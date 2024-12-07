// ReSharper disable InconsistentNaming

// ReSharper disable StyleCop.SA1600
// ReSharper disable StyleCop.SA1601

namespace RTSP_Preview
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
    using VisioForge.Core.ONVIF.Legacy;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.UI;
    using VisioForge.Core.VideoCaptureX;
    using Application = System.Windows.Forms.Application;
    using Task = System.Threading.Tasks.Task;
    using Uri = System.Uri;

    public partial class Window1 : IDisposable
    {
        private Timer tmRecording = new Timer(1000);

        private ONVIFDeviceX onvifDevice;

        private ONVIFDiscoveryX _onvifDiscoveryX = new ONVIFDiscoveryX();

        private MediaBlocksPipeline _pipeline;

        private RTSPSourceBlock _rtspSource;

        private MediaBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private bool disposedValue;

        public Window1()
        {
            InitializeComponent();

            Application.EnableVisualStyles();
        }

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();

            _pipeline.OnError += VideoCapture1_OnError;
        }

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

        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

            tmRecording.Elapsed += async (senderx, args) =>
            {
                await UpdateRecordingTime();
            };
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            if (onvifDevice != null)
            {
                onvifDevice.Disconnect();
                onvifDevice.Dispose();
                onvifDevice = null;

                btONVIFConnect.Content = "Connect";
            }

            mmLog.Clear();

            var audioEnabled = cbIPAudioCapture.IsChecked == true; 
            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var rtsp = await RTSPSourceSettings.CreateAsync(new Uri(cbIPURL.Text), edIPLogin.Text, edIPPassword.Text, audioEnabled);
            var info = rtsp.GetInfo();

            if (info == null)
            {
                MessageBox.Show(this, "Unable to get RTSP source info. Please, use the direct RTSP URL, not HTTP ONVIF");
                return;
            }

            _rtspSource = new RTSPSourceBlock(rtsp);

            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            _pipeline.Connect(_rtspSource.VideoOutput, _videoRenderer.Input);

            if (audioEnabled && info.AudioStreams.Count > 0)
            {
                _audioRenderer = new AudioRendererBlock();
                _pipeline.Connect(_rtspSource.AudioOutput, _audioRenderer.Input);
            }

            await _pipeline.StartAsync();

            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await _pipeline.StopAsync();
            await _pipeline.DisposeAsync();
        }

        private void llVideoTutorials_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private async void btONVIFConnect_Click(object sender, RoutedEventArgs e)
        {
            if (btONVIFConnect.Content.ToString() == "Connect")
            {
                try
                {
                    btONVIFConnect.IsEnabled = false;
                    btONVIFConnect.Content = "Connecting";

                    if (onvifDevice != null)
                    {
                        onvifDevice.Disconnect();
                        onvifDevice.Dispose();
                        onvifDevice = null;
                    }

                    if (string.IsNullOrEmpty(edONVIFLogin.Text) || string.IsNullOrEmpty(edONVIFPassword.Text))
                    {
                        MessageBox.Show(this, "Please specify IP camera user name and password.");
                        return;
                    }

                    onvifDevice = new ONVIFDeviceX();
                    var result = await onvifDevice.ConnectAsync(new Uri(edONVIFURL.Text), edONVIFLogin.Text, edONVIFPassword.Text);
                    if (!result)
                    {
                        onvifDevice = null;
                        MessageBox.Show(this, "Unable to connect to ONVIF camera.");
                        return;
                    }

                    lbONVIFCameraInfo.Content = $"Camera name {onvifDevice.CameraName}, serial number {onvifDevice.SerialNumber}";                    

                    cbONVIFProfile.Items.Clear();
                    var profiles = onvifDevice.GetProfiles();
                    foreach (var profile in profiles)
                    {
                        cbONVIFProfile.Items.Add($"{profile.Name}");
                    }

                    if (cbONVIFProfile.Items.Count > 0)
                    {
                        cbONVIFProfile.SelectedIndex = 0;
                    }

                    edONVIFLiveVideoURL.Text = cbIPURL.Text = profiles[0].RTSPUrl.ToString();

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

                if (onvifDevice != null)
                {
                    onvifDevice.Disconnect();
                    onvifDevice.Dispose();
                    onvifDevice = null;
                }
            }
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.PauseAsync();
        }

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

        private void btListONVIFSources_Click(object sender, RoutedEventArgs e)
        {
            cbIPURL.Items.Clear();

            _onvifDiscoveryX.OnDeviceFound += async (senderx, args) =>
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    cbIPURL.Items.Add(args.Address);

                    if (cbIPURL.Items.Count == 1)
                    {
                        cbIPURL.SelectedIndex = 0;
                    }
                });
            };
            _onvifDiscoveryX.Start();
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (onvifDevice != null)
                    {
                        onvifDevice.Dispose();
                        onvifDevice = null;
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

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

// ReSharper restore InconsistentNaming