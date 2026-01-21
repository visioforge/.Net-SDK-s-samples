using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.OpenGL;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.OpenGL;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.WinForms;

namespace GaussianBlurDemo
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;
        private GLShaderBlock _blurShaderH;
        private GLShaderBlock _blurShaderV;
        private UniversalSourceBlock _fileSource;
        private VideoRendererBlock _videoRenderer;
        private AudioRendererBlock _audioRenderer;
        private Timer _positionTimer;
        private int _blurMode = 0; // 0=Standard, 1=HQ, 2=Simple
        private float _blurRadius = 1.0f;
        private float _videoWidth = 1920.0f;
        private System.ComponentModel.IContainer components;
        private float _videoHeight = 1080.0f;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize component.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            VideoView1 = new VideoView();
            pnVideo = new Panel();
            btnSelectFile = new Button();
            edFilename = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            btnPause = new Button();
            btnResume = new Button();
            tbBlurRadius = new TrackBar();
            lbBlurRadius = new Label();
            cbBlurMode = new ComboBox();
            lbBlurMode = new Label();
            lbPosition = new Label();
            tbTimeline = new TrackBar();
            mmError = new TextBox();
            _positionTimer = new Timer(components);
            pnVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbBlurRadius).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).BeginInit();
            SuspendLayout();
            // 
            // VideoView1
            // 
            VideoView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VideoView1.BackColor = System.Drawing.Color.Black;
            VideoView1.Location = new System.Drawing.Point(0, 0);
            VideoView1.Name = "VideoView1";
            VideoView1.Size = new System.Drawing.Size(640, 480);
            VideoView1.TabIndex = 0;
            // 
            // pnVideo
            // 
            pnVideo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnVideo.BackColor = System.Drawing.Color.Black;
            pnVideo.Controls.Add(VideoView1);
            pnVideo.Location = new System.Drawing.Point(12, 12);
            pnVideo.Name = "pnVideo";
            pnVideo.Size = new System.Drawing.Size(640, 480);
            pnVideo.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelectFile.Location = new System.Drawing.Point(470, 498);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new System.Drawing.Size(90, 33);
            btnSelectFile.TabIndex = 2;
            btnSelectFile.Text = "Select File";
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // edFilename
            // 
            edFilename.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            edFilename.Location = new System.Drawing.Point(12, 500);
            edFilename.Name = "edFilename";
            edFilename.Size = new System.Drawing.Size(450, 31);
            edFilename.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStart.Location = new System.Drawing.Point(12, 530);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(75, 38);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStop.Location = new System.Drawing.Point(93, 530);
            btnStop.Name = "btnStop";
            btnStop.Size = new System.Drawing.Size(75, 38);
            btnStop.TabIndex = 4;
            btnStop.Text = "Stop";
            btnStop.Click += btnStop_Click;
            // 
            // btnPause
            // 
            btnPause.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPause.Location = new System.Drawing.Point(174, 530);
            btnPause.Name = "btnPause";
            btnPause.Size = new System.Drawing.Size(75, 38);
            btnPause.TabIndex = 5;
            btnPause.Text = "Pause";
            btnPause.Click += btnPause_Click;
            // 
            // btnResume
            // 
            btnResume.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnResume.Location = new System.Drawing.Point(255, 530);
            btnResume.Name = "btnResume";
            btnResume.Size = new System.Drawing.Size(92, 38);
            btnResume.TabIndex = 6;
            btnResume.Text = "Resume";
            btnResume.Click += btnResume_Click;
            // 
            // tbBlurRadius
            // 
            tbBlurRadius.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbBlurRadius.Location = new System.Drawing.Point(670, 100);
            tbBlurRadius.Maximum = 100;
            tbBlurRadius.Name = "tbBlurRadius";
            tbBlurRadius.Size = new System.Drawing.Size(200, 69);
            tbBlurRadius.TabIndex = 10;
            tbBlurRadius.TickFrequency = 10;
            tbBlurRadius.Value = 10;
            tbBlurRadius.Scroll += tbBlurRadius_Scroll;
            // 
            // lbBlurRadius
            // 
            lbBlurRadius.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbBlurRadius.Location = new System.Drawing.Point(670, 80);
            lbBlurRadius.Name = "lbBlurRadius";
            lbBlurRadius.Size = new System.Drawing.Size(200, 20);
            lbBlurRadius.TabIndex = 9;
            lbBlurRadius.Text = "Blur Radius: 1.0";
            // 
            // cbBlurMode
            // 
            cbBlurMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbBlurMode.Items.AddRange(new object[] { "Two-Pass (Standard)", "Two-Pass (High Quality)", "Single-Pass (Simple)" });
            cbBlurMode.Location = new System.Drawing.Point(670, 40);
            cbBlurMode.Name = "cbBlurMode";
            cbBlurMode.Size = new System.Drawing.Size(200, 33);
            cbBlurMode.TabIndex = 8;
            cbBlurMode.SelectedIndexChanged += cbBlurMode_SelectedIndexChanged;
            // 
            // lbBlurMode
            // 
            lbBlurMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbBlurMode.Location = new System.Drawing.Point(670, 20);
            lbBlurMode.Name = "lbBlurMode";
            lbBlurMode.Size = new System.Drawing.Size(100, 20);
            lbBlurMode.TabIndex = 7;
            lbBlurMode.Text = "Blur Mode:";
            // 
            // lbPosition
            // 
            lbPosition.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbPosition.Location = new System.Drawing.Point(12, 572);
            lbPosition.Name = "lbPosition";
            lbPosition.Size = new System.Drawing.Size(200, 20);
            lbPosition.TabIndex = 11;
            lbPosition.Text = "Position: 00:00:00 / 00:00:00";
            // 
            // tbTimeline
            // 
            tbTimeline.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tbTimeline.Location = new System.Drawing.Point(12, 605);
            tbTimeline.Maximum = 100;
            tbTimeline.Name = "tbTimeline";
            tbTimeline.Size = new System.Drawing.Size(640, 69);
            tbTimeline.TabIndex = 12;
            tbTimeline.TickFrequency = 10;
            tbTimeline.Scroll += tbTimeline_Scroll;
            // 
            // mmError
            // 
            mmError.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mmError.Location = new System.Drawing.Point(670, 200);
            mmError.Multiline = true;
            mmError.Name = "mmError";
            mmError.ScrollBars = ScrollBars.Vertical;
            mmError.Size = new System.Drawing.Size(200, 300);
            mmError.TabIndex = 7;
            // 
            // _positionTimer
            // 
            _positionTimer.Interval = 500;
            _positionTimer.Tick += tmPosition_Tick;
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(2224, 1121);
            Controls.Add(pnVideo);
            Controls.Add(edFilename);
            Controls.Add(btnSelectFile);
            Controls.Add(btnStart);
            Controls.Add(btnStop);
            Controls.Add(btnPause);
            Controls.Add(btnResume);
            Controls.Add(lbBlurMode);
            Controls.Add(cbBlurMode);
            Controls.Add(lbBlurRadius);
            Controls.Add(tbBlurRadius);
            Controls.Add(lbPosition);
            Controls.Add(tbTimeline);
            Controls.Add(mmError);
            Name = "Form1";
            Text = "Gaussian Blur Shader Demo - MediaBlocks SDK";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            pnVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tbBlurRadius).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbTimeline).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private VisioForge.Core.UI.WinForms.VideoView VideoView1;
        private Panel pnVideo;
        private Button btnSelectFile;
        private TextBox edFilename;
        private Button btnStart;
        private Button btnStop;
        private Button btnPause;
        private Button btnResume;
        private TrackBar tbBlurRadius;
        private Label lbBlurRadius;
        private ComboBox cbBlurMode;
        private Label lbBlurMode;
        private Label lbPosition;
        private TrackBar tbTimeline;
        private TextBox mmError;

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private async void Form1_Load(object sender, EventArgs e)
        {
            Text += " [INITIALIZING SDK...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace(" [INITIALIZING SDK...]", "");
            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
        }

        /// <summary>
        /// Handles the btn select file click event.
        /// </summary>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Video Files|*.mp4;*.avi;*.wmv;*.mov;*.mkv|All Files|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    edFilename.Text = dialog.FileName;
                }
            }
        }

        /// <summary>
        /// Handles the btn start click event.
        /// </summary>
        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edFilename.Text))
            {
                MessageBox.Show("Please select a video file first.");
                return;
            }

            if (!File.Exists(edFilename.Text))
            {
                MessageBox.Show("Selected file does not exist.");
                return;
            }

            mmError.Clear();

            CreateEngine();

            try
            {
                // Get media info to check streams
                var mediaInfo = new MediaInfoReaderX(_pipeline.GetContext());
                bool hasVideo = true;
                bool hasAudio = true;
                
                if (await mediaInfo.OpenAsync(new Uri(edFilename.Text)))
                {
                    if (mediaInfo.Info.VideoStreams.Count == 0)
                    {
                        hasVideo = false;
                    }
                    else
                    {
                        var videoStream = mediaInfo.Info.VideoStreams[0];
                        _videoWidth = (float)videoStream.Width;
                        _videoHeight = (float)videoStream.Height;
                    }

                    if (mediaInfo.Info.AudioStreams.Count == 0)
                    {
                        hasAudio = false;
                    }
                }

                // Create source
                _fileSource = new UniversalSourceBlock(
                    await UniversalSourceSettings.CreateAsync(
                        new Uri(edFilename.Text), 
                        renderVideo: hasVideo, 
                        renderAudio: hasAudio));

                if (hasVideo)
                {
                    _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                    switch (_blurMode)
                    {
                        case 2: // Simple single-pass
                            SetupSinglePassBlur();
                            break;
                        case 1: // High quality two-pass
                            SetupTwoPassBlur(true);
                            break;
                        default: // Standard two-pass
                            SetupTwoPassBlur(false);
                            break;
                    }
                }

                if (hasAudio)
                {
                    _audioRenderer = new AudioRendererBlock();
                    _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
                }

                await _pipeline.StartAsync();
                _positionTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting playback: {ex.Message}");
                mmError.Text = ex.ToString();
            }
        }

        /// <summary>
        /// Setup single pass blur.
        /// </summary>
        private void SetupSinglePassBlur()
        {
            var glUpload = new GLUploadBlock();
            var glDownload = new GLDownloadBlock();

            // Create single-pass blur shader
            var vertexShader = File.ReadAllText("gaussian_blur_vertex.glsl");
            var fragmentShader = File.ReadAllText("gaussian_blur_combined.glsl");

            var shaderSettings = new GLShaderSettings(vertexShader, fragmentShader);
            shaderSettings.Uniforms["blur_strength"] = _blurRadius / 10.0f;
            shaderSettings.Uniforms["tex_width"] = _videoWidth;
            shaderSettings.Uniforms["tex_height"] = _videoHeight;

            _blurShaderH = new GLShaderBlock(shaderSettings);

            _pipeline.Connect(_fileSource.VideoOutput, glUpload.Input);
            _pipeline.Connect(glUpload.Output, _blurShaderH.Input);
            _pipeline.Connect(_blurShaderH.Output, glDownload.Input);
            _pipeline.Connect(glDownload.Output, _videoRenderer.Input);
        }

        /// <summary>
        /// Setup two pass blur.
        /// </summary>
        private void SetupTwoPassBlur(bool highQuality = false)
        {
            var glUpload = new GLUploadBlock();
            var glDownload = new GLDownloadBlock();

            // First pass - horizontal blur
            var vertexShader = File.ReadAllText("gaussian_blur_vertex.glsl");
            var horizontalFragmentShader = highQuality 
                ? File.ReadAllText("gaussian_blur_hq_horizontal.glsl")
                : File.ReadAllText("gaussian_blur_horizontal.glsl");

            var horizontalSettings = new GLShaderSettings(vertexShader, horizontalFragmentShader);
            horizontalSettings.Uniforms["blur_radius"] = _blurRadius;
            horizontalSettings.Uniforms["tex_width"] = _videoWidth;

            _blurShaderH = new GLShaderBlock(horizontalSettings);

            // Second pass - vertical blur
            var verticalFragmentShader = highQuality
                ? File.ReadAllText("gaussian_blur_hq_vertical.glsl")
                : File.ReadAllText("gaussian_blur_vertical.glsl");
            
            var verticalSettings = new GLShaderSettings(vertexShader, verticalFragmentShader);
            verticalSettings.Uniforms["blur_radius"] = _blurRadius;
            verticalSettings.Uniforms["tex_height"] = _videoHeight;

            _blurShaderV = new GLShaderBlock(verticalSettings);

            // Connect pipeline: Source -> Upload -> HBlur -> VBlur -> Download -> Renderer
            _pipeline.Connect(_fileSource.VideoOutput, glUpload.Input);
            _pipeline.Connect(glUpload.Output, _blurShaderH.Input);
            _pipeline.Connect(_blurShaderH.Output, _blurShaderV.Input);
            _pipeline.Connect(_blurShaderV.Output, glDownload.Input);
            _pipeline.Connect(glDownload.Output, _videoRenderer.Input);
        }

        /// <summary>
        /// Handles the tb blur radius scroll event.
        /// </summary>
        private void tbBlurRadius_Scroll(object sender, EventArgs e)
        {
            _blurRadius = tbBlurRadius.Value / 10.0f;
            lbBlurRadius.Text = $"Blur Radius: {_blurRadius:F1}";
            UpdateBlurSettings();
        }

        /// <summary>
        /// Update blur settings.
        /// </summary>
        private void UpdateBlurSettings()
        {
            if (_blurShaderH == null)
                return;

            if (_blurMode == 2) // Simple blur
            {
                // Update single-pass blur
                _blurShaderH.Settings.Uniforms["blur_strength"] = _blurRadius / 10.0f;
                _blurShaderH.Update();
            }
            else
            {
                // Update two-pass blur
                _blurShaderH.Settings.Uniforms["blur_radius"] = _blurRadius;
                _blurShaderH.Update();

                if (_blurShaderV != null)
                {
                    _blurShaderV.Settings.Uniforms["blur_radius"] = _blurRadius;
                    _blurShaderV.Update();
                }
            }
        }

        /// <summary>
        /// Handles the cb blur mode selected index changed event.
        /// </summary>
        private async void cbBlurMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool wasRunning = _pipeline != null && _pipeline.State == PlaybackState.Play;
            
            if (wasRunning)
            {
                btnStop_Click(null, null);
            }

            _blurMode = cbBlurMode.SelectedIndex;

            if (wasRunning && !string.IsNullOrEmpty(edFilename.Text))
            {
                btnStart_Click(null, null);
            }
        }

        /// <summary>
        /// Handles the btn stop click event.
        /// </summary>
        private async void btnStop_Click(object sender, EventArgs e)
        {
            _positionTimer.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await DestroyEngineAsync();
            }

            lbPosition.Text = "Position: 00:00:00 / 00:00:00";
            tbTimeline.Value = 0;
        }

        /// <summary>
        /// Handles the btn pause click event.
        /// </summary>
        private async void btnPause_Click(object sender, EventArgs e)
        {
            if (_pipeline != null)
            {
                await _pipeline.PauseAsync();
            }
        }

        /// <summary>
        /// Handles the btn resume click event.
        /// </summary>
        private async void btnResume_Click(object sender, EventArgs e)
        {
            if (_pipeline != null)
            {
                await _pipeline.ResumeAsync();
            }
        }

        /// <summary>
        /// Handles the tb timeline scroll event.
        /// </summary>
        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (_pipeline != null && _pipeline.State == PlaybackState.Play)
            {
                var duration = await _pipeline.DurationAsync();
                if (duration != TimeSpan.Zero)
                {
                    var position = TimeSpan.FromSeconds(tbTimeline.Value * duration.TotalSeconds / 100);
                    await _pipeline.Position_SetAsync(position);
                }
            }
        }

        /// <summary>
        /// Handles the tm position tick event.
        /// </summary>
        private async void tmPosition_Tick(object sender, EventArgs e)
        {
            if (_pipeline != null && _pipeline.State == PlaybackState.Play)
            {
                var position = await _pipeline.Position_GetAsync();
                var duration = await _pipeline.DurationAsync();

                lbPosition.Text = $"Position: {position:hh\\:mm\\:ss} / {duration:hh\\:mm\\:ss}";

                if (duration != TimeSpan.Zero)
                {
                    tbTimeline.Value = (int)(position.TotalSeconds * 100 / duration.TotalSeconds);
                }
            }
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
        }

        /// <summary>
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                
                _blurShaderH = null;
                _blurShaderV = null;
                
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                mmError.Text += $"Error: {e.Message}\r\n";
                Debug.WriteLine($"Pipeline error: {e.Message}");
            }));
        }

        /// <summary>
        /// Pipeline on stop.
        /// </summary>
        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                _positionTimer.Stop();
                lbPosition.Text = "Position: 00:00:00 / 00:00:00";
                tbTimeline.Value = 0;
            }));
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _positionTimer?.Stop();
            await DestroyEngineAsync();
            VisioForgeX.DestroySDK();
        }
    }
}