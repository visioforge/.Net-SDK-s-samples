




namespace IP_Capture
{
    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Threading.Tasks;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using VisioForge.Core;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.ONVIFX;
    using VisioForge.Core.ONVIFDiscovery;
    using VisioForge.Core.ONVIFDiscovery.Models;
    using System.Linq;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.Types.VideoEffects;
    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WinForms.Dialogs;
    using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
    using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;
    using VisioForge.Core.UI.WPF;
    using VisioForge.Core.VideoCapture;
    using Application = System.Windows.Forms.Application;

    public partial class Window1 : IDisposable
    {
        /// <summary>
        /// MP4 HW settings dialog.
        /// </summary>
        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;

        /// <summary>
        /// MPEG TS settings dialog.
        /// </summary>
        private HWEncodersOutputSettingsDialog mpegTSSettingsDialog;

        /// <summary>
        /// MOV settings dialog.
        /// </summary>
        private HWEncodersOutputSettingsDialog movSettingsDialog;

        /// <summary>
        /// MP4 settings dialog.
        /// </summary>
        private MP4SettingsDialog mp4SettingsDialog;

        /// <summary>
        /// AVI settings dialog.
        /// </summary>
        private AVISettingsDialog aviSettingsDialog;

        /// <summary>
        /// WMV settings dialog.
        /// </summary>
        private WMVSettingsDialog wmvSettingsDialog;

        /// <summary>
        /// GIF settings dialog.
        /// </summary>
        private GIFSettingsDialog gifSettingsDialog;

        /// <summary>
        /// Screenshot save dialog.
        /// </summary>
        private SaveFileDialog screenshotSaveDialog = new SaveFileDialog
        {
            FileName = "image.jpg",
            Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
        };

        /// <summary>
        /// Recording timer.
        /// </summary>
        private Timer tmRecording = new Timer(1000);

        /// <summary>
        /// Save file dialog 1.
        /// </summary>
        private readonly SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        /// <summary>
        /// The ONVIF client.
        /// </summary>
        private ONVIFClientX onvifClient;

        // PTZ ranges will be handled differently in the new API

        /// <summary>
        /// The video capture.
        /// </summary>
        private VideoCaptureCore VideoCapture1;
        /// <summary>
        /// The disposed value.
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
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnNetworkSourceDisconnect += VideoCapture1_OnNetworkSourceDisconnect;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
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

        /// <summary>
        /// Form 1 load.
        /// </summary>
        /// <summary>
        /// Form 1 load.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            await CreateEngineAsync();

            Title += $" (SDK v{VideoCapture1.SDK_Version()})";

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };

