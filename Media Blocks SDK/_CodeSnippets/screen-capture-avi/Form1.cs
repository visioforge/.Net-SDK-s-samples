﻿using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;

using VisioForge.Core.Types;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Sources;

namespace screen_capture_avi
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        public Form1()
        {
            InitializeComponent();
        }

        private IScreenCaptureSourceSettings CreateScreenCaptureSource()
        {
            var source = new ScreenCaptureDX9SourceSettings();

            source.FrameRate = new VideoFrameRate(25);
            source.Rectangle = new VisioForge.Core.Types.Rect(System.Windows.Forms.Screen.AllScreens[0].Bounds);

            source.CaptureCursor = true;
            source.Monitor = 0;

            return source;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await VisioForgeX.InitSDKAsync();
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            // create MediaBlocks pipeline
            _pipeline = new MediaBlocksPipeline();

            // add screen source
            var screenSource = new ScreenSourceBlock(CreateScreenCaptureSource());

            // add video renderer
            var videoRenderer = new VideoRendererBlock(_pipeline, videoView: VideoView1);

            // configure AVI output
            var output = new AVIOutputBlock(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.avi"));

            // add video and audio tees
            var videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            // connect everything
            _pipeline.Connect(screenSource, videoTee);

            _pipeline.Connect(videoTee, videoRenderer);

            _pipeline.Connect(videoTee, output);

            // start
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
