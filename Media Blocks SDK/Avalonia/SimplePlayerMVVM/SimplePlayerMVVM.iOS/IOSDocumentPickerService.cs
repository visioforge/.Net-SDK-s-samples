using SimplePlayerMVVMMB;

namespace Simple_Player_MVVM.iOS;

using System;
using System.Threading.Tasks;
using UIKit;
using Foundation;
using MobileCoreServices; // Or UniformTypeIdentifiers in newer iOS versions

public class IOSDocumentPickerService : IDocumentPickerService
{
    TaskCompletionSource<object?>? _tcs;

        /// <summary>
        /// Pick video async.
        /// </summary>
    public Task<object?> PickVideoAsync()
    {
        _tcs = new TaskCompletionSource<object?>();

        // Specify the UTIs (Uniform Type Identifiers) for allowed file types
        // e.g. public.content or public.text, etc.
        string[] allowedUTIs = { UTType.Video, UTType.Movie };
        // Or use new string[] { "public.text", "public.image" } if UTType is not available

        var picker = new UIDocumentPickerViewController(allowedUTIs, UIDocumentPickerMode.Import);
        picker.DidPickDocumentAtUrls += OnDocumentPicked;
        picker.WasCancelled += OnCancelled;

        // Get the topmost view controller
        var window = UIApplication.SharedApplication.KeyWindow;
        var rootVC = window?.RootViewController;
        var topVC = GetTopViewController(rootVC);

        topVC?.PresentViewController(picker, true, null);

        return _tcs.Task;
    }

        /// <summary>
        /// On document picked.
        /// </summary>
    private void OnDocumentPicked(object sender, UIDocumentPickedAtUrlsEventArgs e)
    {
        try
        {
            if (e.Urls != null && e.Urls.Length > 0)
            {
                // Resolve the security-scoped URL so you can access it
                NSUrl fileUrl = e.Urls[0];
                if (fileUrl != null)
                {
                    _tcs?.TrySetResult(fileUrl);
                    return;
                }
            }

            _tcs?.TrySetResult(null);
        }
        catch
        {
            _tcs?.TrySetResult(null);
        }
    }

        /// <summary>
        /// Handles the on cancelled event.
        /// </summary>
    private void OnCancelled(object sender, EventArgs e)
    {
        _tcs?.TrySetResult(null);
    }

    // Utility to get topmost ViewController
    private UIViewController? GetTopViewController(UIViewController? vc)
    {
        if (vc == null)
            return null;

        if (vc.PresentedViewController != null)
            return GetTopViewController(vc.PresentedViewController);

        if (vc is UINavigationController navController)
            return GetTopViewController(navController.VisibleViewController);

        if (vc is UITabBarController tabBarController)
            return GetTopViewController(tabBarController.SelectedViewController);

        return vc;
    }
}