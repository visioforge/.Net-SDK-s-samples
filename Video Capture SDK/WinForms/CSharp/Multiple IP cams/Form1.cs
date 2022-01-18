// ReSharper disable InconsistentNaming

namespace multiple_ap_cams
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Core.VideoCapture;
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
        }

        private void CreateEngine2()
        {
            VideoCapture2 = new VideoCaptureCore(VideoView2 as IVideoView);

            VideoCapture2.OnError += VideoCapture2_OnError;
        }

        private void DestroyEngine1()
        {
            VideoCapture1.OnError -= VideoCapture1_OnError;

            VideoCapture1.Dispose();
            VideoCapture1 = null;
        }

        private void DestroyEngine2()
        {
            VideoCapture2.OnError -= VideoCapture2_OnError;

            VideoCapture2.Dispose();
            VideoCapture2 = null;
        }

        private async void btStart1_Click(object sender, EventArgs e)
        {
            VideoCapture1.IP_Camera_Source = new IPCameraSourceSettings
            {
                URL = new Uri(edURL1.Text),
                Type = IPSourceEngine.Auto_LAV,
                Login = edLogin1.Text,
                Password = edPassword1.Text
            };

            VideoCapture1.Mode = VideoCaptureMode.IPPreview;
            VideoCapture1.Audio_PlayAudio = false;
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            await VideoCapture1.StartAsync();

            tmRecording1.Start();
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + "CAM1: " + e.Message + Environment.NewLine; }));
            }
        }

        private async void btStop1_Click(object sender, EventArgs e)
        {
            tmRecording1.Stop();

            await VideoCapture1.StopAsync();
        }

        private async void btStart2_Click(object sender, EventArgs e)
        {
            VideoCapture2.IP_Camera_Source = new IPCameraSourceSettings
            {
                URL = new Uri(edURL2.Text),
                Type = IPSourceEngine.Auto_LAV,
                Login = edLogin2.Text,
                Password = edPassword2.Text
            };
            VideoCapture2.Mode = VideoCaptureMode.IPPreview;
            VideoCapture2.Audio_PlayAudio = false;
            VideoCapture2.Debug_Mode = cbDebugMode.Checked;
            VideoCapture2.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            await VideoCapture2.StartAsync();

            tmRecording2.Start();
        }

        private void VideoCapture2_OnError(object sender, ErrorsEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + "CAM2: " + e.Message + Environment.NewLine; }));
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

            Text += $" (SDK v{VideoCapture2.SDK_Version()})";

            tmRecording1.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime1();
            };

            tmRecording2.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime2();
            };

            VideoCapture1.Video_Renderer_SetAuto();
            VideoCapture2.Video_Renderer_SetAuto();
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine1();
            DestroyEngine2();
        }
    }
}

// ReSharper restore InconsistentNaming