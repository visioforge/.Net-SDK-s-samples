// ReSharper disable InconsistentNaming

namespace Video_Player_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.UI;

    public partial class Form1 : Form
    {
        private MediaPlayerCore MediaPlayer1;

        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
        }

        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer1_OnError;
                MediaPlayer1.OnStop -= MediaPlayer1_OnStop;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
        }

        public Form1()
        {
            InitializeComponent();
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

        private async void tbSpeed_Scroll(object sender, EventArgs e)
        {
            await MediaPlayer1.SetSpeedAsync(tbSpeed.Value / 10.0);
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmError.Clear();

            switch (cbSourceMode.SelectedIndex)
            {
                case 0:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV;
                    break;
                case 1:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.File_DS;
                    break;
                case 2:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.FFMPEG;
                    break;
                case 3:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.File_VLC;
                    break;
            }

            MediaPlayer1.Playlist_Clear();
            MediaPlayer1.Playlist_Add(edFilename.Text);

            MediaPlayer1.Loop = cbLoop.Checked;
            MediaPlayer1.Audio_PlayAudio = true;
            MediaPlayer1.Info_UseLibMediaInfo = true;
            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            MediaPlayer1.Video_Renderer_SetAuto();

            MediaPlayer1.Debug_Mode = cbDebugMode.Checked;

            await MediaPlayer1.PlayAsync();

            // set audio volume for each stream
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);

            timer1.Start();
        }

        private void btNextFrame_Click(object sender, EventArgs e)
        {
            MediaPlayer1.NextFrame();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            await MediaPlayer1.StopAsync();

            tbTimeline.Value = 0;
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.PauseAsync();
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        private void tbBalance1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            cbSourceMode.SelectedIndex = 0;
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

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmError.Text = mmError.Text + e.Message + Environment.NewLine;
                                   }));
        }

        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       tbTimeline.Value = 0;
                                   }));
        }

        private void btPreviousFrame_Click(object sender, EventArgs e)
        {
            MediaPlayer1.PreviousFrame();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btStop_Click(null, null);

            DestroyEngine();
        }
    }
}

// ReSharper restore InconsistentNaming
