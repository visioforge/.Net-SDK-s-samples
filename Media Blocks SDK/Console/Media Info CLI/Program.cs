// See https://aka.ms/new-console-template for more information

using System;

namespace Media_Info_CLI
{
    static class Program
    {
        //static System.Uri filename = new System.Uri("/Users/roman/Desktop/video.mp4");

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please, specify input file.");
                return;
            }

            var mediaInfo = new VisioForge.Core.MediaInfoReaderX.MediaInfoReaderX();
            if (mediaInfo.Open(args[0]))
            {
                var info = mediaInfo.Info.ToString();
                Console.WriteLine(info);
            }
            else
            {
                Console.WriteLine("Unable to read file info.");
            }
        }
    }
}