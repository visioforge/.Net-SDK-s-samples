using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
// ReSharper disable InconsistentNaming
// ReSharper disable StyleCop.SA1600

namespace face_detection
{
    using System.IO;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Types;
    using VisioForge.Types.Events;
    using VisioForge.Types.VideoCapture;
    using VisioForge.Types.VideoProcessing;

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
            VideoCapture1.OnFaceDetected += VideoCapture1_OnFaceDetected;
        }

        private void DestroyEngine()
        {
            VideoCapture1.OnError -= VideoCapture1_OnError;
            VideoCapture1.OnLicenseRequired -= VideoCapture1_OnLicenseRequired;
            VideoCapture1.OnFaceDetected -= VideoCapture1_OnFaceDetected;

            VideoCapture1.Dispose();
            VideoCapture1 = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{VideoCapture1.SDK_Version})";

            // enumerate devices
            foreach (var device in VideoCapture1.Video_CaptureDevices)
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
            var deviceItem = VideoCapture1.Video_CaptureDevices.FirstOrDefault(device => device.Name == cbVideoInputDevice.Text);
            if (deviceItem == null)
            {
                return;
            }

            cbVideoInputFormat.Items.Clear();
            foreach (var format in deviceItem.VideoFormats)
            {
                cbVideoInputFormat.Items.Add(format.Name);
            }

            if (cbVideoInputFormat.Items.Count > 0)
            {
                cbVideoInputFormat.SelectedIndex = 0;
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            // set debug settings
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            VideoCapture1.Debug_Telemetry = cbTelemetry.Checked;
            mmLog.Clear();

            // configure video source
            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbVideoInputDevice.Text);
            VideoCapture1.Video_CaptureDevice.Format = cbVideoInputFormat.Text;
            VideoCapture1.Video_CaptureDevice.Format_UseBest = cbUseBestVideoInputFormat.Checked;
            VideoCapture1.Video_CaptureDevice.FrameRate = Convert.ToDouble(cbVideoInputFrameRate.Text);

            // disabe audio
            VideoCapture1.Audio_PlayAudio = false;
            VideoCapture1.Audio_RecordAudio = false;

            // set video preview mode
            VideoCapture1.Mode = VideoCaptureMode.VideoPreview;

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

        private void cbVideoInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat.Text))
            {
                return;
            }

            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevices.FirstOrDefault(device => device.Name == cbVideoInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbVideoInputFormat.Text);
                if (videoFormat == null)
                {
                    return;
                }

                cbVideoInputFrameRate.Items.Clear();
                foreach (var frameRate in videoFormat.FrameRates)
                {
                    cbVideoInputFrameRate.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture));
                }

                if (cbVideoInputFrameRate.Items.Count > 0)
                {
                    cbVideoInputFrameRate.SelectedIndex = 0;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}
