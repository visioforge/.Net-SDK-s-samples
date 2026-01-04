using System.Diagnostics;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.ONVIFX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace RTSPViewer
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;

        private RTSPSourceBlock _rtspSource;

        private MediaBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        public MainPage()
        {
            InitializeComponent();

            // We have to initialize the engine on start
            VisioForgeX.InitSDK();
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

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

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

        private async Task StopAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }

            await DestroyEngineAsync();
        }

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

        private void VideoCapture1_OnError(object? sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }
    }

}
