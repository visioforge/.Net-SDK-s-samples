// ReSharper disable InconsistentNaming
// ReSharper disable StyleCop.SA1600
// ReSharper disable StyleCop.SA1601
// ReSharper disable UseObjectOrCollectionInitializer

namespace VisioForge_SDK_4_IP_Camera_CSharp_Demo
{
    using System;
    using System.Diagnostics;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
    using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Core;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.Types.VideoEffects;
    using VisioForge.Core.Helpers;
    using System.Threading.Tasks;
    using VisioForge.Core.ONVIFDiscovery.Models;
    using System.Linq;
    using VisioForge.Core.ONVIFX;

    public partial class Form1 : Form
    {
        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;

        private HWEncodersOutputSettingsDialog mpegTSSettingsDialog;

        private HWEncodersOutputSettingsDialog movSettingsDialog;

        private MP4SettingsDialog mp4SettingsDialog;

        private AVISettingsDialog aviSettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private GIFSettingsDialog gifSettingsDialog;

        private SaveFileDialog screenshotSaveDialog = new SaveFileDialog()
        {
            FileName = "image.jpg",
            Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
            InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
        };

        private ONVIFDeviceX onvifDeviceX;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private VideoCaptureCore VideoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private async Task CreateEngineAsync()
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync(VideoView1 as IVideoView);

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

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CreateEngineAsync();

            Text += $" (SDK v{VideoCapture1.SDK_Version()})";

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };

            cbIPCameraType.SelectedIndex = 2;
            cbOutputFormat.SelectedIndex = 2;

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            if (onvifDeviceX != null)
            {
                await onvifDeviceX.DisconnectAsync();
                onvifDeviceX.Dispose();
                onvifDeviceX = null;

                btONVIFConnect.Text = "Connect";
            }

            mmLog.Clear();

            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Audio_RecordAudio = cbIPAudioCapture.Checked;
            VideoCapture1.Audio_PlayAudio = cbIPAudioCapture.Checked;

            VideoCapture1.Video_Renderer_SetAuto();

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            // source
            VideoCapture1.IP_Camera_Source = new IPCameraSourceSettings
            {
                URL = new Uri(cbIPURL.Text, UriKind.Absolute)
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
                    {
                        // audio not supported
                        VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.HTTP_MJPEG_LowLatency;
                        VideoCapture1.Audio_RecordAudio = false;
                        VideoCapture1.Audio_PlayAudio = false;
                        cbIPAudioCapture.Checked = false;
                    }
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

            VideoCapture1.IP_Camera_Source.AudioCapture = cbIPAudioCapture.Checked;
            VideoCapture1.IP_Camera_Source.Login = edIPLogin.Text;
            VideoCapture1.IP_Camera_Source.Password = edIPPassword.Text;
            VideoCapture1.IP_Camera_Source.VLC_ZeroClockJitterEnabled = cbVLCZeroClockJitter.Checked;
            VideoCapture1.IP_Camera_Source.VLC_CustomLatency = Convert.ToInt32(edVLCCacheSize.Text);
            VideoCapture1.IP_Camera_Source.ForcedFramerate = new VideoFrameRate(Convert.ToInt32(edIPForcedFramerate.Text));
            VideoCapture1.IP_Camera_Source.ForcedFramerate_InstanceID = edIPForcedFramerateID.Text[0];

            if (VideoCapture1.IP_Camera_Source.Type == IPSourceEngine.Auto_LAV)
            {
                VideoCapture1.IP_Camera_Source.LAV_GPU_Use = lavGPU;
                VideoCapture1.IP_Camera_Source.LAV_GPU_Mode = LAVGPUDecoder.DXVA2CopyBack;
            }

            if (cbIPCameraONVIF.Checked)
            {
                VideoCapture1.IP_Camera_Source.ONVIF_Source = true;

                if (cbONVIFProfile.SelectedIndex != -1)
                {
                    VideoCapture1.IP_Camera_Source.ONVIF_SourceProfile = cbONVIFProfile.Text;
                }
            }

            if (cbIPDisconnect.Checked)
            {
                VideoCapture1.IP_Camera_Source.DisconnectEventInterval = TimeSpan.FromSeconds(10);
            }
            else
            {
                VideoCapture1.IP_Camera_Source.DisconnectEventInterval = TimeSpan.Zero;
            }

            if (rbPreview.Checked)
            {
                VideoCapture1.Mode = VideoCaptureMode.IPPreview;
            }
            else if (rbCapture.Checked)
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
            ConfigureVideoEffects();

            VideoView1.StatusOverlay = new TextStatusOverlay();

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
        }

