

namespace Video_Player_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.AudioEffects;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.UI;

    /// <summary>
    /// Simple video player demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCore MediaPlayer1;

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
        /// Destroy engine.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
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
        /// Handles the tb speed scroll event.
        /// </summary>
        private async void tbSpeed_Scroll(object sender, EventArgs e)
        {
            try
            {
                await MediaPlayer1.SetSpeedAsync(tbSpeed.Value / 10.0);
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
            MediaPlayer1.NextFrame();
        }

        /// <summary>
        /// Stop async.
        /// </summary>
        private async Task StopAsync()
        {
            timer1.Stop();

            await MediaPlayer1.StopAsync();

            tbTimeline.Value = 0;
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
        /// Handles the form 1 load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            cbSourceMode.SelectedIndex = 0;
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
        /// Media player 1 on stop.
        /// </summary>
        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       tbTimeline.Value = 0;
                                   }));
        }

        /// <summary>
        /// Handles the bt previous frame click event.
        /// </summary>
        private void btPreviousFrame_Click(object sender, EventArgs e)
        {
            MediaPlayer1.PreviousFrame();
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
    }
}


