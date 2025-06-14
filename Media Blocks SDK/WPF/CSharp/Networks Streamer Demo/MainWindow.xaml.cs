using System;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.AWS;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;

namespace Networks_Streamer_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private MediaBlock _videoSource;

        private SystemAudioSourceBlock _audioSource;

        private YouTubeSinkBlock _youtubeSink;
        
        private FacebookLiveSinkBlock _facebookSink;

        private AWSS3SinkBlock _awsS3Sink;

        private MP4SinkBlock _mp4Sink;

        private HTTPMJPEGLiveSinkBlock _mjpegSink;

        private HLSSinkBlock _hlsSink;

        private SRTMPEGTSSinkBlock _srtSink;

        private RTSPServerBlock _rtspSink;

        private H264EncoderBlock _h264Encoder;

        private NDISinkBlock _ndiSink;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private AACEncoderBlock _aacEncoder;

        private System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DeviceEnumerator_OnAudioSourceAdded(object sender, AudioCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioInput.Items.Add(e.DisplayName);
            });
        }

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

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;
            DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            cbAudioInput.Items.Add("None");
            cbAudioInput.SelectedIndex = 0;

            await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
            await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var position = await _pipeline.Position_GetAsync();

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

            bool audioEnabled = cbAudioInput.SelectedIndex > 0;

            // video source
            if (rbCameraSource.IsChecked == true)
            {
                // camera source
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
            }
            else
            {
                // screen source
                var screenSourceSettings = new ScreenCaptureD3D11SourceSettings() { Rectangle = new VisioForge.Core.Types.Rect(0, 0 , 640, 480) };   
                _videoSource = new ScreenSourceBlock(screenSourceSettings);                
            }

            // audio source
            if (audioEnabled)
            {
                IAudioCaptureDeviceSourceSettings audioSourceSettings = null;

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
                            audioSourceSettings = device.CreateSourceSettings(formatItem.ToFormat());
                        }
                    }
                }

                _audioSource = new SystemAudioSourceBlock(audioSourceSettings);
            }

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

            // audio renderer
            if (audioEnabled)
            {
                _audioRenderer = new AudioRendererBlock() { IsSync = false };
            }

            // capture
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            if (audioEnabled)
            {
                _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
            }

            // connect inputs
            _pipeline.Connect(_videoSource.Output, _videoTee.Input);
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

            if (audioEnabled)
            {
                _pipeline.Connect(_audioSource.Output, _audioTee.Input);
                _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
            }

            // MJPEG
            if (cbPlatform.SelectedIndex == 3)
            {
                _mjpegSink = new HTTPMJPEGLiveSinkBlock(8090);
                _pipeline.Connect(_videoTee.Outputs[1], _mjpegSink.Input);
                edStreamingKey.Text = "IMG tag URL is http://127.0.0.1:8090";
            }
            // NDI
            else if (cbPlatform.SelectedIndex == 6)
            {
                _ndiSink = new NDISinkBlock(edStreamingKey.Text);
                _pipeline.Connect(_videoTee.Outputs[1], _ndiSink.CreateNewInput(MediaBlockPadMediaType.Video));

                if (audioEnabled)
                {
                    _pipeline.Connect(_audioTee.Outputs[1], _ndiSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
            }
            // RTSP
            else if (cbPlatform.SelectedIndex == 7)
            {
                IVideoEncoder videoEncoder = new OpenH264EncoderSettings();
                IAudioEncoder audioEncoder = null;
                if (audioEnabled)
                {
                    audioEncoder = new VOAACEncoderSettings();
                }

                _rtspSink = new RTSPServerBlock(new RTSPServerSettings(new Uri("rtsp://127.0.0.1/live"), videoEncoder, audioEncoder));
                _pipeline.Connect(_videoTee.Outputs[1], _rtspSink.VideoInput);

                if (audioEnabled)
                {
                    _pipeline.Connect(_audioTee.Outputs[1], _rtspSink.AudioInput);
                }
            }
            // Streaming with H264/AAC encoders
            else
            {
                // Create H264 encoder
                var h264Settings = new OpenH264EncoderSettings() { GOPSize = 10 };
                _h264Encoder = new H264EncoderBlock(h264Settings);

                if (audioEnabled)
                {
                    // Create AAC encoder
                    _aacEncoder = new AACEncoderBlock(new MFAACEncoderSettings());
                }

                _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);

                if (audioEnabled)
                {
                    _pipeline.Connect(_audioTee.Outputs[1], _aacEncoder.Input);
                }

                // YouTube
                if (cbPlatform.SelectedIndex == 0)
                {
                    _youtubeSink = new YouTubeSinkBlock(new YouTubeSinkSettings(edStreamingKey.Text));
                    _pipeline.Connect(_h264Encoder.Output, _youtubeSink.CreateNewInput(MediaBlockPadMediaType.Video));

                    if (audioEnabled)
                    {
                        _pipeline.Connect(_aacEncoder.Output, _youtubeSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                    }
                }
                // Facebook Live
                else if (cbPlatform.SelectedIndex == 1)
                {
                    _facebookSink = new FacebookLiveSinkBlock(new FacebookLiveSinkSettings(edStreamingKey.Text));
                    _pipeline.Connect(_h264Encoder.Output, _facebookSink.CreateNewInput(MediaBlockPadMediaType.Video));

                    if (audioEnabled)
                    {
                        _pipeline.Connect(_aacEncoder.Output, _facebookSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                    }
                }
                // HLS
                else if (cbPlatform.SelectedIndex == 2)
                {
                    const string URL = "http://localhost:8088/";
                    string serverPath = AppContext.BaseDirectory;
                    var hlsSettings = new HLSSinkSettings
                    {
                        Location = Path.Combine(serverPath, "segment_%05d.ts"),
                        MaxFiles = 10,
                        PlaylistLength = 5,
                        PlaylistLocation = Path.Combine(serverPath, "playlist.m3u8"),
                        PlaylistRoot = URL,
                        SendKeyframeRequests = true,
                        TargetDuration = 5,
                        Custom_HTTP_Server_Enabled = true,
                        Custom_HTTP_Server_Port = 8088
                    };

                    _hlsSink = new HLSSinkBlock(hlsSettings);
                    _pipeline.Connect(_h264Encoder.Output, _hlsSink.CreateNewInput(MediaBlockPadMediaType.Video));

                    if (audioEnabled)
                    {
                        _pipeline.Connect(_aacEncoder.Output, _hlsSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                    }

                    MessageBox.Show($"Open {URL} in your browser to see HLS stream. Open {URL}playlist.m3u8 in VLC or other player.");
                }
                // AWS S3
                else if (cbPlatform.SelectedIndex == 4)
                {
                    // mux into MP4 stream
                    var mp4Settings = new MP4SinkSettings() { MuxOnly = true };
                    _mp4Sink = new MP4SinkBlock(mp4Settings);

                    _pipeline.Connect(_h264Encoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video));

                    if (audioEnabled)
                    {
                        _pipeline.Connect(_aacEncoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Audio));
                    }

                    // S3 sink
                    var s3settings = new AWSS3SinkSettings();
                    s3settings.Region = "us-west-2";
                    s3settings.ContentType = "video/mp4";
                    s3settings.Uri = "s3://us-west-2/my-bucket-name/output.mp4";

                    s3settings.AccessKey = "#####";
                    s3settings.SecretAccessKey = "#####";

                    _awsS3Sink = new AWSS3SinkBlock(s3settings);

                    // connect
                    _pipeline.Connect(_mp4Sink.Output, _awsS3Sink.Input);
                }
                // SRT
                else if (cbPlatform.SelectedIndex == 5)
                {                    
                    _srtSink = new SRTMPEGTSSinkBlock(new SRTSinkSettings() { Uri = "srt://:8888" });
                    _h264Encoder.Settings.ParseStream = false; // we have to disable parsing for SRT for H264 and HEVC encoders
                    _pipeline.Connect(_h264Encoder.Output, _srtSink.CreateNewInput(MediaBlockPadMediaType.Video));

                    if (audioEnabled)
                    {
                        _pipeline.Connect(_aacEncoder.Output, _srtSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                    }
                }
            }            

            // start
            await _pipeline.StartAsync();

            _timer.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            await _pipeline?.StopAsync();

            _pipeline?.ClearBlocks();

            VideoView1.CallRefresh();
        }

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

        private async void cbAudioInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbAudioFormat.Items.Clear();

            if (cbAudioInput.SelectedIndex > 0 && e != null && e.AddedItems.Count > 0)
            {
                var deviceName = (string)e.AddedItems[0];
                if (!string.IsNullOrEmpty(deviceName))
                {
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
                    edStreamingKey.Text = "HLS URL";
                    break;
                case 3:
                    edStreamingKey.Text = "";
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
                    edStreamingKey.Text = "rtsp://127.0.0.1:7777/live";
                    break;
            }
        }
    }
}
