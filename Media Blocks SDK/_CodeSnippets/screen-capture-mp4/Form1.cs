using System;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.VideoCapture;
using VisioForge.Core.Types;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core;
using System.Linq;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;

namespace screen_capture_mp4
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create screen capture source.
        /// </summary>
        private IScreenCaptureSourceSettings CreateScreenCaptureSource()
        {
            var source = new ScreenCaptureDX9SourceSettings();

            source.FrameRate = new VideoFrameRate(25);
            source.Rectangle = new VisioForge.Core.Types.Rect(System.Windows.Forms.Screen.AllScreens[0].Bounds);

            source.CaptureCursor = true;
            source.Monitor = 0;

            return source;
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private async void Form1_Load(object sender, EventArgs e)
        {
            await VisioForgeX.InitSDKAsync();
        }

        /// <summary>
        /// Handles the bt start without audio click event.
        /// </summary>
        private async void btStartWithoutAudio_Click(object sender, EventArgs e)
        {
            // create MediaBlocks pipeline
            _pipeline = new MediaBlocksPipeline();

            // add screen source
            var screenSource = new ScreenSourceBlock(CreateScreenCaptureSource());

            // add video renderer
            var videoRenderer = new VideoRendererBlock(_pipeline, videoView: VideoView1);

            // configure MP4 output
            var output = new MP4OutputBlock(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4"));

            // add video and audio tees
            var videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            // connect everything
            _pipeline.Connect(screenSource, videoTee);

            _pipeline.Connect(videoTee, videoRenderer);

            _pipeline.Connect(videoTee, output);

            // start
            await _pipeline.StartAsync();
        }

        /// <summary>
        /// Handles the bt start with audio click event.
        /// </summary>
        private async void btStartWithAudio_Click(object sender, EventArgs e)
        {
            // create MediaBlocks pipeline
            _pipeline = new MediaBlocksPipeline();

            // add screen source
            var screenSource = new ScreenSourceBlock(CreateScreenCaptureSource());

            // add first audio device with default parameters
            var audioSources = (await DeviceEnumerator.Shared.AudioSourcesAsync()).ToList();
            var audioSource = new SystemAudioSourceBlock(audioSources[0].CreateSourceSettings());

            // add video renderer
            var videoRenderer = new VideoRendererBlock(_pipeline, videoView: VideoView1);

            // configure MP4 output
            var output = new MP4OutputBlock(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4"));

            // add video and audio tees
            var videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            // connect everything
            _pipeline.Connect(screenSource, videoTee);

            _pipeline.Connect(videoTee, videoRenderer);

            _pipeline.Connect(videoTee, output);
            _pipeline.Connect(audioSource, output);

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
