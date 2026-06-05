using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Special;

namespace TS_Analyzer_CLI
{
    // Analyzes an MPEG transport stream (local .ts/.m2ts file or a live udp://
    // or srt:// broadcast) and prints services, PIDs, per-PID bitrate and
    // integrity (PCR / continuity) statistics.
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: TS Analyzer CLI <source>");
                Console.WriteLine("  <source> = path to a .ts/.m2ts file, or udp://host:port, or srt://host:port");
                return;
            }

            var source = args[0];

            await VisioForgeX.InitSDKAsync();

            var pipeline = new MediaBlocksPipeline();
            var completed = new TaskCompletionSource<bool>();
            pipeline.OnError += (s, e) => Console.WriteLine($"[ERROR] {e.Message}");
            pipeline.OnStop += (s, e) => completed.TrySetResult(true);

            try
            {
                // Source-block creation can throw (invalid URI, missing file, SRT connect
                // failure). Keep it inside the try so a bad input prints a clean [ERROR] and
                // the finally below still disposes the pipeline / SDK instead of crashing.
                MediaBlockPad sourcePad;
                bool isLive;

                if (source.StartsWith("udp://", StringComparison.OrdinalIgnoreCase))
                {
                    var block = new UDPRAWMPEGTSSourceBlock(new UDPRAWMPEGTSSourceSettings(source));
                    sourcePad = block.Output;
                    isLive = true;
                }
                else if (source.StartsWith("srt://", StringComparison.OrdinalIgnoreCase))
                {
                    var settings = await SRTSourceSettings.CreateAsync(new Uri(source), ignoreMediaInfoReader: true);
                    var block = new SRTRAWSourceBlock(settings);
                    sourcePad = block.Output;
                    isLive = true;
                }
                else
                {
                    var block = new BasicFileSourceBlock(source);
                    sourcePad = block.Output;
                    isLive = false;
                }

                var analyzer = new TSAnalyzerBlock(TSAnalyzerMode.Input,
                    new TSAnalyzerSettings { StatisticsInterval = TimeSpan.FromSeconds(1) });
                analyzer.OnAnalysisUpdated += (s, e) =>
                {
                    if (!e.IsFinal)
                    {
                        PrintReport(e.Report, source, final: false);
                    }
                };

                pipeline.Connect(sourcePad, analyzer.Input);

                Console.WriteLine($"Analyzing: {source}");
                Console.WriteLine(isLive ? "Press ENTER to stop." : "Analyzing file until end of stream...");

                await pipeline.StartAsync();

                if (isLive)
                {
                    // Stop on EITHER the user pressing Enter OR the pipeline stopping on
                    // its own (live source EOS / error fires OnStop -> completed.Task), so
                    // a stream that drops does not leave the CLI hung on Console.ReadLine().
                    await Task.WhenAny(completed.Task, Task.Run(() => Console.ReadLine()));
                }
                else
                {
                    await completed.Task;
                }

                await pipeline.StopAsync(force: true);

                PrintReport(analyzer.GetReport(), source, final: true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }
            finally
            {
                pipeline.Dispose();
                VisioForgeX.DestroySDK();
            }
        }

        private static void PrintReport(TSAnalyzerReport report, string source, bool final)
        {
            if (report == null)
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine(new string('=', 78));
            Console.WriteLine($"{(final ? "FINAL " : string.Empty)}TS analysis  |  packet size: {report.PacketSize}  |  " +
                              $"total: {report.TotalBitrateKbps:F0} kbps  |  packets: {report.TotalPackets}  |  " +
                              $"PAT: {(report.HasPAT ? "yes" : "no")}  |  transport errors: {report.TransportErrors}");
            Console.WriteLine(new string('-', 78));

            // Service / provider / type + scrambling, from the first program.
            var firstProgram = report.Programs.FirstOrDefault();
            if (firstProgram != null && (!string.IsNullOrEmpty(firstProgram.ServiceName) ||
                                         !string.IsNullOrEmpty(firstProgram.ServiceProvider)))
            {
                var name = string.IsNullOrEmpty(firstProgram.ServiceName) ? "?" : firstProgram.ServiceName;
                var provider = string.IsNullOrEmpty(firstProgram.ServiceProvider) ? "?" : firstProgram.ServiceProvider;
                Console.WriteLine($"Service: {name}  |  provider: {provider}  |  type: 0x{firstProgram.ServiceType:X2}  |  " +
                                  $"scrambled: {(firstProgram.IsScrambled ? "yes" : "no")}");
            }

            // Map PID -> elementary-stream descriptor for language / codec details.
            var pidToStream = new Dictionary<int, TSElementaryStreamInfo>();
            foreach (var program in report.Programs)
            {
                foreach (var es in program.Streams)
                {
                    pidToStream[es.Pid] = es;
                }
            }

            foreach (var program in report.Programs)
            {
                Console.WriteLine($"Program {program.ProgramNumber}  (PMT PID {program.PmtPid}, PCR PID {program.PcrPid})");
                foreach (var es in program.Streams)
                {
                    var lang = string.IsNullOrEmpty(es.Language) ? string.Empty : $"  [{es.Language}]";
                    Console.WriteLine($"    PID {es.Pid,-6} {es.Kind,-8} type 0x{es.StreamType:X2}  {es.Codec}{lang}");
                }
            }

            Console.WriteLine(new string('-', 78));
            Console.WriteLine($"{"PID",-8}{"Kind",-9}{"Codec",-18}{"Bitrate",12}{"Peak",11}{"Lang",6}{"Packets",12}{"CC err",9}{"PCR",5}{"Scr",5}");
            foreach (var pid in report.Pids.OrderByDescending(p => p.BitrateKbps))
            {
                pidToStream.TryGetValue(pid.Pid, out var es);
                var lang = es?.Language ?? string.Empty;
                var peak = pid.PeakBitrateKbps > 0 ? pid.PeakBitrateKbps.ToString("F0") + " k" : string.Empty;
                Console.WriteLine($"{pid.Pid,-8}{pid.Kind,-9}{Trim(pid.Codec, 17),-18}{pid.BitrateKbps,10:F0} k{peak,11}{lang,6}" +
                                  $"{pid.PacketCount,12}{pid.ContinuityErrors,9}{(pid.IsPcrPid ? " *" : ""),5}{(pid.IsScrambled ? " S" : ""),5}");
            }

            foreach (var pcr in report.Pcr)
            {
                Console.WriteLine($"PCR PID {pcr.Pid}: samples {pcr.SampleCount}, interval min/avg/max " +
                                  $"{pcr.MinIntervalMs:F1}/{pcr.AvgIntervalMs:F1}/{pcr.MaxIntervalMs:F1} ms, " +
                                  $"discontinuities {pcr.Discontinuities}");
            }

            // Null padding / effective payload bitrate.
            if (report.TotalBitrateKbps > 0)
            {
                var nullPct = report.NullBitrateKbps / report.TotalBitrateKbps * 100.0;
                Console.WriteLine($"Null padding: {report.NullPacketCount} packets, {report.NullBitrateKbps:F0} kbps " +
                                  $"({nullPct:F1}% of total)  |  effective payload: {report.EffectiveBitrateKbps:F0} kbps");
            }

            // Network name / stream UTC, when present.
            if (!string.IsNullOrEmpty(report.NetworkName) || report.StreamTimeUtc.HasValue)
            {
                var net = string.IsNullOrEmpty(report.NetworkName) ? "?" : report.NetworkName;
                var utc = report.StreamTimeUtc.HasValue ? report.StreamTimeUtc.Value.ToString("yyyy-MM-dd HH:mm:ss") : "?";
                Console.WriteLine($"Network: {net}  |  stream UTC: {utc}");
            }

            // Audio/video synchronization offset (video PTS minus audio PTS).
            if (report.AvSyncMs.HasValue)
            {
                Console.WriteLine($"A/V sync: {report.AvSyncMs.Value:F0} ms (video minus audio)");
            }

            // ETSI TR 101 290 measurement report, grouped by priority.
            var tr = report.Tr101290;
            if (tr != null)
            {
                Console.WriteLine(new string('-', 78));
                Console.WriteLine($"TR 101 290:  P1={tr.P1Count}  P2={tr.P2Count}  P3={tr.P3Count}  (total {tr.TotalCount})");
                foreach (var priority in new[] { 1, 2, 3 })
                {
                    foreach (var check in tr.Checks.Where(c => c.Priority == priority && c.Count > 0).OrderBy(c => c.Name))
                    {
                        Console.WriteLine($"    P{priority} {check.Name}: {check.Count}");
                    }
                }
            }

            // EPG events, when EPG parsing produced any.
            if (report.Events.Count > 0)
            {
                Console.WriteLine(new string('-', 78));
                Console.WriteLine($"EPG events ({report.Events.Count}):");
                foreach (var ev in report.Events.Take(20))
                {
                    var start = ev.StartTimeUtc.HasValue ? ev.StartTimeUtc.Value.ToString("yyyy-MM-dd HH:mm") : "?";
                    var name = string.IsNullOrEmpty(ev.Name) ? "(no name)" : ev.Name;
                    Console.WriteLine($"    svc {ev.ServiceId} #{ev.EventId} {start} +{ev.Duration:hh\\:mm\\:ss}  {name}");
                }
            }

            // Codec details for video elementary streams.
            var videoStreams = report.Programs.SelectMany(p => p.Streams)
                .Where(s => s.Kind == TSPidKind.Video && s.CodecDetails != null).ToList();
            if (videoStreams.Count > 0)
            {
                Console.WriteLine(new string('-', 78));
                foreach (var vs in videoStreams)
                {
                    var cd = vs.CodecDetails;
                    var fps = cd.FrameRateDen > 0 ? (double)cd.FrameRateNum / cd.FrameRateDen : 0.0;
                    Console.WriteLine($"Video PID {vs.Pid} ({vs.Codec}): {cd.Width}x{cd.Height}" +
                                      (fps > 0 ? $" @ {fps:F2} fps" : string.Empty) +
                                      (!string.IsNullOrEmpty(cd.Profile) ? $", profile {cd.Profile}" : string.Empty) +
                                      (!string.IsNullOrEmpty(cd.Level) ? $", level {cd.Level}" : string.Empty) +
                                      (!string.IsNullOrEmpty(cd.ChromaFormat) ? $", chroma {cd.ChromaFormat}" : string.Empty) +
                                      (!string.IsNullOrEmpty(cd.AspectRatio) ? $", aspect {cd.AspectRatio}" : string.Empty));
                }
            }
        }

        private static string Trim(string value, int max)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value.Length <= max ? value : value.Substring(0, max);
        }
    }
}
