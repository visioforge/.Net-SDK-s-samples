using System;
using System.Windows.Forms;

using VisioForge.Core;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.Output;
using System.IO;

namespace screen_capture_wmv
{
    public partial class Form1 : Form
    {
        private VideoCaptureCoreX videoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private IScreenCaptureSourceSettings CreateScreenCaptureSource()
        {
            var source = new ScreenCaptureDX9SourceSettings();

            source.FrameRate = new VideoFrameRate(25);
            source.Rectangle = new VisioForge.Core.Types.Rect(System.Windows.Forms.Screen.AllScreens[0].Bounds);

            source.CaptureCursor = true;
            source.Monitor = 0;

            return source;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await VisioForgeX.InitSDKAsync();
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // set screen capture with full screen enabled
            videoCapture1.Video_Source = CreateScreenCaptureSource();

            // disable audio playback and recording
            videoCapture1.Audio_Play = videoCapture1.Audio_Record = false;

            // configure WMV output
            var output = new WMV2Output(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.wmv"));
            videoCapture1.Outputs_Add(output);

            await videoCapture1.StartAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await videoCapture1.StopAsync();

            await videoCapture1.DisposeAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
