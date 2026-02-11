using System.IO;
using System.Text;

namespace MMT_MAUI
{
    public static class CsvSerializer
    {
        /// <summary>
        /// Serializes to CSV.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="genericList">The generic list.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="separator">The separator.</param>
        public static void SerializeToCsv<T>(this List<T> genericList, string fileName, char separator)
        {
            var sb = new StringBuilder();
            var info = typeof(T).GetProperties();
            bool writeHeader = !File.Exists(fileName);

            if (writeHeader && info.Length > 0)
            {
                var headerParts = new List<string>();
                foreach (var prop in info)
                {
                    headerParts.Add(prop.Name);
                }
                sb.AppendLine(string.Join(separator.ToString(), headerParts));
            }

            foreach (var obj in genericList)
            {
                var lineParts = new List<string>();
                foreach (var prop in info)
                {
                    lineParts.Add(prop.GetValue(obj, null)?.ToString() ?? string.Empty);
                }
                sb.AppendLine(string.Join(separator.ToString(), lineParts));
            }

            using (var sw = new StreamWriter(fileName, append: !writeHeader))
            {
                sw.Write(sb.ToString());
            }
        }
    }
}