using DVS_MAUI.Services;
using Windows.Storage.Pickers;
using WinRT.Interop;

namespace DVS_MAUI.Platforms.Windows;

/// <summary>
/// Windows-specific implementation of the folder picker using Windows.Storage.Pickers.
/// </summary>
public class FolderPickerImplementation : IFolderPicker
{
    /// <summary>
    /// Opens a Windows folder picker dialog and returns the selected folder path.
    /// </summary>
    /// <param name="title">Title for the folder picker dialog.</param>
    /// <param name="initialPath">Optional initial path to start browsing from.</param>
    /// <returns>The selected folder path, or null if cancelled.</returns>
    public async Task<string> PickFolderAsync(string title, string initialPath = null)
    {
        var folderPicker = new FolderPicker();
        
        // Get the current window handle
        var window = Microsoft.Maui.Controls.Application.Current?.Windows?.FirstOrDefault()?.Handler?.PlatformView as Microsoft.UI.Xaml.Window;
        if (window != null)
        {
            var hwnd = WindowNative.GetWindowHandle(window);
            InitializeWithWindow.Initialize(folderPicker, hwnd);
        }

        // Configure the picker
        folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
        folderPicker.FileTypeFilter.Add("*");
        folderPicker.ViewMode = PickerViewMode.List;
        
        // Show the picker
        var folder = await folderPicker.PickSingleFolderAsync();
        
        return folder?.Path;
    }
}