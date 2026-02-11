namespace VisioForge_MMT
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class FileScanner
    {
        private static readonly HashSet<string> VideoExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".avi", ".mp4", ".wmv", ".flv", ".mov", ".ts", ".mpg"
        };

        /// <summary>
        /// Search video in folder.
        /// </summary>
        public static IEnumerable<string> SearchVideoInFolder(string folder)
        {
            List<string> files = new List<string>();

            try
            {
                var fileList = new DirectoryInfo(folder).GetFiles("*", SearchOption.AllDirectories);
                var matchingFiles = fileList.Where(a => VideoExtensions.Contains(a.Extension));

                files.AddRange(matchingFiles.Select(f => f.FullName));
            }
            catch (UnauthorizedAccessException)
            {
                // Skip directories we don't have access to
            }
            catch (DirectoryNotFoundException)
            {
                // Skip directories that no longer exist
            }

            return files;
        }
    }
}
