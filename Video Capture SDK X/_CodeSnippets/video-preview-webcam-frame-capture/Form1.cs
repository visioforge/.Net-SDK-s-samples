﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Core;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace video_preview_webcam_frame_capture
{
    public partial class Form1 : Form
    {
        private VideoCaptureCoreX videoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // We have to initialize the engine on start
            Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            videoCapture1 = new VideoCaptureCoreX(VideoView1);

            // default video and audio sources will be used
            var videoSources = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList();
            videoCapture1.Video_Source = new VideoCaptureDeviceSourceSettings(videoSources[0]);
            var audioSources = (await DeviceEnumerator.Shared.AudioSourcesAsync()).ToList();
            videoCapture1.Audio_Source = audioSources[0].CreateSourceSettingsVC();

            // default audio sink
            var audioRenderers = (await DeviceEnumerator.Shared.AudioOutputsAsync()).ToList();
            videoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioRenderers[0]);

            videoCapture1.Audio_Play = true;

            // enable frame capture
            videoCapture1.Snapshot_Grabber_Enabled = true;

            // start
            await videoCapture1.StartAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await videoCapture1.StopAsync();

            await videoCapture1.DisposeAsync();
        }

        private async void btSaveFrame_Click(object sender, EventArgs e)
        {
            await videoCapture1.Snapshot_SaveAsync(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "frame.jpg"),
                SkiaSharp.SKEncodedImageFormat.Jpeg);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
