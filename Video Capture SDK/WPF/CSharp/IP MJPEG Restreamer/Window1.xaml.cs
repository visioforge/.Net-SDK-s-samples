// ReSharper disable InconsistentNaming

// ReSharper disable StyleCop.SA1600
// ReSharper disable StyleCop.SA1601

namespace IP_MJPEG_Restreamer
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Timers;
    using System.Windows;
    using System.Windows.Input;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.UI;
    using VisioForge.Core.VideoCapture;
    using Application = System.Windows.Forms.Application;

    public partial class Window1 : IDisposable
    {     
        private Timer tmRecording = new Timer(1000);

        private ONVIFControl onvifControl;

        private VideoCaptureCore VideoCapture1;

        private bool disposedValue;

        public Window1()
        {
            InitializeComponent();

            Application.EnableVisualStyles();
        }

        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnNetworkSourceDisconnect += VideoCapture1_OnNetworkSourceDisconnect;
        }

        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;
                VideoCapture1.OnNetworkSourceDisconnect -= VideoCapture1_OnNetworkSourceDisconnect;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        private void lbVLCRedist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx86UI);
            Process.Start(startInfo);
        }

        private void Form1_Load(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{VideoCapture1.SDK_Version()})";

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };
            cbIPCameraType.SelectedIndex = 2;
}

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (onvifControl != null)
            {
                onvifControl.Disconnect();
                onvifControl.Dispose();
                onvifControl = null;

                btONVIFConnect.Content = "Connect";
            }

            mmLog.Clear();

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Audio_RecordAudio = VideoCapture1.Audio_PlayAudio = false;

            VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.WPF_WinUI_Callback;

            // source
            VideoCapture1.IP_Camera_Source = new IPCameraSourceSettings
            {
                URL = new Uri(cbIPURL.Text)
            };

            bool lavGPU = false;
            switch (cbIPCameraType.SelectedIndex)
            {
                case 0:
                    VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.Auto_VLC;
                    break;
                case 1:
                    VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.Auto_FFMPEG;
                    break;
                case 2:
                    VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.Auto_LAV;
                    break;
                case 3:
                    VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.Auto_LAV;
                    lavGPU = true;
                    break;
                case 4:
                    VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.MMS_WMV;
                    break;
                case 5:
                    VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.HTTP_MJPEG_LowLatency;
                    cbIPAudioCapture.IsChecked = false;
                    VideoCapture1.Audio_RecordAudio = false;
                    VideoCapture1.Audio_PlayAudio = false;
                    break;
                case 6:
                    VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.RTSP_LowLatency;
                    VideoCapture1.IP_Camera_Source.RTSP_LowLatency_UseUDP = false;
                    break;
                case 7:
                    VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.RTSP_LowLatency;
                    VideoCapture1.IP_Camera_Source.RTSP_LowLatency_UseUDP = true;
                    break;
                case 8:
                    VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.NDI;
                    break;
                case 9:
                    VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.NDI_Legacy;
                    break;
            }

            VideoCapture1.IP_Camera_Source.AudioCapture = cbIPAudioCapture.IsChecked == true;
            VideoCapture1.IP_Camera_Source.Login = edIPLogin.Text;
            VideoCapture1.IP_Camera_Source.Password = edIPPassword.Text;
            VideoCapture1.IP_Camera_Source.VLC_ZeroClockJitterEnabled = cbVLCZeroClockJitter.IsChecked == true;
            VideoCapture1.IP_Camera_Source.VLC_CustomLatency = Convert.ToInt32(edVLCCacheSize.Text);
            VideoCapture1.IP_Camera_Source.ForcedFramerate = Convert.ToDouble(edIPForcedFramerate.Text);
            VideoCapture1.IP_Camera_Source.ForcedFramerate_InstanceID = edIPForcedFramerateID.Text[0];

            if (VideoCapture1.IP_Camera_Source.Type == IPSourceEngine.Auto_LAV)
            {
                VideoCapture1.IP_Camera_Source.LAV_GPU_Use = lavGPU;
                VideoCapture1.IP_Camera_Source.LAV_GPU_Mode = LAVGPUDecoder.DXVA2CopyBack;
            }

            if (cbIPCameraONVIF.IsChecked == true)
            {
                VideoCapture1.IP_Camera_Source.ONVIF_Source = true;

                if (cbONVIFProfile.SelectedIndex != -1)
                {
                    VideoCapture1.IP_Camera_Source.ONVIF_SourceProfile = cbONVIFProfile.Text;
                }
            }

            if (cbIPDisconnect.IsChecked == true)
            {
                VideoCapture1.IP_Camera_Source.DisconnectEventInterval = TimeSpan.FromSeconds(10);
            }
            else
            {
                VideoCapture1.IP_Camera_Source.DisconnectEventInterval = TimeSpan.Zero;
            }

                VideoCapture1.Mode = VideoCaptureMode.IPPreview;
            
            // MJPEG streaming
            VideoCapture1.Network_Streaming_Enabled = true;
            VideoCapture1.Network_Streaming_Audio_Enabled = false;
            VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.HTTP_MJPEG;
            VideoCapture1.Network_Streaming_Output = new MJPEGOutput(Convert.ToInt32(edMJPEGPort.Text));

            VideoView1.StatusOverlay = new TextStatusOverlay();

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 2;
            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
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

                    if (onvifControl != null)
                    {
                        onvifControl.Disconnect();
                        onvifControl.Dispose();
                        onvifControl = null;
                    }

                    if (string.IsNullOrEmpty(edONVIFLogin.Text) || string.IsNullOrEmpty(edONVIFPassword.Text))
                    {
                        MessageBox.Show("Please specify IP camera user name and password.");
                        return;
                    }

                    onvifControl = new ONVIFControl();
                    var result = await onvifControl.ConnectAsync(edONVIFURL.Text, edONVIFLogin.Text, edONVIFPassword.Text);
                    if (!result)
                    {
                        onvifControl = null;
                        MessageBox.Show("Unable to connect to ONVIF camera.");
                        return;
                    }

                    var deviceInfo = await onvifControl.GetDeviceInformationAsync();
                    if (deviceInfo != null)
                    {
                        lbONVIFCameraInfo.Content = $"Model {deviceInfo.Model}, Firmware {deviceInfo.Firmware}";
                    }

                    cbONVIFProfile.Items.Clear();
                    var profiles = await onvifControl.GetProfilesAsync();
                    foreach (var profile in profiles)
                    {
                        cbONVIFProfile.Items.Add($"{profile.Name}");
                    }

                    if (cbONVIFProfile.Items.Count > 0)
                    {
                        cbONVIFProfile.SelectedIndex = 0;
                    }

                    edONVIFLiveVideoURL.Text = cbIPURL.Text = await onvifControl.GetVideoURLAsync();

                    edIPLogin.Text = edONVIFLogin.Text;
                    edIPPassword.Text = edONVIFPassword.Text;

                    btONVIFConnect.Content = "Disconnect";
                }
                finally
                {
                    btONVIFConnect.IsEnabled = true;
                    btONVIFConnect.Content = "Connect";
                }
            }
            else
            {
                btONVIFConnect.Content = "Connect";

                if (onvifControl != null)
                {
                    onvifControl.Disconnect();
                    onvifControl.Dispose();
                    onvifControl = null;
                }
            }
        }

        private void UpdateRecordingTime()
        {
            var ts = VideoCapture1.Duration_Time();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private void lbVLCRedist64_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx64UI);
            Process.Start(startInfo);
        }

        private void lbNDIVendor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor);
            Process.Start(startInfo);
        }

        private async void btListNDISources_Click(object sender, RoutedEventArgs e)
        {
            cbIPURL.Items.Clear();

            var lst = await VideoCapture1.IP_Camera_NDI_ListSourcesAsync();
            foreach (var uri in lst)
            {
                cbIPURL.Items.Add(uri);
            }

            if (cbIPURL.Items.Count > 0)
            {
                cbIPURL.SelectedIndex = 0;
            }
        }

        private async void btListONVIFSources_Click(object sender, RoutedEventArgs e)
        {
            cbIPURL.Items.Clear();

            var lst = await VideoCapture1.IP_Camera_ONVIF_ListSourcesAsync(null, null);
            foreach (var uri in lst)
            {
                cbIPURL.Items.Add(uri);
            }

            if (cbIPURL.Items.Count > 0)
            {
                cbIPURL.SelectedIndex = 0;
            }
        }

        private void VideoCapture1_OnNetworkSourceDisconnect(object sender, EventArgs e)
        {
            Dispatcher.Invoke((Action)(
                               async () =>
                                   {
                                       await VideoCapture1.StopAsync();

                                       MessageBox.Show("Network source stopped or disconnected!");
                                   }));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (onvifControl != null)
                    {
                        onvifControl.Dispose();
                        onvifControl = null;
                    }

                    tmRecording?.Dispose();
                    tmRecording = null;

                    VideoCapture1?.Dispose();
                    VideoCapture1 = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
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