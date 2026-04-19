using System;
using System.Linq;
using System.Windows.Forms;

namespace opengl_shader
{
    using System.Diagnostics;
    using System.IO;
    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.OpenGL;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.OpenGL;
    using VisioForge.Core.Types.X.Sources;

    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private GLShaderBlock _shader;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();

            _pipeline.OnError += VideoCapture1_OnError;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= VideoCapture1_OnError;

                _pipeline.Dispose();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // We have to initialize the engine on start
                Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.Enabled = false;
                await VisioForgeX.InitSDKAsync();
                this.Enabled = true;
                Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;

                await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();

                Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Device enumerator on video source added.
        /// </summary>
        private void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            Invoke((Action)(() =>
            {
                cbVideoInputDevice.Items.Add(e.DisplayName);

                if (cbVideoInputDevice.Items.Count == 1)
                {
                    cbVideoInputDevice.SelectedIndex = 0;
                }
            }));
        }

        /// <summary>
        /// Handles the cb video input device selected index changed event.
        /// </summary>
        private async void cbVideoInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbVideoInputFormat.Items.Clear();

                var devices = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList();
                var deviceItem = devices.Find(device => device.DisplayName == cbVideoInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                foreach (var format in deviceItem.VideoFormats)
                {
                    cbVideoInputFormat.Items.Add(format.Name);
                }

                if (cbVideoInputFormat.Items.Count > 0)
                {
                    cbVideoInputFormat.SelectedIndex = 0;
                    cbVideoInputFormat_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                CreateEngine();

                // Create video source
                VideoCaptureDeviceSourceSettings videoSourceSettings = null;

                var deviceName = cbVideoInputDevice.Text;
                var format = cbVideoInputFormat.Text;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList().Find(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.ToList().Find(x => x.Name == format);
                        if (formatItem != null)
                        {
                            videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                            {
                                Format = formatItem.ToFormat()
                            };

                            videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text));
                        }
                    }
                }

                var videoSource = new SystemVideoSourceBlock(videoSourceSettings);

                // Create video renderer
                var videoRenderer = new VideoRendererBlock(_pipeline, videoView: VideoView1);

                // Sample shader
                var shader = GetShader();

                // Upload video frame to GPU
                var glUpload = new GLUploadBlock();

                // Apply shader
                var glShaderSettings = new GLShaderSettings(shader);
                _shader = new GLShaderBlock(glShaderSettings);

                // Download video frame from GPU
                var glDownload = new GLDownloadBlock();

                // Connect everything
                _pipeline.Connect(videoSource, glUpload);
                _pipeline.Connect(glUpload, _shader);
                _pipeline.Connect(_shader, glDownload);
                _pipeline.Connect(glDownload, videoRenderer);

                // Start
                await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Get shader.
        /// </summary>
        private GLShader GetShader()
        {
            GLShader shader;
            if (rbGrayscale.Checked)
            {
                shader = new GLShader(File.ReadAllText("grayscale_vertex.glsl"), File.ReadAllText("grayscale_fragment.glsl"));
            }
            else if (rbInvert.Checked)
            {
                shader = new GLShader(File.ReadAllText("invert_vertex.glsl"), File.ReadAllText("invert_fragment.glsl"));
            }
            else
            {
                shader = new GLShader(File.ReadAllText("none_vertex.glsl"), File.ReadAllText("none_fragment.glsl"));
            }

            return shader;
        }

        /// <summary>
        /// Update shader.
        /// </summary>
        private void UpdateShader()
        {
            if (_shader == null)
            {
                return;
            }

            GLShader shader = GetShader();
            _shader.Settings.Fragment = shader.FragmentShader;
            _shader.Settings.Vertex = shader.VertexShader;

            _shader.Update();
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                _shader = null;

                await _pipeline.StopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the cb video input format selected index changed event.
        /// </summary>
        private async void cbVideoInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbVideoInputFormat.Text))
                {
                    return;
                }

                cbVideoInputFrameRate.Items.Clear();

                if (string.IsNullOrEmpty(cbVideoInputFormat.Text) || string.IsNullOrEmpty(cbVideoInputDevice.Text))
                {
                    return;
                }

                if (cbVideoInputDevice.SelectedIndex != -1)
                {
                    var devices = (await DeviceEnumerator.Shared.VideoSourcesAsync()).ToList();
                    var deviceItem = devices.Find(device => device.DisplayName == cbVideoInputDevice.Text);
                    if (deviceItem == null)
                    {
                        return;
                    }

                    var videoFormat = deviceItem.VideoFormats.Find(format => format.Name == cbVideoInputFormat.Text);
                    if (videoFormat == null)
                    {
                        return;
                    }

                    // build int range from tuple (min, max)    
                    var frameRateList = videoFormat.GetFrameRateRangeAsStringList();
                    foreach (var item in frameRateList)
                    {
                        cbVideoInputFrameRate.Items.Add(item);
                    }

                    if (cbVideoInputFrameRate.Items.Count > 0)
                    {
                        cbVideoInputFrameRate.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the rb shader checked changed event.
        /// </summary>
        private void rbShader_CheckedChanged(object sender, EventArgs e)
        {
            UpdateShader();
        }
    }
}
