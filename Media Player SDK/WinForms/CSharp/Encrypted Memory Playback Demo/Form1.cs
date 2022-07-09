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
    public partial class Form1 : Form
    {
        private ManagedIStream _stream;

        private FileStream _fileStream;

        private MediaPlayerCore MediaPlayer1;

        private VideoDecryptorStream _decryptor;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
        }

        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer1_OnError;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
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

            string iv = "1234567890123456";
            var ivBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            _decryptor = new VideoDecryptorStream();
            _fileStream = new FileStream(edFilename.Text, FileMode.Open);
            var decStream = _decryptor.DecryptToStream(_fileStream, edKey.Text, ivBytes);

            _stream = new ManagedIStream(decStream);
            MediaPlayer1.Source_MemoryStream = new MemoryStreamSource(_stream, videoPresent, audioPresent, decStream.Length);

            MediaPlayer1.Source_Mode = MediaPlayerSourceMode.Memory_DS;

            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            MediaPlayer1.Video_Renderer_SetAuto();

            MediaPlayer1.Debug_Mode = cbDebugMode.Checked;
            await MediaPlayer1.PlayAsync();

            tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;
            timer1.Enabled = true;
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.PauseAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.StopAsync();
            timer1.Enabled = false;
            tbTimeline.Value = 0;

            _fileStream?.Dispose();
            _fileStream = null;

            _decryptor?.Dispose();
            _decryptor = null;

            //_decryptor = null;
            //_stream = null;
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        private void tbBalance1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
        }

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
            {
                mmError.Text = mmError.Text + e.Message + Environment.NewLine;
            }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btStop_Click(null, null);

            DestroyEngine();
        }

        private void btOpenEncDec_Click(object sender, EventArgs e)
        {
            var encDecForm = new EncDecForm();
            encDecForm.ShowDialog();
        }

        private async void timer1_Tick(object sender, EventArgs e)
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
    }
}
