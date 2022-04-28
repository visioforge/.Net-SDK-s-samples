using System;
using System.Windows.Forms;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.GST.VideoEffects;

namespace MediaBlocks_Video_Mixer_Demo
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private FileSourceBlock _source1;

        private FileSourceBlock _source2;

        private VideoMixerBlock _videoMixer;

        private NullRendererBlock _nullRenderer1;

        private NullRendererBlock _nullRenderer2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
        }

        private async void btStart_Click(object sender, System.EventArgs e)
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;

            _source1 = new FileSourceBlock(edFile1.Text);
            _source2 = new FileSourceBlock(edFile2.Text) { Name = "Source2" };

            _videoRenderer = new VideoRendererBlock(videoView1, false);

            var mixerSettings = new GSTVideoMixerSettings();
            mixerSettings.AddStream(Convert.ToInt32(edX1.Text), Convert.ToInt32(edY1.Text), Convert.ToInt32(edWidth1.Text), Convert.ToInt32(edHeight1.Text));
            mixerSettings.AddStream(Convert.ToInt32(edX2.Text), Convert.ToInt32(edY2.Text), Convert.ToInt32(edWidth2.Text), Convert.ToInt32(edHeight2.Text));

            _videoMixer = new VideoMixerBlock(mixerSettings);

            _pipeline.Connect(_source1.VideoOutput, _videoMixer.Inputs[0]);
            _pipeline.Connect(_source2.VideoOutput, _videoMixer.Inputs[1]);

            _pipeline.Connect(_videoMixer.Output, _videoRenderer.Input);

            _nullRenderer1 = new NullRendererBlock();
            _nullRenderer2 = new NullRendererBlock();
            _pipeline.Connect(_source1.AudioOutput, _nullRenderer1.Input);
            _pipeline.Connect(_source2.AudioOutput, _nullRenderer2.Input);

            await _pipeline.StartAsync();
        }

        private void _pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Invoke(new Action(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            }));
        }

        private async void btStop_Click(object sender, System.EventArgs e)
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }

            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;
                _pipeline.Dispose();
                _pipeline = null;
            }

            videoView1.Invalidate();
        }

        private void btOpenFile1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFile1.Text = openFileDialog1.FileName;
            }
        }

        private void btOpenFile2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFile2.Text = openFileDialog1.FileName;
            }
        }
    }
}