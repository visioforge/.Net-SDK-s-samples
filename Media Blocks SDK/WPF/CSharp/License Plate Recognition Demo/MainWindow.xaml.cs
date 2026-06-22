using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.AI;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace License_Plate_Recognition_Demo
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

        private LicensePlateRecognizerBlock _anpr;

        private System.Windows.Threading.DispatcherTimer _timer;

        private bool _timerBusy;

        private VideoCaptureDeviceInfo[] _videoCaptureDevices;

        private bool _isClosing;

        private bool _uiBusy;

        // Bundled FastALPR (MIT) model filenames, shipped next to the executable.
        private const string DetectorModelFile = "yolo-v9-t-640-license-plates-end2end.onnx";
        private const string RecognizerGlobalModelFile = "cct_s_v1_global.onnx";
        private const string RecognizerEuModelFile = "european_mobile_vit_v2_ocr.onnx";

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() => { mmLog.Text += e.Message + Environment.NewLine; });
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

                // Default to the bundled FastALPR (MIT) models shipped next to the executable.
                PrefillModelPath(edDetModel, DetectorModelFile);

                cbRegion.Items.Add("Global (USA + 90+ countries)");
                cbRegion.Items.Add("Europe");
                cbRegion.SelectedIndex = 0; // fires cbRegion_SelectionChanged -> fills the recognition model path

                var providers = OnnxInferenceEngine.GetAvailableProviders();
                mmLog.Text += "ONNX Runtime providers: " + string.Join(", ", providers) + Environment.NewLine;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private static void PrefillModelPath(TextBox box, string fileName)
        {
            var path = System.IO.Path.Combine(AppContext.BaseDirectory, fileName);
            if (System.IO.File.Exists(path))
            {
                box.Text = path;
            }
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
                lbTime.Text = position.ToString("hh\\:mm\\:ss");
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

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing)
            {
                return;
            }

            e.Cancel = true;
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
                Dispatcher.BeginInvoke(new Action(() => Close()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                _isClosing = false;
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

        private void btSelectDet_Click(object sender, RoutedEventArgs e) => PickOnnx(edDetModel);

        private void btSelectRec_Click(object sender, RoutedEventArgs e) => PickOnnx(edRecModel);

        private void cbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (edRecModel == null)
            {
                return;
            }

            // Europe uses the EU-tuned head; everything else uses the global head.
            PrefillModelPath(edRecModel, cbRegion.SelectedIndex == 1 ? RecognizerEuModelFile : RecognizerGlobalModelFile);
        }

        private static void PickOnnx(TextBox box)
        {
            var dlg = new OpenFileDialog { Filter = "ONNX models|*.onnx|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                box.Text = dlg.FileName;
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
                    var deviceName = cbVideoInput.SelectedValue.ToString();
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
                lbResults.Items.Clear();

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

                if (string.IsNullOrWhiteSpace(edDetModel.Text) || string.IsNullOrWhiteSpace(edRecModel.Text))
                {
                    MessageBox.Show(this, "Select the plate detector model and the plate OCR model.");
                    btStart.IsEnabled = true;
                    return;
                }

                if (!await BuildSourceAsync())
                {
                    btStart.IsEnabled = true;
                    return;
                }

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

                var anprSettings = new LicensePlateRecognizerSettings(edDetModel.Text, edRecModel.Text)
                {
                    DrawResults = cbDrawResults.IsChecked == true,
                };

                if (int.TryParse(edFramesToSkip.Text, out var skip) && skip >= 0)
                {
                    anprSettings.FramesToSkip = skip;
                }

                if (float.TryParse(edDetConfidence.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var detConf))
                {
                    anprSettings.DetectionConfidenceThreshold = detConf;
                }

                if (float.TryParse(edOcrConfidence.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var ocrConf))
                {
                    anprSettings.OcrConfidenceThreshold = ocrConf;
                }

                _anpr = new LicensePlateRecognizerBlock(anprSettings);
                _anpr.OnPlateRecognized += Anpr_OnPlateRecognized;

                _pipeline.Connect(_videoSource.Output, _anpr.Input);
                _pipeline.Connect(_anpr.Output, _videoRenderer.Input);

                await _pipeline.StartAsync();

                mmLog.Text += $"ANPR running on: {_anpr.ActiveProvider}" + Environment.NewLine;

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

        private void Anpr_OnPlateRecognized(object sender, LicensePlateRecognizedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                foreach (var plate in e.Plates)
                {
                    lbResults.Items.Insert(0, $"[{e.Timestamp:hh\\:mm\\:ss}] {plate.Text}  ({plate.Confidence:P0})");
                }

                while (lbResults.Items.Count > 300)
                {
                    lbResults.Items.RemoveAt(lbResults.Items.Count - 1);
                }
            });
        }

        private void CleanupBlocks()
        {
            if (_anpr != null)
            {
                _anpr.OnPlateRecognized -= Anpr_OnPlateRecognized;
                _anpr.Dispose();
                _anpr = null;
            }

            _videoRenderer = null;
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
