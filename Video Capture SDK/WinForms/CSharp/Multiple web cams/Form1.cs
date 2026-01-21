

namespace multiple_ap_cams
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.VideoCapture;

    /// <summary>
    /// Multiple web cameras demo main form.
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
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbCamera1.Text);

            var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera1.Text);
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
                VideoCapture1.Video_CaptureDevice.FrameRate = new VideoFrameRate(Convert.ToInt32(cbFrameRate1.Text));
            }
            else
            {
                VideoCapture1.Video_CaptureDevice.FrameRate = new VideoFrameRate(25);
            }

            VideoCapture1.Mode = VideoCaptureMode.VideoPreview;
            VideoCapture1.Audio_PlayAudio = false;
            VideoCapture1.Audio_RecordAudio = false;

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
                Invoke((Action)(() =>
                {
                    mmLog.Text = mmLog.Text + "CAM1: " + e.Message + Environment.NewLine;
                }));
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
            VideoCapture2.Debug_Mode = cbDebugMode.Checked;
            VideoCapture2.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture2.Video_CaptureDevice = new VideoCaptureSource(cbCamera2.Text);

            var deviceItem = VideoCapture2.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera2.Text);
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
                VideoCapture2.Video_CaptureDevice.FrameRate = new VideoFrameRate(Convert.ToDouble(cbFrameRate2.Text));
            }
            else
            {
                VideoCapture2.Video_CaptureDevice.FrameRate = new VideoFrameRate(25);
            }

            VideoCapture2.Mode = VideoCaptureMode.VideoPreview;
            VideoCapture2.Audio_PlayAudio = false;
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
                Invoke((Action)(() =>
                {
                    mmLog.Text = mmLog.Text + "CAM2: " + e.Message + Environment.NewLine;
                }));
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

            Text += $" (SDK v{VideoCapture1.SDK_Version()})";

            tmRecording1.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime1();
            };

            tmRecording2.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime2();
            };

            foreach (var device in VideoCapture1.Video_CaptureDevices())
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
        /// Handles the cb camera 1 selected index changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbCamera1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCamera1.SelectedIndex != -1)
            {
                cbVideoInputFormat1.Items.Clear();

                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera1.Text);
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

        /// <summary>
        /// Handles the cb camera 2 selected index changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbCamera2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCamera2.SelectedIndex != -1)
            {
                cbVideoInputFormat2.Items.Clear();

                var deviceItem = VideoCapture2.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera2.Text);
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

        /// <summary>
        /// Handles the cb video input format 1 selected index changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbVideoInputFormat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat1.Text))
            {
                return;
            }

            if (cbCamera1.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera1.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.Find(format => format.Name == cbVideoInputFormat1.Text);
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

        /// <summary>
        /// Handles the cb video input format 2 selected index changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbVideoInputFormat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat2.Text))
            {
                return;
            }

            if (cbCamera2.SelectedIndex != -2)
            {
                var deviceItem = VideoCapture2.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera2.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.Find(format => format.Name == cbVideoInputFormat2.Text);
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

