using Gst;
using System;

using System.IO;
using System.Linq;
using System.Windows.Forms;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;

namespace MediaBlocks_Simple_Video_Capture_Demo
{
    public partial class Form1 : Form
    {
        private DeviceEnumerator _deviceEnumerator;

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

        private Element _fakeSink;

        public Form1()
        {
            InitializeComponent();

            _deviceEnumerator = new DeviceEnumerator();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            var videoCaptureDevices = await SystemVideoSourceBlock.GetDevicesAsync(_deviceEnumerator);
            if (videoCaptureDevices.Length > 0)
            {
                foreach (var item in videoCaptureDevices)
                {
                    cbVideoInput.Items.Add(item.DisplayName);
                }

                cbVideoInput.SelectedIndex = 0;
            }

            var audioCaptureDevices = await SystemAudioSourceBlock.GetDevicesAsync(_deviceEnumerator, AudioCaptureDeviceAPI.DirectSound);
            if (audioCaptureDevices.Length > 0)
            {
                foreach (var item in audioCaptureDevices)
                {
                    cbAudioInput.Items.Add(item.DisplayName);
                }

                cbAudioInput.SelectedIndex = 0;
            }

            var audioOutputDevices = await AudioRendererBlock.GetDevicesAsync(_deviceEnumerator, AudioOutputDeviceAPI.DirectSound);
            if (audioOutputDevices.Length > 0)
            {
                foreach (var item in audioOutputDevices)
                {
                    cbAudioOutput.Items.Add(item.DisplayName);
                }

                cbAudioOutput.SelectedIndex = 0;
            }

            edFilename.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
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
            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += Pipeline_OnError;

            bool capture = cbCapture.Checked;

            mmLog.Clear();

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select video input device");
                return;
            }

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInput.Text;
            var format = cbVideoFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = (await SystemVideoSourceBlock.GetDevicesAsync(_deviceEnumerator)).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                        {
                            Format = formatItem.ToFormat()
                        };

                        videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text));
                    }
                }
            }

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // audio source
            DSAudioCaptureDeviceSourceSettings audioSourceSettings = null;

            deviceName = cbAudioInput.Text;
            format = cbAudioFormat.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = (await SystemAudioSourceBlock.GetDevicesAsync(_deviceEnumerator, AudioCaptureDeviceAPI.DirectSound)).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        audioSourceSettings = new DSAudioCaptureDeviceSourceSettings(device, formatItem.ToFormat());
                    }
                }
            }

            _audioSource = new SystemAudioSourceBlock(audioSourceSettings);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            // audio renderer
            var audioOutputDevice = (await AudioRendererBlock.GetDevicesAsync(_deviceEnumerator, AudioOutputDeviceAPI.DirectSound)).FirstOrDefault(x => x.DisplayName == cbAudioOutput.Text);
            _audioRenderer = new AudioRendererBlock(audioOutputDevice);

            // capture
            if (capture)
            {
                _videoTee = new TeeBlock(2);
                _audioTee = new TeeBlock(2);
                _h264Encoder = new H264EncoderBlock(new MFH264EncoderSettings());
                _aacEncoder = new AACEncoderBlock(new MFAACEncoderSettings());
                _mp4Muxer = new MP4SinkBlock(new MP4SinkSettings(edFilename.Text));
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

                _pipeline.Connect(_audioSource.Output, _audioRenderer.Input);
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

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                _pipeline.ClearBlocks();

                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.DisposeAsync();

                _pipeline = null;
            }

            VideoView1.Invalidate();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            if (_pipeline != null)
            {
                await _pipeline.PauseAsync();
            }
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            if (_pipeline != null)
            {
                await _pipeline.ResumeAsync();
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;

            if (_pipeline != null)
            {
                var position = await _pipeline.Position_GetAsync();
                lbTime.Text = position.ToString("hh\\:mm\\:ss");
            }

            timer1.Tag = 0;
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();

            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            VideoView1.Invalidate();

            if (_deviceEnumerator != null)
            {
                _deviceEnumerator.Dispose();
                _deviceEnumerator = null;
            }
        }

        private async void cbVideoInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deviceName = cbVideoInput.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                cbVideoFormat.Items.Clear();

                var device = (await SystemVideoSourceBlock.GetDevicesAsync(_deviceEnumerator)).FirstOrDefault(x => x.DisplayName == deviceName);
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

        private async void cbVideoFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbVideoFrameRate.Items.Clear();

            var deviceName = cbVideoInput.Text;
            var format = cbVideoFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = (await SystemVideoSourceBlock.GetDevicesAsync(_deviceEnumerator)).FirstOrDefault(x => x.DisplayName == deviceName);
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

        private async void cbAudioInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deviceName = cbAudioInput.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                cbAudioFormat.Items.Clear();

                var device = (await SystemAudioSourceBlock.GetDevicesAsync(_deviceEnumerator, AudioCaptureDeviceAPI.DirectSound)).FirstOrDefault(x => x.DisplayName == deviceName);
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
            //if (_audioRenderer != null)
            //{
            //    _audioRenderer.Volume = tbVolume.Value / 100.0;
            //}
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "MP4 files (*.mp4)|*.mp4|WebM files (*.webm)|*.mp4|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = dialog.FileName;
            }
        }
    }
}
