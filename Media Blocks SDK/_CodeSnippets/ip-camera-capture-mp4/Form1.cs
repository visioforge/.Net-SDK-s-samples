using System;
using System.Windows.Forms;

using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Special;
using System.IO;

namespace ip_camera_capture_mp4
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
            // create MediaBlocks pipeline
            _pipeline = new MediaBlocksPipeline();

            // video renderer
            var videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            // RTSP camera source
            var rtsp = await RTSPSourceSettings.CreateAsync(new Uri(edURL.Text), edLogin.Text, edPassword.Text, audioEnabled: true);
            var rtspSource = new RTSPSourceBlock(rtsp);
                  
            // configure MP4 output
            var mp4Output = new MP4OutputBlock(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4"));

            // add video tee
            var videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
            _pipeline.Connect(rtspSource, videoTee);

            // connect video tee to video renderer and MP4 output
            _pipeline.Connect(videoTee, videoRenderer);
            _pipeline.Connect(videoTee, mp4Output);

            // audio output
            if (rtsp.IsAudioAvailable())
            {
                var audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);

                var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound))[0];
                var audioOutput = new AudioRendererBlock(new AudioRendererSettings(audioOutputDevice));

                _pipeline.Connect(rtspSource, audioTee);
                _pipeline.Connect(audioTee, audioOutput);
                _pipeline.Connect(audioTee, mp4Output);
            }

            // start
            await _pipeline.StartAsync();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            await _pipeline.StopAsync();

            await _pipeline.DisposeAsync();
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
