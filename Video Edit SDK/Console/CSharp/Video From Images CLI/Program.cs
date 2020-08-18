using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Types;
using VisioForge.Types.OutputFormat;

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
            var options = new CommandLineOptions();
            if (!VisioForge.Shared.CommandLine.Parser.Default.ParseArguments(args, options))
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

            VisioForge.Controls.VideoEdit.VideoEditCore ve = new VisioForge.Controls.VideoEdit.VideoEditCore();

            int insertTime = 0;
            
            int videoWidth = Convert.ToInt32(options.Resolution[0]);
            int videoHeight = Convert.ToInt32(options.Resolution[1]);

            foreach (string img in files)
            {
                ve.Input_AddImageFile(img, TimeSpan.FromMilliseconds(2000), TimeSpan.FromMilliseconds(insertTime), VFVideoEditStretchMode.Letterbox, 0, videoWidth, videoHeight);
                insertTime += 2000;
            }

            ve.Video_Effects_Clear();
            ve.Mode = VisioForge.Types.VFVideoEditMode.Convert;

            ve.Video_Resize = true;
            ve.Video_Resize_Width = videoWidth;
            ve.Video_Resize_Height = videoHeight; 

            ve.Video_FrameRate = 25;
            ve.Video_Renderer = new VideoRendererSettingsBase
            {
                VideoRendererInternal = VFVideoRendererInternal.None,
                StretchMode = VFVideoRendererStretchMode.Letterbox
            };

            if (string.IsNullOrEmpty(options.Format))
            {
                options.Format = "mp4";
            }

            switch (options.Format)
            {
                case "mp4":
                    ve.Output_Format = new VFMP4v8v10Output();
                    break;
                case "avi":
                    ve.Output_Format = new VFAVIOutput();
                    break;
                case "wmv":
                    ve.Output_Format = new VFWMVOutput();
                    break;
                default:
                    Console.WriteLine("Wrong output format. MP4 will be used.");
                    ve.Output_Format = new VFMP4v8v10Output();
                    break;
            }

            ve.Output_Filename = options.OutputFile;

            ve.Video_Effects_Enabled = true;
            ve.Video_Effects_Clear();

            ve.OnError += VideoEdit1_OnError;
            ve.OnProgress += VeOnOnProgress;

            ve.ConsoleUsage = true;

            ve.Start();

            Console.WriteLine(@"Video saved to: " + ve.Output_Filename);
            Console.Write("Press any key to exit.");
            Console.ReadKey();
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
