using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace DVS
{
    /// <summary>
    /// Settings.
    /// </summary>
    public static class Settings
    {
        #region Serialize
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
            catch
            {
                return false;
            }
        }

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
            catch
            {
                return false;
            }
        }

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
                return Enum.Parse(targetType, element.GetString());
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

        public static string SettingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VisioForge Video Duplicates Finder");

        public static string LastPath;
    }
}