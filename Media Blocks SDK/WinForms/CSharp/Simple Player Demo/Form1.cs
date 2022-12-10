// ReSharper disable InconsistentNaming

namespace MediaBlocks_Player_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioEncoders;
    using VisioForge.Core.MediaBlocks.AudioProcessing;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sinks;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.VideoEncoders;
    using VisioForge.Core.MediaBlocks.VideoProcessing;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.MediaInfoReaderX;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.AudioEffects;
    using VisioForge.Core.Types.X.AudioEncoders;
    using VisioForge.Core.Types.X.Sinks;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.Types.X.VideoEffects;
    using VisioForge.Core.Types.X.VideoEncoders;
    using VisioForge.Core.Types.X.MediaPlayer;
    using VisioForge.Core.UI;

    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private FileSourceBlock _fileSource;

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline(false);
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
        }

        private void DestroyEngine()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;

                _pipeline.Dispose();
                _pipeline = null;
            }
        }

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

        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(_tmPosition.Tag) == 0)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void tbSpeed_Scroll(object sender, EventArgs e)
        {
            await _pipeline.Rate_SetAsync(tbSpeed.Value / 10.0);
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmError.Clear();

            CreateEngine();

            _pipeline.Debug_Mode = cbDebugMode.Checked;

            var mediaInfo = new MediaInfoReaderX();
            bool videoStream = true;
            bool audioStream = true;
            if (await mediaInfo.OpenAsync(new Uri(edFilename.Text)))
            {
                if (mediaInfo.Info.VideoStreams.Count == 0)
                {
                    videoStream = false;
                }

                if (mediaInfo.Info.AudioStreams.Count == 0)
                {
                    audioStream = false;
                }
            }

            _fileSource = new FileSourceBlock(edFilename.Text, renderVideo: videoStream, renderAudio: audioStream);

            if (videoStream)
            {
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
                _pipeline.Connect(_fileSource.VideoOutput, _videoRenderer.Input);
            }

            if (audioStream)
            {
                _audioRenderer = new AudioRendererBlock();
                _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
            }

            _pipeline.Loop = cbLoop.Checked;

            await _pipeline.StartAsync();

            // set audio volume for each stream
            // _pipeline.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
            // _pipeline.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);

            _tmPosition.Start();
        }

        private void btNextFrame_Click(object sender, EventArgs e)
        {
            _pipeline.NextFrame(1);
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            _tmPosition.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }

            tbTimeline.Value = 0;

            VideoView1.Invalidate();

            DestroyEngine();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await _pipeline.PauseAsync();
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            _audioRenderer.Volume = tbVolume1.Value / 100.0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
        }

        private async void tmPosition_Tick(object sender, EventArgs e)
        {
            _tmPosition.Tag = 1;

            var position = await _pipeline.Position_GetAsync();
            var duration = await _pipeline.DurationAsync();

            tbTimeline.Maximum = (int)duration.TotalSeconds;

            lbTime.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

            if (tbTimeline.Maximum >= position.TotalSeconds)
            {
                tbTimeline.Value = (int)position.TotalSeconds;
            }

            _tmPosition.Tag = 0;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btStop_Click(null, null);

            DestroyEngine();
        }
    }
}

// ReSharper restore InconsistentNaming
