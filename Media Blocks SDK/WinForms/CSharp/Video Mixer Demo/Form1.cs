using System;
using System.Windows.Forms;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types;

namespace MediaBlocks_Video_Mixer_Demo
{
    public partial class Form1 : Form
    {
        private IMixerEngine _engine;
                

        public Form1()
        {
            InitializeComponent();

            // We have to initialize the engine on start
            VisioForgeX.InitSDK();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
        }

        private async void btStart_Click(object sender, System.EventArgs e)
        {
            if (rbCPU.Checked)
            {
                _engine = new CPUMixerEngine();
            }
            else
            {
                _engine = new D3D11MixerEngine();
            }

            _engine.AddStream(new Rect(Convert.ToInt32(edX1.Text), Convert.ToInt32(edY1.Text), Convert.ToInt32(edWidth1.Text), Convert.ToInt32(edHeight1.Text)), 0);
            _engine.AddStream(new Rect(Convert.ToInt32(edX2.Text), Convert.ToInt32(edY2.Text), Convert.ToInt32(edWidth2.Text), Convert.ToInt32(edHeight2.Text)), 1);

            await _engine.StartAsync(edFile1.Text, edFile2.Text, videoView1);
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
            if (_engine != null)
            {
                await _engine.StopAsync();
                _engine = null;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}