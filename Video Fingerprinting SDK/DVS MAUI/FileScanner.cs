namespace DVS_MAUI
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class FileScanner
    {
        public static IEnumerable<string> SearchVideoInFolder(string folder, List<string> extensions)
        {   
            var files = new List<string>();
            
            try
            {
                if (!Directory.Exists(folder))
                    return files;

#if MACCATALYST
                // Restore security-scoped access for macOS sandboxing
                Platforms.MacCatalyst.FolderPickerImplementation.RestoreSecurityScopedAccess(folder);
#endif
                    
                var fileList = new DirectoryInfo(folder).GetFiles("*", SearchOption.AllDirectories);
                var fileList2 = fileList.Where(a => 
                    extensions.Contains(a.Extension.ToLowerInvariant().Replace(".", "")));

                foreach (var fileInfo in fileList2)
                {
                    files.Add(fileInfo.FullName);
                }
            }
            catch (Exception ex)
            {
                // Log error but continue
                System.Diagnostics.Debug.WriteLine($"Error scanning folder {folder}: {ex.Message}");
            }

            return files;
        }
    }
}