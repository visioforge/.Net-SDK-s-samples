namespace SeamlessPlaybackDemo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.UI;

    /// <summary>
    /// Seamless playback demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The source files.
        /// </summary>
        private readonly List<string> sourceFiles;

        /// <summary>
        /// The current player.
        /// </summary>
        private MediaPlayerCore CurrentPlayer;

        /// <summary>
        /// The media player 1 instance.
        /// </summary>
        private MediaPlayerCore MediaPlayer1;

        /// <summary>
        /// The media player 2 instance.
        /// </summary>
        private MediaPlayerCore MediaPlayer2;

        /// <summary>
        /// Create engine 1.
        /// </summary>
        private void CreateEngine1()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer_OnError;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
        }

        /// <summary>
        /// Create engine 2.
        /// </summary>
        private void CreateEngine2()
        {
            MediaPlayer2 = new MediaPlayerCore(VideoView2 as IVideoView);
            MediaPlayer2.OnError += MediaPlayer_OnError;
            MediaPlayer2.OnStop += MediaPlayer2_OnStop;
        }

        /// <summary>
        /// Destroy engine 1.
        /// </summary>
        private void DestroyEngine1()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer_OnError;
                MediaPlayer1.OnStop -= MediaPlayer1_OnStop;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
        }

        /// <summary>
        /// Destroy engine 2.
        /// </summary>
        private void DestroyEngine2()
        {
            if (MediaPlayer2 != null)
            {
                MediaPlayer2.OnError -= MediaPlayer_OnError;
                MediaPlayer2.OnStop -= MediaPlayer2_OnStop;

                MediaPlayer2.Dispose();
                MediaPlayer2 = null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            sourceFiles = new List<string>();
        }

        /// <summary>
        /// Handles the form 1 shown event.
        /// </summary>
        private void Form1_Shown(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";
        }

        /// <summary>
        /// Handles the bt add file to playlist click event.
        /// </summary>
        private void btAddFileToPlaylist_Click(object sender, EventArgs e)
        {
            lbSourceFiles.Items.Add(edFilenameOrURL.Text);
        }

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilenameOrURL.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, EventArgs e)
        {
            try
            {
                await CurrentPlayer.ResumeAsync();
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
                await CurrentPlayer.PauseAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();

                await CurrentPlayer.StopAsync();

                tbTimeline.Value = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the timer 1 tick event.
        /// </summary>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Tag = 1;
                tbTimeline.Maximum = (int)(await CurrentPlayer.Duration_TimeAsync()).TotalSeconds;

                int value = (int)(await CurrentPlayer.Position_Get_TimeAsync()).TotalSeconds;
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

        /// <summary>
        /// Handles the bt next frame click event.
        /// </summary>
        private void btNextFrame_Click(object sender, EventArgs e)
        {
            CurrentPlayer.NextFrame();
        }

        /// <summary>
        /// Handles the tb speed scroll event.
        /// </summary>
        private async void tbSpeed_Scroll(object sender, EventArgs e)
        {
            try
            {
                await CurrentPlayer.SetSpeedAsync(tbSpeed.Value / 10.0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Init player.
        /// </summary>
        private void InitPlayer(MediaPlayerCore player)
        {
            player.Debug_Mode = cbDebugMode.Checked;
            player.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            player.Source_Mode = MediaPlayerSourceMode.LAV;
            player.Audio_OutputDevice = "Default DirectSound Device";
            player.Info_UseLibMediaInfo = true;

            player.Video_Renderer_SetAuto();
        }

        /// <summary>
        /// Play file async.
        /// </summary>
        private async Task PlayFileAsync(string filename, MediaPlayerCore player)
        {
            player.Playlist_Clear();
            player.Playlist_Add(filename);

            await player.PlayAsync();

            timer1.Start();
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbSourceFiles.Items.Count < 2)
                {
                    MessageBox.Show(this, "You must add 2 or more files to test seamless playback.");
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Media player 1 on stop.
        /// </summary>
        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            BeginInvoke(new StopDelegate1(StopDelegateMethod1), null);
        }

        /// <summary>
        /// Media player 2 on stop.
        /// </summary>
        private void MediaPlayer2_OnStop(object sender, StopEventArgs e)
        {
            BeginInvoke(new StopDelegate2(StopDelegateMethod2), null);
        }

        private delegate void StopDelegate1();

        private delegate void StopDelegate2();

        /// <summary>
        /// Stop delegate method 1.
        /// </summary>
        private async void StopDelegateMethod1()
        {
            try
            {
                VideoView2.Show();
                VideoView1.Hide();

                tbTimeline.Value = 0;

                CurrentPlayer = MediaPlayer2;
                await MediaPlayer2.ResumeAsync();
                if (sourceFiles.Count > 0)
                {
                    await this.PlayFileAsync(sourceFiles[0], MediaPlayer1);
                    sourceFiles.RemoveAt(0);
                    await MediaPlayer1.PauseAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Stop delegate method 2.
        /// </summary>
        private async void StopDelegateMethod2()
        {
            try
            {
                VideoView2.Hide();
                VideoView1.Show();

                tbTimeline.Value = 0;

                CurrentPlayer = MediaPlayer1;
                await MediaPlayer1.ResumeAsync();
                if (sourceFiles.Count > 0)
                {
                    await this.PlayFileAsync(sourceFiles[0], MediaPlayer2);
                    sourceFiles.RemoveAt(0);
                    await MediaPlayer2.PauseAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Form 1 form closed.
        /// </summary>
        private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (MediaPlayer1.State() != PlaybackState.Free)
                {
                    await MediaPlayer1.StopAsync();
                }

                if (MediaPlayer2.State() != PlaybackState.Free)
                {
                    await MediaPlayer2.StopAsync();
                }

                DestroyEngine1();
                DestroyEngine2();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
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
                    await CurrentPlayer.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Link label 1 link clicked.
        /// </summary>
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Media player on error.
        /// </summary>
        private void MediaPlayer_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text += e.Message + Environment.NewLine;
                                   }));
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine1();
            CreateEngine2();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";
        }
    }
}
