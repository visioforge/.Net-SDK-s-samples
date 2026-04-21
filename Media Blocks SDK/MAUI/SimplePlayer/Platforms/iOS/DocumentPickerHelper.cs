#if IOS && !MACCATALYST
using System;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using UniformTypeIdentifiers;

namespace Simple_Player_MB_MAUI.Platforms.iOS
{
    /// <summary>
    /// iOS-native file picker that returns the original security-scoped NSUrl
    /// handed to us by UIDocumentPickerViewController. MAUI's FilePicker drops
    /// the scoped bookmark and only exposes a raw path string, so a fresh
    /// NSUrl.FromFilename(path) has no sandbox grant — reads work once through
    /// the picker's short "discretionary" window and then fail on subsequent
    /// Open of the same file (IOSHelper.CheckFileAccess throws "Unable to
    /// access file"). Returning the original NSUrl lets the caller hold
    /// StartAccessingSecurityScopedResource open for the whole playback session.
    /// </summary>
    public sealed class DocumentPickerHelper : NSObject, IUIDocumentPickerDelegate
    {
        private TaskCompletionSource<NSUrl?>? _tcs;

        // Strong reference to the delegate instance itself so ObjC doesn't release it mid-pick
        // (the picker only keeps a weak delegate reference, and the local in ShowAsync goes out
        // of scope as soon as the method returns).
        private static DocumentPickerHelper? s_pinnedHelper;

        // Strong managed reference to the picked NSUrl. MUST live at least until the caller is
        // done reading the file — without it, AVAsset.FromUrl later throws ObjectDisposedException
        // because the Xamarin NSUrl wrapper loses its native handle after picker dismissal.
        private NSUrl? _heldUrl;

        /// <summary>
        /// Presents a video-only document picker and resolves with the selected
        /// security-scoped NSUrl, or null if the user cancelled.
        /// </summary>
        public static Task<NSUrl?> PickVideoAsync()
        {
            // Replace any previous helper — ObjC keeps a weak delegate reference to the picker,
            // so the .NET wrapper must remain rooted until didPick…/wasCancelled fires.
            s_pinnedHelper = new DocumentPickerHelper();
            return s_pinnedHelper.ShowAsync();
        }

        private Task<NSUrl?> ShowAsync()
        {
            _tcs = new TaskCompletionSource<NSUrl?>(TaskCreationOptions.RunContinuationsAsynchronously);

            var types = new[] { UTTypes.Movie, UTTypes.Video, UTTypes.QuickTimeMovie, UTTypes.Mpeg4Movie };
            // asCopy: true makes iOS hardlink/copy the picked file into our app's Inbox. The
            // resulting NSUrl is a normal sandbox file URL with a stable path, no security-scope
            // bookmark dance needed. We tried asCopy:false (keep original security-scoped URL),
            // but Xamarin's NSUrl wrapper loses its native handle after picker dismissal and
            // AVAsset.FromUrl / GStreamer filesrc subsequently throw ObjectDisposedException.
            // iOS copies via file-provider coordinator — for iCloud / Files this is near-free
            // (APFS clone on same volume), so we're not duplicating hundreds of MB on disk.
            var picker = new UIDocumentPickerViewController(types, asCopy: true);
            picker.Delegate = this;
            picker.AllowsMultipleSelection = false;

            var scene = UIApplication.SharedApplication.ConnectedScenes
                .OfType<UIWindowScene>()
                .FirstOrDefault(s => s.ActivationState == UISceneActivationState.ForegroundActive);
            var keyWindow = scene?.KeyWindow ?? scene?.Windows.FirstOrDefault();
            var top = keyWindow?.RootViewController;
            while (top?.PresentedViewController != null)
            {
                top = top.PresentedViewController;
            }

            if (top == null)
            {
                _tcs.TrySetResult(null);
                return _tcs.Task;
            }

            top.PresentViewController(picker, true, null);
            return _tcs.Task;
        }

        [Export("documentPicker:didPickDocumentsAtURLs:")]
        public void DidPickDocuments(UIDocumentPickerViewController controller, NSUrl[] urls)
        {
            var url = urls.FirstOrDefault();
            if (url == null)
            {
                _tcs?.TrySetResult(null);
                return;
            }

            // Pin a strong managed reference so the Xamarin wrapper doesn't get collected
            // between the picker callback and GStreamer's AVAsset.FromUrl call. Without this,
            // AVAsset.FromUrl throws ObjectDisposedException("Foundation.NSUrl") once ObjC
            // releases the short-lived picker URL after dismissal.
            _heldUrl = url;
            _tcs?.TrySetResult(url);
        }

        [Export("documentPickerWasCancelled:")]
        public void WasCancelled(UIDocumentPickerViewController controller)
        {
            _tcs?.TrySetResult(null);
        }
    }
}
#endif
