using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;

namespace DynamicTextOverlaySample
{
    /// <summary>
    /// Records FullHD 50 fps video with a text overlay whose last line is rebuilt on every frame
    /// from a live sensor value, the wall clock and the frame timestamp - and a second overlay that
    /// is only visible for the first seconds.
    /// </summary>
    class Program
    {
        private const int DurationSeconds = 6;

        // Stands in for a real sensor. Written by a background loop, read by the overlay's
        // TextProvider on the streaming thread - float so the read is atomic without a lock.
        private static volatile float _sensorValue;

        // Counts how many times the provider was asked for text, to show it really is per-frame.
        private static int _providerCalls;

        static async Task Main(string[] args)
        {
            Console.WriteLine("DynamicTextOverlay - per-frame text in OverlayManagerBlock");
            Console.WriteLine("=========================================================");
            Console.WriteLine();

            VisioForgeX.InitSDK();

            var outputFile = args.Length > 0
                ? args[0]
                : Path.Combine(Path.GetTempPath(), "dynamic_text_overlay.mp4");

            await RecordAsync(outputFile);

            VisioForgeX.DestroySDK();
        }

        static async Task RecordAsync(string outputFile)
        {
            var pipeline = new MediaBlocksPipeline();

            try
            {
                // FullHD 50 fps in NV12 - the customer scenario, and the format that makes the
                // overlay do a real colorspace conversion rather than a passthrough.
                var source = new VirtualVideoSourceBlock(new VirtualVideoSourceSettings
                {
                    Width = 1920,
                    Height = 1080,
                    FrameRate = new VideoFrameRate(50, 1),
                    Format = VideoFormatX.NV12,
                    Pattern = VirtualVideoSourcePattern.SMPTE
                });

                var overlay = new OverlayManagerBlock();

                // Three fixed lines plus one that changes every frame. The provider runs on the
                // GStreamer streaming thread, so it must be short and must not block.
                var readout = new OverlayManagerText(string.Empty, 60, 80)
                {
                    Name = "readout",
                    Color = SkiaSharp.SKColors.Yellow
                };
                readout.Font.Size = 40;
                readout.TextProvider = ts =>
                {
                    Interlocked.Increment(ref _providerCalls);
                    return "CAMERA 1\nOPERATOR: DEMO\nREC\n"
                        + $"SENSOR {_sensorValue:F1}  {DateTime.Now:HH:mm:ss}  T {ts:mm\\:ss\\.ff}";
                };
                overlay.Video_Overlay_Add(readout);

                // Visible for the first two seconds only. EndTime alone is enough - a zero
                // StartTime means "from the beginning".
                var banner = new OverlayManagerText("STARTING UP", 60, 460)
                {
                    Name = "banner",
                    Color = SkiaSharp.SKColors.Cyan,
                    EndTime = TimeSpan.FromSeconds(2)
                };
                banner.Font.Size = 56;
                overlay.Video_Overlay_Add(banner);

                var encoder = new H264EncoderBlock();
                var sink = new MP4SinkBlock(new MP4SinkSettings(outputFile));

                pipeline.Connect(source.Output, overlay.Input);
                pipeline.Connect(overlay.Output, encoder.Input);
                pipeline.Connect(encoder.Output, sink.CreateNewInput(MediaBlockPadMediaType.Video));

                pipeline.OnError += (sender, e) => Console.WriteLine($"Pipeline error: {e.Message}");

                Console.WriteLine($"Recording {DurationSeconds}s of 1920x1080@50 to {outputFile}");
                await pipeline.StartAsync();

                // Drive the stand-in sensor while recording.
                for (var i = 0; i < DurationSeconds * 4; i++)
                {
                    _sensorValue = 20f + (i % 40) / 2f;
                    await Task.Delay(250);
                }

                await pipeline.StopAsync();

                var calls = Volatile.Read(ref _providerCalls);
                Console.WriteLine($"TextProvider calls: {calls} (about {DurationSeconds * 50} frames expected)");
                Console.WriteLine($"Saved: {outputFile}");
                Console.WriteLine("The yellow block updates every frame; the cyan banner disappears after 2 s.");
            }
            finally
            {
                pipeline.Dispose();
            }
        }
    }
}
