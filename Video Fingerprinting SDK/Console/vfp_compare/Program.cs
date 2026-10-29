using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vfp_compare
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
#if __MACOS__
            // The process starts inside the .app bundle; resolve relative paths against the shell's folder.
            var shellDir = Environment.GetEnvironmentVariable("PWD");
            if (Directory.Exists(shellDir)) Environment.CurrentDirectory = shellDir;
#endif

            Console.WriteLine(new CommandLineOptions().GetUsage());

            var options = CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args).Value;
            if (options == null)
            {
                return;
            }

            if (!File.Exists(options.Input1))
            {
                Console.WriteLine("Input file 1 not found: " + options.Input1 + ".");
                return;
            }

            if (!File.Exists(options.Input2))
            {
                Console.WriteLine("Input file 2 not found: " + options.Input2 + ".");
                return;
            }

            if (options.MaxShift < 0)
            {
                Console.WriteLine("Max shift must not be negative.");
                return;
            }

            VFPAnalyzer.SetLicenseKey(options.LicenseKey);

            Console.WriteLine("Starting analyze.");

            var time = DateTime.Now;

            var fragment = VFPFingerPrint.Load(options.Input1);
            var main = VFPFingerPrint.Load(options.Input2);

            // The third argument is the maximal time shift searched, not a difference limit.
            var res = VFPCompare.Compare(fragment, main, options.MaxShift);

            var elapsed = DateTime.Now - time;
            Console.WriteLine("Analyze finished. Elapsed time: " + elapsed.ToString("g"));
            Console.WriteLine("Difference: " + res);

            if (res < options.Threshold)
            {
                Console.WriteLine("Input files are similar.");
            }
            else
            {
                Console.WriteLine("Input files are different.");
            }
        }
    }
}
