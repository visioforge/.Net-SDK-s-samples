using System;
using System.Windows.Forms;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types;

namespace MediaBlocks_Video_Mixer_Demo
{
    /// <summary>
    /// The main form of the application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The mixer engine.
        /// </summary>
        private IMixerEngine _engine;
                

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form 1 load.
        /// </summary>
        private async void Form1_Load(object sender, System.EventArgs e)
        {
            // We have to initialize the engine on start
            Text += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
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

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void _pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Invoke(new Action(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, System.EventArgs e)
        {
            if (_engine != null)
            {
                await _engine.StopAsync();
                _engine = null;
            }

            videoView1.Invalidate();
        }

        /// <summary>
        /// Handles the bt open file 1 click event.
        /// </summary>
        private void btOpenFile1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFile1.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the bt open file 2 click event.
        /// </summary>
        private void btOpenFile2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFile2.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}