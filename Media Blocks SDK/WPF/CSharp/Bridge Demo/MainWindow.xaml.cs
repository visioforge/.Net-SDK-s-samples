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
        /// <summary>
        /// The video ID.
        /// </summary>
        private const string VIDEO_ID = "video_pair";

        /// <summary>
        /// The audio ID.
        /// </summary>
        private const string AUDIO_ID = "audio_pair";

        /// <summary>
        /// The pipeline source.
        /// </summary>
        private MediaBlocksPipeline _pipelineSource;

        /// <summary>
        /// The pipeline file output.
        /// </summary>
        private MediaBlocksPipeline _pipelineFileOutput;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The video bridge sink.
        /// </summary>
        private BridgeVideoSinkBlock _videoBridgeSink;

        /// <summary>
        /// The video bridge source.
        /// </summary>
        private BridgeVideoSourceBlock _videoBridgeSource;

        /// <summary>
        /// The audio bridge sink.
        /// </summary>
        private BridgeAudioSinkBlock _audioBridgeSink;

        /// <summary>
        /// The audio bridge source.
        /// </summary>
        private BridgeAudioSourceBlock _audioBridgeSource;

        /// <summary>
        /// The video tee.
        /// </summary>
        private TeeBlock _videoTee;

        /// <summary>
        /// The audio tee.
        /// </summary>
        private TeeBlock _audioTee;

        /// <summary>
        /// The video source.
        /// </summary>
        private VirtualVideoSourceBlock _videoSource;

        /// <summary>
        /// The audio source.
        /// </summary>
        private VirtualAudioSourceBlock _audioSource;

        /// <summary>
        /// The MP4 output.
        /// </summary>
        private MP4OutputBlock _mp4Output;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
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

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            edFilename.Text = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

            await CreateSourceEngineAsync();

            await _pipelineSource.StartAsync();
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Create source engine async.
        /// </summary>
        private async Task CreateSourceEngineAsync()
        {
            _pipelineSource = new MediaBlocksPipeline(name: "SOURCE");
            _pipelineSource.OnError += Pipeline_OnError;
            
            // video
            _videoSource = new VirtualVideoSourceBlock(new VirtualVideoSourceSettings());
            
            var videoInfo = new VideoFrameInfoX(_videoSource.Settings.Width, _videoSource.Settings.Height, _videoSource.Settings.FrameRate);
            _videoBridgeSink = new BridgeVideoSinkBlock(new BridgeVideoSinkSettings(VIDEO_ID, videoInfo));
           
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
            
            _videoRenderer = new VideoRendererBlock(_pipelineSource, VideoView1) { IsSync = false };
            _videoRenderer.IsSync = false;

            _pipelineSource.Connect(_videoSource.Output, _videoTee.Input);
            _pipelineSource.Connect(_videoTee.Outputs[0], _videoBridgeSink.Input);
            _pipelineSource.Connect(_videoTee.Outputs[1], _videoRenderer.Input);

            // audio
            _audioSource = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings());

            var audioInfo = new AudioInfoX(_audioSource.Settings.Format, _audioSource.Settings.SampleRate, _audioSource.Settings.Channels);
            _audioBridgeSink = new BridgeAudioSinkBlock(new BridgeAudioSinkSettings(AUDIO_ID, audioInfo));

            _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);

            _audioRenderer = new AudioRendererBlock() { IsSync = false };

            _pipelineSource.Connect(_audioSource.Output, _audioTee.Input);
            _pipelineSource.Connect(_audioTee.Outputs[0], _audioBridgeSink.Input);
            _pipelineSource.Connect(_audioTee.Outputs[1], _audioRenderer.Input);
        }

        /// <summary>
        /// Create file output engine.
        /// </summary>
        private void CreateFileOutputEngine()
        {
            _pipelineFileOutput = new MediaBlocksPipeline(name: "FILE_OUTPUT");
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

        /// <summary>
        /// Destroy engines async.
        /// </summary>
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

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            CreateFileOutputEngine();

            await _pipelineFileOutput.StartAsync();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (_pipelineFileOutput != null)
            {
                await _pipelineFileOutput.StopAsync();
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEnginesAsync().ConfigureAwait(false);

            VisioForgeX.DestroySDK();
        }
    }
}