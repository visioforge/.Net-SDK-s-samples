using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.AI;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace VLM_Captioning_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
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

        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private MediaBlock _videoSource;
        private VLMBlock _vlm;

        private System.Windows.Threading.DispatcherTimer _timer;
        private bool _timerBusy;
        private VideoCaptureDeviceInfo[] _videoCaptureDevices;
        private bool _isClosing;
        private bool _cleanupFinished;
        private bool _uiBusy;

        private readonly ObservableCollection<ResultRow> _results = new ObservableCollection<ResultRow>();

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

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => { mmLog.Text += e.Message + Environment.NewLine; }));
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_uiBusy || _isClosing) return;
                _timer?.Stop();
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
            }));
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

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.OnStop += Pipeline_OnStop;
                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                _videoCaptureDevices = await SystemVideoSourceBlock.GetDevicesAsync() ?? Array.Empty<VideoCaptureDeviceInfo>();
                foreach (var item in _videoCaptureDevices) cbVideoInput.Items.Add(item.DisplayName);
                if (cbVideoInput.Items.Count > 0) cbVideoInput.SelectedIndex = 0;

                foreach (VLMTask t in Enum.GetValues(typeof(VLMTask)))
                    cbTask.Items.Add(new ComboBoxItem { Content = t.ToString(), Tag = t });
                cbTask.SelectedIndex = 0;

                // Prefill the model folder with the cache dir when the assets are already present.
                if (ModelFiles.All(f => File.Exists(Path.Combine(ModelsCacheDir, f))))
                    edModelFolder.Text = ModelsCacheDir;
                RefreshModelStatus();

                var providers = OnnxInferenceEngine.GetAvailableProviders();
                mmLog.Text += "ONNX Runtime providers: " + string.Join(", ", providers) + Environment.NewLine;
                mmLog.Text += "Models are cached under %USERPROFILE%/VisioForge/models/vlm. Weights are NOT shipped with the SDK." + Environment.NewLine;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (_timerBusy) return; _timerBusy = true;
            try
            {
                if (_pipeline != null) lbTime.Text = (await _pipeline.Position_GetAsync()).ToString("hh\\:mm\\:ss");
                if (_vlm != null) lbStatus.Text = $"Provider: {_vlm.ActiveProvider}   |   Dropped frames: {_vlm.DroppedFrameCount}";
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
            try
            {
                _timer?.Stop();
                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.OnStop -= Pipeline_OnStop;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }
                CleanupBlocks();
                VideoView1.CallRefresh();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            try { _cleanupFinished = true; Dispatcher.BeginInvoke(new Action(() => Close())); }
            catch (Exception ex) { Debug.WriteLine(ex); _isClosing = false; _cleanupFinished = false; IsEnabled = true; }
        }

        private void rbSource_Checked(object sender, RoutedEventArgs e)
        {
            if (pnlWebcam == null) return;
            pnlWebcam.Visibility = rbWebcam.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            pnlFile.Visibility = rbFile.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btSelectVideoFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Video files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts|All files|*.*" };
            if (dlg.ShowDialog() == true) edVideoFile.Text = dlg.FileName;
        }

        private void btSelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFolderDialog { Title = "Select the Florence-2 model folder" };
            if (dlg.ShowDialog() == true) { edModelFolder.Text = dlg.FolderName; RefreshModelStatus(); }
        }

        // Disables the Download button and relabels it once every Florence-2 file is present in the selected folder.
        private void RefreshModelStatus()
        {
            if (btDownloadModels == null) return;
            var folder = edModelFolder.Text;
            var ready = !string.IsNullOrWhiteSpace(folder) && Directory.Exists(folder)
                        && ModelFiles.All(f => File.Exists(Path.Combine(folder, f)));
            btDownloadModels.IsEnabled = !ready;
            btDownloadModels.Content = ready ? "Model files ready" : "Download model files";
        }

        // ---- task ----
        private void cbTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized) return;
            var task = SelectedTask;
            if (edTextInput != null) edTextInput.IsEnabled = task == VLMTask.PhraseGrounding;
            if (_vlm != null) _vlm.Task = task;
        }

        private void edTextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_vlm != null) _vlm.TextInput = edTextInput.Text;
        }

        // ---- model download ----
        private async void btDownloadModels_Click(object sender, RoutedEventArgs e)
        {
            btDownloadModels.IsEnabled = false;
            pnlDownload.Visibility = Visibility.Visible;
            try
            {
                foreach (var fileName in ModelFiles) await DownloadModelAsync(fileName);
                edModelFolder.Text = ModelsCacheDir;
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

        // ---- device selection ----
        private void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVideoInput.SelectedIndex != -1 && e?.AddedItems.Count > 0)
                {
                    var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == (string)e.AddedItems[0]);
                    if (device != null)
                    {
                        cbVideoFormat.Items.Clear();
                        foreach (var f in device.VideoFormats) cbVideoFormat.Items.Add(f.Name);
                        if (cbVideoFormat.Items.Count > 0) cbVideoFormat.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        private void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbVideoFrameRate.Items.Clear();
                if (cbVideoInput.SelectedIndex != -1 && e?.AddedItems.Count > 0)
                {
                    var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == cbVideoInput.SelectedValue.ToString());
                    var fmt = device?.VideoFormats.FirstOrDefault(x => x.Name == (string)e.AddedItems[0]);
                    if (fmt != null)
                    {
                        foreach (var r in fmt.GetFrameRateRangeAsStringList()) cbVideoFrameRate.Items.Add(r);
                        if (cbVideoFrameRate.Items.Count > 0) cbVideoFrameRate.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        private async System.Threading.Tasks.Task<bool> BuildSourceAsync()
        {
            if (rbFile.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(edVideoFile.Text)) { MessageBox.Show(this, "Select a video file."); return false; }
                _videoSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(edVideoFile.Text, renderVideo: true, renderAudio: false));
                return true;
            }
            if (cbVideoInput.SelectedIndex < 0) { MessageBox.Show(this, "Select a video input device."); return false; }

            var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == cbVideoInput.Text);
            var fmt = device?.VideoFormats.FirstOrDefault(x => x.Name == cbVideoFormat.Text);
            if (device == null || fmt == null) { MessageBox.Show(this, "Unable to configure the video device."); return false; }
            var s = new VideoCaptureDeviceSourceSettings(device) { Format = fmt.ToFormat() };
            if (!string.IsNullOrEmpty(cbVideoFrameRate.Text))
                s.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text, CultureInfo.InvariantCulture));
            _videoSource = new SystemVideoSourceBlock(s);
            return true;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _uiBusy = true; btStart.IsEnabled = false;
                if (_pipeline == null) { MessageBox.Show(this, "SDK failed to initialize."); btStart.IsEnabled = true; return; }

                mmLog.Clear(); _results.Clear();

                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); }
                catch (Exception ex) { Debug.WriteLine(ex); }
                CleanupBlocks();

                var folder = edModelFolder.Text;
                if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder)) { MessageBox.Show(this, "Select (or download) the Florence-2 model folder on the Model tab."); btStart.IsEnabled = true; return; }

                var settings = new VLMSettings(folder)
                {
                    Task = SelectedTask,
                    TextInput = edTextInput.Text,
                    DrawResults = cbDrawResults.IsChecked == true,
                };

                if (double.TryParse(edInterval.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var interval))
                    settings.ProcessingInterval = TimeSpan.FromSeconds(Math.Max(0.5, Math.Min(10.0, interval)));

                if (int.TryParse(edMaxTokens.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var maxTokens) && maxTokens > 0)
                    settings.MaxNewTokens = maxTokens;

                foreach (var f in ModelFiles)
                {
                    if (!File.Exists(Path.Combine(folder, f))) { MessageBox.Show(this, $"Missing model file: {f}"); btStart.IsEnabled = true; return; }
                }

                if (!await BuildSourceAsync()) { btStart.IsEnabled = true; return; }

                _vlm = new VLMBlock(settings);
                _vlm.OnResultGenerated += Vlm_OnResultGenerated;

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

                _pipeline.Connect(_videoSource.Output, _vlm.Input);
                _pipeline.Connect(_vlm.Output, _videoRenderer.Input);

                if (!await _pipeline.StartAsync())
                {
                    mmLog.Text += "Failed to start - check the model folder and selected source." + Environment.NewLine;
                    try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch { }
                    CleanupBlocks(); btStart.IsEnabled = true; return;
                }

                mmLog.Text += $"Running on: {_vlm.ActiveProvider}" + Environment.NewLine;
                _timer.Start(); btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch { }
                CleanupBlocks(); btStart.IsEnabled = true; btStop.IsEnabled = false;
                mmLog.Text += ex.Message + Environment.NewLine;
            }
            finally { _uiBusy = false; }
        }

        private void Vlm_OnResultGenerated(object sender, VLMResultGeneratedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                var text = e.Text;
                if (string.IsNullOrEmpty(text) && e.Regions.Length > 0)
                    text = string.Join(", ", e.Regions.Select(r => r.Label));

                _results.Insert(0, new ResultRow
                {
                    Timestamp = e.Timestamp.ToString("hh\\:mm\\:ss"),
                    Task = e.Task.ToString(),
                    Text = text,
                    InferenceTimeMs = e.InferenceTimeMs.ToString("F0", CultureInfo.InvariantCulture),
                });

                while (_results.Count > 200) _results.RemoveAt(_results.Count - 1);
            }));
        }

        private void CleanupBlocks()
        {
            if (_vlm != null) { _vlm.OnResultGenerated -= Vlm_OnResultGenerated; _vlm.Dispose(); _vlm = null; }
            _videoSource?.Dispose(); _videoSource = null;
            _videoRenderer?.Dispose(); _videoRenderer = null;
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _uiBusy = true; btStop.IsEnabled = false; _timer?.Stop();
                if (_pipeline != null) { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); }
                CleanupBlocks(); VideoView1.CallRefresh();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { btStart.IsEnabled = true; _uiBusy = false; }
        }
    }
}
