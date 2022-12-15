using System.Diagnostics;
using VisioForge.Core;

namespace VE_Main_Demo_CLI
{
    using System;

    using VisioForge.Core.VideoEdit;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoEdit;
    using VisioForge.Core.Types.VideoEffects;
    using CommandLine;
    using System.Collections.Generic;

    static class Program
    {
        private static void AddVideoSourceFromOption(string[] option, VideoEditCore core)
        {
            VideoSource src;
            if (option.Length == 2)
            {
                src = new VideoSource(
                    option[0],
                    new[] { new FileSegment(null, null) });
            }
            else
            {
                src = new VideoSource(
                    option[0],
                    new[] { new FileSegment(TimeSpan.FromMilliseconds(Convert.ToInt32(option[2])), TimeSpan.FromMilliseconds(Convert.ToInt32(option[3]))) });
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
            AudioSource src;
            if (option.Length == 2)
            {
                src = new AudioSource(
                    option[0],
                    new[] { new FileSegment(null, null) });
            }
            else
            {
                src = new AudioSource(
                    option[0],
                    new[] { new FileSegment(TimeSpan.FromMilliseconds(Convert.ToInt32(option[2])), TimeSpan.FromMilliseconds(Convert.ToInt32(option[3]))) });
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
            //var str = "-i c:\\samples\\pics\\ -o output_file.mp4 -r 1920:1080 -d 2000 -f mp4";
            //var strx = str.Split(' ');
            CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(Run)
                .WithNotParsed(HandleParseError);
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine("Wrong arguments. Press any key to exit...");
            Console.ReadKey();
        }

        static void Run(CommandLineOptions options)
        {
            var core = new VideoEditCore();

            // resize
            if (!string.IsNullOrEmpty(options.Resize))
            {
                core.Video_Resize = true;

                var resize = options.Resize.Split(':');
                core.Video_Resize_Width = Convert.ToInt32(resize[0]);
                core.Video_Resize_Height = Convert.ToInt32(resize[1]);
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
                    core.Output_Format = new MP4HWOutput();
                    break;
                case "avi":
                    core.Output_Format = new AVIOutput();
                    break;
                case "wmv":
                    core.Output_Format = new WMVOutput();
                    break;
                case "webm":
                    core.Output_Format = new WebMOutput();
                    break;
                default:
                    Console.WriteLine("Wrong output format. MP4 will be used.");
                    core.Output_Format = new MP4HWOutput();
                    break;
            }
            
            core.Video_Renderer.VideoRenderer = VideoRendererMode.None;

            //Text overlay
            if (!string.IsNullOrEmpty(options.TextOverlay))
            {
                core.Video_Effects_Enabled = true;

                var textOverlay = new VideoEffectTextLogo(true);
                textOverlay.Text = options.TextOverlay;
                core.Video_Effects_Add(textOverlay);
            }

            //Image overlay
            if (!string.IsNullOrEmpty(options.ImageOverlay))
            {
                core.Video_Effects_Enabled = true;

                var imageLogo = new VideoEffectImageLogo(true)
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
                core.Tags = new MediaFileTags()
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
