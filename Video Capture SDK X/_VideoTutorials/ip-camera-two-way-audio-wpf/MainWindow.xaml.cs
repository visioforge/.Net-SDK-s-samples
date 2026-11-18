using System.ComponentModel;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace IpCameraTwoWayAudioWpf;

public partial class MainWindow : Window
{
    private VideoCaptureCoreX videoCapture1;

    private AudioCaptureDeviceInfo[] microphones;

    private AudioOutputDeviceInfo[] speakers;

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

        microphones = await DeviceEnumerator.Shared.AudioSourcesAsync();
        foreach (var device in microphones)
            cbMicrophone.Items.Add(device.DisplayName);

        if (cbMicrophone.Items.Count > 0) cbMicrophone.SelectedIndex = 0;

        speakers = await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2);
        foreach (var device in speakers)
            cbSpeakers.Items.Add(device.DisplayName);

        // Preselect the system's default output
        if (cbSpeakers.Items.Count > 0) cbSpeakers.SelectedIndex = Math.Max(0, Array.FindIndex(speakers, device => device.IsDefault));

        btStart.IsEnabled = true;
    }

    private async void btStart_Click(object sender, RoutedEventArgs e)
    {
        if (!Uri.TryCreate(edURL.Text, UriKind.Absolute, out var url))
        {
            Title = "Enter the camera URL";
            return;
        }

        if (cbMicrophone.SelectedIndex < 0)
        {
            Title = "No microphone";
            return;
        }

        Title = "Connecting...";
        btStart.IsEnabled = false;

        var started = false;
        try
        {
            // The camera's video and its own microphone, played on the chosen speakers
            videoCapture1.Video_Source = await RTSPSourceSettings.CreateAsync(url, edLogin.Text, edPassword.Password, audioEnabled: true);
            videoCapture1.Audio_OutputDevice = cbSpeakers.SelectedIndex < 0 ? null : new AudioRendererSettings(speakers[cbSpeakers.SelectedIndex]);
            videoCapture1.Audio_Play = true;

            // The PC microphone, sent to the camera speaker over the ONVIF audio backchannel
            videoCapture1.Audio_BackchannelSource = microphones[cbMicrophone.SelectedIndex].CreateSourceSettingsVC();

            started = await videoCapture1.StartAsync();
        }
        catch (Exception ex)
        {
            Title = ex.Message;
        }

        // An SDK error posted during the start stays in the title
        if (Title == "Connecting...") Title = started ? "Talking to the camera" : "The camera did not start";
        btStop.IsEnabled = started;
        btStart.IsEnabled = !started;
    }

    private async void btStop_Click(object sender, RoutedEventArgs e)
    {
        btStop.IsEnabled = false;
        await videoCapture1.StopAsync();
        Title = "IP Camera Two-Way Audio";
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

        e.Cancel = true; // still loading or talking: stop first
        if (!btStop.IsEnabled) return; // already loading, starting or stopping
        btStop.IsEnabled = false;
        await videoCapture1.StopAsync();
        btStart.IsEnabled = true;
        await Dispatcher.InvokeAsync(Close); // not Close(): WPF throws inside Closing
    }
}
