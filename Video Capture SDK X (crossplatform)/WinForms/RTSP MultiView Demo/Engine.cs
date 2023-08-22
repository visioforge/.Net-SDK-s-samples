using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.Types;
using VisioForge.Core.VideoCaptureX;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    internal class Engine
    {
        public VideoCaptureCoreX Core { get; }

        public string URL { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool AudioEnabled { get; set; }

        public string Filename { get; set; }

        public Engine(IVideoView view)
        {
            Core = new VideoCaptureCoreX(view);
        }
    }
}
