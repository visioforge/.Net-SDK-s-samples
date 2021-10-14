// ReSharper disable InconsistentNaming

namespace DVD_Player_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Controls.UI;
    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Tools;
    using VisioForge.Tools.MediaInfo;
    using VisioForge.Types;

    public partial class Form1 : Form
    {
        private readonly DVDInfoReader MediaInfo = new DVDInfoReader();

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

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        private void tbBalance1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
        }

        private void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                MediaPlayer1.Position_Set_Time(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.DVD_SetSpeed(tbSpeed.Value / 10.0, false);
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
        }

        private void btNextFrame_Click(object sender, EventArgs e)
        {
            MediaPlayer1.NextFrame();
        }

        private void cbDVDControlTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDVDControlTitle.SelectedIndex != -1)
            {
                // fill info
                cbDVDControlAudio.Items.Clear();
                cbDVDControlSubtitles.Items.Clear();
                cbDVDControlChapter.Items.Clear();

                MediaInfo.DVD_Fill_Title_Info(cbDVDControlTitle.SelectedIndex);

                for (int i = 0; i < MediaInfo.DVD_Title_NumberOfChapters; i++)
                {
                    cbDVDControlChapter.Items.Add("Chapter " + Convert.ToString(i + 1));
                }

                if (cbDVDControlChapter.Items.Count > 0)
                {
                    cbDVDControlChapter.SelectedIndex = 0;
                }

                for (int i = 0; i < MediaInfo.DVD_Title_MainAttributes_NumberOfAudioStreams; i++)
                {
                    MediaInfo.DVD_Fill_Title_Audio_Info(cbDVDControlTitle.SelectedIndex, i);
                    string s = MediaInfo.DVD_Title_MainAttributes_AudioAttributes_AudioFormat;

                    s = s + " - ";
                    s = s + MediaInfo.DVD_Title_MainAttributes_AudioAttributes_NumberOfChannels + "ch" + " - ";
                    s = s + MediaInfo.DVD_Title_MainAttributes_AudioAttributes_LanguageS;

                    cbDVDControlAudio.Items.Add(s);
                }

                if (cbDVDControlAudio.Items.Count > 0)
                {
                    cbDVDControlAudio.SelectedIndex = 0;
                }

                cbDVDControlSubtitles.Items.Add("Disabled");
                for (int i = 0; i < MediaInfo.DVD_Title_MainAttributes_NumberOfSubpictureStreams; i++)
                {
                    MediaInfo.DVD_Fill_Title_Subpicture_Info(cbDVDControlTitle.SelectedIndex, i);
                    cbDVDControlSubtitles.Items.Add(MediaInfo.DVD_Title_MainAttributes_SubpictureAttributes_LanguageS);
                }

                cbDVDControlSubtitles.SelectedIndex = 0;

                // if (nil we just enumerate titles and chapters
                if (sender != null)
                {
                    // play title
                    MediaPlayer1.DVD_Title_Play(cbDVDControlTitle.SelectedIndex);
                    tbTimeline.Maximum = (int)MediaPlayer1.DVD_Title_GetDuration().TotalSeconds;
                }
            }
        }

        private void cbDVDControlAudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDVDControlAudio.SelectedIndex > 0)
            {
                MediaPlayer1.DVD_Select_AudioStream(cbDVDControlAudio.SelectedIndex);
            }
        }

        private void cbDVDControlChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDVDControlChapter.SelectedIndex > 0)
            {
                MediaPlayer1.DVD_Chapter_Select(cbDVDControlChapter.SelectedIndex);
            }
        }

        private void cbDVDControlSubtitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDVDControlSubtitles.SelectedIndex > 0)
            {
                MediaPlayer1.DVD_Select_SubpictureStream(cbDVDControlSubtitles.SelectedIndex - 1);
            }

            // 0 - x - subtitles
            // -1 - disable subtitles
        }

        private void btDVDControlTitleMenu_Click(object sender, EventArgs e)
        {
            MediaPlayer1.DVD_Menu_Show(VFDVDMenu.Title);
        }

        private void btDVDControlRootMenu_Click(object sender, EventArgs e)
        {
            MediaPlayer1.DVD_Menu_Show(VFDVDMenu.Root);
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmError.Clear();

            MediaPlayer1.FilenamesOrURL.Add(edFilename.Text);
            MediaPlayer1.Loop = cbLoop.Checked;
            MediaPlayer1.Audio_PlayAudio = true;

            MediaPlayer1.Source_Mode = VFMediaPlayerSource.DVD_DS;

            // read DVD info
            cbDVDControlTitle.Items.Clear();
            cbDVDControlChapter.Items.Clear();
            cbDVDControlAudio.Items.Clear();
            cbDVDControlSubtitles.Items.Clear();

            MediaInfo.Filename = edFilename.Text;
            MediaInfo.ReadDVDInfo();

            for (int i = 0; i < MediaInfo.DVD_Disc_NumOfTitles; i++)
            {
                cbDVDControlTitle.Items.Add("Title " + (i + 1));
            }

            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            if (FilterHelpers.Filter_Supported_EVR())
            {
                MediaPlayer1.Video_Renderer.Video_Renderer = VFVideoRenderer.EVR;
            }
            else if (FilterHelpers.Filter_Supported_VMR9())
            {
                MediaPlayer1.Video_Renderer.Video_Renderer = VFVideoRenderer.VMR9;
            }
            else
            {
                MediaPlayer1.Video_Renderer.Video_Renderer = VFVideoRenderer.VideoRenderer;
            }

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
            MediaPlayer1.DVD_Menu_Show(VFDVDMenu.Title);

            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            tbTimeline.Maximum = (int)MediaPlayer1.Duration_Time().TotalSeconds;

            int value = (int)MediaPlayer1.Position_Get_Time().TotalSeconds;
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);

            if (cbDVDControlChapter.Items.Count > 0)
            {
                if (MediaPlayer1.DVD_Chapter_GetCurrent() != cbDVDControlChapter.SelectedIndex)
                {
                    cbDVDControlChapter.SelectedIndex = MediaPlayer1.DVD_Chapter_GetCurrent();
                }
            }

            timer1.Tag = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaPlayer1.SDK_Version})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmError.Text = mmError.Text + e.Message + Environment.NewLine;
                                   }));

        }

        private void MediaPlayer1_OnDVDPlaybackError(object sender, DVDEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmError.Text = mmError.Text + e.Message + Environment.NewLine;
                                   }));

        }

        private void MediaPlayer1_OnStop(object sender, MediaPlayerStopEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       tbTimeline.Value = 0;
                                   }));

        }

        private void MediaPlayer1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       if (cbLicensing.Checked)
                                       {
                                           mmError.Text += "(NOT ERROR) LICENSING:" + Environment.NewLine + e.Message + Environment.NewLine;
                                       }
                                   }));

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btStop_Click(null, null);
        }
    }
}

// ReSharper restore InconsistentNaming