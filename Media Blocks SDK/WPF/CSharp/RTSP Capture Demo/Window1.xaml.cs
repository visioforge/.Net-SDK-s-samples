




namespace RTSP_Capture
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Timers;
    using System.Windows;
    using System.Windows.Input;

    using VisioForge.Core;
    using VisioForge.Core.ONVIFX;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.ONVIFDiscovery;
    using VisioForge.Core.ONVIFDiscovery.Models;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.UI;
    using VisioForge.Core.VideoCaptureX;
    using Application = System.Windows.Forms.Application;
    using Task = System.Threading.Tasks.Task;
    using Uri = System.Uri;
    using System.Linq;
    using VisioForge.Core.MediaBlocks.Special;
    using VisioForge.Core.MediaBlocks.Sinks;
    using VisioForge.Core.MediaBlocks.VideoEncoders;
    using VisioForge.Core.MediaBlocks.AudioEncoders;
    using VisioForge.Core.Types.X.Sinks;
    using VisioForge.Core.Types.X.VideoEncoders;
    using VisioForge.Core.Types.X.AudioEncoders;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for Window1.xaml.
    /// </summary>
    public partial class Window1 : IDisposable
    {
        /// <summary>
        /// The recording timer.
        /// </summary>
        private Timer tmRecording = new Timer(1000);

        /// <summary>
        /// The ONVIF client.
        /// </summary>
        private ONVIFClientX onvifClient;

        /// <summary>
        /// The ONVIF discovery instance.
        /// </summary>
        private Discovery _onvifDiscovery = new Discovery();

        /// <summary>
        /// The cancellation token source.
        /// </summary>
        private System.Threading.CancellationTokenSource _cts;

        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The RTSP source.
        /// </summary>
        private RTSPSourceBlock _rtspSource;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The video tee block.
        /// </summary>
        private TeeBlock _videoTee;

        /// <summary>
        /// The audio tee block.
        /// </summary>
        private TeeBlock _audioTee;

        /// <summary>
        /// The muxer block.
        /// </summary>
        private MediaBlock _muxer;

        /// <summary>
        /// The video encoder block.
        /// </summary>
        private MediaBlock _videoEncoder;

        /// <summary>
        /// The audio encoder block.
        /// </summary>
        private MediaBlock _audioEncoder;

        /// <summary>
        /// Value indicating whether the object is disposed.
        /// </summary>
        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();

            Application.EnableVisualStyles();
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();

            _pipeline.OnError += VideoCapture1_OnError;
        }

        /// <summary>
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= VideoCapture1_OnError;

                _pipeline.Stop();

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Form 1 load.
        /// </summary>
        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                // We have to initialize the engine on start
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                this.IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

                edFilename.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "capture.mp4");

                tmRecording.Elapsed += async (senderx, args) =>
                {
                    await UpdateRecordingTime();
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "MP4 files (*.mp4)|*.mp4|MPEG-TS files (*.ts)|*.ts|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateEngine();

                if (onvifClient != null)
                {
                    onvifClient.Dispose();
                    onvifClient = null;

                    btONVIFConnect.Content = "Connect";
                }

                mmLog.Clear();

                var audioEnabled = cbIPAudioCapture.IsChecked == true;
                var lowLatencyMode = cbLowLatencyMode.IsChecked == true;
                _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
                _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

                var rtsp = await RTSPSourceSettings.CreateAsync(new Uri(cbIPURL.Text), edIPLogin.Text, edIPPassword.Text, audioEnabled);

                // Enable low latency mode if checkbox is checked
                if (lowLatencyMode)
                {
                    rtsp.LowLatencyMode = true;
                    mmLog.Text += "Low latency mode enabled (latency=80ms, no buffering)" + Environment.NewLine;
                }

                var info = rtsp.GetInfo();

                if (info == null)
                {
                    MessageBox.Show(this, "Unable to get RTSP source info. Please, use the direct RTSP URL, not HTTP ONVIF");
                    return;
                }

                _rtspSource = new RTSPSourceBlock(rtsp);

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                // Disable sync for low latency mode to reduce display latency
                if (lowLatencyMode)
                {
                    _videoRenderer.IsSync = false;
                    mmLog.Text += "Video renderer sync disabled for low latency" + Environment.NewLine;
                }

                bool capture = cbCapture.IsChecked == true;

                if (capture)
                {
                    _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

                    switch (cbFormat.SelectedIndex)
                    {
                        case 0: // MP4
                            _muxer = new MP4SinkBlock(new MP4SinkSettings(edFilename.Text));
                            break;
                        case 1: // MPEG-TS
                            _muxer = new MPEGTSSinkBlock(new MPEGTSSinkSettings(edFilename.Text));
                            break;
                    }

                    _videoEncoder = new H264EncoderBlock();

                    _pipeline.Connect(_rtspSource.VideoOutput, _videoTee.Input);
                    _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
                    _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);
                    _pipeline.Connect(_videoEncoder.Output, (_muxer as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Video));
                }
                else
                {
                    _pipeline.Connect(_rtspSource.VideoOutput, _videoRenderer.Input);
                }

                if (audioEnabled && info.AudioStreams.Count > 0)
                {
                    _audioRenderer = new AudioRendererBlock();

                    if (capture)
                    {
                        _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
                        _audioEncoder = new AACEncoderBlock();

                        _pipeline.Connect(_rtspSource.AudioOutput, _audioTee.Input);
                        _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
                        _pipeline.Connect(_audioTee.Outputs[1], _audioEncoder.Input);
                        _pipeline.Connect(_audioEncoder.Output, (_muxer as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Audio));
                    }
                    else
                    {
                        _pipeline.Connect(_rtspSource.AudioOutput, _audioRenderer.Input);
                    }
                }

                await _pipeline.StartAsync();

                tmRecording.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tmRecording.Stop();

                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Ll video tutorials link clicked.
        /// </summary>
        private void llVideoTutorials_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Log.
        /// </summary>
        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Handles the bt onvif connect click event.
        /// </summary>
        private async void btONVIFConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btONVIFConnect.Content.ToString() == "Connect")
                {
                    try
                    {
                        btONVIFConnect.IsEnabled = false;
                        btONVIFConnect.Content = "Connecting";

                        if (onvifClient != null)
                        {
                            onvifClient.Dispose();
                            onvifClient = null;
                        }

                        if (string.IsNullOrEmpty(edONVIFLogin.Text) || string.IsNullOrEmpty(edONVIFPassword.Text))
                        {
                            MessageBox.Show(this, "Please specify IP camera user name and password.");
                            return;
                        }

                        onvifClient = new ONVIFClientX();
                        var result = await onvifClient.ConnectAsync(edONVIFURL.Text, edONVIFLogin.Text, edONVIFPassword.Text);
                        if (!result)
                        {
                            onvifClient = null;
                            MessageBox.Show(this, "Unable to connect to ONVIF camera.");
                            return;
                        }

                        lbONVIFCameraInfo.Content = $"Camera name {onvifClient.DeviceInformation?.Model}, serial number {onvifClient.DeviceInformation?.SerialNumber}";

                        cbONVIFProfile.Items.Clear();
                        var profiles = await onvifClient.GetProfilesAsync();
                        if (profiles != null && profiles.Length > 0)
                        {
                            foreach (var profile in profiles)
                            {
                                cbONVIFProfile.Items.Add($"{profile.Name}");
                            }

                            if (cbONVIFProfile.Items.Count > 0)
                            {
                                cbONVIFProfile.SelectedIndex = 0;
                            }

                            var mediaUri = await onvifClient.GetStreamUriAsync(profiles[0]);
                            if (mediaUri != null)
                            {
                                edONVIFLiveVideoURL.Text = cbIPURL.Text = mediaUri.Uri;
                            }
                        }

                        edIPLogin.Text = edONVIFLogin.Text;
                        edIPPassword.Text = edONVIFPassword.Text;

                        btONVIFConnect.Content = "Disconnect";
                    }
                    catch
                    {
                        btONVIFConnect.Content = "Connect";
                    }

                    btONVIFConnect.IsEnabled = true;
                }
                else
                {
                    btONVIFConnect.Content = "Connect";

                    if (onvifClient != null)
                    {
                        onvifClient.Dispose();
                        onvifClient = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _pipeline.ResumeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _pipeline.PauseAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Update recording time.
        /// </summary>
        private async Task UpdateRecordingTime()
        {
            var ts = await _pipeline.Position_GetAsync();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.Invoke((Action)(() =>
            {
                lbTimestamp.Text = "Duration: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        /// <summary>
        /// Handles the bt list onvif sources click event.
        /// </summary>
        private void btListONVIFSources_Click(object sender, RoutedEventArgs e)
        {
            cbIPURL.Items.Clear();

            _cts?.Cancel();
            _cts = new System.Threading.CancellationTokenSource();

            Task.Run(async () =>
            {
                try
                {
                    await _onvifDiscovery.Discover(5, (device) =>
                    {
                        if (device.XAdresses?.Any() == true)
                        {
                            Dispatcher.Invoke(() =>
                            {
                                var address = device.XAdresses.FirstOrDefault();
                                if (!string.IsNullOrEmpty(address))
                                {
                                    cbIPURL.Items.Add(address);

                                    if (cbIPURL.Items.Count == 1)
                                    {
                                        cbIPURL.SelectedIndex = 0;
                                    }
                                }
                            });
                        }
                    }, _cts.Token);
                }
                catch (OperationCanceledException)
                {
                    // Discovery cancelled
                }
            });
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                await DestroyEngineAsync();

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (onvifClient != null)
                    {
                        onvifClient.Dispose();
                        onvifClient = null;
                    }

                    tmRecording?.Dispose();
                    tmRecording = null;
                }

                disposedValue = true;
            }
        }

        ~Window1()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

