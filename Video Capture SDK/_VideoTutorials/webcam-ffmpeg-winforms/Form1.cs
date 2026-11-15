using VisioForge.Core.Types;
using VisioForge.Core.Types.FFMPEGEXE;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.UI;
using VisioForge.Core.VideoCapture;

namespace WebcamFfmpeg;

public partial class Form1 : Form
{
    private const string Mp4H264 = "MP4 - H.264 + AAC";
    private const string Mp4Hevc = "MP4 - HEVC + AAC";
    private const string WebmVp9 = "WebM - VP9 + Opus";

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

        cbOutput.Items.Add(Mp4H264);
        cbOutput.Items.Add(WebmVp9);

        // HEVC needs a hardware encoder: an Intel, NVIDIA or AMD GPU
        var hw = VideoCaptureCore.HWEncodersAvailable();
        if (hw.QSV_H265 || hw.NVENC_H265 || hw.AMD_H265)
            cbOutput.Items.Add(Mp4Hevc);

        cbOutput.SelectedIndex = 0;
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
        if (cbFrameRate.SelectedItem is null)
        {
            Text = "No camera, format or frame rate";
            return;
        }

        Text = "Webcam to MP4 and WebM with FFmpeg";

        videoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbCamera.Text);
        var camera = videoCapture1.Video_CaptureDevice;
        camera.Format_UseBest = false;
        camera.Format = cbFormat.Text;
        camera.FrameRate = (VideoFrameRate)cbFrameRate.SelectedItem;

        var mic = (string)cbMicrophone.SelectedItem;
        videoCapture1.Audio_RecordAudio = mic is not null; // no microphone: record video only
        if (mic is not null) videoCapture1.Audio_CaptureDevice = new AudioCaptureSource(mic);
        videoCapture1.Audio_PlayAudio = false; // record the microphone without playing it back

        var ffmpeg = new FFMPEGEXEOutput();
        string extension;
        switch (cbOutput.Text)
        {
            case Mp4Hevc:
                ffmpeg.OutputMuxer = OutputMuxer.MP4;
                ffmpeg.Video = new HEVCMFSettings
                {
                    ForceHWEncoding = true, // the GPU's encoder
                    RateControl = H264MFRateControl.CBR,
                    Bitrate = 6_000_000,
                };
                ffmpeg.Audio = Aac();
                extension = ".mp4";
                break;

            case WebmVp9:
                ffmpeg.OutputMuxer = OutputMuxer.WebM;
                ffmpeg.Video = new BasicVideoSettings
                {
                    Encoder = VideoEncoder.VP9,
                    BasicMode = VideoMode.CBR,
                    Bitrate = 8_000_000,
                };
                ffmpeg.Audio = new BasicAudioSettings
                {
                    Encoder = AudioEncoder.OPUS,
                    Mode = AudioMode.CBR,
                    Bitrate = 128_000,
                    SampleRate = 0, // 0: keep the microphone's own
                    Channels = 0,
                };
                extension = ".webm";
                break;

            default:
                ffmpeg.OutputMuxer = OutputMuxer.MP4;
                ffmpeg.Video = new H264MFSettings
                {
                    RateControl = H264MFRateControl.CBR,
                    Bitrate = 8_000_000,
                };
                ffmpeg.Audio = Aac();
                extension = ".mp4";
                break;
        }

        videoCapture1.Output_Filename = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output" + extension);
        videoCapture1.Output_Format = ffmpeg;
        videoCapture1.Mode = VideoCaptureMode.VideoCapture;

        btStart.Enabled = false;
        var started = await videoCapture1.StartAsync();
        btStop.Enabled = started;
        btStart.Enabled = !started;
    }

    private static BasicAudioSettings Aac() => new()
    {
        Encoder = AudioEncoder.AAC,
        Mode = AudioMode.CBR,
        Bitrate = 192_000,
        SampleRate = 0, // 0: keep the microphone's own
        Channels = 0,
    };

    private async void btStop_Click(object sender, EventArgs e)
    {
        btStop.Enabled = false;
        await videoCapture1.StopAsync();
        btStart.Enabled = true;
    }

    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Finish the file before the window goes away
        if (!btStart.Enabled)
        {
            e.Cancel = true;
            if (!btStop.Enabled) return; // already starting or stopping

            btStop.Enabled = false;
            await videoCapture1.StopAsync();
            btStart.Enabled = true;
            BeginInvoke(Close); // close again once this handler has returned
            return;
        }

        videoCapture1.Dispose();
    }
}
