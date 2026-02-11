using System.IO;

namespace MMT_MAUI
{
    public static class FileScanner
    {
        private static readonly string[] VideoExtensions = { "*.mp4", "*.avi", "*.wmv", "*.3gp", "*.mov", "*.mkv", "*.m2v", "*.mts", "*.ts" };

        /// <summary>
        /// Search video files.
        /// </summary>
        public static List<string> SearchVideoFiles(string dir)
        {
            List<string> list = new List<string>();

            try
            {
                foreach (var extension in VideoExtensions)
                {
                    try
                    {
                        list.AddRange(Directory.GetFiles(dir, extension, SearchOption.AllDirectories));
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Skip directories we don't have access to
                    }
                    catch (DirectoryNotFoundException)
                    {
                        // Skip directories that no longer exist
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Cannot access root directory
            }
            catch (DirectoryNotFoundException)
            {
                // Root directory doesn't exist
            }

            return list;
        }
    }
}