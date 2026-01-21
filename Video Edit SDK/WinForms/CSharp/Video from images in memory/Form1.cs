

namespace Video_From_Images
{
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoEdit;
    using VisioForge.Core.Types.VideoEffects;
    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
    using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;
    using VisioForge.Core.VideoEdit;

    /// <summary>
    /// Video from images in memory demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The MP4 HW settings dialog.
        /// </summary>
        private HWEncodersOutputSettingsDialog _mp4HWSettingsDialog;

        /// <summary>
        /// The MP4 settings dialog.
        /// </summary>
        private MP4SettingsDialog _mp4SettingsDialog;

        /// <summary>
        /// The AVI settings dialog.
        /// </summary>
        private AVISettingsDialog _aviSettingsDialog;

        /// <summary>
        /// The MP3 settings dialog.
        /// </summary>
        private MP3SettingsDialog _mp3SettingsDialog;

        /// <summary>
        /// The WMV settings dialog.
        /// </summary>
        private WMVSettingsDialog _wmvSettingsDialog;

        /// <summary>
        /// The DV settings dialog.
        /// </summary>
        private DVSettingsDialog _dvSettingsDialog;

        /// <summary>
        /// The WebM settings dialog.
        /// </summary>
        private WebMSettingsDialog _webmSettingsDialog;

        /// <summary>
        /// The FFMPEG settings dialog.
        /// </summary>
        private FFMPEGSettingsDialog _ffmpegSettingsDialog;

        /// <summary>
        /// The FFMPEG EXE settings dialog.
        /// </summary>
        private FFMPEGEXESettingsDialog _ffmpegEXESettingsDialog;

        /// <summary>
        /// The GIF settings dialog.
        /// </summary>
        private GIFSettingsDialog _gifSettingsDialog;

        /// <summary>
        /// Indicates whether predefined images are used.
        /// </summary>
        private bool _predefinedImagesUsed;

        /// <summary>
        /// The loaded image bitmap.
        /// </summary>
        private Bitmap _loadedImage;

        /// <summary>
        /// The loaded image filename.
        /// </summary>
        private string _loadedImageFilename;

        /// <summary>
        /// The list of loaded image files.
        /// </summary>
        private string[] _loadedFiles;

        /// <summary>
        /// The video editing engine instance.
        /// </summary>
        private VideoEditCore VideoEdit1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates the video editing engine and subscribes to events.
        /// </summary>
        private void CreateEngine()
        {
            VideoEdit1 = new VideoEditCore(VideoView1 as IVideoView);

            VideoEdit1.OnError += VideoEdit1_OnError;
            VideoEdit1.OnStop += VideoEdit1_OnStop;
            VideoEdit1.OnProgress += VideoEdit1_OnProgress;
            VideoEdit1.OnVideoFrameBitmap += VideoEdit1_OnVideoFrameBitmap;
        }

        /// <summary>
        /// Destroys the video editing engine and unsubscribes from events.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoEdit1 != null)
            {
                VideoEdit1.OnError -= VideoEdit1_OnError;
                VideoEdit1.OnStop -= VideoEdit1_OnStop;
                VideoEdit1.OnProgress -= VideoEdit1_OnProgress;
                VideoEdit1.OnVideoFrameBitmap -= VideoEdit1_OnVideoFrameBitmap;

                VideoEdit1.Dispose();
                VideoEdit1 = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutput control.
        /// Opens a file dialog to select the output file path.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the LinkClicked event of the linkLabel1 control.
        /// Opens the video tutorials help link.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// Initializes the engine and sets default values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{VideoEdit1.SDK_Version()})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            cbFrameRate.SelectedIndex = 7;
            cbOutputFormat.SelectedIndex = 7;
        }

