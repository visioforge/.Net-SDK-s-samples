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
        private VideoCaptureCoreX videoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            // Create VideoCaptureCoreX instance and set VideoView for video rendering
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // Set default video and audio sources
            var videoSources = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList();
            videoCapture1.Video_Source = new VideoCaptureDeviceSourceSettings(videoSources[0]);
            var audioSources = (await DeviceEnumerator.Shared.AudioSourcesAsync()).ToList();
            videoCapture1.Audio_Source = audioSources[0].CreateSourceSettingsVC();

            // Set default audio sink
            var audioRenderers = (await DeviceEnumerator.Shared.AudioOutputsAsync()).ToList();
            videoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioRenderers[0]);
            videoCapture1.Audio_Play = true;

            // Configure MP4 output
            var mp4Output = new MP4Output(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4"));
            videoCapture1.Outputs_Add(mp4Output);
            videoCapture1.Audio_Record = true;

            // Start
            await videoCapture1.StartAsync();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await VisioForgeX.InitSDKAsync();
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
