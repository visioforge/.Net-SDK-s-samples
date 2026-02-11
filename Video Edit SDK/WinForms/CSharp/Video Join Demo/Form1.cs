using System;
using System.Globalization;
using System.Windows.Forms;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Output;
using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;

namespace Video_Join_Demo
{
    using System.Diagnostics;
    using System.IO;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.VideoEdit;
    using VisioForge.Core.UI;
    using VisioForge.Core.VideoEdit;

    /// <summary>
    /// Video join demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The MP4 hardware encoders settings dialog.
        /// </summary>
        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;

        /// <summary>
        /// The MP4 settings dialog.
        /// </summary>
        private MP4SettingsDialog mp4SettingsDialog;

        /// <summary>
        /// The AVI settings dialog.
        /// </summary>
        private AVISettingsDialog aviSettingsDialog;

        /// <summary>
        /// The WMV settings dialog.
        /// </summary>
        private WMVSettingsDialog wmvSettingsDialog;

        /// <summary>
        /// The DV settings dialog.
        /// </summary>
        private DVSettingsDialog dvSettingsDialog;

        /// <summary>
        /// The PCM (audio) settings dialog.
        /// </summary>
        private PCMSettingsDialog pcmSettingsDialog;

        /// <summary>
        /// The MP3 settings dialog.
        /// </summary>
        private MP3SettingsDialog mp3SettingsDialog;

        /// <summary>
        /// The WebM settings dialog.
        /// </summary>
        private WebMSettingsDialog webmSettingsDialog;

        /// <summary>
        /// The FFMPEG settings dialog.
        /// </summary>
        private FFMPEGSettingsDialog ffmpegSettingsDialog;

        /// <summary>
        /// The FFMPEG EXE settings dialog.
        /// </summary>
        private FFMPEGEXESettingsDialog ffmpegEXESettingsDialog;

        /// <summary>
        /// The FLAC settings dialog.
        /// </summary>
        private FLACSettingsDialog flacSettingsDialog;

        /// <summary>
        /// The custom format settings dialog.
        /// </summary>
        private CustomFormatSettingsDialog customFormatSettingsDialog;

        /// <summary>
        /// The Ogg Vorbis settings dialog.
        /// </summary>
        private OggVorbisSettingsDialog oggVorbisSettingsDialog;

        /// <summary>
        /// The Speex settings dialog.
        /// </summary>
        private SpeexSettingsDialog speexSettingsDialog;

        /// <summary>
        /// The M4A settings dialog.
        /// </summary>
        private M4ASettingsDialog m4aSettingsDialog;

        /// <summary>
        /// The GIF settings dialog.
        /// </summary>
        private GIFSettingsDialog gifSettingsDialog;

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

