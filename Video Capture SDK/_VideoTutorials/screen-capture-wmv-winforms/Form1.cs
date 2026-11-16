using VisioForge.Core.Types;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.UI;
using VisioForge.Core.VideoCapture;

namespace ScreenCaptureWmv;

public partial class Form1 : Form
{
    private VideoCaptureCore videoCapture1;

    public Form1()
    {
        InitializeComponent();
    }

    // The engine names a monitor by the N of its device name, \\.\DISPLAYN
    private static int MonitorNumber(Screen screen) =>
        int.Parse(screen.DeviceName.Replace(@"\\.\DISPLAY", string.Empty));

    private void Form1_Load(object sender, EventArgs e)
    {
        videoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);

        // Show SDK errors in the title bar
        videoCapture1.OnError += (_, args) => BeginInvoke(() => Text = args.Message);

        foreach (var screen in Screen.AllScreens)
            cbMonitor.Items.Add(MonitorNumber(screen));

        cbMonitor.SelectedItem = MonitorNumber(Screen.PrimaryScreen);

        cbFrameRate.Items.AddRange(new object[] { 5, 10, 15, 25, 30 });
        cbFrameRate.SelectedItem = 15;

        // "VisioForge What You Hear Source" records what plays on the speakers
        foreach (var device in videoCapture1.Audio_CaptureDevices())
            cbSound.Items.Add(device.Name);

        cbSound.SelectedItem = "VisioForge What You Hear Source";
        if (cbSound.SelectedIndex < 0 && cbSound.Items.Count > 0) cbSound.SelectedIndex = 0;
        cbRecordSound.Enabled = cbAudioCodec.Enabled = cbAudioFormat.Enabled = cbSound.Items.Count > 0;
        cbRecordSound.CheckedChanged += (_, _) => cbAudioCodec.Enabled = cbAudioFormat.Enabled = cbRecordSound.Checked; // audio settings need sound

        // The Windows Media codecs that can encode at a constant bitrate
        foreach (var codec in videoCapture1.WMV_CustomProfile_VideoCodecs(WMVStreamMode.CBR))
            cbVideoCodec.Items.Add(codec);

        foreach (var codec in videoCapture1.WMV_CustomProfile_AudioCodecs(WMVStreamMode.CBR))
            cbAudioCodec.Items.Add(codec);

        cbVideoCodec.SelectedItem = "Windows Media Video 9";
        if (cbVideoCodec.SelectedIndex < 0 && cbVideoCodec.Items.Count > 0) cbVideoCodec.SelectedIndex = 0;
        cbAudioCodec.SelectedItem = "Windows Media Audio 9.2";
        if (cbAudioCodec.SelectedIndex < 0 && cbAudioCodec.Items.Count > 0) cbAudioCodec.SelectedIndex = 0;
    }

    private void cbAudioCodec_SelectedIndexChanged(object sender, EventArgs e)
    {
        // The sample rates, channels and bitrates this audio codec offers
        cbAudioFormat.Items.Clear();
        foreach (var format in videoCapture1.WMV_CustomProfile_AudioFormats(cbAudioCodec.Text, WMVStreamMode.CBR))
            cbAudioFormat.Items.Add(format);

        var index = cbAudioFormat.Items.IndexOf("CBR 128 kbps, 44100 Hz, Stereo, 16 bit");
        if (cbAudioFormat.Items.Count > 0) cbAudioFormat.SelectedIndex = index >= 0 ? index : 0;
    }

    private async void btStart_Click(object sender, EventArgs e)
    {
        if (cbVideoCodec.SelectedItem is null)
        {
            Text = "No video codec selected";
            return;
        }

        var recordSound = cbRecordSound.Checked && cbSound.SelectedItem is not null;
        if (recordSound && cbAudioFormat.SelectedItem is null)
        {
            Text = "No audio format selected";
            return;
        }

        Text = "Screen to WMV";

        // The whole monitor at the frame rate from the list
        var frameRate = (int)cbFrameRate.SelectedItem;
        videoCapture1.Screen_Capture_Source = new ScreenCaptureSourceSettings
        {
            FullScreen = true,
            AllowDesktopDuplicationEngine = true, // DXGI Desktop Duplication: faster than GDI
            DisplayIndex = (int)cbMonitor.SelectedItem,
            GrabMouseCursor = cbCursor.Checked,
            FrameRate = new VideoFrameRate(frameRate)
        };

        videoCapture1.Audio_RecordAudio = recordSound;
        // No device when the sound is off: a What You Hear device left here still opens the speakers
        videoCapture1.Audio_CaptureDevice = recordSound ? new AudioCaptureSource(cbSound.Text) : null;
        videoCapture1.Audio_PlayAudio = false; // never play the captured sound back into the speakers

        var wmv = new WMVOutput
        {
            Mode = WMVMode.CustomSettings,

            Custom_Video_StreamPresent = true,
            Custom_Video_Codec = cbVideoCodec.Text,
            Custom_Video_Mode = WMVStreamMode.CBR,
            Custom_Video_Bitrate = 10000, // kbps
            Custom_Video_SizeSameAsInput = true, // the monitor's resolution
            Custom_Video_FrameRate = frameRate,
            Custom_Video_KeyFrameInterval = 2, // seconds

            Custom_Audio_StreamPresent = recordSound,
            Custom_Audio_Codec = cbAudioCodec.Text,
            Custom_Audio_Format = cbAudioFormat.Text,
            Custom_Audio_Mode = WMVStreamMode.CBR,
        };

        videoCapture1.Output_Filename = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.wmv");
        videoCapture1.Output_Format = wmv;
        videoCapture1.Mode = VideoCaptureMode.ScreenCapture;

        btStart.Enabled = false;
        var started = await videoCapture1.StartAsync();
        btStop.Enabled = started;
        btStart.Enabled = !started;
    }

    private async void btStop_Click(object sender, EventArgs e)
    {
        btStop.Enabled = false;
        await videoCapture1.StopAsync();
        btStart.Enabled = true;
    }

    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Finish the WMV before the window goes away
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
