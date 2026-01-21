namespace Computer_Vision_Demo
{
    using SkiaSharp;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Threading;
    using VisioForge.Core;
    using VisioForge.Core.CV;
    using VisioForge.Core.MediaPlayerX;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.VideoProcessing;
    using VisioForge.Core.Types.X;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.VideoCaptureX;

    /// <summary>
    /// The main form for the Computer Vision Demo.
    /// Demonstrates usage of various computer vision techniques such as face detection, pedestrian detection, and car counting using the X-engine.
    /// </summary>
    public partial class Form1 : Form
    {
        private VideoCaptureCoreX VideoCapture1;

        private MediaPlayerCoreX MediaPlayer1;

        private DNNFaceDetector _faceDetector;

        private CarCounter _carCounter;

        private PedestrianDetector _pedestrianDetector;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// Initializes the SDK engine, sets up the video capture and media player cores, and starts monitoring video sources.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            // We have to initialize the engine on start
            Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            VideoCapture1 = new VideoCaptureCoreX(VideoCaptureView);
            VideoCapture1.OnError += VideoCapture1_OnError;

            MediaPlayer1 = new MediaPlayerCoreX(MediaPlayerView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;

            Text += " (SDK v" + VideoCaptureCoreX.SDK_Version + ")";

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;

            await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
        }

        /// <summary>
        /// Handles the OnVideoSourceAdded event of the DeviceEnumerator.
        /// Adds newly discovered video input devices to the UI selection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VideoCaptureDeviceInfo"/> instance containing the device information.</param>
        private void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            Invoke(() =>
            {
                cbVideoInputDevice.Items.Add(e.DisplayName);

                if (cbVideoInputDevice.Items.Count == 1)
                {
                    cbVideoInputDevice.SelectedIndex = 0;
                }
            });
        }

        /// <summary>
        /// Handles the OnError event of the MediaPlayer1 control.
        /// Logs error messages to the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the error data.</param>
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

            VideoCapture1.Face_Detector = _faceDetector;
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

            if (rbFDCircle.Checked)
            {
                _faceDetector.Settings.DrawShapeType = CVShapeType.Circle;
            }
            else
            {
                _faceDetector.Settings.DrawShapeType = CVShapeType.Rectangle;
            }

            _faceDetector.Settings.MinFaceSize = new VisioForge.Core.Types.Size(Convert.ToInt32(edFDMinFaceWidth.Text), Convert.ToInt32(edFDMinFaceHeight.Text));
            _faceDetector.Settings.Pixelate = cbFDMosaic.Checked;
        }

        /// <summary>
        /// Handles the Click event of the btFDUpdate control.
        /// Updates the face detector settings based on the current UI values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
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
        /// Handles the FacesDetected event of the FaceDetector control.
        /// Displays information about detected faces in the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CVFaceDetectedEventArgs"/> instance containing data about detected faces.</param>
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
        private void tbFDSkipFrames_Scroll(object sender, EventArgs e)
        {
            lbFDSkipFrames.Text = tbFDSkipFrames.Value.ToString();
        }

        /// <summary>
        /// Handles the tb fd downscale scroll event.
        /// </summary>
        private void tbFDDownscale_Scroll(object sender, EventArgs e)
        {
            lbFDDownscale.Text = (tbFDDownscale.Value / 10.0).ToString("F2");
        }

        /// <summary>
        /// Handles the tb min neighbors scroll event.
        /// </summary>
        private void tbMinNeighbors_Scroll(object sender, EventArgs e)
        {
            lbFDMinNeighbors.Text = tbFDMinNeighbors.Value.ToString();
        }

        /// <summary>
        /// Handles the tb scale factor scroll event.
        /// </summary>
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
        /// Handles the OnPedestrianDetected event of the PedestrianDetector.
        /// Displays information about detected pedestrians in the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CVPedestrianDetectedEventArgs"/> instance containing data about detected pedestrians.</param>
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
        private void tbPDDownscale_Scroll(object sender, EventArgs e)
        {
            lbPDDownscale.Text = (tbPDDownscale.Value / 10.0).ToString("F2");
        }

        /// <summary>
        /// Handles the tb pd skip frames scroll event.
        /// </summary>
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
        /// Handles the OnCarsDetected event of the CarCounter control.
        /// Updates the detected cars count in the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CVCarDetectedEventArgs"/> instance containing car detection information.</param>
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

        #region Video capture source

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cbVideoInputDevice control.
        /// Populates the video input formats for the selected device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void cbVideoInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                cbVideoInputFormat.Items.Clear();

                var deviceItem = (await VideoCapture1.Video_SourcesAsync()).FirstOrDefault(device => device.DisplayName == cbVideoInputDevice.Text);
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
        /// Select ip camera source async.
        /// </summary>
        private async Task<UniversalSourceSettings> SelectIPCameraSourceAsync()
        {
            // Auto
            var uri = new Uri(edIPUrl.Text);
            if (!string.IsNullOrEmpty(edIPLogin.Text) && !string.IsNullOrEmpty(edIPPassword.Text))
            {
                uri = new UriBuilder(uri) { UserName = edIPLogin.Text, Password = edIPPassword.Text }.Uri;
            }

            var uni = await UniversalSourceSettings.CreateAsync(uri, renderAudio: false);

            VideoCapture1.Video_Source = uni;

            return uni;
        }

        /// <summary>
        /// Select video capture source.
        /// </summary>
        private async Task SelectVideoCaptureSource()
        {
            var videoCaptureDevice = (await VideoCapture1.Video_SourcesAsync()).FirstOrDefault(device => device.DisplayName == cbVideoInputDevice.Text);
            if (videoCaptureDevice == null)
            {
                return;
            }

            var format = videoCaptureDevice.VideoFormats.FirstOrDefault(f => f.Name == cbVideoInputFormat.Text);
            if (format == null)
            {
                return;
            }

            var frameRate = format.FrameRateList.FirstOrDefault(f => f.ToString(CultureInfo.CurrentCulture) == cbVideoInputFrameRate.Text);

            var videoSourceSettings = new VideoCaptureDeviceSourceSettings(videoCaptureDevice)
            {
                Format = format.ToFormat()
            };

            if (cbVideoInputFrameRate.SelectedIndex != -1)
            {
                videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text, CultureInfo.CurrentCulture));
            }

            VideoCapture1.Video_Source = videoSourceSettings;
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
        /// Handles the OnError event of the VideoCapture1 control.
        /// Logs error messages to the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the error data.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Configure video capture async.
        /// </summary>
        private async Task ConfigureVideoCaptureAsync()
        {
            // select source
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");                      
          
            if (rbVideoCaptureDevice.Checked)
            {
                // from video capture device
                await SelectVideoCaptureSource();
            }
            else
            {
                // from IP camera
                VideoCapture1.Video_Source = await SelectIPCameraSourceAsync();
            }

            VideoCapture1.Face_Detector = _faceDetector;

            VideoCapture1.Video_Processors.Clear();
            if (_pedestrianDetector != null)
            {
                VideoCapture1.Video_Processors.Add(_pedestrianDetector);
            }

            if (_carCounter != null)
            {
                VideoCapture1.Video_Processors.Add(_carCounter);
            }

            VideoCapture1.Audio_Record = false;
            VideoCapture1.Audio_Play = false;
        }

        #endregion

        #region Media Player

        /// <summary>
        /// Configure media player async.
        /// </summary>
        private async Task ConfigureMediaPlayerAsync()
        {
            MediaPlayer1.Debug_Mode = cbDebugMode.Checked;
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            MediaPlayer1.Face_Detector = _faceDetector;

            MediaPlayer1.Video_Processors.Clear();
            if (_pedestrianDetector != null)
            {
                MediaPlayer1.Video_Processors.Add(_pedestrianDetector);
            }

            if (_carCounter != null)
            {
                MediaPlayer1.Video_Processors.Add(_carCounter);
            }

            await MediaPlayer1.OpenAsync(await UniversalSourceSettings.CreateAsync(edFilename.Text));
        }

        #endregion

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures and starts either video capture or media playback with computer vision processing enabled.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();
            tcMain.SelectedIndex = 5;

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

            if (rbVideoFile.Checked)
            {
                await ConfigureMediaPlayerAsync();
            }
            else
            {
                await ConfigureVideoCaptureAsync();
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
        /// Handles the Click event of the btStop control.
        /// Stops video capture and media playback, and removes computer vision processing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, EventArgs e)
        {
            await VideoCapture1.StopAsync();
            await MediaPlayer1.StopAsync();

            FaceDetectionRemove();
            CarCounterRemove();
            PedestrianDetectionRemove();
        }

        /// <summary>
        /// Handles the Click event of the btOpenFile control.
        /// Opens a file dialog to select a video file for processing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btOpenFile_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = dlgOpenFile.FileName;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cbVideoInputFormat control.
        /// Populates the available frame rates for the selected video input format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void cbVideoInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat.Text))
            {
                return;
            }

            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                var sources = await VideoCapture1.Video_SourcesAsync();
                var deviceItem = sources.FirstOrDefault(device => device.DisplayName == cbVideoInputDevice.Text);
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
                foreach (var frameRate in videoFormat.FrameRateList)
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
