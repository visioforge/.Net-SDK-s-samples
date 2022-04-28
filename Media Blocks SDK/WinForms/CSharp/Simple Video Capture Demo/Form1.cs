using System;
using System.Linq;
using System.Windows.Forms;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.GST.AudioEncoders;
using VisioForge.Core.Types.GST.Sinks;
using VisioForge.Core.Types.GST.Sources;
using VisioForge.Core.Types.GST.VideoEncoders;
using VisioForge.Core.Types.MediaInfo;

namespace MediaBlocks_Simple_Video_Capture_Demo
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private SystemVideoSourceBlock _videoSource;

        private SystemAudioSourceBlock _audioSource;

        private MP4SinkBlock _mp4Muxer;

        private H264EncoderBlock _h264Encoder;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private AACEncoderBlock _aacEncoder;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            cbOutputFormat.SelectedIndex = 1;

            var videoCaptureDevices = SystemVideoSourceBlock.GetDevices(_pipeline);
            if (videoCaptureDevices.Length > 0)
            {
                foreach (var item in videoCaptureDevices)
                {
                    cbVideoInput.Items.Add(item.Name);
                }

                cbVideoInput.SelectedIndex = 0;
            }

            var audioCaptureDevices = SystemAudioSourceBlock.GetDevices(_pipeline);
            if (audioCaptureDevices.Length > 0)
            {
                foreach (var item in audioCaptureDevices)
                {
                    cbAudioInput.Items.Add(item.Name);
                }

                cbAudioInput.SelectedIndex = 0;
            }

            var audioOutputDevices = AudioRendererBlock.GetDevices(_pipeline);
            if (audioOutputDevices.Length > 0)
            {
                foreach (var item in audioOutputDevices)
                {
                    cbAudioOutput.Items.Add(item);
                }

                cbAudioOutput.SelectedIndex = 0;
            }
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            bool capture = cbOutputFormat.SelectedIndex > 0;

            mmLog.Clear();

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show("Select video input device");
                return;
            }

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInput.Text;
            var format = cbVideoFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = SystemVideoSourceBlock.GetDevices(_pipeline).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        videoSourceSettings = new VideoCaptureDeviceSourceSettings(device.Name)
                        {
                            Format = formatItem.ToFormat()
                        };

                        videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text));
                    }
                }
            }

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // audio source
            AudioCaptureDeviceSourceSettings audioSourceSettings = null;

            deviceName = cbAudioInput.Text;
            format = cbAudioFormat.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = SystemAudioSourceBlock.GetDevices(_pipeline).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        audioSourceSettings = new AudioCaptureDeviceSourceSettings(device.OriginalName, formatItem.ToFormat());
                    }
                }
            }

            _audioSource = new SystemAudioSourceBlock(audioSourceSettings);

            // video renderer
            _videoRenderer = new VideoRendererBlock(VideoView1, true);

            // audio renderer
            _audioRenderer = new AudioRendererBlock(cbAudioOutput.Text, true);

            // capture
            if (capture)
            {
                _videoTee = new TeeBlock(2);
                _audioTee = new TeeBlock(2);
                _h264Encoder = new H264EncoderBlock(new MFH264EncoderSettings());
                _aacEncoder = new AACEncoderBlock(new AACEncoderSettings());
                _mp4Muxer = new MP4SinkBlock(new MP4SinkSettings(@"c:\vf\output.mp4"));
            }

            // connect all
            if (capture)
            {
                _pipeline.Connect(_videoSource.Output, _videoTee.Input);
                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
                _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);
                _pipeline.Connect(_h264Encoder.Output, _mp4Muxer.CreateNewInput(MediaBlockPadMediaType.Video));

                _pipeline.Connect(_audioSource.Output, _audioTee.Input);
                _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
                _pipeline.Connect(_audioTee.Outputs[1], _aacEncoder.Input);
                _pipeline.Connect(_aacEncoder.Output, _mp4Muxer.CreateNewInput(MediaBlockPadMediaType.Audio));
            }
            else
            {
                _pipeline.Connect(_audioSource.Output, _audioRenderer.Input);
                _pipeline.Connect(_videoSource.Output, _videoRenderer.Input);
            }

            // start
            await _pipeline.StartAsync();

            timer1.Start();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            await _pipeline?.StopAsync();

            _pipeline?.ClearBlocks();

            VideoView1.Invalidate();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await _pipeline.PauseAsync();
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;

            var position = await _pipeline.Position_GetAsync();

            lbTime.Text = position.ToString("hh\\:mm\\:ss");

            timer1.Tag = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btStop_Click(null, null);

            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;

                _pipeline.Dispose();
                _pipeline = null;
            }
        }

        private void cbVideoInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deviceName = cbVideoInput.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                cbVideoFormat.Items.Clear();

                var device = SystemVideoSourceBlock.GetDevices(_pipeline).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    foreach (var item in device.VideoFormats)
                    {
                        cbVideoFormat.Items.Add(item.Name);
                    }

                    if (cbVideoFormat.Items.Count > 0)
                    {
                        cbVideoFormat.SelectedIndex = 0;
                    }
                }
            }
        }

        private void cbVideoFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbVideoFrameRate.Items.Clear();

            var deviceName = cbVideoInput.Text;
            var format = cbVideoFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = SystemVideoSourceBlock.GetDevices(_pipeline).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        // build int range from tuple (min, max)    
                        var frameRateList = formatItem.GetFrameRateRangeAsStringList();
                        foreach (var item in frameRateList)
                        {
                            cbVideoFrameRate.Items.Add(item);
                        }

                        if (cbVideoFrameRate.Items.Count > 0)
                        {
                            cbVideoFrameRate.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void cbAudioInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deviceName = cbAudioInput.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                cbAudioFormat.Items.Clear();

                var device = SystemAudioSourceBlock.GetDevices(_pipeline).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    foreach (var format in device.Formats)
                    {
                        cbAudioFormat.Items.Add(format.Name);
                    }

                    if (cbAudioFormat.Items.Count > 0)
                    {
                        cbAudioFormat.SelectedIndex = 0;
                    }
                }
            }
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume1.Value / 100.0;
            }
        }
    }
}
