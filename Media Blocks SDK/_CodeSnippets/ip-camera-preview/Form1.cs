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

namespace ip_camera_preview
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
            // Create Media Blocks pipeline
            _pipeline = new MediaBlocksPipeline();

            // Create video renderer
            var videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            // Add RTSP camera source
            var rtsp = await RTSPSourceSettings.CreateAsync(new Uri(edURL.Text), edLogin.Text, edPassword.Text, audioEnabled: cbAudioStream.Checked);
            var rtspSource = new RTSPSourceBlock(rtsp);

            _pipeline.Connect(rtspSource, videoRenderer);

            // Add audio output (if required)
            if (cbAudioStream.Checked && rtsp.IsAudioAvailable())
            {
                var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound))[0];
                var audioOutput = new AudioRendererBlock(new AudioRendererSettings(audioOutputDevice));
                _pipeline.Connect(rtspSource, audioOutput);
            }

            // Start IP camera preview
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
    }
}
