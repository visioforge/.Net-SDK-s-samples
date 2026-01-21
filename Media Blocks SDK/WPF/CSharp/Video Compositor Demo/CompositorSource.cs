using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.VideoEffects;

namespace Video_Compositor_Demo
{
    /// <summary>
    /// Compositor source helper class.
    /// </summary>
    internal class CompositorSource
    {
        /// <summary>
        /// Gets or sets the source block.
        /// </summary>
        public MediaBlock Source { get; set; }

        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        public Rect Rectangle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether chroma key is enabled.
        /// </summary>
        public bool IsChromaKeyEnabled { get; set; } = false;

        /// <summary>
        /// Gets or sets the chroma key color.
        /// </summary>
        public ChromaKeyColor ChromaColor { get; set; } = ChromaKeyColor.Green;

        /// <summary>
        /// Gets or sets the custom chroma key color.
        /// </summary>
        public SKColor CustomColor { get; set; } = SKColors.Green;

        /// <summary>
        /// Gets or sets the sensitivity.
        /// </summary>
        public double Sensitivity { get; set; } = 20.0;

        /// <summary>
        /// Gets or sets the noise level.
        /// </summary>
        public double NoiseLevel { get; set; } = 2.0;

        /// <summary>
        /// Gets or sets the z-order.
        /// </summary>
        public int ZOrder { get; set; } = 0;

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether to keep the aspect ratio.
        /// </summary>
        public bool KeepAspectRatio { get; set; } = false;

        /// <summary>
        /// Gets or sets the mixer stream.
        /// </summary>
        public VideoMixerStream MixerStream { get; set; }
    }
}
