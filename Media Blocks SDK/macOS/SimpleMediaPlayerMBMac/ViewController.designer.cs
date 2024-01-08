// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SimpleMediaPlayerMBMac
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField edFilename { get; set; }

		[Outlet]
		AppKit.NSSlider slPosition { get; set; }

		[Outlet]
		AppKit.NSView videoViewHost { get; set; }

		[Action ("btOpen_Click:")]
		partial void btOpen_Click (Foundation.NSObject sender);

		[Action ("btStart_Click:")]
		partial void btStart_Click (Foundation.NSObject sender);

		[Action ("btStop_Click:")]
		partial void btStop_Click (Foundation.NSObject sender);

		[Action ("slPositionChanged:")]
		partial void slPositionChanged (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (edFilename != null) {
				edFilename.Dispose ();
				edFilename = null;
			}

			if (slPosition != null) {
				slPosition.Dispose ();
				slPosition = null;
			}

			if (videoViewHost != null) {
				videoViewHost.Dispose ();
				videoViewHost = null;
			}
		}
	}
}
