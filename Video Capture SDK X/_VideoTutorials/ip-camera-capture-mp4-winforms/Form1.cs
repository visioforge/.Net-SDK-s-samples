using VisioForge.Core;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace IpCameraCaptureMp4;

public partial class Form1 : Form
{
    private VideoCaptureCoreX videoCapture1;

    private string outputFile;

    public Form1()
    {
        InitializeComponent();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await VisioForgeX.InitSDKAsync();

        videoCapture1 = new VideoCaptureCoreX(VideoView1);

        // Show SDK errors in the title bar
        videoCapture1.OnError += (_, args) => BeginInvoke(() => Text = args.Message);

        btStart.Enabled = true;
    }

    private async void btStart_Click(object sender, EventArgs e)
    {
        if (!Uri.TryCreate(edURL.Text, UriKind.Absolute, out var url))
        {
            Text = "Enter the camera URL";
            return;
        }

        Text = "Connecting...";
        btStart.Enabled = false;
        cbRecordAudio.Enabled = false;

        var started = false;
        try
        {
            // Reads the stream info first: audio is recorded only when the info shows an audio track
            videoCapture1.Video_Source = await RTSPSourceSettings.CreateAsync(url, edLogin.Text, edPassword.Text, cbRecordAudio.Checked);

            videoCapture1.Audio_Record = cbRecordAudio.Checked;
            videoCapture1.Audio_Play = false; // record the camera's sound, don't play it

            // H.264 on the GPU encoder when there is one, OpenH264 otherwise; AAC audio
            outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), $"ipcam_{DateTime.Now:yyyyMMdd_HHmmss}.mp4");
            videoCapture1.Outputs_Clear();
            videoCapture1.Outputs_Add(new MP4Output(outputFile));

            started = await videoCapture1.StartAsync();
        }
        catch (Exception ex)
        {
            Text = ex.Message;
        }

        // An SDK error posted during the start stays in the title
        if (Text == "Connecting...") Text = started ? "Recording..." : "The recording did not start";
        btStop.Enabled = started;
        btStart.Enabled = !started;
        cbRecordAudio.Enabled = !started;
    }

    private async void btStop_Click(object sender, EventArgs e)
    {
        btStop.Enabled = false;
        await videoCapture1.StopAsync(); // finishes the MP4 file
        Text = "Saved: " + outputFile;
        btStart.Enabled = true;
        cbRecordAudio.Enabled = true;
    }

    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!btStart.Enabled && !btStop.Enabled)
        {
            e.Cancel = true; // loading, starting or stopping: wait for it
            return;
        }

        if (btStop.Enabled)
        {
            e.Cancel = true; // recording: finish the MP4 first
            btStop.Enabled = false;
            await videoCapture1.StopAsync();
            btStart.Enabled = true;
            BeginInvoke(Close);
            return;
        }

        videoCapture1.Dispose();
        VisioForgeX.DestroySDK();
    }
}
