﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Video_From_Images_CLI
{
    using CommandLine;
    using CommandLine.Text;

    public class CommandLineOptions
    {
        [Option(
            'i',
            "in",
            Required = true,
            HelpText = "Input folder with images. BMP, JPG, TIFF, PNG, GIF are supported.")]
        public string InputFolder { get; set; }
        
        [Option('o', "output", Required = true, HelpText = "Output file.")]
        public string OutputFile { get; set; }

        [Option('f', "format", Required = false, HelpText = "Output format. Possible values: mp4, avi, wmv.", Default = "mp4")]
        public string Format { get; set; }

        [Option('w', "width", Required = true, HelpText = "Width. Should divide into 8.", Default = 1280)]
        public int Width { get; set; }

        [Option('h', "height", Required = true, HelpText = "Height. Should divide into 8.", Default = 720)]
        public int Height { get; set; }

        [Option('d', "duration", Required = false, HelpText = "One image duration in video (in milliseconds).")]
        public int Duration { get; set; }

        public static string GetUsage(ParserResult<CommandLineOptions> result)
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("Video Edit SDK Video From Images CLI Demo", "10.5"),
                Copyright = new CopyrightInfo("VisioForge", 2022),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddPreOptionsLine("Sample usage: Video_From_Images_CLI.exe -i \"c:\\samples\\pics\\\" -o \"output file\" -w 1920 -h 1080 -d 2000 -f mp4");
            help.AddPreOptionsLine("Much more features available using API. ");
            help.AddOptions<CommandLineOptions>(result);

            return help;
        }
    }
}
