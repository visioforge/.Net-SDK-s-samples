using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VisioForge.Core.VideoCapture;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core;
using VisioForge.Core.Types.X.Output;

namespace video_capture_webcam_avi
{
    /// <summary>
    /// Video capture webcam AVI X demo main form.
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
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            // Create VideoCaptureCoreX instance and set VideoView for video rendering
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // default video and audio sources will be used
            var videoSourceDevice = (await videoCapture1.Video_SourcesAsync())[0];
            videoCapture1.Video_Source = new VideoCaptureDeviceSourceSettings(videoSourceDevice);

            var audioSourceDevice = (await videoCapture1.Audio_SourcesAsync())[0];
            videoCapture1.Audio_Source = audioSourceDevice.CreateSourceSettingsVC();

            // Set default audio sink
            videoCapture1.Audio_Play = true;
            var audioRendererDevice = (await videoCapture1.Audio_OutputsAsync())[0];
            videoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioRendererDevice);

            // Configure AVI output
            var output = new AVIOutput(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.avi"));
            videoCapture1.Outputs_Add(output);            
            videoCapture1.Audio_Record = true;

            // Start
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
        /// Form 1 form closing.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
