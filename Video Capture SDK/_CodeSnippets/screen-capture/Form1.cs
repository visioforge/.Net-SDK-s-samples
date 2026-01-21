using System;
using System.Linq;
using System.Windows.Forms;



namespace screen_capture
{
    using System.IO;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.VideoCapture;

    /// <summary>
    /// Screen capture demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        private VideoCaptureCore VideoCapture1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{VideoCapture1.SDK_Version()})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

            foreach (var screen in Screen.AllScreens)
            {
                cbScreenCaptureDisplayIndex.Items.Add(screen.DeviceName.Replace(@"\\.\DISPLAY", string.Empty));
            }

            cbScreenCaptureDisplayIndex.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            VideoCapture1.Debug_Telemetry = cbTelemetry.Checked;

            // configure source
            var screenSource = new ScreenCaptureSourceSettings();

            screenSource.Mode = ScreenCaptureMode.Screen;

            screenSource.FullScreen = rbScreenFullScreen.Checked;
            screenSource.Top = Convert.ToInt32(edScreenTop.Text);
            screenSource.Bottom = Convert.ToInt32(edScreenBottom.Text);
            screenSource.Left = Convert.ToInt32(edScreenLeft.Text);
            screenSource.Right = Convert.ToInt32(edScreenRight.Text);

            screenSource.DisplayIndex = Convert.ToInt32(cbScreenCaptureDisplayIndex.Text);
            screenSource.FrameRate = new VideoFrameRate(Convert.ToInt32(edScreenFrameRate.Text));
            screenSource.GrabMouseCursor = cbScreenCapture_GrabMouseCursor.Checked;
            screenSource.AllowDesktopDuplicationEngine = cbScreenCapture_DesktopDuplication.Checked;
            VideoCapture1.Screen_Capture_Source = screenSource;

            // audio capture
            if (cbAudioCapture.Checked)
            {
                VideoCapture1.Audio_PlayAudio = false;
                VideoCapture1.Audio_RecordAudio = true;

                // select first audio device with default parameters
                if (VideoCapture1.Audio_CaptureDevices().Any())
                {
                    VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(VideoCapture1.Audio_CaptureDevices()[0].Name);
                }
            }
            else
            {
                VideoCapture1.Audio_PlayAudio = false;
                VideoCapture1.Audio_RecordAudio = false;
            }

            // configure output
            if (cbCapture.Checked)
            {
                VideoCapture1.Mode = VideoCaptureMode.ScreenCapture;
                VideoCapture1.Output_Format = new MP4Output();
                VideoCapture1.Output_Filename = edOutput.Text;
            }
            else
            {
                VideoCapture1.Mode = VideoCaptureMode.ScreenPreview;
            }

            await VideoCapture1.StartAsync();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            await VideoCapture1.StopAsync();
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, EventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, EventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        /// <summary>
        /// Handles the bt select output click event.
        /// </summary>
        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Log.
        /// </summary>
        private void Log(string txt)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
            }
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}
