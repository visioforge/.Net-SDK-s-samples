using System;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.VideoCapture;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoCapture;

namespace screen_capture_mp4
{
    /// <summary>
    /// Screen capture MP4 demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        private VideoCaptureCore videoCapture1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the bt start with audio click event.
        /// </summary>
        private async void btStartWithAudio_Click(object sender, EventArgs e)
        {
            // set screen capture with full screen enabled
            videoCapture1.Screen_Capture_Source = new ScreenCaptureSourceSettings() { FullScreen = true };

            // select first audio device with default parameters
            videoCapture1.Audio_CaptureDevice = new AudioCaptureSource(videoCapture1.Audio_CaptureDevices()[0].Name);

            // disable audio playback
            videoCapture1.Audio_PlayAudio = false;

            // enable audio recording
            videoCapture1.Audio_RecordAudio = true;

            // set output filename, output format and screen capture mode
            videoCapture1.Output_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            videoCapture1.Output_Format = new MP4Output();
            videoCapture1.Mode = VideoCaptureMode.ScreenCapture;

            await videoCapture1.StartAsync();
        }

        /// <summary>
        /// Handles the bt start without audio click event.
        /// </summary>
        private async void btStartWithoutAudio_Click(object sender, EventArgs e)
        {
            // set screen capture with full screen enabled
            videoCapture1.Screen_Capture_Source = new ScreenCaptureSourceSettings() { FullScreen = true };

            // disable audio playback and recording
            videoCapture1.Audio_PlayAudio = videoCapture1.Audio_RecordAudio = false;

            // set output filename, output format and screen capture mode
            videoCapture1.Output_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            videoCapture1.Output_Format = new MP4Output();
            videoCapture1.Mode = VideoCaptureMode.ScreenCapture;

            await videoCapture1.StartAsync();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            await videoCapture1.StopAsync();
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            videoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);
        }
    }
}
