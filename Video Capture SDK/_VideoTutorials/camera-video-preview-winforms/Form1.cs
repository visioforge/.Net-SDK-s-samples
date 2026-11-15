using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using VisioForge.Core.Types;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.UI;
using VisioForge.Core.VideoCapture;

namespace WebcamPreview;

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

        if (cbCamera.Items.Count > 0) cbCamera.SelectedIndex = 0;
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

    private async void btStart_Click(object sender, EventArgs e)
    {
        Text = cbFrameRate.SelectedItem is null ? "No camera, format or frame rate" : "Webcam preview";
        if (cbFrameRate.SelectedItem is null) return;

        videoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbCamera.Text);
        var camera = videoCapture1.Video_CaptureDevice;
        camera.Format_UseBest = false;
        camera.Format = cbFormat.Text;
        camera.FrameRate = (VideoFrameRate)cbFrameRate.SelectedItem;

        // Video only: audio playback is on by default
        videoCapture1.Audio_PlayAudio = false;
        videoCapture1.Mode = VideoCaptureMode.VideoPreview;

        btStart.Enabled = false;
        var started = await videoCapture1.StartAsync();
        btStop.Enabled = started;
        btSaveFrame.Enabled = started;
        btStart.Enabled = !started;
    }

    private async void btSaveFrame_Click(object sender, EventArgs e)
    {
        // A new JPEG in Pictures on every click, at the camera's own resolution
        var file = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
            $"frame-{DateTime.Now:yyyyMMdd-HHmmss-fff}.jpg");

        if (!await videoCapture1.Frame_SaveAsync(file, ImageFormat.Jpeg, 85)) return;

        // Open it in the default viewer; with no app for .jpg, the path in the title is all there is
        Text = file;
        try { Process.Start(new ProcessStartInfo(file) { UseShellExecute = true }); }
        catch (Win32Exception) { }
    }

    private async void btStop_Click(object sender, EventArgs e)
    {
        btStop.Enabled = false;
        btSaveFrame.Enabled = false;
        await videoCapture1.StopAsync();
        btStart.Enabled = true;
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
