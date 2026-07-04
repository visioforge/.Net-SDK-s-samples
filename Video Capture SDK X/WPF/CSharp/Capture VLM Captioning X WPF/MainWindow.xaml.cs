using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace Capture_VLM_Captioning_X_WPF
{
    /// <summary>
    /// Inserts a Florence-2 VLMBlock into VideoCaptureCoreX via Video_Processing_AddBlock: it taps the
    /// live camera frames, runs the selected vision-language task, draws the result over the preview, and
    /// raises OnResultGenerated. Task and text input can be changed while capture runs.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _core;
        private VLMBlock _vlm;
        private VideoCaptureDeviceInfo[] _cameras;
        private bool _isClosing;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        private System.Windows.Threading.DispatcherTimer _timer;
        private bool _timerBusy;

        private readonly ObservableCollection<ResultRow> _results = new ObservableCollection<ResultRow>();

        // Base URL for the downloadable ONNX model assets (weights are not shipped with the SDK).
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v2";

        // Downloaded models are cached here.
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

                // The engine is created fresh per session in RecreateEngineAsync, so nothing to construct here.

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                if (_cameras != null)
                {
                    foreach (var camera in _cameras)
                    {
                        cbCamera.Items.Add(camera.DisplayName);
                    }
                }

                if (cbCamera.Items.Count > 0)
                {
                    cbCamera.SelectedIndex = 0;
                }

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

                _timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
                _timer.Tick += Timer_Tick;

                Log($"SDK v{VideoCaptureCoreX.SDK_Version} ready.");
                Log("ONNX Runtime providers: " + string.Join(", ", OnnxInferenceEngine.GetAvailableProviders()));
                Log("Models are cached under %USERPROFILE%/VisioForge/models/vlm. Weights are NOT shipped with the SDK.");
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

        // ---- model folder / download ----
        private void btSelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFolderDialog { Title = "Select the Florence-2 model folder" };
            if (dlg.ShowDialog() == true)
            {
                edModelFolder.Text = dlg.FolderName;
                RefreshModelStatus();
            }
        }

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
                Log("Model files ready.");
                lbDownloadStatus.Text = "All models ready.";
                MessageBox.Show(this, "All model files downloaded and ready.", "Models Ready", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Log($"Download failed: {ex.Message}");
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
                Log($"{fileName} already present - skipped.");
                return;
            }

            var tmpPath = destPath + ".part";
            pbDownload.IsIndeterminate = false;
            pbDownload.Value = 0;
            lbDownloadStatus.Text = $"Downloading {fileName}...";
            Log($"Downloading {fileName}...");

            try
            {
                // Stream to a .part temp, then move into place so a failed download leaves no corrupt cache.
                await Task.Run(async () =>
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
                Log($"Saved {fileName} to {ModelsCacheDir}.");
            }
            catch
            {
                try { if (File.Exists(tmpPath)) File.Delete(tmpPath); } catch { }
                throw;
            }
        }

        // ---- task / text input (live) ----
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

        // Disposes any existing engine and builds a fresh VideoCaptureCoreX bound to the same VideoView.
        private async Task RecreateEngineAsync()
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.OnStop -= Core_OnStop;
                try { await _core.StopAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
                await _core.DisposeAsync();
                _core = null;
            }

            if (_isClosing)
            {
                return;
            }

            _core = new VideoCaptureCoreX(VideoView1);
            _core.OnError += Core_OnError;
            _core.OnStop += Core_OnStop;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (_cameras == null || _cameras.Length == 0 || cbCamera.SelectedIndex < 0)
            {
                MessageBox.Show(this, "No camera devices were found.");
                return;
            }

            var folder = edModelFolder.Text;
            if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder))
            {
                MessageBox.Show(this, "Select (or download) the Florence-2 model folder on the Model tab.");
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
                mmLog.Clear();
                _results.Clear();

                await RecreateEngineAsync();
                if (_core == null || _isClosing)
                {
                    return;
                }

                // Configure the camera source at an HD (or best available) format.
                var device = _cameras[cbCamera.SelectedIndex];
                var formatItem = device.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);
                if (formatItem == null)
                {
                    MessageBox.Show(this, "Unable to read a camera format.");
                    btStart.IsEnabled = true;
                    return;
                }

                var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                {
                    Format = formatItem.ToFormat()
                };
                videoSourceSettings.Format.FrameRate = frameRate;
                _core.Video_Source = videoSourceSettings;
                _core.Audio_Play = false;

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
                _core.Video_Processing_AddBlock(_vlm);

                if (!await _core.StartAsync())
                {
                    Log("start error: failed to start capture.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                Log($"Running on: {_vlm.ActiveProvider}");
                _timer.Start();
                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
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
            var text = e.Text;
            if (string.IsNullOrEmpty(text) && e.Regions != null && e.Regions.Length > 0)
            {
                text = string.Join(", ", e.Regions.Select(r => r.Label));
            }

            var task = e.Task;
            var timestamp = e.Timestamp;
            var inferenceMs = e.InferenceTimeMs;

            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing)
                {
                    return;
                }

                _results.Insert(0, new ResultRow
                {
                    Timestamp = timestamp.ToString("hh\\:mm\\:ss"),
                    Task = task.ToString(),
                    Text = text,
                    InferenceTimeMs = inferenceMs.ToString("F0", CultureInfo.InvariantCulture),
                });

                while (_results.Count > 200)
                {
                    _results.RemoveAt(_results.Count - 1);
                }
            }));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_timerBusy)
            {
                return;
            }

            _timerBusy = true;
            try
            {
                if (_vlm != null)
                {
                    lbStatus.Text = $"Provider: {_vlm.ActiveProvider}   |   Dropped frames: {_vlm.DroppedFrameCount}";
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { _timerBusy = false; }
        }

        private void Log(string text)
        {
            if (_isClosing)
            {
                return;
            }

            // Events fire on the pipeline streaming thread; post non-blocking to the UI.
            _ = Dispatcher.BeginInvoke(new Action(() => mmLog.AppendText(text + Environment.NewLine)));
        }

        private void Core_OnError(object sender, ErrorsEventArgs e) => Log(e.Message);

        private void Core_OnStop(object sender, StopEventArgs e)
        {
            // The engine disposes the inserted block on stop; drop our reference so the next Start re-creates one.
            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing)
                {
                    return;
                }

                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_core != null && _core.State != PlaybackState.Free)
                {
                    return;
                }

                _timer?.Stop();
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
            _timer?.Stop();
            try
            {
                await CleanupAfterStopAsync();
                VideoView1.CallRefresh();
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
            if (_core != null)
            {
                await _core.StopAsync();
            }

            DetachBlock();
        }

        /// <summary>
        /// Detaches the handler and drops the reference; the engine owns and disposes the block itself.
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

            _timer?.Stop();

            // Wait for an in-flight Start/Stop to finish before tearing the engine down.
            while (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                await Task.Delay(50);
            }

            try
            {
                if (_core != null)
                {
                    _core.OnError -= Core_OnError;
                    _core.OnStop -= Core_OnStop;
                    await _core.StopAsync();
                    await _core.DisposeAsync();
                    _core = null;
                }

                DetachBlock();
                VideoView1.CallRefresh();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            _ = Dispatcher.BeginInvoke(new Action(() => Close()));
        }
    }
}
