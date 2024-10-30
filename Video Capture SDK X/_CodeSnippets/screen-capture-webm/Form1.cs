﻿using System;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.VideoCapture;
using VisioForge.Core.Types;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core;
using System.Linq;

namespace screen_capture_webm
{
    public partial class Form1 : Form
    {
        private VideoCaptureCoreX videoCapture1;

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

        private async void btStartWithAudio_Click(object sender, EventArgs e)
        {
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // set screen capture with full screen enabled
            videoCapture1.Video_Source = CreateScreenCaptureSource();

            // select first audio device with default parameters
            videoCapture1.Audio_Source = (await videoCapture1.Audio_SourcesAsync())[0].CreateSourceSettingsVC();

            // disable audio playback
            videoCapture1.Audio_Play = false;

            // enable audio recording
            videoCapture1.Audio_Record = true;

            // configure WebM output
            var webmOutput = new WebMOutput(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.webm"));
            videoCapture1.Outputs_Add(webmOutput);

            await videoCapture1.StartAsync();
        }

        private async void btStartWithoutAudio_Click(object sender, EventArgs e)
        {
            // Create VideoCaptureCoreX object
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // Set screen capture with full screen enabled
            videoCapture1.Video_Source = CreateScreenCaptureSource();

            // Disable audio playback and recording
            videoCapture1.Audio_Play = videoCapture1.Audio_Record = false;

            // Configure WebM output
            var webmOutput = new WebMOutput(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.webm"));
            videoCapture1.Outputs_Add(webmOutput);

            // Start capture
            await videoCapture1.StartAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await videoCapture1.StopAsync();

            await videoCapture1.DisposeAsync();
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
