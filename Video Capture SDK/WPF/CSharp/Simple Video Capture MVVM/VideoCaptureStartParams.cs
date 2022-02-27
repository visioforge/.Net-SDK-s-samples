using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.Types.VideoCapture;

namespace Simple_Video_Capture
{
    public class VideoCaptureStartParams
    {
        public bool DebugMode { get; set; }
        public string DebugDirectory { get; set; }
        public bool RecordAudio { get; set; }
        public VideoCaptureSource VideoCaptureDevice { get; set; }
        public AudioCaptureSource AudioCaptureDevice { get; set; }
        public string AudioOutputDevice { get; set; }
        public bool Preview { get; set; }
        public string OutputFileName { get; set; }
        public OutputFormatInfoTag OutputFormat { get; set; }
        public bool MergeImageLogos { get; set; }
        public bool MergeTextLogos { get; set; }
    }
}
