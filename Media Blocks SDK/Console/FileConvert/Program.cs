using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace FileConvert
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("The application can convert any source video file to an MP4 file. Use the source file name as the first parameter.");

            if (args.Length == 0) {
                Console.WriteLine("Please specify the source file name as the first parameter.");
                return;
            }

            var sourceFile = args[0];

            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("Source file not found.");
                return;
            }

            // Create the pipeline
            var pipeline = new MediaBlocksPipeline();

            pipeline.OnError += Pipeline_OnError;
            pipeline.OnStop += Pipeline_OnStop;

            // Add source
            var sourceSettings = await UniversalSourceSettings.CreateAsync(sourceFile);
            var source = new UniversalSourceBlock(sourceSettings);

            // Add H264/AAC encoders with default settings
            var h264Encoder = new H264EncoderBlock();
            var aacEncoder = new AACEncoderBlock();

            // Add MP4 sink
            var filename = Path.Combine(Path.GetDirectoryName(sourceFile), Path.GetFileNameWithoutExtension(sourceFile) + "_new.mp4");

            var settings = new MP4SinkSettings(filename);
            var mp4Sink = new MP4SinkBlock(settings);

            // Connect everything
            pipeline.Connect(source.VideoOutput, h264Encoder.Input);
            pipeline.Connect(h264Encoder.Output, mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video));
            pipeline.Connect(source.AudioOutput, aacEncoder.Input);
            pipeline.Connect(aacEncoder.Output, mp4Sink.CreateNewInput(MediaBlockPadMediaType.Audio));

            // Start the pipeline
            Console.WriteLine("Convering...");

            pipeline.Start();

            Thread.Sleep(2000);

            while (pipeline.State == VisioForge.Core.Types.PlaybackState.Play)
            {
                Thread.Sleep(500);
            }

            // All done. Stop the pipeline and dispose
            pipeline.Stop();
            pipeline.Dispose();

            // Release SDK
            VisioForgeX.DestroySDK();
        }

        private static void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Console.WriteLine("Convering...Done.");
        }

        private static void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}