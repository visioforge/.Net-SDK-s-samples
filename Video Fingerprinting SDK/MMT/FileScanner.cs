namespace VisioForge_MMT
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class FileScanner
    {
        public static IEnumerable<string> SearchVideoInFolder(string folder)
        {
            var fileList = new DirectoryInfo(folder).GetFiles("*", SearchOption.AllDirectories);
            var fileList2 = fileList.Where(a => 
                a.Extension.ToLowerInvariant() == ".avi" ||
                a.Extension.ToLowerInvariant() == ".mp4" ||
                a.Extension.ToLowerInvariant() == ".wmv" ||
                a.Extension.ToLowerInvariant() == ".flv" ||
                a.Extension.ToLowerInvariant() == ".mov" ||
                a.Extension.ToLowerInvariant() == ".ts" ||
                a.Extension.ToLowerInvariant() == ".mpg");

            List<string> files = new List<string>(); 
            foreach (var fileInfo in fileList2)
            {
                files.Add(fileInfo.FullName);
            }

            return files;
        }
    }
}
