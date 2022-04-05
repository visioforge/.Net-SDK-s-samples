using System;

using AppKit;
using Foundation;

using VisioForge.Core.MediaPlayerGST;
using System.Diagnostics;

namespace MediaPlayerSDKSimpleDemo
{
    public partial class ViewController : NSViewController
    {
        private MediaPlayerGST _mediaPlayer;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Debug.WriteLine(VisioForge.GStreamer.API.DLL.GstAudio);

            // Do any additional setup after loading the view.
            _mediaPlayer = new MediaPlayerGST();
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
