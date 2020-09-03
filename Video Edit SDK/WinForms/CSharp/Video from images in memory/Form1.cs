// ReSharper disable InconsistentNaming

namespace Video_From_Images
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    using Properties;

    using VisioForge.Controls.UI;
    using VisioForge.Controls.UI.Dialogs.OutputFormats;
    using VisioForge.Controls.UI.Dialogs.VideoEffects;
    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Tools;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.VideoEffects;

    public partial class Form1 : Form
    {
        private MFSettingsDialog mp4v11SettingsDialog;

        private MP4v10SettingsDialog mp4V10SettingsDialog;

        private AVISettingsDialog aviSettingsDialog;

        private MP3SettingsDialog mp3SettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private DVSettingsDialog dvSettingsDialog;

        private WebMSettingsDialog webmSettingsDialog;

        private FFMPEGDLLSettingsDialog ffmpegDLLSettingsDialog;

        private FFMPEGEXESettingsDialog ffmpegEXESettingsDialog;

        private GIFSettingsDialog gifSettingsDialog;

        private bool predefinedImagesUsed;

        private Bitmap loadedImage;

        private string loadedImageFilename;

        private string[] loadedFiles;

        public Form1()
        {
            InitializeComponent();
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + VideoEdit1.SDK_Version + ", " + VideoEdit1.SDK_State + ")";

            edOutput.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" +
                            "output.mp4";
            VideoEdit1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";

            cbFrameRate.SelectedIndex = 7;
            cbOutputFormat.SelectedIndex = 7;
        }

        private void SetMP4v10Output(ref VFMP4v8v10Output mp4Output)
        {
            if (mp4V10SettingsDialog == null)
            {
                mp4V10SettingsDialog = new MP4v10SettingsDialog();
            }

            mp4V10SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetFFMPEGEXEOutput(ref VFFFMPEGEXEOutput ffmpegOutput)
        {
            if (ffmpegEXESettingsDialog == null)
            {
                ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
            }

            ffmpegEXESettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        private void SetWMVOutput(ref VFWMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        private void SetWebMOutput(ref VFWebMOutput webmOutput)
        {
            if (webmSettingsDialog == null)
            {
                webmSettingsDialog = new WebMSettingsDialog();
            }

            webmSettingsDialog.SaveSettings(ref webmOutput);
        }

        private void SetFFMPEGDLLOutput(ref VFFFMPEGDLLOutput ffmpegDLLOutput)
        {
            if (ffmpegDLLSettingsDialog == null)
            {
                ffmpegDLLSettingsDialog = new FFMPEGDLLSettingsDialog();
            }

            ffmpegDLLSettingsDialog.SaveSettings(ref ffmpegDLLOutput);
        }

        private void SetMP4v11Output(ref VFMP4v11Output mp4Output)
        {
            if (mp4v11SettingsDialog == null)
            {
                mp4v11SettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MP4v11);
            }

            mp4v11SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetGIFOutput(ref VFAnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        private void SetDVOutput(ref VFDVOutput dvOutput)
        {
            if (dvSettingsDialog == null)
            {
                dvSettingsDialog = new DVSettingsDialog();
            }

            dvSettingsDialog.SaveSettings(ref dvOutput);
        }

        private void SetAVIOutput(ref VFAVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(
                    VideoEdit1.Video_Codecs.ToArray(),
                    VideoEdit1.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new VFMP3Output();
                SetMP3Output(ref mp3Output);
                aviOutput.MP3 = mp3Output;
            }
        }

        private void SetMP3Output(ref VFMP3Output mp3Output)
        {
            if (mp3SettingsDialog == null)
            {
                mp3SettingsDialog = new MP3SettingsDialog();
            }

            mp3SettingsDialog.SaveSettings(ref mp3Output);
        }

        private void SetMKVOutput(ref VFMKVv1Output mkvOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(
                    VideoEdit1.Video_Codecs.ToArray(),
                    VideoEdit1.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref mkvOutput);

            if (mkvOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new VFMP3Output();
                SetMP3Output(ref mp3Output);
                mkvOutput.MP3 = mp3Output;
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();

            VideoEdit1.Debug_Mode = cbDebugMode.Checked;

            VideoEdit1.Video_Resize = cbResize.Checked;

            if (VideoEdit1.Video_Resize)
            {
                VideoEdit1.Video_Resize_Width = Convert.ToInt32(edWidth.Text);
                VideoEdit1.Video_Resize_Height = Convert.ToInt32(edHeight.Text);
            }

            VideoEdit1.Video_FrameRate = Convert.ToDouble(cbFrameRate.Text);

            // apply capture parameters
            if (VideoEdit.Filter_Supported_EVR())
            {
                VideoEdit1.Video_Renderer.Video_Renderer = VFVideoRenderer.EVR;
            }
            else if (VideoEdit.Filter_Supported_VMR9())
            {
                VideoEdit1.Video_Renderer.Video_Renderer = VFVideoRenderer.VMR9;
            }
            else
            {
                VideoEdit1.Video_Renderer.Video_Renderer = VFVideoRenderer.VideoRenderer;
            }
            
            if (!rbConvert.Checked)
            {
                VideoEdit1.Mode = VFVideoEditMode.Preview;
               
            }
            else
            {
                VideoEdit1.Mode = VFVideoEditMode.Convert;
                VideoEdit1.Output_Filename = edOutput.Text;

                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            var aviOutput = new VFAVIOutput();
                            SetAVIOutput(ref aviOutput);
                            VideoEdit1.Output_Format = aviOutput;

                            break;
                        }
                    case 1:
                        {
                            var mkvOutput = new VFMKVv1Output();
                            SetMKVOutput(ref mkvOutput);
                            VideoEdit1.Output_Format = mkvOutput;

                            break;
                        }
                    case 2:
                        {
                            var wmvOutput = new VFWMVOutput();
                            SetWMVOutput(ref wmvOutput);
                            VideoEdit1.Output_Format = wmvOutput;

                            break;
                        }
                    case 3:
                        {
                            var dvOutput = new VFDVOutput();
                            SetDVOutput(ref dvOutput);
                            VideoEdit1.Output_Format = dvOutput;

                            break;
                        }
                    case 4:
                        {
                            var webmOutput = new VFWebMOutput();
                            SetWebMOutput(ref webmOutput);
                            VideoEdit1.Output_Format = webmOutput;

                            break;
                        }
                    case 5:
                        {
                            var ffmpegDLLOutput = new VFFFMPEGDLLOutput();
                            SetFFMPEGDLLOutput(ref ffmpegDLLOutput);
                            VideoEdit1.Output_Format = ffmpegDLLOutput;

                            break;
                        }
                    case 6:
                        {
                            var ffmpegOutput = new VFFFMPEGEXEOutput();
                            SetFFMPEGEXEOutput(ref ffmpegOutput);
                            VideoEdit1.Output_Format = ffmpegOutput;

                            break;
                        }
                    case 7:
                        {
                            var mp4Output = new VFMP4v8v10Output();
                            SetMP4v10Output(ref mp4Output);
                            VideoEdit1.Output_Format = mp4Output;

                            break;
                        }
                    case 8:
                        {
                            var mp4Output = new VFMP4v11Output();
                            SetMP4v11Output(ref mp4Output);
                            VideoEdit1.Output_Format = mp4Output;

                            break;
                        }
                    case 9:
                        {
                            var gifOutput = new VFAnimatedGIFOutput();
                            SetGIFOutput(ref gifOutput);

                            VideoEdit1.Output_Format = gifOutput;

                            break;
                        }
                    case 10:
                        {
                            var encOutput = new VFMP4v8v10Output();
                            SetMP4v10Output(ref encOutput);
                            encOutput.Encryption = true;
                            encOutput.Encryption_Format = VFEncryptionFormat.MP4_H264_SW_AAC;

                            VideoEdit1.Output_Format = encOutput;

                            break;
                        }
                }
            }

            VideoEdit1.Video_Effects_Enabled = true;
            VideoEdit1.Video_Effects_Clear();
            lbLogos.Items.Clear();
            ConfigureVideoEffects();

            VideoEdit1.Input_Clear_List();

            if (rbImagesPredefined.Checked)
            {
                predefinedImagesUsed = true;

                await VideoEdit1.Input_AddVideoBlankAsync(
                    TimeSpan.FromMilliseconds(10000),
                    TimeSpan.FromMilliseconds(0),
                    1280,
                    720,
                    Color.Black);
            }
            else
            {
                predefinedImagesUsed = false;

                if (!Directory.Exists(edImagesFolder.Text))
                {
                    MessageBox.Show(this, "Folder with images doesn't exists!");
                    return;
                }

                loadedFiles = EnumerateImageFiles(edImagesFolder.Text);

                int width = Convert.ToInt32(edWidth.Text);
                int height = Convert.ToInt32(edHeight.Text);

                loadedImageFilename = null;
                if (loadedImage != null)
                {
                    loadedImage.Dispose();
                    loadedImage = null;
                }

                await VideoEdit1.Input_AddVideoBlankAsync(
                    TimeSpan.FromSeconds(loadedFiles.Length * 2),
                    TimeSpan.FromMilliseconds(0),
                    width,
                    height,
                    Color.Black);
            }

            await VideoEdit1.StartAsync();
        }

        private static string[] EnumerateImageFiles(string path)
        {
            var res = new List<string>(); 

            var exts = new string[] { "*.jpg", "*.jpeg", "*.png", "*.gif", "*.bmp" };
            foreach (var ext in exts)
            {
                var files = Directory.GetFiles(path, ext);
                res.AddRange(files);
            }

            return res.ToArray();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await VideoEdit1.StopAsync();
            ProgressBar1.Value = 0;
        }

        private void VideoEdit1_OnVideoFrameBitmap(object sender, VideoFrameBitmapEventArgs e)
        {
            Bitmap frame;

            if (predefinedImagesUsed)
            {
                if (e.StartTime.TotalMilliseconds < 2000)
                {
                    frame = Resources._1;
                }
                else if (e.StartTime.TotalMilliseconds < 4000)
                {
                    frame = Resources._2;
                }
                else if (e.StartTime.TotalMilliseconds < 6000)
                {
                    frame = Resources._3;
                }
                else if (e.StartTime.TotalMilliseconds < 8000)
                {
                    frame = Resources._4;
                }
                else
                {
                    frame = Resources._5;
                }
            }
            else
            {
                int index = (int)Math.Truncate(e.StartTime.TotalMilliseconds / 2000);
                if (loadedImageFilename == loadedFiles[index])
                {
                    frame = loadedImage;
                }
                else
                {
                    loadedImageFilename = loadedFiles[index];
                    loadedImage?.Dispose();
                    loadedImage = new Bitmap(loadedFiles[index]);

                    frame = loadedImage;
                }
            }

            using (Graphics g = Graphics.FromImage(e.Frame))
            {
                g.DrawImage(frame, new RectangleF(0, 0, e.Frame.Width, e.Frame.Height), new RectangleF(0, 0, frame.Width, frame.Height), GraphicsUnit.Pixel);
                e.UpdateData = true;
            }
        }

        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Invoke((Action)(() => { ProgressBar1.Value = e.Progress; }));
        }

        private void VideoEdit1_OnStop(object sender, VideoEditStopEventArgs e)
        {
            Invoke((Action)(() => { ProgressBar1.Value = 0; }));

            if (e.Successful)
            {
                MessageBox.Show(this, "Completed successfully", string.Empty, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(this, "Stopped with error", string.Empty, MessageBoxButtons.OK);
            }
        }

        private void VideoEdit1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       if (cbLicensing.Checked)
                                       {
                                           mmLog.Text += "(NOT ERROR) LICENSING:" + Environment.NewLine + e.Message
                                                         + Environment.NewLine;
                                       }
                                   }));
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
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mkv");
                    break;
                }
                case 2:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv");
                    break;
                }
                case 3:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                    break;
                }
                case 4:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm");
                    break;
                }
                case 5:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                    break;
                }
                case 6:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                    break;
                }
                case 7:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                    break;
                }
                case 8:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                    break;
                }
                case 9:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif");
                    break;
                }
                case 10:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".enc");
                    break;
                }
            }
        }

        private void btConfigure_Click(object sender, EventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                {
                    if (aviSettingsDialog == null)
                    {
                        aviSettingsDialog = new AVISettingsDialog(
                            VideoEdit1.Video_Codecs.ToArray(),
                            VideoEdit1.Audio_Codecs.ToArray());
                    }

                    aviSettingsDialog.ShowDialog(this);

                    break;
                }
                case 1:
                {
                    if (aviSettingsDialog == null)
                    {
                        aviSettingsDialog = new AVISettingsDialog(
                            VideoEdit1.Video_Codecs.ToArray(),
                            VideoEdit1.Audio_Codecs.ToArray());
                    }

                    aviSettingsDialog.ShowDialog(this);

                    break;
                }
                case 2:
                {
                    if (wmvSettingsDialog == null)
                    {
                        wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
                    }

                    wmvSettingsDialog.WMA = false;
                    wmvSettingsDialog.ShowDialog(this);

                    break;
                }
                case 3:
                {
                    if (dvSettingsDialog == null)
                    {
                        dvSettingsDialog = new DVSettingsDialog();
                    }

                    dvSettingsDialog.ShowDialog(this);

                    break;
                }
                case 4:
                {
                    if (webmSettingsDialog == null)
                    {
                        webmSettingsDialog = new WebMSettingsDialog();
                    }

                    webmSettingsDialog.ShowDialog(this);

                    break;
                }
                case 5:
                {
                    if (ffmpegDLLSettingsDialog == null)
                    {
                        ffmpegDLLSettingsDialog = new FFMPEGDLLSettingsDialog();
                    }

                    ffmpegDLLSettingsDialog.ShowDialog(this);

                    break;
                }
                case 6:
                {
                    if (ffmpegEXESettingsDialog == null)
                    {
                        ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
                    }

                    ffmpegEXESettingsDialog.ShowDialog(this);

                    break;
                }
                case 7:
                {
                    if (mp4V10SettingsDialog == null)
                    {
                        mp4V10SettingsDialog = new MP4v10SettingsDialog();
                    }

                    mp4V10SettingsDialog.ShowDialog(this);

                    break;
                }
                case 8:
                {
                    if (mp4v11SettingsDialog == null)
                    {
                            mp4v11SettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MP4v11);
                    }

                    mp4v11SettingsDialog.ShowDialog(this);

                    break;
                }
                case 9:
                {
                    if (gifSettingsDialog == null)
                    {
                        gifSettingsDialog = new GIFSettingsDialog();
                    }

                    gifSettingsDialog.ShowDialog(this);

                    break;
                }
                case 10:
                {
                    if (mp4V10SettingsDialog == null)
                    {
                        mp4V10SettingsDialog = new MP4v10SettingsDialog();
                    }

                    mp4V10SettingsDialog.ShowDialog(this);

                    break;
                }
            }
        }

        private void btTextLogoAdd_Click(object sender, EventArgs e)
        {
            var dlg = new TextLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoEdit1);
            var effect = new VFVideoEffectTextLogo(true, name);

            VideoEdit1.Video_Effects_Add(effect);
            lbLogos.Items.Add(effect.Name);
            dlg.Fill(effect);

            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private void btImageLogoAdd_Click(object sender, EventArgs e)
        {
            var dlg = new ImageLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoEdit1);
            var effect = new VFVideoEffectImageLogo(true, name);

            VideoEdit1.Video_Effects_Add(effect);
            lbLogos.Items.Add(effect.Name);

            dlg.Fill(effect);
            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private void btLogoRemove_Click(object sender, EventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                VideoEdit1.Video_Effects_Remove((string)lbLogos.SelectedItem);
                lbLogos.Items.Remove(lbLogos.SelectedItem);
            }
        }

        private void btLogoEdit_Click(object sender, EventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                var effect = VideoEdit1.Video_Effects_Get((string)lbLogos.SelectedItem);
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

        private void tbLightness_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectLightness lightness;
            var effect = VideoEdit1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VFVideoEffectLightness(true, tbLightness.Value);
                VideoEdit1.Video_Effects_Add(lightness);
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
            var effect = VideoEdit1.Video_Effects_Get("Saturation");
            if (effect == null)
            {
                saturation = new VFVideoEffectSaturation(tbSaturation.Value);
                VideoEdit1.Video_Effects_Add(saturation);
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
            var effect = VideoEdit1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VFVideoEffectContrast(true, tbContrast.Value);
                VideoEdit1.Video_Effects_Add(contrast);
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

        private void cbFlipX_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectFlipDown flip;
            var effect = VideoEdit1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipHorizontal(cbFlipX.Checked);
                VideoEdit1.Video_Effects_Add(flip);
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
            var effect = VideoEdit1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipVertical(cbFlipY.Checked);
                VideoEdit1.Video_Effects_Add(flip);
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

        private void cbGreyscale_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectGrayscale grayscale;
            var effect = VideoEdit1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VFVideoEffectGrayscale(cbGreyscale.Checked);
                VideoEdit1.Video_Effects_Add(grayscale);
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
            IVFVideoEffectInvert invert;
            var effect = VideoEdit1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VFVideoEffectInvert(cbInvert.Checked);
                VideoEdit1.Video_Effects_Add(invert);
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

        private void tbDarkness_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectDarkness darkness;
            var effect = VideoEdit1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VFVideoEffectDarkness(true, tbDarkness.Value);
                VideoEdit1.Video_Effects_Add(darkness);
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

        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text += e.Message + Environment.NewLine;
                                   }));
        }

        private void btSelectImagesFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                edImagesFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}

// ReSharper restore InconsistentNaming