            cbOutputFormat.SelectedIndex = 2;
            cbIPCameraType.SelectedIndex = 2;

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
        }

        /// <summary>
        /// Handles the bt save screenshot click event.
        /// </summary>
        /// <summary>
        /// Handles the bt save screenshot click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void btSaveScreenshot_Click(object sender, RoutedEventArgs e)
        {
            if (screenshotSaveDialog.ShowDialog() == true)
            {
                var filename = screenshotSaveDialog.FileName;
                var ext = Path.GetExtension(filename).ToLowerInvariant();
                switch (ext)
                {
                    case ".bmp":
                        await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Bmp, 0);
                        break;
                    case ".jpg":
                        await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Jpeg, 85);
                        break;
                    case ".gif":
                        await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Gif, 0);
                        break;
                    case ".png":
                        await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Png, 0);
                        break;
                    case ".tiff":
                        await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Tiff, 0);
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the bt select output click event.
        /// </summary>
        /// <summary>
        /// Handles the bt select output click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Set mp 4 output.
        /// </summary>
        private void SetMP4Output(ref MP4Output mp4Output)
        {
            if (this.mp4SettingsDialog == null)
            {
                this.mp4SettingsDialog = new MP4SettingsDialog();
            }

            this.mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Set wmv output.
        /// </summary>
        private void SetWMVOutput(ref WMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        /// <summary>
        /// Set mp 4 hw output.
        /// </summary>
        private void SetMP4HWOutput(ref MP4HWOutput mp4Output)
        {
            if (mp4HWSettingsDialog == null)
            {
                mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
            }

            mp4HWSettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Set mpegts output.
        /// </summary>
        private void SetMPEGTSOutput(ref MPEGTSOutput mpegTSOutput)
        {
            if (mpegTSSettingsDialog == null)
            {
                mpegTSSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
            }

            mpegTSSettingsDialog.SaveSettings(ref mpegTSOutput);
        }

        /// <summary>
        /// Set mov output.
        /// </summary>
        private void SetMOVOutput(ref MOVOutput mkvOutput)
        {
            if (movSettingsDialog == null)
            {
                movSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV);
            }

            movSettingsDialog.SaveSettings(ref mkvOutput);
        }

        /// <summary>
        /// Set gif output.
        /// </summary>
        private void SetGIFOutput(ref AnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        /// <summary>
        /// Set avi output.
        /// </summary>
        private void SetAVIOutput(ref AVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoCapture1);
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new MP3Output();
                aviOutput.MP3 = mp3Output;
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient != null)
            {
                onvifClient.Dispose();
                onvifClient = null;

                btONVIFConnect.Content = "Connect";
            }

            mmLog.Clear();

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Audio_RecordAudio = cbIPAudioCapture.IsChecked == true;
            VideoCapture1.Audio_PlayAudio = cbIPAudioCapture.IsChecked == true;

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
            VideoCapture1.IP_Camera_Source.ForcedFramerate = new VideoFrameRate(Convert.ToInt32(edIPForcedFramerate.Text));
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

            if (rbPreview.IsChecked == true)
            {
                VideoCapture1.Mode = VideoCaptureMode.IPPreview;
            }
            else if (rbCapture.IsChecked == true)
            {
                VideoCapture1.Mode = VideoCaptureMode.IPCapture;

                VideoCapture1.Output_Filename = edOutput.Text;

                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            var aviOutput = new AVIOutput();
                            SetAVIOutput(ref aviOutput);
                            VideoCapture1.Output_Format = aviOutput;

                            break;
                        }
                    case 1:
                        {
                            var wmvOutput = new WMVOutput();
                            SetWMVOutput(ref wmvOutput);
                            VideoCapture1.Output_Format = wmvOutput;

                            break;
                        }
                    case 2:
                        {
                            var mp4Output = new MP4Output();
                            SetMP4Output(ref mp4Output);
                            VideoCapture1.Output_Format = mp4Output;

                            break;
                        }
                    case 3:
                        {
                            var mp4Output = new MP4HWOutput();
                            SetMP4HWOutput(ref mp4Output);
                            VideoCapture1.Output_Format = mp4Output;

                            break;
                        }
                    case 4:
                        {
                            var gifOutput = new AnimatedGIFOutput();
                            SetGIFOutput(ref gifOutput);

                            VideoCapture1.Output_Format = gifOutput;

                            break;
                        }
                    case 5:
                        {
                            var tsOutput = new MPEGTSOutput();
                            SetMPEGTSOutput(ref tsOutput);
                            VideoCapture1.Output_Format = tsOutput;

                            break;
                        }
                    case 6:
                        {
                            var movOutput = new MOVOutput();
                            SetMOVOutput(ref movOutput);
                            VideoCapture1.Output_Format = movOutput;

                            break;
                        }
                }
            }

            VideoCapture1.Video_Effects_Enabled = true;
            VideoCapture1.Video_Effects_Clear();
            lbLogos.Items.Clear();
            ConfigureVideoEffects();

            VideoView1.StatusOverlay = new TextStatusOverlay();

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }

        /// <summary>
        /// Configure video effects.
        /// </summary>
        private void ConfigureVideoEffects()
        {
            if (tbLightness.Value > 0)
            {
                tbLightness_Scroll(null, null);
            }

            if (tbSaturation.Value < 255)
            {
                tbSaturation_Scroll(null, null);
            }

            if (tbContrast.Value > 0)
            {
                tbContrast_Scroll(null, null);
            }

            if (tbDarkness.Value > 0)
            {
                tbDarkness_Scroll(null, null);
            }

            if (cbGreyscale.IsChecked == true)
            {
                cbGreyscale_CheckedChanged(null, null);
            }

            if (cbInvert.IsChecked == true)
            {
                cbInvert_CheckedChanged(null, null);
            }

            if (cbFlipX.IsChecked == true)
            {
                CbFlipX_Checked(null, null);
            }

            if (cbFlipY.IsChecked == true)
            {
                CbFlipY_Checked(null, null);
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
        }

        /// <summary>
        /// Ll video tutorials link clicked.
        /// </summary>
        /// <summary>
        /// Ll video tutorials link clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void llVideoTutorials_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Log.
        /// </summary>
        /// <summary>
        /// Log.
        /// </summary>
        /// <param name="txt">Text.</param>
        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Handles the bt onvif connect click event.
        /// </summary>
        /// <summary>
        /// Handles the bt onvif connect click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void btONVIFConnect_Click(object sender, RoutedEventArgs e)
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

                    if (onvifClient.DeviceInformation != null)
                    {
                        lbONVIFCameraInfo.Content = $"Model {onvifClient.DeviceInformation.Model}, Firmware {onvifClient.DeviceInformation.FirmwareVersion}";
                    }

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

                    // Initialize PTZ to center position
                    if (profiles != null && profiles.Length > 0)
                    {
                        await onvifClient.AbsoluteMoveAsync(profiles[0].token, 0, 0, 0, 1.0f, 1.0f, 1.0f);
                    }

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

                if (onvifClient != null)
                {
                    onvifClient.Dispose();
                    onvifClient = null;
                }
            }
        }

        /// <summary>
        /// Handles the bt onvif right click event.
        /// </summary>
        /// <summary>
        /// Handles the bt onvif right click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void btONVIFRight_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            var profiles = await onvifClient.GetProfilesAsync();
            if (profiles != null && profiles.Length > 0)
            {
                await onvifClient.ContinuousMoveAsync(profiles[0].token, 0.5f, 0f, 0f);
            }

            await Task.Delay(500); // Move for 500ms

            await onvifClient.StopMoveAsync(profiles[0].token, true, true);
        }

        /// <summary>
        /// Handles the bt onvifptz set default click event.
        /// </summary>
        /// <summary>
        /// Handles the bt onvifptz set default click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void btONVIFPTZSetDefault_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient != null)
            {
                var profiles = await onvifClient.GetProfilesAsync();
                if (profiles != null && profiles.Length > 0)
                {
                    await onvifClient.GotoHomePositionAsync(profiles[0].token);
                }
            }
        }

        /// <summary>
        /// Handles the bt onvif left click event.
        /// </summary>
        /// <summary>
        /// Handles the bt onvif left click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void btONVIFLeft_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            var profiles = await onvifClient.GetProfilesAsync();
            if (profiles != null && profiles.Length > 0)
            {
                await onvifClient.ContinuousMoveAsync(profiles[0].token, -0.5f, 0, 0f);
            }

            await Task.Delay(500); // Move for 500ms

            await onvifClient.StopMoveAsync(profiles[0].token, true, true);
        }

        /// <summary>
        /// Handles the bt onvif up click event.
        /// </summary>
        /// <summary>
        /// Handles the bt onvif up click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void btONVIFUp_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            var profiles = await onvifClient.GetProfilesAsync();
            if (profiles != null && profiles.Length > 0)
            {
                await onvifClient.ContinuousMoveAsync(profiles[0].token, 0f, 0.5f, 0.0f);
            }

            await Task.Delay(500); // Move for 500ms

            await onvifClient.StopMoveAsync(profiles[0].token, true, true);
        }

        /// <summary>
        /// Handles the bt onvif down click event.
        /// </summary>
        /// <summary>
        /// Handles the bt onvif down click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void btONVIFDown_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            var profiles = await onvifClient.GetProfilesAsync();
            if (profiles != null && profiles.Length > 0)
            {
                await onvifClient.ContinuousMoveAsync(profiles[0].token, 0, -0.5f, 0);
            }

            await Task.Delay(500); // Move for 500ms

            await onvifClient.StopMoveAsync(profiles[0].token, true, true);
        }

        /// <summary>
        /// Handles the bt onvif zoom in click event.
        /// </summary>
        /// <summary>
        /// Handles the bt onvif zoom in click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void btONVIFZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            var profiles = await onvifClient.GetProfilesAsync();
            if (profiles != null && profiles.Length > 0)
            {
                await onvifClient.ContinuousMoveAsync(profiles[0].token, 0, 0, 0.5f);
            }

            await Task.Delay(500); // Move for 500ms

            await onvifClient.StopMoveAsync(profiles[0].token, true, true);
        }

        /// <summary>
        /// Handles the bt onvif zoom out click event.
        /// </summary>
        /// <summary>
        /// Handles the bt onvif zoom out click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void btONVIFZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            var profiles = await onvifClient.GetProfilesAsync();
            if (profiles != null && profiles.Length > 0)
            {
                await onvifClient.ContinuousMoveAsync(profiles[0].token, 0, 0, -0.5f);
            }

            await Task.Delay(500); // Move for 500ms

            await onvifClient.StopMoveAsync(profiles[0].token, true, true);
        }

        /// <summary>
        /// Stop ptz movement async.
        /// </summary>
        private async Task StopPtzMovementAsync()
        {
            if (onvifClient == null)
            {
                return;
            }

            var profiles = await onvifClient.GetProfilesAsync();
            if (profiles != null && profiles.Length > 0)
            {
                await onvifClient.StopMoveAsync(profiles[0].token, true, true);
            }
        }

        /// <summary>
        /// Cb output format selection changed.
        /// </summary>
        /// <summary>
        /// Cb output format selection changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void cbOutputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 1:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv");
                        break;
                    }
                case 2:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4"); //-V3139
                        break;
                    }
                case 3:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 4:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif");
                        break;
                    }
                case 5:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ts");
                        break;
                    }
                case 6:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mov");
                        break;
                    }
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void BtResume_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private async void BtPause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        /// <summary>
        /// Handles the bt output configure click event.
        /// </summary>
        /// <summary>
        /// Handles the bt output configure click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void BtOutputConfigure_Click(object sender, RoutedEventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoCapture1);
                        }

                        aviSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 1:
                    {
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
                        }

                        wmvSettingsDialog.WMA = false;
                        wmvSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 2:
                    {
                        if (this.mp4SettingsDialog == null)
                        {
                            this.mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        this.mp4SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 3:
                    {
                        if (mp4HWSettingsDialog == null)
                        {
                            mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
                        }

                        mp4HWSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 4:
                    {
                        if (gifSettingsDialog == null)
                        {
                            gifSettingsDialog = new GIFSettingsDialog();
                        }

                        gifSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 5:
                    {
                        if (mpegTSSettingsDialog == null)
                        {
                            mpegTSSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
                        }

                        mpegTSSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 6:
                    {
                        if (movSettingsDialog == null)
                        {
                            movSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV);
                        }

                        movSettingsDialog.ShowDialog(this);

                        break;
                    }
            }
        }

        /// <summary>
        /// Update recording time.
        /// </summary>
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

        /// <summary>
        /// Handles the cb greyscale checked changed event.
        /// </summary>
        /// <summary>
        /// Handles the cb greyscale checked changed event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void cbGreyscale_CheckedChanged(object sender, RoutedEventArgs e)
        {
            IVideoEffectGrayscale grayscale;
            var effect = VideoCapture1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VideoEffectGrayscale(cbGreyscale.IsChecked == true);
                VideoCapture1.Video_Effects_Add(grayscale);
            }
            else
            {
                grayscale = effect as IVideoEffectGrayscale;
                if (grayscale != null)
                {
                    grayscale.Enabled = cbGreyscale.IsChecked == true;
                }
            }
        }

        /// <summary>
        /// Handles the tb contrast scroll event.
        /// </summary>
        /// <summary>
        /// Handles the tb contrast scroll event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void tbContrast_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectContrast contrast;
            var effect = VideoCapture1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VideoEffectContrast(true, (int)tbContrast.Value);
                VideoCapture1.Video_Effects_Add(contrast);
            }
            else
            {
                contrast = effect as IVideoEffectContrast;
                if (contrast != null)
                {
                    contrast.Value = (int)tbContrast.Value;
                }
            }
        }

        /// <summary>
        /// Handles the tb darkness scroll event.
        /// </summary>
        /// <summary>
        /// Handles the tb darkness scroll event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void tbDarkness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectDarkness darkness;
            var effect = VideoCapture1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VideoEffectDarkness(true, (int)tbDarkness.Value);
                VideoCapture1.Video_Effects_Add(darkness);
            }
            else
            {
                darkness = effect as IVideoEffectDarkness;
                if (darkness != null)
                {
                    darkness.Value = (int)tbDarkness.Value;
                }
            }
        }

        /// <summary>
        /// Handles the tb lightness scroll event.
        /// </summary>
        /// <summary>
        /// Handles the tb lightness scroll event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void tbLightness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectLightness lightness;
            var effect = VideoCapture1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VideoEffectLightness(true, (int)tbLightness.Value);
                VideoCapture1.Video_Effects_Add(lightness);
            }
            else
            {
                lightness = effect as IVideoEffectLightness;
                if (lightness != null)
                {
                    lightness.Value = (int)tbLightness.Value;
                }
            }
        }

        /// <summary>
        /// Handles the tb saturation scroll event.
        /// </summary>
        /// <summary>
        /// Handles the tb saturation scroll event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void tbSaturation_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 != null)
            {
                IVideoEffectSaturation saturation;
                var effect = VideoCapture1.Video_Effects_Get("Saturation");
                if (effect == null)
                {
                    saturation = new VideoEffectSaturation((int)tbSaturation.Value);
                    VideoCapture1.Video_Effects_Add(saturation);
                }
                else
                {
                    saturation = effect as IVideoEffectSaturation;
                    if (saturation != null)
                    {
                        saturation.Value = (int)tbSaturation.Value;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the cb invert checked changed event.
        /// </summary>
        /// <summary>
        /// Handles the cb invert checked changed event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void cbInvert_CheckedChanged(object sender, RoutedEventArgs e)
        {
            IVideoEffectInvert invert;
            var effect = VideoCapture1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VideoEffectInvert(cbInvert.IsChecked == true);
                VideoCapture1.Video_Effects_Add(invert);
            }
            else
            {
                invert = effect as IVideoEffectInvert;
                if (invert != null)
                {
                    invert.Enabled = cbInvert.IsChecked == true;
                }
            }
        }

        /// <summary>
        /// Cb flip checked.
        /// </summary>
        /// <summary>
        /// Cb flip checked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void CbFlipX_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectFlipDown flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VideoEffectFlipHorizontal(cbFlipX.IsChecked == true);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVideoEffectFlipDown;
                if (flip != null)
                {
                    flip.Enabled = cbFlipX.IsChecked == true;
                }
            }
        }

        /// <summary>
        /// Cb flip checked.
        /// </summary>
        /// <summary>
        /// Cb flip checked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void CbFlipY_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectFlipRight flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VideoEffectFlipVertical(cbFlipY.IsChecked == true);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVideoEffectFlipRight;
                if (flip != null)
                {
                    flip.Enabled = cbFlipY.IsChecked == true;
                }
            }
        }

        /// <summary>
        /// Handles the bt image logo add click event.
        /// </summary>
        /// <summary>
        /// Handles the bt image logo add click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void BtImageLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ImageLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoCapture1);
            var effect = new VideoEffectImageLogo(true, name);

            VideoCapture1.Video_Effects_Add(effect);
            lbLogos.Items.Add(effect.Name);

            dlg.Fill(effect);
            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        /// <summary>
        /// Handles the bt text logo add click event.
        /// </summary>
        /// <summary>
        /// Handles the bt text logo add click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void BtTextLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new TextLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoCapture1);
            var effect = new VideoEffectTextLogo(true, name);

            VideoCapture1.Video_Effects_Add(effect);
            lbLogos.Items.Add(effect.Name);
            dlg.Fill(effect);

            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        /// <summary>
        /// Handles the bt logo edit click event.
        /// </summary>
        /// <summary>
        /// Handles the bt logo edit click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void BtLogoEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                var effect = VideoCapture1.Video_Effects_Get((string)lbLogos.SelectedItem);
                if (effect == null)
                {
                    return;
                }

                if (effect.GetEffectType() == VideoEffectType.TextLogo)
                {
                    var dlg = new TextLogoSettingsDialog();

                    dlg.Attach(effect);

                    dlg.ShowDialog(this);
                    dlg.Dispose();
                }
                else if (effect.GetEffectType() == VideoEffectType.ImageLogo)
                {
                    var dlg = new ImageLogoSettingsDialog();

                    dlg.Attach(effect);

                    dlg.ShowDialog(this);
                    dlg.Dispose();
                }
            }
        }

        /// <summary>
        /// Handles the bt logo remove click event.
        /// </summary>
        /// <summary>
        /// Handles the bt logo remove click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void BtLogoRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                VideoCapture1.Video_Effects_Remove((string)lbLogos.SelectedItem);
                lbLogos.Items.Remove(lbLogos.SelectedItem);
            }
        }

        /// <summary>
        /// Lb ndi vendor mouse left button down.
        /// </summary>
        /// <summary>
        /// Lb ndi vendor mouse left button down.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void lbNDIVendor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the bt list ndi sources click event.
        /// </summary>
        /// <summary>
        /// Handles the bt list ndi sources click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
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

        /// <summary>
        /// Handles the bt list onvif sources click event.
        /// </summary>
        /// <summary>
        /// Handles the bt list onvif sources click event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
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

        /// <summary>
        /// Handles the video capture 1 on network source disconnect event.
        /// </summary>
        /// <summary>
        /// Handles the video capture 1 on network source disconnect event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void VideoCapture1_OnNetworkSourceDisconnect(object sender, EventArgs e)
        {
            Dispatcher.Invoke((Action)(
                               async () =>
                                   {
                                       await VideoCapture1.StopAsync();

                                       MessageBox.Show(this, "Network source stopped or disconnected!");
                                   }));
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        /// <summary>
        /// Window closing.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <summary>
        /// Dispose.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (onvifClient != null)
                    {
                        onvifClient.Dispose();
                        onvifClient = null;
                    }

                    mpegTSSettingsDialog?.Dispose();
                    mpegTSSettingsDialog = null;

                    mp4SettingsDialog?.Dispose();
                    mp4SettingsDialog = null;

                    mp4HWSettingsDialog?.Dispose();
                    mp4HWSettingsDialog = null;

                    movSettingsDialog?.Dispose();
                    movSettingsDialog = null;

                    gifSettingsDialog?.Dispose();
                    gifSettingsDialog = null;

                    aviSettingsDialog?.Dispose();
                    aviSettingsDialog = null;

                    wmvSettingsDialog?.Dispose();
                    wmvSettingsDialog = null;

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

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Window1()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

