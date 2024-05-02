namespace Karaoke_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using VisioForge.Core;
    using VisioForge.Core.MediaPlayerX;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.AudioRenderers;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.UI;

    public partial class Form1 : Form
    {
        private MediaPlayerCoreX MediaPlayer1;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            MediaPlayer1 = new MediaPlayerCoreX(VideoView1);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;

            Text += $" (SDK v{MediaPlayerCoreX.SDK_Version})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // audio output
            foreach (var item in await MediaPlayer1.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound))
            {
                cbAudioOutputDevice.Items.Add(item.Name);
            }

            if (cbAudioOutputDevice.Items.Count > 0)
            {
                cbAudioOutputDevice.SelectedIndex = 0;
            }
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
            }
        }

        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                await MediaPlayer1.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmError.Clear();

            MediaPlayer1.Audio_Play = true;
            var audioOutputDevice = (await MediaPlayer1.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound)).First(x => x.Name == cbAudioOutputDevice.Text);
            MediaPlayer1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

            MediaPlayer1.Debug_Mode = cbDebugMode.Checked;

            var mp3File = edFilename.Text;
            var cdgFile = Path.Combine(Path.GetDirectoryName(mp3File), Path.GetFileNameWithoutExtension(mp3File) + ".cdg");
            await MediaPlayer1.OpenAsync(new CDGSourceSettings(cdgFile, mp3File));

            await MediaPlayer1.PlayAsync();

            MediaPlayer1.Audio_OutputDevice_Volume = tbVolume1.Value;

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
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume = tbVolume1.Value;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;

            var position = await MediaPlayer1.Position_GetAsync();
            var duration = await MediaPlayer1.DurationAsync();

            tbTimeline.Maximum = (int)(duration.TotalSeconds);

            if ((position.TotalSeconds > 0) && (position.TotalSeconds < tbTimeline.Maximum))
            {
                tbTimeline.Value = (int)(position.TotalSeconds);
            }

            lbTime.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

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

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;

            await MediaPlayer1.StopAsync();

            await MediaPlayer1.DisposeAsync();

            VisioForgeX.DestroySDK();
        }
    }
}
