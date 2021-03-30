// ReSharper disable InconsistentNaming

using System.Globalization;

namespace multiple_ap_cams
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;

    public partial class Form1 : Form
    {
        private readonly System.Timers.Timer tmRecording1 = new System.Timers.Timer(1000);

        private readonly System.Timers.Timer tmRecording2 = new System.Timers.Timer(1000);

        public Form1()
        {
            InitializeComponent();
        }

        private async void btStart1_Click(object sender, EventArgs e)
        {
            videoCapture1.Debug_Mode = cbDebugMode.Checked;
            videoCapture1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";

            videoCapture1.Video_CaptureDevice = cbCamera1.Text;

            var deviceItem = videoCapture1.Video_CaptureDevicesInfo.First(device => device.Name == cbCamera1.Text);
            if (deviceItem == null)
            {
                return;
            }

            videoCapture1.Video_CaptureDevice_Format_UseBest = false;
            if (cbVideoInputFormat1.SelectedIndex != -1)
            {
                videoCapture1.Video_CaptureDevice_Format = cbVideoInputFormat1.Text;
            }
            else
            {
                videoCapture1.Video_CaptureDevice_Format = string.Empty;
            }

            if (cbFrameRate1.SelectedIndex != -1)
            {
                videoCapture1.Video_CaptureDevice_FrameRate = Convert.ToInt32(cbFrameRate1.Text);
            }
            else
            {
                videoCapture1.Video_CaptureDevice_FrameRate = 25;
            }

            videoCapture1.OnError += VideoCapture1OnOnError;
            videoCapture1.Mode = VFVideoCaptureMode.VideoPreview;
            videoCapture1.Audio_PlayAudio = false;
            videoCapture1.Audio_RecordAudio = false;

            await videoCapture1.StartAsync();

            tmRecording1.Start();
        }

        private void VideoCapture1OnOnError(object sender, ErrorsEventArgs e)
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

            await videoCapture1.StopAsync();
        }

        private async void btStart2_Click(object sender, EventArgs e)
        {
            videoCapture2.Debug_Mode = cbDebugMode.Checked;
            videoCapture2.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";

            videoCapture2.Video_CaptureDevice = cbCamera2.Text;

            var deviceItem = videoCapture2.Video_CaptureDevicesInfo.First(device => device.Name == cbCamera2.Text);
            if (deviceItem == null)
            {
                return;
            }

            videoCapture2.Video_CaptureDevice_Format_UseBest = false;
            if (cbVideoInputFormat2.SelectedIndex != -1)
            {
                videoCapture2.Video_CaptureDevice_Format = cbVideoInputFormat2.Text;
            }
            else
            {
                videoCapture2.Video_CaptureDevice_Format = string.Empty;
            }

            if (cbFrameRate2.SelectedIndex != -1)
            {
                videoCapture2.Video_CaptureDevice_FrameRate = Convert.ToInt32(cbFrameRate2.Text);
            }
            else
            {
                videoCapture2.Video_CaptureDevice_FrameRate = 25;
            }

            videoCapture2.OnError += VideoCapture2OnOnError;
            videoCapture2.Mode = VFVideoCaptureMode.VideoPreview;
            videoCapture2.Audio_PlayAudio = false;
            await videoCapture2.StartAsync();

            tmRecording2.Start();
        }

        private void VideoCapture2OnOnError(object sender, ErrorsEventArgs e)
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

            await videoCapture2.StopAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + videoCapture1.SDK_Version + ", " + videoCapture1.SDK_State + ")";

            tmRecording1.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime1();
            };

            tmRecording2.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime2();
            };

            foreach (var device in videoCapture1.Video_CaptureDevicesInfo)
            {
                cbCamera1.Items.Add(device.Name);
                cbCamera2.Items.Add(device.Name);
            }

            if (cbCamera1.Items.Count > 0)
            {
                cbCamera1.SelectedIndex = 0;
                cbCamera2.SelectedIndex = 0;
            }

            videoCapture1.Video_Renderer_SetAuto();
            videoCapture2.Video_Renderer_SetAuto();
        }

        private void videoCapture1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() =>
                {
                    mmLog.Text += "(NOT ERROR) LICENSING:" + Environment.NewLine + e.Message + Environment.NewLine;
                }));
            }
        }

        private void videoCapture2_OnLicenseRequired(object sender, LicenseEventArgs e)
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
                var ts = videoCapture1.Duration_Time();

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
                var ts = videoCapture2.Duration_Time();

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

                var deviceItem = videoCapture1.Video_CaptureDevicesInfo.First(device => device.Name == cbCamera1.Text);
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

                var deviceItem = videoCapture2.Video_CaptureDevicesInfo.First(device => device.Name == cbCamera2.Text);
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
                var deviceItem = videoCapture1.Video_CaptureDevicesInfo.First(device => device.Name == cbCamera1.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.First(format => format.Name == cbVideoInputFormat1.Text);
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
                var deviceItem = videoCapture2.Video_CaptureDevicesInfo.First(device => device.Name == cbCamera2.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.First(format => format.Name == cbVideoInputFormat2.Text);
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
    }
}

// ReSharper restore InconsistentNaming