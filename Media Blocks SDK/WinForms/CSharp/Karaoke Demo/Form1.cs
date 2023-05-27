namespace Karaoke_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.UI;
    using static Sentry.MeasurementUnit;

    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private CDGSourceBlock _cdgSource;

        private VideoRendererBlock _videoRenderer;

        private TimeSpan _duration;

        // private AudioRendererBlock _audioRenderer;

        private DeviceEnumerator _deviceEnumerator;

        public Form1()
        {
            InitializeComponent();

            _deviceEnumerator = new DeviceEnumerator();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _pipeline = new MediaBlocksPipeline(false);
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.OnStart += Pipeline_OnStart;

            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // audio output
            foreach (var item in await _deviceEnumerator.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound))
            {
                cbAudioOutputDevice.Items.Add(item.DisplayName);
            }

            if (cbAudioOutputDevice.Items.Count > 0)
            {
                cbAudioOutputDevice.SelectedIndex = 0;
            }
        }

        private async void Pipeline_OnStart(object sender, EventArgs e)
        {
            _duration = await _pipeline.DurationAsync();
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
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmError.Clear();
            _duration = TimeSpan.Zero;

            //_audioRenderer = new AudioRendererBlock(
            //    (await DeviceEnumerator.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).First(x => x.Name == cbAudioOutputDevice.Text));
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            _pipeline.Debug_Mode = cbDebugMode.Checked;

            var mp3File = edFilename.Text;
            var cdgFile = Path.Combine(Path.GetDirectoryName(mp3File), Path.GetFileNameWithoutExtension(mp3File) + ".cdg");
            _cdgSource = new CDGSourceBlock(new CDGSourceSettings(cdgFile, null));

            _pipeline.Connect(_cdgSource.VideoOutput, _videoRenderer.Input);
            //_pipeline.Connect(_cdgSource.AudioOutput, _audioRenderer.Input);

            await _pipeline.StartAsync();

            //_audioRenderer.Volume = tbVolume1.Value;

            timer1.Enabled = true;
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(25));
            //await _pipeline.PauseAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await _pipeline.StopAsync();
            timer1.Enabled = false;
            tbTimeline.Value = 0;
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            //if (_audioRenderer != null)
            //{
            //    _audioRenderer.Volume = tbVolume1.Value;
            //}
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

            _deviceEnumerator.Dispose();
        }
    }
}
