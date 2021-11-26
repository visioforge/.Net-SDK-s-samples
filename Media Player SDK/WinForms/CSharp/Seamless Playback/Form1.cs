namespace SeamlessPlaybackDemo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.UI;
    using VisioForge.MediaFramework;
    using VisioForge.Types;
    using VisioForge.Types.Events;
    using VisioForge.Types.MediaPlayer;

    public partial class Form1 : Form
    {
        private readonly List<string> sourceFiles;

        private MediaPlayerCore CurrentPlayer;

        private MediaPlayerCore MediaPlayer1;

        private MediaPlayerCore MediaPlayer2;

        private void CreateEngine1()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
        }

        private void CreateEngine2()
        {
            MediaPlayer2 = new MediaPlayerCore(VideoView2 as IVideoView);
            MediaPlayer2.OnError += MediaPlayer2_OnError;
            MediaPlayer2.OnStop += MediaPlayer2_OnStop;
        }

        private void DestroyEngine1()
        {
            MediaPlayer1.OnError -= MediaPlayer1_OnError;
            MediaPlayer1.OnStop -= MediaPlayer1_OnStop;

            MediaPlayer1.Dispose();
            MediaPlayer1 = null;
        }

        private void DestroyEngine2()
        {
            MediaPlayer2.OnError -= MediaPlayer2_OnError;
            MediaPlayer2.OnStop -= MediaPlayer2_OnStop;

            MediaPlayer2.Dispose();
            MediaPlayer2 = null;
        }

        public Form1()
        {
            InitializeComponent();

            sourceFiles = new List<string>();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaPlayer1.SDK_Version})";
        }

        private void btAddFileToPlaylist_Click(object sender, EventArgs e)
        {
            lbSourceFiles.Items.Add(edFilenameOrURL.Text);
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilenameOrURL.Text = openFileDialog1.FileName;
            }
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await CurrentPlayer.ResumeAsync();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await CurrentPlayer.PauseAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await CurrentPlayer.StopAsync();
            timer1.Enabled = false;
            tbTimeline.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            tbTimeline.Maximum = (int)CurrentPlayer.Duration_Time().TotalSeconds;

            int value = (int)CurrentPlayer.Position_Get_Time().TotalSeconds;
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);
            
            timer1.Tag = 0;
        }

        private void btNextFrame_Click(object sender, EventArgs e)
        {
            CurrentPlayer.NextFrame();
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            CurrentPlayer.SetSpeed(tbSpeed.Value / 10.0);
        }

        private void InitPlayer(MediaPlayerCore player)
        {
            player.Debug_Mode = cbDebugMode.Checked;
            player.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            player.Source_Mode = MediaPlayerSourceMode.LAV;
            player.Audio_OutputDevice = "Default DirectSound Device";
            MediaPlayer1.Info_UseLibMediaInfo = true;

            if (FilterHelpers.Filter_Supported_EVR())
            {
                player.Video_Renderer.VideoRenderer = VideoRendererMode.EVR;
            }
            else if (FilterHelpers.Filter_Supported_VMR9())
            {
                player.Video_Renderer.VideoRenderer = VideoRendererMode.VMR9;
            }
            else
            {
                player.Video_Renderer.VideoRenderer = VideoRendererMode.VideoRenderer;
            }
        }

        private async Task PlayFileAsync(string filename, MediaPlayerCore player)
        {
            player.FilenamesOrURL.Clear();
            player.FilenamesOrURL.Add(filename);

            await player.PlayAsync();

            timer1.Enabled = true;
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            if (lbSourceFiles.Items.Count < 2)
            {
                MessageBox.Show("You must add 2 or more files to test seamless playback.");
                return;
            }

            InitPlayer(MediaPlayer1);
            InitPlayer(MediaPlayer2);

            foreach (var item in lbSourceFiles.Items)
            {
                sourceFiles.Add(item.ToString());
            }

            CurrentPlayer = MediaPlayer1;

            VideoView1.Show();
            VideoView2.Hide();

            await PlayFileAsync(sourceFiles[0], MediaPlayer1);
            sourceFiles.RemoveAt(0);

            await PlayFileAsync(sourceFiles[0], MediaPlayer2);
            sourceFiles.RemoveAt(0);

            await MediaPlayer2.PauseAsync();
        }

        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            BeginInvoke(new StopDelegate1(StopDelegateMethod1), null);
        }

        private void MediaPlayer2_OnStop(object sender, StopEventArgs e)
        {
            BeginInvoke(new StopDelegate2(StopDelegateMethod2), null);
        }

        private delegate void StopDelegate1();

        private delegate void StopDelegate2();

        private async void StopDelegateMethod1()
        {
            //timer1.Enabled = false;
            tbTimeline.Value = 0;

            VideoView1.Hide();
            VideoView2.Show();

            CurrentPlayer = MediaPlayer2;
            await MediaPlayer2.ResumeAsync();
            if (sourceFiles.Count > 0)
            {
                await this.PlayFileAsync(sourceFiles[0], MediaPlayer1);
                sourceFiles.RemoveAt(0);
                await MediaPlayer1.PauseAsync();
            }
        }

        private async void StopDelegateMethod2()
        {
            //timer1.Enabled = false;
            tbTimeline.Value = 0;

            VideoView1.Show();
            VideoView2.Hide();

            CurrentPlayer = MediaPlayer1;
            await MediaPlayer1.ResumeAsync();
            if (sourceFiles.Count > 0)
            {
                await this.PlayFileAsync(sourceFiles[0], MediaPlayer2);
                sourceFiles.RemoveAt(0);
                await MediaPlayer2.PauseAsync();
            }
        }

        private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MediaPlayer1.State != PlaybackState.Free)
            {
                await MediaPlayer1.StopAsync();
            }

            if (MediaPlayer2.State != PlaybackState.Free)
            {
                await MediaPlayer2.StopAsync();
            }

            DestroyEngine1();
            DestroyEngine2();
        }

        private void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                CurrentPlayer.Position_Set_Time(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void MediaPlayer2_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text += e.Message + Environment.NewLine;
                                   }));
        }

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text += e.Message + Environment.NewLine;
                                   }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine1();
            CreateEngine2();

            Text += $" (SDK v{MediaPlayer1.SDK_Version})";
        }
    }
}
