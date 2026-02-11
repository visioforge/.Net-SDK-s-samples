using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Special;
using System.Diagnostics;

namespace video_capture_webcam_avi
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
            try
            {
                await VisioForgeX.InitSDKAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            try
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

                // configure AVI output
                var output = new AVIOutputBlock(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.avi"));

                // add video and audio tees
                var videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                var audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);

                // connect everything
                _pipeline.Connect(videoSource, videoTee);
                _pipeline.Connect(audioSource, audioTee);

                _pipeline.Connect(videoTee, videoRenderer);
                _pipeline.Connect(audioTee, audioRenderer);

                _pipeline.Connect(videoTee, output);
                _pipeline.Connect(audioTee, output);

                // start
                await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            try
            {
                await _pipeline.StopAsync();

                await _pipeline.DisposeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }
    }
}
