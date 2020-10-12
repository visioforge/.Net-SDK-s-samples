using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VisioForge.Controls.UI;
using VisioForge.Controls.UI.Dialogs.OutputFormats;
using VisioForge.Controls.UI.Dialogs.VideoEffects;
using VisioForge.Controls.UI.WinForms;
using VisioForge.Tools;
using VisioForge.Types;
using VisioForge.Types.OutputFormat;
using VisioForge.Types.Sources;
using VisioForge.Types.VideoEffects;

namespace Decklink_Demo
{
    public partial class Form1 : Form
    {
        private readonly System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private readonly SaveFileDialog screenshotSaveDialog = new SaveFileDialog()
        {
            FileName = "image.jpg",
            Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\"
        };

        private MFSettingsDialog mp4v11SettingsDialog;

        private MFSettingsDialog mpegTSSettingsDialog;

        private MFSettingsDialog movSettingsDialog;

        private MP4v10SettingsDialog mp4V10SettingsDialog;

        private AVISettingsDialog aviSettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private GIFSettingsDialog gifSettingsDialog;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + VideoCapture1.SDK_Version + ", " + VideoCapture1.SDK_State + "), C#";

            cbDecklinkSourceInput.SelectedIndex = 0;
            cbDecklinkSourceNTSC.SelectedIndex = 0;
            cbDecklinkSourceComponentLevels.SelectedIndex = 0;
            cbDecklinkSourceTimecode.SelectedIndex = 0;

            cbOutputFormat.SelectedIndex = 2;

            edOutput.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" + "output.mp4";

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };

            string defaultAudioRenderer = string.Empty;
            foreach (string audioOutputDevice in VideoCapture1.Audio_OutputDevices)
            {
                cbAudioOutputDevice.Items.Add(audioOutputDevice);

                if (audioOutputDevice.Contains("Default DirectSound Device"))
                {
                    defaultAudioRenderer = audioOutputDevice;
                }
            }

            if (cbAudioOutputDevice.Items.Count > 0)
            {
                if (string.IsNullOrEmpty(defaultAudioRenderer))
                {
                    cbAudioOutputDevice.SelectedIndex = 0;
                }
                else
                {
                    cbAudioOutputDevice.Text = defaultAudioRenderer;
                }
            }

            foreach (var device in VideoCapture1.Decklink_CaptureDevices)
            {
                cbDecklinkCaptureDevice.Items.Add(device.Name);
            }

            if (cbDecklinkCaptureDevice.Items.Count > 0)
            {
                cbDecklinkCaptureDevice.SelectedIndex = 0;
                cbDecklinkCaptureDevice_SelectedIndexChanged(null, null);
            }

            VideoCapture1.Video_Renderer_SetAuto();
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

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private void btOutputConfigure_Click(object sender, EventArgs e)
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

        private void btImageLogoAdd_Click(object sender, EventArgs e)
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

        private void btTextLogoAdd_Click(object sender, EventArgs e)
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

        private void btLogoEdit_Click(object sender, EventArgs e)
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

