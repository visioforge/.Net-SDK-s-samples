using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace speaker_capture
{
    using VisioForge.Core.VideoCaptureX;
    using VisioForge.Core;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.AudioRenderers;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.Types.X.VideoCapture;
    using System.IO;

    /// <summary>
    /// Speaker capture X demo main form.
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

            var audioSinks = await DeviceEnumerator.Shared.AudioOutputsAsync();
            foreach (var sink in audioSinks)
            {
                if (sink.API == AudioOutputDeviceAPI.WASAPI2)
                {
                    cbAudioLoopbackSource.Items.Add(sink.Name);

                    if (cbAudioLoopbackSource.Items.Count == 1)
                    {
                        cbAudioLoopbackSource.SelectedIndex = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            videoCapture1 = new VideoCaptureCoreX();

            // audio input
            IVideoCaptureBaseAudioSourceSettings audioSource = null;
            var deviceItem = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2)).First(device => device.Name == cbAudioLoopbackSource.Text);
            if (deviceItem == null)
            {
                return;
            }

            audioSource = new LoopbackAudioCaptureDeviceSourceSettings(deviceItem);

            videoCapture1.Audio_Source = audioSource;

            videoCapture1.Audio_Play = false;
            videoCapture1.Audio_Record = true;
            videoCapture1.Video_Play = false;

            // output
            var output = new M4AOutput(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.m4a"));
            videoCapture1.Outputs_Add(output);

            await videoCapture1.StartAsync();
        }
    }
}
