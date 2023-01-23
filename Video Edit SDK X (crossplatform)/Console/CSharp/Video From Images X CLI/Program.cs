using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.VideoEdit;

namespace Video_From_Images_CLI
{
    static class Program
    {
        static void AddFiles(string inputFolder, string ext, ref List<string> files)
        {
            var files2 = Directory.GetFiles(inputFolder, ext);
            foreach (var s in files2)
            {
                files.Add(s);
            }
        }

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
                    videoEdit.Output_Format = new WMV1Output(options.OutputFile);
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
        }

        private static void VideoEdit_OnStop(object sender, StopEventArgs e)
        {
            Console.WriteLine("Completed");
        }

        private static void VideoEdit1_OnProgress(object sender, ProgressEventArgs progressEventArgs)
        {
            Console.WriteLine(progressEventArgs.Progress);
        }

        private static void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
