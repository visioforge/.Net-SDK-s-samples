using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

using Whisper.net.Ggml;

namespace LiveSubtitlesConsole
{
    /// <summary>
    /// Console speech-to-text test harness: transcribes a media file with Whisper losslessly (the
    /// synchronous block paces the source to Whisper, so it runs at max speed without dropping audio), and
    /// prints recognized text, live position/duration progress, and the SDK's own diagnostic log lines.
    /// Usage: LiveSubtitles &lt;media-file&gt; [language].
    /// </summary>
    internal static class Program
    {
        // Models are cached under %USERPROFILE%/VisioForge/models (same location the WPF demo uses).
        private static readonly string ModelsDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        // Silero VAD v5 ONNX model (MIT), hosted on the samples GitHub release alongside the other models.
        private const string SileroVadUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1/silero_vad.onnx";

        private static async Task<int> Main(string[] args)
        {
            // Route the SDK's internal diagnostics to the console so block log lines are visible when headless.
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;

            Console.WriteLine("VisioForge - speech-to-text console TEST harness (lossless)");
            Console.WriteLine("Usage: LiveSubtitles <media-file> [language]   (language defaults to 'auto')");
            Console.WriteLine();

            if (args.Length == 0)
            {
                Console.WriteLine("Please pass a media file (mp4/mkv/wav/mp3/m4a/...) as the first argument.");
                return 1;
            }

            var mediaFile = args[0];
            if (!File.Exists(mediaFile))
            {
                Console.WriteLine($"File not found: {mediaFile}");
                return 1;
            }

            var language = args.Length > 1 ? args[1] : "auto";

            string whisperModel, sileroModel;
            try
            {
                whisperModel = await EnsureWhisperModelAsync(GgmlType.Base);
                sileroModel = await EnsureSileroModelAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Model download failed: " + ex.Message);
                return 1;
            }

            await VisioForgeX.InitSDKAsync();

            var pipeline = new MediaBlocksPipeline();
            var done = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            pipeline.OnError += (s, e) => { Console.WriteLine("[pipeline][error] " + e.Message); done.TrySetResult(false); };
            pipeline.OnStop += (s, e) => { Console.WriteLine("[pipeline] OnStop"); done.TrySetResult(true); };

            var lastSegmentEnd = TimeSpan.Zero;
            var pipelineFailed = false;

            SpeechToTextBlock stt = null;
            try
            {
                var settings = new SpeechToTextSettings(whisperModel)
                {
                    Language = language,
                    Provider = OnnxExecutionProvider.Auto, // CUDA when available, else CPU
                    EnableVad = true,
                };
                settings.Vad.ModelPath = sileroModel;

                var source = new UniversalSourceBlock(
                    await UniversalSourceSettings.CreateAsync(mediaFile, renderVideo: false, renderAudio: true));
                var audioPad = source.AudioOutput;
                if (audioPad == null)
                {
                    Console.WriteLine("The selected file has no audio track to transcribe.");
                    return 1;
                }

                stt = new SpeechToTextBlock(settings);
                stt.OnSpeechRecognized += (s, e) =>
                {
                    if (e?.Segments == null)
                    {
                        return;
                    }

                    foreach (var seg in e.Segments)
                    {
                        if (!string.IsNullOrWhiteSpace(seg?.Text))
                        {
                            if (seg.EndTime > lastSegmentEnd)
                            {
                                lastSegmentEnd = seg.EndTime;
                            }

                            Console.WriteLine($"[{seg.StartTime:hh\\:mm\\:ss}] {seg.Text.Trim()}");
                        }
                    }
                };

                // Non-synced null sink: no real-time clock caps the speed, so the pipeline runs as fast as Whisper can transcribe.
                var sink = new NullRendererBlock(MediaBlockPadMediaType.Audio) { IsSync = false };

                if (!pipeline.Connect(audioPad, stt.Input) || !pipeline.Connect(stt.Output, sink.Input))
                {
                    Console.WriteLine("Failed to build the audio pipeline.");
                    return 1;
                }

                Console.WriteLine($"Transcribing '{Path.GetFileName(mediaFile)}' (language: {language})...");
                Console.WriteLine("Press Enter to stop early.");
                Console.WriteLine();

                var wall = Stopwatch.StartNew();
                await pipeline.StartAsync();

                // Progress reporter: pipeline position vs duration (duration is polled lazily inside it).
                var durationBox = new TimeSpan[1];
                using var progressCts = new CancellationTokenSource();
                var progressTask = ReportProgressAsync(pipeline, () => lastSegmentEnd, wall, durationBox, progressCts.Token);

                var finished = await Task.WhenAny(done.Task, Task.Run(() => Console.ReadLine()));
                progressCts.Cancel();
                var stoppedByUser = finished != done.Task;

                // Pipeline-ended run: OnError completed done with false — surface that as a nonzero exit code.
                if (!stoppedByUser)
                {
                    pipelineFailed = !await done.Task;
                }

                await pipeline.StopAsync();
                wall.Stop();

                var finalDuration = durationBox[0] > TimeSpan.Zero ? durationBox[0] : await SafeDurationAsync(pipeline);
                Console.WriteLine();
                Console.WriteLine($"[summary] stoppedByUser={stoppedByUser} fileDuration={finalDuration:hh\\:mm\\:ss} " +
                    $"lastSegmentEnd={lastSegmentEnd:hh\\:mm\\:ss} wallTime={wall.Elapsed:hh\\:mm\\:ss} " +
                    $"speed={(finalDuration.TotalSeconds > 0 && wall.Elapsed.TotalSeconds > 0 ? finalDuration.TotalSeconds / wall.Elapsed.TotalSeconds : 0):F1}x");
            }
            finally
            {
                await pipeline.DisposeAsync();
                stt?.Dispose();
                VisioForgeX.DestroySDK();
            }

            Console.WriteLine("Done.");
            return pipelineFailed ? 1 : 0;
        }

