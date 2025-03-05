using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using VisioForge.Core;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.AudioRenderers;

namespace video_capture_webcam_mp4
{
    public partial class Form1 : Form
    {
        // Core Video Capture object
        private VideoCaptureCoreX videoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            // Create VideoCaptureCoreX instance and set VideoView for video rendering
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // Enumerate video and audio sources
            var videoSources = (await DeviceEnumerator.Shared.VideoSourcesAsync());
            var audioSources = (await DeviceEnumerator.Shared.AudioSourcesAsync());

            // Set default video source
            videoCapture1.Video_Source = new VideoCaptureDeviceSourceSettings(videoSources[0]);

            // Set default audio source
            videoCapture1.Audio_Source = audioSources[0].CreateSourceSettingsVC();

            // Set default audio sink
            var audioRenderers = (await DeviceEnumerator.Shared.AudioOutputsAsync());
            videoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioRenderers[0]);
            videoCapture1.Audio_Play = true;
            videoCapture1.Audio_Record = true;

            // Configure MP4 output. Default video and audio encoders will be used. GPU encoders will be used if available.
            var mp4Output = new MP4Output(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4"));
            videoCapture1.Outputs_Add(mp4Output);

            // Enable video sample grabber to make snapshots
            videoCapture1.Snapshot_Grabber_Enabled = true;

            // Start capture
            await videoCapture1.StartAsync();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // We have to initialize the engine on start
            Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            // Stop capture
            await videoCapture1.StopAsync();

            // Release resources
            await videoCapture1.DisposeAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Release SDK
            VisioForgeX.DestroySDK();
        }

        private async void btSaveSnapshot_Click(object sender, EventArgs e)
        {
            await videoCapture1.Snapshot_SaveAsync(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "snapshot.jpg"), SkiaSharp.SKEncodedImageFormat.Jpeg);
        }
    }
}
