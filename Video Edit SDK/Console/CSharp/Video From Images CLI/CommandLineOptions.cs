using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Video_From_Images_CLI
{
    using VisioForge.Libs.CommandLine;
    using VisioForge.Libs.CommandLine.Text;

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

        [Option('f', "format", Required = false, HelpText = "Output format. Possible values: mp4, avi, wmv.", DefaultValue = "mp4")]
        public string Format { get; set; }

        [OptionList('r', "resolution", Required = true, HelpText = "Resolution option. Format is \"width:height\". Should divide into 8.")]
        public IList<string> Resolution { get; set; }

        [Option('d', "duration", Required = false, HelpText = "One image duration in video (in milliseconds).")]
        public int Duration { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("Video Edit SDK Video From Images CLI Demo", "10.5"),
                Copyright = new CopyrightInfo("VisioForge", 2018),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddPreOptionsLine("Sample usage: Video_From_Images_CLI.exe -i \"c:\\samples\\pics\\\" -o \"output file\" -r 1920:1080 -d 2000 -f mp4");
            help.AddPreOptionsLine("Much more features available using API. ");
            help.AddOptions(this);

            return help;
        }
    }
}
