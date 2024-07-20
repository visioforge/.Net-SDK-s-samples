﻿using System;
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
    internal class D3D11MixerEngine : IMixerEngine
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private UniversalSourceBlock _source1;

        private UniversalSourceBlock _source2;

        private VideoMixerBlock _videoMixer;

        private NullRendererBlock _nullRenderer1;

        private NullRendererBlock _nullRenderer2;

        private D3D11VideoCompositorSettings _settings = new D3D11VideoCompositorSettings(0, 0, VideoFrameRate.Empty);

        public event EventHandler<ErrorsEventArgs> OnError;

        public void AddStream(Rect rect, uint zorder)
        {
            _settings.Streams.Add(new D3D11VideoCompositorStream(rect, zorder));
        }

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
