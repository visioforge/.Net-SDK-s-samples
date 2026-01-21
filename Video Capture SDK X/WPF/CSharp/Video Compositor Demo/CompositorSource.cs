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
    /// <summary>
    /// Represents a video source and its configuration settings for use within the video compositor.
    /// </summary>
    internal class CompositorSource
    {
        /// <summary>
        /// Gets or sets the video source settings.
        /// </summary>
        public IVideoMixerSource Source { get; set; }

        /// <summary>
        /// Gets or sets the rectangle (position and size) where this source will be rendered in the mixer.
        /// </summary>
        public Rect Rectangle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether chroma key (greenscreen) is enabled for this source.
        /// </summary>
        public bool IsChromaKeyEnabled { get; set; } = false;

        /// <summary>
        /// Gets or sets the predefined chroma key color to filter out.
        /// </summary>
        public ChromaKeyColor ChromaColor { get; set; } = ChromaKeyColor.Green;

        /// <summary>
        /// Gets or sets the custom chroma key color to filter out, if <see cref="ChromaColor"/> is set to Custom.
        /// </summary>
        public SKColor CustomColor { get; set; } = SKColors.Green;

        /// <summary>
        /// Gets or sets the sensitivity of the chroma key effect.
        /// </summary>
        public double Sensitivity { get; set; } = 20.0;

        /// <summary>
        /// Gets or sets the noise level for the chroma key effect.
        /// </summary>
        public double NoiseLevel { get; set; } = 2.0;

        /// <summary>
        /// Gets or sets the Z-order of the source. Higher values appear on top of lower values.
        /// </summary>
        public int ZOrder { get; set; } = 0;

        /// <summary>
        /// Gets or sets the name of the source for display in the UI.
        /// </summary>
        public string DisplayName { get; set; } = "";

        /// <summary>
        /// Gets or sets a value indicating whether to keep the original aspect ratio of the source.
        /// </summary>
        public bool KeepAspectRatio { get; set; } = false;

        /// <summary>
        /// Gets or sets the active mixer stream associated with this source during playback.
        /// </summary>
        public VideoMixerStream MixerStream { get; set; }
    }
}
