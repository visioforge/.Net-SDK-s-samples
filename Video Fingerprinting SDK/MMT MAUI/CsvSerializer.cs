using System.IO;
using System.Text;

namespace MMT_MAUI
{
    public static class CsvSerializer
    {
        public static void SerializeToCsv<T>(this List<T> genericList, string fileName, char separator)
        {
            var sb = new StringBuilder();
            var header = string.Empty;
            var info = typeof(T).GetProperties();
            if (!File.Exists(fileName))
            {
                var file = File.Create(fileName);
                file.Close();
                foreach (var prop in typeof(T).GetProperties())
                {
                    header += prop.Name + separator;
                }
                header = header.Substring(0, header.Length - 1);
                sb.AppendLine(header);
                using (var sw = new StreamWriter(fileName))
                {
                    sw.Write(sb.ToString());
                }
            }
            sb = new StringBuilder();
            foreach (var obj in genericList)
            {
                sb = new StringBuilder();
                var line = string.Empty;
                foreach (var prop in info)
                {
                    line += prop.GetValue(obj, null)?.ToString() + separator;
                }
                line = line.Substring(0, line.Length - 1);
                sb.AppendLine(line);
                using (var sw = new StreamWriter(fileName, true))
                {
                    sw.Write(sb.ToString());
                }
            }
        }
    }
}