namespace Karaoke_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core.CDG;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.UI;

    public partial class Form1 : Form
    {
        private MediaPlayerCore MediaPlayer1;

        private CDGFile _cdg;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore();
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
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

                if (_cdg != null)
                {
                    _cdg.Dispose();
                    _cdg = null;
                }

                var cdgFile = Path.Combine(Path.GetDirectoryName(edFilename.Text), Path.GetFileNameWithoutExtension(edFilename.Text)) + ".cdg";
                if (File.Exists(cdgFile))
                {
                    _cdg = new CDGFile(cdgFile);
                }
            }
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
            mmError.Clear();

            MediaPlayer1.Playlist_Clear();
            MediaPlayer1.Playlist_Add(edFilename.Text);

            MediaPlayer1.Audio_PlayAudio = true;

            MediaPlayer1.Source_Mode = MediaPlayerSourceMode.File_DS;
            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.None;

            MediaPlayer1.Debug_Mode = cbDebugMode.Checked;
            MediaPlayer1.Info_UseLibMediaInfo = true;

            await MediaPlayer1.PlayAsync();

            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);

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

            imgScreen.Image = null;
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        private void tbBalance1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;

            if (((await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds > 0) && ((await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds < tbTimeline.Maximum))
            {
                tbTimeline.Value = (int)(await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds;
            }

            lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);

            if (_cdg != null)
            {
                if (_cdg.renderAtPosition((long)(await MediaPlayer1.Position_Get_TimeAsync()).TotalMilliseconds))
                {
                    imgScreen.Image = _cdg.RGBImage();
                }
            }

            timer1.Tag = 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btStop_Click(null, null);
        }
    }
}
