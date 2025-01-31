using System;
using System.Windows.Forms;

using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using System.Linq;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Parsers;
using VisioForge.Core.MediaBlocks.VideoDecoders;
using VisioForge.Core.Types.X.VideoDecoders;
using System.Threading;
using System.Timers;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace media_player
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private PushSourceBlock _source;

        private H264DecoderBlock _decoder;

        private H264ParseBlock _parse;

        private VideoRendererBlock _renderer;

        private Thread _pushThread;

        private System.Timers.Timer _tmPosition;

        private const int CHUNK_SIZE = 4096;

        private volatile bool _stopFlag;

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
            _pipeline.OnStop += (sender2, args) =>
            {
                _stopFlag = true;
            };

            // Add source
            var sourceSettings = new PushDataSourceSettings();
            var caps = new Gst.Caps("video/x-h264");
            caps.SetValue("stream-format", new GLib.Value("byte-stream"));
            sourceSettings.Caps = caps;
            sourceSettings.PushFormat = PushSourceFormat.Time;
            sourceSettings.IsLive = true;
            sourceSettings.PadMediaType = MediaBlockPadMediaType.Video;
            sourceSettings.BlockPushData = true;

            _source = new PushSourceBlock(sourceSettings);

            // Add decoder and parser
            _decoder = new H264DecoderBlock(new FFMPEGH264DecoderSettings());
            _parse = new H264ParseBlock();

            // Add video renderer
            _renderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = true };

            // Connect blocks
            _pipeline.Connect(_source, _parse);
            _pipeline.Connect(_parse, _decoder);
            _pipeline.Connect(_decoder, _renderer);

            _stopFlag = false;

            // Create pipeline and configure elements
            await _pipeline.StartAsync(onlyPreload: true);

            // Push data loop
            _pushThread = new Thread(async () =>
            {
                Stream stream = null;
                HttpClient httpClient = null;
                HttpResponseMessage response = null;

                if (httpSource)
                {
                    httpClient = new HttpClient();
                    response = await httpClient.GetAsync(edFilename.Text, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();

                    stream = await response.Content.ReadAsStreamAsync();
                }
                else
                {
                    stream = System.IO.File.OpenRead(edFilename.Text);
                }

                var buffer = new byte[CHUNK_SIZE];
                int len = 0;
                while ((len = stream.Read(buffer, 0, CHUNK_SIZE)) > 0 && !_stopFlag)
                {
                    _source.PushData(buffer, len);
                }

                stream.Close();

                response?.Dispose();
                httpClient?.Dispose();

                _source.SendEOS();
            });

            _pushThread.Start();

            // Start playback
            await _pipeline.ResumeAsync();

            _tmPosition.Start();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            _stopFlag = true;

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
            // We have to initialize the engine on start
            Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
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
