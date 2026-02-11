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
            CommandLineOptions options = null;
            var parseResult = CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args);
            parseResult.WithParsed(opts => options = opts)
                       .WithNotParsed(errors =>
                       {
                           Console.WriteLine(new CommandLineOptions().GetUsage());
                       });

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

            try
            {
                VFPAnalyzer.SetLicenseKey(options.LicenseKey);

                Console.WriteLine("Starting analyze.");

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

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

                stopwatch.Stop();
                Console.WriteLine("Analyze finished. Elapsed time: " + stopwatch.Elapsed.ToString("g"));

                fp.Save(options.OutputFile);
            }
            finally
            {
                VisioForgeX.DestroySDK();
            }
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
