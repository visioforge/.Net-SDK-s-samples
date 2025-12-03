using System;
using System.ComponentModel;
using System.Windows;
using Microsoft.Win32;
using SkiaSharp;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;

namespace scrolling_text
{
    /// <summary>
    /// Simple scrolling text overlay sample using Media Blocks SDK.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private OverlayManagerBlock _overlayManager;

        private OverlayManagerScrollingText _scrollingText;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize the SDK on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(edFilename.Text))
            {
                MessageBox.Show("Please select a video file.");
                return;
            }

            // Create MediaBlocks pipeline
            _pipeline = new MediaBlocksPipeline();

            // Create file source
            var fileSourceSettings = await UniversalSourceSettings.CreateAsync(edFilename.Text);
            var fileSource = new UniversalSourceBlock(fileSourceSettings);

            // Create overlay manager
            _overlayManager = new OverlayManagerBlock();

            // Create scrolling text overlay
            int speed = 5;
            int.TryParse(edSpeed.Text, out speed);

            _scrollingText = new OverlayManagerScrollingText(
                edScrollText.Text,
                x: 0,
                y: 50,
                speed: speed,
                direction: ScrollDirection.RightToLeft)
            {
                DefaultWidth = 1920,  // Set to match common video width
                Infinite = true,
                Color = SKColors.Yellow,
                BackgroundTransparent = false,
                BackgroundColor = new SKColor(0, 0, 128, 200), // Semi-transparent dark blue
                ZIndex = 10
            };
            _scrollingText.Font.Size = 32;

            // Add shadow for better visibility
            _scrollingText.Shadow = new OverlayManagerShadowSettings
            {
                Enabled = true,
                Color = SKColors.Black,
                Opacity = 0.7,
                BlurRadius = 3,
                Depth = 3,
                Direction = 45
            };

            // Add scrolling text to overlay manager
            _overlayManager.Video_Overlay_Add(_scrollingText);

            // Create video renderer
            var videoRenderer = new VideoRendererBlock(_pipeline, videoView1);

            // Connect: source -> overlay manager -> renderer
            _pipeline.Connect(fileSource.VideoOutput, _overlayManager.Input);
            _pipeline.Connect(_overlayManager.Output, videoRenderer.Input);

            // Add audio output if available
            var info = fileSourceSettings.GetInfo();
            if (info.AudioStreams.Count > 0)
            {
                var audioOutputs = await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound);
                if (audioOutputs.Length > 0)
                {
                    var audioRenderer = new AudioRendererBlock(audioOutputs[0]);
                    _pipeline.Connect(fileSource.AudioOutput, audioRenderer.Input);
                }
            }

            // Start playback
            await _pipeline.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            await _pipeline.StopAsync();
            await _pipeline.DisposeAsync();
            _pipeline = null;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            btStop_Click(null, null);
            VisioForgeX.DestroySDK();
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Video files|*.mp4;*.avi;*.mkv;*.mov;*.wmv|All files|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                edFilename.Text = dlg.FileName;
            }
        }
    }
}