        private void llVideoTutorials_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
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

        private async void btONVIFConnect_Click(object sender, EventArgs e)
        {
            if (btONVIFConnect.Text == "Connect")
            {
                try
                {
                    btONVIFConnect.Enabled = false;
                    btONVIFConnect.Text = "Connecting";

                    if (onvifDeviceX != null)
                    {
                        await onvifDeviceX.DisconnectAsync();
                        onvifDeviceX.Dispose();
                        onvifDeviceX = null;
                    }

                    if (string.IsNullOrEmpty(edONVIFLogin.Text) || string.IsNullOrEmpty(edONVIFPassword.Text))
                    {
                        MessageBox.Show(this, "Please specify IP camera user name and password.");
                        return;
                    }

                    onvifDeviceX = new ONVIFDeviceX();
                    var result = await onvifDeviceX.ConnectAsync(edONVIFURL.Text, edONVIFLogin.Text, edONVIFPassword.Text);
                    if (!result)
                    {
                        onvifDeviceX = null;
                        MessageBox.Show(this, "Unable to connect to ONVIF camera.");
                        return;
                    }

                    lbONVIFCameraInfo.Text = $"Model {onvifDeviceX.CameraName}, Serial number {onvifDeviceX.SerialNumber}";

                    cbONVIFProfile.Items.Clear();
                    var profiles = await onvifDeviceX.GetProfilesAsync();
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

                    btONVIFConnect.Text = "Disconnect";
                }
                finally
                {
                    btONVIFConnect.Enabled = true;
                    btONVIFConnect.Text = "Connect";
                }
            }
            else
            {
                btONVIFConnect.Text = "Connect";

                if (onvifDeviceX != null)
                {
                    await onvifDeviceX.DisconnectAsync();
                    onvifDeviceX.Dispose();
                    onvifDeviceX = null;
                }
            }
        }

