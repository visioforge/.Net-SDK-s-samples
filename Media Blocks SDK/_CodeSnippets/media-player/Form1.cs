using System;
using System.Windows.Forms;

using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using System.Linq;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.AudioRendering;

namespace media_player
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edFilename.Text))
            {
                MessageBox.Show("Please select a file.");
                return;
            }

            // Create MediaBlocks pipeline
            _pipeline = new MediaBlocksPipeline();

            // Add file source
            var fileSourceSettings = await UniversalSourceSettings.CreateAsync(edFilename.Text);
            var videoStreamAvailable = fileSourceSettings.GetInfo().VideoStreams.Count > 0;
            var audioStreamAvailable = fileSourceSettings.GetInfo().AudioStreams.Count > 0;

            var fileSource = new UniversalSourceBlock(fileSourceSettings);

            // Add video renderer
            if (videoStreamAvailable)
            {
                var videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
                _pipeline.Connect(fileSource, videoRenderer);
            }

            // Add audio output
            if (audioStreamAvailable)
            {
                var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound))[0];
                var audioOutput = new AudioRendererBlock(new AudioRendererSettings(audioOutputDevice));
                _pipeline.Connect(fileSource, audioOutput);
            }

            // Start playback
            await _pipeline.StartAsync();

            timer1.Start();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            await _pipeline.StopAsync(force: true);

            await _pipeline.DisposeAsync();
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

        /// <summary>
        /// Handles the bt open file click event.
        /// </summary>
        private void btOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the tb timeline scroll event.
        /// </summary>
        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        /// <summary>
        /// Handles the timer 1 tick event.
        /// </summary>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            tbTimeline.Maximum = (int)(await _pipeline.DurationAsync()).TotalSeconds;

            int value = (int)(await _pipeline.Position_GetAsync()).TotalSeconds;
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTime.Text = TimeSpan.FromSeconds(tbTimeline.Value).ToString("hh\\:mm\\:ss") + "/" + TimeSpan.FromSeconds(tbTimeline.Maximum).ToString("hh\\:mm\\:ss");

            timer1.Tag = 0;
        }
    }
}
