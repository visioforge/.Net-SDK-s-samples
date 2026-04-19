using Avalonia.Controls;
using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.UI.Avalonia;

#if __MACOS__ || __MACCATALYST__
using VisioForge.Core.Types.X.Apple.VideoEffects;
#endif

namespace VideoMixerMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public static MainViewModel? Instance;

        public IVideoView VideoViewIntf { get; set; }

        public TopLevel TopLevel { get; set; }

        // Properties

        private string _startStopText = "START";

        public string StartStopText
        {
            get => _startStopText;
            set => this.RaiseAndSetIfChanged(ref _startStopText, value);
        }

        private bool _startStopEnabled = false;

        public bool StartStopEnabled
        {
            get => _startStopEnabled;
            set => this.RaiseAndSetIfChanged(ref _startStopEnabled, value);
        }

        // Commands

        public ICommand StartStopCommand { get; }

        public ReactiveCommand<Unit, Unit> WindowClosingCommand { get; }

        private bool _isClosing;

        // Pipeline fields

        private MediaBlocksPipeline _pipeline;
        private VirtualVideoSourceBlock _virtualSource1;
        private VirtualVideoSourceBlock _virtualSource2;
        private MediaBlock _mixer;
        private VideoRendererBlock _videoRenderer;
#if __MACOS__ || __MACCATALYST__
        private MetalVideoFilterBlock _metalFilter1;
        private MetalVideoFilterBlock _metalFilter2;
#endif

        public MainViewModel()
        {
            Instance = this;

            StartStopCommand = ReactiveCommand.CreateFromTask(StartStopAsync);
            WindowClosingCommand = ReactiveCommand.Create(OnWindowClosing);
        }

        public async Task InitAsync()
        {
            await VisioForgeX.InitSDKAsync();
            StartStopEnabled = true;
        }

        public void InitAndLoad()
        {
            VisioForgeX.InitSDK();
            StartStopEnabled = true;
        }

        private async Task StartStopAsync()
        {
            if (_pipeline == null || _pipeline.State == PlaybackState.Free)
            {
                StartStopEnabled = false;
                await CreatePipelineAsync();
                StartStopText = "STOP";
                StartStopEnabled = true;
            }
            else
            {
                StartStopEnabled = false;
                await StopPipelineAsync();
                StartStopText = "START";
                StartStopEnabled = true;
            }
        }

        private async Task CreatePipelineAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
            }

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            int width = 1920;
            int height = 1080;
            var fps = VideoFrameRate.FPS_30;

            // Two virtual video sources
            _virtualSource1 = new VirtualVideoSourceBlock(width, height, fps);
            _virtualSource2 = new VirtualVideoSourceBlock(640, 360, fps);

            // PiP dimensions
            int pipWidth = 320;
            int pipHeight = 180;
            int margin = 20;

            var mainRect = new Rect(0, 0, width, height);
            var pipRect = new Rect(width - pipWidth - margin, height - pipHeight - margin, width - margin, height - margin);

            // Create mixer with platform-specific backend
#if __MACOS__ || __MACCATALYST__
            if (MetalVideoCompositorBlock.IsAvailable())
            {
                var settings = new MetalVideoCompositorSettings(width, height, fps);
                settings.AddStream(new MetalVideoMixerStream(mainRect, 0));
                settings.AddStream(new MetalVideoMixerStream(pipRect, 1));
                _mixer = new MetalVideoCompositorBlock(settings);
                Debug.WriteLine("Using Metal video compositor");
            }
            else
#endif
            {
                var settings = new VideoMixerSettings(width, height, fps);
                settings.AddStream(new VideoMixerStream(mainRect, 0));
                settings.AddStream(new VideoMixerStream(pipRect, 1));
                _mixer = new VideoMixerBlock(settings);
                Debug.WriteLine("Using CPU video mixer");
            }

            // Video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoViewIntf) { IsSync = false };

            // Connect pipeline
#if __MACOS__ || __MACCATALYST__
            if (MetalVideoFilterBlock.IsAvailable())
            {
                // Metal filter on source 1: sepia + vignette (cinematic look)
                var filterSettings1 = new MetalVideoFilterSettings
                {
                    Sepia = 0.9,
                    Vignette = 0.5,
                    Contrast = 1.2
                };
                _metalFilter1 = new MetalVideoFilterBlock(filterSettings1);

                // Metal filter on source 2: vibrant look (boosted saturation + sharpness)
                var filterSettings2 = new MetalVideoFilterSettings
                {
                    Saturation = 1.5,
                    Sharpness = 0.3,
                    Brightness = 0.1
                };
                _metalFilter2 = new MetalVideoFilterBlock(filterSettings2);

                _pipeline.Connect(_virtualSource1.Output, _metalFilter1.Input);
                _pipeline.Connect(_metalFilter1.Output, _mixer.Inputs[0]);
                _pipeline.Connect(_virtualSource2.Output, _metalFilter2.Input);
                _pipeline.Connect(_metalFilter2.Output, _mixer.Inputs[1]);

                Debug.WriteLine("Using Metal video filters on both sources");
            }
            else
#endif
            {
                _pipeline.Connect(_virtualSource1.Output, _mixer.Inputs[0]);
                _pipeline.Connect(_virtualSource2.Output, _mixer.Inputs[1]);
            }

            _pipeline.Connect(_mixer.Output, _videoRenderer.Input);

            await _pipeline.StartAsync();
        }

        private async Task StopPipelineAsync()
        {
            if (_pipeline == null)
                return;

            _pipeline.OnError -= Pipeline_OnError;
            await _pipeline.StopAsync();
            await _pipeline.DisposeAsync();
            _pipeline = null;
        }

        private void Pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine($"Pipeline error: {e.Message}");
        }

        public async Task StopAndCleanupAsync()
        {
            if (_isClosing)
                return;

            _isClosing = true;

            await StopPipelineAsync();
            VisioForgeX.DestroySDK();
        }

        private void OnWindowClosing()
        {
            // Kept for backward compatibility; prefer StopAndCleanupAsync
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.Stop();
                _pipeline.Dispose();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }
    }
}