        /// <summary>
        /// Configures the MP4 output settings.
        /// </summary>
        /// <param name="mp4Output">The MP4 output settings.</param>
        private void SetMP4Output(ref MP4Output mp4Output)
        {
            if (this._mp4SettingsDialog == null)
            {
                this._mp4SettingsDialog = new MP4SettingsDialog();
            }

            this._mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Configures the FFMPEG EXE output settings.
        /// </summary>
        /// <param name="ffmpegOutput">The FFMPEG EXE output settings.</param>
        private void SetFFMPEGEXEOutput(ref FFMPEGEXEOutput ffmpegOutput)
        {
            if (_ffmpegEXESettingsDialog == null)
            {
                _ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
            }

            _ffmpegEXESettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        /// <summary>
        /// Configures the WMV output settings.
        /// </summary>
        /// <param name="wmvOutput">The WMV output settings.</param>
        private void SetWMVOutput(ref WMVOutput wmvOutput)
        {
            if (_wmvSettingsDialog == null)
            {
                _wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
            }

            _wmvSettingsDialog.WMA = false;
            _wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        /// <summary>
        /// Configures the WebM output settings.
        /// </summary>
        /// <param name="webmOutput">The WebM output settings.</param>
        private void SetWebMOutput(ref WebMOutput webmOutput)
        {
            if (_webmSettingsDialog == null)
            {
                _webmSettingsDialog = new WebMSettingsDialog();
            }

            _webmSettingsDialog.SaveSettings(ref webmOutput);
        }

        /// <summary>
        /// Configures the FFMPEG output settings.
        /// </summary>
        /// <param name="ffmpegOutput">The FFMPEG output settings.</param>
        private void SetFFMPEGOutput(ref FFMPEGOutput ffmpegOutput)
        {
            if (_ffmpegSettingsDialog == null)
            {
                _ffmpegSettingsDialog = new FFMPEGSettingsDialog();
            }

            _ffmpegSettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        /// <summary>
        /// Configures the MP4 hardware encoders output settings.
        /// </summary>
        /// <param name="mp4Output">The MP4 HW output settings.</param>
        private void SetMP4HWOutput(ref MP4HWOutput mp4Output)
        {
            if (_mp4HWSettingsDialog == null)
            {
                _mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
            }

            _mp4HWSettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Configures the Animated GIF output settings.
        /// </summary>
        /// <param name="gifOutput">The GIF output settings.</param>
        private void SetGIFOutput(ref AnimatedGIFOutput gifOutput)
        {
            if (_gifSettingsDialog == null)
            {
                _gifSettingsDialog = new GIFSettingsDialog();
            }

            _gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        /// <summary>
        /// Configures the DV output settings.
        /// </summary>
        /// <param name="dvOutput">The DV output settings.</param>
        private void SetDVOutput(ref DVOutput dvOutput)
        {
            if (_dvSettingsDialog == null)
            {
                _dvSettingsDialog = new DVSettingsDialog();
            }

            _dvSettingsDialog.SaveSettings(ref dvOutput);
        }

        /// <summary>
        /// Configures the AVI output settings.
        /// </summary>
        /// <param name="aviOutput">The AVI output settings.</param>
        private void SetAVIOutput(ref AVIOutput aviOutput)
        {
            if (_aviSettingsDialog == null)
            {
                _aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
            }

            _aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new MP3Output();
                SetMP3Output(ref mp3Output);
                aviOutput.MP3 = mp3Output;
            }
        }

        /// <summary>
        /// Configures the MP3 output settings.
        /// </summary>
        /// <param name="mp3Output">The MP3 output settings.</param>
        private void SetMP3Output(ref MP3Output mp3Output)
        {
            if (_mp3SettingsDialog == null)
            {
                _mp3SettingsDialog = new MP3SettingsDialog();
            }

            _mp3SettingsDialog.SaveSettings(ref mp3Output);
        }

        /// <summary>
        /// Configures the MKV output settings.
        /// </summary>
        /// <param name="mkvOutput">The MKV output settings.</param>
        private void SetMKVOutput(ref MKVv1Output mkvOutput)
        {
            if (_aviSettingsDialog == null)
            {
                _aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
            }

            _aviSettingsDialog.SaveSettings(ref mkvOutput);

            if (mkvOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new MP3Output();
                SetMP3Output(ref mp3Output);
                mkvOutput.MP3 = mp3Output;
            }
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the output and starts the video creation process using a blank input that will be filled manually.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

            VideoEdit1.Video_FrameRate = new VideoFrameRate(Convert.ToDouble(cbFrameRate.Text));

            // apply capture parameters            
            VideoEdit1.Video_Renderer_SetAuto();

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
                _predefinedImagesUsed = true;

                await VideoEdit1.Input_AddVideoBlankAsync(
                    TimeSpan.FromMilliseconds(10000),
                    TimeSpan.FromMilliseconds(0),
                    1280,
                    720,
                    Color.Black);
            }
            else
            {
                _predefinedImagesUsed = false;

                if (!Directory.Exists(edImagesFolder.Text))
                {
                    MessageBox.Show(this, "Folder with images doesn't exists!");
                    return;
                }

                _loadedFiles = EnumerateImageFiles(edImagesFolder.Text);

                int width = Convert.ToInt32(edWidth.Text);
                int height = Convert.ToInt32(edHeight.Text);

                _loadedImageFilename = null;
                if (_loadedImage != null)
                {
                    _loadedImage.Dispose();
                    _loadedImage = null;
                }

                await VideoEdit1.Input_AddVideoBlankAsync(
                    TimeSpan.FromSeconds(_loadedFiles.Length * 2),
                    TimeSpan.FromMilliseconds(0),
                    width,
                    height,
                    Color.Black);
            }

            await VideoEdit1.StartAsync();
        }

        /// <summary>
        /// Enumerates image files in the specified path.
        /// </summary>
        /// <param name="path">The folder path.</param>
        /// <returns>An array of image file paths.</returns>
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

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the video creation process.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, EventArgs e)
        {
            await VideoEdit1.StopAsync();
            ProgressBar1.Value = 0;
        }

        /// <summary>
        /// Handles the OnVideoFrameBitmap event of the VideoEdit engine.
        /// Manually draws the image onto the video frame for "in memory" processing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VideoFrameBitmapEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnVideoFrameBitmap(object sender, VideoFrameBitmapEventArgs e)
        {
            Bitmap frame;

            if (_predefinedImagesUsed)
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
                if (_loadedImageFilename == _loadedFiles[index])
                {
                    frame = _loadedImage;
                }
                else
                {
                    _loadedImageFilename = _loadedFiles[index];
                    _loadedImage?.Dispose();
                    _loadedImage = new Bitmap(_loadedFiles[index]);

                    frame = _loadedImage;
                }
            }

            using (Graphics g = Graphics.FromImage(e.Frame))
            {
                g.DrawImage(frame, new RectangleF(0, 0, e.Frame.Width, e.Frame.Height), new RectangleF(0, 0, frame.Width, frame.Height), GraphicsUnit.Pixel);
                e.UpdateData = true;
            }

            if (_predefinedImagesUsed)
            {
                frame.Dispose();
            }
        }

        /// <summary>
        /// Handles the OnProgress event of the VideoEdit engine.
        /// Updates the progress bar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ProgressEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Invoke((Action)(() => { ProgressBar1.Value = e.Progress; }));
        }

        /// <summary>
        /// Handles the OnStop event of the VideoEdit engine.
        /// Resets the UI and displays a completion message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="StopEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            Invoke((Action)(() =>
            {
                ProgressBar1.Value = 0;
                 
                if (e.Successful)
                {
                    MessageBox.Show(this, "Completed successfully", string.Empty, MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(this, "Stopped with error", string.Empty, MessageBoxButtons.OK);
                }
            }));      
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cbOutputFormat control.
        /// Updates the output file extension based on the selected format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4"); //-V3139
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

