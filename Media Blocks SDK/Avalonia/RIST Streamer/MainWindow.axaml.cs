using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

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
using VisioForge.Core.UI.Avalonia;
using System.Diagnostics;

namespace RISTStreamerAMB
{
    public partial class MainWindow : Window, IDisposable
    {
        private bool _initialized;

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private SystemVideoSourceBlock _videoSource;

        private SystemAudioSourceBlock _audioSource;

        private RISTMPEGTSSinkBlock _ristSink;

        private H264EncoderBlock _h264Encoder;

        private AACEncoderBlock _aacEncoder;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private System.Timers.Timer _timer;

        private bool disposedValue;

        public ObservableCollection<string> VideoInputDevices { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> VideoInputFormats { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> VideoInputFrameRates { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioInputDevices { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioInputFormats { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();

            VisioForgeX.InitSDK();

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;
            DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;

            InitControls();

            Activated += MainWindow_Activated;

            DataContext = this;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void InitControls()
        {
            VideoView1 = this.FindControl<VideoView>("VideoView1");

            cbVideoInputDevice = this.FindControl<ComboBox>("cbVideoInputDevice");
            cbVideoInputDevice.SelectionChanged += cbVideoInputDevice_SelectionChanged;
            cbVideoInputDevice.ItemsSource = VideoInputDevices;

            cbVideoInputFormat = this.FindControl<ComboBox>("cbVideoInputFormat");
            cbVideoInputFormat.SelectionChanged += cbVideoInputFormat_SelectionChanged;
            cbVideoInputFormat.ItemsSource = VideoInputFormats;

            cbVideoInputFrameRate = this.FindControl<ComboBox>("cbVideoInputFrameRate");
            cbVideoInputFrameRate.ItemsSource = VideoInputFrameRates;

            cbAudioInputDevice = this.FindControl<ComboBox>("cbAudioInputDevice");
            cbAudioInputDevice.SelectionChanged += cbAudioInputDevice_SelectionChanged;
            cbAudioInputDevice.ItemsSource = AudioInputDevices;

            cbAudioInputFormat = this.FindControl<ComboBox>("cbAudioInputFormat");
            cbAudioInputFormat.ItemsSource = AudioInputFormats;

            edAddress = this.FindControl<TextBox>("edAddress");
            edPort = this.FindControl<TextBox>("edPort");
            edSenderBuffer = this.FindControl<TextBox>("edSenderBuffer");

            lbTime = this.FindControl<TextBlock>("lbTime");
            edLog = this.FindControl<TextBox>("edLog");

            btStart = this.FindControl<Button>("btStart");
            btStart.Click += btStart_Click;

            btStop = this.FindControl<Button>("btStop");
            btStop.Click += btStop_Click;
        }

        private async void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            try
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    VideoInputDevices.Add(e.DisplayName);

                    if (cbVideoInputDevice.Items.Count == 1)
                    {
                        cbVideoInputDevice.SelectedIndex = 0;
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void DeviceEnumerator_OnAudioSourceAdded(object sender, AudioCaptureDeviceInfo e)
        {
            try
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    AudioInputDevices.Add(e.DisplayName);
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void MainWindow_Activated(object sender, EventArgs e)
        {
            try
            {
                if (_initialized)
                {
                    return;
                }

                _initialized = true;

    #if __MACOS__
                AVFoundation.AVCaptureDevice.RequestAccessForMediaType(AVFoundation.AVAuthorizationMediaType.Video, (bool granted) => {
                    System.Diagnostics.Debug.WriteLine($"Camera access: {granted}");
                });
    #endif

                Closing += Window_Closing;

                await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();

                var audioInputs = await DeviceEnumerator.Shared.AudioSourcesAsync();
                foreach (var device in audioInputs)
                {
                    AudioInputDevices.Add(device.DisplayName);
                }

                if (AudioInputDevices.Count > 0)
                {
                    cbAudioInputDevice.SelectedIndex = 0;
                    cbAudioInputDevice_SelectionChanged(null, null);
                }

                _timer = new System.Timers.Timer(500);
                _timer.Elapsed += Timer_Elapsed;

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                var pipeline = _pipeline;
                if (pipeline == null) return;

                try
                {
                    var position = await pipeline.Position_GetAsync();

                    await Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        lbTime.Text = position.ToString("hh\\:mm\\:ss");
                    });
                }
                catch (ObjectDisposedException)
                {
                    // Pipeline was disposed between null check and usage
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            });
        }

        private async void btStart_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                edLog.Text = string.Empty;

                if (cbVideoInputDevice.SelectedIndex < 0)
                {
                    edLog.Text += "Please select a video input device." + Environment.NewLine;
                    return;
                }

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.Dispose();
                    _pipeline = null;
                }

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                bool audioEnabled = cbAudioInputDevice.SelectedIndex >= 0;

                // video source
                VideoCaptureDeviceSourceSettings videoSourceSettings = null;

                var deviceName = cbVideoInputDevice.SelectedItem?.ToString();
                var format = cbVideoInputFormat.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            videoSourceSettings = new VideoCaptureDeviceSourceSettings(device, formatItem.ToFormat());
                            if (cbVideoInputFrameRate.SelectedIndex >= 0)
                            {
                                if (double.TryParse(cbVideoInputFrameRate.SelectedItem?.ToString(), out double frameRate))
                                {
                                    videoSourceSettings.Format.FrameRate = new VideoFrameRate(frameRate);
                                }
                            }
                        }
                    }
                }

                _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

                // audio source
                if (audioEnabled)
                {
                    IAudioCaptureDeviceSourceSettings audioSourceSettings = null;

                    deviceName = cbAudioInputDevice.SelectedItem?.ToString();
                    format = cbAudioInputFormat.SelectedItem?.ToString();
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
                    _audioRenderer = new AudioRendererBlock() { IsSync = false };
                }

                // tees
                _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                _pipeline.Connect(_videoSource, _videoTee);
                _pipeline.Connect(_videoTee, _videoRenderer);

                if (audioEnabled)
                {
                    _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
                    _pipeline.Connect(_audioSource, _audioTee);
                    _pipeline.Connect(_audioTee, _audioRenderer);
                }

                // H264 encoder
                var h264Settings = new OpenH264EncoderSettings() { GOPSize = 30 };
                _h264Encoder = new H264EncoderBlock(h264Settings);
                _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);

