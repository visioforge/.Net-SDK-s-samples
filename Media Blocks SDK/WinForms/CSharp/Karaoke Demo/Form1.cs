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

        private AudioRendererBlock _audioRenderer;

        private PitchBlock _pitch;

        private TimeSpan _duration;

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
            openFileDialog1.Filter = "Karaoke files|*.mp3;*.cdg;*.zip|CDG files|*.cdg|MP3 files|*.mp3|ZIP archives|*.zip|All files|*.*";
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

            // Create pitch block for pitch shifting (-12 to +12 semitones)
            _pitch = new PitchBlock(tbPitch.Value);

            _pipeline.Debug_Mode = cbDebugMode.Checked;

            var filename = edFilename.Text;
            CDGSourceSettings settings;

            // Check if it's a ZIP file
            if (filename.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
            {
                // ZIP archive containing CDG and MP3 files
                settings = new CDGSourceSettings(filename);
            }
            else if (filename.EndsWith(".cdg", StringComparison.OrdinalIgnoreCase))
            {
                // CDG file selected - look for matching audio file
                var cdgFile = filename;
                var mp3File = Path.Combine(Path.GetDirectoryName(cdgFile), Path.GetFileNameWithoutExtension(cdgFile) + ".mp3");
                settings = new CDGSourceSettings(cdgFile, File.Exists(mp3File) ? mp3File : null);
            }
            else
            {
                // Traditional MP3 file with accompanying CDG file
                var mp3File = filename;
                var cdgFile = Path.Combine(Path.GetDirectoryName(mp3File), Path.GetFileNameWithoutExtension(mp3File) + ".cdg");
                settings = new CDGSourceSettings(cdgFile, mp3File);
            }

            _cdgSource = new CDGSourceBlock(settings);

            _pipeline.Connect(_cdgSource.VideoOutput, _videoRenderer.Input);

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

            VisioForgeX.DestroySDK();
        }
    }
}
