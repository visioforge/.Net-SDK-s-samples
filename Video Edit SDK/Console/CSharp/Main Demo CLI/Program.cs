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

    /// <summary>
    /// Represents the main program for the Video Edit CLI demo.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Adds a video source to the video editing engine based on the specified option.
        /// </summary>
        /// <param name="option">The option array containing file path and segment information.</param>
        /// <param name="core">The VideoEditCore instance.</param>
        /// <returns>True if the video source was added successfully, false otherwise.</returns>
        private static bool AddVideoSourceFromOption(string[] option, VideoEditCore core)
        {
            VideoSource src;
            if (option.Length == 2)
            {
                src = new VideoSource(
                    option[0],
                    new[] { new FileSegment(null, null) });
                core.Input_AddVideoFile(src);
            }
            else if (option.Length >= 5)
            {
                if (!int.TryParse(option[2], out int startMs) ||
                    !int.TryParse(option[3], out int endMs) ||
                    !int.TryParse(option[4], out int insertMs))
                {
                    Console.WriteLine("Invalid numeric values in video source option.");
                    return false;
                }

                if ((startMs < -1) || (endMs < -1) || (insertMs < -1))
                {
                    Console.WriteLine("Time values must be non-negative or -1 in video source option.");
                    return false;
                }

                src = new VideoSource(
                    option[0],
                    new[] { new FileSegment(TimeSpan.FromMilliseconds(startMs), TimeSpan.FromMilliseconds(endMs)) });
                core.Input_AddVideoFile(src, TimeSpan.FromMilliseconds(insertMs));
            }
            else
            {
                Console.WriteLine("Invalid video source option format. Expected 2 or 5+ elements.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds an audio source to the video editing engine based on the specified option.
        /// </summary>
        /// <param name="option">The option array containing file path and segment information.</param>
        /// <param name="core">The VideoEditCore instance.</param>
        /// <returns>True if the audio source was added successfully, false otherwise.</returns>
        private static bool AddAudioSourceFromOption(string[] option, VideoEditCore core)
        {
            AudioSource src;
            if (option.Length == 2)
            {
                src = new AudioSource(
                    option[0],
                    new[] { new FileSegment(null, null) });
                core.Input_AddAudioFile(src);
            }
            else if (option.Length >= 5)
            {
                if (!int.TryParse(option[2], out int startMs) ||
                    !int.TryParse(option[3], out int endMs) ||
                    !int.TryParse(option[4], out int insertMs))
                {
                    Console.WriteLine("Invalid numeric values in audio source option.");
                    return false;
                }

                if ((startMs < -1) || (endMs < -1) || (insertMs < -1))
                {
                    Console.WriteLine("Time values must be non-negative or -1 in audio source option.");
                    return false;
                }

                src = new AudioSource(
                    option[0],
                    new[] { new FileSegment(TimeSpan.FromMilliseconds(startMs), TimeSpan.FromMilliseconds(endMs)) });
                core.Input_AddAudioFile(src, TimeSpan.FromMilliseconds(insertMs));
            }
            else
            {
                Console.WriteLine("Invalid audio source option format. Expected 2 or 5+ elements.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds sources to the video editing engine based on the provided option.
        /// </summary>
        /// <param name="option">The option array containing file path, type, and segment information.</param>
        /// <param name="core">The VideoEditCore instance.</param>
        /// <returns>True if sources were added successfully, false otherwise.</returns>
        private static bool AddSources(string[] option, VideoEditCore core)
        {
            if (option == null || option.Length < 2)
            {
                Console.WriteLine("Invalid source option: insufficient elements.");
                return false;
            }

            if (option[1] == "x")
            {
                if (!AddVideoSourceFromOption(option, core))
                    return false;
                if (!AddAudioSourceFromOption(option, core))
                    return false;
            }
            else if (option[1] == "a")
            {
                if (!AddAudioSourceFromOption(option, core))
                    return false;
            }
            else if (option[1] == "v")
            {
                if (!AddVideoSourceFromOption(option, core))
                    return false;
            }
            else
            {
                Console.WriteLine("Wrong type parameter for input file. Use 'v' for video, 'a' for audio, or 'x' for both.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            //var str = "-i c:\\samples\\pics\\ -o output_file.mp4 -r 1920:1080 -d 2000 -f mp4";
            //var strx = str.Split(' ');
            CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(Run)
                .WithNotParsed(HandleParseError);
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
        /// Runs the video editing process with the specified options.
        /// </summary>
        /// <param name="options">The command-line options.</param>
        static void Run(CommandLineOptions options)
        {
            var core = new VideoEditCore();

            // resize
            if (!string.IsNullOrEmpty(options.Resize))
            {
                var resize = options.Resize.Split(':');
                if (resize.Length != 2 ||
                    !int.TryParse(resize[0], out int width) ||
                    !int.TryParse(resize[1], out int height))
                {
                    Console.WriteLine("Invalid resize format. Expected 'width:height' with numeric values.");
                    core.Dispose();
                    return;
                }

                if (width <= 0 || height <= 0)
                {
                    Console.WriteLine("Invalid resize dimensions. Width and height must be positive values.");
                    core.Dispose();
                    return;
                }

                core.Video_Resize = true;
                core.Video_Resize_Width = width;
                core.Video_Resize_Height = height;
            }

            // add source files
            if (!AddSources(options.InputFile1, core))
            {
                Console.WriteLine("Failed to add primary input file.");
                core.Dispose();
                return;
            }

            if (options.InputFile2 != null)
            {
                if (!AddSources(options.InputFile2, core))
                {
                    Console.WriteLine("Failed to add input file 2.");
                    core.Dispose();
                    return;
                }
            }

            if (options.InputFile3 != null)
            {
                if (!AddSources(options.InputFile3, core))
                {
                    Console.WriteLine("Failed to add input file 3.");
                    core.Dispose();
                    return;
                }
            }

            if (options.InputFile4 != null)
            {
                if (!AddSources(options.InputFile4, core))
                {
                    Console.WriteLine("Failed to add input file 4.");
                    core.Dispose();
                    return;
                }
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

            core.Stop();
            core.Dispose();
        }
    }
}
