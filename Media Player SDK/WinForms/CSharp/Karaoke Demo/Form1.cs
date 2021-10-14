namespace Karaoke_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Controls.MediaPlayer;
    using VisioForge.Controls.UI;
    using VisioForge.MediaFramework.CDG;
    using VisioForge.Types;

    public partial class Form1 : Form
    {
        private MediaPlayerCore MediaPlayer1;

        private CDGFile cdg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MediaPlayer1 = new MediaPlayerCore();
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnLicenseRequired += MediaPlayer1_OnLicenseRequired;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;

            Text += $" (SDK v{MediaPlayer1.SDK_Version})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;

                if (cdg != null)
                {
                    cdg.Dispose();
                    cdg = null;
                }

                var cdgFile = Path.Combine(Path.GetDirectoryName(edFilename.Text), Path.GetFileNameWithoutExtension(edFilename.Text)) + ".cdg";
                if (File.Exists(cdgFile))
                {
                    cdg = new CDGFile(cdgFile);
                }
            }
        }

        private void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                MediaPlayer1.Position_Set_Time(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmError.Clear();

            MediaPlayer1.FilenamesOrURL.Add(edFilename.Text);
            MediaPlayer1.Audio_PlayAudio = true;

            MediaPlayer1.Source_Mode = VFMediaPlayerSource.File_DS;
            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            MediaPlayer1.Video_Renderer.VideoRendererInternal = VFVideoRendererInternal.None;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            tbTimeline.Maximum = (int)MediaPlayer1.Duration_Time().TotalSeconds;

            if ((MediaPlayer1.Position_Get_Time().TotalSeconds > 0) && (MediaPlayer1.Position_Get_Time().TotalSeconds < tbTimeline.Maximum))
            {
                tbTimeline.Value = (int)MediaPlayer1.Position_Get_Time().TotalSeconds;
            }

            lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);

            if (cdg != null)
            {
                if (cdg.renderAtPosition((long)MediaPlayer1.Position_Get_Time().TotalMilliseconds))
                {
                    imgScreen.Image = cdg.RGBImage();
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
