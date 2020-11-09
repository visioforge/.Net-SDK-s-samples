// ReSharper disable InconsistentNaming

// ReSharper disable StyleCop.SA1600
// ReSharper disable StyleCop.SA1601

namespace IP_Capture
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using Microsoft.Win32;

    using VisioForge.Controls.UI;
    using VisioForge.Controls.UI.Dialogs;
    using VisioForge.Controls.UI.Dialogs.OutputFormats;
    using VisioForge.Controls.UI.Dialogs.VideoEffects;
    using VisioForge.Shared.IPCameraDB;
    using VisioForge.Tools;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.Sources;
    using VisioForge.Types.VideoEffects;

    using Application = System.Windows.Forms.Application;

    public partial class Window1
    {
        private MFSettingsDialog mp4v11SettingsDialog;

        private MFSettingsDialog mpegTSSettingsDialog;

        private MFSettingsDialog movSettingsDialog;

        private MP4v10SettingsDialog mp4V10SettingsDialog;

        private AVISettingsDialog aviSettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private GIFSettingsDialog gifSettingsDialog;

        private readonly SaveFileDialog screenshotSaveDialog = new SaveFileDialog
                                                                   {
                                                                       FileName = "image.jpg",
                                                                       Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
                                                                       InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\"
                                                                   };

        private readonly Timer tmRecording = new Timer(1000);

        private readonly SaveFileDialog saveFileDialog1 = new SaveFileDialog();

#if !NETCOREAPP
        private ONVIFControl onvifControl;
#endif

        private ONVIFPTZRanges onvifPtzRanges;

        private float onvifPtzX;

        private float onvifPtzY;

        private float onvifPtzZoom;
        
        public Window1()
        {
            InitializeComponent();

            Application.EnableVisualStyles();
        }

        private void lbVLCRedist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx86UI);
            Process.Start(startInfo);
        }

        private void Form1_Load(object sender, RoutedEventArgs e)
        {
            Title += " (SDK v" + VideoCapture1.SDK_Version + ", " + VideoCapture1.SDK_State + ")";

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };

            cbOutputFormat.SelectedIndex = 2;
            cbIPCameraType.SelectedIndex = 2;

            edOutput.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" +
                            "output.mp4";
        }
        
        private async void btSaveScreenshot_Click(object sender, RoutedEventArgs e)
        {
            if (screenshotSaveDialog.ShowDialog() == true)
            {
                var filename = screenshotSaveDialog.FileName;
                var ext = Path.GetExtension(filename).ToLowerInvariant();
                switch (ext)
                {
                    case ".bmp":
                        await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.BMP, 0);
                        break;
                    case ".jpg":
                        await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.JPEG, 85);
                        break;
                    case ".gif":
                        await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.GIF, 0);
                        break;
                    case ".png":
                        await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.PNG, 0);
                        break;
                    case ".tiff":
                        await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.TIFF, 0);
                        break;
                }
            }
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }
        
        private void SetMP4Output(ref VFMP4v8v10Output mp4Output)
        {
            if (mp4V10SettingsDialog == null)
            {
                mp4V10SettingsDialog = new MP4v10SettingsDialog();
            }

            mp4V10SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetWMVOutput(ref VFWMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }
        
        private void SetMP4v11Output(ref VFMP4v11Output mp4Output)
        {
            if (mp4v11SettingsDialog == null)
            {
                mp4v11SettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MP4v11);
            }

            mp4v11SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetMPEGTSOutput(ref VFMPEGTSOutput mpegTSOutput)
        {
            if (mpegTSSettingsDialog == null)
            {
                mpegTSSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MPEGTS);
            }

            mpegTSSettingsDialog.SaveSettings(ref mpegTSOutput);
        }

        private void SetMOVOutput(ref VFMOVOutput mkvOutput)
        {
            if (movSettingsDialog == null)
            {
                movSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MOV);
            }

            movSettingsDialog.SaveSettings(ref mkvOutput);
        }

        private void SetGIFOutput(ref VFAnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        private void SetAVIOutput(ref VFAVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(
                    VideoCapture1.Video_Codecs.ToArray(),
                    VideoCapture1.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new VFMP3Output();
                aviOutput.MP3 = mp3Output;
            }
        }
        
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
#if !NETCOREAPP
            if (onvifControl != null)
            {
                onvifControl.Disconnect();
                onvifControl.Dispose();
                onvifControl = null;

                btONVIFConnect.Content = "Connect";
            }

#endif

            mmLog.Clear();

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";

            VideoCapture1.Audio_RecordAudio = cbIPAudioCapture.IsChecked == true;
            VideoCapture1.Audio_PlayAudio = cbIPAudioCapture.IsChecked == true;

            VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRendererWPF.WPF;

            // source
            VideoCapture1.IP_Camera_Source = new IPCameraSourceSettings
            {
                URL = cbIPURL.Text
            };

            switch (cbIPCameraType.SelectedIndex)
            {
                case 0:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.Auto_VLC;
                    break;
                case 1:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.Auto_FFMPEG;
                    break;
                case 2:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.Auto_LAV;
                    break;
                case 3:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.RTSP_Live555;
                    break;
                case 4:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.HTTP_FFMPEG;
                    break;
                case 5:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.MMS_WMV;
                    break;
                case 6:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.RTSP_UDP_FFMPEG;
                    break;
                case 7:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.RTSP_TCP_FFMPEG;
                    break;
                case 8:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.RTSP_HTTP_FFMPEG;
                    break;
                case 9:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.HTTP_MJPEG_LowLatency;
                    cbIPAudioCapture.IsChecked = false;
                    VideoCapture1.Audio_RecordAudio = false;
                    VideoCapture1.Audio_PlayAudio = false;

                    break;

                case 10:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.RTSP_LowLatency;
                    VideoCapture1.IP_Camera_Source.RTSP_LowLatency_UseUDP = false;
                    break;
                case 11:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.RTSP_LowLatency;
                    VideoCapture1.IP_Camera_Source.RTSP_LowLatency_UseUDP = true;
                    break;
                case 12:
                    VideoCapture1.IP_Camera_Source.Type = VFIPSource.NDI;
                    break;
            }

            VideoCapture1.IP_Camera_Source.AudioCapture = cbIPAudioCapture.IsChecked == true;
            VideoCapture1.IP_Camera_Source.Login = edIPLogin.Text;
            VideoCapture1.IP_Camera_Source.Password = edIPPassword.Text;
            VideoCapture1.IP_Camera_Source.VLC_ZeroClockJitterEnabled = cbVLCZeroClockJitter.IsChecked == true;
            VideoCapture1.IP_Camera_Source.VLC_CustomLatency = Convert.ToInt32(edVLCCacheSize.Text);
            VideoCapture1.IP_Camera_Source.ForcedFramerate = Convert.ToDouble(edIPForcedFramerate.Text);
            VideoCapture1.IP_Camera_Source.ForcedFramerate_InstanceID = edIPForcedFramerateID.Text[0];

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
                VideoCapture1.IP_Camera_Source.DisconnectEventInterval = 5000;
            }

            if (rbPreview.IsChecked == true)
            {
                VideoCapture1.Mode = VFVideoCaptureMode.IPPreview;
            }
            else if (rbCapture.IsChecked == true)
            {
                VideoCapture1.Mode = VFVideoCaptureMode.IPCapture;

                VideoCapture1.Output_Filename = edOutput.Text;

                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            var aviOutput = new VFAVIOutput();
                            SetAVIOutput(ref aviOutput);
                            VideoCapture1.Output_Format = aviOutput;

                            break;
                        }
                    case 1:
                        {
                            var wmvOutput = new VFWMVOutput();
                            SetWMVOutput(ref wmvOutput);
                            VideoCapture1.Output_Format = wmvOutput;

                            break;
                        }
                    case 2:
                        {
                            var mp4Output = new VFMP4v8v10Output();
                            SetMP4Output(ref mp4Output);
                            VideoCapture1.Output_Format = mp4Output;

                            break;
                        }
                    case 3:
                        {
                            var mp4Output = new VFMP4v11Output();
                            SetMP4v11Output(ref mp4Output);
                            VideoCapture1.Output_Format = mp4Output;

                            break;
                        }
                    case 4:
                        {
                            var gifOutput = new VFAnimatedGIFOutput();
                            SetGIFOutput(ref gifOutput);

                            VideoCapture1.Output_Format = gifOutput;

                            break;
                        }
                    case 5:
                        {
                            var tsOutput = new VFMPEGTSOutput();
                            SetMPEGTSOutput(ref tsOutput);
                            VideoCapture1.Output_Format = tsOutput;

                            break;
                        }
                    case 6:
                        {
                            var movOutput = new VFMOVOutput();
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

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }

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

        private void VideoCapture1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            Log("(NOT ERROR) " + e.Message);
        }

        private void btShowIPCamDatabase_Click(object sender, RoutedEventArgs e)
        {
            IPCameraDB.ShowWindow();
        }

        private void btONVIFConnect_Click(object sender, RoutedEventArgs e)
        {
#if NETCOREAPP
            MessageBox.Show("ONVIF not avauilable for .Net Core SDK build.");
#else
            if (btONVIFConnect.Content.ToString() == "Connect")
            {
                btONVIFConnect.Content = "Disconnect";

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
                var result = onvifControl.Connect(edONVIFURL.Text, edONVIFLogin.Text, edONVIFPassword.Text);
                if (!result)
                {
                    onvifControl = null;
                    MessageBox.Show("Unable to connect to ONVIF camera.");
                    return;
                }

                var deviceInfo = onvifControl.GetDeviceInformation();
                lbONVIFCameraInfo.Content = $"Model {deviceInfo.Model}, Firmware {deviceInfo.Firmware}";

                edONVIFLiveVideoURL.Text = cbIPURL.Text = onvifControl.GetVideoURL();

                edIPLogin.Text = edONVIFLogin.Text;
                edIPPassword.Text = edONVIFPassword.Text;

                cbONVIFProfile.Items.Clear();
                var profiles = onvifControl.GetProfiles();
                foreach (var profile in profiles)
                {
                    cbONVIFProfile.Items.Add($"{profile.Name}");
                }

                if (cbONVIFProfile.Items.Count > 0)
                {
                    cbONVIFProfile.SelectedIndex = 0;
                }

                onvifPtzRanges = onvifControl.PTZ_GetRanges();
                onvifControl.PTZ_SetAbsolute(0, 0, 0);

                onvifPtzX = 0;
                onvifPtzY = 0;
                onvifPtzZoom = 0;
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

#endif
        }

        private void btONVIFRight_Click(object sender, RoutedEventArgs e)
        {
#if NETCOREAPP
            MessageBox.Show("ONVIF not avauilable for .Net Core SDK build.");
#else
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxX - onvifPtzRanges.MinX) / 30;
            onvifPtzX = onvifPtzX - step;

            if (onvifPtzX < onvifPtzRanges.MinX)
            {
                onvifPtzX = onvifPtzRanges.MinX;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
#endif
        }

        private void btONVIFPTZSetDefault_Click(object sender, RoutedEventArgs e)
        {
#if NETCOREAPP
            MessageBox.Show("ONVIF not avauilable for .Net Core SDK build.");
#else
            onvifControl?.PTZ_SetAbsolute(0, 0, 0);
#endif
        }

        private void btONVIFLeft_Click(object sender, RoutedEventArgs e)
        {
#if NETCOREAPP
            MessageBox.Show("ONVIF not avauilable for .Net Core SDK build.");
#else
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxX - onvifPtzRanges.MinX) / 30;
            onvifPtzX = onvifPtzX + step;

            if (onvifPtzX > onvifPtzRanges.MaxX)
            {
                onvifPtzX = onvifPtzRanges.MaxX;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
#endif
        }

        private void btONVIFUp_Click(object sender, RoutedEventArgs e)
        {
#if NETCOREAPP
            MessageBox.Show("ONVIF not avauilable for .Net Core SDK build.");
#else
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxY - onvifPtzRanges.MinY) / 30;
            onvifPtzY = onvifPtzY - step;

            if (onvifPtzY < onvifPtzRanges.MinY)
            {
                onvifPtzY = onvifPtzRanges.MinY;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
#endif
        }

        private void btONVIFDown_Click(object sender, RoutedEventArgs e)
        {
#if NETCOREAPP
            MessageBox.Show("ONVIF not avauilable for .Net Core SDK build.");
#else
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxY - onvifPtzRanges.MinY) / 30;
            onvifPtzY = onvifPtzY + step;

            if (onvifPtzY > onvifPtzRanges.MaxY)
            {
                onvifPtzY = onvifPtzRanges.MaxY;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
#endif
        }

        private void btONVIFZoomIn_Click(object sender, RoutedEventArgs e)
        {
#if NETCOREAPP
            MessageBox.Show("ONVIF not avauilable for .Net Core SDK build.");
#else
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxZoom - onvifPtzRanges.MinZoom) / 100;
            onvifPtzZoom = onvifPtzZoom + step;

            if (onvifPtzZoom > onvifPtzRanges.MaxZoom)
            {
                onvifPtzZoom = onvifPtzRanges.MaxZoom;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
#endif
        }

        private void btONVIFZoomOut_Click(object sender, RoutedEventArgs e)
        {
#if NETCOREAPP
            MessageBox.Show("ONVIF not avauilable for .Net Core SDK build.");
#else
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxZoom - onvifPtzRanges.MinZoom) / 100;
            onvifPtzZoom = onvifPtzZoom - step;

            if (onvifPtzZoom < onvifPtzRanges.MinZoom)
            {
                onvifPtzZoom = onvifPtzRanges.MinZoom;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
#endif
        }

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
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
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

        private async void BtResume_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        private async void BtPause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        private void BtOutputConfigure_Click(object sender, RoutedEventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray());
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
                        if (mp4V10SettingsDialog == null)
                        {
                            mp4V10SettingsDialog = new MP4v10SettingsDialog();
                        }

                        mp4V10SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 3:
                    {
                        if (mp4v11SettingsDialog == null)
                        {
                            mp4v11SettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MP4v11);
                        }

                        mp4v11SettingsDialog.ShowDialog(this);

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
                            mpegTSSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MPEGTS);
                        }

                        mpegTSSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 6:
                    {
                        if (movSettingsDialog == null)
                        {
                            movSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MOV);
                        }

                        movSettingsDialog.ShowDialog(this);

                        break;
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

        private void cbGreyscale_CheckedChanged(object sender, RoutedEventArgs e)
        {
            IVFVideoEffectGrayscale grayscale;
            var effect = VideoCapture1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VFVideoEffectGrayscale(cbGreyscale.IsChecked == true);
                VideoCapture1.Video_Effects_Add(grayscale);
            }
            else
            {
                grayscale = effect as IVFVideoEffectGrayscale;
                if (grayscale != null)
                {
                    grayscale.Enabled = cbGreyscale.IsChecked == true;
                }
            }
        }

        private void tbContrast_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVFVideoEffectContrast contrast;
            var effect = VideoCapture1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VFVideoEffectContrast(true, (int)tbContrast.Value);
                VideoCapture1.Video_Effects_Add(contrast);
            }
            else
            {
                contrast = effect as IVFVideoEffectContrast;
                if (contrast != null)
                {
                    contrast.Value = (int)tbContrast.Value;
                }
            }
        }

        private void tbDarkness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVFVideoEffectDarkness darkness;
            var effect = VideoCapture1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VFVideoEffectDarkness(true, (int)tbDarkness.Value);
                VideoCapture1.Video_Effects_Add(darkness);
            }
            else
            {
                darkness = effect as IVFVideoEffectDarkness;
                if (darkness != null)
                {
                    darkness.Value = (int)tbDarkness.Value;
                }
            }
        }

        private void tbLightness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVFVideoEffectLightness lightness;
            var effect = VideoCapture1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VFVideoEffectLightness(true, (int)tbLightness.Value);
                VideoCapture1.Video_Effects_Add(lightness);
            }
            else
            {
                lightness = effect as IVFVideoEffectLightness;
                if (lightness != null)
                {
                    lightness.Value = (int)tbLightness.Value;
                }
            }
        }

        private void tbSaturation_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 != null)
            {
                IVFVideoEffectSaturation saturation;
                var effect = VideoCapture1.Video_Effects_Get("Saturation");
                if (effect == null)
                {
                    saturation = new VFVideoEffectSaturation((int)tbSaturation.Value);
                    VideoCapture1.Video_Effects_Add(saturation);
                }
                else
                {
                    saturation = effect as IVFVideoEffectSaturation;
                    if (saturation != null)
                    {
                        saturation.Value = (int)tbSaturation.Value;
                    }
                }
            }
        }

        private void cbInvert_CheckedChanged(object sender, RoutedEventArgs e)
        {
            IVFVideoEffectInvert invert;
            var effect = VideoCapture1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VFVideoEffectInvert(cbInvert.IsChecked == true);
                VideoCapture1.Video_Effects_Add(invert);
            }
            else
            {
                invert = effect as IVFVideoEffectInvert;
                if (invert != null)
                {
                    invert.Enabled = cbInvert.IsChecked == true;
                }
            }
        }

        private void CbFlipX_Checked(object sender, RoutedEventArgs e)
        {
            IVFVideoEffectFlipDown flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipHorizontal(cbFlipX.IsChecked == true);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVFVideoEffectFlipDown;
                if (flip != null)
                {
                    flip.Enabled = cbFlipX.IsChecked == true;
                }
            }
        }

        private void CbFlipY_Checked(object sender, RoutedEventArgs e)
        {
            IVFVideoEffectFlipRight flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipVertical(cbFlipY.IsChecked == true);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVFVideoEffectFlipRight;
                if (flip != null)
                {
                    flip.Enabled = cbFlipY.IsChecked == true;
                }
            }
        }

        private void BtImageLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ImageLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoCapture1);
            var effect = new VFVideoEffectImageLogo(true, name);

            VideoCapture1.Video_Effects_Add(effect);
            lbLogos.Items.Add(effect.Name);

            dlg.Fill(effect);
            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private void BtTextLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new TextLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoCapture1);
            var effect = new VFVideoEffectTextLogo(true, name);

            VideoCapture1.Video_Effects_Add(effect);
            lbLogos.Items.Add(effect.Name);
            dlg.Fill(effect);

            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private void BtLogoEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                var effect = VideoCapture1.Video_Effects_Get((string)lbLogos.SelectedItem);
                if (effect.GetEffectType() == VFVideoEffectType.TextLogo)
                {
                    var dlg = new TextLogoSettingsDialog();

                    dlg.Attach(effect);

                    dlg.ShowDialog(this);
                    dlg.Dispose();
                }
                else if (effect.GetEffectType() == VFVideoEffectType.ImageLogo)
                {
                    var dlg = new ImageLogoSettingsDialog();

                    dlg.Attach(effect);

                    dlg.ShowDialog(this);
                    dlg.Dispose();
                }
            }
        }

        private void BtLogoRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                VideoCapture1.Video_Effects_Remove((string)lbLogos.SelectedItem);
                lbLogos.Items.Remove(lbLogos.SelectedItem);
            }
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

        private void btListNDISources_Click(object sender, RoutedEventArgs e)
        {
            cbIPURL.Items.Clear();

            var lst = VideoCapture1.IP_Camera_NDI_ListSources();
            foreach (var uri in lst)
            {
                cbIPURL.Items.Add(uri);
            }

            if (cbIPURL.Items.Count > 0)
            {
                cbIPURL.SelectedIndex = 0;
            }
        }
    }
}

// ReSharper restore InconsistentNaming