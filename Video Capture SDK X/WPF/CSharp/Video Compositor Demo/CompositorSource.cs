using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;

namespace Video_Compositor_Demo
{
    internal class CompositorSource
    {
        public IVideoMixerSource Source { get; set; }

        public Rect Rectangle { get; set; }

        public bool IsChromaKeyEnabled { get; set; } = false;

        public ChromaKeyColor ChromaColor { get; set; } = ChromaKeyColor.Green;

        public SKColor CustomColor { get; set; } = SKColors.Green;

        public double Sensitivity { get; set; } = 20.0;

        public double NoiseLevel { get; set; } = 2.0;

        public int ZOrder { get; set; } = 0;

        public string DisplayName { get; set; } = "";

        public bool KeepAspectRatio { get; set; } = false;

        public VideoMixerStream MixerStream { get; set; }
    }
}
