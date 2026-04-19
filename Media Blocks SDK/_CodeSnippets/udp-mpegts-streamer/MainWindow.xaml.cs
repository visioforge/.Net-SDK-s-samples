using System;
using System.ComponentModel;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;

namespace udp_mpegts_streamer_mb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create screen capture source.
        /// </summary>
        private IScreenCaptureSourceSettings CreateScreenCaptureSource()
        {
            var source = new ScreenCaptureD3D11SourceSettings();

            source.FrameRate = new VideoFrameRate(30);
            source.Rectangle = new VisioForge.Core.Types.Rect(System.Windows.Forms.Screen.AllScreens[0].Bounds);

            source.CaptureCursor = true;

            return source;
        }

        /// <summary>
        /// Updates the playback info text to reflect the current port value.
        /// </summary>
        private void UpdatePlaybackInfo()
        {
            if (tbPlaybackInfo == null)
            {
                return;
            }

            tbPlaybackInfo.Text = $"Play with: ffplay udp://@:{edPort.Text} | gst-launch-1.0 udpsrc port={edPort.Text} ! tsdemux ! decodebin ! autovideosink | vlc udp://@:{edPort.Text}";
        }

        /// <summary>
        /// Handles the port text changed event.
        /// </summary>
        private void edPort_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdatePlaybackInfo();
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            var originalTitle = Title;
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;

            try
            {
                await VisioForgeX.InitSDKAsync();
            }
            finally
            {
                this.IsEnabled = true;
                Title = originalTitle;
            }

            UpdatePlaybackInfo();
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            UpdatePlaybackInfo();

            if (_pipeline != null)
            {
                return;
            }

            if (!int.TryParse(edPort.Text, out int port))
            {
                MessageBox.Show("Invalid port number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Create the pipeline
                _pipeline = new MediaBlocksPipeline();

                // Create video renderer
                var videoRenderer = new VideoRendererBlock(_pipeline, videoView1);

                // Set screen capture with full screen enabled
                var videoSource = new ScreenSourceBlock(CreateScreenCaptureSource());

                // Video tee
                var tee = new TeeBlock(2, MediaBlockPadMediaType.Video);

                // H264 video encoder
                var videoEncoder = new H264EncoderBlock(new OpenH264EncoderSettings());

                // AAC audio encoder
                var audioEncoder = new AACEncoderBlock(new AVENCAACEncoderSettings() { Bitrate = 192 });

                // Audio fake audio source
                var audioSource = new VirtualAudioSourceBlock(VirtualAudioSourceSettingsWave.Silence);

                // Create UDP MPEG-TS sink
                var udpSettings = new UDPSinkSettings
                {
                    Host = edHost.Text,
                    Port = port
                };

                var udpSink = new UDPMPEGTSSinkBlock(udpSettings);

                // Connect blocks
                _pipeline.Connect(videoSource, tee);
                _pipeline.Connect(tee.Outputs[0], videoRenderer.Input);
                _pipeline.Connect(tee.Outputs[1], videoEncoder.Input);
                _pipeline.Connect(videoEncoder.Output, udpSink.CreateNewInput(MediaBlockPadMediaType.Video));
                _pipeline.Connect(audioSource.Output, audioEncoder.Input);
                _pipeline.Connect(audioEncoder.Output, udpSink.CreateNewInput(MediaBlockPadMediaType.Audio));

                // Start
                await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                if (_pipeline != null)
                {
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }

                MessageBox.Show($"Failed to start pipeline: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, CancelEventArgs e)
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }
    }
}
