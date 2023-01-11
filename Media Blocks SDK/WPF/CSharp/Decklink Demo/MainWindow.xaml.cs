using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;

using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.VideoEffects;
using VisioForge.Core.Types.X.AudioEncoders;
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

        private VideoEffectsBlock _videoEffects;

        private MP4SinkBlock _mp4Muxer;

        private H264EncoderBlock _h264Encoder;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private AACEncoderBlock _aacEncoder;

        private DecklinkAudioSinkBlock _decklinkAudioSink;

        private DecklinkVideoSinkBlock _decklinkVideoSink;

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

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var position = await _pipeline.Position_GetAsync();

            Dispatcher.Invoke(() =>
            {
                lbTime.Text = position.ToString("hh\\:mm\\:ss");
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += Pipeline_OnError;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            cbOutputFormat.SelectedIndex = 0;

            var videoCaptureDevices = DecklinkVideoSourceBlock.GetDevices(_pipeline);
            if (videoCaptureDevices.Length > 0)
            {
                foreach (var item in videoCaptureDevices)
                {
                    cbVideoInput.Items.Add(item.Name);
                }

                cbVideoInput.SelectedIndex = 0;
            }

            var audioCaptureDevices = DecklinkAudioSourceBlock.GetDevices(_pipeline);
            if (audioCaptureDevices.Length > 0)
            {
                foreach (var item in audioCaptureDevices)
                {
                    cbAudioInput.Items.Add(item.Name);
                }

                cbAudioInput.SelectedIndex = 0;
            }

            var videoSinkDevices = DecklinkVideoSinkBlock.GetDevices(_pipeline);
            if (videoSinkDevices.Length > 0)
            {
                foreach (var item in videoSinkDevices)
                {
                    cbDecklinkVideoOutput.Items.Add(item.Name);
                }

                cbDecklinkVideoOutput.SelectedIndex = 0;
            }

            var audioSinkDevices = DecklinkAudioSinkBlock.GetDevices(_pipeline);
            if (audioSinkDevices.Length > 0)
            {
                foreach (var item in audioSinkDevices)
                {
                    cbDecklinkAudioOutput.Items.Add(item.Name);
                }

                cbDecklinkAudioOutput.SelectedIndex = 0;
            }

            var audioOutputDevices = AudioRendererBlock.GetDevices(_pipeline);
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

            edFilename.Text = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
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

            await _pipeline?.StopAsync();

            _pipeline?.ClearBlocks();

            VideoView1.CallRefresh();
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

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            bool capture = cbOutputFormat.SelectedIndex > 0;
            bool decklinkOutput = cbDecklinkOutput.IsChecked == true;
            bool tee = capture || decklinkOutput;

            mmLog.Clear();

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show("Select video input device");
                return;
            }

            // video source
            DecklinkVideoSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInput.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = DecklinkVideoSourceBlock.GetDevices(_pipeline).FirstOrDefault(x => x.Name == deviceName);
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
                var device = DecklinkAudioSourceBlock.GetDevices(_pipeline).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    audioSourceSettings = new DecklinkAudioSourceSettings(device);
                }
            }

            _audioSource = new DecklinkAudioSourceBlock(audioSourceSettings);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            // audio renderer
            _audioRenderer = new AudioRendererBlock(cbAudioOutput.Text);

            // effects
            _videoEffects = new VideoEffectsBlock();

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

            _pipeline.Connect(_videoSource.Output, _videoEffects.Input);

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

                _videoTee = new TeeBlock(k);
                _audioTee = new TeeBlock(k);

                _pipeline.Connect(_videoEffects.Output, _videoTee.Input);
                _pipeline.Connect(_videoSource.Output, _videoTee.Input);
                _pipeline.Connect(_audioSource.Output, _audioTee.Input);

                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
                _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
            }

            // capture
            if (capture)
            {
                var h264settings = new MFH264EncoderSettings();

                // GOP size
                h264settings.GOPSize = 25;

                // quality
                h264settings.RCMode = MFH264EncoderRCMode.QVBR;
                h264settings.QP = 15;
                h264settings.QPB = 15;
                h264settings.QPP = 15;
                h264settings.QPI = 15;

                _h264Encoder = new H264EncoderBlock(h264settings);

                _aacEncoder = new AACEncoderBlock(new MFAACEncoderSettings());

                var mp4Settings = new MP4SinkSettings(edFilename.Text);
                _mp4Muxer = new MP4SinkBlock(mp4Settings);

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
                        _pipeline.Connect(_videoResize.Output, _h264Encoder.Input);
                    }
                    else
                    {
                        _pipeline.Connect(_videoTee.Outputs[captureID], _h264Encoder.Input);
                    }      
                        
                    _pipeline.Connect(_h264Encoder.Output, _mp4Muxer.CreateNewInput(MediaBlockPadMediaType.Video));

                    _pipeline.Connect(_audioTee.Outputs[captureID], _aacEncoder.Input);
                    _pipeline.Connect(_aacEncoder.Output, _mp4Muxer.CreateNewInput(MediaBlockPadMediaType.Audio));
                }

                if (decklinkOutput)
                {
                    DecklinkVideoSinkSettings videoSinkSettings = null;

                    deviceName = cbDecklinkVideoOutput.Text;
                    if (!string.IsNullOrEmpty(deviceName))
                    {
                        var device = DecklinkVideoSinkBlock.GetDevices(_pipeline).FirstOrDefault(x => x.Name == deviceName);
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
                        var device = DecklinkAudioSinkBlock.GetDevices(_pipeline).FirstOrDefault(x => x.Name == deviceName);
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
                _pipeline.Connect(_audioSource.Output, _audioRenderer.Input);
                _pipeline.Connect(_videoEffects.Output, _videoRenderer.Input);
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
    }
}
