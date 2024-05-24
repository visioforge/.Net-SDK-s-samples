using System.Windows;

using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;
using System;
using System.Threading.Tasks;
using Microsoft.Win32;
using VisioForge.Core.MediaBlocks.Bridge;
using VisioForge.Core.Types.X.Bridge;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types.X;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using System.Diagnostics;

namespace Bridge_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string VIDEO_ID = "video_pair";

        private const string AUDIO_ID = "audio_pair";

        private MediaBlocksPipeline _pipelineSource;

        private MediaBlocksPipeline _pipelineFileOutput;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private BridgeVideoSinkBlock _videoBridgeSink;

        private BridgeVideoSourceBlock _videoBridgeSource;

        private BridgeAudioSinkBlock _audioBridgeSink;

        private BridgeAudioSourceBlock _audioBridgeSource;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private VirtualVideoSourceBlock _videoSource;

        private VirtualAudioSourceBlock _audioSource;

        private MP4OutputBlock _mp4Output;

        public MainWindow()
        {
            InitializeComponent();

            // We have to initialize the engine on start
            VisioForgeX.InitSDK();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            edFilename.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\output.mp4";

            await CreateSourceEngineAsync();

            await _pipelineSource.StartAsync();
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private async Task CreateSourceEngineAsync()
        {
            _pipelineSource = new MediaBlocksPipeline(false, name: "SOURCE");
            _pipelineSource.OnError += Pipeline_OnError;
            
            // video
            _videoSource = new VirtualVideoSourceBlock(new VirtualVideoSourceSettings());
            
            var videoInfo = new VideoFrameInfoX(_videoSource.Settings.Width, _videoSource.Settings.Height, _videoSource.Settings.FrameRate);
            _videoBridgeSink = new BridgeVideoSinkBlock(new BridgeVideoSinkSettings(VIDEO_ID, videoInfo));
           
            _videoTee = new TeeBlock(2);
            
            _videoRenderer = new VideoRendererBlock(_pipelineSource, VideoView1);
            
            _pipelineSource.Connect(_videoSource.Output, _videoTee.Input);
            _pipelineSource.Connect(_videoTee.Outputs[0], _videoBridgeSink.Input);
            _pipelineSource.Connect(_videoTee.Outputs[1], _videoRenderer.Input);

            // audio
            _audioSource = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings());

            var audioInfo = new AudioInfoX(_audioSource.Settings.Format, _audioSource.Settings.SampleRate, _audioSource.Settings.Channels);
            _audioBridgeSink = new BridgeAudioSinkBlock(new BridgeAudioSinkSettings(AUDIO_ID, audioInfo));

            _audioTee = new TeeBlock(2);

            _audioRenderer = new AudioRendererBlock();

            _pipelineSource.Connect(_audioSource.Output, _audioTee.Input);
            _pipelineSource.Connect(_audioTee.Outputs[0], _audioBridgeSink.Input);
            _pipelineSource.Connect(_audioTee.Outputs[1], _audioRenderer.Input);
        }

        private void CreateFileOutputEngine()
        {
            _pipelineFileOutput = new MediaBlocksPipeline(true, name: "FILE_OUTPUT");
            _pipelineFileOutput.OnError += Pipeline_OnError;
            
            // video bridge source
            var videoInfo = new VideoFrameInfoX(_videoSource.Settings.Width, _videoSource.Settings.Height, _videoSource.Settings.FrameRate);
            _videoBridgeSource = new BridgeVideoSourceBlock(new BridgeVideoSourceSettings(VIDEO_ID, videoInfo));

            // audio bridge source
            var audioInfo = new AudioInfoX(_audioSource.Settings.Format, _audioSource.Settings.SampleRate, _audioSource.Settings.Channels);
            _audioBridgeSource = new BridgeAudioSourceBlock(new BridgeAudioSourceSettings(AUDIO_ID, audioInfo));

            // encoder
            _mp4Output = new MP4OutputBlock(new MP4SinkSettings(edFilename.Text), H264EncoderBlock.GetDefaultSettings(), AACEncoderBlock.GetDefaultSettings());

            _pipelineFileOutput.Connect(_videoBridgeSource.Output, _mp4Output.CreateNewInput(MediaBlockPadMediaType.Video));
            _pipelineFileOutput.Connect(_audioBridgeSource.Output, _mp4Output.CreateNewInput(MediaBlockPadMediaType.Audio));
        }

        private async Task DestroyEnginesAsync()
        {
            if (_pipelineSource != null)
            {
                await _pipelineSource.StopAsync();
                
                _pipelineSource.OnError -= Pipeline_OnError;
                await _pipelineSource.DisposeAsync();
                _pipelineSource = null;
            }

            if (_pipelineFileOutput != null)
            {
                _pipelineFileOutput.OnError -= Pipeline_OnError;
                await _pipelineFileOutput.DisposeAsync();
                _pipelineFileOutput = null;
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            CreateFileOutputEngine();

            await _pipelineFileOutput.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (_pipelineFileOutput != null)
            {
                await _pipelineFileOutput.StopAsync();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEnginesAsync().ConfigureAwait(false);

            VisioForgeX.DestroySDK();
        }
    }
}