        private void btLogoRemove_Click(object sender, EventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                VideoCapture1.Video_Effects_Remove((string)lbLogos.SelectedItem);
                lbLogos.Items.Remove(lbLogos.SelectedItem);
            }
        }

        private void tbLightness_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectLightness lightness;
            var effect = VideoCapture1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VFVideoEffectLightness(true, tbLightness.Value);
                VideoCapture1.Video_Effects_Add(lightness);
            }
            else
            {
                lightness = effect as IVFVideoEffectLightness;
                if (lightness != null)
                {
                    lightness.Value = tbLightness.Value;
                }
            }
        }

        private void tbSaturation_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectSaturation saturation;
            var effect = VideoCapture1.Video_Effects_Get("Saturation");
            if (effect == null)
            {
                saturation = new VFVideoEffectSaturation(tbSaturation.Value);
                VideoCapture1.Video_Effects_Add(saturation);
            }
            else
            {
                saturation = effect as IVFVideoEffectSaturation;
                if (saturation != null)
                {
                    saturation.Value = tbSaturation.Value;
                }
            }
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectContrast contrast;
            var effect = VideoCapture1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VFVideoEffectContrast(true, tbContrast.Value);
                VideoCapture1.Video_Effects_Add(contrast);
            }
            else
            {
                contrast = effect as IVFVideoEffectContrast;
                if (contrast != null)
                {
                    contrast.Value = tbContrast.Value;
                }
            }
        }

        private void tbDarkness_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectDarkness darkness;
            var effect = VideoCapture1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VFVideoEffectDarkness(true, tbDarkness.Value);
                VideoCapture1.Video_Effects_Add(darkness);
            }
            else
            {
                darkness = effect as IVFVideoEffectDarkness;
                if (darkness != null)
                {
                    darkness.Value = tbDarkness.Value;
                }
            }
        }

        private void cbGreyscale_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectGrayscale grayscale;
            var effect = VideoCapture1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VFVideoEffectGrayscale(cbGreyscale.Checked);
                VideoCapture1.Video_Effects_Add(grayscale);
            }
            else
            {
                grayscale = effect as IVFVideoEffectGrayscale;
                if (grayscale != null)
                {
                    grayscale.Enabled = cbGreyscale.Checked;
                }
            }
        }

        private void cbInvert_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectInvert invert;
            var effect = VideoCapture1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VFVideoEffectInvert(cbInvert.Checked);
                VideoCapture1.Video_Effects_Add(invert);
            }
            else
            {
                invert = effect as IVFVideoEffectInvert;
                if (invert != null)
                {
                    invert.Enabled = cbInvert.Checked;
                }
            }
        }

        private void cbFlipX_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectFlipDown flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipHorizontal(cbFlipX.Checked);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVFVideoEffectFlipDown;
                if (flip != null)
                {
                    flip.Enabled = cbFlipX.Checked;
                }
            }
        }

        private void cbFlipY_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectFlipRight flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipVertical(cbFlipY.Checked);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVFVideoEffectFlipRight;
                if (flip != null)
                {
                    flip.Enabled = cbFlipY.Checked;
                }
            }
        }

        private void cbAudAmplifyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, 0, cbAudAmplifyEnabled.Checked);
        }

        private void tbAudAmplifyAmp_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Amplify(-1, 0, tbAudAmplifyAmp.Value * 10, false);
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";

            VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text;

            if (cbRecordAudio.Checked)
            {
                VideoCapture1.Audio_RecordAudio = true;
                VideoCapture1.Audio_PlayAudio = true;
            }
            else
            {
                VideoCapture1.Audio_RecordAudio = false;
                VideoCapture1.Audio_PlayAudio = false;
            }

            // apply capture parameters
            VideoCapture1.Decklink_Source = new DecklinkSourceSettings
            {
                Name = cbDecklinkCaptureDevice.Text,
                VideoFormat = cbDecklinkCaptureVideoFormat.Text
            };

            if (rbPreview.Checked)
            {
                VideoCapture1.Mode = VFVideoCaptureMode.DecklinkSourcePreview;
            }
            else
            {
                VideoCapture1.Mode = VFVideoCaptureMode.DecklinkSourceCapture;
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

            // Audio processing
            VideoCapture1.Audio_Effects_Clear(-1);
            VideoCapture1.Audio_Effects_Enabled = true;

            VideoCapture1.Audio_Effects_Add(-1, VFAudioEffectType.Amplify, cbAudAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 4;
            tmRecording.Start();
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
                aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(),
                    VideoCapture1.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new VFMP3Output();
                aviOutput.MP3 = mp3Output;
            }
        }

        private void ConfigureVideoEffects()
        {
            // Other effects
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

        private async void btStop_Click(object sender, EventArgs e)
        {
            tmRecording.Stop();

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

        private async void btSaveScreenshot_Click(object sender, EventArgs e)
        {
            if (screenshotSaveDialog.ShowDialog(this) == DialogResult.OK)
            {
                var filename = screenshotSaveDialog.FileName;
                var ext = Path.GetExtension(filename)?.ToLowerInvariant();
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

        private void cbDecklinkCaptureDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDecklinkCaptureVideoFormat.Items.Clear();

            var deviceItem = VideoCapture1.Decklink_CaptureDevices.First(device => device.Name == cbDecklinkCaptureDevice.Text);
            if (deviceItem != null)
            {
                foreach (var format in deviceItem.VideoFormats)
                {
                    cbDecklinkCaptureVideoFormat.Items.Add(format.Name);
                }

                if (cbDecklinkCaptureVideoFormat.Items.Count == 0)
                {
                    cbDecklinkCaptureVideoFormat.Items.Add("No input connected");
                }

                cbDecklinkCaptureVideoFormat.SelectedIndex = 0;
            }
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
            Log("(NOT ERROR) " + e.Message);
        }

        private void llVideoTutorials_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }
    }
}
