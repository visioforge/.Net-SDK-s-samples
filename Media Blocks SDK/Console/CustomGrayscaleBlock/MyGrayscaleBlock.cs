using System;
using Gst;
using VisioForge.Core.MediaBlocks;

namespace CustomGrayscaleBlockSample
{
    /// <summary>
    /// Example user-authored MediaBlock that wraps the GStreamer "videobalance"
    /// element with saturation = 0 to convert color video into grayscale.
    ///
    /// This block demonstrates the canonical pattern for writing a typed
    /// MediaBlock on top of a single GStreamer element, using only the public
    /// surface of the SDK (MediaBlock, IMediaBlockInternals, MediaBlockPad).
    /// </summary>
    public class MyGrayscaleBlock : MediaBlock, IMediaBlockInternals
    {
        private const string TAG = "MyGrayscaleBlock";

        private Element _element;
        private readonly MediaBlockPad _inputPad;
        private readonly MediaBlockPad _outputPad;

        /// <summary>
        /// MediaBlockType.Custom is the catch-all type used by user-authored
        /// blocks; the SDK does not require a dedicated enum value per block.
        /// </summary>
        public override MediaBlockType Type => MediaBlockType.Custom;

        /// <inheritdoc/>
        public override MediaBlockPad Input => _inputPad;

        /// <inheritdoc/>
        public override MediaBlockPad[] Inputs => new[] { _inputPad };

        /// <inheritdoc/>
        public override MediaBlockPad Output => _outputPad;

        /// <inheritdoc/>
        public override MediaBlockPad[] Outputs => new[] { _outputPad };

        /// <summary>
        /// Initializes a new instance of <see cref="MyGrayscaleBlock"/>.
        /// The underlying GStreamer element is NOT created here — element
        /// creation happens in <see cref="Build"/>, which the pipeline calls
        /// during <c>StartAsync</c>.
        /// </summary>
        public MyGrayscaleBlock()
        {
            Name = "MyGrayscale";

            _inputPad = new MediaBlockPad(this, MediaBlockPadDirection.In, MediaBlockPadMediaType.Video);
            _outputPad = new MediaBlockPad(this, MediaBlockPadDirection.Out, MediaBlockPadMediaType.Video);
        }

        /// <summary>
        /// Returns true when the underlying GStreamer element ("videobalance")
        /// is present in the current GStreamer registry. Call this before
        /// constructing the block if you need to fail fast on platforms where
        /// the plugin is missing.
        /// </summary>
        public static bool IsAvailable()
        {
            var factory = ElementFactory.Find("videobalance");
            if (factory == null)
            {
                return false;
            }

            factory.Dispose();
            return true;
        }

        /// <summary>
        /// Creates the GStreamer element, configures it, adds it to the
        /// pipeline, and binds the block's MediaBlockPads to the element's
        /// static pads. Invoked by the pipeline during preload/start.
        /// </summary>
        public override bool Build()
        {
            if (_isBuilt)
            {
                return true;
            }

            _element = ElementFactory.Make("videobalance", $"videobalance_{Guid.NewGuid():N}");
            if (_element == null)
            {
                Context?.Error(TAG, "Build", "Unable to create videobalance element.");
                return false;
            }

            // videobalance.saturation is a gdouble — match the type exactly,
            // otherwise SetProperty is a silent no-op.
            _element.SetProperty("saturation", new GLib.Value(0.0));

            _pipelineCtx.Pipeline.Add(_element);

            var sink = _element.GetStaticPad("sink");
            var src = _element.GetStaticPad("src");
            if (sink == null || src == null)
            {
                Context?.Error(TAG, "Build", "Unable to retrieve videobalance static pads.");
                _pipelineCtx.Pipeline.Remove(_element);
                _element.Dispose();
                _element = null;
                return false;
            }

            _inputPad.SetInternalPad(sink);
            _outputPad.SetInternalPad(src);

            _isBuilt = true;
            return true;
        }

        void IMediaBlockInternals.SetContext(MediaBlocksPipeline pipeline)
        {
            SetPipeline(pipeline);
            Context = pipeline.GetContext();
        }

        bool IMediaBlockInternals.Build() => Build();

        Gst.Element IMediaBlockInternals.GetElement() => _element;

        VisioForge.Core.GStreamer.Base.BaseElement IMediaBlockInternals.GetCore() => null;

        /// <summary>
        /// Disposes the underlying GStreamer element. Called by the pipeline
        /// during teardown via <see cref="IMediaBlockInternals.CleanUp"/>.
        /// </summary>
        public void CleanUp()
        {
            _element?.Dispose();
            _element = null;
        }

        /// <summary>
        /// Releases managed and unmanaged resources owned by this block.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                CleanUp();
            }

            base.Dispose(disposing);
        }
    }
}
