using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoEdit;

namespace Video_From_Images_CLI
{
    /// <summary>
    /// Represents the main program for the Video From Images CLI demo.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Adds files from the specified folder with the given extension to the file list.
        /// </summary>
        /// <param name="inputFolder">The input folder path.</param>
        /// <param name="ext">The file extension filter (e.g., "*.jpg").</param>
        /// <param name="files">The list of files to add to.</param>
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
            if (args.Length < 2)
            {
                var help = CommandLineOptions.GetUsage();
                Console.WriteLine(help);

                Console.Write("Press any key to exit.");
                Console.ReadKey();
                return;
            }

            //var str = "-i c:\\samples\\pics\\ -o output_file.mp4 -r 1920:1080 -d 2000 -f mp4";
            //var strx = str.Split(' ');
            CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(Run)
                .WithNotParsed(HandleParseError);
        }
        
        /// <summary>
        /// Runs the video creation process from images with the specified options.
        /// </summary>
        /// <param name="options">The command-line options.</param>
        static void Run(CommandLineOptions options)
        {
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

            // Validate resolution before allocating resources
            var res = options.Resolution.Split(':');
            if (res.Length != 2)
            {
                Console.WriteLine("Invalid resolution format. Use 'width:height' (e.g., '1920:1080').");
                return;
            }

            if (!int.TryParse(res[0], out int videoWidth) || !int.TryParse(res[1], out int videoHeight))
            {
                Console.WriteLine("Invalid resolution values. Width and height must be integers.");
                return;
            }

            if (videoWidth <= 0 || videoHeight <= 0)
            {
                Console.WriteLine("Invalid resolution values. Width and height must be positive.");
                return;
            }

            if (File.Exists(options.OutputFile))
            {
                File.Delete(options.OutputFile);
            }

            var videoEdit = new VisioForge.Core.VideoEdit.VideoEditCore();

            int insertTime = 0;
            int imageDuration = options.Duration > 0 ? options.Duration : 2000;

            foreach (string img in files)
            {
                videoEdit.Input_AddImageFile(img, TimeSpan.FromMilliseconds(imageDuration), TimeSpan.FromMilliseconds(insertTime), VideoEditStretchMode.Letterbox, 0, videoWidth, videoHeight);
                insertTime += imageDuration;
            }

            videoEdit.Mode = VideoEditMode.Convert;

            videoEdit.Video_Resize = true;
            videoEdit.Video_Resize_Width = videoWidth;
            videoEdit.Video_Resize_Height = videoHeight;

            videoEdit.Video_FrameRate = new VideoFrameRate(25);
            videoEdit.Video_Renderer = new VideoRendererSettings
            {
                VideoRenderer = VideoRendererMode.None,
                StretchMode = VideoRendererStretchMode.Letterbox
            };

            if (string.IsNullOrEmpty(options.Format))
            {
                options.Format = "mp4";
            }

            switch (options.Format)
            {
                case "mp4":
                    videoEdit.Output_Format = new MP4Output();
                    break;
                case "avi":
                    videoEdit.Output_Format = new AVIOutput();
                    break;
                case "wmv":
                    videoEdit.Output_Format = new WMVOutput();
                    break;
                default:
                    Console.WriteLine("Wrong output format. MP4 will be used.");
                    videoEdit.Output_Format = new MP4Output();
                    break;
            }

            videoEdit.Output_Filename = options.OutputFile;

            videoEdit.Video_Effects_Enabled = true;
            videoEdit.Video_Effects_Clear();

            videoEdit.OnError += VideoEdit1_OnError;
            videoEdit.OnProgress += VeOnOnProgress;

            videoEdit.ConsoleUsage = true;

            videoEdit.Start();

            Console.WriteLine(@"Video saved to: " + videoEdit.Output_Filename);
            Console.Write("Press any key to exit.");
            Console.ReadKey();

            videoEdit.Stop();
            videoEdit.Dispose();
        }
        
        /// <summary>
        /// Handles errors that occur during command-line argument parsing.
        /// </summary>
        /// <param name="errs">The collection of errors.</param>
        static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine("Wrong arguments. Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Handles the progress event of the video editing process.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="progressEventArgs">The ProgressEventArgs containing progress information.</param>
        private static void VeOnOnProgress(object sender, ProgressEventArgs progressEventArgs)
        {
            Console.WriteLine(progressEventArgs.Progress);
        }

        /// <summary>
        /// Handles the error event of the video editing process.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The ErrorsEventArgs containing error information.</param>
        private static void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