        private void cbONVIFProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onvifDeviceX == null || !onvifDeviceX.IsConnected())
            {
                return;
            }

            var profiles = onvifDeviceX.GetProfiles();
            edONVIFLiveVideoURL.Text = cbIPURL.Text = profiles[cbONVIFProfile.SelectedIndex].RTSPUrl.ToString();
        }

        private void btONVIFRight_Click(object sender, EventArgs e)
        {
            if (onvifDeviceX == null || !onvifDeviceX.IsConnected())
            {
                return;
            }

            onvifDeviceX.PTZ_Move(0.5f, 0, 0);
        }

        private void btONVIFPTZSetDefault_Click(object sender, EventArgs e)
        {
            onvifDeviceX?.PTZ_GoHome();
        }

        private void btONVIFLeft_Click(object sender, EventArgs e)
        {
            if (onvifDeviceX == null || !onvifDeviceX.IsConnected())
            {
                return;
            }

            onvifDeviceX.PTZ_Move(-0.5f, 0, 0);
        }

        private void btONVIFUp_Click(object sender, EventArgs e)
        {
            onvifDeviceX.PTZ_Move(0, 0.5f, 0);
        }

        private void btONVIFDown_Click(object sender, EventArgs e)
        {
            if (onvifDeviceX == null || !onvifDeviceX.IsConnected())
            {
                return;
            }

            onvifDeviceX.PTZ_Move(0, -0.5f, 0);
        }

        private void btONVIFZoomIn_Click(object sender, EventArgs e)
        {
            if (onvifDeviceX == null || !onvifDeviceX.IsConnected())
            {
                return;
            }

            onvifDeviceX.PTZ_Move(0, 0, 0.5f);
        }

        private void btONVIFZoomOut_Click(object sender, EventArgs e)
        {
            if (onvifDeviceX == null || !onvifDeviceX.IsConnected())
            {
                return;
            }

            onvifDeviceX.PTZ_Move(0, 0, -0.5f);
        }

        private async void btSaveScreenshot_Click(object sender, EventArgs e)
        {
            if (screenshotSaveDialog.ShowDialog(this) == DialogResult.OK)
            {
                var filename = screenshotSaveDialog.FileName;
                var ext = Path.GetExtension(filename)?.ToLowerInvariant();
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

        private void SetMP4Output(ref MP4Output mp4Output)
        {
            if (this.mp4SettingsDialog == null)
            {
                this.mp4SettingsDialog = new MP4SettingsDialog();
            }

            this.mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetWMVOutput(ref WMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        private void SetMP4HWOutput(ref MP4HWOutput mp4Output)
        {
            if (mp4HWSettingsDialog == null)
            {
                mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
            }

            mp4HWSettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetMPEGTSOutput(ref MPEGTSOutput mpegTSOutput)
        {
            if (mpegTSSettingsDialog == null)
            {
                mpegTSSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
            }

            mpegTSSettingsDialog.SaveSettings(ref mpegTSOutput);
        }

        private void SetMOVOutput(ref MOVOutput mkvOutput)
        {
            if (movSettingsDialog == null)
            {
                movSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV);
            }

            movSettingsDialog.SaveSettings(ref mkvOutput);
        }

        private void SetGIFOutput(ref AnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

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


        private void cbOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
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

        private async void btResume_Click(object sender, EventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        private void btOutputConfigure_Click(object sender, EventArgs e)
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

        private void UpdateRecordingTime()
        {
            if (IsHandleCreated)
            {
                var ts = VideoCapture1.Duration_Time();

                if (Math.Abs(ts.TotalMilliseconds) < 0.01)
                {
                    return;
                }

                BeginInvoke(
                    (Action)(() =>
                                    {
                                        lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
                                    }));
            }
        }

        private void btTextLogoAdd_Click(object sender, EventArgs e)
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

        private void btImageLogoAdd_Click(object sender, EventArgs e)
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

        private void btLogoRemove_Click(object sender, EventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                VideoCapture1.Video_Effects_Remove((string)lbLogos.SelectedItem);
                lbLogos.Items.Remove(lbLogos.SelectedItem);
            }
        }

        private void btLogoEdit_Click(object sender, EventArgs e)
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

        private void tbLightness_Scroll(object sender, EventArgs e)
        {
            IVideoEffectLightness lightness;
            var effect = VideoCapture1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VideoEffectLightness(true, tbLightness.Value);
                VideoCapture1.Video_Effects_Add(lightness);
            }
            else
            {
                lightness = effect as IVideoEffectLightness;
                if (lightness != null)
                {
                    lightness.Value = tbLightness.Value;
                }
            }
        }

        private void tbSaturation_Scroll(object sender, EventArgs e)
        {
            IVideoEffectSaturation saturation;
            var effect = VideoCapture1.Video_Effects_Get("Saturation");
            if (effect == null)
            {
                saturation = new VideoEffectSaturation(tbSaturation.Value);
                VideoCapture1.Video_Effects_Add(saturation);
            }
            else
            {
                saturation = effect as IVideoEffectSaturation;
                if (saturation != null)
                {
                    saturation.Value = tbSaturation.Value;
                }
            }
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {
            IVideoEffectContrast contrast;
            var effect = VideoCapture1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VideoEffectContrast(true, tbContrast.Value);
                VideoCapture1.Video_Effects_Add(contrast);
            }
            else
            {
                contrast = effect as IVideoEffectContrast;
                if (contrast != null)
                {
                    contrast.Value = tbContrast.Value;
                }
            }
        }

        private void cbFlipX_CheckedChanged(object sender, EventArgs e)
        {
            IVideoEffectFlipDown flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VideoEffectFlipHorizontal(cbFlipX.Checked);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVideoEffectFlipDown;
                if (flip != null)
                {
                    flip.Enabled = cbFlipX.Checked;
                }
            }
        }

        private void cbFlipY_CheckedChanged(object sender, EventArgs e)
        {
            IVideoEffectFlipRight flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VideoEffectFlipVertical(cbFlipY.Checked);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVideoEffectFlipRight;
                if (flip != null)
                {
                    flip.Enabled = cbFlipY.Checked;
                }
            }
        }

        private void cbGreyscale_CheckedChanged(object sender, EventArgs e)
        {
            IVideoEffectGrayscale grayscale;
            var effect = VideoCapture1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VideoEffectGrayscale(cbGreyscale.Checked);
                VideoCapture1.Video_Effects_Add(grayscale);
            }
            else
            {
                grayscale = effect as IVideoEffectGrayscale;
                if (grayscale != null)
                {
                    grayscale.Enabled = cbGreyscale.Checked;
                }
            }
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

            if (cbGreyscale.Checked)
            {
                cbGreyscale_CheckedChanged(null, null);
            }

            if (cbInvert.Checked)
            {
                cbInvert_CheckedChanged(null, null);
            }

            if (cbFlipX.Checked)
            {
                cbFlipX_CheckedChanged(null, null);
            }

            if (cbFlipY.Checked)
            {
                cbFlipY_CheckedChanged(null, null);
            }
        }

        private void cbInvert_CheckedChanged(object sender, EventArgs e)
        {
            IVideoEffectInvert invert;
            var effect = VideoCapture1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VideoEffectInvert(cbInvert.Checked);
                VideoCapture1.Video_Effects_Add(invert);
            }
            else
            {
                invert = effect as IVideoEffectInvert;
                if (invert != null)
                {
                    invert.Enabled = cbInvert.Checked;
                }
            }
        }

        private void tbDarkness_Scroll(object sender, EventArgs e)
        {
            IVideoEffectDarkness darkness;
            var effect = VideoCapture1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VideoEffectDarkness(true, tbDarkness.Value);
                VideoCapture1.Video_Effects_Add(darkness);
            }
            else
            {
                darkness = effect as IVideoEffectDarkness;
                if (darkness != null)
                {
                    darkness.Value = tbDarkness.Value;
                }
            }
        }

        private void lbNDI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor);
            Process.Start(startInfo);
        }

        private async void btListNDISources_Click(object sender, EventArgs e)
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

        private async void btListONVIFSources_Click(object sender, EventArgs e)
        {
            cbIPURL.Items.Clear();
            Action<DiscoveryDevice> onDeviceDiscovered = AddONVIFSource;
            await VideoCapture1.IP_Camera_ONVIF_ListSourcesAsyncEx(onDeviceDiscovered, null, null);
        }

        private void AddONVIFSource(DiscoveryDevice discoveryDevice)
        {
            Invoke((Action)(() => 
            { 
                cbIPURL.Items.Add(discoveryDevice.XAdresses.FirstOrDefault());

                if (cbIPURL.Items.Count == 1)
                {
                    cbIPURL.SelectedIndex = 0;
                }
            }));
        }

        private void VideoCapture1_OnNetworkSourceDisconnect(object sender, EventArgs e)
        {
            Invoke((Action)(
                               async () =>
                                   {
                                       await VideoCapture1.StopAsync();

                                       MessageBox.Show(this, "Network source stopped or disconnected!");
                                   }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}

// ReSharper restore InconsistentNaming