using System;
using System.IO;
using System.Threading;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.VideoEffects;

namespace lut_sample
{
    internal class Program
    {
        private static MediaBlocksPipeline _pipeline;

        private static Thread _thread;

        static void Main(string[] args)
        {
            Console.WriteLine("Initializing SDK...");
            VisioForgeX.InitSDK();

            _thread = new Thread((() =>
            {
                // Create pipeline
                _pipeline = new MediaBlocksPipeline();

                // Create video source
                var videoSource = new VirtualVideoSourceBlock();

                // Create video renderer
                var videoRenderer1 = new VideoRendererBlock(_pipeline, null);
                var videoRenderer2 = new VideoRendererBlock(_pipeline, null);

                // Create video tee
                var videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

                // Create LUT processor
                var lutPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bw.cube");
                var lutProcessor = new LUTProcessorBlock(new LUTVideoEffect(lutPath));

                // Connect blocks
                _pipeline.Connect(videoSource.Output, videoTee.Input);

                _pipeline.Connect(videoTee.Outputs[0], lutProcessor.Input);
                _pipeline.Connect(lutProcessor.Output, videoRenderer1.Input);

                _pipeline.Connect(videoTee.Outputs[1], videoRenderer2.Input);

                // Start pipeline
                _pipeline.Start();
            }));

            _thread.Start();

            Console.WriteLine("You should see two video windows on screen");
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();

            _pipeline.Stop();
            _thread.Join();

            _pipeline.Dispose();

            VisioForgeX.DestroySDK();

            Console.WriteLine("Done.");
        }
    }
}
