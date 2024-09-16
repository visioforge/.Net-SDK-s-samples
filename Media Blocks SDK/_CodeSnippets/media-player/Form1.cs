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
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await _pipeline.StopAsync();

            await _pipeline.DisposeAsync();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await VisioForgeX.InitSDKAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
            }
        }
    }
}
