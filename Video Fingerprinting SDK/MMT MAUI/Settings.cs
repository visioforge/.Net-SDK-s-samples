using System.Reflection;
using System.Text.Json;

namespace MMT_MAUI
{
    /// <summary>
    /// Application settings with persistence support.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Gets or sets the last used path.
        /// </summary>
        public static string LastPath { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ignored folders.
        /// </summary>
        public static string IgnoredFolders { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ignored areas.
        /// </summary>
        public static string IgnoredAreas { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the difference threshold.
        /// </summary>
        public static int Difference { get; set; } = 500;

        /// <summary>
        /// Gets the settings folder path.
        /// </summary>
        public static string SettingsFolder =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VisioForge MMT MAUI");

        /// <summary>
        /// Gets the settings file path.
        /// </summary>
        private static string SettingsFilePath => Path.Combine(SettingsFolder, "settings.json");

        /// <summary>
        /// Saves settings to disk.
        /// </summary>
        public static bool Save()
        {
            try
            {
                Directory.CreateDirectory(SettingsFolder);

                var settingsDict = new Dictionary<string, object?>
                {
                    [nameof(LastPath)] = LastPath,
                    [nameof(IgnoredFolders)] = IgnoredFolders,
                    [nameof(IgnoredAreas)] = IgnoredAreas,
                    [nameof(Difference)] = Difference
                };

                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(settingsDict, options);
                File.WriteAllText(SettingsFilePath, json);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save settings: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Loads settings from disk.
        /// </summary>
        public static bool Load()
        {
            try
            {
                if (!File.Exists(SettingsFilePath))
                {
                    return false;
                }

                string json = File.ReadAllText(SettingsFilePath);
                var settingsDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

                if (settingsDict == null)
                {
                    return false;
                }

                if (settingsDict.TryGetValue(nameof(LastPath), out var lastPath))
                    LastPath = lastPath.GetString() ?? string.Empty;

                if (settingsDict.TryGetValue(nameof(IgnoredFolders), out var ignoredFolders))
                    IgnoredFolders = ignoredFolders.GetString() ?? string.Empty;

                if (settingsDict.TryGetValue(nameof(IgnoredAreas), out var ignoredAreas))
                    IgnoredAreas = ignoredAreas.GetString() ?? string.Empty;

                if (settingsDict.TryGetValue(nameof(Difference), out var difference))
                    Difference = difference.GetInt32();

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to load settings: {ex.Message}");
                return false;
            }
        }
    }
}