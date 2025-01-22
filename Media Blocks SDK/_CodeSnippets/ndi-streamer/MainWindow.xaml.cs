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
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types;
using VisioForge.Core;
using VisioForge.Core.Types.X.Decklink;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Decklink;
using VisioForge.Core.MediaBlocks.Special;
using System.ComponentModel;
using VisioForge.Core.MediaBlocks.Sinks;

namespace ndi_streamer_mb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        public MainWindow()
        {
            InitializeComponent();
        }

        private IScreenCaptureSourceSettings CreateScreenCaptureSource()
        {
            var source = new ScreenCaptureD3D11SourceSettings();

            source.FrameRate = new VideoFrameRate(30);
            source.Rectangle = new VisioForge.Core.Types.Rect(System.Windows.Forms.Screen.AllScreens[0].Bounds);

            source.CaptureCursor = true;

            return source;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await VisioForgeX.InitSDKAsync();         
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            // Create the pipeline
            _pipeline = new MediaBlocksPipeline();

            // Create video renderer
            var videoRenderer = new VideoRendererBlock(_pipeline, videoView1);

            // Set screen capture with full screen enabled
            var videoSource = new ScreenSourceBlock(CreateScreenCaptureSource());

            // Add NDI output
            var ndiSink = new NDISinkBlock(name: $"VisioForge NDI Streamer");

            // Video tee
            var tee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            // Audio fake audio source
            var audioSource = new VirtualAudioSourceBlock(VirtualAudioSourceSettingsWave.Silence);

            // Connect blocks
            _pipeline.Connect(videoSource, tee);
            _pipeline.Connect(tee.Outputs[0], videoRenderer.Input);
            _pipeline.Connect(tee.Outputs[1], ndiSink.CreateNewInput(MediaBlockPadMediaType.Video));
            _pipeline.Connect(audioSource.Output, ndiSink.CreateNewInput(MediaBlockPadMediaType.Audio));

            // Start
            await _pipeline.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.StopAsync();

            await _pipeline.DisposeAsync();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}