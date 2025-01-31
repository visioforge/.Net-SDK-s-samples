using System;
using System.IO;
using System.Windows.Forms;

using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core;
using VisioForge.Core.Types.X.Output;
using System.Linq;

namespace video_capture_webcam_wmv
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
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // default video and audio sources will be used
            var videoSources = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList();
            videoCapture1.Video_Source = new VideoCaptureDeviceSourceSettings(videoSources[0]);
            var audioSources = (await DeviceEnumerator.Shared.AudioSourcesAsync()).ToList();
            videoCapture1.Audio_Source = audioSources[0].CreateSourceSettingsVC();

            // default audio sink
            var audioRenderers = (await DeviceEnumerator.Shared.AudioOutputsAsync()).ToList();
            videoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioRenderers[0]);

            videoCapture1.Audio_Play = true;
            videoCapture1.Audio_Record = true;

            // configure WMV output
            var output = new WMV2Output(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.wmv"));
            videoCapture1.Outputs_Add(output);

            // start
            await videoCapture1.StartAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await videoCapture1.StopAsync();

            await videoCapture1.DisposeAsync();
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
