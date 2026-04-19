using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.AWS;
using VisioForge.Core.MediaBlocks.Bridge;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Bridge;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;

namespace Networks_Streamer_Demo_with_Bridge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string VIDEO_BRIDGE_ID = "networks_video_bridge";
        private const string AUDIO_BRIDGE_ID = "networks_audio_bridge";

        private MediaBlocksPipeline _pipelinePreview;
        private MediaBlocksPipeline _pipelineStreaming;

        private VideoRendererBlock _videoRenderer;
        private AudioRendererBlock _audioRenderer;

        private SystemVideoSourceBlock _videoSource;
        private SystemAudioSourceBlock _audioSource;

        private BridgeVideoSinkBlock _videoBridgeSink;
        private BridgeAudioSinkBlock _audioBridgeSink;

        private BridgeVideoSourceBlock _videoBridgeSource;
        private BridgeAudioSourceBlock _audioBridgeSource;

        private TeeBlock _videoTee;
        private TeeBlock _audioTee;

        private H264EncoderBlock _h264Encoder;
        private AACEncoderBlock _aacEncoder;
        private OPUSEncoderBlock _opusEncoder;

        private YouTubeSinkBlock _youtubeSink;
        private FacebookLiveSinkBlock _facebookSink;
        private AWSS3SinkBlock _awsS3Sink;
        private MP4SinkBlock _mp4Sink;
        private HTTPMJPEGLiveSinkBlock _mjpegSink;
        private HLSSinkBlock _hlsSink;
        private SRTMPEGTSSinkBlock _srtSink;
        private RTSPServerBlock _rtspSink;
        private WHIPSinkBlock _whipSink;
        private NDISinkBlock _ndiSink;

        private System.Timers.Timer _timer;

        private bool _isPreviewRunning = false;
        private bool _isStreamingRunning = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Device enumerator on audio source added.
        /// </summary>
        private void DeviceEnumerator_OnAudioSourceAdded(object sender, AudioCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioInput.Items.Add(e.DisplayName);
            });
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
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;
            DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            cbAudioInput.Items.Add("None");
            cbAudioInput.SelectedIndex = 0;

            await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
            await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();
        }

        /// <summary>
        /// Timer elapsed.
        /// </summary>
        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_pipelinePreview != null)
            {
                var position = await _pipelinePreview.Position_GetAsync();

                Dispatcher.Invoke(() =>
                {
                    lbTime.Content = position.ToString("hh\\:mm\\:ss");
                });
            }
        }

        /// <summary>
        /// Creates the preview pipeline with bridge sinks.
        /// </summary>
        private async System.Threading.Tasks.Task CreatePreviewPipelineAsync()
        {
            _pipelinePreview = new MediaBlocksPipeline(name: "PREVIEW");
            _pipelinePreview.OnError += Pipeline_OnError;

            bool audioEnabled = cbAudioInput.SelectedIndex > 0;

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

            // audio source
            if (audioEnabled)
            {
                IAudioCaptureDeviceSourceSettings audioSourceSettings = null;

                var audioDeviceName = cbAudioInput.Text;
                var audioFormat = cbAudioFormat.Text;
                if (!string.IsNullOrEmpty(audioDeviceName))
                {
                    var audioDevice = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == audioDeviceName);
                    if (audioDevice != null)
                    {
                        var audioFormatItem = audioDevice.Formats.FirstOrDefault(x => x.Name == audioFormat);
                        if (audioFormatItem != null)
                        {
                            audioSourceSettings = audioDevice.CreateSourceSettings(audioFormatItem.ToFormat());
                        }
                    }
                }

                _audioSource = new SystemAudioSourceBlock(audioSourceSettings);
            }

            // video tee for splitting signal
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipelinePreview, VideoView1) { IsSync = false };

            // video bridge sink
            var videoInfo = new VideoFrameInfoX(videoSourceSettings.Format.Width, videoSourceSettings.Format.Height, videoSourceSettings.Format.FrameRate);
            _videoBridgeSink = new BridgeVideoSinkBlock(new BridgeVideoSinkSettings(VIDEO_BRIDGE_ID, videoInfo));

            // connect video
            _pipelinePreview.Connect(_videoSource.Output, _videoTee.Input);
            _pipelinePreview.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
            _pipelinePreview.Connect(_videoTee.Outputs[1], _videoBridgeSink.Input);

            // audio
            if (audioEnabled)
            {
                _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
                _audioRenderer = new AudioRendererBlock() { IsSync = false };

                var audioInfo = new AudioInfoX(_audioSource.Settings.Format.Format, _audioSource.Settings.Format.SampleRate, _audioSource.Settings.Format.Channels);
                _audioBridgeSink = new BridgeAudioSinkBlock(new BridgeAudioSinkSettings(AUDIO_BRIDGE_ID, audioInfo));

                _pipelinePreview.Connect(_audioSource.Output, _audioTee.Input);
                _pipelinePreview.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
                _pipelinePreview.Connect(_audioTee.Outputs[1], _audioBridgeSink.Input);
            }
        }

        /// <summary>
        /// Handles the bt start click event - starts preview pipeline.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select video input device");
                return;
            }

            await CreatePreviewPipelineAsync();
            await _pipelinePreview.StartAsync();

            _isPreviewRunning = true;
            UpdateUI();

            _timer.Start();
        }

        /// <summary>
        /// Creates the streaming pipeline using bridge sources.
        /// </summary>
        private void CreateStreamingPipeline()
        {
            _pipelineStreaming = new MediaBlocksPipeline(name: "STREAMING");
            _pipelineStreaming.OnError += Pipeline_OnError;

            bool audioEnabled = cbAudioInput.SelectedIndex > 0;

            // video bridge source
            var videoSourceSettings = _videoSource.Settings as VideoCaptureDeviceSourceSettings;
            var videoInfo = new VideoFrameInfoX(videoSourceSettings.Format.Width, videoSourceSettings.Format.Height, videoSourceSettings.Format.FrameRate);
            _videoBridgeSource = new BridgeVideoSourceBlock(new BridgeVideoSourceSettings(VIDEO_BRIDGE_ID, videoInfo));

            // MJPEG
            if (cbPlatform.SelectedIndex == 3)
            {
                _mjpegSink = new HTTPMJPEGLiveSinkBlock(8090);
                _pipelineStreaming.Connect(_videoBridgeSource.Output, _mjpegSink.Input);
            }
            // NDI
            else if (cbPlatform.SelectedIndex == 6)
            {
                _ndiSink = new NDISinkBlock(edStreamingKey.Text);
                _pipelineStreaming.Connect(_videoBridgeSource.Output, _ndiSink.CreateNewInput(MediaBlockPadMediaType.Video));

                if (audioEnabled)
                {
                    var audioInfo = new AudioInfoX(_audioSource.Settings.Format.Format, _audioSource.Settings.Format.SampleRate, _audioSource.Settings.Format.Channels);
                    _audioBridgeSource = new BridgeAudioSourceBlock(new BridgeAudioSourceSettings(AUDIO_BRIDGE_ID, audioInfo));
                    _pipelineStreaming.Connect(_audioBridgeSource.Output, _ndiSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
            }
            // RTSP
            else if (cbPlatform.SelectedIndex == 7)
            {
                IVideoEncoder videoEncoder = new OpenH264EncoderSettings();
                IAudioEncoder audioEncoder = null;
                if (audioEnabled)
                {
                    audioEncoder = new AVENCAACEncoderSettings();
                }

                _rtspSink = new RTSPServerBlock(new RTSPServerSettings(new Uri("rtsp://127.0.0.1/live"), videoEncoder, audioEncoder));
                _pipelineStreaming.Connect(_videoBridgeSource.Output, _rtspSink.VideoInput);

                if (audioEnabled)
                {
                    var audioInfo = new AudioInfoX(_audioSource.Settings.Format.Format, _audioSource.Settings.Format.SampleRate, _audioSource.Settings.Format.Channels);
                    _audioBridgeSource = new BridgeAudioSourceBlock(new BridgeAudioSourceSettings(AUDIO_BRIDGE_ID, audioInfo));
                    _pipelineStreaming.Connect(_audioBridgeSource.Output, _rtspSink.AudioInput);
                }
            }
            // WebRTC WHIP (requires H264 + Opus)
            else if (cbPlatform.SelectedIndex == 8)
            {
                var h264Settings = new OpenH264EncoderSettings() { GOPSize = 10, ParseStream = false };
                _h264Encoder = new H264EncoderBlock(h264Settings);
                _pipelineStreaming.Connect(_videoBridgeSource.Output, _h264Encoder.Input);

                var whipSettings = new WHIPSinkSettings()
                {
                    Location = edStreamingKey.Text
                };

                _whipSink = new WHIPSinkBlock(whipSettings);
                _pipelineStreaming.Connect(_h264Encoder.Output, _whipSink.CreateNewInput(MediaBlockPadMediaType.Video));

                if (audioEnabled)
                {
                    var audioInfo = new AudioInfoX(_audioSource.Settings.Format.Format, _audioSource.Settings.Format.SampleRate, _audioSource.Settings.Format.Channels);
                    _audioBridgeSource = new BridgeAudioSourceBlock(new BridgeAudioSourceSettings(AUDIO_BRIDGE_ID, audioInfo));

                    _opusEncoder = new OPUSEncoderBlock(new OPUSEncoderSettings());
                    _pipelineStreaming.Connect(_audioBridgeSource.Output, _opusEncoder.Input);
                    _pipelineStreaming.Connect(_opusEncoder.Output, _whipSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
            }
            // Streaming with H264/AAC encoders (YouTube, Facebook, HLS, AWS S3, SRT)
            else
            {
                // Create H264 encoder
                var h264Settings = new OpenH264EncoderSettings() { GOPSize = 10 };
                _h264Encoder = new H264EncoderBlock(h264Settings);

                _pipelineStreaming.Connect(_videoBridgeSource.Output, _h264Encoder.Input);

                if (audioEnabled)
                {
                    var audioInfo = new AudioInfoX(_audioSource.Settings.Format.Format, _audioSource.Settings.Format.SampleRate, _audioSource.Settings.Format.Channels);
                    _audioBridgeSource = new BridgeAudioSourceBlock(new BridgeAudioSourceSettings(AUDIO_BRIDGE_ID, audioInfo));

                    // Create AAC encoder
                    _aacEncoder = new AACEncoderBlock(new MFAACEncoderSettings());
                    _pipelineStreaming.Connect(_audioBridgeSource.Output, _aacEncoder.Input);
                }

                // YouTube
                if (cbPlatform.SelectedIndex == 0)
                {
                    _youtubeSink = new YouTubeSinkBlock(new YouTubeSinkSettings(edStreamingKey.Text));
                    _pipelineStreaming.Connect(_h264Encoder.Output, _youtubeSink.CreateNewInput(MediaBlockPadMediaType.Video));

                    if (audioEnabled)
                    {
                        _pipelineStreaming.Connect(_aacEncoder.Output, _youtubeSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                    }
                }
                // Facebook Live
                else if (cbPlatform.SelectedIndex == 1)
                {
                    _facebookSink = new FacebookLiveSinkBlock(new FacebookLiveSinkSettings(edStreamingKey.Text));
                    _pipelineStreaming.Connect(_h264Encoder.Output, _facebookSink.CreateNewInput(MediaBlockPadMediaType.Video));

                    if (audioEnabled)
                    {
                        _pipelineStreaming.Connect(_aacEncoder.Output, _facebookSink.CreateNewInput(MediaBlockPadMediaType.Audio));
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
                        TargetDuration = TimeSpan.FromSeconds(5),
                        Custom_HTTP_Server_Enabled = true,
                        Custom_HTTP_Server_Port = 8088
                    };

                    _hlsSink = new HLSSinkBlock(hlsSettings);
                    _pipelineStreaming.Connect(_h264Encoder.Output, _hlsSink.CreateNewInput(MediaBlockPadMediaType.Video));

                    if (audioEnabled)
                    {
                        _pipelineStreaming.Connect(_aacEncoder.Output, _hlsSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                    }

                    MessageBox.Show($"Open {URL} in your browser to see HLS stream. Open {URL}playlist.m3u8 in VLC or other player.");
                }
                // AWS S3
                else if (cbPlatform.SelectedIndex == 4)
                {
                    // mux into MP4 stream
                    var mp4Settings = new MP4SinkSettings() { MuxOnly = true };
                    _mp4Sink = new MP4SinkBlock(mp4Settings);

                    _pipelineStreaming.Connect(_h264Encoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video));

                    if (audioEnabled)
                    {
                        _pipelineStreaming.Connect(_aacEncoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Audio));
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
                    _pipelineStreaming.Connect(_mp4Sink.Output, _awsS3Sink.Input);
                }
                // SRT
                else if (cbPlatform.SelectedIndex == 5)
                {
                    _srtSink = new SRTMPEGTSSinkBlock(new SRTSinkSettings() { Uri = "srt://:8888" });
                    _h264Encoder.Settings.ParseStream = false; // we have to disable parsing for SRT for H264 and HEVC encoders
                    _pipelineStreaming.Connect(_h264Encoder.Output, _srtSink.CreateNewInput(MediaBlockPadMediaType.Video));

                    if (audioEnabled)
                    {
                        _pipelineStreaming.Connect(_aacEncoder.Output, _srtSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                    }
                }
            }
        }

        /// <summary>
        /// Handles the bt start streaming click event.
        /// </summary>
        private async void btStartStreaming_Click(object sender, RoutedEventArgs e)
        {
            CreateStreamingPipeline();
            await _pipelineStreaming.StartAsync();

            _isStreamingRunning = true;
            UpdateUI();
        }

        /// <summary>
        /// Handles the bt stop streaming click event.
        /// </summary>
        private async void btStopStreaming_Click(object sender, RoutedEventArgs e)
        {
            await StopStreamingAsync();
        }

        private async System.Threading.Tasks.Task StopStreamingAsync()
        {
            if (_pipelineStreaming != null)
            {
                await _pipelineStreaming.StopAsync();
                _pipelineStreaming.OnError -= Pipeline_OnError;
                await _pipelineStreaming.DisposeAsync();
                _pipelineStreaming = null;
            }

            _isStreamingRunning = false;
            UpdateUI();
        }

        /// <summary>
        /// Handles the bt stop click event - stops preview pipeline.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_isStreamingRunning)
            {
                await StopStreamingAsync();
            }

            if (_pipelinePreview != null)
            {
                await _pipelinePreview.StopAsync();
                _pipelinePreview.OnError -= Pipeline_OnError;
                await _pipelinePreview.DisposeAsync();
                _pipelinePreview = null;
            }

            _isPreviewRunning = false;
            UpdateUI();

            VideoView1.CallRefresh();
        }

        /// <summary>
        /// Update UI state.
        /// </summary>
        private void UpdateUI()
        {
            btStart.IsEnabled = !_isPreviewRunning;
            btStop.IsEnabled = _isPreviewRunning;
            btStartStreaming.IsEnabled = _isPreviewRunning && !_isStreamingRunning;
            btStopStreaming.IsEnabled = _isStreamingRunning;

            cbVideoInput.IsEnabled = !_isPreviewRunning;
            cbVideoFormat.IsEnabled = !_isPreviewRunning;
            cbVideoFrameRate.IsEnabled = !_isPreviewRunning;
            cbAudioInput.IsEnabled = !_isPreviewRunning;
            cbAudioFormat.IsEnabled = !_isPreviewRunning;

            if (!_isPreviewRunning && !_isStreamingRunning)
            {
                lbStatus.Content = "Not started";
            }
            else if (_isPreviewRunning && !_isStreamingRunning)
            {
                lbStatus.Content = "Preview running";
            }
            else if (_isPreviewRunning && _isStreamingRunning)
            {
                lbStatus.Content = "Preview + Streaming";
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer?.Stop();

            if (_pipelineStreaming != null)
            {
                await _pipelineStreaming.StopAsync();
                _pipelineStreaming.OnError -= Pipeline_OnError;
                await _pipelineStreaming.DisposeAsync();
                _pipelineStreaming = null;
            }

            if (_pipelinePreview != null)
            {
                await _pipelinePreview.StopAsync();
                _pipelinePreview.OnError -= Pipeline_OnError;
                await _pipelinePreview.DisposeAsync();
                _pipelinePreview = null;
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

        /// <summary>
        /// Cb audio input selection changed.
        /// </summary>
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

        /// <summary>
        /// Cb platform selection changed.
        /// </summary>
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
                case 8:
                    edStreamingKey.Text = "http://localhost:8889/stream/whip";
                    break;
            }
        }
    }
}
