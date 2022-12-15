using System;
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
            "input",
            Required = true,
            HelpText = "Input folder with images. BMP, JPG, TIFF, PNG, GIF are supported.")]
        public string InputFolder { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output file.")]
        public string OutputFile { get; set; }

        [Option('f', "format", Required = false, HelpText = "Output format. Possible values: mp4, avi, wmv.", Default = "mp4")]
        public string Format { get; set; }

        [Option('r', "resolution", Required = true, HelpText = "Resolution option. Format is \"width:height\". Should divide into 8.")]
        public string Resolution { get; set; }

        [Option('d', "duration", Required = false, HelpText = "One image duration in video (in milliseconds).")]
        public int Duration { get; set; }

        public static string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("Video Edit SDK Video From Images CLI Demo", "15.5"),
                Copyright = new CopyrightInfo("VisioForge", 2023),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddPreOptionsLine("Sample usage: Video_From_Images_CLI.exe --input \"c:\\samples\\pics\\\" --output \"output file\" --resolution 1920:1080 --duration 2000 --format mp4");
            help.AddPreOptionsLine("Much more features available using API. ");
            //help.AddOptions<CommandLineOptions>(this);

            help.AutoHelp = true;

            return help;
        }
    }
}
