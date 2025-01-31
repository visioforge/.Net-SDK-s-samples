using System.Diagnostics;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.ONVIF;
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
                var onvifDevice = new ONVIFDevice();
                var result = await onvifDevice.ConnectAsync(uri, edUsername.Text, edPassword.Text);
                if (result)
                {
                    var deviceInfo = onvifDevice.GetDeviceInformation();
                    if (deviceInfo != null)
                    {
                        Debug.WriteLine($"Model {deviceInfo.Model}, Firmware {deviceInfo.Firmware}");
                    }

                    var endPoints = onvifDevice.MediaEndpoints;
                    if (endPoints.Length > 0)
                    {
                        var rtspUri = endPoints[0].Uri.Uri;
                        if (rtspUri != null)
                        {
                            uri = new Uri(rtspUri);
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Unable to get RTSP source info from ONVIF URL.", "OK");
                    return;
                }
            }
            else if (uri.Scheme != "rtsp")
            {
                await DisplayAlert("Alert", "Unsupported URL", "OK");
            }

            var rtsp = await RTSPSourceSettings.CreateAsync(uri, edUsername.Text, edPassword.Text, true);
            var info = rtsp.GetInfo();

            if (info == null)
            {
                await DisplayAlert("Alert", "Unable to get RTSP source info.", "OK");
                return;
            }

            _rtspSource = new RTSPSourceBlock(rtsp);

            IVideoView vv;
#if __MACCATALYST__
            vv = videoView;
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

        private async void btPlay_Clicked(object sender, EventArgs e)
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

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }
    }

}
