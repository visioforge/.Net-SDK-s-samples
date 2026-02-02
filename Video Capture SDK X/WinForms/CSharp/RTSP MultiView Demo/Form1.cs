using System;
using System.Collections.Generic;

using System.Windows.Forms;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    /// <summary>
    /// The main form for the RTSP MultiView Demo.
    /// Demonstrates how to display and capture multiple RTSP streams simultaneously using the X-engine.
    /// </summary>
    public partial class Form1 : Form
    {
        private Engine[] _engines = new Engine[9];

        private List<Tuple<string, string>> _customDecoders;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// Initializes the SDK engine, populates available GPU decoders, and sets default UI values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            // We have to initialize the engine on start
            Text += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            Text += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

            cbCameraIndex.SelectedIndex = 0;
            edURL.Text = "http://localhost:8000/camera/mjpeg"; 
            edFilename.Text = @"c:\vf\outputxx.ts";

            // HW decoders
            cbGPUDecoder.Items.Add("None");

            var hwDecoders = MediaBlocksPipeline.GetHardwareDecoders(new[] { "H264", "H265", "HEVC", "H.264", "H.265" });
            var swH264Decoders = MediaBlocksPipeline.GetSoftwareH264Decoders();
            var swH265Decoders = MediaBlocksPipeline.GetSoftwareH265Decoders();

            _customDecoders = new List<Tuple<string, string>>();
            _customDecoders.AddRange(hwDecoders);
            _customDecoders.AddRange(swH264Decoders);
            _customDecoders.AddRange(swH265Decoders);

            foreach (var item in _customDecoders)
            {
                cbGPUDecoder.Items.Add(item.Item2.Replace("Direct3D11/DXVA", ""));
            }

            cbGPUDecoder.SelectedIndex = 0;

            if (cbGPUDecoder.Items.Count > 1)
            {
                cbGPUDecoder.Enabled = true;
                cbUseGPU.Enabled = true;
            }
        }

        /// <summary>
        /// Gets the video view control associated with the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the video view.</param>
        /// <returns>An <see cref="IVideoView"/> instance if found; otherwise, null.</returns>
        private IVideoView GetVideoViewByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return videoView1;
                case 1:
                    return videoView2;
                case 2:
                    return videoView3;
                case 3:
                    return videoView4;
                case 4:
                    return videoView5;
                case 5:
                    return videoView6;
                case 6:
                    return videoView7;
                case 7:
                    return videoView8;
                case 8:
                    return videoView9;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures and starts the video capture engine for the selected camera index.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, EventArgs e)
        {
            edLog.Text = string.Empty;

            int id = cbCameraIndex.SelectedIndex;
            if (_engines[id] != null)
            {
                await _engines[id].Core.StopAsync();
                await _engines[id].Core.DisposeAsync();
                _engines[id] = null;
            }

            _engines[id] = new Engine(GetVideoViewByIndex(id));
            _engines[id].Core.OnError += Engine_OnError;

            _engines[id].URL = edURL.Text;
            _engines[id].Login = edLogin.Text;
            _engines[id].Password = edPassword.Text;
            _engines[id].Filename = edFilename.Text;
            _engines[id].AudioEnabled = cbAudioEnabled.Checked;

            if (cbUseMJPEG.Checked)
            {
                var urix = new UriBuilder(_engines[id].URL);
                urix.UserName = _engines[id].Login;
                urix.Password = _engines[id].Password;

                var uniSettings = await UniversalSourceSettings.CreateAsync(urix.Uri, renderAudio: _engines[id].AudioEnabled);

                _engines[id].Core.Video_Source = uniSettings;                
            }
            else
            {
                var rtspSettings = await RTSPSourceSettings.CreateAsync(new Uri(_engines[id].URL), _engines[id].Login, _engines[id].Password, _engines[id].AudioEnabled);
                rtspSettings.UseGPUDecoder = cbUseGPU.Checked;
                rtspSettings.CompatibilityMode = cbCompatibilityMode.Checked;
                
                // Enable low latency mode if checkbox is checked
                if (cbLowLatencyMode.Checked)
                {
                    rtspSettings.LowLatencyMode = true;
                }
                
                if (cbGPUDecoder.SelectedIndex > 0)
                {
                    rtspSettings.CustomVideoDecoder = _customDecoders[cbGPUDecoder.SelectedIndex - 1].Item1;
                }

                _engines[id].Core.Video_Source = rtspSettings;
            }

            _engines[id].Core.Outputs_Clear();
            if (cbCapture.Checked)
            {
                _engines[id].Core.Outputs_Add(new MP4Output(edFilename.Text));
            }

            await _engines[id].Core.StartAsync();
        }

        /// <summary>
        /// Handles the OnError event of an Engine's video capture core.
        /// Logs error messages to the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisioForge.Core.Types.Events.ErrorsEventArgs"/> instance containing the error data.</param>
        private void Engine_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops and disposes of the video capture engine for the selected camera index.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, EventArgs e)
        {
            int id = cbCameraIndex.SelectedIndex;
            if (_engines[id] != null)
            {
                await _engines[id].Core.StopAsync();

                _engines[id].Core.OnError -= Engine_OnError;
                await _engines[id].Core.DisposeAsync();
                _engines[id] = null;
            }

            GetVideoViewByIndex(id).CallRefresh();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cbCameraIndex control.
        /// Updates the UI with settings from the newly selected camera engine.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbCameraIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = cbCameraIndex.SelectedIndex;
            if (_engines[id] != null)
            {
                edURL.Text = _engines[id].URL;
                edLogin.Text = _engines[id].Login;
                edPassword.Text = _engines[id].Password;
                cbAudioEnabled.Checked = _engines[id].AudioEnabled;
                edFilename.Text = _engines[id].Filename;
            }
            else
            {
                edURL.Text = "";
                edLogin.Text = "";
                edPassword.Text = "";
                cbAudioEnabled.Checked = false;
                edFilename.Text = "";
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the Form1 control.
        /// Stops and disposes of all active engines and destroys the SDK.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < _engines.Length; i++)
            {
                if (_engines[i] != null)
                {
                    await _engines[i].Core.DisposeAsync();
                    _engines[i] = null;
                }
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the Click event of the btReadInfo control.
        /// Uses MediaInfoReaderX to retrieve and log stream information for the current URL.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btReadInfo_Click(object sender, EventArgs e)
        {
            var infoReader = new MediaInfoReaderX();

            var uriBuilder = new UriBuilder(edURL.Text);
            if (!string.IsNullOrEmpty(edLogin.Text) && !string.IsNullOrEmpty(edPassword.Text))
            {
                uriBuilder.UserName = edLogin.Text;
                uriBuilder.Password = edPassword.Text;
            }

            var res = await infoReader.OpenAsync(uriBuilder.Uri);
            if (res)
            {
                if (infoReader.Info.VideoStreams.Count > 0)
                {
                    edLog.Text += "Video streams: " + Environment.NewLine;
                    foreach (var item in infoReader.Info.VideoStreams)
                    {
                        edLog.Text += $"  {item.Codec} {item.Width}x{item.Height}" + Environment.NewLine;
                    }
                }

                edLog.Text += Environment.NewLine;

                if (infoReader.Info.AudioStreams.Count > 0)
                {
                    edLog.Text += "Audio streams: " + Environment.NewLine;
                    foreach (var item in infoReader.Info.AudioStreams)
                    {
                        edLog.Text += $"  {item.Codec} {item.Channels} ch {item.SampleRate} Hz" + Environment.NewLine;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btONVIF control.
        /// Opens the ONVIF discovery dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btONVIF_Click(object sender, EventArgs e)
        {
            var disc = new ONVIFDiscovery();
            disc.ShowDialog();
            disc.Dispose();
        }
    }
}
