namespace MediaBlocks_ARM64_Player_Demo
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.MediaInfoReaderX;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Sources;

    /// <summary>
    /// Plays a file into a live preview from a native ARM64 process.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// Set once the close is under way, so the second FormClosing pass lets the form go.
        /// </summary>
        private bool _isClosing;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btSelectFile control.
        /// </summary>
        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edFilename.Text) || !File.Exists(edFilename.Text))
            {
                MessageBox.Show("Please select a file.");
                return;
            }

            try
            {
                mmError.Clear();

                btStart.Enabled = false;

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;

                // Only the streams the file really has: a missing optional stream is not an error.
                bool videoStream = true;
                bool audioStream = true;

                var mediaInfo = new MediaInfoReaderX(_pipeline.GetContext());
                if (await mediaInfo.OpenAsync(new Uri(edFilename.Text)))
                {
                    videoStream = mediaInfo.Info.VideoStreams.Count > 0;
                    audioStream = mediaInfo.Info.AudioStreams.Count > 0;
                }

                var fileSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(new Uri(edFilename.Text), renderVideo: videoStream, renderAudio: audioStream));

                if (videoStream)
                {
                    var videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
                    _pipeline.Connect(fileSource.VideoOutput, videoRenderer.Input);
                }

                if (audioStream)
                {
                    var audioRenderer = new AudioRendererBlock();
                    _pipeline.Connect(fileSource.AudioOutput, audioRenderer.Input);
                }

                await _pipeline.StartAsync();

                // Stop is usable only once the pipeline runs: before that it would release a half-built one.
                btStop.Enabled = true;
            }
            catch (Exception ex)
            {
                mmError.Text += ex.Message + Environment.NewLine;
                await DisposePipelineAsync();
                btStart.Enabled = true;
                btStop.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            await DisposePipelineAsync();

            btStart.Enabled = true;
            btStop.Enabled = false;
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        private async void Form1_Load(object sender, EventArgs e)
        {
            // A Windows on Arm laptop is often smaller than the design size, and display scaling eats more.
            var area = Screen.FromControl(this).WorkingArea;
            Size = new System.Drawing.Size(Math.Min(Width, area.Width), Math.Min(Height, area.Height));
            CenterToScreen();

            lbArch.Text = $"Process architecture: {RuntimeInformation.ProcessArchitecture}, OS: {RuntimeInformation.OSArchitecture}";

            try
            {
                // First start builds the plugin registry, which takes a few seconds.
                Text += " [BUILDING THE REGISTRY...]";
                Enabled = false;
                await VisioForgeX.InitSDKAsync();
                Enabled = true;
                Text = $"Media Blocks SDK .Net - ARM64 Player Demo (SDK v{MediaBlocksPipeline.SDK_Version})";
            }
            catch (Exception ex)
            {
                mmError.Text += ex.Message + Environment.NewLine;
                Enabled = true;
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the Form1 control: the form waits for the pipeline and the SDK.
        /// </summary>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isClosing)
            {
                return;
            }

            e.Cancel = true;
            _isClosing = true;

            try
            {
                await DisposePipelineAsync();

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                mmError.Text += ex.Message + Environment.NewLine;
            }

            Close();
        }

        /// <summary>
        /// Handles the OnError event of the pipeline.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() => mmError.Text += e.Message + Environment.NewLine));
        }

        /// <summary>
        /// Stops and releases the pipeline; disposing it stops it.
        /// </summary>
        private async Task DisposePipelineAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            _pipeline.OnError -= Pipeline_OnError;
            await _pipeline.DisposeAsync();
            _pipeline = null;
        }
    }
}