                // AAC encoder
                if (audioEnabled)
                {
                    _aacEncoder = new AACEncoderBlock();
                    _pipeline.Connect(_audioTee.Outputs[1], _aacEncoder.Input);
                }

                // RIST sink
                var ristSettings = new RISTSinkSettings()
                {
                    Address = edAddress.Text
                };

                if (uint.TryParse(edPort.Text, out uint port))
                {
                    ristSettings.Port = port;
                }

                if (int.TryParse(edSenderBuffer.Text, out int senderBuffer))
                {
                    ristSettings.SenderBuffer = TimeSpan.FromMilliseconds(senderBuffer);
                }

                _ristSink = new RISTMPEGTSSinkBlock(ristSettings);

                _pipeline.Connect(_h264Encoder.Output, _ristSink.CreateNewInput(MediaBlockPadMediaType.Video));

                if (audioEnabled)
                {
                    _pipeline.Connect(_aacEncoder.Output, _ristSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }

                await _pipeline.StartAsync();

                _timer?.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btStop_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                _timer?.Stop();

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();

                    _pipeline.OnError -= Pipeline_OnError;

                    _pipeline.Dispose();
                    _pipeline = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void cbVideoInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVideoInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
                {
                    VideoInputFormats.Clear();

                    var deviceItem = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                        .FirstOrDefault(device => device.DisplayName == e.AddedItems[0]?.ToString());
                    if (deviceItem == null) return;

                    foreach (var fmt in deviceItem.VideoFormats)
                    {
                        VideoInputFormats.Add(fmt.Name);
                    }

                    if (VideoInputFormats.Count > 0)
                    {
                        cbVideoInputFormat.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void cbVideoInputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                VideoInputFrameRates.Clear();

                if (cbVideoInputDevice.SelectedIndex == -1 || cbVideoInputFormat.SelectedItem == null) return;

                var deviceItem = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                    .FirstOrDefault(device => device.DisplayName == cbVideoInputDevice.SelectedItem?.ToString());
                if (deviceItem == null) return;

                var videoFormat = deviceItem.VideoFormats
                    .FirstOrDefault(format => format.Name == cbVideoInputFormat.SelectedItem?.ToString());
                if (videoFormat == null) return;

                var frameRateList = videoFormat.GetFrameRateRangeAsStringList();
                foreach (var item in frameRateList)
                {
                    VideoInputFrameRates.Add(item);
                }

                if (VideoInputFrameRates.Count > 0)
                {
                    cbVideoInputFrameRate.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void cbAudioInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AudioInputFormats.Clear();

                if (cbAudioInputDevice.SelectedIndex == -1) return;

                var selectedName = cbAudioInputDevice.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedName)) return;

                var deviceItem = (await DeviceEnumerator.Shared.AudioSourcesAsync())
                    .FirstOrDefault(device => device.DisplayName == selectedName);
                if (deviceItem == null) return;

                foreach (var fmt in deviceItem.Formats)
                {
                    AudioInputFormats.Add(fmt.Name);
                }

                if (AudioInputFormats.Count > 0)
                {
                    cbAudioInputFormat.SelectedIndex = 0;
                }
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
                _timer?.Stop();

                DeviceEnumerator.Shared.OnVideoSourceAdded -= DeviceEnumerator_OnVideoSourceAdded;
                DeviceEnumerator.Shared.OnAudioSourceAdded -= DeviceEnumerator_OnAudioSourceAdded;

                if (_pipeline != null)
                {
                    _pipeline.OnError -= Pipeline_OnError;

                    await _pipeline.StopAsync();
                    _pipeline.Dispose();
                    _pipeline = null;
                }

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _timer?.Dispose();
                    _timer = null;

                    if (_pipeline != null)
                    {
                        _pipeline.OnError -= Pipeline_OnError;
                        _pipeline.Dispose();
                        _pipeline = null;
                    }

                    VideoView1?.Dispose();
                    VideoView1 = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
