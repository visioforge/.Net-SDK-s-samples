namespace vfp_search
{
    using CommandLine;
    using CommandLine.Text;

    public class CommandLineOptions
    {
        /// <summary>
        /// Gets or sets the fragment fingerprint file (small).
        /// </summary>
        [Option('f', "fragment", Required = true, HelpText = "Fragment fingerprint file (small).")]
        public string FragmentFile { get; set; }

        /// <summary>
        /// Gets or sets the main fingerprint file (long).
        /// </summary>
        [Option('m', "main", Required = true, HelpText = "Main fingerprint file (long).")]
        public string MainFile { get; set; }

        /// <summary>
        /// Gets or sets the license key.
        /// </summary>
        [Option('l', "license", Required = false, HelpText = "License key.", Default = "TRIAL")]
        public string LicenseKey { get; set; }

        /// <summary>
        /// Gets or sets the maximal difference between fingerprints.
        /// </summary>
        [Option('d', "md", Required = false, HelpText = "Maximal difference between fingerprints.", Default = 500)]
        public int MaxDifference { get; set; }

        /// <summary>
        /// Get usage.
        /// </summary>
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("VisioForge Video Fingerprinting SDK signature search tool (can search one fingerprint in another).", "v2025"),
                Copyright = new CopyrightInfo("VisioForge", 2025),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddPreOptionsLine("Usage: app -f \"fragment file\" -m \"main file\" options");

            return help;
        }
    }
}
