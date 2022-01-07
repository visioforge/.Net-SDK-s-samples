using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace webcam_preview
{
    using System.IO;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Types;
    using VisioForge.Types.Events;
    using VisioForge.Types.VideoCapture;

    public partial class Form1 : Form
    {
        private VideoCaptureCore VideoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
        }

        private void DestroyEngine()
        {
            VideoCapture1.OnError -= VideoCapture1_OnError;
 
            VideoCapture1.Dispose();
            VideoCapture1 = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{VideoCapture1.SDK_Version})";

            // enumerate devices
            foreach (var device in VideoCapture1.Video_CaptureDevices)
            {
                cbVideoInputDevice.Items.Add(device.Name);
            }

            if (cbVideoInputDevice.Items.Count > 0)
            {
                cbVideoInputDevice.SelectedIndex = 0;
            }

            foreach (var device in VideoCapture1.Audio_CaptureDevices)
            {
                cbAudioInputDevice.Items.Add(device.Name);
            }
            
            if (cbAudioInputDevice.Items.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
            }
        }

        private void cbVideoInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            // fill video formats and frame rates
            var deviceItem = VideoCapture1.Video_CaptureDevices.FirstOrDefault(device => device.Name == cbVideoInputDevice.Text);
            if (deviceItem == null)
            {
                return;
            }

            cbVideoInputFormat.Items.Clear();
            foreach (var format in deviceItem.VideoFormats)
            {
                cbVideoInputFormat.Items.Add(format.Name);
            }
            
            if (cbVideoInputFormat.Items.Count > 0)
            {
                cbVideoInputFormat.SelectedIndex = 0;
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            // set debug settings
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            VideoCapture1.Debug_Telemetry = cbTelemetry.Checked;
            mmLog.Clear();

            // configure video source
            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbVideoInputDevice.Text);
            VideoCapture1.Video_CaptureDevice.Format = cbVideoInputFormat.Text;
            VideoCapture1.Video_CaptureDevice.Format_UseBest = cbUseBestVideoInputFormat.Checked;
            VideoCapture1.Video_CaptureDevice.FrameRate = Convert.ToDouble(cbVideoInputFrameRate.Text, CultureInfo.CurrentCulture);

            // configure audio source
            VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(cbAudioInputDevice.Text);
            VideoCapture1.Audio_CaptureDevice.Format = cbAudioInputFormat.Text;
            VideoCapture1.Audio_CaptureDevice.Format_UseBest = cbUseBestAudioInputFormat.Checked;
            VideoCapture1.Audio_CaptureDevice.Line = cbAudioInputLine.Text;
            
            // set video preview mode
            VideoCapture1.Mode = VideoCaptureMode.VideoPreview;

            // start
            await VideoCapture1.StartAsync();
        }

        private void cbAudioInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAudioInputFormat.Items.Clear();
            cbAudioInputLine.Items.Clear();

            if (cbAudioInputDevice.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Audio_CaptureDevices.FirstOrDefault(device => device.Name == cbAudioInputDevice.Text);
                if (deviceItem != null)
                {
                    foreach (string format in deviceItem.Formats)
                    {
                        cbAudioInputFormat.Items.Add(format);
                    }

                    if (cbAudioInputFormat.Items.Count > 0)
                    {
                        cbAudioInputFormat.SelectedIndex = 0;
                    }

                    foreach (string line in deviceItem.Lines)
                    {
                        cbAudioInputLine.Items.Add(line);
                    }

                    if (cbAudioInputLine.Items.Count > 0)
                    {
                        cbAudioInputLine.SelectedIndex = 0;
                    }
                }
            }
        }

        private void Log(string txt)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
            }
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await VideoCapture1.StopAsync();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        private void cbVideoInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat.Text))
            {
                return;
            }

            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevices.FirstOrDefault(device => device.Name == cbVideoInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbVideoInputFormat.Text);
                if (videoFormat == null)
                {
                    return;
                }

                cbVideoInputFrameRate.Items.Clear();
                foreach (var frameRate in videoFormat.FrameRates)
                {
                    cbVideoInputFrameRate.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture));
                }

                if (cbVideoInputFrameRate.Items.Count > 0)
                {
                    cbVideoInputFrameRate.SelectedIndex = 0;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}
