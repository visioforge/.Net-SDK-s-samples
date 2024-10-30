// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SimpleVideoCaptureMB
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSComboBox cbAudioFormat { get; set; }

		[Outlet]
		AppKit.NSComboBox cbAudioOutput { get; set; }

		[Outlet]
		AppKit.NSComboBox cbAudioSource { get; set; }

		[Outlet]
		AppKit.NSComboBox cbVideoFormat { get; set; }

		[Outlet]
		AppKit.NSComboBox cbVideoFrameRate { get; set; }

		[Outlet]
		AppKit.NSComboBox cbVideoSource { get; set; }

		[Outlet]
		AppKit.NSView videoViewHost { get; set; }

		[Action ("btStartClick:")]
		partial void btStartClick (Foundation.NSObject sender);

		[Action ("btStopClick:")]
		partial void btStopClick (Foundation.NSObject sender);
				
		void ReleaseDesignerOutlets ()
		{
			if (cbAudioFormat != null) {
				cbAudioFormat.Dispose ();
				cbAudioFormat = null;
			}

			if (cbAudioOutput != null) {
				cbAudioOutput.Dispose ();
				cbAudioOutput = null;
			}

			if (cbAudioSource != null) {
				cbAudioSource.Dispose ();
				cbAudioSource = null;
			}

			if (cbVideoFormat != null) {
				cbVideoFormat.Dispose ();
				cbVideoFormat = null;
			}

			if (cbVideoFrameRate != null) {
				cbVideoFrameRate.Dispose ();
				cbVideoFrameRate = null;
			}

			if (cbVideoSource != null) {
				cbVideoSource.Dispose ();
				cbVideoSource = null;
			}

			if (videoViewHost != null) {
				videoViewHost.Dispose ();
				videoViewHost = null;
			}
		}
	}
}