        /// <summary>
        /// Handles the Click event of the btConfigure control.
        /// Opens the settings dialog for the selected output format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btConfigure_Click(object sender, EventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                case 1:
                    {
                        if (_aviSettingsDialog == null)
                        {
                            _aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
                        }

                        _aviSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 2:
                    {
                        if (_wmvSettingsDialog == null)
                        {
                            _wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
                        }

                        _wmvSettingsDialog.WMA = false;
                        _wmvSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 3:
                    {
                        if (_dvSettingsDialog == null)
                        {
                            _dvSettingsDialog = new DVSettingsDialog();
                        }

                        _dvSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 4:
                    {
                        if (_webmSettingsDialog == null)
                        {
                            _webmSettingsDialog = new WebMSettingsDialog();
                        }

                        _webmSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 5:
                    {
                        if (_ffmpegSettingsDialog == null)
                        {
                            _ffmpegSettingsDialog = new FFMPEGSettingsDialog();
                        }

                        _ffmpegSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 6:
                    {
                        if (_ffmpegEXESettingsDialog == null)
                        {
                            _ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
                        }

                        _ffmpegEXESettingsDialog.ShowDialog(this);

                        break;
                    }
                case 7:
                case 10:
                    {
                        if (this._mp4SettingsDialog == null)
                        {
                            this._mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        this._mp4SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 8:
                    {
                        if (_mp4HWSettingsDialog == null)
                        {
                            _mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
                        }

                        _mp4HWSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 9:
                    {
                        if (_gifSettingsDialog == null)
                        {
                            _gifSettingsDialog = new GIFSettingsDialog();
                        }

                        _gifSettingsDialog.ShowDialog(this);

                        break;
                    }
            }
        }

        /// <summary>
        /// Handles the Click event of the btTextLogoAdd control.
        /// Adds a new text logo effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btImageLogoAdd control.
        /// Adds a new image logo effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btLogoRemove control.
        /// Removes the selected logo effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btLogoRemove_Click(object sender, EventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                VideoEdit1.Video_Effects_Remove((string)lbLogos.SelectedItem);
                lbLogos.Items.Remove(lbLogos.SelectedItem);
            }
        }

        /// <summary>
        /// Handles the Click event of the btLogoEdit control.
        /// Opens the settings dialog for the selected logo effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btLogoEdit_Click(object sender, EventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                var effect = VideoEdit1.Video_Effects_Get((string)lbLogos.SelectedItem);
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
        /// Handles the tb lightness scroll event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the tb saturation scroll event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the tb contrast scroll event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the cb flip checked changed event.
        /// </summary>
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

        /// <summary>
        /// Handles the cb flip checked changed event.
        /// </summary>
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

        /// <summary>
        /// Handles the cb greyscale checked changed event.
        /// </summary>
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

        /// <summary>
        /// Handles the cb invert checked changed event.
        /// </summary>
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

        /// <summary>
        /// Handles the tb darkness scroll event.
        /// </summary>
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

        /// <summary>
        /// Video edit 1 on error.
        /// </summary>
        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text += e.Message + Environment.NewLine;
                                   }));
        }

        /// <summary>
        /// Handles the bt select images folder click event.
        /// </summary>
        private void btSelectImagesFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                edImagesFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }

        /// <summary>
        /// Link label decoders link clicked.
        /// </summary>
        private void linkLabelDecoders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistLAVx64);
            Process.Start(startInfo);
        }
    }
}

