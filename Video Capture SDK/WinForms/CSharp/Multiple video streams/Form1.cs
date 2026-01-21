





using System.Globalization;

namespace multiple_video_streams
{
    using Properties;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.VideoCapture;

    /// <summary>
    /// Multiple video streams demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        private VideoCaptureCore videoCaptureHelper;

        private VideoCaptureCore VideoCapture1;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnVideoFrameBitmap += VideoCapture1_OnVideoFrameBitmap;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;
                VideoCapture1.OnVideoFrameBitmap -= VideoCapture1_OnVideoFrameBitmap;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, EventArgs e)
        {
            // 1st device
            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbCamera1.Text);
            VideoCapture1.Video_CaptureDevice.Format_UseBest = false;
            VideoCapture1.Video_CaptureDevice.Format = cbVideoFormat1.Text;
            VideoCapture1.Video_CaptureDevice.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate1.Text));

            // 2nd device
            VideoCapture1.PIP_Sources_Add_VideoCaptureDevice(
                cbCamera2.Text,
                cbVideoFormat2.Text,
                false,
                new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate1.Text)),
                cbCamera2.Text,
                0,
                0,
                320,
                240);

            var wmvOutput = new WMVOutput
            {
                Mode = WMVMode.ExternalProfileFromText,
                External_Profile_Text = Resources.WMVProfile
            };
            VideoCapture1.Output_Format = wmvOutput;

            // main options
            VideoCapture1.OnError += VideoCapture1_OnError;

            VideoCapture1.Output_Filename = edFilename.Text;
            VideoCapture1.Mode = VideoCaptureMode.VideoCapture;
            VideoCapture1.PIP_Mode = PIPMode.MultipleVideoStreams;
            VideoCapture1.PIP_AddSampleGrabbers = true;
            VideoCapture1.Audio_PlayAudio = false;
            VideoCapture1.Audio_RecordAudio = false;

            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            await VideoCapture1.StartAsync();
            tmRecording.Start();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, EventArgs e)
        {
            tmRecording.Stop();
            await VideoCapture1.StopAsync();

            videoScreen2.Image = null;
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            await CreateEngineAsync();

            videoCaptureHelper = new VideoCaptureCore();
            Text += $" (SDK v{videoCaptureHelper.SDK_Version()})";

            foreach (var device in videoCaptureHelper.Video_CaptureDevices())
            {
                cbCamera1.Items.Add(device.Name);
                cbCamera2.Items.Add(device.Name);
            }

            if (cbCamera1.Items.Count > 0)
            {
                cbCamera1.SelectedIndex = 0;
                cbCamera2.SelectedIndex = 0;
            }

            edFilename.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "multiple_video_streams.wmv");

            VideoCapture1.Video_Renderer_SetAuto();

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };
        }

        /// <summary>
        /// Handles the cb camera 1 selected index changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbCamera1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deviceItem = videoCaptureHelper.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera1.Text);
            if (deviceItem == null)
            {
                return;
            }

            var formats = deviceItem.VideoFormats;

            cbVideoFormat1.Items.Clear();
            foreach (var format in formats)
            {
                cbVideoFormat1.Items.Add(format);
            }

            if (cbVideoFormat1.Items.Count > 0)
            {
                cbVideoFormat1.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Handles the cb camera 2 selected index changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbCamera2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deviceItem = videoCaptureHelper.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera2.Text);
            if (deviceItem == null)
            {
                return;
            }

            var formats = deviceItem.VideoFormats;

            cbVideoFormat2.Items.Clear();
            foreach (var format in formats)
            {
                cbVideoFormat2.Items.Add(format);
            }

            if (cbVideoFormat2.Items.Count > 4)
            {
                cbVideoFormat2.SelectedIndex = 4;
            }
        }

        /// <summary>
        /// Video capture 1 on video frame bitmap.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="VideoFrameBitmapEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnVideoFrameBitmap(object sender, VideoFrameBitmapEventArgs e)
        {
            if (e.SourceStream == VideoStreamType.PIP1)
            {
                videoScreen2.Image = e.Frame;
            }
        }

        /// <summary>
        /// Log.
        /// </summary>
        /// <param name="txt">The text.</param>
        private void Log(string txt)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { edLog.Text = edLog.Text + txt + Environment.NewLine; }));
            }
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Update recording time.
        /// </summary>
        private void UpdateRecordingTime()
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
                                        lbTimestamp.Text = $"Recording time: " + ts.ToString(@"hh\:mm\:ss");
                                    }));
            }
        }

        /// <summary>
        /// Handles the cb video format 1 selected index changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbVideoFormat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoFormat1.Text))
            {
                return;
            }

            if (cbVideoFormat1.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera1.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.Find(format => format.Name == cbVideoFormat1.Text);
                if (videoFormat == null)
                {
                    return;
                }

                cbVideoFrameRate1.Items.Clear();
                foreach (var frameRate in videoFormat.FrameRates)
                {
                    cbVideoFrameRate1.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture));
                }

                if (cbVideoFrameRate1.Items.Count > 0)
                {
                    cbVideoFrameRate1.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Handles the cb video format 2 selected index changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbVideoFormat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoFormat2.Text))
            {
                return;
            }

            if (cbVideoFormat2.SelectedIndex != -2)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbCamera2.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.Find(format => format.Name == cbVideoFormat2.Text);
                if (videoFormat == null)
                {
                    return;
                }

                cbVideoFrameRate2.Items.Clear();
                foreach (var frameRate in videoFormat.FrameRates)
                {
                    cbVideoFrameRate2.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture));
                }

                if (cbVideoFrameRate2.Items.Count > 0)
                {
                    cbVideoFrameRate2.SelectedIndex = 0;
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
            DestroyEngine();
        }
    }
}

