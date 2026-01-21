using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.Output;
using VisioForge.Core.UI;
using VisioForge.Core.VideoEdit;

namespace Audio_Extractor
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The video editing engine instance.
        /// </summary>
        private VideoEditCore _core;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutput control.
        /// Opens a file dialog to select the output audio file path.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutputFile.Text = SaveDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btSelectInput control.
        /// Opens a file dialog to select the source video file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btSelectInput_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                edSourceFile.Text = OpenDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// Initializes the engine and sets default values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            edOutputFile.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp3");

            _core = new VideoEditCore();
            _core.Video_Renderer.VideoRenderer = VideoRendererMode.None;
            _core.OnProgress += _core_OnProgress;
            _core.OnError += _core_OnError;
            _core.OnStop += _core_OnStop;
        }

        /// <summary>
        /// Handles the OnStop event of the VideoEdit engine.
        /// Updates the UI and displays a completion message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void _core_OnStop(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                btStart.Enabled = true;
                btStop.Enabled = false;

                pbProgress.Value = 0;

                MessageBox.Show(this, "Finished!");
            }));
        }

        /// <summary>
        /// Handles the OnError event of the VideoEdit engine.
        /// Logs the error message to debug output and the text box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void _core_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);

            Invoke(new Action(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Handles the OnProgress event of the VideoEdit engine.
        /// Updates the progress bar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ProgressEventArgs"/> instance containing the event data.</param>
        private void _core_OnProgress(object sender, ProgressEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (e.Progress > 0)
                {
                    pbProgress.Value = e.Progress;
                }
            }));
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Starts the audio extraction or re-encoding process.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, EventArgs e)
        {
            btStart.Enabled = false;
            btStop.Enabled = true;

            if (rbExtract.Checked)
            {
                await _core.FastEdit_ExtractAudioStreamAsync(edSourceFile.Text, TimeSpan.Zero, TimeSpan.Zero, edOutputFile.Text);
            }
            else
            {
                await _core.Input_AddAudioFileAsync(edSourceFile.Text);

                _core.Output_Filename = edOutputFile.Text;

                if (rbReencodeMP3.Checked)
                {
                    _core.Output_Format = new MP3Output();
                }
                else if (rbReencodeM4A.Checked)
                {
                    _core.Output_Format = new M4AOutput();
                }

                await _core.StartAsync();
            }
        }

        /// <summary>
        /// Handles the LinkClicked event of the linkLabelDecoders control.
        /// Opens the download link for LAV decoders.
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