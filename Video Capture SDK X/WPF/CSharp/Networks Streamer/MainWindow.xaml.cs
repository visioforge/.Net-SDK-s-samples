using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.VideoCaptureX;
using Rect = VisioForge.Core.Types.Rect;

namespace Networks_Streamer_Demo
{
    /// <summary>
    /// Interaction logic for the Networks Streamer WPF demo's MainWindow.
    /// Demonstrates streaming to various online platforms and network protocols (YouTube, Facebook, RTSP, RTMP, SRT, NDI, HLS, etc.) using the X-engine.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _videoCapture;

        private System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the OnAudioSinkAdded event of the DeviceEnumerator.
        /// Adds newly discovered audio output devices to the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="AudioOutputDeviceInfo"/> instance containing the device information.</param>
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

        /// <summary>
        /// Handles the OnAudioSourceAdded event of the DeviceEnumerator.
        /// Adds newly discovered audio input sources to the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="AudioCaptureDeviceInfo"/> instance containing the device information.</param>
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

        /// <summary>
        /// Handles the OnVideoSourceAdded event of the DeviceEnumerator.
        /// Adds newly discovered video input sources to the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VideoCaptureDeviceInfo"/> instance containing the device information.</param>
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

        /// <summary>
        /// Handles the OnError event of the _videoCapture control.
        /// Logs error messages to the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the error information.</param>
        private void VideoCapture_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// Initializes the SDK, sets up the engine, and starts device monitoring.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;
            DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;
            DeviceEnumerator.Shared.OnAudioSinkAdded += DeviceEnumerator_OnAudioSinkAdded;

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

        /// <summary>
        /// Handles the Elapsed event of the _timer control.
        /// Updates the streaming duration displayed in the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var position = await _videoCapture.DurationAsync();

            Dispatcher.Invoke(() =>
            {
                lbTime.Text = position.ToString("hh\\:mm\\:ss");
            });
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the engine with selected capture devices and network output, then starts streaming.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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
                screenCaptureSourceSettings.FrameRate = new VideoFrameRate(30);

                _videoCapture.Video_Source = screenCaptureSourceSettings;

             //   _videoCapture.Video_Effects_Clear();
              //  await _videoCapture.Video_Effects_AddOrUpdateAsync(new ResizeVideoEffect(1920, 1080));
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
            // RTSP server
            else if (cbPlatform.SelectedIndex == 3)
            {
                var rtspSettings = new RTSPServerSettings(new Uri(edStreamingKey.Text), new OpenH264EncoderSettings(), new VOAACEncoderSettings());
                var rtspOutput = new RTSPServerOutput(rtspSettings);
                _videoCapture.Outputs_Add(rtspOutput, true);
            }
            // AWS S3
            else if (cbPlatform.SelectedIndex == 4)
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
            // SRT (muxed into MPEG-TS)
            else if (cbPlatform.SelectedIndex == 5)
            {
                var srtOutput = new SRTOutput(edStreamingKey.Text);
                _videoCapture.Outputs_Add(srtOutput, true);
            }
            // NDI
            else if (cbPlatform.SelectedIndex == 6)
            {
                var ndiOutput = new NDIOutput(edStreamingKey.Text);
                _videoCapture.Outputs_Add(ndiOutput, true);
            }
            // MJPEG
            else if (cbPlatform.SelectedIndex == 7)
            {
                int port = 8090;
                var mjpegOutput = new HTTPMJPEGLiveOutput(port);
                _videoCapture.Outputs_Add(mjpegOutput, true);

                edStreamingKey.Text = $"IMG tag URL is http://127.0.0.1:{port}";

                _videoCapture.Audio_Record = false;
                _videoCapture.Audio_Play = false;
            }
            // HLS
            else if (cbPlatform.SelectedIndex == 8)
            {
                // HLS sink
                var settings = new HLSSinkSettings
                {
                    Location = Path.Combine(AppContext.BaseDirectory, "segment_%05d.ts"),
                    MaxFiles = 10,
                    PlaylistLength = 5,
                    PlaylistLocation = Path.Combine(AppContext.BaseDirectory, "playlist.m3u8"),
                    PlaylistRoot = edStreamingKey.Text,
                    SendKeyframeRequests = true,
                    TargetDuration = TimeSpan.FromSeconds(5),
                    Custom_HTTP_Server_Enabled = true,
                    Custom_HTTP_Server_Port = new Uri(edStreamingKey.Text).Port
                };

                var hlsOutput = new HLSOutput(settings);
                _videoCapture.Outputs_Add(hlsOutput, true);
            }

            // start
            await _videoCapture.StartAsync();

            _timer.Start();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the network stream and resets UI state.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            await _videoCapture?.StopAsync();

            VideoView1.CallRefresh();
        }

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// Ensures the engine is stopped and resources are released.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the SelectionChanged event of the cbVideoInput control.
        /// Populates available video formats for the selected camera.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the SelectionChanged event of the cbVideoFormat control.
        /// Populates available frame rates for the selected video format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the SelectionChanged event of the cbAudioInput control.
        /// Populates available audio formats for the selected device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the SelectionChanged event of the cbPlatform control.
        /// Updates the default streaming key or URL text depending on the selected platform.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbPlatform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (edStreamingKey == null)
            {
                return;
            }

            switch (cbPlatform.SelectedIndex)
            {
                case 0:
                    edStreamingKey.Text = "YouTube streaming key";
                    break;
                case 1:
                    edStreamingKey.Text = "Facebook streaming key";
                    break;
                case 2:
                    edStreamingKey.Text = "RTMP streaming key";
                    break;
                case 3:
                    edStreamingKey.Text = "rtsp://127.0.0.1:7777/live";
                    break;
                case 4:
                    edStreamingKey.Text = "AWS S3 URL";
                    break;
                case 5:
                    edStreamingKey.Text = "SRT streaming URL";
                    break;
                case 6:
                    edStreamingKey.Text = "NDI name";
                    break;
                case 7:
                    edStreamingKey.Text = "";
                    break;
                case 8:
                    edStreamingKey.Text = "http://localhost:8088/";
                    break;
            }
        }
    }
}
