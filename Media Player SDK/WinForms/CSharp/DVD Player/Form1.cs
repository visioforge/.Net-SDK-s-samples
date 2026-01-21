

namespace DVD_Player_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core.MediaInfo;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.UI;

    /// <summary>
    /// DVD player demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The DVD info reader.
        /// </summary>
        private readonly DVDInfoReader MediaInfo = new DVDInfoReader();

        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCore MediaPlayer1;

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
        /// Handles the tb timeline scroll event.
        /// </summary>
        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        /// <summary>
        /// Handles the tb speed scroll event.
        /// </summary>
        private async void tbSpeed_Scroll(object sender, EventArgs e)
        {
            await MediaPlayer1.DVD_SetSpeedAsync(tbSpeed.Value / 10.0, false);
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.PauseAsync();
        }

        /// <summary>
        /// Stop async.
        /// </summary>
        private async Task StopAsync()
        {
            await MediaPlayer1.StopAsync();

            timer1.Enabled = false;

            tbTimeline.Value = 0;
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            await StopAsync();
        }

        /// <summary>
        /// Handles the bt next frame click event.
        /// </summary>
        private void btNextFrame_Click(object sender, EventArgs e)
        {
            MediaPlayer1.NextFrame();
        }

        /// <summary>
        /// Handles the cb dvd control title selected index changed event.
        /// </summary>
        private async void cbDVDControlTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDVDControlTitle.SelectedIndex != -1)
            {
                // fill info
                cbDVDControlAudio.Items.Clear();
                cbDVDControlSubtitles.Items.Clear();
                cbDVDControlChapter.Items.Clear();

                var title = MediaInfo.Info.Titles[cbDVDControlTitle.SelectedIndex];
                for (int i = 0; i < title.NumberOfChapters; i++)
                {
                    cbDVDControlChapter.Items.Add("Chapter " + Convert.ToString(i + 1));
                }

                if (cbDVDControlChapter.Items.Count > 0)
                {
                    cbDVDControlChapter.SelectedIndex = 0;
                }

                for (int i = 0; i < title.MainAttributes.NumberOfAudioStreams; i++)
                {
                    var audioStream = title.MainAttributes.AudioAttributes[i];
                    string s = audioStream.AudioFormat.ToString();

                    s = s + " - ";
                    s = s + audioStream.NumberOfChannels + "ch" + " - ";
                    s = s + audioStream.Language;

                    cbDVDControlAudio.Items.Add(s);
                }

                if (cbDVDControlAudio.Items.Count > 0)
                {
                    cbDVDControlAudio.SelectedIndex = 0;
                }

                cbDVDControlSubtitles.Items.Add("Disabled");
                for (int i = 0; i < title.MainAttributes.NumberOfSubpictureStreams; i++)
                {
                    cbDVDControlSubtitles.Items.Add(title.MainAttributes.SubpictureAttributes[i].Language);
                }

                cbDVDControlSubtitles.SelectedIndex = 0;

                // if (null we just enumerate titles and chapters
                if (sender != null)
                {
                    // play title
                    await MediaPlayer1.DVD_Title_PlayAsync(cbDVDControlTitle.SelectedIndex);
                    tbTimeline.Maximum = (int)((await MediaPlayer1.DVD_Title_GetDurationAsync()).TotalSeconds);
                }
            }
        }

        /// <summary>
        /// Handles the cb dvd control audio selected index changed event.
        /// </summary>
        private async void cbDVDControlAudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDVDControlAudio.SelectedIndex > 0)
            {
                await MediaPlayer1.DVD_Select_AudioStreamAsync(cbDVDControlAudio.SelectedIndex);
            }
        }

        /// <summary>
        /// Handles the cb dvd control chapter selected index changed event.
        /// </summary>
        private async void cbDVDControlChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDVDControlChapter.SelectedIndex > 0)
            {
                await MediaPlayer1.DVD_Chapter_SelectAsync(cbDVDControlChapter.SelectedIndex);
            }
        }

        /// <summary>
        /// Handles the cb dvd control subtitles selected index changed event.
        /// </summary>
        private async void cbDVDControlSubtitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDVDControlSubtitles.SelectedIndex > 0)
            {
                await MediaPlayer1.DVD_Select_SubpictureStreamAsync(cbDVDControlSubtitles.SelectedIndex - 1);
            }

            // 0 - x - subtitles
            // -1 - disable subtitles
        }

        /// <summary>
        /// Handles the bt dvd control title menu click event.
        /// </summary>
        private async void btDVDControlTitleMenu_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.DVD_Menu_ShowAsync(DVDMenu.Title);
        }

        /// <summary>
        /// Handles the bt dvd control root menu click event.
        /// </summary>
        private async void btDVDControlRootMenu_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.DVD_Menu_ShowAsync(DVDMenu.Root);
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            mmError.Clear();

            MediaPlayer1.Playlist_Clear();
            MediaPlayer1.Playlist_Add(edFilename.Text);
            MediaPlayer1.Loop = cbLoop.Checked;
            MediaPlayer1.Audio_PlayAudio = true;

            MediaPlayer1.Source_Mode = MediaPlayerSourceMode.DVD_DS;

            // read DVD info
            cbDVDControlTitle.Items.Clear();
            cbDVDControlChapter.Items.Clear();
            cbDVDControlAudio.Items.Clear();
            cbDVDControlSubtitles.Items.Clear();

            MediaInfo.Filename = edFilename.Text;
            MediaInfo.ReadDVDInfo();

            for (int i = 0; i < MediaInfo.Info.Disc_NumOfTitles; i++)
            {
                cbDVDControlTitle.Items.Add("Title " + (i + 1));
            }

            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            MediaPlayer1.Video_Renderer_SetAuto();

            MediaPlayer1.Debug_Mode = cbDebugMode.Checked;

            await MediaPlayer1.PlayAsync();

            // DVD
            // select and play first title
            if (cbDVDControlTitle.Items.Count > 0)
            {
                cbDVDControlTitle.SelectedIndex = 0;
                cbDVDControlTitle_SelectedIndexChanged(null, null);
            }

            // show title menu
            await MediaPlayer1.DVD_Menu_ShowAsync(DVDMenu.Title);

            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);

            timer1.Enabled = true;
        }

        /// <summary>
        /// Handles the timer 1 tick event.
        /// </summary>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            tbTimeline.Maximum = (int)((await MediaPlayer1.Duration_TimeAsync()).TotalSeconds);

            int value = (int)((await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds);
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);

            if (cbDVDControlChapter.Items.Count > 0)
            {
                if (MediaPlayer1.DVD_Chapter_GetCurrent() != cbDVDControlChapter.SelectedIndex)
                {
                    //cbDVDControlChapter.SelectedIndex =  MediaPlayer1.DVD_Chapter_GetCurrent();
                }
            }

            timer1.Tag = 0;
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnDVDPlaybackError += MediaPlayer1_OnDVDPlaybackError;
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
                MediaPlayer1.OnDVDPlaybackError -= MediaPlayer1_OnDVDPlaybackError;
                MediaPlayer1.OnStop -= MediaPlayer1_OnStop;

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
        /// Media player 1 on error.
        /// </summary>
        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmError.Text = mmError.Text + e.Message + Environment.NewLine;
                                   }));

        }

        /// <summary>
        /// Media player 1 on dvd playback error.
        /// </summary>
        private void MediaPlayer1_OnDVDPlaybackError(object sender, DVDEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmError.Text = mmError.Text + e.Message + Environment.NewLine;
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
        /// Form 1 form closing.
        /// </summary>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            await StopAsync();

            DestroyEngine();
        }
    }
}

