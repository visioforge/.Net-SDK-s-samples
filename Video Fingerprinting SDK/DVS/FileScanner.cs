namespace VisioForge_MMT
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class FileScanner
    {
        public static IEnumerable<string> SearchVideoInFolder(string folder, List<string> extensions)
        {   
            var fileList = new DirectoryInfo(folder).GetFiles("*", SearchOption.AllDirectories);
            var fileList2 = fileList.Where(a => 
                extensions.Contains(a.Extension.ToLowerInvariant().Replace(".", "")));

            List<string> files = new List<string>(); 
            foreach (var fileInfo in fileList2)
            {
                files.Add(fileInfo.FullName);
            }

            return files;
        }
    }
}
