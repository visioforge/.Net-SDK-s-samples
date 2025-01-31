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

namespace screen_to_decklink_mb
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

            source.FrameRate = new VideoFrameRate(60);
            source.Rectangle = new VisioForge.Core.Types.Rect(System.Windows.Forms.Screen.AllScreens[0].Bounds);

            source.CaptureCursor = true;

            return source;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            var devices = await DeviceEnumerator.Shared.DecklinkVideoSinksAsync();
            foreach (var device in devices)
            {
                cbDecklinkOutput.Items.Add(device.Name);
            }

            if (devices.Length > 0)
            {
                cbDecklinkOutput.SelectedIndex = 0;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            // Create VideoCaptureCoreX object
            _pipeline = new MediaBlocksPipeline();

            // Create video renderer
            var videoRenderer = new VideoRendererBlock(_pipeline, videoView1);

            // Set screen capture with full screen enabled
            var videoSource = new ScreenSourceBlock(CreateScreenCaptureSource());

            // Add Decklink output
            var videoSinks = await DeviceEnumerator.Shared.DecklinkVideoSinksAsync();
            var videoSink = new DecklinkVideoSinkSettings(videoSinks[cbDecklinkOutput.SelectedIndex]);
            videoSink.Mode = DecklinkMode.HD1080p60;
            videoSink.CustomVideoSize = new ResizeVideoEffect(1920, 1080);
            var decklinkVideoOutput = new DecklinkVideoSinkBlock(videoSink);

            // Video tee
            var tee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            // Connect blocks
            _pipeline.Connect(videoSource, tee);
            _pipeline.Connect(tee, videoRenderer);
            _pipeline.Connect(tee, decklinkVideoOutput);

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