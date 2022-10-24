using System;
using System.Collections.Generic;
using System.IO;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoEdit;

namespace Video_From_Images_CLI
{
    class Program
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
            //var optionsz = new CommandLineOptions { InputFolder = "c:\\samples\\pics\\", OutputFile = "c:\\vf\\output.avi", Resolution = new[] { "1920", "1080" }, Duration = 2000, Format = "mp4" };
            //var arguments = CommandLine.Parser.Default.FormatCommandLine(optionsz);

            var options = new CommandLineOptions();
            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

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

            var videoEdit = new VisioForge.Core.VideoEdit.VideoEditCore();

            int insertTime = 0;

            int videoWidth = Convert.ToInt32(options.Resolution[0]);
            int videoHeight = Convert.ToInt32(options.Resolution[1]);

            foreach (string img in files)
            {
                videoEdit.Input_AddImageFile(img, TimeSpan.FromMilliseconds(2000), TimeSpan.FromMilliseconds(insertTime), VideoEditStretchMode.Letterbox, 0, videoWidth, videoHeight);
                insertTime += 2000;
            }

            videoEdit.Video_Effects_Clear();
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

        private static void VeOnOnProgress(object sender, ProgressEventArgs progressEventArgs)
        {
            Console.WriteLine(progressEventArgs.Progress);
        }

        private static void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
