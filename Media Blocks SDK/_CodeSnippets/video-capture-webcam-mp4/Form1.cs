using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using VisioForge.Core;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;

namespace video_capture_webcam_mp4
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await VisioForgeX.InitSDKAsync();
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            // Create the pipeline
            _pipeline = new MediaBlocksPipeline();

            // Add video and audio sources
            var videoSources = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList();
            var videoSource = new SystemVideoSourceBlock(new VideoCaptureDeviceSourceSettings(videoSources[0]));

            var audioSources = (await DeviceEnumerator.Shared.AudioSourcesAsync()).ToList();
            var audioSource = new SystemAudioSourceBlock(audioSources[0].CreateSourceSettings());

            // Add video renderer and specify VideoView control
            var videoRenderer = new VideoRendererBlock(_pipeline, videoView: VideoView1);

            // Add audio renderer
            var audioRenderers = (await DeviceEnumerator.Shared.AudioOutputsAsync()).ToList();
            var audioRenderer = new AudioRendererBlock(new AudioRendererSettings(audioRenderers[0]));

            // Configure MP4 output
            var output = new MP4OutputBlock(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4"));

            // Add video and audio tees
            var videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
            var audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);

            // Connect everything
            _pipeline.Connect(videoSource, videoTee);
            _pipeline.Connect(audioSource, audioTee);

            _pipeline.Connect(videoTee, videoRenderer);
            _pipeline.Connect(audioTee, audioRenderer);

            _pipeline.Connect(videoTee, output);
            _pipeline.Connect(audioTee, output);

            // Start MP4 recording
            await _pipeline.StartAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await _pipeline.StopAsync();

            await _pipeline.DisposeAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
