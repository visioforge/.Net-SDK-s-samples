namespace DVS
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class FileScanner
    {
        /// <summary>
        /// Search video in folder.
        /// </summary>
        public static IEnumerable<string> SearchVideoInFolder(string folder, List<string> extensions)
        {
            List<string> files = new List<string>();

            try
            {
                var fileList = new DirectoryInfo(folder).GetFiles("*", SearchOption.AllDirectories);
                var matchingFiles = fileList.Where(a =>
                    extensions.Contains(a.Extension.ToLowerInvariant().Replace(".", "")));

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
