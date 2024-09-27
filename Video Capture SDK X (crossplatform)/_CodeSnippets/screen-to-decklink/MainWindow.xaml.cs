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
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core;
using VisioForge.Core.Types.Decklink;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Decklink;
using VisioForge.Core.Types.X.VideoEffects;

namespace screen_to_decklink
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX videoCapture1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private IScreenCaptureSourceSettings CreateScreenCaptureSource()
        {
            var source = new ScreenCaptureDX9SourceSettings();

            source.FrameRate = new VideoFrameRate(30);
            source.Rectangle = new VisioForge.Core.Types.Rect(System.Windows.Forms.Screen.AllScreens[0].Bounds);

            source.CaptureCursor = true;
            source.Monitor = 0;

            return source;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await VisioForgeX.InitSDKAsync();

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
            videoCapture1 = new VideoCaptureCoreX(videoView1);

            // Set screen capture with full screen enabled
            videoCapture1.Video_Source = CreateScreenCaptureSource();

            // Disable audio playback and recording
            videoCapture1.Audio_Play = videoCapture1.Audio_Record = false;

            // Add Decklink output
            var sinks = await DeviceEnumerator.Shared.DecklinkVideoSinksAsync();
            var videoSink = new DecklinkVideoSinkSettings(sinks[cbDecklinkOutput.SelectedIndex]);
            videoSink.Mode = DecklinkMode.HD1080p30;
            videoSink.CustomVideoSize = new ResizeVideoEffect(1920, 1080);
            var decklinkOutput = new DecklinkOutput(videoSink, null);
            videoCapture1.Outputs_Add(decklinkOutput);

            // Resize to one of Decklink supported sizes
            await videoCapture1.Video_Effects_AddOrUpdateAsync(new ResizeVideoEffect(1920, 1080));

            // Start
            await videoCapture1.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await videoCapture1.StopAsync();

            await videoCapture1.DisposeAsync();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}