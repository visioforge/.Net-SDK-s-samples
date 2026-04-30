using System.Diagnostics;
using System.Linq;
using System.Threading;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.ONVIFDiscovery;
using VisioForge.Core.ONVIFX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace RTSPViewer
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The RTSP source.
        /// </summary>
        private RTSPSourceBlock _rtspSource;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private MediaBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The ONVIF discovery instance.
        /// </summary>
        private readonly Discovery _onvifDiscovery = new Discovery();

        /// <summary>
        /// The ONVIF discovery cancellation token source.
        /// </summary>
        private CancellationTokenSource _onvifCts;

        public MainPage()
        {
            InitializeComponent();

            // We have to initialize the engine on start
            VisioForgeX.InitSDK();

            Loaded += MainPage_Loaded;
        }

        /// <summary>
        /// Main page loaded.
        /// </summary>
        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            Window.Destroying += Window_Destroying;
        }

        /// <summary>
        /// Window destroying.
        /// </summary>
        private async void Window_Destroying(object? sender, EventArgs e)
        {
            try
            {
                await StopAsync();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error during cleanup: {ex.Message}");
            }
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
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= VideoCapture1_OnError;

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Open async.
        /// </summary>
        private async Task OpenAsync()
        {
            CreateEngine();

            var uri = new Uri(edURL.Text);
            if (uri.Scheme == "http" || uri.Scheme == "https")
            {
                // Get RTSP URL from ONVIF
                var onvifClient = new ONVIFClientX();
                var result = await onvifClient.ConnectAsync(edURL.Text, edUsername.Text, edPassword.Text);
                if (result)
                {
                    var deviceInfo = onvifClient.DeviceInformation;
                    if (deviceInfo != null)
                    {
                        Debug.WriteLine($"Model {deviceInfo.Model}, Firmware {deviceInfo.SerialNumber}");
                    }

                    var profiles = await onvifClient.GetProfilesAsync();
                    if (profiles != null && profiles.Length > 0)
                    {
                        var mediaUri = await onvifClient.GetStreamUriAsync(profiles[0]);
                        if (mediaUri != null)
                        {
                            uri = new Uri(mediaUri.Uri);
                        }
                    }

                    onvifClient.Dispose();
                }
                else
                {
                    onvifClient.Dispose();
                    await DisplayAlertAsync("Alert", "Unable to get RTSP source info from ONVIF URL.", "OK");
                    return;
                }
            }
            else if (uri.Scheme != "rtsp")
            {
                await DisplayAlertAsync("Alert", "Unsupported URL", "OK");
            }

            var rtsp = await RTSPSourceSettings.CreateAsync(uri, edUsername.Text, edPassword.Text, true);
            
            // Enable low latency mode by default (checkbox is checked by default)
            if (cbLowLatencyMode.IsChecked)
            {
                rtsp.LowLatencyMode = true;
            }
            
            var info = rtsp.GetInfo();

            if (info == null)
            {
                await DisplayAlertAsync("Alert", "Unable to get RTSP source info.", "OK");
                return;
            }

            _rtspSource = new RTSPSourceBlock(rtsp);

            IVideoView vv;
#if __MACCATALYST__
            vv = videoView.GetVideoView();
#else
            vv = videoView.GetVideoView();
#endif

            _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = false };

            _pipeline.Connect(_rtspSource.VideoOutput, _videoRenderer.Input);

            if (info.AudioStreams.Count > 0)
            {
                _audioRenderer = new AudioRendererBlock();
                _pipeline.Connect(_rtspSource.AudioOutput, _audioRenderer.Input);
            }

            await _pipeline.StartAsync();
        }

        /// <summary>
        /// Stop async.
        /// </summary>
        private async Task StopAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }

            await DestroyEngineAsync();
        }

        /// <summary>
        /// Handles the bt play clicked event.
        /// </summary>
        private async void btPlay_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (btPlay.Text == "PLAY")
                {
                    btPlay.Text = "STOP";

                    await OpenAsync();
                }
                else
                {
                    btPlay.Text = "PLAY";

                    await StopAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in play/stop: {ex.Message}");
                await DisplayAlertAsync("Error", $"Operation failed: {ex.Message}", "OK");
                
                // Reset button state on error
                btPlay.Text = "PLAY";
            }
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        private void VideoCapture1_OnError(object? sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Handles the scan button click. Discovers ONVIF devices on the local network
        /// and populates the picker with their service URLs.
        /// </summary>
        private async void btScan_Clicked(object? sender, EventArgs e)
        {
            try
            {
                _onvifCts?.Cancel();
                _onvifCts = new CancellationTokenSource();

                cbONVIFDevices.Items.Clear();
                btScan.IsEnabled = false;
                btScan.Text = "...";

                try
                {
                    await _onvifDiscovery.Discover(5, (device) =>
                    {
                        if (device.XAdresses?.Any() == true)
                        {
                            var address = device.XAdresses.FirstOrDefault();
                            if (string.IsNullOrEmpty(address))
                            {
                                return;
                            }

                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                if (!cbONVIFDevices.Items.Contains(address))
                                {
                                    cbONVIFDevices.Items.Add(address);

                                    if (cbONVIFDevices.Items.Count == 1)
                                    {
                                        cbONVIFDevices.SelectedIndex = 0;
                                    }
                                }
                            });
                        }
                    }, _onvifCts.Token);
                }
                catch (OperationCanceledException)
                {
                    // Discovery cancelled
                }

                if (cbONVIFDevices.Items.Count == 0)
                {
                    await DisplayAlertAsync("ONVIF scan", "No ONVIF devices found on the local network.", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ONVIF scan error: {ex.Message}");
                await DisplayAlertAsync("ONVIF scan", $"Discovery failed: {ex.Message}", "OK");
            }
            finally
            {
                btScan.Text = "SCAN";
                btScan.IsEnabled = true;
            }
        }

        /// <summary>
        /// Copies the selected ONVIF device URL into the URL entry field.
        /// </summary>
        private void cbONVIFDevices_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbONVIFDevices.SelectedIndex < 0)
            {
                return;
            }

            edURL.Text = cbONVIFDevices.SelectedItem?.ToString() ?? string.Empty;
        }
    }

}
