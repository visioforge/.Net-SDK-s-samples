// ReSharper disable InconsistentNaming

namespace multiple_ap_cams
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Types;
    using VisioForge.Types.Sources;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly System.Timers.Timer tmRecording1 = new System.Timers.Timer(1000);

        private readonly System.Timers.Timer tmRecording2 = new System.Timers.Timer(1000);


        // private const string url = "http://212.162.177.75/mjpg/video.mjpg";
        // private const string url = "rtsp://media1.law.harvard.edu/Media/policy_a/2012/02/02_unger.mov";

        private async void btStart1_Click(object sender, EventArgs e)
        {
            videoCapture1.IP_Camera_Source = new IPCameraSourceSettings
            {
                URL = edURL1.Text,
                Type = VFIPSource.Auto_LAV
            };
            videoCapture1.Mode = VFVideoCaptureMode.IPPreview;
            videoCapture1.Audio_PlayAudio = false;
            videoCapture1.Debug_Mode = cbDebugMode.Checked;
            videoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            await videoCapture1.StartAsync();

            tmRecording1.Start();
        }

        private void VideoCapture1OnOnError(object sender, ErrorsEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + "CAM1: " + e.Message + Environment.NewLine; }));
            }
        }

        private async void btStop1_Click(object sender, EventArgs e)
        {
            tmRecording1.Stop();

            await videoCapture1.StopAsync();
        }

        private async void btStart2_Click(object sender, EventArgs e)
        {
            videoCapture2.IP_Camera_Source = new IPCameraSourceSettings
            {
                URL = edURL2.Text,
                Type = VFIPSource.Auto_LAV
            };
            videoCapture2.Mode = VFVideoCaptureMode.IPPreview;
            videoCapture2.Audio_PlayAudio = false;
            videoCapture2.Debug_Mode = cbDebugMode.Checked;
            videoCapture2.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            await videoCapture2.StartAsync();

            tmRecording2.Start();
        }

        private void VideoCapture2OnOnError(object sender, ErrorsEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + "CAM2: " + e.Message + Environment.NewLine; }));
            }
        }

        private async void btStop2_Click(object sender, EventArgs e)
        {
            tmRecording2.Stop();
            await videoCapture2.StopAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + videoCapture2.SDK_Version + ", " + videoCapture2.SDK_State + ")";

            tmRecording1.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime1();
            };

            tmRecording2.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime2();
            };

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
    }
}

// ReSharper restore InconsistentNaming