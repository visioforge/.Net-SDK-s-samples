using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.Helpers;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioProcessing;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Decklink;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.VideoEffects;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Decklink;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.VideoEncoders;

namespace Decklink_MB_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private VideoResizeBlock _videoResize;

        private DecklinkVideoSourceBlock _videoSource;

        private DecklinkAudioSourceBlock _audioSource;

        private VideoEffectsWinBlock _videoEffects;

        private MediaBlock _muxer;

        private MediaBlock _videoEncoder;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private MediaBlock _audioEncoder;

        private DecklinkAudioSinkBlock _decklinkAudioSink;

        private DecklinkVideoSinkBlock _decklinkVideoSink;

        private UniversalSourceBlock _fileSource;

        private System.Timers.Timer _timer;

        private bool _started;

        public MainWindow()
        {
            InitializeComponent();           

            _videoEffects = new VideoEffectsWinBlock();
        }

        private void CreatePipeline(bool live)
        {
            _started = false;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStart += Pipeline_OnStart;
            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        private void Pipeline_OnStart(object sender, EventArgs e)
        {
            _started = true;
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_pipeline != null)
            {
                var position = await _pipeline.Position_GetAsync();

                Dispatcher.Invoke(() =>
                {
                    lbTime.Text = position.ToString("hh\\:mm\\:ss");
                });
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            cbOutputFormat.SelectedIndex = 0;

            var videoCaptureDevices = await DecklinkVideoSourceBlock.GetDevicesAsync();
            if (videoCaptureDevices.Length > 0)
            {
                foreach (var item in videoCaptureDevices)
                {
                    cbVideoInput.Items.Add(item.Name);
                }

                cbVideoInput.SelectedIndex = 0;
            }

            var audioCaptureDevices = await DecklinkAudioSourceBlock.GetDevicesAsync();
            if (audioCaptureDevices.Length > 0)
            {
                foreach (var item in audioCaptureDevices)
                {
                    cbAudioInput.Items.Add(item.Name);
                }

                cbAudioInput.SelectedIndex = 0;
            }

            var videoSinkDevices = await DecklinkVideoSinkBlock.GetDevicesAsync();
            if (videoSinkDevices.Length > 0)
            {
                foreach (var item in videoSinkDevices)
                {
                    cbDecklinkVideoOutput.Items.Add(item.Name);
                }

                cbDecklinkVideoOutput.SelectedIndex = 0;
            }

            var audioSinkDevices = await DecklinkAudioSinkBlock.GetDevicesAsync();
            if (audioSinkDevices.Length > 0)
            {
                foreach (var item in audioSinkDevices)
                {
                    cbDecklinkAudioOutput.Items.Add(item.Name);
                }

                cbDecklinkAudioOutput.SelectedIndex = 0;
            }

            var audioOutputDevices = (await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound)).ToArray();
            if (audioOutputDevices.Length > 0)
            {
                foreach (var item in audioOutputDevices)
                {
                    cbAudioOutput.Items.Add(item);
                }

                cbAudioOutput.SelectedIndex = 0;
            }

            var decklinkModes = Enum.GetValues(typeof(DecklinkMode));
            foreach (var item in decklinkModes)
            {
                cbVideoMode.Items.Add(item.ToString());
            }

            cbVideoMode.SelectedIndex = 0;

            edFilename.Text = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

            DeviceEnumerator.Shared.OnDecklinkSignalLost += DeviceEnumerator_OnDecklinkSignalLost;
        }

        private void DeviceEnumerator_OnDecklinkSignalLost(object sender, EventArgs e)
        {
            if (!_started)
            {
                return;
            }

            Dispatcher.Invoke(() =>
            {
                mmLog.Text = mmLog.Text + "Decklink signal lost." + Environment.NewLine;
            });
        }

        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume.Value / 100.0;
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                _pipeline.ClearBlocks();
            }

            VideoView1.CallRefresh();

            _videoEffects?.Dispose();
            _videoEffects = new VideoEffectsWinBlock();

            AddVideoEffects();
        }

        private void AddTextLogo()
        {
            var textOverlay = new VideoEffectTextLogo(true);
            textOverlay.Left = 50;
            textOverlay.Top = 50;
            _videoEffects.Video_Effects_Add(textOverlay);
        }

        private void RemoveTextLogo()
        {
            _videoEffects.Video_Effects_Remove("TextLogo");
        }

        private void AddScrollingTextLogo()
        {
            var textOverlay = new VideoEffectScrollingTextLogo(true);
            textOverlay.Left = 50;
            textOverlay.Top = 50;
            _videoEffects.Video_Effects_Add(textOverlay);
        }

        private void RemoveScrollingTextLogo()
        {
            _videoEffects.Video_Effects_Remove("ScrollingTextLogo");
        }

        private void AddImageLogo()
        {
            var imageOverlay = new VideoEffectImageLogo(true);
            imageOverlay.Filename = System.IO.Path.Combine(Environment.CurrentDirectory, "logo.png");
            imageOverlay.Left = 50;
            imageOverlay.Top = 150;
            _videoEffects.Video_Effects_Add(imageOverlay);
        }

        private void RemoveImageLogo()
        {
            _videoEffects.Video_Effects_Remove("ImageLogo");
        }

        private void CreateMP4Output()
        {
            _videoEncoder = new H264EncoderBlock();

            _audioEncoder = new AACEncoderBlock();

            var mp4Settings = new MP4SinkSettings(edFilename.Text);
            _muxer = new MP4SinkBlock(mp4Settings);

            (_muxer as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Video);
            (_muxer as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio);
        }

        private void CreateWebMOutput()
        {
            var vpxSettings = new VP8EncoderSettings();
            _videoEncoder = new VPXEncoderBlock(vpxSettings);

            _audioEncoder = new VorbisEncoderBlock(new VorbisEncoderSettings());

            var webMSettings = new WebMSinkSettings(edFilename.Text);
            _muxer = new WebMSinkBlock(webMSettings);

            (_muxer as WebMSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video);
            (_muxer as WebMSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio);
        }

        private void CreateMPEG2Output()
        {
            var videoSettings = new MPEG2VideoEncoderSettings();
            videoSettings.Bitrate = 15_000;
            _videoEncoder = new MPEG2EncoderBlock(videoSettings);

            _audioEncoder = new MP2EncoderBlock(new MP2EncoderSettings());

            var muxSettings = new MPEGTSSinkSettings(edFilename.Text);
            _muxer = new MPEGTSSinkBlock(muxSettings);

            (_muxer as MPEGTSSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video);
            (_muxer as MPEGTSSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio);
        }


        private void CreateMXFOutput()
        {
            var decklinkFormat = (DecklinkMode)Enum.Parse(typeof(DecklinkMode), cbVideoMode.Text);
            DecklinkHelper.GetVideoInfoFromMode(decklinkFormat, out var width, out var height, out var frameRate);

            var format = DNxHDEncoderSettings.GetFormatByResolution(width, height);

            var dnxSettings = new DNxHDEncoderSettings(format);
            _videoEncoder = new DNxHDEncoderBlock(dnxSettings);

            _audioEncoder = new AudioConverterBlock();

            var mxfSettings = new MXFSinkSettings(edFilename.Text, MXFVideoStreamType.DNxHD, MXFAudioStreamType.Uncompressed);
            _muxer = new MXFSinkBlock(mxfSettings);

            (_muxer as MXFSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video);
            (_muxer as MXFSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio);
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            CreatePipeline(rbCaptureDeviceSource.IsChecked == true);
      
            bool capture = cbOutputFormat.SelectedIndex > 0;
            if (capture)
            {
                var decklinkFormat = (DecklinkMode)Enum.Parse(typeof(DecklinkMode), cbVideoMode.Text);
                if (decklinkFormat == DecklinkMode.Unknown)
                {
                    MessageBox.Show(this, "Decklink mode must be set to a specific value if you want to capture to the output file.");
                    return;
                }
            }

            bool decklinkOutput = cbDecklinkOutput.IsChecked == true;
            bool tee = capture || decklinkOutput;

            mmLog.Clear();

            MediaBlockPad videoSourcePad = null;
            MediaBlockPad audioSourcePad = null;

            if (rbCaptureDeviceSource.IsChecked == true)
            {
                if (cbVideoInput.SelectedIndex < 0)
                {
                    MessageBox.Show(this, "Select video input device");
                    return;
                }

                // video source
                DecklinkVideoSourceSettings videoSourceSettings = null;

                var deviceName = cbVideoInput.Text;
                if (!string.IsNullOrEmpty(deviceName))
                {
                    var device = (await DecklinkVideoSourceBlock.GetDevicesAsync()).FirstOrDefault(x => x.Name == deviceName);
                    if (device != null)
                    {
                        videoSourceSettings = new DecklinkVideoSourceSettings(device);
                        videoSourceSettings.Mode = (DecklinkMode)Enum.Parse(typeof(DecklinkMode), cbVideoMode.Text);
                    }
                }

                _videoSource = new DecklinkVideoSourceBlock(videoSourceSettings);

                // audio source
                DecklinkAudioSourceSettings audioSourceSettings = null;

                deviceName = cbAudioInput.Text;
                if (!string.IsNullOrEmpty(deviceName))
                {
                    var device = (await DecklinkAudioSourceBlock.GetDevicesAsync()).FirstOrDefault(x => x.Name == deviceName);
                    if (device != null)
                    {
                        audioSourceSettings = new DecklinkAudioSourceSettings(device);
                    }
                }

                _audioSource = new DecklinkAudioSourceBlock(audioSourceSettings);

                videoSourcePad = _videoSource.Output;
                audioSourcePad = _audioSource.Output;
            }
            else
            {
                // file source
                //edSourceFilename.Text = @"c:\Projects\_Projects\CustomDevelopment\HRC_REC\test_24bit_audio.mkv";
                _fileSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(edSourceFilename.Text));

                videoSourcePad = _fileSource.VideoOutput;
                audioSourcePad = _fileSource.AudioOutput;
            }

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

            // audio renderer
            _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).Where(device => device.DisplayName == cbAudioOutput.Text).First()) { IsSync = false };

            // effects
            AddVideoEffects();

            _pipeline.Connect(videoSourcePad, _videoEffects.Input);

            // tees
            int captureID = -1;
            int decklinkOutputID = -1;
            if (capture || decklinkOutput)
            {
                int k = 1;
                if (capture)
                {
                    captureID = k;
                    k++;
                }

                if (decklinkOutput)
                {
                    decklinkOutputID = k;
                    k++;
                }

                _videoTee = new TeeBlock(k, MediaBlockPadMediaType.Video);
                _audioTee = new TeeBlock(k, MediaBlockPadMediaType.Audio);

                _pipeline.Connect(_videoEffects.Output, _videoTee.Input);
                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

                _pipeline.Connect(audioSourcePad, _audioTee.Input);
                _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
            }

            // capture
            if (capture)
            {
                switch (cbOutputFormat.SelectedIndex)
                {
                    case 1:
                        CreateMP4Output();
                        break;
                    case 2:
                        CreateWebMOutput();
                        break;
                    case 3:
                        CreateMXFOutput();
                        break;
                    case 4:
                        CreateMPEG2Output();
                        break;
                    default:
                        break;
                }

                if (cbResizeVideo.IsChecked == true)
                {
                    _videoResize = new VideoResizeBlock(new ResizeVideoEffect(Convert.ToInt32(edResizeWidth.Text), Convert.ToInt32(edResizeHeight.Text)));
                }
            }

            // connect all
            if (tee)
            {
                if (capture)
                {
                    if (cbResizeVideo.IsChecked == true)
                    {
                        _pipeline.Connect(_videoTee.Outputs[captureID], _videoResize.Input);
                        _pipeline.Connect(_videoResize.Output, _videoEncoder.Input);
                    }
                    else
                    {
                        _pipeline.Connect(_videoTee.Outputs[captureID], _videoEncoder.Input);
                    }      
                        
                    _pipeline.Connect(_videoEncoder.Output, _muxer.GetInputPadByType(MediaBlockPadMediaType.Video));

                    _pipeline.Connect(_audioTee.Outputs[captureID], _audioEncoder.Input);
                    _pipeline.Connect(_audioEncoder.Output, _muxer.GetInputPadByType(MediaBlockPadMediaType.Audio));
                }

                if (decklinkOutput)
                {
                    DecklinkVideoSinkSettings videoSinkSettings = null;

                    var deviceName = cbDecklinkVideoOutput.Text;
                    if (!string.IsNullOrEmpty(deviceName))
                    {
                        var device = (await DecklinkVideoSinkBlock.GetDevicesAsync()).FirstOrDefault(x => x.Name == deviceName);
                        if (device != null)
                        {
                            videoSinkSettings = new DecklinkVideoSinkSettings(device);
                            videoSinkSettings.Mode = (DecklinkMode)Enum.Parse(typeof(DecklinkMode), cbVideoMode.Text);
                        }
                    }

                    _decklinkVideoSink = new DecklinkVideoSinkBlock(videoSinkSettings);

                    DecklinkAudioSinkSettings audioSinkSettings = null;

                    deviceName = cbDecklinkAudioOutput.Text;
                    if (!string.IsNullOrEmpty(deviceName))
                    {
                        var device = (await DecklinkAudioSinkBlock.GetDevicesAsync()).FirstOrDefault(x => x.Name == deviceName);
                        if (device != null)
                        {
                            audioSinkSettings = new DecklinkAudioSinkSettings(device);
                        }
                    }

                    _decklinkAudioSink = new DecklinkAudioSinkBlock(audioSinkSettings);

                    _pipeline.Connect(_videoTee.Outputs[decklinkOutputID], _decklinkVideoSink.Input);
                    _pipeline.Connect(_audioTee.Outputs[decklinkOutputID], _decklinkAudioSink.Input);
                }
            }
            else
            {
                _pipeline.Connect(audioSourcePad, _audioRenderer.Input);
                _pipeline.Connect(_videoEffects.Output, _videoRenderer.Input);
            }

            // start
            await _pipeline.StartAsync();

            _timer.Start();
        }

        private void AddVideoEffects()
        {
            if (cbAddTextOverlay.IsChecked == true)
            {
                AddTextLogo();
            }

            if (cbAddScrollingTextOverlay.IsChecked == true)
            {
                AddScrollingTextLogo();
            }

            if (cbAddImageOverlay.IsChecked == true)
            {
                AddImageLogo();
            }
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

            VideoView1.CallRefresh();   
            
            VisioForgeX.DestroySDK();
        }

        private void cbAddTextOverlay_Checked(object sender, RoutedEventArgs e)
        {
            AddTextLogo();
        }

        private void cbAddTextOverlay_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveTextLogo();
        }

        private void cbAddImageOverlay_Checked(object sender, RoutedEventArgs e)
        {
            AddImageLogo();
        }

        private void cbAddImageOverlay_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveImageLogo();
        }

        private void cbAddScrollingTextOverlay_Checked(object sender, RoutedEventArgs e)
        {
            AddScrollingTextLogo();
        }

        private void cbAddScrollingTextOverlay_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveScrollingTextLogo();
        }

        private void btSelectSourceFile_Click(object sender, RoutedEventArgs e)
        {
            // select source file
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                edSourceFilename.Text = dialog.FileName;
            }
        }
    }
}
