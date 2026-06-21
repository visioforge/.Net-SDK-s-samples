using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Background_Removal_Demo
{
    public partial class MainWindow : Window
    {
        // ---- model download infrastructure ----
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

        static MainWindow()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-BackgroundRemoval-Demo/1.0");
        }

        private sealed class ModelPreset
        {
            public string Name;
            public string Tag;
            public BackgroundRemovalModel Family;
            public string DownloadUrl;
            public string FileName;
            public bool IsLocal;
            public string LocalPath;
        }

        private List<ModelPreset> _modelPresets;
        private ModelPreset _selectedPreset;

        private List<ModelPreset> BuildModelList()
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var list = new List<ModelPreset>();

            AddDownloadable(list, "PP-MattingV2 (recommended, real-time)", "ppmattingv2", "ppmattingv2.onnx", BackgroundRemovalModel.PPMattingV2);
            AddDownloadable(list, "MODNet (portrait, real-time)", "modnet", "modnet.onnx", BackgroundRemovalModel.MODNet);

            list.Add(new ModelPreset
            {
                Name = "Custom model...",
                Tag = "custom",
                Family = BackgroundRemovalModel.Custom,
                IsLocal = false
            });

            return list;
        }

        private void AddDownloadable(List<ModelPreset> list, string name, string tag,
            string fileName, BackgroundRemovalModel family)
        {
            var cachePath = Path.Combine(ModelsCacheDir, fileName);
            var isCached = File.Exists(cachePath);
            list.Add(new ModelPreset
            {
                Name = name,
                Tag = tag,
                Family = family,
                DownloadUrl = ModelsReleaseUrl + "/" + fileName,
                FileName = fileName,
                IsLocal = isCached,
                LocalPath = isCached ? cachePath : null
            });
        }

        private void RefreshModelList()
        {
            _modelPresets = BuildModelList();
            var selTag = _selectedPreset?.Tag;
            cbModel.Items.Clear();
            int selIdx = 0;
            for (int i = 0; i < _modelPresets.Count; i++)
            {
                var p = _modelPresets[i];
                cbModel.Items.Add(new ComboBoxItem { Content = p.Name, Tag = p.Tag });
                if (p.Tag == selTag) selIdx = i;
            }
            cbModel.SelectedIndex = selIdx;
        }

        private ModelPreset GetSelectedPreset()
        {
            var tag = ((cbModel.SelectedItem as ComboBoxItem)?.Tag as string) ?? "ppmattingv2";
            return _modelPresets.FirstOrDefault(p => p.Tag == tag) ?? _modelPresets[0];
        }

        // ---- pipeline fields ----
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private MediaBlock _videoSource;
        private BackgroundRemovalBlock _brBlock;

        // The live settings instance shared with the running block. The processor reads it every frame, so
        // mutating these properties retunes the effect without rebuilding the pipeline. Null when not running.
        private BackgroundRemovalSettings _brSettings;
        private System.Windows.Threading.DispatcherTimer _timer;
        private bool _timerBusy;
        private VideoCaptureDeviceInfo[] _videoCaptureDevices;
        private bool _isClosing;
        private bool _uiBusy;

        // Cancels an in-flight model download (e.g. when the window closes).
        private System.Threading.CancellationTokenSource _downloadCts;

        public MainWindow() { InitializeComponent(); }

        // ---- pipeline events ----
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
            => Dispatcher.Invoke(() => mmLog.Text += e.Message + Environment.NewLine);

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

                _modelPresets = BuildModelList();
                foreach (var p in _modelPresets) cbModel.Items.Add(new ComboBoxItem { Content = p.Name, Tag = p.Tag });
                cbModel.SelectedIndex = 0;

                var providers = OnnxInferenceEngine.GetAvailableProviders();
                mmLog.Text += "ONNX Runtime providers: " + string.Join(", ", providers) + Environment.NewLine;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (_timerBusy) return; _timerBusy = true;
            try { if (_pipeline != null) _ = await _pipeline.Position_GetAsync(); }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { _timerBusy = false; }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing) return; e.Cancel = true; _isClosing = true; IsEnabled = false;
            try
            {
                _timer?.Stop();
                _downloadCts?.Cancel();
                _downloadCts?.Dispose();
                _downloadCts = null;
                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.OnStop -= Pipeline_OnStop;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }
                CleanupBlocks(); VideoView1.CallRefresh(); VisioForgeX.DestroySDK();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            try { _ = Dispatcher.BeginInvoke(new Action(() => Close())); }
            catch (Exception ex) { Debug.WriteLine(ex); _isClosing = false; IsEnabled = true; }
        }

        // ---- source UI ----
        private void rbSource_Checked(object sender, RoutedEventArgs e)
        {
            if (pnlWebcam == null) return;
            pnlWebcam.Visibility = rbWebcam.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            pnlFile.Visibility = rbFile.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            pnlRTSP.Visibility = rbRTSP.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btSelectVideoFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Video files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts|All files|*.*" };
            if (dlg.ShowDialog() == true) edVideoFile.Text = dlg.FileName;
        }

        private void btSelectModel_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "ONNX models|*.onnx|All files|*.*" };
            if (dlg.ShowDialog() == true) edModelFile.Text = dlg.FileName;
        }

        private void btSelectImage_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp;*.webp|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                edImageFile.Text = dlg.FileName;
                if (_brSettings != null) _brSettings.BackgroundImagePath = edImageFile.Text;
            }
        }

        // ---- model selection ----
        private BackgroundRemovalModel SelectedMattingModel()
            => _selectedPreset?.Family ?? BackgroundRemovalModel.MODNet;

        private void cbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsInitialized || cbModel.SelectedItem == null || _modelPresets == null) return;
            try
            {
                _selectedPreset = GetSelectedPreset();
                var needsDownload = _selectedPreset.DownloadUrl != null && !_selectedPreset.IsLocal;
                var isCustom = _selectedPreset.Tag == "custom";
                btDownloadModel.Visibility = needsDownload ? Visibility.Visible : Visibility.Collapsed;
                btSelectModel.Visibility = isCustom ? Visibility.Visible : Visibility.Collapsed;
                edModelFile.Visibility = Visibility.Visible;
                if (_selectedPreset.IsLocal && _selectedPreset.LocalPath != null)
                    edModelFile.Text = _selectedPreset.LocalPath;
            }
            catch { }
        }

        private async void btDownloadModel_Click(object sender, RoutedEventArgs e)
        {
            // Snapshot the preset so a mid-download model change can't redirect the save path or URL.
            var preset = _selectedPreset;
            if (preset?.DownloadUrl == null) return;
            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, preset.FileName);
            var tempPath = destPath + ".part"; // download here, then atomically swap in on success

            _downloadCts?.Cancel();
            _downloadCts?.Dispose();
            _downloadCts = new System.Threading.CancellationTokenSource();
            var token = _downloadCts.Token;

            btDownloadModel.IsEnabled = false;
            btDownloadModel.Content = "Downloading...";
            mmLog.Text += $"Downloading {preset.Name}..." + Environment.NewLine;

            try
            {
                // Stream the response straight to disk instead of buffering the whole model in memory
                // (BiRefNet is ~115 MB), which would spike memory on constrained machines.
                using (var response = await _http.GetAsync(preset.DownloadUrl, HttpCompletionOption.ResponseHeadersRead, token))
                {
                    response.EnsureSuccessStatusCode();
                    using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
                    {
                        await response.Content.CopyToAsync(fileStream, token);
                    }
                }

                // Only now publish the completed file so an interrupted download never leaves a truncated
                // .onnx at the cache path that File.Exists would later treat as a valid cached model.
                if (File.Exists(destPath)) File.Delete(destPath);
                File.Move(tempPath, destPath);

                edModelFile.Text = destPath;
                mmLog.Text += $"Saved to {ModelsCacheDir} ({new FileInfo(destPath).Length / 1024 / 1024} MB)" + Environment.NewLine;
                RefreshModelList();
            }
            catch (OperationCanceledException)
            {
                TryDeleteTemp(tempPath);
                mmLog.Text += "Download canceled." + Environment.NewLine;
            }
            catch (Exception ex)
            {
                TryDeleteTemp(tempPath);
                Dispatcher.Invoke(() => MessageBox.Show(this,
                    $"Download failed:\n{ex.Message}\n\nURL: {preset.DownloadUrl}",
                    "Download Error", MessageBoxButton.OK, MessageBoxImage.Warning));
            }
            finally
            {
                btDownloadModel.IsEnabled = true;
                btDownloadModel.Content = "Download";
            }
        }

        private static void TryDeleteTemp(string path)
        {
            try { if (File.Exists(path)) File.Delete(path); }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        // ---- video device selection ----
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
                    if (device != null)
                    {
                        var fmt = device.VideoFormats.FirstOrDefault(x => x.Name == (string)e.AddedItems[0]);
                        if (fmt != null)
                        {
                            foreach (var r in fmt.GetFrameRateRangeAsStringList()) cbVideoFrameRate.Items.Add(r);
                            if (cbVideoFrameRate.Items.Count > 0) cbVideoFrameRate.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        // ---- replacement mode UI ----
        private void cbMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsInitialized || pnlBlur == null) return;
            var mode = SelectedReplacementMode();
            pnlBlur.Visibility = mode == BackgroundReplacementMode.Blur ? Visibility.Visible : Visibility.Collapsed;
            pnlColor.Visibility = mode == BackgroundReplacementMode.SolidColor ? Visibility.Visible : Visibility.Collapsed;
            pnlImage.Visibility = mode == BackgroundReplacementMode.Image ? Visibility.Visible : Visibility.Collapsed;

            if (_brSettings != null) _brSettings.ReplacementMode = mode;

            // Transparent writes the matte into the alpha channel only; the preview renderer draws onto an opaque
            // surface, so there is no visible change here. Alpha is meaningful for an RGBA muxer/output.
            if (mode == BackgroundReplacementMode.Transparent && mmLog != null)
            {
                mmLog.Text += "Transparent mode affects the alpha channel only; the preview shows no visible change (use an RGBA output to see it)." + Environment.NewLine;
            }
        }

        private BackgroundReplacementMode SelectedReplacementMode()
        {
            var tag = ((cbMode.SelectedItem as ComboBoxItem)?.Tag as string) ?? "blur";
            switch (tag)
            {
                case "color": return BackgroundReplacementMode.SolidColor;
                case "image": return BackgroundReplacementMode.Image;
                case "transparent": return BackgroundReplacementMode.Transparent;
                case "blur":
                default: return BackgroundReplacementMode.Blur;
            }
        }

        private OnnxExecutionProvider SelectedProvider()
        {
            var tag = ((cbProvider.SelectedItem as ComboBoxItem)?.Tag as string) ?? "auto";
            switch (tag)
            {
                case "directml": return OnnxExecutionProvider.DirectML;
                case "cpu": return OnnxExecutionProvider.CPU;
                case "auto":
                default: return OnnxExecutionProvider.Auto;
            }
        }

        // ---- source builder ----
        private async System.Threading.Tasks.Task<bool> BuildSourceAsync()
        {
            if (rbFile.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(edVideoFile.Text)) { MessageBox.Show(this, "Select a video file."); return false; }
                _videoSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(edVideoFile.Text, renderVideo: true, renderAudio: false));
                return true;
            }
            if (rbRTSP.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(edRTSPURL.Text) || edRTSPURL.Text.Trim() == "rtsp://") { MessageBox.Show(this, "Enter an RTSP URL."); return false; }
                _videoSource = new RTSPSourceBlock(await RTSPSourceSettings.CreateAsync(new Uri(edRTSPURL.Text.Trim()), edRTSPLogin.Text, edRTSPPassword.Password, audioEnabled: false));
                return true;
            }
            if (cbVideoInput.SelectedIndex < 0) { MessageBox.Show(this, "Select a video input device."); return false; }

            var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == cbVideoInput.Text);
            var fmt = device?.VideoFormats.FirstOrDefault(x => x.Name == cbVideoFormat.Text);
            if (device == null || fmt == null) { MessageBox.Show(this, "Unable to configure video device."); return false; }
            var s = new VideoCaptureDeviceSourceSettings(device) { Format = fmt.ToFormat() };
            if (!string.IsNullOrEmpty(cbVideoFrameRate.Text))
                s.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text, CultureInfo.InvariantCulture));
            _videoSource = new SystemVideoSourceBlock(s);
            return true;
        }

        // ---- start / stop ----
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _uiBusy = true; btStart.IsEnabled = false;
                if (_pipeline == null) { MessageBox.Show(this, "SDK failed to initialize."); btStart.IsEnabled = true; return; }

                mmLog.Clear();

                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); }
                catch (Exception ex) { Debug.WriteLine(ex); }
                CleanupBlocks();

                if (string.IsNullOrWhiteSpace(edModelFile.Text)) { MessageBox.Show(this, "Select or download a matting model."); btStart.IsEnabled = true; return; }
                if (!File.Exists(edModelFile.Text)) { MessageBox.Show(this, "The model file does not exist. Download it or browse to a local .onnx."); btStart.IsEnabled = true; return; }
                if (!await BuildSourceAsync()) { btStart.IsEnabled = true; return; }

                var mode = SelectedReplacementMode();

                if (mode == BackgroundReplacementMode.Image && (string.IsNullOrWhiteSpace(edImageFile.Text) || !File.Exists(edImageFile.Text)))
                { MessageBox.Show(this, "Select a background image."); btStart.IsEnabled = true; return; }

                _brSettings = new BackgroundRemovalSettings(edModelFile.Text)
                {
                    Model = SelectedMattingModel(),
                    ReplacementMode = mode,
                    BlurRadius = (float)slBlur.Value,
                    BackgroundImagePath = edImageFile.Text,
                    MaskFeatherAmount = (int)slFeather.Value,
                    Provider = SelectedProvider(),
                };

                if (SkiaSharp.SKColor.TryParse(edColor.Text.Trim(), out var color))
                    _brSettings.ReplacementColor = color;

                if (int.TryParse(edFramesToSkip.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var skip) && skip >= 0)
                    _brSettings.FramesToSkip = skip;

                if (float.TryParse(edThreshold.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var threshold))
                    _brSettings.MaskThreshold = threshold;

                // Square input size for dynamic-input models (e.g. MODNet). Fixed-size models ignore it.
                if (int.TryParse(edInputSize.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var inputSize) && inputSize >= 64)
                {
                    _brSettings.InputWidth = inputSize;
                    _brSettings.InputHeight = inputSize;
                }

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

                _brBlock = new BackgroundRemovalBlock(_brSettings);

                _pipeline.Connect(_videoSource.Output, _brBlock.Input);
                _pipeline.Connect(_brBlock.Output, _videoRenderer.Input);
                await _pipeline.StartAsync();

                mmLog.Text += $"Provider: {_brBlock.ActiveProvider}" + Environment.NewLine;

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

        private void CleanupBlocks()
        {
            if (_brBlock != null) { _brBlock.Dispose(); _brBlock = null; }
            _brSettings = null;
            _videoSource?.Dispose(); _videoSource = null;
            _videoRenderer?.Dispose(); _videoRenderer = null;
        }

        // ---- live parameter changes (applied to the running effect without restarting) ----
        // The processor reads _brSettings every frame, so updating these while the pipeline runs retunes the
        // effect instantly. Each handler no-ops until Start has created _brSettings.

        private void slBlur_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_brSettings != null) _brSettings.BlurRadius = (float)slBlur.Value;
        }

        private void slFeather_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_brSettings != null) _brSettings.MaskFeatherAmount = (int)slFeather.Value;
        }

        private void edColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_brSettings != null && SkiaSharp.SKColor.TryParse(edColor.Text.Trim(), out var c))
                _brSettings.ReplacementColor = c;
        }

        private void edThreshold_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_brSettings != null && float.TryParse(edThreshold.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var t))
                _brSettings.MaskThreshold = t;
        }

        private void edFramesToSkip_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_brSettings != null && int.TryParse(edFramesToSkip.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var s) && s >= 0)
                _brSettings.FramesToSkip = s;
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
