// ReSharper disable InconsistentNaming

namespace multiple_ap_cams
{
    using System.Globalization;

    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using VisioForge.Controls.VideoCapture;
    using VisioForge.Types;
    using VisioForge.Types.Events;
    using VisioForge.Types.VideoCapture;

    public partial class Form1 : Form
    {
        private System.Timers.Timer tmRecording1 = new System.Timers.Timer(1000);

        private System.Timers.Timer tmRecording2 = new System.Timers.Timer(1000);

        private VideoCaptureCore VideoCapture1;

        private VideoCaptureCore VideoCapture2;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateEngine1()
        {
            VideoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnLicenseRequired += VideoCapture1_OnLicenseRequired;
        }

        private void CreateEngine2()
        {
            VideoCapture2 = new VideoCaptureCore(VideoView2 as IVideoView);

            VideoCapture2.OnError += VideoCapture2_OnError;
            VideoCapture2.OnLicenseRequired += VideoCapture2_OnLicenseRequired;
        }

        private void DestroyEngine1()
        {
            VideoCapture1.OnError -= VideoCapture1_OnError;
            VideoCapture1.OnLicenseRequired -= VideoCapture1_OnLicenseRequired;

            VideoCapture1.Dispose();
            VideoCapture1 = null;
        }

        private void DestroyEngine2()
        {
            VideoCapture2.OnError -= VideoCapture2_OnError;
            VideoCapture2.OnLicenseRequired -= VideoCapture2_OnLicenseRequired;

            VideoCapture2.Dispose();
            VideoCapture2 = null;
        }

        private async void btStart1_Click(object sender, EventArgs e)
        {
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbCamera1.Text);

            var deviceItem = VideoCapture1.Video_CaptureDevices.FirstOrDefault(device => device.Name == cbCamera1.Text);
            if (deviceItem == null)
            {
                return;
            }

            VideoCapture1.Video_CaptureDevice.Format_UseBest = false;
            if (cbVideoInputFormat1.SelectedIndex != -1)
            {
                VideoCapture1.Video_CaptureDevice.Format = cbVideoInputFormat1.Text;
            }
            else
            {
                VideoCapture1.Video_CaptureDevice.Format = string.Empty;
            }

            if (cbFrameRate1.SelectedIndex != -1)
            {
                VideoCapture1.Video_CaptureDevice.FrameRate = Convert.ToInt32(cbFrameRate1.Text);
            }
            else
            {
                VideoCapture1.Video_CaptureDevice.FrameRate = 25;
            }

            VideoCapture1.Mode = VideoCaptureMode.VideoPreview;
            VideoCapture1.Audio_PlayAudio = false;
            VideoCapture1.Audio_RecordAudio = false;

            await VideoCapture1.StartAsync();

