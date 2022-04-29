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
    using VisioForge.Core.MediaInfoGST;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.GST.AudioEffects;
    using VisioForge.Core.Types.GST.AudioEncoders;
    using VisioForge.Core.Types.GST.Sinks;
    using VisioForge.Core.Types.GST.Sources;
    using VisioForge.Core.Types.GST.VideoEffects;
    using VisioForge.Core.Types.GST.VideoEncoders;
    using VisioForge.Core.Types.MediaPlayer.GST;
    using VisioForge.Core.UI;

    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private FileSourceBlock _fileSource;

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _pipeline.OnError += MediaPlayer1_OnError;
            _pipeline.OnStop += MediaPlayer1_OnStop;
        }

        private void DestroyEngine()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= MediaPlayer1_OnError;
                _pipeline.OnStop -= MediaPlayer1_OnStop;

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
            if (Convert.ToInt32(timer1.Tag) == 0)
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

            var mediaInfo = new GSTMediaInfoReader();
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
                _videoRenderer = new VideoRendererBlock(VideoView1, false);
                _pipeline.Connect(_fileSource.VideoOutput, _videoRenderer.Input);
            }

            if (audioStream)
            {
                _audioRenderer = new AudioRendererBlock(false);
                _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
            }

            await _pipeline.StartAsync();

            // set audio volume for each stream
            // _pipeline.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
            // _pipeline.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);

            timer1.Start();
        }

        private void btNextFrame_Click(object sender, EventArgs e)
        {
            _pipeline.NextFrame(1);
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            await _pipeline?.StopAsync();

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

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;

            var position = await _pipeline.Position_GetAsync();
            var duration = await _pipeline.DurationAsync();

            tbTimeline.Maximum = (int)duration.TotalSeconds;

            lbTime.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

            if (tbTimeline.Maximum >= position.TotalSeconds)
            {
                tbTimeline.Value = (int)position.TotalSeconds;
            }

            timer1.Tag = 0;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btStop_Click(null, null);

            DestroyEngine();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx86UI);
            Process.Start(startInfo);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx64UI);
            Process.Start(startInfo);
        }
    }
}

// ReSharper restore InconsistentNaming
