using System;
using System.Windows.Forms;

using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using System.Linq;

namespace ip_camera_preview
{
    /// <summary>
    /// IP camera preview X demo main form.
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
            // Create VideoCaptureCoreX instance
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // Configure RTSP camera source
            var rtsp = await RTSPSourceSettings.CreateAsync(new Uri(edURL.Text), edLogin.Text, edPassword.Text, cbAudioStream.Checked);
            videoCapture1.Video_Source = rtsp;

            // Set audio output device
            var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound))[0];
            videoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

            // Start IP preview
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
