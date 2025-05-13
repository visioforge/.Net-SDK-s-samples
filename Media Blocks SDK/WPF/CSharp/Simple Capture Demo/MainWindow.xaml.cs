using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;

namespace MediaBlocks_Simple_Video_Capture_Demo_WPF
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

        private MediaBlock _muxer;

        private MediaBlock _videoEncoder;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private MediaBlock _audioEncoder;

        private System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DeviceEnumerator_OnAudioSinkAdded(object sender, AudioOutputDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioOutput.Items.Add(e.DisplayName);

                if (cbAudioOutput.Items.Count == 1)
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

                if (cbAudioInput.Items.Count == 1)
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

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
            await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();
            await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();

            edFilename.Text = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            bool capture = cbOutputFormat.SelectedIndex > 0;

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

            // audio source
            IAudioCaptureDeviceSourceSettings audioSourceSettings = null;

            deviceName = cbAudioInput.Text;
            format = cbAudioFormat.Text;
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

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

            // audio renderer
            _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == cbAudioOutput.Text).First()) { IsSync = false };

            // capture
            if (capture)
            {
                _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);

                switch (cbOutputFormat.SelectedIndex)
                {
                    case 1: // MP4
                        _muxer = new MP4SinkBlock(new MP4SinkSettings(edFilename.Text));
                        _videoEncoder = new H264EncoderBlock();
                        _audioEncoder = new AACEncoderBlock();
                        break;
                    case 2: // MPEG-TS
                        _muxer = new MPEGTSSinkBlock(new MPEGTSSinkSettings(edFilename.Text));
                        _videoEncoder = new H264EncoderBlock();
                        _audioEncoder = new AACEncoderBlock();
                        break;
                    case 3: // WebM
                        _muxer = new WebMSinkBlock(new WebMSinkSettings(edFilename.Text));
                        _videoEncoder = new VPXEncoderBlock(new VP8EncoderSettings());
                        _audioEncoder = new VorbisEncoderBlock(new VorbisEncoderSettings());
                        break;
                    default:
                        break;
                }
            }

            // connect all
            if (capture)
            {
                _pipeline.Connect(_videoSource.Output, _videoTee.Input);
                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
                _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);
                _pipeline.Connect(_videoEncoder.Output, (_muxer as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Video));

                _pipeline.Connect(_audioSource.Output, _audioTee.Input);
                _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
                _pipeline.Connect(_audioTee.Outputs[1], _audioEncoder.Input);
                _pipeline.Connect(_audioEncoder.Output, (_muxer as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Audio));
            }
            else
            {
                _pipeline.Connect(_audioSource.Output, _audioRenderer.Input);
                _pipeline.Connect(_videoSource.Output, _videoRenderer.Input);
            }
            
            // start
            await _pipeline.StartAsync();

            _timer.Start();
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "MP4 files (*.mp4)|*.mp4|WebM files (*.webm)|*.mp4|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            await _pipeline?.StopAsync();

            _pipeline?.ClearBlocks();

            VideoView1.CallRefresh();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.PauseAsync();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var position = await _pipeline.Position_GetAsync();

            Dispatcher.Invoke(() =>
            {
                lbTime.Text = position.ToString("hh\\:mm\\:ss");
            });           
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

        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume.Value / 100.0;
            }
        }
    }
}
