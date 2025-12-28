namespace Karaoke_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioProcessing;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.Special;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.UI;

    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private CDGSourceBlock _cdgSource;

        private VideoRendererBlock _videoRenderer;

        private VideoRendererBlock _secondaryVideoRenderer;

        private TeeBlock _videoTee;

        private AudioRendererBlock _audioRenderer;

        private PitchBlock _pitch;

        private TimeSpan _duration;

        private SecondaryVideoWindow _secondaryWindow;

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

            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            // Initialize and show secondary window
            _secondaryWindow = new SecondaryVideoWindow();
#pragma warning disable S6966 // Awaitable method should be used
            _secondaryWindow.Show();
#pragma warning restore S6966

            // audio output
            foreach (var item in await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound))
            {
                cbAudioOutputDevice.Items.Add(item.DisplayName);
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

        private async void Pipeline_OnStart(object sender, EventArgs e)
        {
            _duration = await _pipeline.DurationAsync();
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
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmError.Clear();
            _duration = TimeSpan.Zero;

            // Create fresh pipeline for each run
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.OnStart += Pipeline_OnStart;
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var audioDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound))
                .FirstOrDefault(x => x.DisplayName == cbAudioOutputDevice.Text);
            _audioRenderer = new AudioRendererBlock(audioDevice);
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            // Add secondary video renderer with tee
            if (_secondaryWindow != null)
            {
                _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                _secondaryVideoRenderer = new VideoRendererBlock(_pipeline, _secondaryWindow.VideoView);
            }

            // Create pitch block for pitch shifting (-12 to +12 semitones)
            _pitch = new PitchBlock(tbPitch.Value);

            _pipeline.Debug_Mode = cbDebugMode.Checked;

            CDGSourceSettings settings;

            if (rbZipMode.Checked)
            {
                // ZIP archive containing CDG and audio files
                var zipFile = edFilename.Text;
                settings = new CDGSourceSettings(zipFile);
            }
            else
            {
                // Separate CDG and audio files
                var cdgFile = edFilename.Text;
                var audioFile = edAudioFilename.Text;
                settings = new CDGSourceSettings(cdgFile, audioFile);
            }

            _cdgSource = new CDGSourceBlock(settings);

            // Connect video with or without tee
            if (_videoTee != null)
            {
                _pipeline.Connect(_cdgSource.VideoOutput, _videoTee.Input);
                _pipeline.Connect(_videoTee.GetFreeOutputPad(), _videoRenderer.Input);
                _pipeline.Connect(_videoTee.GetFreeOutputPad(), _secondaryVideoRenderer.Input);
            }
            else
            {
                _pipeline.Connect(_cdgSource.VideoOutput, _videoRenderer.Input);
            }

            if (_cdgSource.AudioOutput != null)
            {
                _pipeline.Connect(_cdgSource.AudioOutput, _pitch.Input);
                _pipeline.Connect(_pitch.Output, _audioRenderer.Input);
            }

            await _pipeline.StartAsync();

            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume1.Value;
            }

            timer1.Enabled = true;
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await _pipeline.PauseAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (_pipeline != null)
            {
                await _pipeline.StopAsync(true);

                // Dispose all blocks to clean up resources
                _pitch?.Dispose();
                _pitch = null;

                _audioRenderer?.Dispose();
                _audioRenderer = null;

                _videoRenderer?.Dispose();
                _videoRenderer = null;

                _secondaryVideoRenderer?.Dispose();
                _secondaryVideoRenderer = null;

                _videoTee?.Dispose();
                _videoTee = null;

                // Important: Dispose CDGSourceBlock to clean up temp ZIP files
                _cdgSource?.Dispose();
                _cdgSource = null;

                // Dispose and recreate pipeline for clean state
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            tbTimeline.Value = 0;
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume1.Value;
            }
        }

        private void tbPitch_Scroll(object sender, EventArgs e)
        {
            var semitones = tbPitch.Value;
            lbPitch.Text = $"Pitch: {semitones:+#;-#;0}";

            if (_pitch != null)
            {
                _pitch.Semitones = semitones;
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

            var position = await _pipeline.Position_GetAsync();

            if (_duration == TimeSpan.Zero)
            {
                _duration = await _pipeline.DurationAsync();
            }

            tbTimeline.Maximum = (int)(_duration.TotalSeconds);

            if ((position.TotalSeconds > 0) && (position.TotalSeconds < tbTimeline.Maximum))
            {
                tbTimeline.Value = (int)(position.TotalSeconds);
            }

            lbTime.Text = position.ToString("hh\\:mm\\:ss") + " | " + _duration.ToString("hh\\:mm\\:ss");

            timer1.Tag = 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmError.Text = mmError.Text + e.Message + Environment.NewLine;
                                   }));
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       tbTimeline.Value = 0;
                                   }));
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            _secondaryWindow?.Close();
            _secondaryWindow?.Dispose();

            VisioForgeX.DestroySDK();
        }
    }
}
