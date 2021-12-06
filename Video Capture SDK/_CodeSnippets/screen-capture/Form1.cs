using System;
using System.Linq;
using System.Windows.Forms;
// ReSharper disable StyleCop.SA1600
// ReSharper disable InconsistentNaming

namespace screen_capture
{
    using System.IO;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Types;
    using VisioForge.Types.Events;
    using VisioForge.Types.Output;
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
            VideoCapture1.OnLicenseRequired += VideoCapture1_OnLicenseRequired;
        }

        private void DestroyEngine()
        {
            VideoCapture1.OnError -= VideoCapture1_OnError;
            VideoCapture1.OnLicenseRequired -= VideoCapture1_OnLicenseRequired;

            VideoCapture1.Dispose();
            VideoCapture1 = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{VideoCapture1.SDK_Version})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");

            foreach (var screen in Screen.AllScreens)
            {
                cbScreenCaptureDisplayIndex.Items.Add(screen.DeviceName.Replace(@"\\.\DISPLAY", string.Empty));
            }

            cbScreenCaptureDisplayIndex.SelectedIndex = 0;
        }

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
            screenSource.FrameRate = Convert.ToInt32(edScreenFrameRate.Text);
            screenSource.GrabMouseCursor = cbScreenCapture_GrabMouseCursor.Checked;
            screenSource.AllowDesktopDuplicationEngine = cbScreenCapture_DesktopDuplication.Checked;
            VideoCapture1.Screen_Capture_Source = screenSource;

            // audio capture
            if (cbAudioCapture.Checked)
            {
                VideoCapture1.Audio_PlayAudio = false;
                VideoCapture1.Audio_RecordAudio = true;

                // select first audio device with default parameters
                if (VideoCapture1.Audio_CaptureDevices.Any())
                {
                    VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(VideoCapture1.Audio_CaptureDevices[0].Name);
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

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
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

        private void VideoCapture1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            Log(e.Message);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}
