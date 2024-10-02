using System;
using System.Windows.Forms;

using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.Sources;

using System.Threading;
using System.Timers;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using VisioForge.Core.MediaBlocks.Special;

namespace media_player
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private StreamSourceBlock _source;

        private Stream _stream;

        private DecodeBinBlock _decoder;

        private VideoRendererBlock _videoRenderer;

        private System.Timers.Timer _tmPosition;

        public Form1()
        {
            InitializeComponent();

            _tmPosition = new System.Timers.Timer(1000);
            _tmPosition.Elapsed += _tmPosition_Elapsed;
        }

        private void _tmPosition_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(async () =>
            {
                if (_pipeline != null)
                {
                    var pos = await _pipeline.Position_GetAsync();
                    lbTimestamp.Text = pos.ToString(@"hh\:mm\:ss");
                }
            }));
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edFilename.Text))
            {
                MessageBox.Show("Please select an H264 file.");
                return;
            }

            var filename = edFilename.Text;
            var httpSource = filename.Contains("http://") || filename.Contains("https://");

            // Create MediaBlocks pipeline
            _pipeline = new MediaBlocksPipeline();

            // Add source
            _stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            _source = new StreamSourceBlock(_stream);

            // Add decoder and parser
            _decoder = new DecodeBinBlock(renderAudio: false);

            // Add video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = true };

            // Connect blocks
            _pipeline.Connect(_source.Output, _decoder.Input);
            _pipeline.Connect(_decoder.VideoOutput, _videoRenderer.Input);

            // Create pipeline and configure elements
            await _pipeline.StartAsync(onlyPreload: true);

            // Start playback
            await _pipeline.ResumeAsync();

            _tmPosition.Start();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            //_stopFlag = true;

            _tmPosition.Stop();

            await _pipeline.StopAsync();

            await _pipeline.DisposeAsync();
        }

        private async Task<Stream> OpenHTTPStreamAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            using (HttpResponseMessage response = await httpClient.GetAsync(edFilename.Text, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStreamAsync();
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await VisioForgeX.InitSDKAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
            }
        }
    }
}