                VideoEdit1.Dispose();
                VideoEdit1 = null;
            }
        }

        /// <summary>
        /// Gets the file extension from the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The file extension including the dot.</returns>
        private static string GetFileExt(string filename)
        {
            return Path.GetExtension(filename);
        }

        /// <summary>
        /// Handles the Click event of the BtAddInputFile control.
        /// Adds a video, image, or audio file to the input list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void BtAddInputFile_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                VideoEdit1.Video_FrameRate = new VideoFrameRate(Convert.ToDouble(cbFrameRate.Text, CultureInfo.InvariantCulture));

                string s = OpenDialog1.FileName;

                lbFiles.Items.Add(s);

                // resize if required
                int customWidth = 0;
                int customHeight = 0;

                if (cbResize.Checked)
                {
                    customWidth = Convert.ToInt32(edWidth.Text);
                    customHeight = Convert.ToInt32(edHeight.Text);
                }

                if ((string.Compare(GetFileExt(s), ".BMP", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".JPG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".JPEG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".GIF", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".PNG", StringComparison.OrdinalIgnoreCase) == 0))
                {
                    await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds(2000), null, VideoEditStretchMode.Letterbox, 0, customWidth, customHeight);
                }
                else if ((string.Compare(GetFileExt(s), ".WAV", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".MP3", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".OGG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".WMA", StringComparison.OrdinalIgnoreCase) == 0))
                {
                    var audioFile = new AudioSource(s, TimeSpan.Zero, TimeSpan.Zero, string.Empty);
                    await VideoEdit1.Input_AddAudioFileAsync(audioFile, null, 0);
                }
                else
                {
                    var videoFile = new VideoSource(s, TimeSpan.Zero, TimeSpan.Zero, VideoEditStretchMode.Letterbox);
                    var audioFile = new AudioSource(s, TimeSpan.Zero, TimeSpan.Zero, string.Empty);

                    await VideoEdit1.Input_AddVideoFileAsync(videoFile, null, 0, customWidth, customHeight);
                    await VideoEdit1.Input_AddAudioFileAsync(audioFile, null, 0);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the BtSelectOutput control.
        /// Opens a file dialog to select the output file path.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtSelectOutput_Click(object sender, EventArgs e)
        {
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = SaveDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the BtClearList control.
        /// Clears the input files list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtClearList_Click(object sender, EventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
        }

        /// <summary>
        /// Handles the Click event of the BtConfigure control.
        /// Opens the settings dialog for the selected output format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtConfigure_Click(object sender, EventArgs e)
        {
            switch (cbOutputVideoFormat.SelectedIndex)
            {
                case 0:
                case 1:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
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
                        if (pcmSettingsDialog == null)
                        {
                            pcmSettingsDialog = new PCMSettingsDialog(VideoEdit1);
                        }

                        pcmSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 5:
                    {
                        if (mp3SettingsDialog == null)
                        {
                            mp3SettingsDialog = new MP3SettingsDialog();
                        }

                        mp3SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 6:
                    {
                        if (m4aSettingsDialog == null)
                        {
                            m4aSettingsDialog = new M4ASettingsDialog();
                        }

                        m4aSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 7:
                    {
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
                        }

                        wmvSettingsDialog.WMA = true;
                        wmvSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 8:
                    {
                        if (oggVorbisSettingsDialog == null)
                        {
                            oggVorbisSettingsDialog = new OggVorbisSettingsDialog();
                        }

                        oggVorbisSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 9:
                    {
                        if (flacSettingsDialog == null)
                        {
                            flacSettingsDialog = new FLACSettingsDialog();
                        }

                        flacSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 10:
                    {
                        if (speexSettingsDialog == null)
                        {
                            speexSettingsDialog = new SpeexSettingsDialog();
                        }

                        speexSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 11:
                    {
                        if (customFormatSettingsDialog == null)
                        {
                            customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoEdit1);
                        }

                        customFormatSettingsDialog.ShowDialog(this);

                        break;
                    }

                case 12:
                    {
                        if (webmSettingsDialog == null)
                        {
                            webmSettingsDialog = new WebMSettingsDialog();
                        }

                        webmSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 13:
                    {
                        if (ffmpegSettingsDialog == null)
                        {
                            ffmpegSettingsDialog = new FFMPEGSettingsDialog();
                        }

                        ffmpegSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 14:
                    {
                        if (ffmpegEXESettingsDialog == null)
                        {
                            ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
                        }

                        ffmpegEXESettingsDialog.ShowDialog(this);

                        break;
                    }
                case 15:
                case 18:
                    {
                        if (this.mp4SettingsDialog == null)
                        {
                            this.mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        this.mp4SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 16:
                    {
                        if (mp4HWSettingsDialog == null)
                        {
                            mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
                        }

                        mp4HWSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 17:
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

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cbOutputVideoFormat control.
        /// Updates the output file extension based on the selected format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CbOutputVideoFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbOutputVideoFormat.SelectedIndex)
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
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wav");
                        break;
                    }
                case 5:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp3");
                        break;
                    }
                case 6:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".m4a");
                        break;
                    }
                case 7:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wma");
                        break;
                    }
                case 8:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg");
                        break;
                    }
                case 9:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".flac");
                        break;
                    }
                case 10:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg");
                        break;
                    }
                case 11:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 12:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm");
                        break;
                    }
                case 13:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 14:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 15:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 16:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 17:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif");
                        break;
                    }
                case 18:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".enc");
                        break;
                    }
            }
        }

        /// <summary>
        /// Handles the Click event of the BtStart control.
        /// Configures the output format and starts the video joining process.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void BtStart_Click(object sender, EventArgs e)
        {
            btStart.Enabled = false;
            btStop.Enabled = true;

            VideoEdit1.Debug_Mode = cbDebugMode.Checked;
            VideoEdit1.Debug_Telemetry = cbTelemetry.Checked;

            mmLog.Clear();

            VideoEdit1.Mode = VideoEditMode.Convert;

            VideoEdit1.Video_Effects_Clear();
            VideoEdit1.Video_Resize = cbResize.Checked;

            if (VideoEdit1.Video_Resize)
            {
                if (!int.TryParse(edWidth.Text, out int width) || width <= 0)
                {
                    MessageBox.Show(this, "Please enter a valid positive width value.");
                    btStart.Enabled = true;
                    btStop.Enabled = false;
                    return;
                }

                if (!int.TryParse(edHeight.Text, out int height) || height <= 0)
                {
                    MessageBox.Show(this, "Please enter a valid positive height value.");
                    btStart.Enabled = true;
                    btStop.Enabled = false;
                    return;
                }

                VideoEdit1.Video_Resize_Width = width;
                VideoEdit1.Video_Resize_Height = height;
            }

            if (!double.TryParse(cbFrameRate.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double frameRate) || frameRate <= 0)
            {
                MessageBox.Show(this, "Please enter a valid positive frame rate.");
                btStart.Enabled = true;
                btStop.Enabled = false;
                return;
            }

            VideoEdit1.Video_FrameRate = new VideoFrameRate(frameRate);

            VideoEdit1.Output_Filename = edOutput.Text;

            switch (cbOutputVideoFormat.SelectedIndex)
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
                        var acmOutput = new ACMOutput();
                        SetACMOutput(ref acmOutput);
                        VideoEdit1.Output_Format = acmOutput;
                        break;
                    }
                case 5:
                    {
                        var mp3Output = new MP3Output();
                        SetMP3Output(ref mp3Output);
                        VideoEdit1.Output_Format = mp3Output;
                        break;
                    }
                case 6:
                    {
                        var m4aOutput = new M4AOutput();
                        SetM4AOutput(ref m4aOutput);
                        VideoEdit1.Output_Format = m4aOutput;
                        break;
                    }
                case 7:
                    {
                        var wmaOutput = new WMAOutput();
                        SetWMAOutput(ref wmaOutput);
                        VideoEdit1.Output_Format = wmaOutput;
                        break;
                    }
                case 8:
                    {
                        var oggVorbisOutput = new OGGVorbisOutput();
                        SetOGGOutput(ref oggVorbisOutput);
                        VideoEdit1.Output_Format = oggVorbisOutput;
                        break;
                    }
                case 9:
                    {
                        var flacOutput = new FLACOutput();
                        SetFLACOutput(ref flacOutput);
                        VideoEdit1.Output_Format = flacOutput;
                        break;
                    }
                case 10:
                    {
                        var speexOutput = new SpeexOutput();
                        SetSpeexOutput(ref speexOutput);
                        VideoEdit1.Output_Format = speexOutput;
                        break;
                    }
                case 11:
                    {
                        var customOutput = new CustomOutput();
                        SetCustomOutput(ref customOutput);
                        VideoEdit1.Output_Format = customOutput;
                        break;
                    }
                case 12:
                    {
                        var webmOutput = new WebMOutput();
                        SetWebMOutput(ref webmOutput);
                        VideoEdit1.Output_Format = webmOutput;
                        break;
                    }
                case 13:
                    {
                        var ffmpegOutput = new FFMPEGOutput();
                        SetFFMPEGOutput(ref ffmpegOutput);
                        VideoEdit1.Output_Format = ffmpegOutput;
                        break;
                    }
                case 14:
                    {
                        var ffmpegOutput = new FFMPEGEXEOutput();
                        SetFFMPEGEXEOutput(ref ffmpegOutput);
                        VideoEdit1.Output_Format = ffmpegOutput;
                        break;
                    }
                case 15:
                    {
                        var mp4Output = new MP4Output();
                        SetMP4Output(ref mp4Output);
                        VideoEdit1.Output_Format = mp4Output;
                        break;
                    }
                case 16:
                    {
                        var mp4Output = new MP4HWOutput();
                        SetMP4HWOutput(ref mp4Output);
                        VideoEdit1.Output_Format = mp4Output;
                        break;
                    }
                case 17:
                    {
                        var gifOutput = new AnimatedGIFOutput();
                        SetGIFOutput(ref gifOutput);
                        VideoEdit1.Output_Format = gifOutput;
                        break;
                    }
                case 18:
                    MessageBox.Show(this, "Please use Main Demo to create encrypted files.");
                    btStart.Enabled = true;
                    btStop.Enabled = false;
                    return;
            }

            VideoEdit1.Audio_Preview_Enabled = true;

            await VideoEdit1.StartAsync();
        }

        /// <summary>
        /// Handles the Click event of the BtStop control.
        /// Stops the video joining process and clears the input list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void BtStop_Click(object sender, EventArgs e)
        {
            await VideoEdit1.StopAsync();

            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
            ProgressBar1.Value = 0;
        }

        /// <summary>
        /// Handles the OnError event of the VideoEdit engine.
        /// Logs the error message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text = mmLog.Text + e.Message + "(" + e.CallSite + ")" + Environment.NewLine;
                                   }));
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
                btStart.Enabled = true;
                btStop.Enabled = false;

                ProgressBar1.Value = 0;
                lbFiles.Items.Clear();

                VideoEdit1.Input_Clear_List();
                VideoEdit1.Video_Transition_Clear();

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
        /// Configures the MP3 output settings.
        /// </summary>
        /// <param name="mp3Output">The MP3 output settings.</param>
        private void SetMP3Output(ref MP3Output mp3Output)
        {
            if (mp3SettingsDialog == null)
            {
                mp3SettingsDialog = new MP3SettingsDialog();
            }

            mp3SettingsDialog.SaveSettings(ref mp3Output);
        }

        /// <summary>
        /// Configures the MP4 output settings.
        /// </summary>
        /// <param name="mp4Output">The MP4 output settings.</param>
        private void SetMP4Output(ref MP4Output mp4Output)
        {
            if (this.mp4SettingsDialog == null)
            {
                this.mp4SettingsDialog = new MP4SettingsDialog();
            }

            this.mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Configures the FFMPEG EXE output settings.
        /// </summary>
        /// <param name="ffmpegOutput">The FFMPEG EXE output settings.</param>
        private void SetFFMPEGEXEOutput(ref FFMPEGEXEOutput ffmpegOutput)
        {
            if (ffmpegEXESettingsDialog == null)
            {
                ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
            }

            ffmpegEXESettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        /// <summary>
        /// Configures the WMV output settings.
        /// </summary>
        /// <param name="wmvOutput">The WMV output settings.</param>
        private void SetWMVOutput(ref WMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        /// <summary>
        /// Configures the WMA output settings.
        /// </summary>
        /// <param name="wmaOutput">The WMA output settings.</param>
        private void SetWMAOutput(ref WMAOutput wmaOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
            }

            wmvSettingsDialog.WMA = true;
            wmvSettingsDialog.SaveSettings(ref wmaOutput);
        }

        /// <summary>
        /// Configures the ACM (audio) output settings.
        /// </summary>
        /// <param name="acmOutput">The ACM output settings.</param>
        private void SetACMOutput(ref ACMOutput acmOutput)
        {
            if (pcmSettingsDialog == null)
            {
                pcmSettingsDialog = new PCMSettingsDialog(VideoEdit1);
            }

            pcmSettingsDialog.SaveSettings(ref acmOutput);
        }

        /// <summary>
        /// Configures the WebM output settings.
        /// </summary>
        /// <param name="webmOutput">The WebM output settings.</param>
        private void SetWebMOutput(ref WebMOutput webmOutput)
        {
            if (webmSettingsDialog == null)
            {
                webmSettingsDialog = new WebMSettingsDialog();
            }

            webmSettingsDialog.SaveSettings(ref webmOutput);
        }

        /// <summary>
        /// Configures the FFMPEG output settings.
        /// </summary>
        /// <param name="ffmpegOutput">The FFMPEG output settings.</param>
        private void SetFFMPEGOutput(ref FFMPEGOutput ffmpegOutput)
        {
            if (ffmpegSettingsDialog == null)
            {
                ffmpegSettingsDialog = new FFMPEGSettingsDialog();
            }

            ffmpegSettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        /// <summary>
        /// Configures the FLAC output settings.
        /// </summary>
        /// <param name="flacOutput">The FLAC output settings.</param>
        private void SetFLACOutput(ref FLACOutput flacOutput)
        {
            if (flacSettingsDialog == null)
            {
                flacSettingsDialog = new FLACSettingsDialog();
            }

            flacSettingsDialog.SaveSettings(ref flacOutput);
        }

        /// <summary>
        /// Configures the MP4 hardware encoders output settings.
        /// </summary>
        /// <param name="mp4Output">The MP4 HW output settings.</param>
        private void SetMP4HWOutput(ref MP4HWOutput mp4Output)
        {
            if (mp4HWSettingsDialog == null)
            {
                mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
            }

            mp4HWSettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Configures the Speex output settings.
        /// </summary>
        /// <param name="speexOutput">The Speex output settings.</param>
        private void SetSpeexOutput(ref SpeexOutput speexOutput)
        {
            if (speexSettingsDialog == null)
            {
                speexSettingsDialog = new SpeexSettingsDialog();
            }

            speexSettingsDialog.SaveSettings(ref speexOutput);
        }

        /// <summary>
        /// Configures the M4A output settings.
        /// </summary>
        /// <param name="m4aOutput">The M4A output settings.</param>
        private void SetM4AOutput(ref M4AOutput m4aOutput)
        {
            if (m4aSettingsDialog == null)
            {
                m4aSettingsDialog = new M4ASettingsDialog();
            }

            m4aSettingsDialog.SaveSettings(ref m4aOutput);
        }

        /// <summary>
        /// Configures the Animated GIF output settings.
        /// </summary>
        /// <param name="gifOutput">The GIF output settings.</param>
        private void SetGIFOutput(ref AnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        /// <summary>
        /// Configures the custom output settings.
        /// </summary>
        /// <param name="customOutput">The custom output settings.</param>
        private void SetCustomOutput(ref CustomOutput customOutput)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoEdit1);
            }

            customFormatSettingsDialog.SaveSettings(ref customOutput);
        }

        /// <summary>
        /// Configures the DV output settings.
        /// </summary>
        /// <param name="dvOutput">The DV output settings.</param>
        private void SetDVOutput(ref DVOutput dvOutput)
        {
            if (dvSettingsDialog == null)
            {
                dvSettingsDialog = new DVSettingsDialog();
            }

            dvSettingsDialog.SaveSettings(ref dvOutput);
        }

        /// <summary>
        /// Configures the AVI output settings.
        /// </summary>
        /// <param name="aviOutput">The AVI output settings.</param>
        private void SetAVIOutput(ref AVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new MP3Output();
                SetMP3Output(ref mp3Output);
                aviOutput.MP3 = mp3Output;
            }
        }

        /// <summary>
        /// Configures the MKV output settings.
        /// </summary>
        /// <param name="mkvOutput">The MKV output settings.</param>
        private void SetMKVOutput(ref MKVv1Output mkvOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
            }

            aviSettingsDialog.SaveSettings(ref mkvOutput);

            if (mkvOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new MP3Output();
                SetMP3Output(ref mp3Output);
                mkvOutput.MP3 = mp3Output;
            }
        }

        /// <summary>
        /// Configures the Ogg Vorbis output settings.
        /// </summary>
        /// <param name="oggVorbisOutput">The Ogg Vorbis output settings.</param>
        private void SetOGGOutput(ref OGGVorbisOutput oggVorbisOutput)
        {
            if (oggVorbisSettingsDialog == null)
            {
                oggVorbisSettingsDialog = new OggVorbisSettingsDialog();
            }

            oggVorbisSettingsDialog.SaveSettings(ref oggVorbisOutput);
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

            cbFrameRate.SelectedIndex = 0;
            cbOutputVideoFormat.SelectedIndex = 15;

            btStop.Enabled = false;
        }

        /// <summary>
        /// Handles the FormClosing event of the Form1 control.
        /// Destroys the video editing engine.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }

        /// <summary>
        /// Handles the LinkClicked event of the linkLabelDecoders control.
        /// Opens the help link for LAV filters.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void linkLabelDecoders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistLAVx64);
            Process.Start(startInfo);
        }
    }
}
