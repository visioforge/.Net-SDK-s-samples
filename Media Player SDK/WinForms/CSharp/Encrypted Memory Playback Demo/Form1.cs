using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Core;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.MediaPlayer;
using VisioForge.Core.UI;
using VisioForge.Core.VideoEncryption;

namespace Encrypted_Memory_Playback_Demo
{
    /// <summary>
    /// Encrypted memory playback demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The managed stream.
        /// </summary>
        private ManagedIStream _stream;

        /// <summary>
        /// The file stream.
        /// </summary>
        private FileStream _fileStream;

        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCore MediaPlayer1;

        /// <summary>
        /// The video decryptor stream.
        /// </summary>
        private VideoDecryptorStream _decryptor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
        }

        /// <summary>
        /// Media player 1 on stop.
        /// </summary>
        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            timer1.Enabled = false;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer1_OnError;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
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
        /// Handles the tb timeline scroll event.
        /// </summary>
        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(timer1.Tag) == 0)
                {
                    await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                mmError.Text = string.Empty;

                // video and audio present in file. tune this settings to play audio files or video files without audio
                bool videoPresent;
                bool audioPresent;
                if (rbVideoWithAudio.Checked)
                {
                    videoPresent = true;
                    audioPresent = true;
                }
                else if (rbVideoWithoutAudio.Checked)
                {
                    videoPresent = true;
                    audioPresent = false;
                }
                else
                {
                    videoPresent = false;
                    audioPresent = true;
                }

                // WARNING: This IV is hardcoded for demonstration purposes only.
                // In production, use a cryptographically random IV for each encryption operation.
                string iv = "1234567890123456";
                var ivBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

                _decryptor = new VideoDecryptorStream();
                _fileStream = new FileStream(edFilename.Text, FileMode.Open);
                var decStream = _decryptor.DecryptToStream(_fileStream, edKey.Text, ivBytes);

                _stream = new ManagedIStream(decStream);
                MediaPlayer1.Source_MemoryStream = new MemoryStreamSource(_stream, videoPresent, audioPresent, decStream.Length);

                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.Memory_DS;

                MediaPlayer1.Audio_PlayAudio = audioPresent;
                MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

                MediaPlayer1.Video_Renderer_SetAuto();

                MediaPlayer1.Debug_Mode = cbDebugMode.Checked;
                await MediaPlayer1.PlayAsync();

                tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, EventArgs e)
        {
            try
            {
                await MediaPlayer1.ResumeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, EventArgs e)
        {
            try
            {
                await MediaPlayer1.PauseAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Stop async.
        /// </summary>
        private async Task StopAsync()
        {
            await MediaPlayer1.StopAsync();
            timer1.Enabled = false;
            tbTimeline.Value = 0;

            _stream = null;

            _fileStream?.Dispose();
            _fileStream = null;

            _decryptor?.Dispose();
            _decryptor = null;
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            try
            {
                await StopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the tb volume 1 scroll event.
        /// </summary>
        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        /// <summary>
        /// Handles the tb balance 1 scroll event.
        /// </summary>
        private void tbBalance1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
        }

        /// <summary>
        /// Media player 1 on error.
        /// </summary>
        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
            {
                mmError.AppendText(e.Message + Environment.NewLine);
            }));
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                await StopAsync();

                DestroyEngine();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt open enc dec click event.
        /// </summary>
        private void btOpenEncDec_Click(object sender, EventArgs e)
        {
            var encDecForm = new EncDecForm();
            encDecForm.ShowDialog();
        }

        /// <summary>
        /// Handles the timer 1 tick event.
        /// </summary>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Tag = 1;
                tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;

                int value = (int)(await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds;
                if ((value > 0) && (value < tbTimeline.Maximum))
                {
                    tbTimeline.Value = value;
                }

                lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);

                timer1.Tag = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
