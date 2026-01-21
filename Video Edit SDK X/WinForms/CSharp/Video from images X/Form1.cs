

using System;
using System.Drawing;
using System.Windows.Forms;
using VisioForge.Core.UI;
using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;


namespace Video_From_Images
{
    using System.Diagnostics;

    using VisioForge.Core.Types;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.VideoEffects;
    using System.IO;
    using VisioForge.Core.VideoEditX;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.VideoEdit;
    using VisioForge.Core;
    using VisioForge.Core.Helpers;
    using System.Globalization;

    /// <summary>
    /// The main form for the Video From Images X demo.
    /// Provides an interface for creating videos from a sequence of image files using the X-engine.
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
        /// Creates the video editing engine and subscribes to essential events.
        /// </summary>
        private void CreateEngine()
        {
            VideoEdit1 = new VideoEditCoreX(VideoView1 as IVideoView);

            VideoEdit1.OnError += VideoEdit1_OnError;
            VideoEdit1.OnStop += VideoEdit1_OnStop;
            VideoEdit1.OnProgress += VideoEdit1_OnProgress;
        }

        /// <summary>
        /// Destroys the video editing engine and unsubscribes from events to release resources.
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
        /// Handles the Click event of the btAddInputFile control.
        /// Opens a file dialog to select multiple image files to add to the video project.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btAddInputFile_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                if (cbResize.Checked)
                {
                    VideoEdit1.Output_VideoSize = new VisioForge.Core.Types.Size(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text));
                }

                var frameRate = Convert.ToInt32(cbFrameRate.Text, CultureInfo.InvariantCulture);
                if (frameRate != 0)
                {
                    VideoEdit1.Output_VideoFrameRate = new VideoFrameRate(frameRate);
                }

                foreach (var s in OpenDialog1.FileNames)
                {
                    lbFiles.Items.Add(s);

                    if (FilenameHelper.IsImageFile(s))
                    {
                        VideoEdit1.Input_AddImageFile(s, TimeSpan.FromMilliseconds(2000));
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btClearList control.
        /// Clears the input files list and resets the engine's input state.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btClearList_Click(object sender, EventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutput control.
        /// Opens a save file dialog to specify the output video file path.
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
        /// Link label 1 link clicked.
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// Initializes the SDK engine, configures default paths, and sets initial UI values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            // We have to initialize the engine on start
            Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");


            CreateEngine();

            Text += $" (SDK v{VideoEditCoreX.SDK_Version})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            cbFrameRate.SelectedIndex = 7;

            cbOutputFormat.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the output format and starts the video generation process.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();

            VideoEdit1.Debug_Mode = cbDebugMode.Checked;

            // apply capture parameters
            if (rbPreview.Checked)
            {
                VideoEdit1.Output_Format = null;
            }
            else
            {
                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            var mp4Output = new MP4Output(edOutput.Text);
                            VideoEdit1.Output_Format = mp4Output;

                            break;
                        }
                    case 1:
                        {
                            var aviOutput = new AVIOutput(edOutput.Text);
                            VideoEdit1.Output_Format = aviOutput;

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
                            var webmOutput = new WebMOutput(edOutput.Text);
                            VideoEdit1.Output_Format = webmOutput;

                            break;
                        }
                }
            }

            VideoEdit1.Start();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the video generation process and resets project state.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btStop_Click(object sender, EventArgs e)
        {
            VideoEdit1.Stop();
            ProgressBar1.Value = 0;

            VideoEdit1.Input_Clear_List();
            lbFiles.Items.Clear();
        }

        /// <summary>
        /// Video edit 1 on progress.
        /// </summary>
        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Invoke((Action)(() => { ProgressBar1.Value = e.Progress; }));
        }

        /// <summary>
        /// Video edit 1 on stop.
        /// </summary>
        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            Invoke((Action)(() =>
            {
                ProgressBar1.Value = 0;
                lbFiles.Items.Clear();

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
        /// Form 1 form closing.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();

            VisioForgeX.DestroySDK();
        }
    }
}

