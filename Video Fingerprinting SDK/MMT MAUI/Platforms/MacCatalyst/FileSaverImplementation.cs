using MMT_MAUI.Services;
using Foundation;
using UIKit;
using UniformTypeIdentifiers;

namespace MMT_MAUI.Platforms.MacCatalyst;

/// <summary>
/// Mac Catalyst-specific implementation of the file saver.
/// </summary>
public class FileSaverImplementation : IFileSaver
{
    /// <summary>
    /// Opens a Mac Catalyst file save dialog using UIDocumentPickerViewController and returns the selected file path.
    /// </summary>
    /// <param name="suggestedFileName">Suggested file name for the save dialog.</param>
    /// <param name="fileTypes">Dictionary of file type descriptions and their extensions.</param>
    /// <returns>The selected file path, or null if cancelled.</returns>
    public async Task<string> SaveFileAsync(string suggestedFileName, Dictionary<string, List<string>> fileTypes)
    {
        var tcs = new TaskCompletionSource<string>();

        await Microsoft.Maui.Controls.Application.Current.Dispatcher.DispatchAsync(async () =>
        {
            try
            {
                // Create a temporary file with the suggested name
                var tempPath = Path.Combine(Path.GetTempPath(), suggestedFileName);
                
                // Create an empty file temporarily (required for UIDocumentPickerViewController in export mode)
                await File.WriteAllTextAsync(tempPath, string.Empty);
                var tempUrl = NSUrl.FromFilename(tempPath);

                // Create content types from file extensions
                var contentTypes = new List<UTType>();
                if (fileTypes != null)
                {
                    foreach (var fileType in fileTypes)
                    {
                        foreach (var extension in fileType.Value)
                        {
                            // Remove the dot if present
                            var ext = extension.TrimStart('.');
                            
                            // Try to get UTType from file extension
                            var utType = UTType.CreateFromExtension(ext);
                            if (utType != null)
                            {
                                contentTypes.Add(utType);
                            }
                        }
                    }
                }

                // If no valid content types found, use generic data
                if (contentTypes.Count == 0)
                {
                    contentTypes.Add(UTTypes.Data);
                }

                // Create document picker for export (saving)
                // Use the newer constructor that takes asCopy parameter
                var documentPicker = new UIDocumentPickerViewController(
                    new[] { tempUrl },
                    asCopy: false); // false means move/export, true means copy

                // Create delegate to handle selection
                var pickerDelegate = new FileSaverDelegate(tcs, tempPath);
                documentPicker.Delegate = pickerDelegate;
                documentPicker.ShouldShowFileExtensions = true;

                // Get the current view controller
                var currentViewController = Platform.GetCurrentUIViewController();
                if (currentViewController != null)
                {
                    await currentViewController.PresentViewControllerAsync(documentPicker, true);
                }
                else
                {
                    // Clean up temp file if we can't show the picker
                    if (File.Exists(tempPath))
                    {
                        File.Delete(tempPath);
                    }
                    tcs.SetResult(null);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in FileSaverImplementation: {ex.Message}");
                tcs.SetResult(null);
            }
        });

        return await tcs.Task;
    }

    /// <summary>
    /// Delegate class to handle UIDocumentPickerViewController events for file saving.
    /// </summary>
    private class FileSaverDelegate : UIDocumentPickerDelegate
    {
        private readonly TaskCompletionSource<string> _tcs;
        private readonly string _tempPath;

        public FileSaverDelegate(TaskCompletionSource<string> tcs, string tempPath)
        {
            _tcs = tcs;
            _tempPath = tempPath;
        }

        public override void DidPickDocument(UIDocumentPickerViewController controller, NSUrl[] urls)
        {
            try
            {
                if (urls != null && urls.Length > 0)
                {
                    var url = urls[0];
                    
                    // Start accessing security-scoped resource
                    if (url.StartAccessingSecurityScopedResource())
                    {
                        try
                        {
                            // Get the selected path
                            var selectedPath = url.Path;
                            
                            // Copy the temp file content to the selected location if needed
                            // The document picker in export mode should handle this automatically
                            
                            _tcs.SetResult(selectedPath);
                        }
                        finally
                        {
                            // Stop accessing the security-scoped resource
                            url.StopAccessingSecurityScopedResource();
                        }
                    }
                    else
                    {
                        _tcs.SetResult(url?.Path);
                    }
                }
                else
                {
                    _tcs.SetResult(null);
                }
            }
            finally
            {
                // Clean up temporary file
                CleanupTempFile();
                controller.DismissViewController(true, null);
            }
        }

        public override void WasCancelled(UIDocumentPickerViewController controller)
        {
            _tcs.SetResult(null);
            CleanupTempFile();
            controller.DismissViewController(true, null);
        }

        private void CleanupTempFile()
        {
            try
            {
                if (File.Exists(_tempPath))
                {
                    File.Delete(_tempPath);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cleaning up temp file: {ex.Message}");
            }
        }
    }
}