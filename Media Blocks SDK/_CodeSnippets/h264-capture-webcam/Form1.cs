using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using VisioForge.Core;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types;
using VisioForge.Core.MediaBlocks.VideoDecoders;
using VisioForge.Core.Types.X.VideoDecoders;

using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace h264_capture_webcam
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private List<VideoCaptureDeviceInfo> _videoSources;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await VisioForgeX.InitSDKAsync();

            edOutputFile.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

            await AddVideoSourcesAsync();

            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
        }

        private async Task AddVideoSourcesAsync()
        {
            _videoSources = (await DeviceEnumerator.Shared.VideoSourcesAsync()).Where(x => x.API == VideoCaptureDeviceAPI.KS).ToList();
            foreach (var source in _videoSources)
            {
                    cbVideoInputDevice.Items.Add(source.Name);                
            }

            if (cbVideoInputDevice.Items.Count > 0)
            {
                cbVideoInputDevice.SelectedIndex = 0;
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            // Create the pipeline
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInputDevice.Text;
            var format = cbVideoInputFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = _videoSources.Find(x => x.Name == deviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.ToList().Find(x => x.Name == format);
                    if (formatItem != null)
                    {
                        videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                        {
                            Format = formatItem.ToFormat()
                        };

                        videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text));

                        // Disable H264 decoder, because if we are capturing H264, we don't need to decode it.
                        videoSourceSettings.DisableH264Decoder = true;
                    }
                }
            }

            if (videoSourceSettings == null)
            {
                MessageBox.Show("Please select video source and format.");
                return;
            }

            var videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // Add video renderer and specify VideoView control
            var videoRenderer = new VideoRendererBlock(_pipeline, videoView: VideoView1);

            // Add video tee
            var videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            // Add H264 decoder
            var h264Decoder = new H264DecoderBlock(new FFMPEGH264DecoderSettings());

            // Add MP4 sink
            var mp4sink = new MP4SinkBlock(edOutputFile.Text);

            // Connect everything
            _pipeline.Connect(videoSource, videoTee);
            _pipeline.Connect(videoTee, h264Decoder);
            _pipeline.Connect(h264Decoder, videoRenderer);
            _pipeline.Connect(videoTee.Outputs[1], mp4sink.CreateNewInput(MediaBlockPadMediaType.Video));

            // Start MP4 recording
            await _pipeline.StartAsync();
        }

        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine("Error: " + e.Message);
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            await _pipeline.StopAsync();

            await _pipeline.DisposeAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;

                _pipeline.Dispose();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

        private void cbVideoInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbVideoInputFormat.Items.Clear();

            var deviceItem = _videoSources.Find(device => device.Name == cbVideoInputDevice.Text);
            if (deviceItem == null)
            {
                return;
            }

            foreach (var format in deviceItem.VideoFormats)
            {
                if (!format.Name.Contains("H264"))
                {
                    continue;
                }

                cbVideoInputFormat.Items.Add(format.Name);
            }

            if (cbVideoInputFormat.Items.Count > 0)
            {
                cbVideoInputFormat.SelectedIndex = 0;
                cbVideoInputFormat_SelectedIndexChanged(null, null);
            }
        }

        private void cbVideoInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat.Text))
            {
                return;
            }

            cbVideoInputFrameRate.Items.Clear();

            if (string.IsNullOrEmpty(cbVideoInputFormat.Text) || string.IsNullOrEmpty(cbVideoInputDevice.Text))
            {
                return;
            }

            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                var deviceItem = _videoSources.Find(device => device.Name == cbVideoInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.Find(format => format.Name == cbVideoInputFormat.Text);
                if (videoFormat == null)
                {
                    return;
                }

                // build int range from tuple (min, max)    
                var frameRateList = videoFormat.GetFrameRateRangeAsStringList();
                foreach (var item in frameRateList)
                {
                    cbVideoInputFrameRate.Items.Add(item);
                }

                if (cbVideoInputFrameRate.Items.Count > 0)
                {
                    cbVideoInputFrameRate.SelectedIndex = 0;
                }
            }
        }
    }
}
