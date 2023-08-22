// ReSharper disable InconsistentNaming

namespace MediaBlocks_Encryptor_Player_Demo
{
    using GstreamerSharp;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.Special;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.UI;

    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private DecodeBinBlock _decodeBin;

        //private DecryptorPlayerBlock _source;

        private MemorySourceBlock _source;

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

            Gst.Plugin.LoadFile(@"c:\Projects\_Projects\MediaFrameworkDotNet\_SOURCE\VisioForge.GstPlugins\x64\Debug\VisioForgeGstPlugins.dll");

            _pipeline.Debug_Mode = cbDebugMode.Checked;

            //var mediaInfo = new MediaInfoGST();
            bool videoStream = true;
            bool audioStream = true;
            //if (await mediaInfo.OpenAsync(new Uri(edFilename.Text)))
            //{
            //    if (mediaInfo.Info.VideoStreams.Count == 0)
            //    {
            //        videoStream = false;
            //    }

            //    if (mediaInfo.Info.AudioStreams.Count == 0)
            //    {
            //        audioStream = false;
            //    }
            //}

            //_source = new DecryptorPlayerBlock(_pipeline, edFilename.Text, edKey.Text, "e9aa8e834d8d70b7e0d254ff670dd718", renderVideo: videoStream, renderAudio: audioStream);

            var data = File.ReadAllBytes(@"c:\samples\!video.avi");
            _source = new MemorySourceBlock(new MemorySourceSettings(data));

            _decodeBin = new DecodeBinBlock();
            _pipeline.Connect(_source.Output, _decodeBin.Input);

            if (videoStream)
            {
                _videoRenderer = new VideoRendererBlock(VideoView1);
                _pipeline.Connect(_decodeBin.VideoOutput, _videoRenderer.Input);
                //_pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
            }

            if (audioStream)
            {
                _audioRenderer = new AudioRendererBlock();
                _pipeline.Connect(_decodeBin.AudioOutput, _audioRenderer.Input);
                //_pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
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

        private void button1_Click(object sender, EventArgs e)
        {
            var pipeline = new MediaBlocksPipeline(true);
            Playback.MainXXX(new string[] { });
        }
    }
}

// ReSharper restore InconsistentNaming
