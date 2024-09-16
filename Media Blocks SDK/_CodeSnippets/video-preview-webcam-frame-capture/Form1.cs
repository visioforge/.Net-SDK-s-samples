using System;
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
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;

namespace video_preview_webcam_frame_capture
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private VideoSampleGrabberBlock _videoSampleGrabber;

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
            // Create MediaBlocksPipeline object
            _pipeline = new MediaBlocksPipeline();

            // Add default video and audio sources
            var videoSources = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList();
            var videoSource = new SystemVideoSourceBlock(new VideoCaptureDeviceSourceSettings(videoSources.Find(x => x.Name.Contains("920"))));

            var audioSources = (await DeviceEnumerator.Shared.AudioSourcesAsync()).ToList();
            var audioSource = new SystemAudioSourceBlock(audioSources[0].CreateSourceSettings());

            // Add video renderer
            var videoRenderer = new VideoRendererBlock(_pipeline, videoView: VideoView1);

            // Add audio renderer
            var audioRenderers = (await DeviceEnumerator.Shared.AudioOutputsAsync()).ToList();
            var audioRenderer = new AudioRendererBlock(new AudioRendererSettings(audioRenderers[0]));

            // add sample grabber
            _videoSampleGrabber = new VideoSampleGrabberBlock(VisioForge.Core.Types.X.VideoFormatX.RGB);
            _videoSampleGrabber.SaveLastFrame = true;

            // Connect everything
            _pipeline.Connect(videoSource, _videoSampleGrabber);
            _pipeline.Connect(_videoSampleGrabber, videoRenderer);

            _pipeline.Connect(audioSource, audioRenderer);            

            // Start preview
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

        private void btSaveFrame_Click(object sender, EventArgs e)
        {
            var frame = _videoSampleGrabber.GetLastFrameAsBitmap();
            frame.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "frame.jpg"), ImageFormat.Jpeg);
            frame.Dispose();
        }
    }
}
