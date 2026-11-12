using VisioForge.Core.Types;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.Types.VideoEffects;
using VisioForge.Core.UI;
using VisioForge.Core.VideoCapture;

namespace WebcamTextOverlay;

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

        foreach (var device in videoCapture1.Video_CaptureDevices())
            cbCamera.Items.Add(device.Name);

        foreach (var device in videoCapture1.Audio_CaptureDevices())
            cbMicrophone.Items.Add(device.Name);

        if (cbCamera.Items.Count > 0) cbCamera.SelectedIndex = 0;
        if (cbMicrophone.Items.Count > 0) cbMicrophone.SelectedIndex = 0;
    }

    private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
    {
        cbFormat.Items.Clear();
        cbFrameRate.Items.Clear();
        var device = videoCapture1.Video_CaptureDevices().First(d => d.Name == cbCamera.Text);
        foreach (var format in device.VideoFormats)
            cbFormat.Items.Add(format.Name);

        var index = cbFormat.Items.IndexOf("1920x1080 MJPG, 24 bit");
        if (cbFormat.Items.Count > 0) cbFormat.SelectedIndex = index >= 0 ? index : 0;
    }

    private void cbFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
        cbFrameRate.Items.Clear();
        var device = videoCapture1.Video_CaptureDevices().First(d => d.Name == cbCamera.Text);
        var format = device.VideoFormats.First(f => f.Name == cbFormat.Text);
        foreach (var frameRate in format.FrameRates)
            cbFrameRate.Items.Add(frameRate);

        var rate = cbFrameRate.Items.IndexOf(VideoFrameRate.FPS_30);
        if (cbFrameRate.Items.Count > 0) cbFrameRate.SelectedIndex = rate >= 0 ? rate : 0;
    }

    private void AddOverlays()
    {
        videoCapture1.Video_Effects_Enabled = true;
        videoCapture1.Video_Effects_Clear();

        // A caption at the bottom, changed with Apply while recording
        videoCapture1.Video_Effects_Add(new VideoEffectTextLogo(true, "caption")
        {
            Text = tbCaption.Text,
            Font = new Font("Segoe UI", 40, FontStyle.Bold),
            FontColor = Color.Yellow,
            HorizontalAlignment = TextLogoHorizontalAlignment.Center,
            VerticalAlignment = TextLogoVerticalAlignment.Bottom
        });

        // Date and time in the top-right corner
        videoCapture1.Video_Effects_Add(new VideoEffectTextLogo(true, "clock")
        {
            Mode = TextLogoMode.DateTime,
            DateTimeMask = "yyyy-MM-dd HH:mm:ss",
            Text = "",
            HorizontalAlignment = TextLogoHorizontalAlignment.Right,
            VerticalAlignment = TextLogoVerticalAlignment.Top
        });

        // The frame number in the top-left corner
        videoCapture1.Video_Effects_Add(new VideoEffectTextLogo(true, "frame")
        {
            Mode = TextLogoMode.FrameNumber,
            Text = "Frame ",
            Left = 20,
            Top = 40
        });

        // Time since the recording started, under the frame number
        videoCapture1.Video_Effects_Add(new VideoEffectTextLogo(true, "time")
        {
            Mode = TextLogoMode.Timestamp,
            TimeStampMask = @"hh\:mm\:ss\.fff",
            Text = "Rec ",
            Left = 20,
            Top = 100
        });
    }

    private async void btStart_Click(object sender, EventArgs e)
    {
        Text = cbFrameRate.SelectedItem is null ? "No camera, format or frame rate" : "Webcam with text overlay";
        if (cbFrameRate.SelectedItem is null) return;

        videoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbCamera.Text);
        var camera = videoCapture1.Video_CaptureDevice;
        camera.Format_UseBest = false;
        camera.Format = cbFormat.Text;
        camera.FrameRate = (VideoFrameRate)cbFrameRate.SelectedItem;

        var mic = (string)cbMicrophone.SelectedItem;
        videoCapture1.Audio_RecordAudio = mic is not null; // no microphone: record video only
        if (mic is not null) videoCapture1.Audio_CaptureDevice = new AudioCaptureSource(mic);
        videoCapture1.Audio_PlayAudio = false; // record the microphone without playing it back

        videoCapture1.Output_Filename = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
        videoCapture1.Output_Format = new MP4Output(); // H.264 and AAC
        videoCapture1.Mode = VideoCaptureMode.VideoCapture;

        AddOverlays();

        btStart.Enabled = false;
        var started = await videoCapture1.StartAsync();
        btStop.Enabled = started;
        btApply.Enabled = started;
        btStart.Enabled = !started;
    }

    private void btApply_Click(object sender, EventArgs e)
    {
        // Change the caption while recording: new text, then Update to redraw it
        if (videoCapture1.Video_Effects_Get("caption") is VideoEffectTextLogo caption)
        {
            caption.Text = tbCaption.Text;
            caption.Update();
        }
    }

    private async void btStop_Click(object sender, EventArgs e)
    {
        btStop.Enabled = false;
        btApply.Enabled = false;
        await videoCapture1.StopAsync();
        btStart.Enabled = true;
    }

    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Finish the MP4 before the window goes away
        if (!btStart.Enabled)
        {
            e.Cancel = true;
            if (!btStop.Enabled) return; // already starting or stopping

            btStop.Enabled = false;
            btApply.Enabled = false;
            await videoCapture1.StopAsync();
            btStart.Enabled = true;
            BeginInvoke(Close); // close again once this handler has returned
            return;
        }

        videoCapture1.Dispose();
    }
}
