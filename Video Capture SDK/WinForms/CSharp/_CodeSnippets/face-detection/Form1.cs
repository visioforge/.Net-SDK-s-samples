using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable InconsistentNaming
// ReSharper disable StyleCop.SA1600

namespace face_detection
{
    using VisioForge.Types;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + VideoCapture1.SDK_Version + ", " + VideoCapture1.SDK_State + ")";

            // enumerate devices
            foreach (var device in VideoCapture1.Video_CaptureDevicesInfo)
            {
                cbVideoInputDevice.Items.Add(device.Name);
            }

            if (cbVideoInputDevice.Items.Count > 0)
            {
                cbVideoInputDevice.SelectedIndex = 0;
            }

            cbFaceTrackingColorMode.SelectedIndex = 0;
            cbFaceTrackingScalingMode.SelectedIndex = 0;
            cbFaceTrackingSearchMode.SelectedIndex = 1;
        }

        private void cbVideoInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            // fill video formats and frame rates
            var deviceItem = VideoCapture1.Video_CaptureDevicesInfo.First(device => device.Name == cbVideoInputDevice.Text);
            if (deviceItem == null)
            {
                return;
            }

            cbVideoInputFormat.Items.Clear();
            foreach (string format in deviceItem.VideoFormats)
            {
                cbVideoInputFormat.Items.Add(format);
            }

            if (cbVideoInputFormat.Items.Count > 0)
            {
                cbVideoInputFormat.SelectedIndex = 0;
            }

            cbVideoFrameRate.Items.Clear();
            foreach (string frameRate in deviceItem.VideoFrameRates)
            {
                cbVideoFrameRate.Items.Add(frameRate);
            }

            if (cbVideoFrameRate.Items.Count > 0)
            {
                cbVideoFrameRate.SelectedIndex = 0;
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            // set debug settings
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";
            VideoCapture1.Debug_Telemetry = cbTelemetry.Checked;
            mmLog.Clear();

            // configure video source
            VideoCapture1.Video_CaptureDevice = cbVideoInputDevice.Text;
            VideoCapture1.Video_CaptureDevice_Format = cbVideoInputFormat.Text;
            VideoCapture1.Video_CaptureDevice_Format_UseBest = cbUseBestVideoInputFormat.Checked;
            VideoCapture1.Video_CaptureDevice_FrameRate = Convert.ToDouble(cbVideoFrameRate.Text);

            // disabe audio
            VideoCapture1.Audio_PlayAudio = false;
            VideoCapture1.Audio_RecordAudio = false;

            // set video preview mode
            VideoCapture1.Mode = VFVideoCaptureMode.VideoPreview;

            // set face tracking settings
            VideoCapture1.Face_Tracking = new FaceTrackingSettings
            {
                ColorMode = (CamshiftMode)cbFaceTrackingColorMode.SelectedIndex,
                Highlight = cbFaceTrackingCHL.Checked,
                MinimumWindowSize =
                                                      int.Parse(edFaceTrackingMinimumWindowSize.Text),
                ScalingMode =
                                                      (ObjectDetectorScalingMode)
                                                      cbFaceTrackingScalingMode.SelectedIndex,
                SearchMode =
                                                      (ObjectDetectorSearchMode)
                                                      cbFaceTrackingSearchMode.SelectedIndex
            };

            // start
            await VideoCapture1.StartAsync();
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

        private void VideoCapture1_OnFaceDetected(object sender, AFFaceDetectionEventArgs e)
        {
            BeginInvoke(new FaceDelegate(FaceDelegateMethod), e);
        }

        public delegate void FaceDelegate(AFFaceDetectionEventArgs e);

        public void FaceDelegateMethod(AFFaceDetectionEventArgs e)
        {
            edFaceTrackingFaces.Text = string.Empty;

            foreach (var faceRectangle in e.FaceRectangles)
            {
                edFaceTrackingFaces.Text += "(" + faceRectangle.Left + ", " + faceRectangle.Top + "), ("
                                            + faceRectangle.Width + ", " + faceRectangle.Height + ")" + Environment.NewLine;
            }
        }
    }
}
