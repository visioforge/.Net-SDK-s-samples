using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vfp_search
{
    using System.IO;

    using VisioForge.Core.VideoFingerPrinting;

    class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine(new CommandLineOptions().GetUsage());

            var options = CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args).Value;
            if (options == null)
            {
                return;
            }

            if (!File.Exists(options.FragmentFile))
            {
                Console.WriteLine("Fragment file not found: " + options.FragmentFile + ".");
                return;
            }

            if (!File.Exists(options.MainFile))
            {
                Console.WriteLine("Main file not found: " + options.MainFile + ".");
                return;
            }

            VFPAnalyzer.SetLicenseKey(options.LicenseKey);

            Console.WriteLine("Starting analyze.");

            var time = DateTime.Now;

            var fragment = VFPFingerPrint.Load(options.FragmentFile);
            var main = VFPFingerPrint.Load(options.MainFile);

            double difference;
            var res = VFPSearch.Search(fragment, 0, main, 0, out difference, options.MaxDifference);

            var elapsed = DateTime.Now - time;
            Console.WriteLine("Analyze finished. Elapsed time: " + elapsed.ToString("g"));

            if (res > 0)
            {
                TimeSpan ts = new TimeSpan(res * TimeSpan.TicksPerSecond);
                Console.WriteLine($"Detected fragment file at {ts:g}, difference level is {difference}");
            }
            else
            {
                Console.WriteLine("Fragment file not found.");
            }
        }
    }
}
