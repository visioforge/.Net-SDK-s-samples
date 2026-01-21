using System.IO;

namespace MMT_MAUI
{
    public static class FileScanner
    {
        /// <summary>
        /// Search video files.
        /// </summary>
        public static List<string> SearchVideoFiles(string dir)
        {
            List<string> list = new List<string>();

            list.AddRange(System.IO.Directory.GetFiles(dir, "*.mp4"));
            list.AddRange(System.IO.Directory.GetFiles(dir, "*.avi"));
            list.AddRange(System.IO.Directory.GetFiles(dir, "*.wmv"));
            list.AddRange(System.IO.Directory.GetFiles(dir, "*.3gp"));
            list.AddRange(System.IO.Directory.GetFiles(dir, "*.mov"));
            list.AddRange(System.IO.Directory.GetFiles(dir, "*.mkv"));
            list.AddRange(System.IO.Directory.GetFiles(dir, "*.m2v"));
            list.AddRange(System.IO.Directory.GetFiles(dir, "*.mts"));
            list.AddRange(System.IO.Directory.GetFiles(dir, "*.ts"));

            foreach (string dir2 in System.IO.Directory.GetDirectories(dir))
            {
                list.AddRange(SearchVideoFiles(dir2));
            }

            return list;
        }
    }
}