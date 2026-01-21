using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.VideoEdit;

namespace Video_From_Images_CLI
{
    static class Program
    {
        /// <summary>
        /// Scans the specified folder for files with a given extension and adds them to a list.
        /// </summary>
        /// <param name="inputFolder">The path to the folder to scan.</param>
        /// <param name="ext">The file extension to look for (e.g., "*.jpg").</param>
        /// <param name="files">A reference to the list where the found file paths will be added.</param>
        static void AddFiles(string inputFolder, string ext, ref List<string> files)
        {
            var files2 = Directory.GetFiles(inputFolder, ext);
            foreach (var s in files2)
            {
                files.Add(s);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            var res = CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args);
            if (res == null || res.Value == null || string.IsNullOrEmpty(res.Value.InputFolder))
            {
                Console.WriteLine(CommandLineOptions.GetUsage(res));
                Console.WriteLine("Press any key to exit...");
                Console.Read();
                return;
            }

            var options = res.Value;

            options.InputFolder = options.InputFolder.Trim();

            if (!Directory.Exists(options.InputFolder))
            {
                Console.WriteLine(@"Folder with images does not exists: " + options.InputFolder);
                return;
            }

            var files = new List<string>();
            AddFiles(options.InputFolder, "*.jpg", ref files);
            AddFiles(options.InputFolder, "*.jpeg", ref files);
            AddFiles(options.InputFolder, "*.png", ref files);
            AddFiles(options.InputFolder, "*.bmp", ref files);
            AddFiles(options.InputFolder, "*.gif", ref files);
            AddFiles(options.InputFolder, "*.tif", ref files);

            if (files.Count == 0)
            {
                Console.WriteLine(@"Folder with images is empty or do not contains supported formats: " + options.InputFolder);
                return;
            }

            if (File.Exists(options.OutputFile))
            {
                File.Delete(options.OutputFile);
            }

            var videoEdit = new VisioForge.Core.VideoEditX.VideoEditCoreX();

            int insertTime = 0;

            int videoWidth = options.Width;
            int videoHeight = options.Height;

            foreach (string img in files)
            {
                videoEdit.Input_AddImageFile(img, TimeSpan.FromMilliseconds(2000), TimeSpan.FromMilliseconds(insertTime));
                insertTime += 2000;
            }

            videoEdit.Output_VideoSize = new Size(videoWidth, videoHeight);
            videoEdit.Output_VideoFrameRate = new VideoFrameRate(25);

            if (string.IsNullOrEmpty(options.Format))
            {
                options.Format = "mp4";
            }

            switch (options.Format)
            {
                case "mp4":
                    videoEdit.Output_Format = new MP4Output(options.OutputFile);
                    break;
                case "avi":
                    videoEdit.Output_Format = new AVIOutput(options.OutputFile);
                    break;
                case "wmv":
                    videoEdit.Output_Format = new WMVOutput(options.OutputFile);
                    break;
                default:
                    Console.WriteLine("Wrong output format. MP4 will be used.");
                    videoEdit.Output_Format = new MP4Output(options.OutputFile);
                    break;
            }
            
            videoEdit.OnError += VideoEdit1_OnError;
            videoEdit.OnProgress += VideoEdit1_OnProgress;
            videoEdit.OnStop += VideoEdit_OnStop;

            videoEdit.ConsoleUsage = true;

            videoEdit.Start();

            Console.WriteLine(@"Video saved to: " + options.OutputFile);
            Console.Write("Press any key to exit.");
            Console.ReadKey();

            videoEdit.Dispose();

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Event handler for the engine's Stop event.
        /// Outputs a completion message to the console.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="StopEventArgs"/> instance containing the event data.</param>
        private static void VideoEdit_OnStop(object sender, StopEventArgs e)
        {
            Console.WriteLine("Completed");
        }

        /// <summary>
        /// Event handler for the engine's Progress event.
        /// Outputs the current progress percentage to the console.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="progressEventArgs">The <see cref="ProgressEventArgs"/> instance containing progress information.</param>
        private static void VideoEdit1_OnProgress(object sender, ProgressEventArgs progressEventArgs)
        {
            Console.WriteLine(progressEventArgs.Progress);
        }

        /// <summary>
        /// Event handler for the engine's Error event.
        /// Outputs error messages to the console.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing error information.</param>
        private static void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
