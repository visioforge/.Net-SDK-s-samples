using System;
using System.Windows.Forms;

using VisioForge.Core;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Parsers;

using System.Timers;
using System.IO;

using VisioForge.Core.MediaBlocks.Special;

namespace media_player
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private BasicFileSourceBlock _fileSource;

        private ParseBinBlock _demux;

        private H264ParseBlock _parse;

        private DataSampleGrabberBlock _sampleGrabber;

        private NullRendererBlock _nullRenderer;

        private System.Timers.Timer _tmPosition;

        private long _frameCount = 0;

        public Form1()
        {
            InitializeComponent();

            _tmPosition = new System.Timers.Timer(100);
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
            _frameCount = 0;

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
                Invoke(new Action(() =>
                {
                    _tmPosition.Stop();

                    MessageBox.Show("Playback complete.");
                }));
            };

            _pipeline.Debug_Mode = true;
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // Create file source
            _fileSource = new BasicFileSourceBlock(edFilename.Text);

            // Create demux
            _demux = new ParseBinBlock();

            // Add decoder and parser
            _parse = new H264ParseBlock();

            // Add sample grabber
            _sampleGrabber = new DataSampleGrabberBlock(MediaBlockPadMediaType.Video);
            _sampleGrabber.OnDataFrame += (sender2, args) =>
            {
                Invoke(new Action(() =>
                {
                    _frameCount++;
                    lbStatus.Text = $"Received frames: {_frameCount}";
                }));
            };

            // Add null renderer
            _nullRenderer = new NullRendererBlock(MediaBlockPadMediaType.Video);
            _nullRenderer.IsSync = false; // disable sync to play as fast as possible

            // Connect blocks
            _pipeline.Connect(_fileSource, _demux);
            _pipeline.Connect(_demux.GetOutputPadByType(MediaBlockPadMediaType.Video), _parse.Input);
            _pipeline.Connect(_parse, _sampleGrabber);
            _pipeline.Connect(_sampleGrabber, _nullRenderer);

            // Create pipeline and configure elements
            await _pipeline.StartAsync();     

            _tmPosition.Start();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            _tmPosition.Stop();

            await _pipeline.StopAsync();

            await _pipeline.DisposeAsync();
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
