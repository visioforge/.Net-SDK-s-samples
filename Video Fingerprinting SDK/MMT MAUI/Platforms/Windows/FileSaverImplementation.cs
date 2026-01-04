using Windows.Storage;
using Windows.Storage.Pickers;
using MMT_MAUI.Services;
using WinRT.Interop;

namespace MMT_MAUI.Platforms.Windows
{
    public class FileSaverImplementation : IFileSaver
    {
        public async Task<string?> SaveFileAsync(string suggestedFileName, Dictionary<string, List<string>> fileTypes)
        {
            try
            {
                var savePicker = new FileSavePicker();
                
                // Get the current window handle
                var window = App.Current?.Windows[0]?.Handler?.PlatformView as MauiWinUIWindow;
                if (window == null)
                {
                    return null;
                }
                var windowHandle = window.WindowHandle;
                InitializeWithWindow.Initialize(savePicker, windowHandle);

                savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                savePicker.SuggestedFileName = suggestedFileName;

                // Add file type choices
                if (fileTypes != null && fileTypes.Count > 0)
                {
                    foreach (var fileType in fileTypes)
                    {
                        savePicker.FileTypeChoices.Add(fileType.Key, fileType.Value);
                    }
                }
                else
                {
                    // Default to all files if no types specified
                    savePicker.FileTypeChoices.Add("All Files", new List<string>() { "*" });
                }

                var file = await savePicker.PickSaveFileAsync();
                if (file != null)
                {
                    return file.Path;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in SaveFileAsync: {ex.Message}");
            }

            return null;
        }
    }
}