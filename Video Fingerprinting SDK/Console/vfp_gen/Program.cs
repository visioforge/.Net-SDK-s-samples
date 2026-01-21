using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vfpgen
{
    using CommandLine;
    using System.IO;
    using System.Threading.Tasks;
    using VisioForge.Core;
    using VisioForge.Core.Types;
    using VisioForge.Core.VideoFingerPrinting;

    class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        static async Task Main(string[] args)
        {
            Console.WriteLine(new CommandLineOptions().GetUsage());

            var options = CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args).Value;
            if (options == null)
            {
                return;
            }

            if (!File.Exists(options.InputFile))
            {
                Console.WriteLine("Source file not found: " + options.InputFile + ".");
                return;
            }

            if (File.Exists(options.OutputFile))
            {
                try
                {
                    File.Delete(options.OutputFile);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to delete output file: " + options.OutputFile + ". Exception: " + e.Message + ".");
                    return;
                }
            }

            await VisioForgeX.InitSDKAsync();

            VFPAnalyzer.SetLicenseKey(options.LicenseKey);

            Console.WriteLine("Starting analyze.");

            var time = DateTime.Now;

            var source = new VFPFingerprintSource(options.InputFile);
            if (options.Duration > 0)
            {
                source.StopTime = TimeSpan.FromMilliseconds(options.Duration);
            }

            VFPFingerPrint fp = null;
            if (options.Type == "search")
            {
                fp = await VFPAnalyzer.GetSearchFingerprintForVideoFileAsync(source, ErrorCallback);
            }
            else
            {
                fp = await VFPAnalyzer.GetComparingFingerprintForVideoFileAsync(source, ErrorCallback);
            }

            if (fp == null)
            {
                Console.WriteLine("Unable to get fingerprint.");
                return;
            }

            var elapsed = DateTime.Now - time;
            Console.WriteLine("Analyze finished. Elapsed time: " + elapsed.ToString("g"));

            fp.Save(options.OutputFile);

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Error callback.
        /// </summary>
        private static void ErrorCallback(string error)
        {
            Console.WriteLine(error);
        }
    }
}
