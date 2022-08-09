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
using VisioForge.Core.Types.GST.VideoEffects;

namespace MediaBlocks_Video_Mixer_Demo
{
    internal class CPUMixerEngine : IMixerEngine
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private FileSourceBlock _source1;

        private FileSourceBlock _source2;

        private VideoMixerBlock _videoMixer;

        private NullRendererBlock _nullRenderer1;

        private NullRendererBlock _nullRenderer2;

        private VideoMixerSettings _settings = new VideoMixerSettings();

        public event EventHandler<ErrorsEventArgs> OnError;

        public void AddStream(Rectangle rect, int zorder)
        {
            _settings.AddStream(new VideoMixerStream(rect, (uint)zorder));
        }

        public async Task StartAsync(string filename1, string filename2, IVideoView videoView)
        {
            _pipeline = new MediaBlocksPipeline(false);
            _pipeline.OnError += _pipeline_OnError;

            _source1 = new FileSourceBlock(filename1);
            _source2 = new FileSourceBlock(filename2) { Name = "Source2" };

            _videoRenderer = new VideoRendererBlock(_pipeline, videoView);

            _videoMixer = new VideoMixerBlock(_settings);

            _pipeline.Connect(_source1.VideoOutput, _videoMixer.Inputs[0]);
            _pipeline.Connect(_source2.VideoOutput, _videoMixer.Inputs[1]);

            _pipeline.Connect(_videoMixer.Output, _videoRenderer.Input);

            _nullRenderer1 = new NullRendererBlock();
            _nullRenderer2 = new NullRendererBlock();
            _pipeline.Connect(_source1.AudioOutput, _nullRenderer1.Input);
            _pipeline.Connect(_source2.AudioOutput, _nullRenderer2.Input);

            await _pipeline.StartAsync();
        }

        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            OnError?.Invoke(this, e);
        }

        public async Task StopAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }

            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;
                _pipeline.Dispose();
                _pipeline = null;
            }
        }
    }
}
