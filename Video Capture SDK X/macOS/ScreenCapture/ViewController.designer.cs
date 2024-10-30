// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ScreenCaptureMB
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField lbDurationX { get; set; }

		[Outlet]
		AppKit.NSView pnVideoViewX { get; set; }

		[Action ("btStartClickX:")]
		partial void btStartClickX (Foundation.NSObject sender);

		[Action ("btStopClickX:")]
		partial void btStopClickX (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (pnVideoViewX != null) {
				pnVideoViewX.Dispose ();
				pnVideoViewX = null;
			}

			if (lbDurationX != null) {
				lbDurationX.Dispose ();
				lbDurationX = null;
			}
		}
	}
}
