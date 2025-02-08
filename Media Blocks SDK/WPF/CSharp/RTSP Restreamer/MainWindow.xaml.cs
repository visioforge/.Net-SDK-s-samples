using System;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.VideoEncoders;

namespace RTSP_Restreamer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RTSPServerBlock _server;

        private MediaBlocksPipeline _pipeline;

        private RTSPSourceBlock _rtspSource;

        private TeeBlock _videoTee;

        private VideoRendererBlock _videoRenderer;

        private TextOverlayBlock _textOverlay;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;

            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            this.IsEnabled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            // Create pipeline
            _pipeline = new MediaBlocksPipeline();

            // Create RTSP source
            var rtspSourceSettings = await RTSPSourceSettings.CreateAsync(new Uri(edSourceURL.Text), edUsername.Text, edPassword.Text, audioEnabled: true);
            var videoAvailable = rtspSourceSettings.GetInfo().VideoStreams.Count > 0;
            var audioAvailable = rtspSourceSettings.GetInfo().AudioStreams.Count > 0;

            _rtspSource = new RTSPSourceBlock(rtspSourceSettings);

            if (videoAvailable)
            {
                // Create video tee
                _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

                // Create video renderer
                _videoRenderer = new VideoRendererBlock(_pipeline, videoView1);

                // Connect video source to video tee
                _pipeline.Connect(_rtspSource.VideoOutput, _videoTee.Input);

                // Connect video tee to video renderer
                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
            }

            // Create video and audio encoders, if streams are available
            IVideoEncoder videoEncoder = null;
            if (videoAvailable)
            {
                videoEncoder = new OpenH264EncoderSettings();
            }

            IAudioEncoder audioEncoder = null;
            if (audioAvailable)
            {
                audioEncoder = new AVENCAACEncoderSettings();
            }

            var outputUri = new Uri(edOutputURL.Text);
            var rtspSettings = new RTSPServerSettings(videoEncoder, audioEncoder);
            rtspSettings.Port = outputUri.Port;
            rtspSettings.Point = outputUri.AbsolutePath;
            _server = new RTSPServerBlock(rtspSettings);

            // Connect RTSP server
            if (videoAvailable)
            {
                // Add text overlay?
                if (cbAddTextOverlay.IsChecked == true)
                {
                    _textOverlay = new TextOverlayBlock(new TextOverlaySettings("SAMPLE TEXT OVERLAY") { HorizontalAlignment = TextOverlayHAlign.Center, VerticalAlignment = TextOverlayVAlign.Top });
                    _pipeline.Connect(_videoTee.Outputs[1], _textOverlay.Input);
                    _pipeline.Connect(_textOverlay.Output, _server.VideoInput);
                }
                else
                {
                    _pipeline.Connect(_videoTee.Outputs[1], _server.VideoInput);
                }
            }

            if (audioAvailable)
            {
                _pipeline.Connect(_rtspSource.AudioOutput, _server.AudioInput);
            }

            await _pipeline.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.StopAsync();
        }
    }
}