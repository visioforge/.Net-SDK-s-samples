namespace Karaoke_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.MediaPlayerX;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.AudioRenderers;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.UI;

    public partial class Form1 : Form
    {
        private MediaPlayerCoreX MediaPlayer1;

        private CDGSourceSettings _currentSettings;

        private SecondaryVideoWindow _secondaryWindow;
        private VideoRendererBlock _secondaryRenderer;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // We have to initialize the engine on start
            Text += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            MediaPlayer1 = new MediaPlayerCoreX(VideoView1);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;

            Text += $" (SDK v{MediaPlayerCoreX.SDK_Version})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // Initialize and show secondary window
            _secondaryWindow = new SecondaryVideoWindow();
#pragma warning disable S6966 // Awaitable method should be used
            _secondaryWindow.Show();
#pragma warning restore S6966

            // audio output
            foreach (var item in await MediaPlayer1.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound))
            {
                cbAudioOutputDevice.Items.Add(item.Name);
            }

            if (cbAudioOutputDevice.Items.Count > 0)
            {
                cbAudioOutputDevice.SelectedIndex = 0;
            }

            // Initialize pitch trackbar (range: -12 to +12 semitones)
            tbPitch.Minimum = -12;
            tbPitch.Maximum = 12;
            tbPitch.Value = 0;
            lbPitch.Text = "Pitch: 0";
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (rbZipMode.Checked)
            {
                openFileDialog1.Filter = "ZIP archives|*.zip|All files|*.*";
            }
            else
            {
                openFileDialog1.Filter = "CDG files|*.cdg|All files|*.*";
            }
            
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

            // Add secondary video output if window should be visible
            if (_secondaryWindow != null)
            {
                // Create a secondary video renderer for the second window
                _secondaryRenderer = new VideoRendererBlock(null, _secondaryWindow.VideoView);
                MediaPlayer1.Custom_Video_Outputs.Clear();
                MediaPlayer1.Custom_Video_Outputs.Add(_secondaryRenderer);
            }

            if (rbZipMode.Checked)
            {
                // ZIP archive containing CDG and audio files
                var zipFile = edFilename.Text;
                _currentSettings = new CDGSourceSettings(zipFile);
            }
            else
            {
                // Separate CDG and audio files
                var cdgFile = edFilename.Text;
                var audioFile = edAudioFilename.Text;
                _currentSettings = new CDGSourceSettings(cdgFile, audioFile);
            }

            // Set pitch from trackbar (semitones) and enable runtime pitch control
            _currentSettings.EnablePitchShifting = true;
            _currentSettings.PitchSemitones = tbPitch.Value;

            await MediaPlayer1.OpenAsync(_currentSettings);
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

            _currentSettings = null;

            // Clean up secondary renderer
            if (_secondaryRenderer != null)
            {
                MediaPlayer1.Custom_Video_Outputs.Clear();
                _secondaryRenderer = null;
            }

            timer1.Enabled = false;
            tbTimeline.Value = 0;
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume = tbVolume1.Value;
        }

        private void tbPitch_Scroll(object sender, EventArgs e)
        {
            var semitones = tbPitch.Value;
            lbPitch.Text = $"Pitch: {semitones:+#;-#;0}";

            // Change pitch during playback - just set the property on settings
            if (_currentSettings != null)
            {
                _currentSettings.PitchSemitones = semitones;
            }
        }

        private void rbInputMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbZipMode.Checked)
            {
                // ZIP mode - disable audio file input
                label1.Text = "ZIP File:";
                edAudioFilename.Enabled = false;
                btSelectAudioFile.Enabled = false;
                label2.Enabled = false;
                edFilename.Text = "c:\\1.zip";
            }
            else
            {
                // Separate files mode - enable audio file input
                label1.Text = "CDG File:";
                edAudioFilename.Enabled = true;
                btSelectAudioFile.Enabled = true;
                label2.Enabled = true;
                edFilename.Text = "c:\\1.cdg";
                edAudioFilename.Text = "c:\\1.mp3";
            }
        }

        private void btSelectAudioFile_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Audio files|*.mp3;*.wav;*.ogg;*.flac;*.m4a;*.aac|MP3 files|*.mp3|WAV files|*.wav|All files|*.*";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                edAudioFilename.Text = openFileDialog2.FileName;
            }
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

            _secondaryWindow?.Close();
            _secondaryWindow?.Dispose();

            VisioForgeX.DestroySDK();
        }
    }
}
