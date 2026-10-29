namespace vfp_compare
{
    using CommandLine;
    using CommandLine.Text;

    public class CommandLineOptions
    {
        /// <summary>
        /// Gets or sets the first fingerprint file.
        /// </summary>
        [Option('f', "f1", Required = true, HelpText = "First fingerprint file.")]
        public string Input1 { get; set; }

        /// <summary>
        /// Gets or sets the second fingerprint file.
        /// </summary>
        [Option('s', "f2", Required = true, HelpText = "Second fingerprint file.")]
        public string Input2 { get; set; }

        /// <summary>
        /// Gets or sets the maximal time shift in seconds between the videos searched for the best alignment.
        /// </summary>
        [Option('d', "md", Required = false, HelpText = "Maximal time shift in seconds between the videos searched for the best alignment.", Default = 500)]
        public int MaxShift { get; set; }

        /// <summary>
        /// Gets or sets the difference below which the files are reported as similar.
        /// </summary>
        [Option("threshold", Required = false, HelpText = "Difference below which the files are reported as similar.", Default = 300)]
        public int Threshold { get; set; }

        /// <summary>
        /// Gets or sets the license key.
        /// </summary>
        [Option('l', "license", Required = false, HelpText = "License key.", Default = "TRIAL")]
        public string LicenseKey { get; set; }

        /// <summary>
        /// Get usage.
        /// </summary>
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("VisioForge Video Fingerprinting SDK signature compare tool (can compare one fingerprint with another).", "v2025"),
                Copyright = new CopyrightInfo("VisioForge", 2025),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddPreOptionsLine("Usage: app -f \"first fingerprint file\" -s \"second fingerprint file\" options");

            return help;
        }
    }
}
