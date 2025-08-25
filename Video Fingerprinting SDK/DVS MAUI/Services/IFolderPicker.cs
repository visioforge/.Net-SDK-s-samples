namespace DVS_MAUI.Services;

/// <summary>
/// Interface for platform-specific folder picker implementations.
/// </summary>
public interface IFolderPicker
{
    /// <summary>
    /// Opens a folder picker dialog and returns the selected folder path.
    /// </summary>
    /// <param name="title">Title for the folder picker dialog.</param>
    /// <param name="initialPath">Optional initial path to start browsing from.</param>
    /// <returns>The selected folder path, or null if cancelled.</returns>
    Task<string> PickFolderAsync(string title, string initialPath = null);
}