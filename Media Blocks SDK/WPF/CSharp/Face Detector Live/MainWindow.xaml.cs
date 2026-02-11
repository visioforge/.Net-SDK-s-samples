using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.CV;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.OpenCV;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.OpenCV;
using VisioForge.Core.Types.X.Sources;
using System.Diagnostics;

namespace Face_Detector_Live
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The video source.
        /// </summary>
        private SystemVideoSourceBlock _videoSource;

        /// <summary>
        /// The face detector.
        /// </summary>
        private DNNFaceDetectorBlock _faceDetect;

        /// <summary>
        /// The timer.
        /// </summary>
        private System.Timers.Timer _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // We have to initialize the engine on start
                Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                this.IsEnabled = true;
                Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                _timer = new System.Timers.Timer(500);
                _timer.Elapsed += _timer_Elapsed;

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                var videoCaptureDevices = await SystemVideoSourceBlock.GetDevicesAsync();
                if (videoCaptureDevices.Length > 0)
                {
                    foreach (var item in videoCaptureDevices)
                    {
                        cbVideoInput.Items.Add(item.DisplayName);
                    }

                    cbVideoInput.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Timer elapsed.
        /// </summary>
        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                var position = await _pipeline.Position_GetAsync();

                Dispatcher.Invoke(() =>
                {
                    lbTime.Text = position.ToString("hh\\:mm\\:ss");
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                _timer.Stop();

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();

                    _pipeline.OnError -= Pipeline_OnError;

                    await _pipeline.DisposeAsync();

                    _pipeline = null;
                }

                VideoView1.CallRefresh();

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Cb video input selection changed.
        /// </summary>
        private async void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
                {
                    var deviceName = (string)e.AddedItems[0];

                    if (!string.IsNullOrEmpty(deviceName))
                    {
                        cbVideoFormat.Items.Clear();

                        var device = (await SystemVideoSourceBlock.GetDevicesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
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

        /// <summary>
        /// Cb video format selection changed.
        /// </summary>
        private async void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                        var device = (await SystemVideoSourceBlock.GetDevicesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                        if (device != null)
                        {
                            var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                            if (formatItem != null)
                            {
                                // build int range from tuple (min, max)    
                                var frameRateList = formatItem.GetFrameRateRangeAsStringList();
                                foreach (var item in frameRateList)
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mmLog.Clear();

                if (cbVideoInput.SelectedIndex < 0)
                {
                    MessageBox.Show(this, "Select video input device");
                    return;
                }

                // video source
                VideoCaptureDeviceSourceSettings videoSourceSettings = null;

                var deviceName = cbVideoInput.Text;
                var format = cbVideoFormat.Text;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await SystemVideoSourceBlock.GetDevicesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                            {
                                Format = formatItem.ToFormat()
                            };

                            videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text));
                        }
                    }
                }

                _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

                // video renderer
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

                // detector/blurrer
                var detectSettings = new DNNFaceDetectorSettings();
                detectSettings.Blur = rbBlurFaces.IsChecked == true;
                _faceDetect = new DNNFaceDetectorBlock(detectSettings);
                _faceDetect.OnFaceDetected += _detector_FaceDetected;

                // connect all
                _pipeline.Connect(_videoSource.Output, _faceDetect.Input);
                _pipeline.Connect(_faceDetect.Output, _videoRenderer.Input);

                // start
                await _pipeline.StartAsync();

                _timer.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Detector hand detected.
        /// </summary>
        private void _detector_HandDetected(object sender, CVHandDetectedEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmFaces.Text = e.ToString();
            }));
        }

        /// <summary>
        /// Detector face detected.
        /// </summary>
        private void _detector_FaceDetected(object sender, CVFaceDetectedEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmFaces.Text = e.ToString();
            }));
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _timer.Stop();

                if (_faceDetect != null)
                {
                    _faceDetect.OnFaceDetected -= _detector_FaceDetected;
                }

                await _pipeline?.StopAsync();

                _pipeline?.ClearBlocks();

                VideoView1.CallRefresh();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
