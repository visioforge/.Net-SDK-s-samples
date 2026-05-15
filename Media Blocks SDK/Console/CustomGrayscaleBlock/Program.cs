using System;
using System.IO;
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Special;

namespace CustomGrayscaleBlockSample
{
    /// <summary>
    /// Demonstrates two ways of wrapping a GStreamer element ("videobalance"
    /// with saturation = 0, which produces grayscale) as a MediaBlock:
    ///
    ///   Path A — use the built-in <see cref="CustomMediaBlock"/> with
    ///            <see cref="CustomMediaBlockSettings"/>. Zero subclassing.
    ///
    ///   Path B — use the user-authored <see cref="MyGrayscaleBlock"/> in
    ///            this project, which inherits <see cref="MediaBlock"/> and
    ///            implements <see cref="IMediaBlockInternals"/>.
    ///
    /// Both pipelines: VirtualVideoSource → grayscale block → H264 → MP4.
    /// </summary>
    internal class Program
    {
        private const int Width = 1280;
        private const int Height = 720;
        private const int DurationSeconds = 5;

        private static async Task Main(string[] args)
        {
            Console.WriteLine("Custom Grayscale MediaBlock — sample");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine("NOTE: The SDK already ships a built-in GrayscaleBlock and");
            Console.WriteLine("      VideoBalanceBlock. This sample exists to teach the");
            Console.WriteLine("      technique of wrapping any GStreamer element as a");
            Console.WriteLine("      MediaBlock; grayscale is just a convenient example.");
            Console.WriteLine();

            VisioForgeX.InitSDK();
            try
            {
                var outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                if (string.IsNullOrEmpty(outputFolder) || !Directory.Exists(outputFolder))
                {
                    outputFolder = Directory.GetCurrentDirectory();
                }

                var pathA = Path.Combine(outputFolder, "custom_grayscale_pathA.mp4");
                var pathB = Path.Combine(outputFolder, "custom_grayscale_pathB.mp4");

                Console.WriteLine($"[Path A] CustomMediaBlock wrapping videobalance → {pathA}");
                await RunPathACustomMediaBlock(pathA);
                Console.WriteLine();

                Console.WriteLine($"[Path B] MyGrayscaleBlock (typed subclass)    → {pathB}");
                await RunPathBTypedSubclass(pathB);
                Console.WriteLine();

                Console.WriteLine("Done. Open the MP4s to compare — both should be grayscale.");
            }
            finally
            {
                VisioForgeX.DestroySDK();
            }
        }

        /// <summary>
        /// Path A — wrap "videobalance" with the built-in CustomMediaBlock.
        /// No subclassing, no extra files. The element name and property
        /// value are passed as data.
        /// </summary>
        private static async Task RunPathACustomMediaBlock(string outputFile)
        {
            var pipeline = new MediaBlocksPipeline();
            try
            {
                pipeline.OnError += (s, e) => Console.WriteLine($"  [A] pipeline error: {e.Message}");

                var source = new VirtualVideoSourceBlock(new VirtualVideoSourceSettings
                {
                    Width = Width,
                    Height = Height,
                    FrameRate = VideoFrameRate.FPS_30,
                    Pattern = VirtualVideoSourcePattern.SMPTE,
                });

                // Build the CustomMediaBlock settings: one sink + one src pad,
                // wrap "videobalance", set saturation = 0.0 (double — match
                // the GStreamer property type exactly).
                var settings = new CustomMediaBlockSettings("videobalance");
                settings.Pads.Add(new CustomMediaBlockPad(MediaBlockPadDirection.In, MediaBlockPadMediaType.Video));
                settings.Pads.Add(new CustomMediaBlockPad(MediaBlockPadDirection.Out, MediaBlockPadMediaType.Video));
                settings.ElementParams["saturation"] = 0.0;

                var grayscale = new CustomMediaBlock(settings);

                var encoder = new H264EncoderBlock();
                var sink = new MP4SinkBlock(new MP4SinkSettings(outputFile));

                pipeline.AddBlock(source);
                pipeline.AddBlock(grayscale);
                pipeline.AddBlock(encoder);
                pipeline.AddBlock(sink);

                pipeline.Connect(source.Output, grayscale.Input);
                pipeline.Connect(grayscale.Output, encoder.Input);
                pipeline.Connect(encoder.Output, sink.CreateNewInput(MediaBlockPadMediaType.Video));

                await pipeline.StartAsync();
                await Task.Delay(TimeSpan.FromSeconds(DurationSeconds));
                await pipeline.StopAsync();
            }
            finally
            {
                pipeline.Dispose();
            }
        }

        /// <summary>
        /// Path B — use the user-authored MyGrayscaleBlock from this project.
        /// </summary>
        private static async Task RunPathBTypedSubclass(string outputFile)
        {
            if (!MyGrayscaleBlock.IsAvailable())
            {
                Console.WriteLine("  [B] videobalance element is not available on this system, skipping.");
                return;
            }

            var pipeline = new MediaBlocksPipeline();
            try
            {
                pipeline.OnError += (s, e) => Console.WriteLine($"  [B] pipeline error: {e.Message}");

                var source = new VirtualVideoSourceBlock(new VirtualVideoSourceSettings
                {
                    Width = Width,
                    Height = Height,
                    FrameRate = VideoFrameRate.FPS_30,
                    Pattern = VirtualVideoSourcePattern.SMPTE,
                });

                var grayscale = new MyGrayscaleBlock();

                var encoder = new H264EncoderBlock();
                var sink = new MP4SinkBlock(new MP4SinkSettings(outputFile));

                pipeline.AddBlock(source);
                pipeline.AddBlock(grayscale);
                pipeline.AddBlock(encoder);
                pipeline.AddBlock(sink);

                pipeline.Connect(source.Output, grayscale.Input);
                pipeline.Connect(grayscale.Output, encoder.Input);
                pipeline.Connect(encoder.Output, sink.CreateNewInput(MediaBlockPadMediaType.Video));

                await pipeline.StartAsync();
                await Task.Delay(TimeSpan.FromSeconds(DurationSeconds));
                await pipeline.StopAsync();
            }
            finally
            {
                pipeline.Dispose();
            }
        }
    }
}
