using System.Diagnostics;
using VisioForge.MediaFramework;

namespace VE_Main_Demo_CLI
{
    using System;

    using VisioForge.Controls.VideoEdit;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.VideoEffects;

    class Program
    {
        private static void AddVideoSourceFromOption(string[] option, VideoEditCore core)
        {
            VFVEVideoSource src;
            if (option.Length == 2)
            {
                src = new VFVEVideoSource(
                    option[0],
                    new[] { new VFVEFileSegment(null, null) });
            }
            else
            {
                src = new VFVEVideoSource(
                    option[0],
                    new[] { new VFVEFileSegment(TimeSpan.FromMilliseconds(Convert.ToInt32(option[2])), TimeSpan.FromMilliseconds(Convert.ToInt32(option[3]))) });
            }

            if (option.Length == 2)
            {
                core.Input_AddVideoFile(src);
            }
            else
            {
                core.Input_AddVideoFile(src, TimeSpan.FromMilliseconds(Convert.ToInt32(option[4])));
            }
        }

        private static void AddAudioSourceFromOption(string[] option, VideoEditCore core)
        {
            VFVEAudioSource src;
            if (option.Length == 2)
            {
                src = new VFVEAudioSource(
                    option[0],
                    new[] { new VFVEFileSegment(null, null) });
            }
            else
            {
                src = new VFVEAudioSource(
                    option[0],
                    new[] { new VFVEFileSegment(TimeSpan.FromMilliseconds(Convert.ToInt32(option[2])), TimeSpan.FromMilliseconds(Convert.ToInt32(option[3]))) });
            }

            if (option.Length == 2)
            {
                core.Input_AddAudioFile(src);
            }
            else
            {
                core.Input_AddAudioFile(src, TimeSpan.FromMilliseconds(Convert.ToInt32(option[4])));
            }
        }

        private static bool AddSources(string[] option, VideoEditCore core)
        {
            if (option[1] == "x")
            {
                AddVideoSourceFromOption(option, core);
                AddAudioSourceFromOption(option, core);
            }
            else if (option[1] == "a")
            {
                AddAudioSourceFromOption(option, core);
            }
            else if (option[1] == "v")
            {
                AddVideoSourceFromOption(option, core);
            }
            else
            {
                Console.WriteLine("Wrong type parameter for input file.");
                return false;
            }

            return true;
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

            var core = new VideoEditCore();

            // resize
            if (options.Resize != null && options.Resize.Count == 2)
            {
                core.Video_Resize = true;
                core.Video_Resize_Width = Convert.ToInt32(options.Resize[0]);
                core.Video_Resize_Height = Convert.ToInt32(options.Resize[1]);
            }

            // add source files
            AddSources(options.InputFile1, core);

            if (options.InputFile2 != null)
            {
                AddSources(options.InputFile2, core);
            }

            if (options.InputFile3 != null)
            {
                AddSources(options.InputFile3, core);
            }

            if (options.InputFile4 != null)
            {
                AddSources(options.InputFile4, core);
            }

            if (string.IsNullOrEmpty(options.Format))
            {
                options.Format = "mp4";
            }

            switch (options.Format)
            {
                case "mp4":
                    core.Output_Format = new VFMP4HWOutput();
                    break;
                case "avi":
                    core.Output_Format = new VFAVIOutput();
                    break;
                case "wmv":
                    core.Output_Format = new VFWMVOutput();
                    break;
                case "webm":
                    core.Output_Format = new VFWebMOutput();
                    break;
                default:
                    Console.WriteLine("Wrong output format. MP4 will be used.");
                    core.Output_Format = new VFMP4HWOutput();
                    break;
            }
            
            core.Video_Renderer.VideoRendererInternal = VFVideoRendererInternal.None;

            //Text overlay
            if (!string.IsNullOrEmpty(options.TextOverlay))
            {
                core.Video_Effects_Enabled = true;

                var textOverlay = new VFVideoEffectTextLogo(true);
                textOverlay.Text = options.TextOverlay;
                core.Video_Effects_Add(textOverlay);
            }

            //Image overlay
            if (!string.IsNullOrEmpty(options.ImageOverlay))
            {
                core.Video_Effects_Enabled = true;

                var imageLogo = new VFVideoEffectImageLogo(true)
                                    {
                                        Filename = options.ImageOverlay,
                                        Left = 30,
                                        Top = 30
                                    };
                core.Video_Effects_Add(imageLogo);
            }

            core.Output_Filename = options.OutputFile;

            //Event Handlers
            core.OnProgress += (sender, e) =>
            {
                Console.Out.WriteLine("Video Encoding Status : " + e.Progress);
            };

            core.OnStop += (sender, e) =>
            {
                Console.Out.WriteLine("Done. Please press any key.");
            };

            core.OnError += (sender, e) =>
            {
                Console.Out.WriteLine("Error: " + e.Message + "\n" + e.StackTrace + "\n" + e.CallSite);
            };

            //File Tags
            if (options.Tags)
            {
                core.Tags = new VFFileTags()
                                {
                                    Title = "Test Title",
                                    Performers = new string[] { },
                                    Album = "test",
                                    Comment = "test",
                                    Track = 0,
                                    Copyright = string.Empty,
                                    Year = 2017,
                                    Composers = new string[] { },
                                    Genres = new string[] { },
                                    Lyrics = string.Empty
                                };
            }

            Console.Out.WriteLine("# Video Encoding Starting #");

            core.ConsoleUsage = true;

            core.Start();

            Console.ReadKey();
        }
    }
}
