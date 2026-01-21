











namespace VideoEdit_CS_Demo
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Core;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.AudioEffects;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.VideoEdit;
    using VisioForge.Core.Types.X.VideoEffects;
    using VisioForge.Core.UI;
    using VisioForge.Core.VideoEditX;

    /// <summary>
    /// The main form for the Video Edit SDK X Main Demo.
    /// Provides an interface for configuring video sources, effects, and output formats using the X-engine.
    /// </summary>
    public partial class Form1 : Form
    {
        private VideoEditCoreX VideoEdit1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btClearList control.
        /// Clears the input files list and resets the UI appropriately.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btClearList_Click(object sender, EventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
        }

        /// <summary>
        /// Handles the Click event of the btAddInputFile control.
        /// Opens a file dialog to select and add video, image, or audio files to the project.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btAddInputFile_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = OpenDialog1.FileName;

                lbFiles.Items.Add(s);

                if (!string.IsNullOrEmpty(edWidth.Text) && !string.IsNullOrEmpty(edHeight.Text))
                {
                    VideoEdit1.Output_VideoSize = new VisioForge.Core.Types.Size(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text));
                }

                var frameRate = Convert.ToInt32(cbFrameRate.Text, CultureInfo.InvariantCulture);
                if (frameRate != 0)
                {
                    VideoEdit1.Output_VideoFrameRate = new VideoFrameRate(frameRate);
                }

                if (FilenameHelper.IsImageFile(s))
                {
                    if (cbAddFullFile.Checked)
                    {
                        if (cbInsertAfterPreviousFile.Checked)
                        {
                            VideoEdit1.Input_AddImageFile(
                                s,
                                TimeSpan.FromMilliseconds(2000),
                                null);
                        }
                        else
                        {
                            VideoEdit1.Input_AddImageFile(
                                s,
                                TimeSpan.FromMilliseconds(2000),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                    else
                    {
                        if (cbInsertAfterPreviousFile.Checked)
                        {
                            VideoEdit1.Input_AddImageFile(
                                s,
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text) - Convert.ToInt32(edStartTime.Text)));
                        }
                        else
                        {
                            VideoEdit1.Input_AddImageFile(
                                s,
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text) - Convert.ToInt32(edStartTime.Text)),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                }
                else if (FilenameHelper.IsAudioFile(s))
                {
                    if (cbAddFullFile.Checked)
                    {
                        var audioFile = new AudioFileSource(s);
                        if (cbInsertAfterPreviousFile.Checked)
                        {
                            VideoEdit1.Input_AddAudioFile(audioFile, null);
                        }
                        else
                        {
                            VideoEdit1.Input_AddAudioFile(audioFile, insertTime: TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                    else
                    {
                        var audioFile = new AudioFileSource(
                            s,
                            TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)),
                            TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)));
                        if (cbInsertAfterPreviousFile.Checked)
                        {
                            VideoEdit1.Input_AddAudioFile(audioFile, null);
                        }
                        else
                        {
                            VideoEdit1.Input_AddAudioFile(audioFile, insertTime: TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                }
                else
                {
                    if (cbAddFullFile.Checked)
                    {
                        if (cbInsertAfterPreviousFile.Checked)
                        {
                            VideoEdit1.Input_AddVideoFile(s, null);
                        }
                        else
                        {
                            VideoEdit1.Input_AddAudioVideoFile(s, insertTime: TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                    else
                    {
                        if (cbInsertAfterPreviousFile.Checked)
                        {
                            VideoEdit1.Input_AddAudioVideoFile(
                                s,
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)),
                                null);
                        }
                        else
                        {
                            VideoEdit1.Input_AddAudioVideoFile(
                                s,
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutput control.
        /// Opens a save file dialog to specify the output target.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = SaveDialog1.FileName;
            }
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            VideoEdit1 = new VideoEditCoreX(VideoView1 as IVideoView);

            VideoEdit1.OnError += VideoEdit1_OnError;
            VideoEdit1.OnStart += VideoEdit1_OnStart;
            VideoEdit1.OnStop += VideoEdit1_OnStop;
            VideoEdit1.OnProgress += VideoEdit1_OnProgress;

            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoEdit1 != null)
            {
                VideoEdit1.OnError -= VideoEdit1_OnError;
                VideoEdit1.OnStart -= VideoEdit1_OnStart;
                VideoEdit1.OnStop -= VideoEdit1_OnStop;
                VideoEdit1.OnProgress -= VideoEdit1_OnProgress;

                VideoEdit1.Dispose();
                VideoEdit1 = null;
            }
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// Initializes the SDK engine, sets default UI values, and populates transition lists.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            // We have to initialize the engine on start
            Text += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            CreateEngine();

            Text += $" (SDK v{VideoEditCoreX.SDK_Version})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

            cbMode.SelectedIndex = 1;
            cbFrameRate.SelectedIndex = 0;
            cbOutputVideoFormat.SelectedIndex = 0;
            cbRotate.SelectedIndex = 0;

            var transitions = VideoEdit1.Video_Transitions_Names();
            foreach (var item in transitions)
            {
                cbTransitionName.Items.Add(item);
            }

            cbTransitionName.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the engine with selected output format, effects, and starts the process.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btStart_Click(object sender, EventArgs e)
        {
            VideoEdit1.Debug_Mode = cbDebugMode.Checked;
            VideoEdit1.Debug_Telemetry = cbTelemetry.Checked;

            mmLog.Clear();


            if (cbCrop.Checked)
            {
                VideoEdit1.Output_VideoCrop = new CropVideoEffect(
                    Convert.ToInt32(edCropLeft.Text),
                    Convert.ToInt32(edCropTop.Text),
                    Convert.ToInt32(edCropRight.Text),
                    Convert.ToInt32(edCropBottom.Text));
            }
            else
            {
                VideoEdit1.Output_VideoCrop = null;
            }

            //if (cbSubtitlesEnabled.Checked)
            //{
            //    VideoEdit1.Video_Subtitles = new SubtitlesSettings(edSubtitlesFilename.Text);
            //}
            //else
            //{
            //    VideoEdit1.Video_Subtitles = null;
            //}

            if (cbMode.SelectedIndex == 0)
            {
                switch (cbOutputVideoFormat.SelectedIndex)
                {
                    case 0:
                        {
                            var mp4Output = new MP4Output(edOutput.Text);
                            VideoEdit1.Output_Format = mp4Output;

                            break;
                        }
                    case 1:
                        {
                            var webmOutput = new WebMOutput(edOutput.Text);
                            VideoEdit1.Output_Format = webmOutput;

                            break;
                        }
                    case 2:
                        {
                            var mkvOutput = new MKVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = mkvOutput;

                            break;
                        }
                    case 3:
                        {
                            var wmvOutput = new WMVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = wmvOutput;

                            break;
                        }
                    case 4:
                        {
                            var acmOutput = new WAVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = acmOutput;

                            break;
                        }
                    case 5:
                        {
                            var mp3Output = new MP3Output(edOutput.Text);
                            VideoEdit1.Output_Format = mp3Output;

                            break;
                        }
                    case 6:
                        {
                            var m4aOutput = new M4AOutput(edOutput.Text);
                            VideoEdit1.Output_Format = m4aOutput;

                            break;
                        }
                    case 7:
                        {
                            var wmaOutput = new WMAOutput(edOutput.Text);
                            VideoEdit1.Output_Format = wmaOutput;

                            break;
                        }
                    case 8:
                        {
                            var oggVorbisOutput = new OGGVorbisOutput(edOutput.Text);
                            VideoEdit1.Output_Format = oggVorbisOutput;

                            break;
                        }
                    case 9:
                        {
                            var flacOutput = new FLACOutput(edOutput.Text);
                            VideoEdit1.Output_Format = flacOutput;

                            break;
                        }
                    case 10:
                        {
                            var speexOutput = new SpeexOutput(edOutput.Text);
                            VideoEdit1.Output_Format = speexOutput;

                            break;
                        }
                }
            }
            else
            {
                VideoEdit1.Output_Format = null;
            }

            // Audio effects
            VideoEdit1.Audio_Effects.Clear();

            if (cbAudAmplifyEnabled.Checked)
            {
                var amplify = new AmplifyAudioEffect(tbAudAmplifyAmp.Value / 100.0);
                VideoEdit1.Audio_Effects.Add(amplify);
            }

            if (cbAudEqualizerEnabled.Checked)
            {
                var levels = new double[] { tbAudEq0.Value, tbAudEq1.Value, tbAudEq2.Value, tbAudEq3.Value, tbAudEq4.Value,
                                            tbAudEq5.Value,tbAudEq6.Value,tbAudEq7.Value,tbAudEq8.Value,tbAudEq9.Value};
                var eq10 = new Equalizer10AudioEffect(levels);
                VideoEdit1.Audio_Effects.Add(eq10);
            }

            // Video effects CPU
            AddVideoEffects();

            // video rotation
            switch (cbRotate.SelectedIndex)
            {
                case 0:
                    VideoEdit1.Output_VideoRotateFlip = null;
                    break;
                case 1:
                    VideoEdit1.Output_VideoRotateFlip = new FlipRotateVideoEffect(VideoFlipRotateMethod.Method90R);
                    break;
                case 2:
                    VideoEdit1.Output_VideoRotateFlip = new FlipRotateVideoEffect(VideoFlipRotateMethod.Method180);
                    break;
                case 3:
                    VideoEdit1.Output_VideoRotateFlip = new FlipRotateVideoEffect(VideoFlipRotateMethod.Method90L);
                    break;
            }

            VideoEdit1.Start();

            //lbTransitions.Items.Clear();
        }

        /// <summary>
        /// Add video effects.
        /// </summary>
        private void AddVideoEffects()
        {
            // Deinterlace
            if (cbDeinterlace.Checked)
            {
                var deint = new DeinterlaceVideoEffect();

                VideoEdit1.Video_Effects.Add(deint);
            }

            // Balance
            if (tbBrightness.Value != 0 || tbHue.Value != 0 || tbContrast.Value != 100 || tbSaturation.Value != 100)
            {
                var balance = new VideoBalanceVideoEffect();
                balance.Brightness = tbBrightness.Value / 100.0;
                balance.Hue = tbHue.Value / 100.0;
                balance.Saturation = tbSaturation.Value / 100.0;
                balance.Contrast = tbContrast.Value / 100.0;

                VideoEdit1.Video_Effects.Add(balance);
            }

            // Grayscale
            if (cbGreyscale.Checked)
            {
                var grayscale = new VideoBalanceVideoEffect();
                grayscale.Saturation = 0;

                VideoEdit1.Video_Effects.Add(grayscale);
            }

            // Sepia
            if (cbSepia.Checked)
            {
                var sepia = new ColorEffectsVideoEffect(ColorEffectsPreset.Sepia);

                VideoEdit1.Video_Effects.Add(sepia);
            }

            // Flip
            if (cbFlipX.Checked)
            {
                var flipx = new FlipRotateVideoEffect(VideoFlipRotateMethod.MethodHorizontal);

                VideoEdit1.Video_Effects.Add(flipx);
            }

            if (cbFlipY.Checked)
            {
                var flipy = new FlipRotateVideoEffect(VideoFlipRotateMethod.MethodVertical);

                VideoEdit1.Video_Effects.Add(flipy);
            }

            // Text overlay
            if (cbTextOverlay.Checked)
            {
                var textOverlay = new TextOverlay("Hello world!");

                VideoEdit1.Video_TextOverlays.Add(textOverlay);
            }

            // Image overlay
            if (cbImageOverlay.Checked)
            {
                var imageOverlay = new ImageOverlayVideoEffect("logo.png");

                VideoEdit1.Video_Effects.Add(imageOverlay);
            }
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the video editing process and clears the project state.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btStop_Click(object sender, EventArgs e)
        {
            VideoEdit1.Stop();

            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
            ProgressBar1.Value = 0;

            VideoEdit1.Video_Effects.Clear();
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VideoEdit1.Stop();

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Link label 1 link clicked.
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the Scroll event of the tbSeeking control.
        /// Sets the playback position in the engine.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tbSeeking_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Position_Set(TimeSpan.FromMilliseconds(tbSeeking.Value));
        }

        /// <summary>
        /// Video edit 1 on error.
        /// </summary>
        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text = mmLog.Text + e.Message + "(" + e.CallSite + ")" + Environment.NewLine;
                                   }));
        }

        /// <summary>
        /// Handles the video edit 1 on start event.
        /// </summary>
        private void VideoEdit1_OnStart(object sender, EventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       tbSeeking.Maximum = (int)VideoEdit1.Duration().TotalMilliseconds;
                                   }));
        }

        /// <summary>
        /// Video edit 1 on progress.
        /// </summary>
        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       ProgressBar1.Value = e.Progress;
                                   }));
        }

        /// <summary>
        /// Video edit 1 on stop.
        /// </summary>
        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       System.Threading.Thread.Sleep(1000);

                                       ProgressBar1.Value = 0;
                                       lbFiles.Items.Clear();
                                       //lbTransitions.Items.Clear();

                                       if (e.Successful)
                                       {
                                           MessageBox.Show(this, "Completed successfully", string.Empty, MessageBoxButtons.OK);
                                       }
                                       else
                                       {
                                           MessageBox.Show(this, "Stopped with error", string.Empty, MessageBoxButtons.OK);
                                       }

                                       // DestroyEngine();
                                       //CreateEngine();
                                   }));

            //VideoEdit1.Input_Clear_List();
            //VideoEdit1.Video_Transitions.Clear();
            //VideoEdit1.Video_Effects.Clear();         
        }

        /// <summary>
        /// Handles the bt add transition click event.
        /// </summary>
        private void btAddTransition_Click(object sender, EventArgs e)
        {
            var trans = new VideoTransition(
                cbTransitionName.Text,
                TimeSpan.FromMilliseconds(Convert.ToInt32(edTransStartTime.Text)),
                TimeSpan.FromMilliseconds(Convert.ToInt32(edTransStopTime.Text)));
            VideoEdit1.Video_Transitions.Add(trans);

            // add to list
            lbTransitions.Items.Add(cbTransitionName.Text +
            "(Start: " + edTransStartTime.Text + ", stop: " + edTransStopTime.Text + ")");
        }

        /// <summary>
        /// Handles the bt subtitles select file click event.
        /// </summary>
        private void btSubtitlesSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogSubtitles.ShowDialog() == DialogResult.OK)
            {
                edSubtitlesFilename.Text = openFileDialogSubtitles.FileName;
            }
        }
    }
}


