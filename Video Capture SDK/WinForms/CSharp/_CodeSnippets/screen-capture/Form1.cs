using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable StyleCop.SA1600
// ReSharper disable InconsistentNaming

namespace screen_capture
{
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.Sources;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + VideoCapture1.SDK_Version + ", " + VideoCapture1.SDK_State + ")";

            edOutput.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" + "output.mp4";

            foreach (var screen in Screen.AllScreens)
            {
                cbScreenCaptureDisplayIndex.Items.Add(screen.DeviceName.Replace(@"\\.\DISPLAY", string.Empty));
            }

            cbScreenCaptureDisplayIndex.SelectedIndex = 0;
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";
            VideoCapture1.Debug_Telemetry = cbTelemetry.Checked;

            // configure source
            var screenSource = new ScreenCaptureSourceSettings();

            screenSource.Mode = VFScreenCaptureMode.Screen;

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

            // disable audio
            VideoCapture1.Audio_PlayAudio = false;
            VideoCapture1.Audio_RecordAudio = false;

            // configure output
            if (cbCapture.Checked)
            {
                VideoCapture1.Mode = VFVideoCaptureMode.ScreenCapture;
                VideoCapture1.Output_Format = new VFMP4v8v10Output();
                VideoCapture1.Output_Filename = edOutput.Text;
            }
            else
            {
                VideoCapture1.Mode = VFVideoCaptureMode.ScreenPreview;
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
    }
}
