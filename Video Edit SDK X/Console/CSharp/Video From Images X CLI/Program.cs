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
        private static readonly ManualResetEvent _completionEvent = new ManualResetEvent(false);
        private static bool _completedSuccessfully;

        /// <summary>
        /// Scans the specified folder for files with a given extension and adds them to a list.
        /// </summary>
        /// <param name="inputFolder">The path to the folder to scan.</param>
        /// <param name="ext">The file extension to look for (e.g., "*.jpg").</param>
        /// <param name="files">The list where the found file paths will be added.</param>
        static void AddFiles(string inputFolder, string ext, List<string> files)
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
            AddFiles(options.InputFolder, "*.jpg", files);
            AddFiles(options.InputFolder, "*.jpeg", files);
            AddFiles(options.InputFolder, "*.png", files);
            AddFiles(options.InputFolder, "*.bmp", files);
            AddFiles(options.InputFolder, "*.gif", files);
            AddFiles(options.InputFolder, "*.tif", files);

            if (files.Count == 0)
            {
                Console.WriteLine(@"Folder with images is empty or do not contains supported formats: " + options.InputFolder);
                return;
            }

            if (File.Exists(options.OutputFile))
            {
                File.Delete(options.OutputFile);
            }

            using (var videoEdit = new VisioForge.Core.VideoEditX.VideoEditCoreX())
            {
                // Subscribe to events early to ensure no events are missed
                videoEdit.OnError += VideoEdit1_OnError;
                videoEdit.OnProgress += VideoEdit1_OnProgress;
                videoEdit.OnStop += VideoEdit_OnStop;

                int insertTime = 0;

                int videoWidth = options.Width;
                int videoHeight = options.Height;
                int imageDuration = options.Duration;

                foreach (string img in files)
                {
                    videoEdit.Input_AddImageFile(img, TimeSpan.FromMilliseconds(imageDuration), TimeSpan.FromMilliseconds(insertTime));
                    insertTime += imageDuration;
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

                videoEdit.ConsoleUsage = true;

                _completionEvent.Reset();
                videoEdit.Start();

                Console.WriteLine("Processing...");
                _completionEvent.WaitOne();

                if (_completedSuccessfully)
                {
                    Console.WriteLine(@"Video saved to: " + options.OutputFile);
                }
                else
                {
                    Console.WriteLine("Video processing failed.");
                }
            }

            VisioForgeX.DestroySDK();

            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// Event handler for the engine's Stop event.
        /// Signals completion to the main thread.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="StopEventArgs"/> instance containing the event data.</param>
        private static void VideoEdit_OnStop(object sender, StopEventArgs e)
        {
            _completedSuccessfully = e.Successful;
            _completionEvent.Set();
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
