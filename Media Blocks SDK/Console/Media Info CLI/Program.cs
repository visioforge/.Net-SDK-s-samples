// See https://aka.ms/new-console-template for more information

using System;
using System.Threading.Tasks;

namespace Media_Info_CLI
{
    /// <summary>
    /// Represents the program.
    /// </summary>
    static class Program
    {
        //static System.Uri filename = new System.Uri("/Users/roman/Desktop/video.mp4");

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please, specify input file.");
                return;
            }

            var mediaInfo = new VisioForge.Core.MediaInfoReaderX.MediaInfoReaderX();
            if (await mediaInfo.OpenAsync(args[0]))
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