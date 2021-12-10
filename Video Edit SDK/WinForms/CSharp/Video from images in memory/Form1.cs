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
    using VisioForge.Core;
    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
    using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;
    using VisioForge.Core.VideoEdit;
    using VisioForge.Types;
    using VisioForge.Types.Events;
    using VisioForge.Types.Output;
    using VisioForge.Types.VideoEdit;
    using VisioForge.Types.VideoEffects;

    public partial class Form1 : Form
    {
        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;

        private MP4SettingsDialog mp4SettingsDialog;

        private AVISettingsDialog aviSettingsDialog;

        private MP3SettingsDialog mp3SettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private DVSettingsDialog dvSettingsDialog;

        private WebMSettingsDialog webmSettingsDialog;

        private FFMPEGSettingsDialog ffmpegSettingsDialog;

        private FFMPEGEXESettingsDialog ffmpegEXESettingsDialog;

        private GIFSettingsDialog gifSettingsDialog;

        private bool predefinedImagesUsed;

        private Bitmap loadedImage;

        private string loadedImageFilename;

        private string[] loadedFiles;

        private VideoEditCore VideoEdit1;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateEngine()
        {
            VideoEdit1 = new VideoEditCore(VideoView1 as IVideoView);

            VideoEdit1.OnError += VideoEdit1_OnError;
            VideoEdit1.OnLicenseRequired += VideoEdit1_OnLicenseRequired;
            VideoEdit1.OnStop += VideoEdit1_OnStop;
            VideoEdit1.OnProgress += VideoEdit1_OnProgress;
        }

        private void DestroyEngine()
        {
            VideoEdit1.OnError -= VideoEdit1_OnError;
            VideoEdit1.OnLicenseRequired -= VideoEdit1_OnLicenseRequired;
            VideoEdit1.OnStop -= VideoEdit1_OnStop;
            VideoEdit1.OnProgress -= VideoEdit1_OnProgress;

            VideoEdit1.Dispose();
            VideoEdit1 = null;
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
            CreateEngine();

            Text += $" (SDK v{VideoEdit1.SDK_Version})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            cbFrameRate.SelectedIndex = 7;
            cbOutputFormat.SelectedIndex = 7;
        }

        private void SetMP4Output(ref MP4Output mp4Output)
        {
            if (this.mp4SettingsDialog == null)
            {
                this.mp4SettingsDialog = new MP4SettingsDialog();
            }

            this.mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetFFMPEGEXEOutput(ref FFMPEGEXEOutput ffmpegOutput)
        {
            if (ffmpegEXESettingsDialog == null)
            {
                ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
            }

            ffmpegEXESettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        private void SetWMVOutput(ref WMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        private void SetWebMOutput(ref WebMOutput webmOutput)
        {
            if (webmSettingsDialog == null)
            {
                webmSettingsDialog = new WebMSettingsDialog();
            }

            webmSettingsDialog.SaveSettings(ref webmOutput);
        }

        private void SetFFMPEGOutput(ref FFMPEGOutput ffmpegOutput)
        {
            if (ffmpegSettingsDialog == null)
            {
                ffmpegSettingsDialog = new FFMPEGSettingsDialog();
            }

            ffmpegSettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        private void SetMP4HWOutput(ref MP4HWOutput mp4Output)
        {
            if (mp4HWSettingsDialog == null)
            {
                mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
            }

            mp4HWSettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetGIFOutput(ref AnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        private void SetDVOutput(ref DVOutput dvOutput)
        {
            if (dvSettingsDialog == null)
            {
                dvSettingsDialog = new DVSettingsDialog();
            }

            dvSettingsDialog.SaveSettings(ref dvOutput);
        }

        private void SetAVIOutput(ref AVIOutput aviOutput)
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
                var mp3Output = new MP3Output();
                SetMP3Output(ref mp3Output);
                aviOutput.MP3 = mp3Output;
            }
        }

        private void SetMP3Output(ref MP3Output mp3Output)
        {
            if (mp3SettingsDialog == null)
            {
                mp3SettingsDialog = new MP3SettingsDialog();
            }

            mp3SettingsDialog.SaveSettings(ref mp3Output);
        }

        private void SetMKVOutput(ref MKVv1Output mkvOutput)
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
                var mp3Output = new MP3Output();
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
            if (FilterHelpers.Filter_Supported_EVR())
            {
                VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.EVR;
            }
            else if (FilterHelpers.Filter_Supported_VMR9())
            {
                VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.VMR9;
            }
            else
            {
                VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.VideoRenderer;
            }
            
            if (!rbConvert.Checked)
            {
                VideoEdit1.Mode = VideoEditMode.Preview;
               
            }
            else
            {
                VideoEdit1.Mode = VideoEditMode.Convert;
                VideoEdit1.Output_Filename = edOutput.Text;

                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            var aviOutput = new AVIOutput();
                            SetAVIOutput(ref aviOutput);
                            VideoEdit1.Output_Format = aviOutput;

                            break;
                        }
                    case 1:
                        {
                            var mkvOutput = new MKVv1Output();
                            SetMKVOutput(ref mkvOutput);
                            VideoEdit1.Output_Format = mkvOutput;

                            break;
                        }
                    case 2:
                        {
                            var wmvOutput = new WMVOutput();
                            SetWMVOutput(ref wmvOutput);
                            VideoEdit1.Output_Format = wmvOutput;

                            break;
                        }
                    case 3:
                        {
                            var dvOutput = new DVOutput();
                            SetDVOutput(ref dvOutput);
                            VideoEdit1.Output_Format = dvOutput;

                            break;
                        }
                    case 4:
                        {
                            var webmOutput = new WebMOutput();
                            SetWebMOutput(ref webmOutput);
                            VideoEdit1.Output_Format = webmOutput;

                            break;
                        }
                    case 5:
                        {
                            var ffmpegOutput = new FFMPEGOutput();
                            SetFFMPEGOutput(ref ffmpegOutput);
                            VideoEdit1.Output_Format = ffmpegOutput;

                            break;
                        }
                    case 6:
                        {
                            var ffmpegOutput = new FFMPEGEXEOutput();
                            SetFFMPEGEXEOutput(ref ffmpegOutput);
                            VideoEdit1.Output_Format = ffmpegOutput;

                            break;
                        }
                    case 7:
                        {
                            var mp4Output = new MP4Output();
                            SetMP4Output(ref mp4Output);
                            VideoEdit1.Output_Format = mp4Output;

                            break;
                        }
                    case 8:
                        {
                            var mp4Output = new MP4HWOutput();
                            SetMP4HWOutput(ref mp4Output);
                            VideoEdit1.Output_Format = mp4Output;

                            break;
                        }
                    case 9:
                        {
                            var gifOutput = new AnimatedGIFOutput();
                            SetGIFOutput(ref gifOutput);

                            VideoEdit1.Output_Format = gifOutput;

                            break;
                        }
                    case 10:
                        {
                            var encOutput = new MP4Output();
                            SetMP4Output(ref encOutput);
                            encOutput.Encryption = true;
                            encOutput.Encryption_Format = EncryptionFormat.MP4_H264_SW_AAC;

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
                if (e.Timestamp.TotalMilliseconds < 2000)
                {
                    frame = Resources._1;
                }
                else if (e.Timestamp.TotalMilliseconds < 4000)
                {
                    frame = Resources._2;
                }
                else if (e.Timestamp.TotalMilliseconds < 6000)
                {
                    frame = Resources._3;
                }
                else if (e.Timestamp.TotalMilliseconds < 8000)
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
                int index = (int)Math.Truncate(e.Timestamp.TotalMilliseconds / 2000);
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

        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
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
                    if (ffmpegSettingsDialog == null)
                    {
                        ffmpegSettingsDialog = new FFMPEGSettingsDialog();
                    }

                    ffmpegSettingsDialog.ShowDialog(this);

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
                case 10:
                {
                    if (this.mp4SettingsDialog == null)
                    {
                        this.mp4SettingsDialog = new MP4SettingsDialog();
                    }

                    this.mp4SettingsDialog.ShowDialog(this);

                    break;
                }
                case 8:
                {
                    if (mp4HWSettingsDialog == null)
                    {
                            mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
                    }

                    mp4HWSettingsDialog.ShowDialog(this);

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
            }
        }

        private void btTextLogoAdd_Click(object sender, EventArgs e)
        {
            var dlg = new TextLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoEdit1);
            var effect = new VideoEffectTextLogo(true, name);

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
            var effect = new VideoEffectImageLogo(true, name);

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
            var effect = VideoEdit1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VideoEffectLightness(true, tbLightness.Value);
                VideoEdit1.Video_Effects_Add(lightness);
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
            var effect = VideoEdit1.Video_Effects_Get("Saturation");
            if (effect == null)
            {
                saturation = new VideoEffectSaturation(tbSaturation.Value);
                VideoEdit1.Video_Effects_Add(saturation);
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
            var effect = VideoEdit1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VideoEffectContrast(true, tbContrast.Value);
                VideoEdit1.Video_Effects_Add(contrast);
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
            var effect = VideoEdit1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VideoEffectFlipHorizontal(cbFlipX.Checked);
                VideoEdit1.Video_Effects_Add(flip);
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
            var effect = VideoEdit1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VideoEffectFlipVertical(cbFlipY.Checked);
                VideoEdit1.Video_Effects_Add(flip);
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
            var effect = VideoEdit1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VideoEffectGrayscale(cbGreyscale.Checked);
                VideoEdit1.Video_Effects_Add(grayscale);
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
            var effect = VideoEdit1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VideoEffectInvert(cbInvert.Checked);
                VideoEdit1.Video_Effects_Add(invert);
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
            var effect = VideoEdit1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VideoEffectDarkness(true, tbDarkness.Value);
                VideoEdit1.Video_Effects_Add(darkness);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}

// ReSharper restore InconsistentNaming