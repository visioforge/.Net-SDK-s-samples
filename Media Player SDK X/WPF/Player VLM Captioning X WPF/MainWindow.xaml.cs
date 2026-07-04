using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Win32;

using VisioForge.Core;
using VisioForge.Core.AI;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace Player_VLM_Captioning_X_WPF
{
    /// <summary>
    /// Plays a video file with MediaPlayerCoreX and inserts a Florence-2 VLM captioning block through the
    /// X-engine Video_Processing_AddBlock API: the block taps the decoded video, runs the selected VLM task
    /// (caption, detailed caption, object detection, OCR, phrase grounding, ...) on sampled frames, optionally
    /// draws the results into the rendered frame, and raises OnResultGenerated while the engine plays the file.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayerCoreX _player;
        private VLMBlock _vlm;
        private bool _isClosing;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Base URL for the downloadable ONNX model assets (weights are not shipped with the SDK).
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v2";

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models", "vlm");

        // The full Florence-2 asset set resolved by VLMSettings(modelFolder) via its conventional file names.
        private static readonly string[] ModelFiles =
        {
            VLMSettings.VisionEncoderFileName,
            VLMSettings.EmbedTokensFileName,
            VLMSettings.EncoderFileName,
            VLMSettings.DecoderFileName,
            VLMSettings.VocabFileName,
            VLMSettings.MergesFileName,
            VLMSettings.AddedTokensFileName,
        };

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(15) };

        private readonly ObservableCollection<ResultRow> _results = new ObservableCollection<ResultRow>();

        static MainWindow()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-AI-Demo/1.0");
        }

        public MainWindow()
        {
            InitializeComponent();
            dgResults.ItemsSource = _results;
        }

        private sealed class ResultRow
        {
            public string Timestamp { get; set; }
            public string Task { get; set; }
            public string Text { get; set; }
            public string InferenceTimeMs { get; set; }
        }

        private VLMTask SelectedTask =>
            (cbTask.SelectedItem as ComboBoxItem)?.Tag is VLMTask t ? t : VLMTask.Caption;

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();

                // The engine is created fresh per session in btStart_Click (RecreatePlayerAsync).

                foreach (VLMTask t in Enum.GetValues(typeof(VLMTask)))
                {
                    cbTask.Items.Add(new ComboBoxItem { Content = t.ToString(), Tag = t });
                }

                cbTask.SelectedIndex = 0;

                // Prefill the model folder with the cache dir when the assets are already present.
                if (ModelFiles.All(f => File.Exists(Path.Combine(ModelsCacheDir, f))))
                {
                    edModelFolder.Text = ModelsCacheDir;
                }

                RefreshModelStatus();

                Log($"SDK v{MediaPlayerCoreX.SDK_Version} ready.");
                Log("ONNX Runtime providers: " + string.Join(", ", OnnxInferenceEngine.GetAvailableProviders()));
                Log("Florence-2 weights are NOT shipped with the SDK; download them on first run.");
            }
            catch (Exception ex)
            {
                Log("load error: " + ex.Message);
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private void Log(string text)
        {
            if (_isClosing)
            {
                return;
            }

            _ = Dispatcher.BeginInvoke(new Action(() => lbStatus.Text = text));
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Media files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts|All files|*.*" };
            if (dialog.ShowDialog() == true)
            {
                edFile.Text = dialog.FileName;
            }
        }

        private void btSelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog { Title = "Select the Florence-2 model folder" };
            if (dialog.ShowDialog() == true)
            {
                edModelFolder.Text = dialog.FolderName;
            }
        }

        private void edModelFolder_TextChanged(object sender, TextChangedEventArgs e) => RefreshModelStatus();

        // Disables the Download button and relabels it once every Florence-2 file is present in the selected folder.
        private void RefreshModelStatus()
        {
            if (btDownloadModels == null)
            {
                return;
            }

            var folder = edModelFolder.Text;
            var ready = !string.IsNullOrWhiteSpace(folder) && Directory.Exists(folder)
                        && ModelFiles.All(f => File.Exists(Path.Combine(folder, f)));
            btDownloadModels.IsEnabled = !ready;
            btDownloadModels.Content = ready ? "Model files ready" : "Download model files";
        }

        private void cbTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized)
            {
                return;
            }

            var task = SelectedTask;
            if (edTextInput != null)
            {
                edTextInput.IsEnabled = task == VLMTask.PhraseGrounding;
            }

            // Task can be changed live; the change takes effect on the next inference.
            if (_vlm != null)
            {
                _vlm.Task = task;
            }
        }

        private void edTextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_vlm != null)
            {
                _vlm.TextInput = edTextInput.Text;
            }
        }

        // ---- model download ----
        private async void btDownloadModels_Click(object sender, RoutedEventArgs e)
        {
            btDownloadModels.IsEnabled = false;
            pnlDownload.Visibility = Visibility.Visible;
            try
            {
                foreach (var fileName in ModelFiles)
                {
                    await DownloadModelAsync(fileName);
                }

                edModelFolder.Text = ModelsCacheDir;
                lbDownloadStatus.Text = "All models ready.";
                MessageBox.Show(this, "All model files downloaded and ready.", "Models Ready", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Download failed:\n{ex.Message}", "Download Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                RefreshModelStatus();
                pnlDownload.Visibility = Visibility.Collapsed; // hide the progress panel once downloads finish (or fail)
            }
        }

        private async Task DownloadModelAsync(string fileName)
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, fileName);

            // Already present with a plausible size: skip the download.
            if (File.Exists(destPath) && new FileInfo(destPath).Length > 0)
            {
                return;
            }

            var tmpPath = destPath + ".part";
            pbDownload.IsIndeterminate = false;
            pbDownload.Value = 0;
            lbDownloadStatus.Text = $"Downloading {fileName}...";

            try
            {
                // Download off the UI thread so a large model can't freeze the window.
                await Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(ModelsReleaseUrl + "/" + fileName, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();
                        var total = response.Content.Headers.ContentLength ?? -1L;
                        Dispatcher.BeginInvoke(new Action(() => pbDownload.IsIndeterminate = total <= 0));

                        using (var src = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(tmpPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
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
            }
            catch
            {
                try { if (File.Exists(tmpPath)) { File.Delete(tmpPath); } } catch { /* best-effort cleanup */ }
                throw;
            }
        }

        // Disposes any existing engine and builds a fresh MediaPlayerCoreX bound to the same VideoView.
        private async Task RecreatePlayerAsync()
        {
            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                try { await _player.StopAsync(); } catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex); }
                await _player.DisposeAsync();
                _player = null;
            }

            if (_isClosing)
            {
                return;
            }

            _player = new MediaPlayerCoreX(VideoView1);
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edFile.Text))
            {
                MessageBox.Show(this, "Select a media file.");
                return;
            }

            var folder = edModelFolder.Text;
            if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder))
            {
                MessageBox.Show(this, "Select (or download) the Florence-2 model folder.");
                return;
            }

            foreach (var f in ModelFiles)
            {
                if (!File.Exists(Path.Combine(folder, f)))
                {
                    MessageBox.Show(this, $"Missing model file: {f}");
                    return;
                }
            }

            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                return;
            }

            try
            {
                btStart.IsEnabled = false;
                _results.Clear();

                // Build the engine from scratch for every session.
                await RecreatePlayerAsync();
                if (_player == null || _isClosing)
                {
                    return;
                }

                // Build the source before registering the block so a CreateAsync failure strands nothing.
                var source = await UniversalSourceSettings.CreateAsync(edFile.Text, renderVideo: true, renderAudio: false);

                var settings = new VLMSettings(folder)
                {
                    Task = SelectedTask,
                    TextInput = edTextInput.Text,
                    DrawResults = cbDrawResults.IsChecked == true,
                };

                if (double.TryParse(edInterval.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var interval))
                {
                    settings.ProcessingInterval = TimeSpan.FromSeconds(Math.Max(0.5, Math.Min(10.0, interval)));
                }

                if (int.TryParse(edMaxTokens.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var maxTokens) && maxTokens > 0)
                {
                    settings.MaxNewTokens = maxTokens;
                }

                _vlm = new VLMBlock(settings);
                _vlm.OnResultGenerated += Vlm_OnResultGenerated;
                _player.Video_Processing_AddBlock(_vlm);

                _player.Video_Play = true;
                _player.Audio_Play = false;

                if (!await _player.OpenAsync(source) || !await _player.PlayAsync())
                {
                    Log("start error: failed to open or play the source.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                lbStatus.Text = $"Provider: {_vlm.ActiveProvider}";
                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                // StopAsync tears down the pipeline and disposes any wired block it owns.
                Log("start error: " + ex.Message);
                await CleanupAfterStopAsync();
                btStart.IsEnabled = true;
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        private void Vlm_OnResultGenerated(object sender, VLMResultGeneratedEventArgs e)
        {
            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                var text = e.Text;
                if (string.IsNullOrEmpty(text) && e.Regions != null && e.Regions.Length > 0)
                {
                    text = string.Join(", ", e.Regions.Select(r => r.Label));
                }

                _results.Insert(0, new ResultRow
                {
                    Timestamp = e.Timestamp.ToString("hh\\:mm\\:ss"),
                    Task = e.Task.ToString(),
                    Text = text,
                    InferenceTimeMs = e.InferenceTimeMs.ToString("F0", CultureInfo.InvariantCulture),
                });

                while (_results.Count > 200)
                {
                    _results.RemoveAt(_results.Count - 1);
                }
            }));
        }

        private void Player_OnError(object sender, ErrorsEventArgs e) => Log(e.Message);

        private void Player_OnStop(object sender, StopEventArgs e)
        {
            // The engine disposes the inserted block on stop; drop our reference so the next Start re-creates one.
            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing)
                {
                    return;
                }

                // Ignore a stale Stop from a previous session while a start/stop is in flight.
                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_player != null && _player.State != PlaybackState.Free)
                {
                    return;
                }

                DetachBlock();
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
            }));
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                return;
            }

            btStop.IsEnabled = false;
            try
            {
                await CleanupAfterStopAsync();
            }
            catch (Exception ex)
            {
                Log("stop error: " + ex.Message);
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }

            btStart.IsEnabled = true;
        }

        private async Task CleanupAfterStopAsync()
        {
            if (_player != null)
            {
                await _player.StopAsync();
            }

            DetachBlock();
        }

        /// <summary>
        /// The engine owns and disposes the inserted block once started, so we only detach the handler and drop
        /// the reference here (we do not dispose it ourselves).
        /// </summary>
        private void DetachBlock()
        {
            if (_vlm != null)
            {
                _vlm.OnResultGenerated -= Vlm_OnResultGenerated;
                _vlm = null;
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing)
            {
                return;
            }

            e.Cancel = true;
            _isClosing = true;
            IsEnabled = false;

            // Wait for an in-flight Start/Stop to finish before tearing the engine down.
            while (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                await Task.Delay(50);
            }

            try
            {
                if (_player != null)
                {
                    _player.OnError -= Player_OnError;
                    _player.OnStop -= Player_OnStop;
                    await _player.StopAsync();
                    await _player.DisposeAsync();
                    _player = null;
                }

                DetachBlock();

                VideoView1.CallRefresh();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            _ = Dispatcher.BeginInvoke(new Action(() => Close()));
        }
    }
}
