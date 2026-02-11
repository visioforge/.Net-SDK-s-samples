using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace webcam_preview
{
    using System.IO;
    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.AudioRenderers;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.Types.X.VideoCapture;
using System.Diagnostics;

    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

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
                DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;
                DeviceEnumerator.Shared.OnAudioSinkAdded += DeviceEnumerator_OnAudioSinkAdded;

                await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
                await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();
                await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();

                Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Device enumerator on audio sink added.
        /// </summary>
        private void DeviceEnumerator_OnAudioSinkAdded(object sender, AudioOutputDeviceInfo e)
        {
            Invoke((Action)(() =>
            {
                cbAudioOutputDevice.Items.Add(e.DisplayName);

                if (cbAudioOutputDevice.Items.Count == 1)
                {
                    cbAudioOutputDevice.SelectedIndex = 0;
                }
            }));
        }

        /// <summary>
        /// Device enumerator on audio source added.
        /// </summary>
        private void DeviceEnumerator_OnAudioSourceAdded(object sender, AudioCaptureDeviceInfo e)
        {
            Invoke((Action)(() =>
            {
                cbAudioInputDevice.Items.Add(e.DisplayName);

                if (cbAudioInputDevice.Items.Count == 1)
                {
                    cbAudioInputDevice.SelectedIndex = 0;
                }
            }));
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

                // set debug settings
                _pipeline.Debug_Mode = cbDebugMode.Checked;
                _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
                _pipeline.Debug_Telemetry = cbTelemetry.Checked;
                mmLog.Clear();

                // video source
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

                // audio source
                IAudioCaptureDeviceSourceSettings audioSourceSettings = null;

                deviceName = cbAudioInputDevice.Text;
                format = cbAudioInputFormat.Text;
                if (!string.IsNullOrEmpty(deviceName))
                {
                    var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).ToList().Find(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.Formats.ToList().Find(x => x.Name == format);
                        if (formatItem != null)
                        {
                            audioSourceSettings = device.CreateSourceSettings(formatItem.ToFormat());
                        }
                    }
                }

                var audioSource = new SystemAudioSourceBlock(audioSourceSettings);

                // audio sink
                var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).ToList().Find(x => x.DisplayName == cbAudioOutputDevice.Text);
                var audioRenderer = new AudioRendererBlock(new AudioRendererSettings(audioOutputDevice));

                // video renderer
                var videoRenderer = new VideoRendererBlock(_pipeline, videoView: VideoView1);

                // connect everything
                _pipeline.Connect(videoSource, videoRenderer);
                _pipeline.Connect(audioSource, audioRenderer);

                // start
                await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the cb audio input device selected index changed event.
        /// </summary>
        private async void cbAudioInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbAudioInputFormat.Items.Clear();

                if (cbAudioInputDevice.SelectedIndex != -1)
                {
                    var deviceItem = (await DeviceEnumerator.Shared.AudioSourcesAsync()).ToList().Find(device => device.DisplayName == cbAudioInputDevice.Text);
                    if (deviceItem == null)
                    {
                        return;
                    }

                    var defaultValue = "S16LE 44100 Hz 2 ch.";
                    var defaultValueExists = false;
                    foreach (var format in deviceItem.Formats)
                    {
                        cbAudioInputFormat.Items.Add(format.Name);

                        if (defaultValue == format.Name)
                        {
                            defaultValueExists = true;
                        }
                    }

                    if (cbAudioInputFormat.Items.Count > 0)
                    {
                        cbAudioInputFormat.SelectedIndex = 0;

                        if (defaultValueExists)
                        {
                            cbAudioInputFormat.Text = defaultValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Log.
        /// </summary>
        private void Log(string txt)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
            }
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
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

                await _pipeline.StopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                await _pipeline.PauseAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, EventArgs e)
        {
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                await _pipeline.ResumeAsync();
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
    }
}