        private static async Task ReportProgressAsync(MediaBlocksPipeline pipeline, Func<TimeSpan> lastSegmentEnd, Stopwatch wall, TimeSpan[] durationBox, CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    await Task.Delay(1000, token);

                    // Resolve duration lazily — it isn't known the instant the pipeline starts.
                    if (durationBox[0] <= TimeSpan.Zero)
                    {
                        durationBox[0] = await SafeDurationAsync(pipeline);
                    }

                    var pos = await pipeline.Position_GetAsync();
                    Console.WriteLine($"[progress] pos={pos:hh\\:mm\\:ss} lastSeg={lastSegmentEnd():hh\\:mm\\:ss} dur={durationBox[0]:hh\\:mm\\:ss} wall={wall.Elapsed:hh\\:mm\\:ss}");
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private static async Task<TimeSpan> SafeDurationAsync(MediaBlocksPipeline pipeline)
        {
            try
            {
                return await pipeline.DurationAsync();
            }
            catch
            {
                return TimeSpan.Zero;
            }
        }

        /// <summary>Downloads the Whisper GGML model to the cache if it is not already present.</summary>
        private static async Task<string> EnsureWhisperModelAsync(GgmlType type)
        {
            Directory.CreateDirectory(ModelsDir);
            var dest = Path.Combine(ModelsDir, $"ggml-{type.ToString().ToLowerInvariant()}.bin");
            if (File.Exists(dest))
            {
                return dest;
            }

            Console.WriteLine($"Downloading Whisper model ({type})...");
            var temp = dest + ".part";
            using (var modelStream = await WhisperGgmlDownloader.Default.GetGgmlModelAsync(type))
            using (var fileStream = File.Create(temp))
            {
                await modelStream.CopyToAsync(fileStream);
            }

            File.Move(temp, dest);
            Console.WriteLine($"Saved {Path.GetFileName(dest)} ({new FileInfo(dest).Length / 1024 / 1024} MB).");
            return dest;
        }

        /// <summary>Downloads the Silero VAD ONNX model to the cache if it is not already present.</summary>
        private static async Task<string> EnsureSileroModelAsync()
        {
            Directory.CreateDirectory(ModelsDir);
            var dest = Path.Combine(ModelsDir, "silero_vad.onnx");
            if (File.Exists(dest))
            {
                return dest;
            }

            Console.WriteLine("Downloading Silero VAD model...");
            var temp = dest + ".part";
            using (var http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) })
            using (var response = await http.GetAsync(SileroVadUrl, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                using (var fileStream = File.Create(temp))
                {
                    await response.Content.CopyToAsync(fileStream);
                }
            }

            File.Move(temp, dest);
            Console.WriteLine($"Saved {Path.GetFileName(dest)} ({new FileInfo(dest).Length / 1024} KB).");
            return dest;
        }
    }
}
