using System;
using System.Linq;

using System.Windows;
using System.Windows.Controls;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;

namespace Social_Networks_Streamer_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private SystemVideoSourceBlock _videoSource;

        private SystemAudioSourceBlock _audioSource;

        private YouTubeSinkBlock _youtubeSink;
        
        private FacebookLiveSinkBlock _facebookSink;

        private HTTPMJPEGLiveSinkBlock _mjpegSink;

        private H264EncoderBlock _h264Encoder;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private AACEncoderBlock _aacEncoder;

        private System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();

            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += Pipeline_OnError;
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += Pipeline_OnError;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            var videoCaptureDevices = SystemVideoSourceBlock.GetDevices();
            if (videoCaptureDevices.Length > 0)
            {
                foreach (var item in videoCaptureDevices)
                {
                    cbVideoInput.Items.Add(item.Name);
                }

                cbVideoInput.SelectedIndex = 0;
            }

            var audioCaptureDevices = SystemAudioSourceBlock.GetDevices();
            if (audioCaptureDevices.Length > 0)
            {
                foreach (var item in audioCaptureDevices)
                {
                    cbAudioInput.Items.Add(item.Name);
                }

                cbAudioInput.SelectedIndex = 0;
            }
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
                MessageBox.Show("Select video input device");
                return;
            }

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInput.Text;
            var format = cbVideoFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = SystemVideoSourceBlock.GetDevices().FirstOrDefault(x => x.Name == deviceName);
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
            DSAudioCaptureDeviceSourceSettings audioSourceSettings = null;

            deviceName = cbAudioInput.Text;
            format = cbAudioFormat.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = SystemAudioSourceBlock.GetDevices().FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        audioSourceSettings = new DSAudioCaptureDeviceSourceSettings(device, formatItem.ToFormat());
                    }
                }
            }

            _audioSource = new SystemAudioSourceBlock(audioSourceSettings);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            // audio renderer
            _audioRenderer = new AudioRendererBlock();

            // capture
            _videoTee = new TeeBlock(2);
            _audioTee = new TeeBlock(2);

            // connect inputs
            _pipeline.Connect(_videoSource.Output, _videoTee.Input);
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
            
            _pipeline.Connect(_audioSource.Output, _audioTee.Input);
            _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);

            if (cbPlatform.SelectedIndex == 0 || cbPlatform.SelectedIndex == 1)
            {
                // H264/AAC encoders
                var h264Settings = new OpenH264EncoderSettings();
                _h264Encoder = new H264EncoderBlock(h264Settings);
                _aacEncoder = new AACEncoderBlock(new MFAACEncoderSettings());

                _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);
                _pipeline.Connect(_audioTee.Outputs[1], _aacEncoder.Input);
                
                // YouTube
                if (cbPlatform.SelectedIndex == 0)
                {
                    _youtubeSink = new YouTubeSinkBlock(new YouTubeSinkSettings(edStreamingKey.Text));
                    _pipeline.Connect(_h264Encoder.Output, _youtubeSink.CreateNewInput(MediaBlockPadMediaType.Video));
                    _pipeline.Connect(_aacEncoder.Output, _youtubeSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
                // Facebook Live
                else if (cbPlatform.SelectedIndex == 1)
                {
                    _facebookSink = new FacebookLiveSinkBlock(new FacebookLiveSinkSettings(edStreamingKey.Text));
                    _pipeline.Connect(_h264Encoder.Output, _facebookSink.CreateNewInput(MediaBlockPadMediaType.Video));
                    _pipeline.Connect(_aacEncoder.Output, _facebookSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
            }
            // MJPEG
            else
            {
                _mjpegSink = new HTTPMJPEGLiveSinkBlock(8090);
                _pipeline.Connect(_videoTee.Outputs[1], _mjpegSink.Input);
                edStreamingKey.Text = "IMG tag URL is http://127.0.0.1:8090";
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btStop_Click(null, null);

            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;

                _pipeline.Dispose();
                _pipeline = null;
            }
        }

        private void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                var deviceName = (string)e.AddedItems[0];

                if (!string.IsNullOrEmpty(deviceName))
                {
                    cbVideoFormat.Items.Clear();

                    var device = SystemVideoSourceBlock.GetDevices().FirstOrDefault(x => x.Name == deviceName);
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

        private void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbVideoFrameRate.Items.Clear();

            if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                var deviceName = cbVideoInput.SelectedValue.ToString();
                var format = (string)e.AddedItems[0];
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = SystemVideoSourceBlock.GetDevices().FirstOrDefault(x => x.Name == deviceName);
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

        private void cbAudioInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAudioInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                var deviceName = (string)e.AddedItems[0];
                if (!string.IsNullOrEmpty(deviceName))
                {
                    cbAudioFormat.Items.Clear();

                    var device = SystemAudioSourceBlock.GetDevices().FirstOrDefault(x => x.Name == deviceName);
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