            tmRecording1.Start();
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() =>
                {
                    mmLog.Text = mmLog.Text + "CAM1: " + e.Message + Environment.NewLine;
                }));
            }
        }

        private async void btStop1_Click(object sender, EventArgs e)
        {
            tmRecording1.Stop();

            await VideoCapture1.StopAsync();
        }

        private async void btStart2_Click(object sender, EventArgs e)
        {
            VideoCapture2.Debug_Mode = cbDebugMode.Checked;
            VideoCapture2.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture2.Video_CaptureDevice = new VideoCaptureSource(cbCamera2.Text);

            var deviceItem = VideoCapture2.Video_CaptureDevices.FirstOrDefault(device => device.Name == cbCamera2.Text);
            if (deviceItem == null)
            {
                return;
            }

            VideoCapture2.Video_CaptureDevice.Format_UseBest = false;
            if (cbVideoInputFormat2.SelectedIndex != -1)
            {
                VideoCapture2.Video_CaptureDevice.Format = cbVideoInputFormat2.Text;
            }
            else
            {
                VideoCapture2.Video_CaptureDevice.Format = string.Empty;
            }

            if (cbFrameRate2.SelectedIndex != -1)
            {
                VideoCapture2.Video_CaptureDevice.FrameRate = Convert.ToInt32(cbFrameRate2.Text);
            }
            else
            {
                VideoCapture2.Video_CaptureDevice.FrameRate = 25;
            }

            VideoCapture2.Mode = VideoCaptureMode.VideoPreview;
            VideoCapture2.Audio_PlayAudio = false;
            await VideoCapture2.StartAsync();

            tmRecording2.Start();
        }

        private void VideoCapture2_OnError(object sender, ErrorsEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() =>
                {
                    mmLog.Text = mmLog.Text + "CAM2: " + e.Message + Environment.NewLine;
                }));
            }
        }

        private async void btStop2_Click(object sender, EventArgs e)
        {
            tmRecording2.Stop();

            await VideoCapture2.StopAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine1();
            CreateEngine2();

            Text += $" (SDK v{VideoCapture1.SDK_Version})";

            tmRecording1.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime1();
            };

            tmRecording2.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime2();
            };

            foreach (var device in VideoCapture1.Video_CaptureDevices)
            {
                cbCamera1.Items.Add(device.Name);
                cbCamera2.Items.Add(device.Name);
            }

            if (cbCamera1.Items.Count > 0)
            {
                cbCamera1.SelectedIndex = 0;
                cbCamera2.SelectedIndex = 0;
            }

            VideoCapture1.Video_Renderer_SetAuto();
            VideoCapture2.Video_Renderer_SetAuto();
        }

        private void VideoCapture1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() =>
                {
                    mmLog.Text += "(NOT ERROR) LICENSING:" + Environment.NewLine + e.Message + Environment.NewLine;
                }));
            }
        }

        private void VideoCapture2_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() =>
                {
                    mmLog.Text += "(NOT ERROR) LICENSING:" + Environment.NewLine + e.Message + Environment.NewLine;
                }));
            }
        }

        private void UpdateRecordingTime1()
        {
            if (IsHandleCreated)
            {
                var ts = VideoCapture1.Duration_Time();

                if (Math.Abs(ts.TotalMilliseconds) < 0.01)
                {
                    return;
                }

                BeginInvoke(
                    (Action)(() =>
                                    {
                                        lbTimestamp1.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
                                    }));
            }
        }

        private void UpdateRecordingTime2()
        {
            if (IsHandleCreated)
            {
                var ts = VideoCapture2.Duration_Time();

                if (Math.Abs(ts.TotalMilliseconds) < 0.01)
                {
                    return;
                }

                BeginInvoke(
                    (Action)(() =>
                                    {
                                        lbTimestamp2.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
                                    }));
            }
        }

        private void cbCamera1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCamera1.SelectedIndex != -1)
            {
                cbVideoInputFormat1.Items.Clear();

                var deviceItem = VideoCapture1.Video_CaptureDevices.FirstOrDefault(device => device.Name == cbCamera1.Text);
                if (deviceItem == null)
                {
                    return;
                }

                foreach (var format in deviceItem.VideoFormats)
                {
                    cbVideoInputFormat1.Items.Add(format.Name);
                }

                if (cbVideoInputFormat1.Items.Count > 0)
                {
                    cbVideoInputFormat1.SelectedIndex = 0;
                }
            }
        }

        private void cbCamera2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCamera2.SelectedIndex != -1)
            {
                cbVideoInputFormat2.Items.Clear();

                var deviceItem = VideoCapture2.Video_CaptureDevices.FirstOrDefault(device => device.Name == cbCamera2.Text);
                if (deviceItem == null)
                {
                    return;
                }

                foreach (var format in deviceItem.VideoFormats)
                {
                    cbVideoInputFormat2.Items.Add(format.Name);
                }

                if (cbVideoInputFormat2.Items.Count > 0)
                {
                    cbVideoInputFormat2.SelectedIndex = 0;
                }
            }
        }

        private void cbVideoInputFormat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat1.Text))
            {
                return;
            }

            if (cbCamera1.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevices.FirstOrDefault(device => device.Name == cbCamera1.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbVideoInputFormat1.Text);
                if (videoFormat == null)
                {
                    return;
                }

                cbFrameRate1.Items.Clear();
                foreach (var frameRate in videoFormat.FrameRates)
                {
                    cbFrameRate1.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture));
                }

                if (cbFrameRate1.Items.Count > 0)
                {
                    cbFrameRate1.SelectedIndex = 0;
                }
            }
        }

        private void cbVideoInputFormat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat2.Text))
            {
                return;
            }

            if (cbCamera2.SelectedIndex != -2)
            {
                var deviceItem = VideoCapture2.Video_CaptureDevices.FirstOrDefault(device => device.Name == cbCamera2.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbVideoInputFormat2.Text);
                if (videoFormat == null)
                {
                    return;
                }

                cbFrameRate2.Items.Clear();
                foreach (var frameRate in videoFormat.FrameRates)
                {
                    cbFrameRate2.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture));
                }

                if (cbFrameRate2.Items.Count > 0)
                {
                    cbFrameRate2.SelectedIndex = 0;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine1();
            DestroyEngine2();
        }
    }
}

// ReSharper restore InconsistentNaming