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
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The video resize block.
        /// </summary>
        private VideoResizeBlock _videoResize;

        /// <summary>
        /// The decklink video source.
        /// </summary>
        private DecklinkVideoSourceBlock _videoSource;

        /// <summary>
        /// The decklink audio source.
        /// </summary>
        private DecklinkAudioSourceBlock _audioSource;

        /// <summary>
        /// The video effects block.
        /// </summary>
        private VideoEffectsWinBlock _videoEffects;

        /// <summary>
        /// The muxer.
        /// </summary>
        private MediaBlock _muxer;

        /// <summary>
        /// The video encoder.
        /// </summary>
        private MediaBlock _videoEncoder;

        /// <summary>
        /// The video tee.
        /// </summary>
        private TeeBlock _videoTee;

        /// <summary>
        /// The audio tee.
        /// </summary>
        private TeeBlock _audioTee;

        /// <summary>
        /// The audio encoder.
        /// </summary>
        private MediaBlock _audioEncoder;

        /// <summary>
        /// The decklink audio sink.
        /// </summary>
        private DecklinkAudioSinkBlock _decklinkAudioSink;

        /// <summary>
        /// The decklink video sink.
        /// </summary>
        private DecklinkVideoSinkBlock _decklinkVideoSink;

        /// <summary>
        /// The decklink output resize.
        /// </summary>
        private VideoResizeBlock _decklinkOutputResize;

        /// <summary>
        /// The decklink output frame rate.
        /// </summary>
        private VideoRateBlock _decklinkOutputFrameRate;

        /// <summary>
        /// The file source.
        /// </summary>
        private UniversalSourceBlock _fileSource;

        /// <summary>
        /// The timer.
        /// </summary>
        private System.Timers.Timer _timer;

        /// <summary>
        /// The started flag.
        /// </summary>
        private bool _started;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            _videoEffects = new VideoEffectsWinBlock();
        }

        /// <summary>
        /// Create pipeline.
        /// </summary>
        private void CreatePipeline(bool live)
        {
            _started = false;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStart += Pipeline_OnStart;
            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        /// <summary>
        /// Handles the pipeline on start event.
        /// </summary>
        private void Pipeline_OnStart(object sender, EventArgs e)
        {
            _started = true;
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
        /// Timer elapsed.
        /// </summary>
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
                cbDecklinkOutputMode.Items.Add(item.ToString());
            }

            cbVideoMode.SelectedIndex = 0;
            cbDecklinkOutputMode.SelectedIndex = 0;

            edFilename.Text = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

            DeviceEnumerator.Shared.OnDecklinkSignalLost += DeviceEnumerator_OnDecklinkSignalLost;
        }

        /// <summary>
        /// Handles the device enumerator on decklink signal lost event.
        /// </summary>
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

        /// <summary>
        /// Tb volume value changed.
        /// </summary>
        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume.Value / 100.0;
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
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

        /// <summary>
        /// Add text logo.
        /// </summary>
        private void AddTextLogo()
        {
            var textOverlay = new VideoEffectTextLogo(true);
            textOverlay.Left = 50;
            textOverlay.Top = 50;
            _videoEffects.Video_Effects_Add(textOverlay);
        }

        /// <summary>
        /// Remove text logo.
        /// </summary>
        private void RemoveTextLogo()
        {
            _videoEffects.Video_Effects_Remove("TextLogo");
        }

        /// <summary>
        /// Add scrolling text logo.
        /// </summary>
        private void AddScrollingTextLogo()
        {
            var textOverlay = new VideoEffectScrollingTextLogo(true);
            textOverlay.Left = 50;
            textOverlay.Top = 50;
            _videoEffects.Video_Effects_Add(textOverlay);
        }

        /// <summary>
        /// Remove scrolling text logo.
        /// </summary>
        private void RemoveScrollingTextLogo()
        {
            _videoEffects.Video_Effects_Remove("ScrollingTextLogo");
        }

        /// <summary>
        /// Add image logo.
        /// </summary>
        private void AddImageLogo()
        {
            var imageOverlay = new VideoEffectImageLogo(true);
            imageOverlay.Filename = System.IO.Path.Combine(Environment.CurrentDirectory, "logo.png");
            imageOverlay.Left = 50;
            imageOverlay.Top = 150;
            _videoEffects.Video_Effects_Add(imageOverlay);
        }

        /// <summary>
        /// Remove image logo.
        /// </summary>
        private void RemoveImageLogo()
        {
            _videoEffects.Video_Effects_Remove("ImageLogo");
        }

        /// <summary>
        /// Create mp 4 output.
        /// </summary>
        private void CreateMP4Output()
        {
            _videoEncoder = new H264EncoderBlock();

            _audioEncoder = new AACEncoderBlock();

            var mp4Settings = new MP4SinkSettings(edFilename.Text);
            _muxer = new MP4SinkBlock(mp4Settings);

            (_muxer as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Video);
            (_muxer as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio);
        }

        /// <summary>
        /// Create web m output.
        /// </summary>
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

        /// <summary>
        /// Create mpeg 2 output.
        /// </summary>
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


        /// <summary>
        /// Create mxf output.
        /// </summary>
        private void CreateMXFOutput()
        {
            var decklinkFormat = (DecklinkMode)Enum.Parse(typeof(DecklinkMode), cbVideoMode.Text);
            DecklinkHelper.GetVideoInfoFromMode(decklinkFormat, out var width, out var height, out var frameRate);

            _videoEncoder = new H264EncoderBlock();

            _audioEncoder = new AudioConverterBlock();

            var mxfSettings = new MXFSinkSettings(edFilename.Text, MXFVideoStreamType.DNxHD, MXFAudioStreamType.Uncompressed);
            _muxer = new MXFSinkBlock(mxfSettings);

            (_muxer as MXFSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video);
            (_muxer as MXFSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio);
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
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
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            // audio renderer
            _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).Where(device => device.DisplayName == cbAudioOutput.Text).First());

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

                    // Determine the output mode - use custom mode if enabled, otherwise use input mode
                    DecklinkMode outputMode;
                    bool useCustomFormat = cbDecklinkOutputCustomFormat.IsChecked == true;
                    if (useCustomFormat)
                    {
                        outputMode = (DecklinkMode)Enum.Parse(typeof(DecklinkMode), cbDecklinkOutputMode.Text);
                    }
                    else
                    {
                        outputMode = (DecklinkMode)Enum.Parse(typeof(DecklinkMode), cbVideoMode.Text);
                    }

                    var deviceName = cbDecklinkVideoOutput.Text;
                    if (!string.IsNullOrEmpty(deviceName))
                    {
                        var device = (await DecklinkVideoSinkBlock.GetDevicesAsync()).FirstOrDefault(x => x.Name == deviceName);
                        if (device != null)
                        {
                            videoSinkSettings = new DecklinkVideoSinkSettings(device, outputMode);
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

                    // Get output format info for custom format conversion
                    if (useCustomFormat && outputMode != DecklinkMode.Unknown)
                    {
                        DecklinkHelper.GetVideoInfoFromMode(outputMode, out var outputWidth, out var outputHeight, out var outputFrameRate);

                        // Create resize and frame rate blocks for format conversion
                        _decklinkOutputResize = new VideoResizeBlock(new ResizeVideoEffect(outputWidth, outputHeight));
                        _decklinkOutputFrameRate = new VideoRateBlock(outputFrameRate);

                        // Connect: tee -> resize -> framerate -> decklink sink
                        _pipeline.Connect(_videoTee.Outputs[decklinkOutputID], _decklinkOutputResize.Input);
                        _pipeline.Connect(_decklinkOutputResize.Output, _decklinkOutputFrameRate.Input);
                        _pipeline.Connect(_decklinkOutputFrameRate.Output, _decklinkVideoSink.Input);
                    }
                    else
                    {
                        _pipeline.Connect(_videoTee.Outputs[decklinkOutputID], _decklinkVideoSink.Input);
                    }

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

        /// <summary>
        /// Add video effects.
        /// </summary>
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

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "MP4 files (*.mp4)|*.mp4|WebM files (*.webm)|*.mp4|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
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

        /// <summary>
        /// Cb add text overlay checked.
        /// </summary>
        private void cbAddTextOverlay_Checked(object sender, RoutedEventArgs e)
        {
            AddTextLogo();
        }

        /// <summary>
        /// Cb add text overlay unchecked.
        /// </summary>
        private void cbAddTextOverlay_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveTextLogo();
        }

        /// <summary>
        /// Cb add image overlay checked.
        /// </summary>
        private void cbAddImageOverlay_Checked(object sender, RoutedEventArgs e)
        {
            AddImageLogo();
        }

        /// <summary>
        /// Cb add image overlay unchecked.
        /// </summary>
        private void cbAddImageOverlay_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveImageLogo();
        }

        /// <summary>
        /// Cb add scrolling text overlay checked.
        /// </summary>
        private void cbAddScrollingTextOverlay_Checked(object sender, RoutedEventArgs e)
        {
            AddScrollingTextLogo();
        }

        /// <summary>
        /// Cb add scrolling text overlay unchecked.
        /// </summary>
        private void cbAddScrollingTextOverlay_Unchecked(object sender, RoutedEventArgs e)
        {
            RemoveScrollingTextLogo();
        }

        /// <summary>
        /// Handles the bt select source file click event.
        /// </summary>
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
