using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.MediaInfo;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoEdit;
using VisioForge.Core.UI;
using VisioForge.Core.VideoEdit;

namespace File_Encryptor
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The video editing engine instance.
        /// </summary>
        VideoEditCore _videoEdit = new VideoEditCore();

        /// <summary>
        /// Indicates whether fast encryption mode is used (stream copy instead of re-encoding).
        /// </summary>
        bool _fastEncrypt = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// Initializes the SDK version display and sets default file paths.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            Text += $" (SDK v{VideoEditCore.GetVersion()})";

            edOutputFile.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.enc");
            _videoEdit.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            _videoEdit.OnError += _videoEdit_OnError;
            _videoEdit.OnStop += _videoEdit_OnStop;
        }

        /// <summary>
        /// Handles the FormClosing event.
        /// Disposes the video editing engine to release resources.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmProgress.Stop();

            if (_videoEdit != null)
            {
                _videoEdit.OnError -= _videoEdit_OnError;
                _videoEdit.OnStop -= _videoEdit_OnStop;

                if (_fastEncrypt)
                {
                    _videoEdit.FastEncrypt_Stop();
                }
                else
                {
                    _videoEdit.Stop();
                }

                _videoEdit.Dispose();
                _videoEdit = null;
            }
        }

        /// <summary>
        /// Handles the OnStop event of the VideoEdit engine.
        /// Displays a completion message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisioForge.Core.Types.Events.StopEventArgs"/> instance containing the event data.</param>
        private void _videoEdit_OnStop(object sender, VisioForge.Core.Types.Events.StopEventArgs e)
        {
            Invoke((Action)(() =>
            {
                tmProgress.Stop();
                pbProgress.Value = 0;
                btStart.Enabled = true;
                btStop.Enabled = false;
                MessageBox.Show(this, "Complete");
            }));
        }

        /// <summary>
        /// Handles the OnError event of the VideoEdit engine.
        /// Logs the error message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisioForge.Core.Types.Events.ErrorsEventArgs"/> instance containing the event data.</param>
        private void _videoEdit_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Checks media info to decide between fast encryption or re-encoding, and starts the process.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, EventArgs e)
        {
            if (!File.Exists(edInputFile.Text))
            {
                MessageBox.Show(this, "Input file does not exist.");
                return;
            }

            if (string.IsNullOrWhiteSpace(edKey.Text))
            {
                MessageBox.Show(this, "Please enter an encryption key. An empty key provides no security.");
                return;
            }

            if (string.IsNullOrWhiteSpace(edOutputFile.Text))
            {
                MessageBox.Show(this, "Please select an output file.");
                return;
            }

            btStart.Enabled = false;
            btStop.Enabled = true;

            bool hasVideoStream;
            bool hasAudioStream;

            var mediaInfo = new MediaInfoReader();

            mediaInfo.Filename = edInputFile.Text;
            mediaInfo.ReadFileInfo(true);

            hasVideoStream = mediaInfo.VideoStreams.Count > 0;
            hasAudioStream = mediaInfo.AudioStreams.Count > 0;

            // H264 check
            _fastEncrypt = true;
            if (hasVideoStream)
            {
                if (!mediaInfo.VideoStreams[0].Codec.Contains("264"))
                {
                    _fastEncrypt = false;
                }
            }

            // AAC check
            if (hasAudioStream)
            {
                if (!mediaInfo.AudioStreams[0].Codec.ToLowerInvariant().Contains("aac"))
                {
                    _fastEncrypt = false;
                }
            }

            if (cbForceRecompress.Checked)
            {
                _fastEncrypt = false;
            }

            // fast encrypt or reencoding
            if (_fastEncrypt)
            {
                _videoEdit.FastEncrypt_Start(edInputFile.Text, edOutputFile.Text, VisioForge.Core.Types.Output.EncryptionKeyType.String, edKey.Text, true);
            }
            else
            {
                if (hasVideoStream)
                {
                    _videoEdit.Input_AddVideoFile(edInputFile.Text);
                }

                if (hasAudioStream)
                {
                    _videoEdit.Input_AddAudioFile(edInputFile.Text, edInputFile.Text);
                }

                // you can specify settings
                var mp4Output = new MP4Output();
                mp4Output.Encryption = true;
                mp4Output.Encryption_Format = EncryptionFormat.MP4_H264_SW_AAC;
                mp4Output.Encryption_Key = edKey.Text;

                _videoEdit.Output_Format = mp4Output;
                _videoEdit.Output_Filename = edOutputFile.Text;
                _videoEdit.Mode = VideoEditMode.Convert;
                _videoEdit.Audio_Preview_Enabled = false;

                _videoEdit.Video_Renderer.VideoRenderer = VideoRendererMode.None;

                await _videoEdit.StartAsync();
            }

            tmProgress.Start();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the encryption process.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, EventArgs e)
        {
            tmProgress.Stop();
            btStart.Enabled = true;
            btStop.Enabled = false;

            if (_fastEncrypt)
            {
                _videoEdit.FastEncrypt_Stop();
            }
            else
            {
                await _videoEdit.StopAsync();
            }
        }

        /// <summary>
        /// Handles the Click event of the btInputFile control.
        /// Opens a file dialog to select the input media file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btInputFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edInputFile.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btOutputFile control.
        /// Opens a file dialog to select the output encrypted file path.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btOutputFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutputFile.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Tick event of the tmProgress timer.
        /// Updates the progress bar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tmProgress_Tick(object sender, EventArgs e)
        {
            if (_fastEncrypt)
            {
                pbProgress.Value = _videoEdit.FastEncrypt_GetProgress();
            }
            else
            {
                pbProgress.Value = _videoEdit.GetProgress();
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