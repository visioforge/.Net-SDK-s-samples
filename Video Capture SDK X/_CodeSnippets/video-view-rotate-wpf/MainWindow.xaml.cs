using System;
using System.IO;
using System.Linq;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.VideoCaptureX;

namespace video_view_rotate_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX VideoCapture1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCoreX(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
        }

        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            CreateEngine();

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;

            await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";
        }

        private void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbVideoInputDevice.Items.Add(e.DisplayName);

                if (cbVideoInputDevice.Items.Count == 1)
                {
                    cbVideoInputDevice.SelectedIndex = 0;
                }
            });
        }

        private async void cbVideoInputDevice_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            cbVideoInputFormat.Items.Clear();

            var devices = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList();
            var deviceItem = devices.Find(device => device.DisplayName == cbVideoInputDevice.Text);
            if (deviceItem == null)
            {
                return;
            }

            foreach (var format in deviceItem.VideoFormats)
            {
                cbVideoInputFormat.Items.Add(format.Name);
            }

            if (cbVideoInputFormat.Items.Count > 0)
            {
                cbVideoInputFormat.SelectedIndex = 0;
                cbVideoInputFormat_SelectionChanged(null, null);
            }
        }

        private async void cbVideoInputFormat_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat.Text))
            {
                return;
            }

            cbVideoInputFrameRate.Items.Clear();

            if (string.IsNullOrEmpty(cbVideoInputFormat.Text) || string.IsNullOrEmpty(cbVideoInputDevice.Text))
            {
                return;
            }

            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                var devices = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList();
                var deviceItem = devices.Find(device => device.DisplayName == cbVideoInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.Find(format => format.Name == cbVideoInputFormat.Text);
                if (videoFormat == null)
                {
                    return;
                }

                // build int range from tuple (min, max)    
                var frameRateList = videoFormat.GetFrameRateRangeAsStringList();
                foreach (var item in frameRateList)
                {
                    cbVideoInputFrameRate.Items.Add(item);
                }

                if (cbVideoInputFrameRate.Items.Count > 0)
                {
                    cbVideoInputFrameRate.SelectedIndex = 0;
                }
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            // set debug settings
            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            VideoCapture1.Debug_Telemetry = cbTelemetry.IsChecked == true;
            mmLog.Clear();

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInputDevice.Text;
            var format = cbVideoInputFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList().Find(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.ToList().Find(x => x.Name == format);
                    if (formatItem != null)
                    {
                        videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                        {
                            Format = formatItem.ToFormat()
                        };

                        videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text));
                    }
                }
            }

            VideoCapture1.Video_Source = videoSourceSettings;

            // Disable native rendering to allow WPF rotation
            VideoView1.SetNativeRendering(false);

            // start
            await VideoCapture1.StartAsync();

            // Apply rotation
            ApplyRotation();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 != null)
            {
                await VideoCapture1.StopAsync();
            }
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 != null)
            {
                await VideoCapture1.PauseAsync();
            }
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 != null)
            {
                await VideoCapture1.ResumeAsync();
            }
        }

        private void cbRotationEnabled_Checked(object sender, RoutedEventArgs e)
        {
            ApplyRotation();
        }

        private void sliderRotation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tbRotationValue != null)
            {
                tbRotationValue.Text = $"{(int)sliderRotation.Value}°";
            }

            ApplyRotation();
        }

        private void ApplyRotation()
        {
            if (cbRotationEnabled?.IsChecked == true)
            {
                VideoView1.RotationAngle = sliderRotation.Value;
                VideoView1.RotationStretch = System.Windows.Media.Stretch.Uniform;
            }
            else
            {
                VideoView1.RotationAngle = 0;
            }
        }

        private void Log(string txt)
        {
            Dispatcher.Invoke(() =>
            {
                mmLog.Text = mmLog.Text + txt + Environment.NewLine;
            });
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();

            VisioForgeX.DestroySDK();
        }
    }
}
