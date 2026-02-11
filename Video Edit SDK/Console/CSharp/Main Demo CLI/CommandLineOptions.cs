using System;

namespace VE_Main_Demo_CLI
{
    using CommandLine;
    using CommandLine.Text;

    /// <summary>
    /// Command line options.
    /// </summary>
    public class CommandLineOptions
    {
        /// <summary>
        /// Gets or sets the first input file.
        /// </summary>
        [Option(
            'i',
            "in1",
            Separator = ':',
            Required = true,
            HelpText = "Input video file 1. Value is \"filename:type\" or \"filename:type:start_time:stop_time:timeline_position\" (time in milliseconds, '-1' to add entire file, type is 'a' for audio, 'v' for video, 'x' to add video and audio).")]
        public string[] InputFile1 { get; set; }

        /// <summary>
        /// Gets or sets the second input file.
        /// </summary>
        [Option(
            "in2",
            Separator = ':',
            Required = false,
            HelpText = "Input video file 2. Value is \"filename type\" or \"filename type start_time stop_time timeline_position\" (time in milliseconds, '-1' to add entire file, type is 'a' for audio, 'v' for video, 'x' to add video and audio).")]
        public string[] InputFile2 { get; set; }

        /// <summary>
        /// Gets or sets the third input file.
        /// </summary>
        [Option(
            "in3",
            Separator = ':',
            Required = false,
            HelpText = "Input video file 3. Value is \"filename type\" or \"filename type start_time stop_time timeline_position\" (time in milliseconds, '-1' to add entire file, type is 'a' for audio, 'v' for video, 'x' to add video and audio).")]
        public string[] InputFile3 { get; set; }

        /// <summary>
        /// Gets or sets the fourth input file.
        /// </summary>
        [Option(
            "in4",
            Separator = ':',
            Required = false,
            HelpText = "Input video file 4. Value is \"filename type\" or \"filename type start_time stop_time timeline_position\" (time in milliseconds, '-1' to add entire file, type is 'a' for audio, 'v' for video, 'x' to add video and audio).")]
        public string[] InputFile4 { get; set; }

        /// <summary>
        /// Gets or sets the output file.
        /// </summary>
        [Option('o', "output", Required = true, HelpText = "Output file.")]
        public string OutputFile { get; set; }
        
        /// <summary>
        /// Gets or sets the output format.
        /// </summary>
        [Option('f', "format", Required = false, HelpText = "Output format. Possible values: mp4, avi, wmv, webm.", Default = "mp4")]
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the resize settings.
        /// </summary>
        [Option(
            'r',
            "resize",
            Separator = ':',
            Required = false,
            HelpText = "Resize option. Format is \"width:height\"")]
        public string Resize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to add test tags.
        /// </summary>
        [Option("tags", Required = false, HelpText = "Set this option to add test tags to output file.")]
        public bool Tags { get; set; }

        /// <summary>
        /// Gets or sets the text overlay settings.
        /// </summary>
        [Option("text-overlay", Required = false, HelpText = "Text overlay.")]
        public string TextOverlay { get; set; }

        /// <summary>
        /// Gets or sets the image overlay settings.
        /// </summary>
        [Option("image-overlay", Required = false, HelpText = "Use this option to add test image overlay to output file.")]
        public string ImageOverlay { get; set; }

        /// <summary>
        /// Gets the usage guidelines.
        /// </summary>
        /// <returns>The usage guidelines.</returns>
        public static string GetUsage()
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
            
            help.AutoHelp = true;

            return help;
        }
    }
}
