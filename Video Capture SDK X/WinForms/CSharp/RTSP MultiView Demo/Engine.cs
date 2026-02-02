using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.Types;
using VisioForge.Core.VideoCaptureX;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    /// <summary>
    /// Represents a single video capture engine instance for a specific camera view.
    /// Manages its own VideoCaptureCoreX core and associated stream settings.
    /// </summary>
    internal class Engine
    {
        /// <summary>
        /// Gets the video capture core instance.
        /// </summary>
        public VideoCaptureCoreX Core { get; }

        /// <summary>
        /// Gets or sets the RTSP/MJPEG stream URL.
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets the login username for the stream.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the login password for the stream.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether audio is enabled for this engine.
        /// </summary>
        public bool AudioEnabled { get; set; }

        /// <summary>
        /// Gets or sets the output filename for capture.
        /// </summary>
        public string Filename { get; set; }

        public Engine(IVideoView view)
        {
            Core = new VideoCaptureCoreX(view);
        }
    }
}
