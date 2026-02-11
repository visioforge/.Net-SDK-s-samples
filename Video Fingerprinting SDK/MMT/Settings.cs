using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System;

namespace VisioForge_MMT.Classes
{
    /// <summary>
    /// Settings.
    /// </summary>
    public static class Settings
    {
        #region Serialize
        /// <summary>
        /// Save.
        /// </summary>
        public static bool Save(Type staticClass, string filename)
        {
            try
            {
                var path = Path.GetDirectoryName(filename);
                if (!string.IsNullOrEmpty(path))
                {
                    Directory.CreateDirectory(path);
                }

                FieldInfo[] fields = staticClass.GetFields(BindingFlags.Static | BindingFlags.Public);
                var settingsDict = new Dictionary<string, object>();

                foreach (FieldInfo field in fields)
                {
                    settingsDict[field.Name] = field.GetValue(null);
                }

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(settingsDict, options);
                File.WriteAllText(filename, jsonString);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save settings: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Load.
        /// </summary>
        public static bool Load(Type staticClass, string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    return false;
                }

                string jsonString = File.ReadAllText(filename);
                var options = new JsonSerializerOptions();
                var settingsDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString, options);

                if (settingsDict == null)
                {
                    return false;
                }

                FieldInfo[] fields = staticClass.GetFields(BindingFlags.Static | BindingFlags.Public);

                foreach (FieldInfo field in fields)
                {
                    if (settingsDict.TryGetValue(field.Name, out JsonElement value))
                    {
                        // Convert JsonElement to the appropriate type
                        object typedValue = ConvertJsonElementToType(value, field.FieldType);
                        field.SetValue(null, typedValue);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to load settings: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Convert json element to type.
        /// </summary>
        private static object ConvertJsonElementToType(JsonElement element, Type targetType)
        {
            if (targetType == typeof(string))
            {
                return element.GetString();
            }
            else if (targetType == typeof(int))
            {
                return element.GetInt32();
            }
            else if (targetType == typeof(long))
            {
                return element.GetInt64();
            }
            else if (targetType == typeof(bool))
            {
                return element.GetBoolean();
            }
            else if (targetType == typeof(double))
            {
                return element.GetDouble();
            }
            else if (targetType == typeof(DateTime))
            {
                return element.GetDateTime();
            }
            else if (targetType.IsEnum)
            {
                var enumString = element.GetString();
                if (Enum.TryParse(targetType, enumString, out object enumValue))
                {
                    return enumValue;
                }
                // Return default enum value if parsing fails
                return Enum.GetValues(targetType).GetValue(0);
            }
            else if (targetType == typeof(Guid))
            {
                return Guid.Parse(element.GetString());
            }
            else
            {
                // For complex types
                return JsonSerializer.Deserialize(element.GetRawText(), targetType);
            }
        }
        #endregion

        /// <summary>
        /// Gets or sets the settings folder.
        /// </summary>
        public static string SettingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VisioForge Video Duplicates Finder");

        /// <summary>
        /// Gets or sets the last path.
        /// </summary>
        public static string LastPath;
    }
}