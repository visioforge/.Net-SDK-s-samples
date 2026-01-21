using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.Types.VideoCapture;

namespace Simple_Video_Capture
{
    /// <summary>
    /// Video capture start parameters.
    /// </summary>
    public class VideoCaptureStartParams
    {
        /// <summary>
        /// Gets or sets a value indicating whether debug mode is enabled.
        /// </summary>
        public bool DebugMode { get; set; }

        /// <summary>
        /// Gets or sets the debug directory.
        /// </summary>
        public string DebugDirectory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to record audio.
        /// </summary>
        public bool RecordAudio { get; set; }

        /// <summary>
        /// Gets or sets the video capture device.
        /// </summary>
        public VideoCaptureSource VideoCaptureDevice { get; set; }

        /// <summary>
        /// Gets or sets the audio capture device.
        /// </summary>
        public AudioCaptureSource AudioCaptureDevice { get; set; }

        /// <summary>
        /// Gets or sets the audio output device.
        /// </summary>
        public string AudioOutputDevice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether preview is enabled.
        /// </summary>
        public bool Preview { get; set; }

        /// <summary>
        /// Gets or sets the output file name.
        /// </summary>
        public string OutputFileName { get; set; }

        /// <summary>
        /// Gets or sets the output format.
        /// </summary>
        public OutputFormatInfoTag OutputFormat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to merge image logos.
        /// </summary>
        public bool MergeImageLogos { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to merge text logos.
        /// </summary>
        public bool MergeTextLogos { get; set; }
    }
}
