using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Video_Capture
{
    public class VideoCaptureStartParams
    {
        public bool DebugMode { get; set; }
        public string DebugDirectory { get; set; }
        public bool RecordAudio { get; set; }
        public string VideoCaptureDevice { get; set; }
        public bool VideoCaptureDeviceIsAudioSource { get; set; }
        public string VideoCaptureFormat { get; set; }
        public bool VideoCaptureFormatUseBest { get; set; }
        public string AudioCaptureDevice { get; set; }
        public string AudioCaptureDeviceFormat { get; set; }
        public bool AudioCaptureDeviceFormatUseBest { get; set; }
        public string AudioOutputDevice { get; set; }
        public double VideoFrameRate { get; set; }
        public bool Preview { get; set; }
        public string OutputFileName { get; set; }
        public OutputFormatInfoTag OutputFormat { get; set; }
        public bool MergeImageLogos { get; set; }
        public bool MergeTextLogos { get; set; }
    }
}
