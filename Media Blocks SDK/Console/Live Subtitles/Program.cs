using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using VisioForge.Core;
using VisioForge.Core.AI.Whisper.Subtitles;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Special;

using Whisper.net.Ggml;

namespace LiveSubtitlesConsole
{
    /// <summary>
    /// Console speech-to-text test harness: transcribes a media file with Whisper losslessly (the
    /// synchronous block paces the source to Whisper, so it runs at max speed without dropping audio), and
    /// prints recognized text, live position/duration progress, and the SDK's own diagnostic log lines.
    /// With --realtime the file plays at 1x through the speakers instead and captions are printed when
    /// playback reaches them.
    /// Usage: LiveSubtitles &lt;media-file&gt; [language] [--realtime].
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

            var realtime = Array.IndexOf(args, "--realtime") >= 0;
            var positional = Array.FindAll(args, a => !a.StartsWith("--", StringComparison.Ordinal));

            Console.WriteLine("VisioForge - speech-to-text console TEST harness " + (realtime ? "(real-time playback)" : "(lossless, max speed)"));
            Console.WriteLine("Usage: LiveSubtitles <media-file> [language] [--realtime]   (language defaults to 'auto')");
            Console.WriteLine("  --realtime: play the file at 1x through the speakers and print each caption when playback");
            Console.WriteLine("              reaches it. Off by default - this harness measures transcription speed.");
            Console.WriteLine();

            if (positional.Length == 0)
            {
                Console.WriteLine("Please pass a media file (mp4/mkv/wav/mp3/m4a/...) as the first argument.");
                return 1;
            }

            var mediaFile = positional[0];
            if (!File.Exists(mediaFile))
            {
                Console.WriteLine($"File not found: {mediaFile}");
                return 1;
            }

            var language = positional.Length > 1 ? positional[1] : "auto";

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

                // Real-time mode buffers the captions and prints them from the position poll instead of on arrival.
                var timeline = realtime ? new CaptionTimeline() : null;

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

                            if (timeline == null)
                            {
                                Console.WriteLine($"[{seg.StartTime:hh\\:mm\\:ss}] {seg.Text.Trim()}");
                            }
                        }
                    }

                    timeline?.Add(e);
                };

                // In max-speed mode nothing clocks the transcriber's leg, so the pipeline runs as fast as Whisper
                // can transcribe. In real-time mode this sink is on the clock too: a pipeline position query
                // answers with the furthest-advanced sink, so an unsynced one here would report the
                // transcriber's front - seconds ahead of the audio - and every caption would appear early.
                var sink = new NullRendererBlock(MediaBlockPadMediaType.Audio) { IsSync = realtime };

                bool connected;
                if (realtime)
                {
                    // A 10-second buffer on the transcriber's leg absorbs a Whisper inference burst so it does not stall
                    // the speakers. The queue must NOT be leaky: segment times come from a sample counter, not from buffer
                    // timestamps, so a dropped buffer would shift every later caption and SRT line earlier.
                    // ponytail: a machine that cannot keep up with real time stutters the playback instead - visible,
                    // rather than a transcript that silently drifts out of step.
                    var queueSettings = new TeeQueueSettings
                    {
                        MaxSizeBuffers = 0,
                        MaxSizeBytes = 0,
                        MaxSizeTime = (ulong)TimeSpan.FromSeconds(10).TotalMilliseconds * 1000000,
                        Leaky = TeeQueueLeaky.No,
                    };

                    var tee = new TeeBlock(2, MediaBlockPadMediaType.Audio, queueSettings);
                    var audioRenderer = new AudioRendererBlock();

                    connected = pipeline.Connect(audioPad, tee.Input)
                        && pipeline.Connect(tee.Outputs[0], audioRenderer.Input)
                        && pipeline.Connect(tee.Outputs[1], stt.Input)
                        && pipeline.Connect(stt.Output, sink.Input);
                }
                else
                {
                    connected = pipeline.Connect(audioPad, stt.Input) && pipeline.Connect(stt.Output, sink.Input);
                }

                if (!connected)
                {
                    Console.WriteLine("Failed to build the audio pipeline.");
                    return 1;
                }

                Console.WriteLine($"Transcribing '{Path.GetFileName(mediaFile)}' (language: {language}, mode: {(realtime ? "real-time playback" : "max speed")})...");
                Console.WriteLine("Press Enter to stop early.");
                Console.WriteLine();

                var wall = Stopwatch.StartNew();
                await pipeline.StartAsync();

                // Progress reporter: pipeline position vs duration (duration is polled lazily inside it).
                var durationBox = new TimeSpan[1];
                using var progressCts = new CancellationTokenSource();
                var progressTask = ReportProgressAsync(pipeline, () => lastSegmentEnd, wall, durationBox, timeline, progressCts.Token);

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

                // speed is file duration over wall time: how much faster than real time Whisper ran. In --realtime
                // mode the audio renderer's clock paces the run, so ~1.0x is the expected reading, not a slow one.
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

        private static async Task ReportProgressAsync(MediaBlocksPipeline pipeline, Func<TimeSpan> lastSegmentEnd, Stopwatch wall, TimeSpan[] durationBox, CaptionTimeline timeline, CancellationToken token)
        {
            var lastCaption = string.Empty;

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

                    // Real-time mode: the caption for the current position, printed once when it changes.
                    if (timeline != null)
                    {
                        var caption = timeline.TextAt(pos);
                        if (caption != lastCaption)
                        {
                            lastCaption = caption;
                            if (caption.Length > 0)
                            {
                                Console.WriteLine($"[{pos:hh\\:mm\\:ss}] {caption}");
                            }
                        }
                    }

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
