using DVS_MAUI.Services;
using Foundation;
using UIKit;

namespace DVS_MAUI.Platforms.MacCatalyst;

/// <summary>
/// Mac Catalyst-specific implementation of the folder picker.
/// </summary>
/// <remarks>
/// Mac Catalyst cannot directly use AppKit NSOpenPanel. 
/// This implementation uses UIDocumentPickerViewController which is available in Mac Catalyst.
/// </remarks>
public class FolderPickerImplementation : IFolderPicker
{
    /// <summary>
    /// Opens a Mac Catalyst folder picker dialog using UIDocumentPickerViewController and returns the selected folder path.
    /// </summary>
    /// <param name="title">Title for the folder picker dialog.</param>
    /// <param name="initialPath">Optional initial path to start browsing from.</param>
    /// <returns>The selected folder path, or null if cancelled.</returns>
    public async Task<string> PickFolderAsync(string title, string initialPath = null)
    {
        var tcs = new TaskCompletionSource<string>();

        await Microsoft.Maui.Controls.Application.Current.Dispatcher.DispatchAsync(async () =>
        {
            try
            {
                // For Mac Catalyst, we use UIDocumentPickerViewController with folder selection
                // Use the newer constructor that takes UTType directly (iOS 14+)
                var documentPicker = new UIDocumentPickerViewController(
                    new[] { UniformTypeIdentifiers.UTTypes.Folder },
                    asCopy: false); // false = open/access, true = copy
                
                documentPicker.AllowsMultipleSelection = false;
                documentPicker.ShouldShowFileExtensions = false;
                
                // Set initial directory if provided and valid
                if (!string.IsNullOrEmpty(initialPath) && Directory.Exists(initialPath))
                {
                    documentPicker.DirectoryUrl = NSUrl.FromFilename(initialPath);
                }

                // Create delegate to handle selection
                var pickerDelegate = new FolderPickerDelegate(tcs);
                documentPicker.Delegate = pickerDelegate;

                // Get the current view controller
                var currentViewController = Platform.GetCurrentUIViewController();
                if (currentViewController != null)
                {
                    await currentViewController.PresentViewControllerAsync(documentPicker, true);
                }
                else
                {
                    tcs.SetResult(null);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in FolderPickerImplementation: {ex.Message}");
                tcs.SetResult(null);
            }
        });

        return await tcs.Task;
    }

    /// <summary>
    /// Delegate class to handle UIDocumentPickerViewController events.
    /// </summary>
    private class FolderPickerDelegate : UIDocumentPickerDelegate
    {
        private readonly TaskCompletionSource<string> _tcs;

        public FolderPickerDelegate(TaskCompletionSource<string> tcs)
        {
            _tcs = tcs;
        }

        public override void DidPickDocument(UIDocumentPickerViewController controller, NSUrl[] urls)
        {
            if (urls != null && urls.Length > 0)
            {
                var url = urls[0];
                _tcs.SetResult(url?.Path);
            }
            else
            {
                _tcs.SetResult(null);
            }
            controller.DismissViewController(true, null);
        }

        public override void WasCancelled(UIDocumentPickerViewController controller)
        {
            _tcs.SetResult(null);
            controller.DismissViewController(true, null);
        }
    }
}