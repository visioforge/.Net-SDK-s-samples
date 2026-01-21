using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core;
using VisioForge.Core.VideoCaptureX;
using System.Linq;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.VideoEffects;

namespace video_capture_text_overlay
{
    /// <summary>
    /// Video capture text overlay X demo main form.
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
        /// Handles the bt start click event.
        /// </summary>
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

            // configure MP4 output
            var output = new MP4Output(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4"));
            videoCapture1.Outputs_Add(output);

            // text overlay
            await videoCapture1.Video_Effects_AddOrUpdateAsync(new TextOverlayVideoEffect() { Text = "Hello World!" });

            // start
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
            // We have to initialize the engine on start
            Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
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
