using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SkiaSharp;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.OpenCV;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.OpenCV;
using VisioForge.Core.Types.X.Sources;

namespace MediaBlocks_Motion_Detection_Demo_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private SystemVideoSourceBlock _videoSource;

        private CVMotionCellsBlock _motionDetector;

        private System.Timers.Timer _timer;

        private int _motionEventCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Device enumerator on video source added.
        /// </summary>
        private void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbVideoInput.Items.Add(e.DisplayName);

                if (cbVideoInput.Items.Count == 1)
                {
                    cbVideoInput.SelectedIndex = 0;
                }
            });
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
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();

            // Setup slider value change handlers
            sliderGridX.ValueChanged += (s, args) => lblGridX.Content = ((int)sliderGridX.Value).ToString();
            sliderGridY.ValueChanged += (s, args) => lblGridY.Content = ((int)sliderGridY.Value).ToString();
            sliderSensitivity.ValueChanged += (s, args) => lblSensitivity.Content = sliderSensitivity.Value.ToString("F2");
            sliderThreshold.ValueChanged += (s, args) => lblThreshold.Content = sliderThreshold.Value.ToString("F2");
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

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
                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
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

            // motion detection settings
            var motionSettings = new CVMotionCellsSettings
            {
                GridSize = new VisioForge.Core.Types.Size((int)sliderGridX.Value, (int)sliderGridY.Value),
                Sensitivity = sliderSensitivity.Value,
                Display = cbDisplayMotion.IsChecked == true,
                PostNoMotion = TimeSpan.Zero,
                PostAllMotion = true,
                MinimumMotionFrames = 1,
                Gap = TimeSpan.FromSeconds(1),
                Threshold = sliderThreshold.Value,
                CalculateMotion = true,
                CellsColor = SKColors.Red
            };

            _motionDetector = new CVMotionCellsBlock(motionSettings);
            _motionDetector.MotionDetected += MotionDetector_OnMotionDetected;

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

            // connect all
            _pipeline.Connect(_videoSource.Output, _motionDetector.Input);
            _pipeline.Connect(_motionDetector.Output, _videoRenderer.Input);

            // start
            await _pipeline.StartAsync();

            _timer.Start();
        }

        /// <summary>
        /// Motion detector on motion detected.
        /// </summary>
        private void MotionDetector_OnMotionDetected(object sender, CVMotionCellsEventArgs e)
        {
            _motionEventCount++;
            
            Dispatcher.Invoke(() =>
            {
                lbMotionEvents.Text = $"Motion Events: {_motionEventCount}";
                lbMotionLevel.Text = $"Motion: {(e.IsMotion ? "Yes" : "No")}";
                
                // Log to the text box
                mmLog.AppendText($"[{DateTime.Now:HH:mm:ss}] Motion detected: {e.Cells}{Environment.NewLine}");
                mmLog.ScrollToEnd();
            });
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            await _pipeline?.StopAsync();

            _pipeline?.ClearBlocks();

            VideoView1.CallRefresh();

            if (_motionDetector != null)
            {
                _motionDetector.MotionDetected -= MotionDetector_OnMotionDetected;
            }
        }

        /// <summary>
        /// Timer elapsed.
        /// </summary>
        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(async () =>
            {
                var position = await _pipeline.Position_GetAsync();
                lbTime.Text = position.ToString("hh\\:mm\\:ss");
            });
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();

                _pipeline.OnError -= Pipeline_OnError;

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Cb video input selection changed.
        /// </summary>
        private async void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                var deviceName = (string)e.AddedItems[0];

                if (!string.IsNullOrEmpty(deviceName))
                {
                    cbVideoFormat.Items.Clear();

                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
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

        /// <summary>
        /// Cb video format selection changed.
        /// </summary>
        private async void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbVideoFrameRate.Items.Clear();

            if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                var deviceName = cbVideoInput.SelectedValue.ToString();
                var format = (string)e.AddedItems[0];
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
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
    }
}
