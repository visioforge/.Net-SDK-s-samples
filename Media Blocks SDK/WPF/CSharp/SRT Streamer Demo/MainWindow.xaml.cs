using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using VisioForge.Core;
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
using System.Diagnostics;

namespace SRT_Streamer_Demo
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

        private SRTMPEGTSSinkBlock _srtSink;

        private H264EncoderBlock _h264Encoder;

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
            try
            {
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                this.IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

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

        private SRTSinkSettings BuildSrtSettings()
        {
            var settings = new SRTSinkSettings
            {
                Uri = edSrtUri.Text,
                AutoReconnect = cbAutoReconnect.IsChecked == true,
                WaitForConnection = cbWaitForConnection.IsChecked == true
            };

            // Mode
            switch (cbSrtMode.SelectedIndex)
            {
                case 0:
                    settings.Mode = SRTConnectionMode.Caller;
                    break;
                case 1:
                    settings.Mode = SRTConnectionMode.Listener;
                    break;
                case 2:
                    settings.Mode = SRTConnectionMode.Rendezvous;
                    break;
            }

            // Latency
            if (int.TryParse(edSrtLatency.Text, out int latency))
            {
                settings.Latency = TimeSpan.FromMilliseconds(latency);
            }

            // Muxer latency
            if (int.TryParse(edMuxerLatency.Text, out int muxerLatency))
            {
                settings.MuxerLatency = TimeSpan.FromMilliseconds(muxerLatency);
            }

            // Encryption
            if (!string.IsNullOrWhiteSpace(edPassphrase.Text))
            {
                settings.Passphrase = edPassphrase.Text;

                switch (cbKeyLength.SelectedIndex)
                {
                    case 0:
                        settings.PbKeyLen = SRTKeyLength.NoKey;
                        break;
                    case 1:
                        settings.PbKeyLen = SRTKeyLength.Length16;
                        break;
                    case 2:
                        settings.PbKeyLen = SRTKeyLength.Length24;
                        break;
                    case 3:
                        settings.PbKeyLen = SRTKeyLength.Length32;
                        break;
                }
            }

            return settings;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mmLog.Clear();

                if (rbCameraSource.IsChecked == true && cbVideoInput.SelectedIndex < 0)
                {
                    MessageBox.Show(this, "Select video input device");
                    return;
                }

                bool audioEnabled = cbAudioInput.SelectedIndex > 0;

                // video source
                if (rbCameraSource.IsChecked == true)
                {
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
                    var screenSourceSettings = new ScreenCaptureD3D11SourceSettings() { Rectangle = new VisioForge.Core.Types.Rect(0, 0, 640, 480) };
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

                // tees
                _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

                if (audioEnabled)
                {
                    _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
                }

                // connect video source -> tee -> renderer
                _pipeline.Connect(_videoSource.Output, _videoTee.Input);
                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

                if (audioEnabled)
                {
                    _pipeline.Connect(_audioSource.Output, _audioTee.Input);
                    _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
                }

                // H264 encoder
                var h264Settings = new OpenH264EncoderSettings() { GOPSize = 10 };
                _h264Encoder = new H264EncoderBlock(h264Settings);
                _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);

                // AAC encoder
                if (audioEnabled)
                {
                    _aacEncoder = new AACEncoderBlock(new MFAACEncoderSettings());
                    _pipeline.Connect(_audioTee.Outputs[1], _aacEncoder.Input);
                }

                // SRT sink
                var srtSettings = BuildSrtSettings();
                _srtSink = new SRTMPEGTSSinkBlock(srtSettings);

                _pipeline.Connect(_h264Encoder.Output, _srtSink.CreateNewInput(MediaBlockPadMediaType.Video));

                if (audioEnabled)
                {
                    _pipeline.Connect(_aacEncoder.Output, _srtSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }

                // start
                await _pipeline.StartAsync();

                _timer.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                mmLog.Text += ex.Message + Environment.NewLine;
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _timer.Stop();

                await _pipeline?.StopAsync();

                _pipeline?.ClearBlocks();

                VideoView1.CallRefresh();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

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

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

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
                        var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                        if (device != null)
                        {
                            var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                            if (formatItem != null)
                            {
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

        private async void cbAudioInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
