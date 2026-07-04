using Microsoft.Win32;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using VisioForge.Core;
using VisioForge.Core.AI.Clip;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace Player_Semantic_Video_Search_X_WPF
{
    /// <summary>
    /// Indexes a video file into CLIP frame embeddings with MediaPlayerCoreX: a VideoEmbeddingBlock is
    /// inserted through Video_Processing_AddBlock and, with Video_Renderer_IsSync = false, the file is
    /// decoded at full speed (not real time) with no dropped samples. A plain-text query is then matched
    /// against the index with a contrastive margin, so the moments that look like the query can be found.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Base URL for the downloadable ONNX model assets (weights are not shipped with the SDK).
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v2";

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models", "clip");

        private const string VisionModelFile = "clip-vitb32-vision.onnx";
        private const string TextModelFile = "clip-vitb32-text.onnx";
        private const string VocabFile = "clip-vocab.json";
        private const string MergesFile = "clip-merges.txt";

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(15) };

        // Maximum number of relevant frames shown per search (after the margin threshold is applied).
        private const int MaxResults = 24;

        // Generic "background" prompts. CLIP's raw cosine carries a large per-prompt bias, so an absent concept
        // still scores ~0.2 on every frame. Subtracting the best of these generic descriptions from the query's
        // cosine cancels that bias, leaving a margin that is positive only where the query beats a plain
        // description of the frame - which is what makes an absent concept (e.g. "a tank") return nothing.
        private static readonly string[] BaselinePrompts =
        {
            "a photo", "a picture", "an image", "a screenshot", "a random background",
        };

        // The shared index (indexing appends into it; search queries it).
        private readonly FrameEmbeddingIndex _index = new FrameEmbeddingIndex();

        // The player that decodes and indexes the file. Video_Renderer_IsSync = false runs it at full speed.
        private MediaPlayerCoreX _player;

        // The embedding block inserted into the player. The engine owns and disposes it on stop; we only
        // detach the handler and drop the reference (never dispose it ourselves).
        private VideoEmbeddingBlock _embeddingBlock;

        // A single CLIP engine reused to encode text queries in the same space as the indexed frames. We own it.
        private ClipEmbeddingEngine _clipEngine;

        private System.Windows.Threading.DispatcherTimer _timer;
        private bool _timerBusy;
        private bool _indexing;
        private TimeSpan _indexDuration;
        private bool _isClosing;
        private bool _cleanupFinished;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Tracks the in-flight background search so teardown can drain it before disposing the engine.
        private Task _searchTask;

        public MainWindow()
        {
            InitializeComponent();
        }

        private OnnxExecutionProvider SelectedProvider =>
            (cbProvider.SelectedItem as ComboBoxItem)?.Tag is OnnxExecutionProvider p ? p : OnnxExecutionProvider.Auto;

        // Frames per second to sample for indexing; drives SampleInterval = 1/fps. Defaults to 1 fps.
        private double SelectedIndexFps =>
            (cbIndexFps.SelectedItem as ComboBoxItem)?.Tag is double f && f > 0 ? f : 1.0;

        private sealed class ResultVM
        {
            public System.Windows.Media.ImageSource Thumb { get; set; }
            public string Caption { get; set; }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                IsEnabled = false;
                try { await VisioForgeX.InitSDKAsync(); }
                finally { IsEnabled = true; Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", string.Empty); }

                _timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
                _timer.Tick += Timer_Tick;

                Title += $" (SDK v{MediaPlayerCoreX.SDK_Version})";

                foreach (var prov in new[] { OnnxExecutionProvider.Auto, OnnxExecutionProvider.CPU, OnnxExecutionProvider.CUDA, OnnxExecutionProvider.DirectML })
                    cbProvider.Items.Add(new ComboBoxItem { Content = prov.ToString(), Tag = prov });
                cbProvider.SelectedIndex = 1;

                // Frames-per-second to index: maps to SampleInterval (1/fps). Higher = denser index, slower indexing.
                foreach (var fps in new[] { 0.5, 1.0, 2.0, 4.0, 5.0, 10.0 })
                    cbIndexFps.Items.Add(new ComboBoxItem { Content = fps.ToString(CultureInfo.InvariantCulture), Tag = fps });
                cbIndexFps.SelectedIndex = 1; // default 1 fps

                PrefillModelPaths();

                mmLog.Text += "Models are cached under %USERPROFILE%/VisioForge/models/clip. Weights are NOT shipped with the SDK." + Environment.NewLine;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        private void PrefillModelPaths()
        {
            edVisionModel.Text = CachedOrEmpty(VisionModelFile);
            edTextModel.Text = CachedOrEmpty(TextModelFile);
            edVocab.Text = CachedOrEmpty(VocabFile);
            edMerges.Text = CachedOrEmpty(MergesFile);
            RefreshModelStatus();
        }

        // Disables the Download button and relabels it once all four CLIP files are present.
        private void RefreshModelStatus()
        {
            if (btDownloadModels == null) return;
            var ready = File.Exists(edVisionModel.Text) && File.Exists(edTextModel.Text)
                        && File.Exists(edVocab.Text) && File.Exists(edMerges.Text);
            btDownloadModels.IsEnabled = !ready;
            btDownloadModels.Content = ready ? "Model files ready" : "Download model files";
        }

        private static string CachedOrEmpty(string fileName)
        {
            var path = Path.Combine(ModelsCacheDir, fileName);
            return File.Exists(path) ? path : string.Empty;
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (_timerBusy || !_indexing) return; _timerBusy = true;
            try
            {
                if (_player != null)
                {
                    if (_indexDuration <= TimeSpan.Zero)
                    {
                        try { _indexDuration = await _player.DurationAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
                    }

                    var pos = await _player.Position_GetAsync();
                    if (_indexDuration > TimeSpan.Zero)
                        pbIndex.Value = Math.Max(0, Math.Min(100, pos.TotalSeconds / _indexDuration.TotalSeconds * 100));

                    lbIndexStatus.Text = $"Indexed frames: {_index.Count}";
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { _timerBusy = false; }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_cleanupFinished) return;
            e.Cancel = true;
            if (_isClosing) return;
            _isClosing = true; IsEnabled = false;

            // Wait for an in-flight Index/Stop to finish before tearing the engine down.
            while (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                await Task.Delay(50);
            }

            try
            {
                _timer?.Stop();

                if (_player != null)
                {
                    _player.OnError -= Player_OnError;
                    _player.OnStop -= Player_OnStop;
                    await _player.StopAsync();
                    await _player.DisposeAsync();
                    _player = null;
                }

                DetachBlock();

                // Drain an in-flight search before disposing the engine it may still be using.
                if (_searchTask != null) { try { await _searchTask; } catch { } }

                _clipEngine?.Dispose();
                _clipEngine = null;

                VideoView1.CallRefresh();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            try { _cleanupFinished = true; Dispatcher.BeginInvoke(new Action(() => Close())); }
            catch (Exception ex) { Debug.WriteLine(ex); _isClosing = false; _cleanupFinished = false; IsEnabled = true; }
        }

        // ---- file / model pickers ----
        private void btSelectVideoFile_Click(object sender, RoutedEventArgs e) => PickFile(edVideoFile, "Video files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts|All files|*.*");
        private void btSelectVision_Click(object sender, RoutedEventArgs e) => PickFile(edVisionModel, "ONNX models|*.onnx|All files|*.*");
        private void btSelectText_Click(object sender, RoutedEventArgs e) => PickFile(edTextModel, "ONNX models|*.onnx|All files|*.*");
        private void btSelectVocab_Click(object sender, RoutedEventArgs e) => PickFile(edVocab, "Vocabulary|*.json|All files|*.*");
        private void btSelectMerges_Click(object sender, RoutedEventArgs e) => PickFile(edMerges, "Merges|*.txt|All files|*.*");

        private void PickFile(TextBox box, string filter)
        {
            var dlg = new OpenFileDialog { Filter = filter };
            if (dlg.ShowDialog() == true) { box.Text = dlg.FileName; RefreshModelStatus(); }
        }

        private bool ModelsSelected()
        {
            if (string.IsNullOrWhiteSpace(edVisionModel.Text) || !File.Exists(edVisionModel.Text) ||
                string.IsNullOrWhiteSpace(edTextModel.Text) || !File.Exists(edTextModel.Text) ||
                string.IsNullOrWhiteSpace(edVocab.Text) || !File.Exists(edVocab.Text) ||
                string.IsNullOrWhiteSpace(edMerges.Text) || !File.Exists(edMerges.Text))
            {
                MessageBox.Show(this, "Select (or download) the four CLIP files on the Models tab.");
                return false;
            }

            return true;
        }

        private VideoEmbeddingSettings BuildEmbeddingSettings()
            => new VideoEmbeddingSettings(edVisionModel.Text, edTextModel.Text, edVocab.Text, edMerges.Text) { Provider = SelectedProvider };

        // ---- model download ----
        private async void btDownloadModels_Click(object sender, RoutedEventArgs e)
        {
            btDownloadModels.IsEnabled = false;
            pnlDownload.Visibility = Visibility.Visible;
            try
            {
                foreach (var fileName in new[] { VisionModelFile, TextModelFile, VocabFile, MergesFile })
                    await DownloadModelAsync(fileName);
                PrefillModelPaths();
                mmLog.Text += "Model files ready." + Environment.NewLine;
                lbDownloadStatus.Text = "All models ready.";
                MessageBox.Show(this, "All model files downloaded and ready.", "Models Ready", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                mmLog.Text += $"Download failed: {ex.Message}" + Environment.NewLine;
                MessageBox.Show(this, $"Download failed:\n{ex.Message}", "Download Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                RefreshModelStatus();
                pnlDownload.Visibility = Visibility.Collapsed; // hide the progress panel once downloads finish (or fail)
            }
        }

        private async System.Threading.Tasks.Task DownloadModelAsync(string fileName)
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, fileName);

            // Already present with a plausible size: skip the download.
            if (File.Exists(destPath) && new FileInfo(destPath).Length > 0)
            {
                mmLog.Text += $"{fileName} already present - skipped." + Environment.NewLine;
                return;
            }

            var tmpPath = destPath + ".part";
            pbDownload.IsIndeterminate = false;
            pbDownload.Value = 0;
            lbDownloadStatus.Text = $"Downloading {fileName}...";
            mmLog.Text += $"Downloading {fileName}..." + Environment.NewLine;

            try
            {
                await System.Threading.Tasks.Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(ModelsReleaseUrl + "/" + fileName, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();
                        var total = response.Content.Headers.ContentLength ?? -1L;
                        Dispatcher.BeginInvoke(new Action(() => pbDownload.IsIndeterminate = total <= 0));

                        using (var src = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = File.Create(tmpPath))
                        {
                            var buffer = new byte[81920];
                            long readTotal = 0;
                            int lastPercent = -1;
                            int read;
                            while ((read = await src.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, read);
                                readTotal += read;
                                if (total > 0)
                                {
                                    var percent = (int)(readTotal * 100 / total);
                                    if (percent != lastPercent)
                                    {
                                        lastPercent = percent;
                                        var done = readTotal;
                                        Dispatcher.BeginInvoke(new Action(() =>
                                        {
                                            pbDownload.Value = percent;
                                            lbDownloadStatus.Text = $"Downloading {fileName}... {percent}% ({done / 1024 / 1024} / {total / 1024 / 1024} MB)";
                                        }));
                                    }
                                }
                            }

                            if (total > 0 && readTotal != total)
                            {
                                throw new IOException($"Incomplete download: received {readTotal} of {total} bytes.");
                            }
                        }
                    }
                });

                File.Move(tmpPath, destPath, true);
                lbDownloadStatus.Text = $"Saved {fileName}.";
                mmLog.Text += $"Saved {fileName} to {ModelsCacheDir}." + Environment.NewLine;
            }
            catch
            {
                try { if (File.Exists(tmpPath)) File.Delete(tmpPath); } catch { }
                throw;
            }
        }

        // ---- indexing ----

        // Disposes any existing engine and builds a fresh MediaPlayerCoreX bound to the same VideoView.
        private async Task RecreatePlayerAsync()
        {
            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                try { await _player.StopAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
                await _player.DisposeAsync();
                _player = null;
            }

            if (_isClosing) return;

            _player = new MediaPlayerCoreX(VideoView1);
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;
        }

        private async void btIndex_Click(object sender, RoutedEventArgs e)
        {
            if (_indexing) return;
            if (!ModelsSelected()) return;

            var path = edVideoFile.Text;
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) { MessageBox.Show(this, "Select a video file to index."); return; }

            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0) return;

            try
            {
                // Build a fresh engine for every indexing session.
                await RecreatePlayerAsync();
                if (_player == null || _isClosing) return;

                // Index at full decode speed (no clock sync) rather than real time. Set BEFORE OpenAsync.
                _player.Video_Renderer_IsSync = false;
                _player.Video_Play = true;
                _player.Audio_Play = false;

                // Video-only source (no audio => no audio renderer).
                var source = await UniversalSourceSettings.CreateAsync(path, renderVideo: true, renderAudio: false);

                // Use the full path as the source tag so search results can locate the file for thumbnails.
                var settings = BuildEmbeddingSettings();
                settings.Index = _index;
                settings.SourceTag = path;
                settings.SampleInterval = TimeSpan.FromSeconds(1.0 / SelectedIndexFps);

                // Backpressure: the block blocks the streaming thread until the CLIP worker is free instead of
                // dropping a sample, so every SampleInterval is captured. Combined with Video_Renderer_IsSync =
                // false the file decodes as fast as the encoder can consume — full speed, no dropped samples.
                settings.BackpressureNoDrop = true;

                _embeddingBlock = new VideoEmbeddingBlock(settings);
                _embeddingBlock.OnFrameEmbedding += Embedding_OnFrameEmbedding;
                _player.Video_Processing_AddBlock(_embeddingBlock);

                _indexDuration = TimeSpan.Zero;
                pbIndex.Value = 0;

                if (!await _player.OpenAsync(source) || !await _player.PlayAsync())
                {
                    mmLog.Text += "Failed to start indexing." + Environment.NewLine;
                    await CleanupAfterStopAsync();
                    return;
                }

                _indexing = true;
                btIndex.IsEnabled = false;
                btIndexStop.IsEnabled = true;
                mmLog.Text += $"Indexing {Path.GetFileName(path)} on {_embeddingBlock.ActiveProvider} (dim {_embeddingBlock.Dimension})..." + Environment.NewLine;
                _timer.Start();
            }
            catch (Exception ex)
            {
                _indexing = false;
                await CleanupAfterStopAsync();
                btIndex.IsEnabled = true; btIndexStop.IsEnabled = false;
                mmLog.Text += ex.Message + Environment.NewLine;
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        private async void btIndexStop_Click(object sender, RoutedEventArgs e)
        {
            if (!_indexing) return;
            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0) return;

            try
            {
                _timer?.Stop();
                await CleanupAfterStopAsync();
                FinalizeIndexing(completed: false);
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        // Stops the player (which disposes the inserted block it owns) and detaches our handler.
        private async Task CleanupAfterStopAsync()
        {
            if (_player != null)
            {
                try { await _player.StopAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
            }

            DetachBlock();
        }

        // Resets the UI at the end of an indexing session (manual stop or end-of-file).
        private void FinalizeIndexing(bool completed)
        {
            _indexing = false;
            pbIndex.Value = 100;
            lbIndexStatus.Text = $"Indexed frames: {_index.Count}";
            mmLog.Text += (completed
                ? $"Indexing complete. Total indexed frames: {_index.Count}."
                : $"Indexing stopped. Total indexed frames: {_index.Count}.") + Environment.NewLine;
            btIndex.IsEnabled = true;
            btIndexStop.IsEnabled = false;
        }

        // Raised on a worker thread for each sampled frame; used to keep the indexed-frame count live.
        private void Embedding_OnFrameEmbedding(object sender, FrameEmbeddingEventArgs e)
        {
            var count = _index.Count;
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing || !_indexing) return;
                lbIndexStatus.Text = $"Indexed frames: {count}";
            }));
        }

        private void Player_OnError(object sender, ErrorsEventArgs e)
            => Dispatcher.BeginInvoke(new Action(() => mmLog.Text += e.Message + Environment.NewLine));

        // End-of-file: the engine has torn the pipeline down and disposed the inserted block. Finish the session.
        private void Player_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing) return;

                // Ignore a stale Stop from a previous session while a start/stop is in flight (manual Stop path).
                if (Volatile.Read(ref _startStopBusy) != 0) return;

                if (!_indexing) return;

                _timer?.Stop();
                DetachBlock();
                FinalizeIndexing(completed: true);
            }));
        }

        /// <summary>
        /// The engine owns and disposes the inserted block on stop, so we only detach the handler and drop the
        /// reference here (we never dispose it ourselves).
        /// </summary>
        private void DetachBlock()
        {
            if (_embeddingBlock != null)
            {
                _embeddingBlock.OnFrameEmbedding -= Embedding_OnFrameEmbedding;
                _embeddingBlock = null;
            }
        }

        private async void btSaveIndex_Click(object sender, RoutedEventArgs e)
        {
            if (_indexing) { MessageBox.Show(this, "Cannot save the index while indexing is active."); return; }
            if (_index.Count == 0) { MessageBox.Show(this, "The index is empty."); return; }
            var dlg = new SaveFileDialog { Filter = "Frame embedding index|*.vfei|All files|*.*", FileName = "frames.vfei" };
            if (dlg.ShowDialog() == true)
            {
                try { await System.Threading.Tasks.Task.Run(() => _index.Save(dlg.FileName)); mmLog.Text += $"Saved {_index.Count} embeddings to {dlg.FileName}." + Environment.NewLine; }
                catch (Exception ex) { mmLog.Text += "Save failed: " + ex.Message + Environment.NewLine; }
            }
        }

        private async void btLoadIndex_Click(object sender, RoutedEventArgs e)
        {
            if (_indexing) { MessageBox.Show(this, "Cannot load an index while indexing is active."); return; }
            var dlg = new OpenFileDialog { Filter = "Frame embedding index|*.vfei|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                try { await System.Threading.Tasks.Task.Run(() => _index.Load(dlg.FileName)); lbIndexStatus.Text = $"Indexed frames: {_index.Count}"; mmLog.Text += $"Loaded {_index.Count} embeddings from {dlg.FileName}." + Environment.NewLine; }
                catch (Exception ex) { mmLog.Text += "Load failed: " + ex.Message + Environment.NewLine; }
            }
        }

        private void btClearIndex_Click(object sender, RoutedEventArgs e)
        {
            if (_indexing) { MessageBox.Show(this, "Cannot clear the index while indexing is active."); return; }
            _index.Clear();
            lbIndexStatus.Text = "Indexed frames: 0";
            icResults.ItemsSource = null;
            mmLog.Text += "Index cleared." + Environment.NewLine;
        }

        // ---- search (decoupled from the player: works during indexing and after teardown) ----
        private ClipEmbeddingEngine GetOrCreateEngine(VideoEmbeddingSettings settings)
        {
            if (_clipEngine != null) return _clipEngine;
            var engine = new ClipEmbeddingEngine(settings);

            // Only cache the engine once it has initialized. If Init fails (or throws), dispose it and surface the
            // error so the next search retries with a fresh engine instead of reusing a half-built one.
            bool ok;
            try { ok = engine.Init(); }
            catch { engine.Dispose(); throw; }

            if (!ok)
            {
                engine.Dispose();
                throw new InvalidOperationException("The CLIP embedding engine failed to initialize. Check the model and tokenizer files on the Models tab.");
            }

            _clipEngine = engine;
            return engine;
        }

        private void slThreshold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbThreshold != null) lbThreshold.Text = slThreshold.Value.ToString("F3", System.Globalization.CultureInfo.InvariantCulture);
        }

        private async void btSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!ModelsSelected()) return;
            if (_index.Count == 0) { MessageBox.Show(this, "Index a video (or load an index) first."); return; }

            var query = edQuery.Text?.Trim();
            if (string.IsNullOrEmpty(query)) { MessageBox.Show(this, "Enter a search query."); return; }

            btSearch.IsEnabled = false;
            lbSearchStatus.Text = "Searching...";
            try
            {
                // Read UI-thread-affine control values (model paths + provider + threshold) before going off-thread.
                var settings = BuildEmbeddingSettings();
                float minMargin = (float)slThreshold.Value;

                // Score each frame by a CONTRASTIVE margin, not raw cosine: margin = cos(frame, query) minus the
                // best cos(frame, generic-prompt). Raw CLIP cosine carries a large per-prompt bias (an absent
                // concept still scores ~0.2 everywhere), so a plain top-K / absolute threshold always "finds"
                // something. Subtracting the best generic description cancels that bias, leaving a value that is
                // positive only where the query genuinely describes the frame better than a plain caption.
                var searchTask = System.Threading.Tasks.Task.Run(() =>
                {
                    var engine = GetOrCreateEngine(settings);

                    var queryCos = _index.Search(engine.EncodeText(query), _index.Count);

                    // Best generic-prompt cosine per frame (keyed by source + timestamp).
                    var baseline = new Dictionary<(string, TimeSpan), float>();
                    foreach (var neg in BaselinePrompts)
                    {
                        foreach (var h in _index.Search(engine.EncodeText(neg), _index.Count))
                        {
                            var key = (h.SourceTag, h.Timestamp);
                            if (!baseline.TryGetValue(key, out var cur) || h.Score > cur)
                            {
                                baseline[key] = h.Score;
                            }
                        }
                    }

                    var list = new List<ResultVM>();
                    var ranked = queryCos
                        .Select(h =>
                        {
                            baseline.TryGetValue((h.SourceTag, h.Timestamp), out var nb);
                            return (hit: h, margin: h.Score - nb);
                        })
                        .Where(r => r.margin >= minMargin)
                        .OrderByDescending(r => r.margin)
                        .Take(MaxResults);

                    foreach (var (hit, margin) in ranked)
                    {
                        var thumb = TryMakeThumbnail(hit.SourceTag, hit.Timestamp);
                        list.Add(new ResultVM
                        {
                            Thumb = thumb,
                            Caption = $"{hit.Timestamp:hh\\:mm\\:ss}   {margin:+0.000;-0.000}",
                        });
                    }

                    return list;
                });
                _searchTask = searchTask;
                var items = await searchTask;

                if (_isClosing)
                {
                    return;
                }

                icResults.ItemsSource = items;
                lbSearchStatus.Text = items.Count > 0
                    ? $"{items.Count} result(s) with margin ≥ {minMargin:F3}."
                    : $"No frames matched with margin ≥ {minMargin:F3}. Lower Min margin or try another query.";
            }
            catch (Exception ex)
            {
                lbSearchStatus.Text = "Search failed.";
                mmLog.Text += "Search failed: " + ex.Message + Environment.NewLine;
                MessageBox.Show(this, $"Search failed:\n{ex.Message}", "Search Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally { btSearch.IsEnabled = true; }
        }

        // Extracts a frozen thumbnail bitmap at the given timestamp (safe to build on a background thread).
        private static System.Windows.Media.ImageSource TryMakeThumbnail(string filePath, TimeSpan timestamp)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath)) return null;

                using (var bmp = MediaInfoReaderX.GetFileSnapshotSKBitmap(filePath, timestamp))
                {
                    if (bmp == null) return null;

                    using (var image = SKImage.FromBitmap(bmp))
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 85))
                    using (var ms = new MemoryStream(data.ToArray()))
                    {
                        var bi = new BitmapImage();
                        bi.BeginInit();
                        bi.CacheOption = BitmapCacheOption.OnLoad;
                        bi.DecodePixelWidth = 180;
                        bi.StreamSource = ms;
                        bi.EndInit();
                        bi.Freeze();
                        return bi;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

    }
}
