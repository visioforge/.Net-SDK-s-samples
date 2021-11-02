using System;
using System.IO;
using System.Windows.Forms;
using VisioForge.Controls.VideoCapture;
using VisioForge.Types;
using VisioForge.Types.Output;
using VisioForge.Types.VideoCapture;

namespace screen_capture_mp4
{
    public partial class Form1 : Form
    {
        private VideoCaptureCore videoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private void btStartWithAudio_Click(object sender, EventArgs e)
        {
            // set screen capture with full screen enabled
            videoCapture1.Screen_Capture_Source = new ScreenCaptureSourceSettings() { FullScreen = true };

            // select first audio device with default parameters
            videoCapture1.Audio_CaptureDevice = new AudioCaptureSource(videoCapture1.Audio_CaptureDevices[0].Name);

            // disable audio playback
            videoCapture1.Audio_PlayAudio = false;

            // enable audio recording
            videoCapture1.Audio_RecordAudio = true;

            // set output filename, output format and screen capture mode
            videoCapture1.Output_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            videoCapture1.Output_Format = new MP4Output();
            videoCapture1.Mode = VideoCaptureMode.ScreenCapture;

            videoCapture1.Start();
        }

        private void btStartWithoutAudio_Click(object sender, EventArgs e)
        {
            // set screen capture with full screen enabled
            videoCapture1.Screen_Capture_Source = new ScreenCaptureSourceSettings() { FullScreen = true };

            // disable audio playback and recording
            videoCapture1.Audio_PlayAudio = videoCapture1.Audio_RecordAudio = false;

            // set output filename, output format and screen capture mode
            videoCapture1.Output_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            videoCapture1.Output_Format = new MP4Output();
            videoCapture1.Mode = VideoCaptureMode.ScreenCapture;
            videoCapture1.Start();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await videoCapture1.StopAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);
        }
    }
}
