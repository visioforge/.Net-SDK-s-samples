using Microsoft.Win32;
using SkiaSharp;
using System;
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

namespace PII_Redaction_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        // Webcam, file or RTSP source.
        private MediaBlock _videoSource;

        private PIIRedactionBlock _redaction;

        // The settings object shared with the running block; category checkboxes, style, and sliders
        // mutate it live while the pipeline runs.
        private PIIRedactionSettings _settings;

        private System.Windows.Threading.DispatcherTimer _timer;

        private bool _timerBusy;

        private VideoCaptureDeviceInfo[] _videoCaptureDevices;

        private bool _isClosing;

        private bool _cleanupFinished;

        private bool _uiBusy;

        // File-playback transport state (seek bar + real-time/max-speed toggle).
        private bool _isFile;

        private bool _seeking;

        private bool _suppressSeek;

        private TimeSpan _duration;

        // The YuNet face detector is hosted in the SDK samples release; the plate/text models ship next
        // to the demo executable. Weights are NOT shipped with the SDK.
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private const string FaceModelFile = "face_detection_yunet_2023mar.onnx"; // YuNet (MIT)
        private const string PlateModelFile = "yolo-v9-t-640-license-plates-end2end.onnx"; // FastALPR (MIT)
        private const string TextDetModelFile = "ch_PP-OCRv5_mobile_det.onnx"; // PP-OCRv5 (Apache-2.0)
        private const string TextRecModelFile = "latin_PP-OCRv5_rec_mobile_infer.onnx"; // PP-OCRv5 (Apache-2.0)
        private const string TextDictFile = "ppocrv5_latin_dict.txt";

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            // BeginInvoke (non-blocking): OnError fires on a worker; a blocking Invoke would deadlock teardown.
            Dispatcher.BeginInvoke(new Action(() => { mmLog.Text += e.Message + Environment.NewLine; }));
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_uiBusy || _isClosing)
                {
                    return;
                }

                _timer?.Stop();
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;

                slSeek.IsEnabled = false;
                _suppressSeek = true;
                slSeek.Value = 0;
                _suppressSeek = false;
            }));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                try
                {
                    await VisioForgeX.InitSDKAsync();
                }
                finally
                {
                    this.IsEnabled = true;
                    Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", string.Empty);
                }

                _timer = new System.Windows.Threading.DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(500),
                };
                _timer.Tick += Timer_Tick;

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.OnStop += Pipeline_OnStop;

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                _videoCaptureDevices = await SystemVideoSourceBlock.GetDevicesAsync() ?? Array.Empty<VideoCaptureDeviceInfo>();
                foreach (var item in _videoCaptureDevices)
                {
                    cbVideoInput.Items.Add(item.DisplayName);
                }

                if (cbVideoInput.Items.Count > 0)
                {
                    cbVideoInput.SelectedIndex = 0;
                }

                cbStyle.Items.Add("Gaussian blur");
                cbStyle.Items.Add("Pixelate");
                cbStyle.Items.Add("Solid fill");
                cbStyle.SelectedIndex = 0;

                cbFillColor.Items.Add("Black");
                cbFillColor.Items.Add("White");
                cbFillColor.Items.Add("Gray");
                cbFillColor.SelectedIndex = 0;

                // The plate/text models ship next to the executable; YuNet comes from the cache when
                // already downloaded.
                PrefillFromBaseDir(edPlateModel, PlateModelFile);
                PrefillFromBaseDir(edTextDetModel, TextDetModelFile);
                PrefillFromBaseDir(edTextRecModel, TextRecModelFile);
                PrefillFromBaseDir(edTextDict, TextDictFile);
                PrefillFromCache(edFaceModel, FaceModelFile);
                RefreshModelButtons();

                var providers = OnnxInferenceEngine.GetAvailableProviders();
                mmLog.Text += "ONNX Runtime providers: " + string.Join(", ", providers) + Environment.NewLine;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private static void PrefillFromBaseDir(TextBox box, string fileName)
        {
            var path = Path.Combine(AppContext.BaseDirectory, fileName);
            if (File.Exists(path))
            {
                box.Text = path;
            }
        }

        private static void PrefillFromCache(TextBox box, string fileName)
        {
            var path = Path.Combine(ModelsCacheDir, fileName);
            if (File.Exists(path))
            {
                box.Text = path;
            }
        }

        // Show the face model's Download button only when its file is missing from the cache.
        private void RefreshModelButtons()
        {
            btDownloadFace.Visibility = File.Exists(Path.Combine(ModelsCacheDir, FaceModelFile))
                ? Visibility.Collapsed : Visibility.Visible;
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (_timerBusy)
            {
                return;
            }

            _timerBusy = true;
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                var position = await _pipeline.Position_GetAsync();

                if (_isFile)
                {
                    // Duration is known only after preroll - keep trying until it resolves.
                    if (_duration <= TimeSpan.Zero)
                    {
                        try { _duration = await _pipeline.DurationAsync(); } catch (Exception durEx) { Debug.WriteLine(durEx); }
                    }
                }

                if (_isFile && _duration > TimeSpan.Zero)
                {
                    lbTime.Text = $"{position:hh\\:mm\\:ss} / {_duration:hh\\:mm\\:ss}";

                    // Reflect playback position on the seek bar unless the user is dragging it.
                    if (!_seeking)
                    {
                        _suppressSeek = true;
                        slSeek.Value = Math.Max(0, Math.Min(slSeek.Maximum, position.TotalSeconds / _duration.TotalSeconds * slSeek.Maximum));
                        _suppressSeek = false;
                    }
                }
                else
                {
                    lbTime.Text = position.ToString("hh\\:mm\\:ss");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _timerBusy = false;
            }
        }

        private void slSeek_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            _seeking = true;
        }

        private async void slSeek_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            _seeking = false;
            await SeekToSliderAsync();
        }

        private async void slSeek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Ignore timer-driven updates and per-tick drag changes (committed once in DragCompleted); a track click lands here.
            if (_suppressSeek || _seeking)
            {
                return;
            }

            await SeekToSliderAsync();
        }

        private async System.Threading.Tasks.Task SeekToSliderAsync()
        {
            if (_pipeline == null || !_isFile)
            {
                return;
            }

            if (_duration <= TimeSpan.Zero)
            {
                try { _duration = await _pipeline.DurationAsync(); } catch (Exception durEx) { Debug.WriteLine(durEx); }
            }

            if (_duration <= TimeSpan.Zero)
            {
                return;
            }

            try
            {
                var target = TimeSpan.FromSeconds(slSeek.Value / slSeek.Maximum * _duration.TotalSeconds);
                await _pipeline.Position_SetAsync(target, seekToKeyframe: true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Once cleanup has completed, let the real close proceed.
            if (_cleanupFinished)
            {
                return;
            }

            // Cancel close attempts until the async teardown finishes.
            e.Cancel = true;

            if (_isClosing)
            {
                return;
            }

            _isClosing = true;
            IsEnabled = false;

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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            try
            {
                _cleanupFinished = true;
                Dispatcher.BeginInvoke(new Action(() => Close()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                _isClosing = false;
                _cleanupFinished = false;
                IsEnabled = true;
            }
        }

        private void rbSource_Checked(object sender, RoutedEventArgs e)
        {
            if (pnlWebcam == null || pnlFile == null || pnlRTSP == null)
            {
                return;
            }

            pnlWebcam.Visibility = rbWebcam.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            pnlFile.Visibility = rbFile.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            pnlRTSP.Visibility = rbRTSP.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btSelectVideoFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Video files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                edVideoFile.Text = dlg.FileName;
            }
        }

        private void btSelectFaceModel_Click(object sender, RoutedEventArgs e) => PickOnnx(edFaceModel);

        private void btSelectPlateModel_Click(object sender, RoutedEventArgs e) => PickOnnx(edPlateModel);

        private void btSelectTextDetModel_Click(object sender, RoutedEventArgs e) => PickOnnx(edTextDetModel);

        private void btSelectTextRecModel_Click(object sender, RoutedEventArgs e) => PickOnnx(edTextRecModel);

        private void btSelectTextDict_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Dictionary files|*.txt|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                edTextDict.Text = dlg.FileName;
            }
        }

        private static void PickOnnx(TextBox box)
        {
            var dlg = new OpenFileDialog { Filter = "ONNX models|*.onnx|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                box.Text = dlg.FileName;
            }
        }

        private async void btDownloadFace_Click(object sender, RoutedEventArgs e)
            => await DownloadModelAsync(btDownloadFace, edFaceModel, FaceModelFile);

        private async System.Threading.Tasks.Task DownloadModelAsync(Button button, TextBox target, string fileName)
        {
            var destPath = Path.Combine(ModelsCacheDir, fileName);
            if (File.Exists(destPath))
            {
                target.Text = destPath;
                RefreshModelButtons();
                return;
            }

            button.IsEnabled = false;
            var tmpPath = destPath + ".part";

            pnlDownload.Visibility = Visibility.Visible;
            pbDownload.IsIndeterminate = false;
            pbDownload.Value = 0;
            lbDownloadStatus.Text = $"Downloading {fileName}...";
            mmLog.Text += $"Downloading {fileName}..." + Environment.NewLine;

            try
            {
                Directory.CreateDirectory(ModelsCacheDir);

                // Stream to a .part temp file on a background thread, then rename in - an interrupted download never
                // leaves a corrupt .onnx at the final path. Progress marshals back via Dispatcher.BeginInvoke.
                await System.Threading.Tasks.Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(ModelsReleaseUrl + "/" + fileName, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        var total = response.Content.Headers.ContentLength ?? -1L;
                        Dispatcher.BeginInvoke(new Action(() => pbDownload.IsIndeterminate = total <= 0));

                        using (var src = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = File.Create(tmpPath))
                        using (var cts = new System.Threading.CancellationTokenSource())
                        {
                            // ResponseHeadersRead means the HttpClient timeout only bounds the header read, not the
                            // body stream. Guard the copy with an idle timeout so a stalled connection cannot hang
                            // the download forever; the timer resets after every chunk that makes progress.
                            var idleTimeout = TimeSpan.FromSeconds(100);
                            var buffer = new byte[81920];
                            long readTotal = 0;
                            int lastPercent = -1;
                            long lastReportedBytes = 0;
                            int read;
                            cts.CancelAfter(idleTimeout);
                            while ((read = await src.ReadAsync(buffer, 0, buffer.Length, cts.Token)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, read, cts.Token);
                                cts.CancelAfter(idleTimeout);
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
                                            lbDownloadStatus.Text = $"Downloading {fileName}... {percent}% ({done / 1024} / {total / 1024} KB)";
                                        }));
                                    }
                                }
                                else if (readTotal - lastReportedBytes >= 1024 * 1024)
                                {
                                    // No Content-Length: throttle to ~once per MB so the dispatcher isn't flooded.
                                    lastReportedBytes = readTotal;
                                    var done = readTotal;
                                    Dispatcher.BeginInvoke(new Action(() =>
                                        lbDownloadStatus.Text = $"Downloading {fileName}... {done / 1024} KB"));
                                }
                            }
                        }
                    }
                });

                File.Move(tmpPath, destPath, true);

                // The download runs async; the window may already be closing by the time it finishes. Skip UI
                // updates (and never MessageBox.Show(this, ...) with a closing owner — WPF throws on that).
                if (!_isClosing)
                {
                    target.Text = destPath;
                    pbDownload.IsIndeterminate = false;
                    pbDownload.Value = 100;
                    lbDownloadStatus.Text = $"Saved {fileName} ({new FileInfo(destPath).Length / 1024} KB).";
                    mmLog.Text += $"Saved to {ModelsCacheDir}." + Environment.NewLine;
                    RefreshModelButtons();
                }
            }
            catch (Exception ex)
            {
                try { if (File.Exists(tmpPath)) File.Delete(tmpPath); } catch { }

                if (!_isClosing)
                {
                    pbDownload.IsIndeterminate = false;
                    pbDownload.Value = 0;
                    lbDownloadStatus.Text = "Download failed.";
                    mmLog.Text += $"Download failed: {ex.Message}" + Environment.NewLine;
                    MessageBox.Show(this, $"Download failed:\n{ex.Message}\n\nURL: {ModelsReleaseUrl}/{fileName}", "Download Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            finally
            {
                button.IsEnabled = true;
            }
        }

        private void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
                {
                    var deviceName = (string)e.AddedItems[0];
                    if (!string.IsNullOrEmpty(deviceName))
                    {
                        cbVideoFormat.Items.Clear();

                        var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == deviceName);
                        if (device != null)
                        {
                            foreach (var item in device.VideoFormats)
                            {
                                cbVideoFormat.Items.Add(item.Name);
                            }

                            if (cbVideoFormat.Items.Count > 0)
                            {
                                cbVideoFormat.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbVideoFrameRate.Items.Clear();

                if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
                {
                    var deviceName = cbVideoInput.SelectedValue?.ToString();
                    var format = (string)e.AddedItems[0];
                    if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                    {
                        var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == deviceName);
                        var formatItem = device?.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            foreach (var item in formatItem.GetFrameRateRangeAsStringList())
                            {
                                cbVideoFrameRate.Items.Add(item);
                            }

                            if (cbVideoFrameRate.Items.Count > 0)
                            {
                                cbVideoFrameRate.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        // Live-updates the shared settings while the pipeline runs; a no-op before the first Start.
        private void cbCategory_Changed(object sender, RoutedEventArgs e)
        {
            if (_settings == null)
            {
                return;
            }

            _settings.Faces.Enabled = cbFaces.IsChecked == true;
            _settings.LicensePlates.Enabled = cbPlates.IsChecked == true;
            _settings.Text.Enabled = cbText.IsChecked == true;
        }

        private void cbStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_settings != null)
            {
                _settings.Style = (PIIRedactionStyle)cbStyle.SelectedIndex;
            }
        }

        private void cbFillColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_settings != null)
            {
                _settings.FillColor = SelectedFillColor();
            }
        }

        private SKColor SelectedFillColor()
        {
            switch (cbFillColor.SelectedIndex)
            {
                case 1: return SKColors.White;
                case 2: return SKColors.Gray;
                default: return SKColors.Black;
            }
        }

        private void slBlurRadius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbBlurRadius != null)
            {
                lbBlurRadius.Text = ((int)slBlurRadius.Value).ToString();
            }

            if (_settings != null)
            {
                _settings.BlurRadius = (float)slBlurRadius.Value;
            }
        }

        private void slPixelate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbPixelate != null)
            {
                lbPixelate.Text = ((int)slPixelate.Value).ToString();
            }

            if (_settings != null)
            {
                _settings.PixelateBlockSize = (int)slPixelate.Value;
            }
        }

        // Reads the current UI into a fresh settings object (used at Start).
        private PIIRedactionSettings BuildSettings()
        {
            var settings = new PIIRedactionSettings
            {
                Style = (PIIRedactionStyle)cbStyle.SelectedIndex,
                BlurRadius = (float)slBlurRadius.Value,
                PixelateBlockSize = (int)slPixelate.Value,
                FillColor = SelectedFillColor(),
            };

            settings.Faces.Enabled = cbFaces.IsChecked == true;
            settings.Faces.ModelPath = edFaceModel.Text;
            settings.LicensePlates.Enabled = cbPlates.IsChecked == true;
            settings.LicensePlates.ModelPath = edPlateModel.Text;
            settings.Text.Enabled = cbText.IsChecked == true;
            settings.Text.DetectionModelPath = edTextDetModel.Text;
            settings.Text.RecognitionModelPath = edTextRecModel.Text;
            settings.Text.CharacterDictionaryPath = edTextDict.Text;

            var regex = edTextRegex.Text?.Trim();
            if (!string.IsNullOrEmpty(regex))
            {
                settings.Text.TextFilterRegex = regex;
            }

            if (float.TryParse(edPadding.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var padding) && padding >= 0)
            {
                settings.RegionPaddingPercent = padding / 100f;
            }

            if (int.TryParse(edHoldMs.Text, out var hold) && hold >= 0)
            {
                settings.RegionHoldTimeMs = hold;
            }

            if (int.TryParse(edFramesToSkip.Text, out var skip) && skip >= 0)
            {
                settings.FramesToSkip = skip;
            }

            return settings;
        }

        private bool ModelsSelected()
        {
            if (cbFaces.IsChecked != true && cbPlates.IsChecked != true && cbText.IsChecked != true)
            {
                MessageBox.Show(this, "Enable at least one PII category on the Redaction tab.");
                return false;
            }

            if (cbFaces.IsChecked == true && string.IsNullOrWhiteSpace(edFaceModel.Text))
            {
                MessageBox.Show(this, "Select (or download) the face detector model on the Models tab, or disable the Faces category.");
                return false;
            }

            if (cbPlates.IsChecked == true && string.IsNullOrWhiteSpace(edPlateModel.Text))
            {
                MessageBox.Show(this, "Select the license plate detector model on the Models tab, or disable the License plates category.");
                return false;
            }

            if (cbText.IsChecked == true
                && (string.IsNullOrWhiteSpace(edTextDetModel.Text)
                    || string.IsNullOrWhiteSpace(edTextRecModel.Text)
                    || string.IsNullOrWhiteSpace(edTextDict.Text)))
            {
                MessageBox.Show(this, "On-screen text redaction needs the detection model, the recognition model, and the dictionary on the Models tab (recognition filters out non-text detections), or disable the On-screen text category.");
                return false;
            }

            // Validate the regex up front so an invalid pattern reports the real reason instead of the generic
            // "check the model paths" start failure.
            if (cbText.IsChecked == true && !string.IsNullOrWhiteSpace(edTextRegex.Text))
            {
                try
                {
                    _ = new System.Text.RegularExpressions.Regex(edTextRegex.Text.Trim());
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, "Invalid text filter regex: " + ex.Message);
                    return false;
                }
            }

            return true;
        }

        private async System.Threading.Tasks.Task<bool> BuildSourceAsync()
        {
            if (rbFile.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(edVideoFile.Text))
                {
                    MessageBox.Show(this, "Select a video file.");
                    return false;
                }

                var settings = await UniversalSourceSettings.CreateAsync(edVideoFile.Text, renderVideo: true, renderAudio: false);
                _videoSource = new UniversalSourceBlock(settings);
                return true;
            }

            if (rbRTSP.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(edRTSPURL.Text) || edRTSPURL.Text.Trim() == "rtsp://")
                {
                    MessageBox.Show(this, "Enter an RTSP URL.");
                    return false;
                }

                var rtspSettings = await RTSPSourceSettings.CreateAsync(new Uri(edRTSPURL.Text.Trim()), edRTSPLogin.Text, edRTSPPassword.Password, audioEnabled: false);
                _videoSource = new RTSPSourceBlock(rtspSettings);
                return true;
            }

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select a video input device.");
                return false;
            }

            VideoCaptureDeviceSourceSettings videoSourceSettings = null;
            var deviceName = cbVideoInput.Text;
            var deviceFormat = cbVideoFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(deviceFormat))
            {
                var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == deviceName);
                var formatItem = device?.VideoFormats.FirstOrDefault(x => x.Name == deviceFormat);
                if (formatItem != null)
                {
                    videoSourceSettings = new VideoCaptureDeviceSourceSettings(device) { Format = formatItem.ToFormat() };
                    if (!string.IsNullOrEmpty(cbVideoFrameRate.Text))
                    {
                        videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text, CultureInfo.InvariantCulture));
                    }
                }
            }

            if (videoSourceSettings == null)
            {
                MessageBox.Show(this, "Unable to configure the selected video device.");
                return false;
            }

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);
            return true;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _uiBusy = true;
                btStart.IsEnabled = false;

                if (_pipeline == null)
                {
                    MessageBox.Show(this, "The SDK failed to initialize. Please restart the application.");
                    btStart.IsEnabled = true;
                    return;
                }

                mmLog.Clear();
                txtResults.Clear();

                try
                {
                    await _pipeline.StopAsync();
                    _pipeline.ClearBlocks();
                }
                catch (Exception priorStopEx)
                {
                    Debug.WriteLine(priorStopEx);
                }

                CleanupBlocks();

                if (!ModelsSelected())
                {
                    btStart.IsEnabled = true;
                    return;
                }

                if (!await BuildSourceAsync())
                {
                    btStart.IsEnabled = true;
                    return;
                }

                _isFile = rbFile.IsChecked == true;

                // Sync the renderer only for real-time file playback; live sources and max-speed files run unsynchronized.
                var realTime = _isFile && cbRealTime.IsChecked == true;
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = realTime };

                _settings = BuildSettings();
                _redaction = new PIIRedactionBlock(_settings);
                _redaction.OnRegionsRedacted += Redaction_OnRegionsRedacted;

                _pipeline.Connect(_videoSource.Output, _redaction.Input);
                _pipeline.Connect(_redaction.Output, _videoRenderer.Input);

                if (!await _pipeline.StartAsync())
                {
                    mmLog.Text += "Failed to start PII redaction - check the model paths and selected device." + Environment.NewLine;
                    try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch (Exception stopEx) { Debug.WriteLine(stopEx); }
                    CleanupBlocks();
                    btStart.IsEnabled = true;
                    return;
                }

                mmLog.Text += $"PII redaction running on: {_redaction.ActiveProvider}" + Environment.NewLine;

                // Enable the seek bar for file playback; duration resolves lazily in the timer once playback prerolls.
                _duration = TimeSpan.Zero;
                _suppressSeek = true;
                slSeek.Value = 0;
                _suppressSeek = false;
                slSeek.IsEnabled = _isFile;

                _timer.Start();
                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                try
                {
                    await _pipeline.StopAsync();
                    _pipeline.ClearBlocks();
                }
                catch (Exception cleanupEx)
                {
                    Debug.WriteLine(cleanupEx);
                }

                CleanupBlocks();

                btStart.IsEnabled = true;
                btStop.IsEnabled = false;

                mmLog.Text += ex.Message + Environment.NewLine;
                Debug.WriteLine(ex);
            }
            finally
            {
                _uiBusy = false;
            }
        }

        private void Redaction_OnRegionsRedacted(object sender, PIIRegionsRedactedEventArgs e)
        {
            // Marshal to the UI thread without blocking the detection worker.
            Dispatcher.BeginInvoke(new Action(() =>
            {
                int faces = 0, plates = 0, text = 0;
                foreach (var region in e.Regions)
                {
                    switch (region.Category)
                    {
                        case PIICategory.Face: faces++; break;
                        case PIICategory.LicensePlate: plates++; break;
                        case PIICategory.Text: text++; break;
                    }
                }

                var parts = new System.Collections.Generic.List<string>();
                if (faces > 0) parts.Add($"{faces} face(s)");
                if (plates > 0) parts.Add($"{plates} plate(s)");
                if (text > 0) parts.Add($"{text} text region(s)");

                var line = $"[{e.Timestamp:hh\\:mm\\:ss}] Redacted {string.Join(", ", parts)}";

                // Diagnostic for text over-detection: dump the largest text box (WxH) and the score range, so we can
                // tell one giant false box (geometry) from many high-confidence DBNet detections (scene noise).
                if (text > 0)
                {
                    int maxW = 0, maxH = 0, maxArea = -1;
                    float minScore = float.MaxValue, maxScore = float.MinValue;
                    foreach (var region in e.Regions)
                    {
                        if (region.Category != PIICategory.Text) continue;
                        int w = region.BoundingBox.Right - region.BoundingBox.Left;
                        int h = region.BoundingBox.Bottom - region.BoundingBox.Top;
                        if (w * h > maxArea) { maxArea = w * h; maxW = w; maxH = h; }
                        if (region.Score < minScore) minScore = region.Score;
                        if (region.Score > maxScore) maxScore = region.Score;
                    }

                    line += $"\r\n    text: {text} box(es), largest {maxW}x{maxH}, score {minScore:0.00}..{maxScore:0.00}";
                }

                // Newest on top; cap the buffer so it does not grow without bound.
                txtResults.Text = line + "\r\n" + txtResults.Text;
                if (txtResults.Text.Length > 40000)
                {
                    txtResults.Text = txtResults.Text.Substring(0, 40000);
                }
            }));
        }

        private void CleanupBlocks()
        {
            if (_redaction != null)
            {
                _redaction.OnRegionsRedacted -= Redaction_OnRegionsRedacted;
                _redaction.Dispose();
                _redaction = null;
            }

            _settings = null;
            _videoRenderer = null;

            // Dispose the source if it was created but never connected: if an exception fires after
            // BuildSourceAsync but before Connect, ClearBlocks never saw it, so nulling alone would leak the
            // native block. Dispose is idempotent, so this is safe even when it was already connected+cleared.
            _videoSource?.Dispose();
            _videoSource = null;
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _uiBusy = true;
                btStop.IsEnabled = false;

                _timer?.Stop();

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.ClearBlocks();
                }

                CleanupBlocks();

                VideoView1.CallRefresh();

                slSeek.IsEnabled = false;
                _suppressSeek = true;
                slSeek.Value = 0;
                _suppressSeek = false;

                btStart.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _uiBusy = false;
            }
        }
    }
}
