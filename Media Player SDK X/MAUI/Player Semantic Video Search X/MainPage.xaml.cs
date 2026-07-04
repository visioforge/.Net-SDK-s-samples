using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using VisioForge.Core;
using VisioForge.Core.AI.Clip;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.MAUI;

namespace Player_Semantic_Video_Search_X
{
    /// <summary>
    /// Indexes a video file into CLIP frame embeddings with MediaPlayerCoreX: a VideoEmbeddingBlock is
    /// inserted through Video_Processing_AddBlock and, with Video_Renderer_IsSync = false, the file is
    /// decoded at full speed (not real time) with no dropped samples. A plain-text query is then matched
    /// against the index with a contrastive margin, so the moments that look like the query can be found.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        // The player that decodes and indexes the file. Video_Renderer_IsSync = false runs it at full speed.
        private MediaPlayerCoreX _player;

        // The embedding block inserted into the player. The engine owns and disposes it on stop; we only
        // detach the handler and drop the reference (never dispose it ourselves).
        private VideoEmbeddingBlock _embeddingBlock;

        // The shared semantic index: the embedding block appends each sampled frame; queries search it.
        private readonly FrameEmbeddingIndex _index = new FrameEmbeddingIndex();

        // Standalone CLIP engine used only to encode text queries, decoupled from the player so search keeps
        // working after indexing finishes and the player (and its embedding block) has been torn down. We own it.
        private ClipEmbeddingEngine _clipEngine;

        // Frames-per-second choices for indexing; the selected value maps to SampleInterval = 1/fps.
        private static readonly double[] IndexFpsOptions = { 0.5, 1.0, 2.0, 4.0, 5.0, 10.0 };

        // Maximum number of relevant frames shown per search (after the margin threshold is applied).
        private const int MaxResults = 24;

        // Generic "background" prompts. CLIP's raw cosine carries a large per-prompt bias, so an absent concept
        // still scores ~0.2 on every frame. Subtracting the best of these generic descriptions from the query's
        // cosine cancels that bias, leaving a margin that is positive only where the query beats a plain description
        // of the frame — which is what makes an absent concept (e.g. "a tank") return nothing.
        private static readonly string[] BaselinePrompts =
        {
            "a photo", "a picture", "an image", "a screenshot", "a random background",
        };

        // The picked video file, copied to a stable local path.
        private string _filename;

        private bool _isRunning;
        private bool _isCleanedUp;

        // Single-shot atomic claim so concurrent Unloaded + Window.Destroying can't both run teardown.
        private int _cleanupClaimed;

        // Captured so the Window.Destroying handler can be unsubscribed on cleanup.
        private Window _window;

        // START/STOP re-entrancy guard (0 = free, 1 = busy).
        private int _startStopBusy;

        // In-flight search guard (0 = free, 1 = busy). Drained by CleanupAsync before disposing _clipEngine.
        private int _searchBusy;

        // ---- CLIP model files (hosted in the SDK samples release; not shipped in NuGet) ----
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v2";

        private const string VisionModelFile = "clip-vitb32-vision.onnx";
        private const string TextModelFile = "clip-vitb32-text.onnx";
        private const string VocabFile = "clip-vocab.json";
        private const string MergesFile = "clip-merges.txt";

        // Downloaded models are cached here; AppDataDirectory is writable on every platform.
        private static string ModelsCacheDir => Path.Combine(FileSystem.AppDataDirectory, "models", "clip");

