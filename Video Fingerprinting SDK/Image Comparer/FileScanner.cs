using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImageComparer
{
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

        public static IEnumerable<string> SearchImagesInFolder(string folder)
        {
            var fileList = new DirectoryInfo(folder).GetFiles("*", SearchOption.AllDirectories);
            var fileList2 = fileList.Where(a =>
                a.Extension.ToLowerInvariant() == ".jpg" ||
                a.Extension.ToLowerInvariant() == ".jpeg" ||
                a.Extension.ToLowerInvariant() == ".bmp" ||
                a.Extension.ToLowerInvariant() == ".png" ||
                a.Extension.ToLowerInvariant() == ".tiff" ||
                a.Extension.ToLowerInvariant() == ".gif");

            List<string> files = new List<string>();
            foreach (var fileInfo in fileList2)
            {
                files.Add(fileInfo.FullName);
            }

            return files;
        }
    }
}
