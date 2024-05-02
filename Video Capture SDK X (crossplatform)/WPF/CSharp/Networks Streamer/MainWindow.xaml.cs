using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.VideoCaptureX;
using Rect = VisioForge.Core.Types.Rect;

namespace Networks_Streamer_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _videoCapture;

        private System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();     

            // We have to initialize the engine on start
            VisioForgeX.InitSDK();

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;
            DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;
            DeviceEnumerator.Shared.OnAudioSinkAdded += DeviceEnumerator_OnAudioSinkAdded;
        }

        private void DeviceEnumerator_OnAudioSinkAdded(object sender, AudioOutputDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioOutput.Items.Add(e.DisplayName);

                if (cbAudioOutput.Items.Count > 0)
                {
                    cbAudioOutput.SelectedIndex = 0;
                }
            });
        }

        private void DeviceEnumerator_OnAudioSourceAdded(object sender, AudioCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioInput.Items.Add(e.DisplayName);

                if (cbAudioInput.Items.Count > 0)
                {
                    cbAudioInput.SelectedIndex = 0;
                }
            });
        }

        private void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbVideoInput.Items.Add(e.DisplayName);

                if (cbVideoInput.Items.Count > 0)
                {
                    cbVideoInput.SelectedIndex = 0;
                }
            });
        }

        private void VideoCapture_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            _videoCapture = new VideoCaptureCoreX(VideoView1);
            _videoCapture.OnError += VideoCapture_OnError;

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

            cbVideoInput.Items.Add("Screen capture");

            await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
            await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();
            await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var position = await _videoCapture.DurationAsync();

            Dispatcher.Invoke(() =>
            {
                lbTime.Text = position.ToString("hh\\:mm\\:ss");
            });
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select video input device");
                return;
            }

            // video source
            if (cbVideoInput.SelectedIndex == 0)
            {
                var screenCaptureSourceSettings = new ScreenCaptureD3D11SourceSettings();
                screenCaptureSourceSettings.Rectangle = new Rect(0, 0, 1920, 1080);
                screenCaptureSourceSettings.FrameRate = new VideoFrameRate(30);

                _videoCapture.Video_Source = screenCaptureSourceSettings;
            }
            else
            {
                VideoCaptureDeviceSourceSettings videoSourceSettings = null;

                var videoDeviceName = cbVideoInput.Text;
                var videoFormat = cbVideoFormat.Text;
                if (!string.IsNullOrEmpty(videoDeviceName) && !string.IsNullOrEmpty(videoFormat))
                {
                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == videoDeviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == videoFormat);
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

                _videoCapture.Video_Source = videoSourceSettings;
            }

            // audio source
            IVideoCaptureBaseAudioSourceSettings audioSourceSettings = null;

            var deviceName = cbAudioInput.Text;
            var format = cbAudioFormat.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        audioSourceSettings = device.CreateSourceSettingsVC(formatItem.ToFormat());
                    }
                }
            }

            _videoCapture.Audio_Source = audioSourceSettings;

            // audio output
            if (!string.IsNullOrEmpty(cbAudioOutput.Text))
            {
                var device = (await DeviceEnumerator.Shared.AudioOutputsAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    _videoCapture.Audio_OutputDevice = new AudioRendererSettings(device);                    
                }
            }

            // output
            _videoCapture.Outputs_Clear();
            _videoCapture.Audio_Record = true;
            _videoCapture.Audio_Play = true;

            // YouTube
            if (cbPlatform.SelectedIndex == 0)
            {
                var youTubeOutput = new YouTubeOutput(edStreamingKey.Text);
                _videoCapture.Outputs_Add(youTubeOutput, true);
            }
            // Facebook Live
            else if (cbPlatform.SelectedIndex == 1)
            {
                var facebookOutput = new FacebookLiveOutput(edStreamingKey.Text);
                _videoCapture.Outputs_Add(facebookOutput, true);
            }
            // generic RTMP
            else if (cbPlatform.SelectedIndex == 2)
            {
                var rtmpOutput = new RTMPOutput(edStreamingKey.Text);
                _videoCapture.Outputs_Add(rtmpOutput, true);
            }
            // AWS S3
            else if (cbPlatform.SelectedIndex == 3)
            {
                var s3settings = new AWSS3SinkSettings();
                s3settings.Region = "us-west-2";
                s3settings.ContentType = "video/mp4";
                s3settings.Uri = "s3://us-west-2/visioforge-test/output.mp4";

                s3settings.AccessKey = "#####";
                s3settings.SecretAccessKey = "#####";

                var s3Output = new AWSS3Output(s3settings, H264EncoderBlock.GetDefaultSettings(), AACEncoderBlock.GetDefaultSettings(), new MP4SinkSettings() { MuxOnly = true });
                _videoCapture.Outputs_Add(s3Output, true);
            }

            // start
            await _videoCapture.StartAsync();

            _timer.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            await _videoCapture?.StopAsync();

            VideoView1.CallRefresh();
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            if (_videoCapture != null)
            {
                await _videoCapture?.StopAsync();
                _videoCapture.OnError -= VideoCapture_OnError;
                await _videoCapture.DisposeAsync();
                _videoCapture = null;
            }

            VisioForgeX.DestroySDK();
        }

        private async void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbVideoFormat.Items.Clear();

            if (cbVideoInput.SelectedIndex > 0 && e != null && e.AddedItems.Count > 0)
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

        private async void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbVideoFrameRate.Items.Clear();

            if (cbVideoInput.SelectedIndex > 0 && e != null && e.AddedItems.Count > 0)
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

        private async void cbAudioInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAudioInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                var deviceName = (string)e.AddedItems[0];
                if (!string.IsNullOrEmpty(deviceName))
                {
                    cbAudioFormat.Items.Clear();

                    var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        foreach (var format in device.Formats)
                        {
                            cbAudioFormat.Items.Add(format.Name);
                        }

                        if (cbAudioFormat.Items.Count > 0)
                        {
                            cbAudioFormat.SelectedIndex = 0;
                        }
                    }
                }
            }
        }
    }
}
