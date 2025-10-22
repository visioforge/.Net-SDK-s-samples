// ReSharper disable InconsistentNaming

namespace RTSP_Preview_WinForms
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using VisioForge.Core;
    using VisioForge.Core.ONVIFX;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.ONVIFDiscovery;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.UI;
    using VisioForge.Core.VideoCaptureX;

    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer tmRecording = new System.Windows.Forms.Timer();

        private ONVIFClientX onvifClient;

        private Discovery _onvifDiscovery = new Discovery();
        
        private CancellationTokenSource _cts;

        private MediaBlocksPipeline _pipeline;

        private RTSPSourceBlock _rtspSource;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        public Form1()
        {
            InitializeComponent();

            tmRecording.Interval = 1000;
            tmRecording.Tick += async (sender, args) =>
            {
                await UpdateRecordingTime();
            };
        }

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();

            _pipeline.OnError += VideoCapture1_OnError;
        }

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= VideoCapture1_OnError;

                _pipeline.Stop();

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // We have to initialize the engine on start
            Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            Text += $" (SDK v{VideoCaptureCoreX.SDK_Version})";
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            CreateEngine();

            if (onvifClient != null)
            {
                onvifClient.Dispose();
                onvifClient = null;

                btONVIFConnect.Text = "Connect";
            }

            mmLog.Clear();

            var audioEnabled = cbIPAudioCapture.Checked;
            var lowLatencyMode = cbLowLatencyMode.Checked;
            _pipeline.Debug_Mode = cbDebugMode.Checked;
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var rtsp = await RTSPSourceSettings.CreateAsync(new Uri(cbIPURL.Text), edIPLogin.Text, edIPPassword.Text, audioEnabled);
            
            // Enable low latency mode if checkbox is checked
            if (lowLatencyMode)
            {
                rtsp.LowLatencyMode = true;
                mmLog.Text += "Low latency mode enabled (latency=80ms, no buffering)" + Environment.NewLine;
            }
            
            var info = rtsp.GetInfo();

            if (info == null)
            {
                MessageBox.Show(this, "Unable to get RTSP source info. Please, use the direct RTSP URL, not HTTP ONVIF");
                return;
            }

            _rtspSource = new RTSPSourceBlock(rtsp);

            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
            
            // Disable sync for low latency mode to reduce display latency
            if (lowLatencyMode)
            {
                _videoRenderer.IsSync = false;
                mmLog.Text += "Video renderer sync disabled for low latency" + Environment.NewLine;
            }

            _pipeline.Connect(_rtspSource.VideoOutput, _videoRenderer.Input);

            if (audioEnabled && info.AudioStreams.Count > 0)
            {
                _audioRenderer = new AudioRendererBlock();
                _pipeline.Connect(_rtspSource.AudioOutput, _audioRenderer.Input);
            }

            await _pipeline.StartAsync();

            tmRecording.Start();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            tmRecording.Stop();

            await _pipeline.StopAsync();
            await _pipeline.DisposeAsync();
        }

        private void llVideoTutorials_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void Log(string txt)
        {
            if (InvokeRequired)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
            }
            else
            {
                mmLog.Text = mmLog.Text + txt + Environment.NewLine;
            }
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private async void btONVIFConnect_Click(object sender, EventArgs e)
        {
            if (btONVIFConnect.Text == "Connect")
            {
                try
                {
                    btONVIFConnect.Enabled = false;
                    btONVIFConnect.Text = "Connecting";

                    if (onvifClient != null)
                    {
                        onvifClient.Dispose();
                        onvifClient = null;
                    }

                    if (string.IsNullOrEmpty(edONVIFLogin.Text) || string.IsNullOrEmpty(edONVIFPassword.Text))
                    {
                        MessageBox.Show(this, "Please specify IP camera user name and password.");
                        return;
                    }

                    onvifClient = new ONVIFClientX();
                    var result = await onvifClient.ConnectAsync(edONVIFURL.Text, edONVIFLogin.Text, edONVIFPassword.Text);
                    if (!result)
                    {
                        onvifClient = null;
                        MessageBox.Show(this, "Unable to connect to ONVIF camera.");
                        return;
                    }

                    lbONVIFCameraInfo.Text = $"Camera name {onvifClient.DeviceInformation?.Model}, serial number {onvifClient.DeviceInformation?.SerialNumber}";

                    cbONVIFProfile.Items.Clear();
                    var profiles = await onvifClient.GetProfilesAsync();
                    if (profiles != null && profiles.Length > 0)
                    {
                        foreach (var profile in profiles)
                        {
                            cbONVIFProfile.Items.Add($"{profile.Name}");
                        }

                        if (cbONVIFProfile.Items.Count > 0)
                        {
                            cbONVIFProfile.SelectedIndex = 0;
                        }

                        var mediaUri = await onvifClient.GetStreamUriAsync(profiles[0]);
                        if (mediaUri != null)
                        {
                            edONVIFLiveVideoURL.Text = cbIPURL.Text = mediaUri.Uri;
                        }
                    }

                    edIPLogin.Text = edONVIFLogin.Text;
                    edIPPassword.Text = edONVIFPassword.Text;

                    btONVIFConnect.Text = "Disconnect";
                }
                catch
                {                    
                    btONVIFConnect.Text = "Connect";
                }

                btONVIFConnect.Enabled = true;
            }
            else
            {
                btONVIFConnect.Text = "Connect";

                if (onvifClient != null)
                {
                    onvifClient.Dispose();
                    onvifClient = null;
                }
            }
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await _pipeline.PauseAsync();
        }

        private async Task UpdateRecordingTime()
        {
            var ts = await _pipeline.Position_GetAsync();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            if (InvokeRequired)
            {
                Invoke((Action)(() =>
                {
                    lbTimestamp.Text = "Duration: " + ts.ToString(@"hh\:mm\:ss");
                }));
            }
            else
            {
                lbTimestamp.Text = "Duration: " + ts.ToString(@"hh\:mm\:ss");
            }
        }

        private void btListONVIFSources_Click(object sender, EventArgs e)
        {
            cbIPURL.Items.Clear();

            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            Task.Run(async () =>
            {
                try
                {
                    await _onvifDiscovery.Discover(5, (device) =>
                    {
                        if (device.XAdresses?.Any() == true)
                        {
                            if (InvokeRequired)
                            {
                                Invoke((Action)(() =>
                                {
                                    var address = device.XAdresses.FirstOrDefault();
                                    if (!string.IsNullOrEmpty(address))
                                    {
                                        cbIPURL.Items.Add(address);

                                        if (cbIPURL.Items.Count == 1)
                                        {
                                            cbIPURL.SelectedIndex = 0;
                                        }
                                    }
                                }));
                            }
                        }
                    }, _cts.Token);
                }
                catch (OperationCanceledException)
                {
                    // Discovery cancelled
                }
            });
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmRecording.Stop();

            await DestroyEngineAsync();

            if (onvifClient != null)
            {
                onvifClient.Dispose();
                onvifClient = null;
            }

            VisioForgeX.DestroySDK();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                if (onvifClient != null)
                {
                    onvifClient.Dispose();
                    onvifClient = null;
                }

                tmRecording?.Dispose();
                tmRecording = null;
            }

            base.Dispose(disposing);
        }
    }
}

// ReSharper restore InconsistentNaming
