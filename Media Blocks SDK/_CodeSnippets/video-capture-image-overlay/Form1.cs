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
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;

namespace video_capture_image_overlay
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

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
            // create MediaBlocks pipeline
            _pipeline = new MediaBlocksPipeline();

            // add default video and audio sources
            var videoSources = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList();
            var videoSource = new SystemVideoSourceBlock(new VideoCaptureDeviceSourceSettings(videoSources[0]));

            var audioSources = (await DeviceEnumerator.Shared.AudioSourcesAsync()).ToList();
            var audioSource = new SystemAudioSourceBlock(audioSources[0].CreateSourceSettings());

            // add video renderer
            var videoRenderer = new VideoRendererBlock(_pipeline, videoView: VideoView1);

            // add audio renderer
            var audioRenderers = (await DeviceEnumerator.Shared.AudioOutputsAsync()).ToList();
            var audioRenderer = new AudioRendererBlock(new AudioRendererSettings(audioRenderers[0]));

            // configure MP4 output
            var output = new MP4OutputBlock(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4"));

            // add video and audio tees
            var videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
            var audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);

            // Add image overlay
            var imageFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.png");
            var imageOverlay = new ImageOverlayCairoBlock(new ImageOverlaySettings(imageFile) { X = 100, Y = 100 });

            // connect everything
            _pipeline.Connect(videoSource, imageOverlay);
            _pipeline.Connect(imageOverlay, videoTee);
            _pipeline.Connect(audioSource, audioTee);

            _pipeline.Connect(videoTee, videoRenderer);
            _pipeline.Connect(audioTee, audioRenderer);

            _pipeline.Connect(videoTee, output);
            _pipeline.Connect(audioTee, output);

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
        /// Form 1 form closing.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
