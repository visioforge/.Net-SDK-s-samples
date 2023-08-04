using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace Social_Networks_Streamer_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DeviceEnumerator _deviceEnumerator;

        private VideoCaptureCoreX _videoCapture;

        private System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();     

            // We have to initialize the engine on start
            MediaBlocksPipeline.InitSDK();
            
            _deviceEnumerator = new DeviceEnumerator();
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

            var videoCaptureDevices = (await _deviceEnumerator.VideoSourcesAsync());
            if (videoCaptureDevices.Length > 0)
            {
                foreach (var item in videoCaptureDevices)
                {
                    cbVideoInput.Items.Add(item.DisplayName);
                }

                cbVideoInput.SelectedIndex = 0;
            }

            var audioCaptureDevices = (await _deviceEnumerator.AudioSourcesAsync(AudioCaptureDeviceAPI.DirectSound));
            if (audioCaptureDevices.Length > 0)
            {
                foreach (var item in audioCaptureDevices)
                {
                    cbAudioInput.Items.Add(item.DisplayName);
                }

                cbAudioInput.SelectedIndex = 0;
            }

            var audioOutputDevices = (await _deviceEnumerator.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound));
            if (audioOutputDevices.Length > 0)
            {
                foreach (var item in audioOutputDevices)
                {
                    cbAudioOutput.Items.Add(item.DisplayName);
                }

                cbAudioOutput.SelectedIndex = 0;
            }
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
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInput.Text;
            var format = cbVideoFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = (await _deviceEnumerator.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
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

            _videoCapture.Video_Source = videoSourceSettings;

            // audio source
            DSAudioCaptureDeviceSourceSettings audioSourceSettings = null;

            deviceName = cbAudioInput.Text;
            format = cbAudioFormat.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = (await _deviceEnumerator.AudioSourcesAsync(AudioCaptureDeviceAPI.DirectSound)).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        audioSourceSettings = new DSAudioCaptureDeviceSourceSettings(device, formatItem.ToFormat());
                    }
                }
            }

            _videoCapture.Audio_Source = audioSourceSettings;

            // audio output
            if (!string.IsNullOrEmpty(cbAudioOutput.Text))
            {
                var device = (await _deviceEnumerator.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    _videoCapture.Audio_OutputDevice = device;                    
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

            _deviceEnumerator?.Dispose();
        }

        private async void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                var deviceName = (string)e.AddedItems[0];

                if (!string.IsNullOrEmpty(deviceName))
                {
                    cbVideoFormat.Items.Clear();

                    var device = (await _deviceEnumerator.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
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

            if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                var deviceName = cbVideoInput.SelectedValue.ToString();
                var format = (string)e.AddedItems[0];
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await _deviceEnumerator.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
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

                    var device = (await _deviceEnumerator.AudioSourcesAsync(AudioCaptureDeviceAPI.DirectSound)).FirstOrDefault(x => x.DisplayName == deviceName);
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
