using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core;
using System.Diagnostics;
using VisioForge.Core.Types.Events;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Bridge;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.Bridge;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Output;
using System.Threading.Tasks;

namespace Bridge_Source_Switch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string VIDEO_ID = "video_pair";

        private const int VIDEO_WIDTH = 1280;

        private const int VIDEO_HEIGHT = 720;

        private readonly VideoFrameRate VIDEO_FRAME_RATE = VideoFrameRate.FPS_25;


        private const string AUDIO_ID = "audio_pair";

        private const int AUDIO_CHANNELS = 2;

        private const int AUDIO_SAMPLE_RATE = 44100;

        private const AudioFormatX AUDIO_FORMAT = AudioFormatX.S16LE;


        private MediaBlocksPipeline _pipelineSource1;

        private VirtualVideoSourceBlock _videoSource1;

        private BridgeVideoSinkBlock _videoBridgeSink1;

        private VirtualAudioSourceBlock _audioSource1;

        private BridgeAudioSinkBlock _audioBridgeSink1;


        private MediaBlocksPipeline _pipelineSource2;

        private VirtualVideoSourceBlock _videoSource2;

        private BridgeVideoSinkBlock _videoBridgeSink2;

        private VirtualAudioSourceBlock _audioSource2;

        private BridgeAudioSinkBlock _audioBridgeSink2;


        private MediaBlocksPipeline _pipelineMain;

        private VideoRendererBlock _videoRenderer;

        private BridgeVideoSourceBlock _videoBridgeSource;

        private MediaBlock _audioRenderer;

        private BridgeAudioSourceBlock _audioBridgeSource;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            var audioOutputs = await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound);
            foreach (var audioOutput in audioOutputs)
            {
                cbAudioOutput.Items.Add(audioOutput.Name);
            }

            if (audioOutputs.Length > 0)
            {
                cbAudioOutput.SelectedIndex = 0;
            }
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private void AddSources()
        {
            // Source 1
            _pipelineSource1 = new MediaBlocksPipeline("pipeline-src1");
            _pipelineSource1.OnError += Pipeline_OnError;

            _videoSource1 = new VirtualVideoSourceBlock(VIDEO_WIDTH, VIDEO_HEIGHT, VIDEO_FRAME_RATE);
            _videoBridgeSink1 = new BridgeVideoSinkBlock(
                new BridgeVideoSinkSettings(VIDEO_ID, new VideoFrameInfoX(VIDEO_WIDTH, VIDEO_HEIGHT, VIDEO_FRAME_RATE)));
            _pipelineSource1.Connect(_videoSource1, _videoBridgeSink1);

            _audioSource1 = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings(AUDIO_SAMPLE_RATE, AUDIO_CHANNELS, AUDIO_FORMAT));
            _audioBridgeSink1 = new BridgeAudioSinkBlock(
                new BridgeAudioSinkSettings(AUDIO_ID, new AudioInfoX(AUDIO_FORMAT, AUDIO_SAMPLE_RATE, AUDIO_CHANNELS)));
            _pipelineSource1.Connect(_audioSource1, _audioBridgeSink1);

            // Source 2
            _pipelineSource2 = new MediaBlocksPipeline("pipeline-src2");
            _pipelineSource2.OnError += Pipeline_OnError;
            _videoSource2 = new VirtualVideoSourceBlock(VIDEO_WIDTH, VIDEO_HEIGHT, VIDEO_FRAME_RATE);
            _videoSource2.Settings.Pattern = VisioForge.Core.Types.X.Sources.VirtualVideoSourcePattern.Ball;
            _videoBridgeSink2 = new BridgeVideoSinkBlock(
                new BridgeVideoSinkSettings(VIDEO_ID, new VideoFrameInfoX(VIDEO_WIDTH, VIDEO_HEIGHT, VIDEO_FRAME_RATE)));
            _pipelineSource2.Connect(_videoSource2, _videoBridgeSink2);

            _audioSource2 = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings(AUDIO_SAMPLE_RATE, AUDIO_CHANNELS, AUDIO_FORMAT));
            _audioSource2.Settings.Wave = VirtualAudioSourceSettingsWave.Ticks;
            _audioBridgeSink2 = new BridgeAudioSinkBlock(
                new BridgeAudioSinkSettings(AUDIO_ID, new AudioInfoX(AUDIO_FORMAT, AUDIO_SAMPLE_RATE, AUDIO_CHANNELS)));
            _pipelineSource2.Connect(_audioSource2, _audioBridgeSink2);
        }

        private async Task AddMainPipelineAsync()
        {
            _pipelineMain = new MediaBlocksPipeline("pipeline-main");
            _pipelineMain.OnError += Pipeline_OnError;
            _videoBridgeSource = new BridgeVideoSourceBlock(
                new BridgeVideoSourceSettings(VIDEO_ID, new VideoFrameInfoX(VIDEO_WIDTH, VIDEO_HEIGHT, VIDEO_FRAME_RATE)));
            _videoRenderer = new VideoRendererBlock(_pipelineMain, VideoView1) { IsSync = false };
            _pipelineMain.Connect(_videoBridgeSource, _videoRenderer);

            _audioBridgeSource = new BridgeAudioSourceBlock(
                new BridgeAudioSourceSettings(AUDIO_ID, new AudioInfoX(AUDIO_FORMAT, AUDIO_SAMPLE_RATE, AUDIO_CHANNELS)));
            var audioOutputs = await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound);
            var audioOutputDevice = audioOutputs[cbAudioOutput.SelectedIndex];
            _audioRenderer = new AudioRendererBlock(audioOutputDevice);
            _pipelineMain.Connect(_audioBridgeSource, _audioRenderer);
        }

        private async Task DestroyEnginesAsync()
        {
            if (_pipelineSource1 != null)
            {
                await _pipelineSource1.StopAsync();

                _pipelineSource1.OnError -= Pipeline_OnError;
                await _pipelineSource1.DisposeAsync();
                _pipelineSource1 = null;
            }

            if (_pipelineSource2 != null)
            {
                await _pipelineSource2.StopAsync();

                _pipelineSource2.OnError -= Pipeline_OnError;
                await _pipelineSource2.DisposeAsync();
                _pipelineSource2 = null;
            }

            if (_pipelineMain != null)
            {
                await _pipelineMain.StopAsync();

                _pipelineMain.OnError -= Pipeline_OnError;
                await _pipelineMain.DisposeAsync();
                _pipelineMain = null;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEnginesAsync().ConfigureAwait(false);

            VisioForgeX.DestroySDK();
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            AddSources();
            await AddMainPipelineAsync();

            await _pipelineSource1.StartAsync();
            await _pipelineMain.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await DestroyEnginesAsync();
        }

        private async void btSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (_pipelineSource1.State == PlaybackState.Play)
            {
                await _pipelineSource1.StopAsync();
                await _pipelineSource2.StartAsync();
            }
            else
            {
                await _pipelineSource2.StopAsync();
                await _pipelineSource1.StartAsync();
            }
        }
    }
}