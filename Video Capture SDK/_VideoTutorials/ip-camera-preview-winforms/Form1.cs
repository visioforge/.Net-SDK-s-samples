using VisioForge.Core.Types;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.Types.VideoEffects;
using VisioForge.Core.UI;
using VisioForge.Core.VideoCapture;

namespace IpCameraPreview;

public partial class Form1 : Form
{
    private VideoCaptureCore videoCapture1;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        videoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);

        // Show SDK errors in the title bar
        videoCapture1.OnError += (_, args) => BeginInvoke(() => Text = args.Message);
    }

    private async void btStart_Click(object sender, EventArgs e)
    {
        if (!Uri.TryCreate(edURL.Text, UriKind.Absolute, out var url))
        {
            Text = "Enter the camera URL";
            return;
        }

        // The URL stays free of credentials: login and password go separately
        videoCapture1.IP_Camera_Source = new IPCameraSourceSettings
        {
            URL = url,
            Login = edLogin.Text,
            Password = edPassword.Text,
            Type = IPSourceEngine.Auto_LAV
        };

        // Video only: audio playback is on by default
        videoCapture1.Audio_PlayAudio = false;

        // Effects are set before the start
        videoCapture1.Video_Effects_Clear();
        videoCapture1.Video_Effects_Enabled = cbPixelate.Checked;
        if (cbPixelate.Checked)
            videoCapture1.Video_Effects_Add(new VideoEffectMosaic(true, 40));

        videoCapture1.Mode = VideoCaptureMode.IPPreview;

        // A camera that does not answer takes up to ~20 s to fail
        Text = "Connecting...";
        btStart.Enabled = false;
        cbPixelate.Enabled = false;
        var started = await videoCapture1.StartAsync();

        // An SDK error posted during the start stays in the title
        if (Text == "Connecting...") Text = started ? "IP camera preview" : "The preview did not start";
        btStop.Enabled = started;
        btStart.Enabled = !started;
        cbPixelate.Enabled = !started;
    }

    private async void btStop_Click(object sender, EventArgs e)
    {
        btStop.Enabled = false;
        await videoCapture1.StopAsync();
        btStart.Enabled = true;
        cbPixelate.Enabled = true;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Starting or stopping: wait for it before closing
        if (!btStart.Enabled && !btStop.Enabled)
        {
            e.Cancel = true;
            return;
        }

        // Dispose stops a running preview: there is no file to finish
        videoCapture1.Dispose();
    }
}
