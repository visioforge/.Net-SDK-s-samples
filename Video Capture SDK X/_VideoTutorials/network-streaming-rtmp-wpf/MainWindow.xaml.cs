using System.ComponentModel;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace WebcamRtmpWpf;

public partial class MainWindow : Window
{
    private VideoCaptureCoreX videoCapture1;

    private VideoCaptureDeviceInfo[] cameras;

    private AudioCaptureDeviceInfo[] microphones;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await VisioForgeX.InitSDKAsync();

        videoCapture1 = new VideoCaptureCoreX(VideoView1);

        // Show SDK errors in the title bar
        videoCapture1.OnError += (_, args) => Dispatcher.InvokeAsync(() => Title = args.Message);

        cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
        foreach (var device in cameras)
            cbCamera.Items.Add(device.DisplayName);

        microphones = await DeviceEnumerator.Shared.AudioSourcesAsync();
        foreach (var device in microphones)
            cbMicrophone.Items.Add(device.DisplayName);

        if (cbCamera.Items.Count > 0) cbCamera.SelectedIndex = 0;
        if (cbMicrophone.Items.Count > 0) cbMicrophone.SelectedIndex = 0;

        btStart.IsEnabled = true;
    }

    private async void btStart_Click(object sender, RoutedEventArgs e)
    {
        if (cbCamera.SelectedIndex < 0)
        {
            Title = "No camera";
            return;
        }

        if (string.IsNullOrWhiteSpace(edURL.Text))
        {
            Title = "Enter the RTMP URL";
            return;
        }

        Title = "Webcam to RTMP";

        // 1080p at 25 fps or more when the camera has it, otherwise 720p, otherwise another format
        videoCapture1.Video_Source = new VideoCaptureDeviceSourceSettings(cameras[cbCamera.SelectedIndex]);

        var hasMic = cbMicrophone.SelectedIndex >= 0;
        videoCapture1.Audio_Source = hasMic ? microphones[cbMicrophone.SelectedIndex].CreateSourceSettingsVC() : null;
        videoCapture1.Audio_Record = hasMic; // no microphone: stream video only
        videoCapture1.Audio_Play = false; // stream the microphone without playing it back

        // H.264 on the GPU encoder when there is one, OpenH264 otherwise; AAC audio
        videoCapture1.Outputs_Clear();
        videoCapture1.Outputs_Add(new RTMPOutput(edURL.Text.Trim()));

        btStart.IsEnabled = false;
        var started = await videoCapture1.StartAsync();
        btStop.IsEnabled = started;
        btStart.IsEnabled = !started;
    }

    private async void btStop_Click(object sender, RoutedEventArgs e)
    {
        btStop.IsEnabled = false;
        await videoCapture1.StopAsync();
        btStart.IsEnabled = true;
    }

    private async void Window_Closing(object sender, CancelEventArgs e)
    {
        if (btStart.IsEnabled)
        {
            videoCapture1.Dispose();
            VisioForgeX.DestroySDK();
            return;
        }

        e.Cancel = true; // still loading or streaming: stop the stream first
        if (!btStop.IsEnabled) return; // already loading, starting or stopping
        btStop.IsEnabled = false;
        await videoCapture1.StopAsync();
        btStart.IsEnabled = true;
        await Dispatcher.InvokeAsync(Close); // not Close(): WPF throws inside Closing
    }
}
