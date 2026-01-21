using System;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.VideoCapture;
using VisioForge.Core.Types;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core;
using System.Linq;

namespace screen_capture_mp4
{
    /// <summary>
    /// Screen capture MP4 X demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        private VideoCaptureCoreX videoCapture1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create screen capture source.
        /// </summary>
        private IScreenCaptureSourceSettings CreateScreenCaptureSource()
        {
            var source = new ScreenCaptureDX9SourceSettings();

            source.FrameRate = new VideoFrameRate(25);
            source.Rectangle = new VisioForge.Core.Types.Rect(System.Windows.Forms.Screen.AllScreens[0].Bounds);

            source.CaptureCursor = true;
            source.Monitor = 0;

            return source;
        }

        /// <summary>
        /// Handles the bt start with audio click event.
        /// </summary>
        private async void btStartWithAudio_Click(object sender, EventArgs e)
        {
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // set screen capture with full screen enabled
            videoCapture1.Video_Source = CreateScreenCaptureSource();

            // select first audio device with default parameters
            var audioSources = (await DeviceEnumerator.Shared.AudioSourcesAsync()).ToList();
            videoCapture1.Audio_Source = audioSources[0].CreateSourceSettingsVC();

            // disable audio playback
            videoCapture1.Audio_Play = false;

            // enable audio recording
            videoCapture1.Audio_Record = true;

            // configure MP4 output
            var mp4Output = new MP4Output(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4"));
            videoCapture1.Outputs_Add(mp4Output);

            await videoCapture1.StartAsync();
        }

        /// <summary>
        /// Handles the bt start without audio click event.
        /// </summary>
        private async void btStartWithoutAudio_Click(object sender, EventArgs e)
        {
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // set screen capture with full screen enabled
            videoCapture1.Video_Source = CreateScreenCaptureSource();

            // disable audio playback and recording
            videoCapture1.Audio_Play = videoCapture1.Audio_Record = false;

            // configure MP4 output
            var mp4Output = new MP4Output(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4"));
            videoCapture1.Outputs_Add(mp4Output);

            await videoCapture1.StartAsync();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            await videoCapture1.StopAsync();

            await videoCapture1.DisposeAsync();
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private async void Form1_Load(object sender, EventArgs e)
        {
            await VisioForgeX.InitSDKAsync();
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