        // Default path used when saving the in-memory index.
        private static string DefaultIndexPath => Path.Combine(FileSystem.AppDataDirectory, "frames.vfei");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(15) };

        private string _visionPath;
        private string _textPath;
        private string _vocabPath;
        private string _mergesPath;

        // A single search hit as displayed in the results list (timestamp + score + source file).
        public sealed class SearchResultItem
        {
            public string Time { get; set; }

            public string Score { get; set; }

            public string Source { get; set; }
        }

        static MainPage()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-SemanticVideoSearch-Demo/1.0");
        }

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;
        }

        private async void MainPage_Unloaded(object sender, EventArgs e)
        {
            try
            {
                await CleanupAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            // Re-arm cleanup/guard flags: MAUI reuses the page instance after an Unloaded teardown.
            _isCleanedUp = false;
            _isRunning = false;
            Interlocked.Exchange(ref _cleanupClaimed, 0);
            Interlocked.Exchange(ref _startStopBusy, 0);
            Interlocked.Exchange(ref _searchBusy, 0);

            try
            {
                await VisioForgeX.InitSDKAsync();

                // Page torn down during the await — CleanupAsync already ran DestroySDK; bail.
                if (_isCleanedUp)
                {
                    return;
                }

                // Drop any copied source videos left in the cache by a previous run.
                try
                {
                    foreach (var stale in Directory.EnumerateFiles(FileSystem.CacheDirectory, "source_*"))
                    {
                        try { File.Delete(stale); } catch (Exception delEx) { Debug.WriteLine(delEx); }
                    }
                }
                catch (Exception ex) { Debug.WriteLine(ex); }

                // Populate the frames-per-second picker (default 1 fps).
                var fpsItems = new List<string>();
                foreach (var f in IndexFpsOptions)
                {
                    fpsItems.Add(f.ToString(CultureInfo.InvariantCulture));
                }

                pkIndexFps.ItemsSource = fpsItems;
                pkIndexFps.SelectedIndex = 1;

                // Prefill model paths from the cache when they were already downloaded.
                ResolveCachedModels();
                RefreshModelStatus();

                _window = Window;
                if (_window != null)
                {
                    _window.Destroying += Window_Destroying;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void ResolveCachedModels()
        {
            _visionPath = CachedOrNull(VisionModelFile);
            _textPath = CachedOrNull(TextModelFile);
            _vocabPath = CachedOrNull(VocabFile);
            _mergesPath = CachedOrNull(MergesFile);
        }

        private static string CachedOrNull(string fileName)
        {
            var path = Path.Combine(ModelsCacheDir, fileName);
            return File.Exists(path) && new FileInfo(path).Length > 0 ? path : null;
        }

        private bool ModelsReady =>
            !string.IsNullOrEmpty(_visionPath) && File.Exists(_visionPath) &&
            !string.IsNullOrEmpty(_textPath) && File.Exists(_textPath) &&
            !string.IsNullOrEmpty(_vocabPath) && File.Exists(_vocabPath) &&
            !string.IsNullOrEmpty(_mergesPath) && File.Exists(_mergesPath);

        private void RefreshModelStatus()
        {
            lbModels.Text = ModelsReady ? "Models: ready (CLIP ViT-B/32)" : "Models: not downloaded";

            // Hide the Download button once all four CLIP files are cached.
            btDownloadModels.IsVisible = !ModelsReady;
        }

        private async void btDownloadModels_Clicked(object sender, EventArgs e)
        {
            btDownloadModels.IsEnabled = false;
            var original = btDownloadModels.Text;
            btDownloadModels.Text = "Downloading...";
            pbDownload.Progress = 0;
            pbDownload.IsVisible = true;

            try
            {
                Directory.CreateDirectory(ModelsCacheDir);
                foreach (var fileName in new[] { VisionModelFile, TextModelFile, VocabFile, MergesFile })
                {
                    await DownloadAsync(fileName);
                }

                ResolveCachedModels();
            }
            catch (Exception ex)
            {
                lbModels.Text = "Models: download failed";
                await DisplayAlert("Download failed", $"{ex.Message}", "OK");
            }
            finally
            {
                if (!_isCleanedUp)
                {
                    pbDownload.IsVisible = false;
                    btDownloadModels.IsEnabled = true;
                    btDownloadModels.Text = original;
                    RefreshModelStatus();
                }
            }
        }

        private async Task<string> DownloadAsync(string fileName)
        {
            var dest = Path.Combine(ModelsCacheDir, fileName);

            // Already present with a plausible size: skip.
            if (File.Exists(dest) && new FileInfo(dest).Length > 0)
            {
                return dest;
            }

            var temp = dest + ".part";
            Dispatcher?.Dispatch(() => lbModels.Text = $"Downloading {fileName}...");

            try
            {
                // Run the download off the UI thread; progress is marshalled back via the Dispatcher.
                await Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(ModelsReleaseUrl + "/" + fileName, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        var total = response.Content.Headers.ContentLength ?? -1L;
                        using (var src = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = File.Create(temp))
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
                                        var progress = percent / 100.0;
                                        Dispatcher?.Dispatch(() => { if (_isCleanedUp) return; pbDownload.Progress = progress; });
                                    }
                                }
                            }

                            // Reject a truncated download so a partial file is never cached as complete.
                            if (total > 0 && readTotal != total)
                            {
                                throw new IOException($"Incomplete download: received {readTotal} of {total} bytes.");
                            }
                        }
                    }

                    File.Move(temp, dest, overwrite: true);
                });

                return dest;
            }
            catch
            {
                // Best-effort cleanup of the partial download before propagating.
                try { if (File.Exists(temp)) File.Delete(temp); } catch { }
                throw;
            }
        }

        // Frames per second to sample for indexing; drives SampleInterval = 1/fps. Defaults to 1 fps.
        private double SelectedIndexFps =>
            (pkIndexFps.SelectedIndex >= 0 && pkIndexFps.SelectedIndex < IndexFpsOptions.Length)
                ? IndexFpsOptions[pkIndexFps.SelectedIndex]
                : 1.0;

        private VideoEmbeddingSettings BuildEmbeddingSettings()
        {
            return new VideoEmbeddingSettings(_visionPath, _textPath, _vocabPath, _mergesPath)
            {
                Index = _index,
                SourceTag = _filename,
                SampleInterval = TimeSpan.FromSeconds(1.0 / SelectedIndexFps),
                Provider = OnnxExecutionProvider.Auto,

                // Block the streaming thread until the CLIP worker is free instead of dropping samples, so the
                // file decodes at full speed (with Video_Renderer_IsSync = false) but every interval is captured.
                BackpressureNoDrop = true,
            };
        }

        // Lazily builds the standalone text-encoding CLIP engine from the cached model paths. Used by search only;
        // independent of the player so queries work whether or not indexing is running.
        private ClipEmbeddingEngine EnsureClipEngine(VideoEmbeddingSettings settings)
        {
            if (_clipEngine != null)
            {
                return _clipEngine;
            }

            var engine = new ClipEmbeddingEngine(settings);

            bool ok;
            try { ok = engine.Init(); }
            catch { engine.Dispose(); throw; }

            if (!ok)
            {
                engine.Dispose();
                throw new InvalidOperationException("The CLIP engine failed to initialize. Check the model files on the Models row.");
            }

            _clipEngine = engine;
            return engine;
        }

        private async void btStartStop_Clicked(object sender, EventArgs e)
        {
            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                return;
            }

            try
            {
                if (_isRunning)
                {
                    await StopAsync();
                }
                else
                {
                    await StartAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

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

            if (_isCleanedUp)
            {
                return;
            }

            _player = new MediaPlayerCoreX(videoView.GetVideoView());
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;
        }

        private async Task StartAsync()
        {
            if (_isCleanedUp)
            {
                return;
            }

            if (string.IsNullOrEmpty(_filename) || !File.Exists(_filename))
            {
                await DisplayAlert("File required", "Tap OPEN FILE and pick a video first.", "OK");
                return;
            }

            if (!ModelsReady)
            {
                await DisplayAlert("Models required", "Tap DOWNLOAD MODELS first.", "OK");
                return;
            }

            // Build a fresh engine for every indexing session.
            await RecreatePlayerAsync();
            if (_player == null || _isCleanedUp)
            {
                return;
            }

            // Index at full decode speed (no clock sync) rather than real time. Set BEFORE OpenAsync.
            _player.Video_Renderer_IsSync = false;
            _player.Video_Play = true;
            _player.Audio_Play = false;

            // Video-only source (no audio => no audio renderer). iOS exposes only the NSUrl overload.
#if IOS && !MACCATALYST
            var source = await UniversalSourceSettings.CreateAsync(Foundation.NSUrl.FromFilename(_filename), renderVideo: true, renderAudio: false);
#else
            var source = await UniversalSourceSettings.CreateAsync(_filename, renderVideo: true, renderAudio: false);
#endif

            var settings = BuildEmbeddingSettings();

            _embeddingBlock = new VideoEmbeddingBlock(settings);
            _embeddingBlock.OnFrameEmbedding += Embedding_OnFrameEmbedding;
            _player.Video_Processing_AddBlock(_embeddingBlock);

            try
            {
                if (!await _player.OpenAsync(source) || !await _player.PlayAsync())
                {
                    // Start failed: tear the player down (StopAsync also disposes the block), then surface it.
                    await StopAsync();
                    await DisplayAlert("Error", "Failed to start indexing.", "OK");
                    return;
                }
            }
            catch
            {
                // A failed build disposes the block inside the engine; drop our stale reference.
                DetachBlock();
                throw;
            }

            _isRunning = true;
            btStartStop.Text = "STOP";
            btStartStop.BackgroundColor = Colors.Red;
            lbIndex.Text = $"Indexing... ({_index.Count} frames)";
        }

        // Manual STOP: stop the player (which disposes the inserted block it owns) and return to START.
        private async Task StopAsync()
        {
            if (_player != null)
            {
                await _player.StopAsync();
            }

            DetachBlock();
            _isRunning = false;
            UpdateIdleUI(completed: false);
        }

        // Resets the Start/Stop button and status label to the idle (not indexing) state.
        private void UpdateIdleUI(bool completed)
        {
            btStartStop.Text = "START";
            btStartStop.BackgroundColor = Color.FromRgb(76, 175, 80);
            lbIndex.Text = completed
                ? $"Indexing complete: {_index.Count} frames. Enter a query and tap SEARCH."
                : $"Indexed frames: {_index.Count} (stopped)";
        }

        // Raised on a worker thread for each sampled frame; used only to keep the indexed-frame count live.
        private void Embedding_OnFrameEmbedding(object sender, FrameEmbeddingEventArgs e)
        {
            var count = _index.Count;
            Dispatcher?.Dispatch(() =>
            {
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                lbIndex.Text = $"Indexing... ({count} frames)";
            });
        }

        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine($"Player error: {e.Message}");
        }

        // End-of-file for the video: the engine tore the pipeline down and disposed the inserted block. Finish the
        // session and return the button to START. Search stays available via the standalone _clipEngine.
        private void Player_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher?.Dispatch(() =>
            {
                if (_isCleanedUp)
                {
                    return;
                }

                // Ignore a stale Stop from a previous session while a manual start/stop is in flight.
                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (!_isRunning)
                {
                    return;
                }

                DetachBlock();
                _isRunning = false;
                UpdateIdleUI(completed: true);
            });
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

        private void slThreshold_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (lbThreshold != null)
            {
                lbThreshold.Text = slThreshold.Value.ToString("F3", CultureInfo.InvariantCulture);
            }
        }

        private async void btSearch_Clicked(object sender, EventArgs e)
        {
            var query = edQuery.Text?.Trim();
            if (string.IsNullOrEmpty(query))
            {
                await DisplayAlert("Query required", "Enter a search phrase, e.g. \"a red car\".", "OK");
                return;
            }

            if (!ModelsReady)
            {
                await DisplayAlert("Models required", "Tap DOWNLOAD MODELS first.", "OK");
                return;
            }

            if (_index.Count == 0)
            {
                await DisplayAlert("Empty index", "No frames indexed yet. Index a video (or load a saved index) first.", "OK");
                return;
            }

            // Claim the search guard so CleanupAsync can't dispose _clipEngine while the search runs.
            if (Interlocked.CompareExchange(ref _searchBusy, 1, 0) != 0)
            {
                return;
            }

            btSearch.IsEnabled = false;
            try
            {
                // Read UI-thread-affine values (threshold + settings that read pickers) before going off-thread.
                float minMargin = (float)slThreshold.Value;
                var settings = BuildEmbeddingSettings();

                // Score each frame by a CONTRASTIVE margin, not raw cosine: margin = cos(frame, query) minus the best
                // cos(frame, generic-prompt). Raw CLIP cosine carries a large per-prompt bias (an absent concept still
                // scores ~0.2 everywhere), so a plain top-K always "finds" something. Subtracting the best generic
                // description cancels that bias, leaving a value that is positive only where the query genuinely
                // describes the frame better than a plain caption — so an absent concept (e.g. "a tank") returns
                // nothing. The standalone engine keeps search working during indexing and after it finishes.
                var items = await Task.Run(() =>
                {
                    var engine = EnsureClipEngine(settings);

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

                    var ranked = queryCos
                        .Select(h =>
                        {
                            baseline.TryGetValue((h.SourceTag, h.Timestamp), out var nb);
                            return (hit: h, margin: h.Score - nb);
                        })
                        .Where(r => r.margin >= minMargin)
                        .OrderByDescending(r => r.margin)
                        .Take(MaxResults);

                    var list = new List<SearchResultItem>();
                    foreach (var (hit, margin) in ranked)
                    {
                        list.Add(new SearchResultItem
                        {
                            Time = string.Format(CultureInfo.InvariantCulture, "{0:00}:{1:00}:{2:00}", (int)hit.Timestamp.TotalHours, hit.Timestamp.Minutes, hit.Timestamp.Seconds),
                            Score = margin.ToString("F3", CultureInfo.InvariantCulture),
                            Source = string.IsNullOrEmpty(hit.SourceTag) ? string.Empty : Path.GetFileName(hit.SourceTag),
                        });
                    }

                    return list;
                });

                if (_isCleanedUp)
                {
                    return;
                }

                cvResults.ItemsSource = items;
                lbIndex.Text = items.Count > 0
                    ? $"Indexed frames: {_index.Count}  |  {items.Count} match(es) with margin ≥ {minMargin.ToString("F3", CultureInfo.InvariantCulture)}"
                    : $"Indexed frames: {_index.Count}  |  no match with margin ≥ {minMargin.ToString("F3", CultureInfo.InvariantCulture)} — lower Min margin or try another query";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Search failed", ex.Message, "OK");
            }
            finally
            {
                btSearch.IsEnabled = true;
                Interlocked.Exchange(ref _searchBusy, 0);
            }
        }

        private async void btSaveIndex_Clicked(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                await DisplayAlert("Indexing in progress", "Cannot save the index while indexing is active.", "OK");
                return;
            }

            if (_index.Count == 0)
            {
                await DisplayAlert("Empty index", "There is nothing to save yet.", "OK");
                return;
            }

            try
            {
                await Task.Run(() => _index.Save(DefaultIndexPath));
                await DisplayAlert("Saved", $"Saved {_index.Count} embeddings to:\n{DefaultIndexPath}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Save failed", ex.Message, "OK");
            }
        }

        private async void btLoadIndex_Clicked(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                await DisplayAlert("Indexing in progress", "Cannot load an index while indexing is active.", "OK");
                return;
            }

            try
            {
                var pick = await FilePicker.Default.PickAsync(new PickOptions { PickerTitle = "Select a saved index (.vfei)" });
                if (pick == null)
                {
                    return;
                }

                // Copy to a stable local path (Android content URIs aren't openable by _index.Load); removed once loaded into memory.
                Directory.CreateDirectory(FileSystem.CacheDirectory);
                var localIndex = Path.Combine(FileSystem.CacheDirectory, $"index_{Guid.NewGuid():N}{Path.GetExtension(pick.FileName)}");
                using (var src = await pick.OpenReadAsync())
                using (var dst = File.Create(localIndex))
                {
                    await src.CopyToAsync(dst);
                }

                try
                {
                    await Task.Run(() => _index.Load(localIndex));
                }
                finally
                {
                    try { if (File.Exists(localIndex)) File.Delete(localIndex); } catch (Exception delEx) { Debug.WriteLine(delEx); }
                }
                cvResults.ItemsSource = null;
                lbIndex.Text = $"Loaded index: {_index.Count} frames";
                await DisplayAlert("Loaded", $"Loaded {_index.Count} embeddings.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Load failed", ex.Message, "OK");
            }
        }

        private async void btClearIndex_Clicked(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                await DisplayAlert("Indexing in progress", "Cannot clear the index while indexing is active.", "OK");
                return;
            }

            _index.Clear();
            cvResults.ItemsSource = null;
            lbIndex.Text = "Indexed frames: 0";
        }

        private async void btOpenFile_Clicked(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                return;
            }

            string dest = null;
            try
            {
                var result = await FilePicker.Default.PickAsync(new PickOptions { PickerTitle = "Select a video file" });
                if (result == null)
                {
                    return;
                }

                // Copy to a stable local path (content URIs aren't openable by the demuxer); GUID name avoids collisions.
                Directory.CreateDirectory(FileSystem.CacheDirectory);
                dest = Path.Combine(FileSystem.CacheDirectory, $"source_{Guid.NewGuid():N}{Path.GetExtension(result.FileName)}");
                using (var src = await result.OpenReadAsync())
                using (var dst = File.Create(dest))
                {
                    await src.CopyToAsync(dst);
                }

                // Switch to the new copy only after it succeeds, then drop the previous one so caches don't accumulate.
                var previous = _filename;
                _filename = dest;
                lbFile.Text = result.FileName;
                if (!string.IsNullOrEmpty(previous))
                {
                    try { if (File.Exists(previous)) File.Delete(previous); } catch (Exception delEx) { Debug.WriteLine(delEx); }
                }
            }
            catch (Exception ex)
            {
                // Best-effort cleanup of a partial copy before surfacing the error.
                if (dest != null)
                {
                    try { if (File.Exists(dest)) File.Delete(dest); } catch (Exception delEx) { Debug.WriteLine(delEx); }
                }

                await DisplayAlert("Open failed", ex.Message, "OK");
            }
        }

        private async void Window_Destroying(object sender, EventArgs e)
        {
            try
            {
                await CleanupAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async Task CleanupAsync()
        {
            // Atomically claim teardown so Unloaded and Window.Destroying can't both run it.
            if (Interlocked.Exchange(ref _cleanupClaimed, 1) == 1)
            {
                return;
            }

            _isCleanedUp = true;

            // Drain and claim the Start/Stop guard before disposing the engine, so teardown can't race a live StartAsync.
            while (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                await Task.Delay(50);
            }

            if (_window != null)
            {
                _window.Destroying -= Window_Destroying;
                _window = null;
            }

            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                await _player.StopAsync();
                await _player.DisposeAsync();
                _player = null;
            }

            DetachBlock();

            // Drain any in-flight search so we don't dispose _clipEngine while it is still encoding.
            while (Interlocked.CompareExchange(ref _searchBusy, 1, 0) != 0)
            {
                await Task.Delay(50);
            }

            _clipEngine?.Dispose();
            _clipEngine = null;

            // Drop the copied source video from the cache so large files don't linger after teardown.
            if (!string.IsNullOrEmpty(_filename))
            {
                try { if (File.Exists(_filename)) File.Delete(_filename); } catch (Exception ex) { Debug.WriteLine(ex); }
                _filename = null;
            }

            VisioForgeX.DestroySDK();
        }
    }
}
