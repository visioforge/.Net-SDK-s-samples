

namespace multiple_ap_cams
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Core.VideoCapture;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.VideoCapture;
    using System.Threading.Tasks;

    /// <summary>
    /// Multiple IP cameras demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        private System.Timers.Timer tmRecording1 = new System.Timers.Timer(1000);

        private System.Timers.Timer tmRecording2 = new System.Timers.Timer(1000);

        private VideoCaptureCore VideoCapture1;

        private VideoCaptureCore VideoCapture2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create engine 1 async.
        /// </summary>
        private async Task CreateEngine1Async()
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
        }

        /// <summary>
        /// Create engine 2 async.
        /// </summary>
        private async Task CreateEngine2Async()
        {
            VideoCapture2 = await VideoCaptureCore.CreateAsync(VideoView2 as IVideoView);

            VideoCapture2.OnError += VideoCapture2_OnError;
        }

        /// <summary>
        /// Destroy engine 1.
        /// </summary>
        private void DestroyEngine1()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        /// <summary>
        /// Destroy engine 2.
        /// </summary>
        private void DestroyEngine2()
        {
            if (VideoCapture2 != null)
            {
                VideoCapture2.OnError -= VideoCapture2_OnError;

                VideoCapture2.Dispose();
                VideoCapture2 = null;
            }
        }

        /// <summary>
        /// Handles the bt start 1 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + "CAM1: " + e.Message + Environment.NewLine; }));
            }
        }

        /// <summary>
        /// Handles the bt stop 1 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStop1_Click(object sender, EventArgs e)
        {
            tmRecording1.Stop();

            await VideoCapture1.StopAsync();
        }

        /// <summary>
        /// Handles the bt start 2 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Video capture 2 on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoCapture2_OnError(object sender, ErrorsEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + "CAM2: " + e.Message + Environment.NewLine; }));
            }
        }

        /// <summary>
        /// Handles the bt stop 2 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStop2_Click(object sender, EventArgs e)
        {
            tmRecording2.Stop();
            await VideoCapture2.StopAsync();
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            await CreateEngine1Async();
            await CreateEngine2Async();

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

        /// <summary>
        /// Update recording time 1.
        /// </summary>
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

        /// <summary>
        /// Update recording time 2.
        /// </summary>
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

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine1();
            DestroyEngine2();
        }
    }
}

