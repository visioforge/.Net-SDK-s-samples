using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;

namespace MediaBlocks_Video_Mixer_Demo
{
    /// <summary>
    /// The CPU mixer engine.
    /// </summary>
    internal class CPUMixerEngine : IMixerEngine
    {
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The first source.
        /// </summary>
        private UniversalSourceBlock _source1;

        /// <summary>
        /// The second source.
        /// </summary>
        private UniversalSourceBlock _source2;

        /// <summary>
        /// The video mixer.
        /// </summary>
        private VideoMixerBlock _videoMixer;

        /// <summary>
        /// The first null renderer.
        /// </summary>
        private NullRendererBlock _nullRenderer1;

        /// <summary>
        /// The second null renderer.
        /// </summary>
        private NullRendererBlock _nullRenderer2;

        /// <summary>
        /// The settings.
        /// </summary>
        private VideoMixerSettings _settings;

        /// <summary>
        /// Occurs when an error happens.
        /// </summary>
        public event EventHandler<ErrorsEventArgs> OnError;

        /// <summary>
        /// Initializes a new instance of the <see cref="CPUMixerEngine"/> class.
        /// </summary>
        public CPUMixerEngine()
        {
            _settings = new VideoMixerSettings(0, 0, VideoFrameRate.Empty);
        }

        /// <summary>
        /// Add stream.
        /// </summary>
        public void AddStream(Rect rect, uint zorder)
        {
            _settings.AddStream(new VideoMixerStream(rect, zorder));
        }

        /// <summary>
        /// Start async.
        /// </summary>
        public async Task StartAsync(string filename1, string filename2, IVideoView videoView)
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;

            var source1Settings = await UniversalSourceSettings.CreateAsync(filename1);
            _source1 = new UniversalSourceBlock(source1Settings);

            var source2settings = await UniversalSourceSettings.CreateAsync(filename2);
            _source2 = new UniversalSourceBlock(source2settings) { Name = "Source2" };

            var info = source1Settings.GetInfo().GetVideoInfo();
            _settings.Width = info.Width;
            _settings.Height = info.Height;
            _settings.FrameRate = info.FrameRate;

            _videoRenderer = new VideoRendererBlock(_pipeline, videoView) { IsSync = false };

            _videoMixer = new VideoMixerBlock(_settings);

            _pipeline.Connect(_source1.VideoOutput, _videoMixer.Inputs[0]);
            _pipeline.Connect(_source2.VideoOutput, _videoMixer.Inputs[1]);

            _pipeline.Connect(_videoMixer.Output, _videoRenderer.Input);

            _nullRenderer1 = new NullRendererBlock(MediaBlockPadMediaType.Video);
            _nullRenderer2 = new NullRendererBlock(MediaBlockPadMediaType.Video);
            _pipeline.Connect(_source1.AudioOutput, _nullRenderer1.Input);
            _pipeline.Connect(_source2.AudioOutput, _nullRenderer2.Input);

            await _pipeline.StartAsync();
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            OnError?.Invoke(this, e);
        }

        /// <summary>
        /// Stop async.
        /// </summary>
        public async Task StopAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync(true);
            }

            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }
    }
}
