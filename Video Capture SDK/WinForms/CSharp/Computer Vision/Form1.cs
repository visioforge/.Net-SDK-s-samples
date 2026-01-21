// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="VisioForge">
//   Computer Vision demo.
// </copyright>
// <summary>
//   Defines the Form1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Computer_Vision_Demo
{
    using SkiaSharp;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using VisioForge.Core.CV;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.Types.VideoProcessing;
    using VisioForge.Core.VideoCapture;

    public partial class Form1 : Form
    {
        /// <summary>
        /// The video capture.
        /// </summary>
        private VideoCaptureCore VideoCapture1;

        /// <summary>
        /// The media player.
        /// </summary>
        private MediaPlayerCore MediaPlayer1;

        /// <summary>
        /// The face detector.
        /// </summary>
        private DNNFaceDetector _faceDetector;

        /// <summary>
        /// The car counter.
        /// </summary>
        private CarCounter _carCounter;

        /// <summary>
        /// The pedestrian detector.
        /// </summary>
        private PedestrianDetector _pedestrianDetector;

        /// <summary>
        /// The covered detector.
        /// </summary>
        private CameraCoveredDetector _coveredDetector;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync(VideoCaptureView as IVideoView);
            VideoCapture1.OnVideoFrameBuffer += VideoCapture1_OnVideoFrameBuffer;
            VideoCapture1.OnError += VideoCapture1_OnError;

            MediaPlayer1 = await MediaPlayerCore.CreateAsync(MediaPlayerView as IVideoView);
            MediaPlayer1.OnVideoFrameBuffer += MediaPlayer1_OnVideoFrameBuffer;
            MediaPlayer1.OnError += MediaPlayer1_OnError;

            Text += " (SDK v" + VideoCapture1.SDK_Version() + ")";

            foreach (var device in VideoCapture1.Video_CaptureDevices())
            {
                cbVideoInputDevice.Items.Add(device.Name);
            }

            if (cbVideoInputDevice.Items.Count > 0)
            {
                cbVideoInputDevice.SelectedIndex = 0;
                cbVideoInputDevice_SelectedIndexChanged(null, null);
            }

            cbIPCameraType.SelectedIndex = 0;
        }

        /// <summary>
        /// Media player 1 on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        #region Face detection

        /// <summary>
        /// Face detection add.
        /// </summary>
        private void FaceDetectionAdd()
        {
            _faceDetector = new DNNFaceDetector();
            _faceDetector.FacesDetected += OnFaceDetected;

            FaceDetectionUpdate();
        }

        /// <summary>
        /// Face detection update.
        /// </summary>
        private void FaceDetectionUpdate()
        {
            if (_faceDetector == null)
            {
                return;
            }

            _faceDetector.Settings.DrawEnabled = cbFDDraw.Checked;
            _faceDetector.Settings.DrawColor = SKColors.Green;
            _faceDetector.Settings.FramesToSkip = tbFDSkipFrames.Value;
            _faceDetector.Settings.MinNeighbors = tbFDMinNeighbors.Value;
            _faceDetector.Settings.ScaleFactor = tbFDScaleFactor.Value / 100.0f;
            _faceDetector.Settings.VideoScale = tbFDDownscale.Value / 10.0f;
            _faceDetector.Settings.Pixelate = cbFDMosaic.Checked;

            if (rbFDCircle.Checked)
            {
                _faceDetector.Settings.DrawShapeType = CVShapeType.Circle;
            }
            else
            {
                _faceDetector.Settings.DrawShapeType = CVShapeType.Rectangle;
            }

            _faceDetector.Settings.MinFaceSize = new VisioForge.Core.Types.Size(Convert.ToInt32(edFDMinFaceWidth.Text), Convert.ToInt32(edFDMinFaceHeight.Text));
        }

        /// <summary>
        /// Handles the bt fd update click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btFDUpdate_Click(object sender, EventArgs e)
        {
            FaceDetectionUpdate();
        }

        /// <summary>
        /// Face detection remove.
        /// </summary>
        private void FaceDetectionRemove()
        {
            if (this._faceDetector != null)
            {
                this._faceDetector.FacesDetected -= OnFaceDetected;
                this._faceDetector.Dispose();
                this._faceDetector = null;
            }
        }

        /// <summary>
        /// On face detected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CVFaceDetectedEventArgs"/> instance containing the event data.</param>
        private void OnFaceDetected(object sender, CVFaceDetectedEventArgs e)
        {
            if (e.Faces.Length == 0)
            {
                return;
            }

            BeginInvoke(
                (Action)(() =>
                {
                    edFDFaces.Text = string.Empty;
                    foreach (var face in e.Faces)
                    {
                        edFDFaces.Text += $"Face at {face.Position.ToString()}" + Environment.NewLine;
                    }
                }));
        }

        /// <summary>
        /// Handles the tb fd skip frames scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tbFDSkipFrames_Scroll(object sender, EventArgs e)
        {
            lbFDSkipFrames.Text = tbFDSkipFrames.Value.ToString();
        }

        /// <summary>
        /// Handles the tb fd downscale scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tbFDDownscale_Scroll(object sender, EventArgs e)
        {
            lbFDDownscale.Text = (tbFDDownscale.Value / 10.0).ToString("F2");
        }

        /// <summary>
        /// Handles the tb min neighbors scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tbMinNeighbors_Scroll(object sender, EventArgs e)
        {
            lbFDMinNeighbors.Text = tbFDMinNeighbors.Value.ToString();
        }

        /// <summary>
        /// Handles the tb scale factor scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tbScaleFactor_Scroll(object sender, EventArgs e)
        {
            lbFDScaleFactor.Text = (tbFDScaleFactor.Value / 100.0).ToString("F2");
        }

        #endregion

        #region Pedestrian detection
        /// <summary>
        /// Pedestrian detection add.
        /// </summary>
        private void PedestrianDetectionAdd()
        {
            _pedestrianDetector = new PedestrianDetector()
            {
                DrawEnabled = cbPDDraw.Checked,
                DrawColor = SKColors.Green,
                FramesToSkip = tbPDSkipFrames.Value,
                VideoScale = tbPDDownscale.Value / 10.0f
            };

            _pedestrianDetector.Init();

            _pedestrianDetector.OnPedestrianDetected += OnPedestrianDetected;
        }

        /// <summary>
        /// Pedestrian detection remove.
        /// </summary>
        private void PedestrianDetectionRemove()
        {
            if (_pedestrianDetector != null)
            {
                _pedestrianDetector.OnPedestrianDetected -= OnPedestrianDetected;
                _pedestrianDetector.Dispose();
                _pedestrianDetector = null;
            }
        }

        /// <summary>
        /// On pedestrian detected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CVPedestrianDetectedEventArgs"/> instance containing the event data.</param>
        private void OnPedestrianDetected(object sender, CVPedestrianDetectedEventArgs e)
        {
            if (e.Items.Length == 0)
            {
                return;
            }

            BeginInvoke(
                (Action)(() =>
                {
                    edPDDetected.Text = string.Empty;
                    foreach (var item in e.Items)
                    {
                        edPDDetected.Text += $"Object at {item.ToString()}" + Environment.NewLine;
                    }
                }));
        }

        /// <summary>
        /// Handles the tb pd downscale scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tbPDDownscale_Scroll(object sender, EventArgs e)
        {
            lbPDDownscale.Text = (tbPDDownscale.Value / 10.0).ToString("F2");
        }

        /// <summary>
        /// Handles the tb pd skip frames scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tbPDSkipFrames_Scroll(object sender, EventArgs e)
        {
            lbPDSkipFrames.Text = tbPDSkipFrames.Value.ToString();
        }

        #endregion

        #region Car counter
        /// <summary>
        /// Car counter add.
        /// </summary>
        private void CarCounterAdd()
        {
            _carCounter = new CarCounter()
            {
                ContoursDraw = cbCCDraw.Checked,
                TrackingLineDraw = cbCCDraw.Checked,
                CounterDraw = cbCCDraw.Checked
            };

            _carCounter.Init();
            _carCounter.OnCarsDetected += this.OnCarsDetected;
        }

        /// <summary>
        /// On cars detected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CVCarDetectedEventArgs"/> instance containing the event data.</param>
        private void OnCarsDetected(object sender, CVCarDetectedEventArgs e)
        {
            BeginInvoke(
                (Action)(() =>
                {
                    edCCDetectedCars.Text = e.CarsCount.ToString();
                }));
        }

        /// <summary>
        /// Car counter remove.
        /// </summary>
        private void CarCounterRemove()
        {
            if (_carCounter != null)
            {
                _carCounter.OnCarsDetected -= this.OnCarsDetected;
                _carCounter.Dispose();
                _carCounter = null;
            }
        }

        #endregion

        #region Camera covered detector

        /// <summary>
        /// Camera covered detector add.
        /// </summary>
        private void CameraCoveredDetectorAdd()
        {
            _coveredDetector = new CameraCoveredDetector()
            {
                Threshold = tbCCDThreshold.Value,
                FramesToSkip = tbCCDSkipFrames.Value
            };

            _coveredDetector.OnCameraCovered += OnCameraCovered;
        }

        /// <summary>
        /// On camera covered.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CameraCoveredDetectorEventArgs"/> instance containing the event data.</param>
        private void OnCameraCovered(object sender, CameraCoveredDetectorEventArgs e)
        {
            BeginInvoke(
               (Action)(() =>
               {
                   edCCDResults.Text += $"Camera covered. Level: {e.Level}" + Environment.NewLine;
               }));
        }

        /// <summary>
        /// Object detector remove.
        /// </summary>
        private void ObjectDetectorRemove()
        {
            if (_coveredDetector != null)
            {
                _coveredDetector.OnCameraCovered -= OnCameraCovered;
                _coveredDetector = null;
            }
        }

        /// <summary>
        /// Handles the tb ccd skip frames scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tbCCDSkipFrames_Scroll(object sender, EventArgs e)
        {
            lbCCDSkipFrames.Text = tbCCDSkipFrames.Value.ToString();
        }

        /// <summary>
        /// Handles the tb ccd threshold scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tbCCDThreshold_Scroll(object sender, EventArgs e)
        {
            lbCCDThreshold.Text = tbCCDThreshold.Value.ToString();
        }

        /// <summary>
        /// Handles the bt ccd update click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btCCDUpdate_Click(object sender, EventArgs e)
        {
            if (_coveredDetector != null)
            {
                _coveredDetector.Threshold = tbCCDThreshold.Value;
                _coveredDetector.FramesToSkip = tbCCDSkipFrames.Value;
            }
        }

        #endregion


        /// <summary>
        /// Process frame.
        /// </summary>
        /// <param name="frame">The video frame.</param>
        private void ProcessFrame(VideoFrame frame)
        {
            _faceDetector?.ProcessFrame(frame);
            _carCounter?.ProcessFrame(frame);
            _pedestrianDetector?.ProcessFrame(frame);
            _coveredDetector?.ProcessFrame(frame);
        }

        #region Video capture source

        /// <summary>
        /// Video capture 1 on video frame buffer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="VideoFrameBufferEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnVideoFrameBuffer(object sender, VideoFrameBufferEventArgs e)
        {
            ProcessFrame(e.Frame);
        }

        /// <summary>
        /// Handles the cb video input device selected index changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbVideoInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                cbVideoInputFormat.Items.Clear();

                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbVideoInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                foreach (var format in deviceItem.VideoFormats)
                {
                    cbVideoInputFormat.Items.Add(format.Name);
                }

                if (cbVideoInputFormat.Items.Count > 0)
                {
                    cbVideoInputFormat.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Select ip camera source.
        /// </summary>
        /// <param name="settings">The settings.</param>
        private void SelectIPCameraSource(out IPCameraSourceSettings settings)
        {
            settings = new IPCameraSourceSettings
            {
                URL = new Uri(edIPUrl.Text)
            };

            switch (cbIPCameraType.SelectedIndex)
            {
                case 0:
                    settings.Type = IPSourceEngine.Auto_VLC;
                    break;
                case 1:
                    settings.Type = IPSourceEngine.Auto_FFMPEG;
                    break;
                case 2:
                    settings.Type = IPSourceEngine.Auto_LAV;
                    break;
                case 3:
                    settings.Type = IPSourceEngine.MMS_WMV;
                    break;
            }

            settings.AudioCapture = false;
            settings.Login = edIPLogin.Text;
            settings.Password = edIPPassword.Text;
            settings.Debug_Enabled = cbDebugMode.Checked;
            settings.Debug_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "ip_cam_log.txt");
        }

        /// <summary>
        /// Select video capture source.
        /// </summary>
        private void SelectVideoCaptureSource()
        {
            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbVideoInputDevice.Text);
            VideoCapture1.Video_CaptureDevice.Format_UseBest = cbUseBestVideoInputFormat.Checked;
            VideoCapture1.Video_CaptureDevice.Format = cbVideoInputFormat.Text;

            if (cbVideoInputFrameRate.SelectedIndex != -1)
            {
                VideoCapture1.Video_CaptureDevice.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text, CultureInfo.CurrentCulture));
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
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
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
        /// Configure video capture.
        /// </summary>
        private void ConfigureVideoCapture()
        {
            // select source
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            //VideoCapture1.VLC_Path = Environment.GetEnvironmentVariable("VFVLCPATH");

            if (rbVideoCaptureDevice.Checked)
            {
                VideoCapture1.Mode = VideoCaptureMode.VideoPreview;
            }
            else
            {
                VideoCapture1.Mode = VideoCaptureMode.IPPreview;
            }

            if ((VideoCapture1.Mode == VideoCaptureMode.IPCapture) || (VideoCapture1.Mode == VideoCaptureMode.IPPreview))
            {
                // from IP camera
                IPCameraSourceSettings settings;
                SelectIPCameraSource(out settings);
                VideoCapture1.IP_Camera_Source = settings;
            }
            else if ((VideoCapture1.Mode == VideoCaptureMode.VideoCapture) || (VideoCapture1.Mode == VideoCaptureMode.VideoPreview) ||
                (VideoCapture1.Mode == VideoCaptureMode.AudioCapture) || (VideoCapture1.Mode == VideoCaptureMode.AudioPreview))
            {
                // from video capture device
                SelectVideoCaptureSource();
            }

            VideoCapture1.Audio_RecordAudio = false;
            VideoCapture1.Audio_PlayAudio = false;

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            VideoCapture1.Video_Renderer_SetAuto();
        }

        #endregion

        #region Media Player

        /// <summary>
        /// Configure media player.
        /// </summary>
        private void ConfigureMediaPlayer()
        {
            MediaPlayer1.Debug_Mode = cbDebugMode.Checked;
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV;
            MediaPlayer1.Playlist_Clear();
            MediaPlayer1.Playlist_Add(edFilename.Text);

            MediaPlayer1.Video_Renderer_SetAuto();
        }

        /// <summary>
        /// Media player 1 on video frame buffer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="VideoFrameBufferEventArgs"/> instance containing the event data.</param>
        private void MediaPlayer1_OnVideoFrameBuffer(object sender, VideoFrameBufferEventArgs e)
        {
            ProcessFrame(e.Frame);
        }

        #endregion

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();
            tcMain.SelectedIndex = 5;

            if (rbVideoFile.Checked)
            {
                ConfigureMediaPlayer();
            }
            else
            {
                ConfigureVideoCapture();
            }

            // add face detection
            if (cbFDEnabled.Checked)
            {
                FaceDetectionAdd();
            }

            // add car counter
            if (cbCCEnabled.Checked)
            {
                CarCounterAdd();
            }

            // add car counter
            if (cbPDEnabled.Checked)
            {
                PedestrianDetectionAdd();
            }

            // add camera covered detector
            if (cbCameraCovered.Checked)
            {
                CameraCoveredDetectorAdd();
            }

            if (rbVideoFile.Checked)
            {
                MediaPlayerView.Show();
                VideoCaptureView.Hide();
                await MediaPlayer1.PlayAsync();
            }
            else
            {
                MediaPlayerView.Hide();
                VideoCaptureView.Show();
                await VideoCapture1.StartAsync();
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, EventArgs e)
        {
            await VideoCapture1.StopAsync();
            await MediaPlayer1.StopAsync();

            FaceDetectionRemove();
            CarCounterRemove();
            PedestrianDetectionRemove();
            ObjectDetectorRemove();
        }

        /// <summary>
        /// Handles the bt open file click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btOpenFile_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = dlgOpenFile.FileName;
            }
        }

        /// <summary>
        /// Handles the cb video input format selected index changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbVideoInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat.Text))
            {
                return;
            }

            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbVideoInputDevice.Text);
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
    }
}
