using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE_Main_Demo_CLI
{
    using VisioForge.Libs.CommandLine;
    using VisioForge.Libs.CommandLine.Text;

    public class CommandLineOptions
    {
        [OptionArray(
            'i',
            "in1",
            Required = true,
            HelpText = "Input video file 1. Value is \"filename type\" or \"filename type start_time stop_time timeline_position\" (time in milliseconds, '-1' to add entire file, type is 'a' for audio, 'v' for video, 'x' to add video and audio).")]
        public string[] InputFile1 { get; set; }

        [OptionArray(
            "in2",
            Required = false,
            HelpText = "Input video file 2. Value is \"filename type\" or \"filename type start_time stop_time timeline_position\" (time in milliseconds, '-1' to add entire file, type is 'a' for audio, 'v' for video, 'x' to add video and audio).")]
        public string[] InputFile2 { get; set; }

        [OptionArray(
            "in3",
            Required = false,
            HelpText = "Input video file 3. Value is \"filename type\" or \"filename type start_time stop_time timeline_position\" (time in milliseconds, '-1' to add entire file, type is 'a' for audio, 'v' for video, 'x' to add video and audio).")]
        public string[] InputFile3 { get; set; }

        [OptionArray(
            "in4",
            Required = false,
            HelpText = "Input video file 4. Value is \"filename type\" or \"filename type start_time stop_time timeline_position\" (time in milliseconds, '-1' to add entire file, type is 'a' for audio, 'v' for video, 'x' to add video and audio).")]
        public string[] InputFile4 { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output file.")]
        public string OutputFile { get; set; }

        [Option('f', "format", Required = false, HelpText = "Output format. Possible values: mp4, avi, wmv, webm.", DefaultValue = "mp4")]
        public string Format { get; set; }

        [OptionList('r', "resize", Required = false, HelpText = "Resize option. Format is \"width:height\"")]
        public IList<string> Resize { get; set; }

        [Option("tags", Required = false, HelpText = "Set this option to add test tags to output file.")]
        public bool Tags { get; set; }

        [Option("text-overlay", Required = false, HelpText = "Text overlay.")]
        public string TextOverlay { get; set; }

        [Option("image-overlay", Required = false, HelpText = "Use this option to add test image overlay to output file.")]
        public string ImageOverlay { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("Video Edit SDK CLI demo", "1.0"),
                Copyright = new CopyrightInfo("VisioForge", 2017),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddPreOptionsLine("Sample usage: VE Main Demo CLI.exe -i \"input file\" x -o \"output file\" -r 1920:1080 --text-overlay \"Hello!\" --image-overlay \"logo.png\" -f mp4");
            help.AddPreOptionsLine("Much more features available using API. ");
            help.AddOptions(this);

            return help;
        }
    }
}
