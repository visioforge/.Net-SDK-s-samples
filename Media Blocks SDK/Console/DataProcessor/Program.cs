using System;
using System.Threading.Tasks;
using Gst;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sinks;
using System.IO;

namespace DataProcessorSample
{
    public class GrayscaleProcessorBlock : DataProcessorBlock
    {
        public GrayscaleProcessorBlock() : base("video/x-raw")
        {
        }

        protected override FlowReturn ProcessBuffer(Gst.Buffer buffer, Gst.Caps caps)
        {
            var structure = caps.GetStructure(0);
            if (structure == null)
                return FlowReturn.Error;

            structure.GetInt("width", out int width);
            structure.GetInt("height", out int height);
            var format = structure.GetString("format");

            if (width == 0 || height == 0 || string.IsNullOrEmpty(format))
                return FlowReturn.Error;

            MapInfo mapInfo;
            if (!buffer.Map(out mapInfo, MapFlags.Read | MapFlags.Write))
                return FlowReturn.Error;

            try
            {
                unsafe
                {
                    byte* data = (byte*)mapInfo.DataPtr.ToPointer();
                    
                    if (format == "RGB")
                    {
                        int pixelCount = width * height;
                        for (int i = 0; i < pixelCount; i++)
                        {
                            int offset = i * 3;
                            byte r = data[offset];
                            byte g = data[offset + 1];
                            byte b = data[offset + 2];
                            
                            byte gray = (byte)(0.299 * r + 0.587 * g + 0.114 * b);
                            
                            data[offset] = gray;
                            data[offset + 1] = gray;
                            data[offset + 2] = gray;
                        }
                    }
                    else if (format == "I420")
                    {
                        int ySize = width * height;
                        int uvSize = ySize / 4;
                        
                        for (int i = ySize; i < ySize + uvSize * 2; i++)
                        {
                            data[i] = 128;
                        }
                    }
                }
            }
            finally
            {
                buffer.Unmap(mapInfo);
            }

            return FlowReturn.Ok;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("DataProcessor Grayscale Sample");
            Console.WriteLine("==============================");

            // Initialize the SDK
            Console.WriteLine("Initializing SDK...");
            VisioForgeX.InitSDK();
            Console.WriteLine("SDK initialized");

            var pipeline = new MediaBlocksPipeline();

            var source = new VirtualVideoSourceBlock(640, 480, VideoFrameRate.FPS_30);
            
            var processor = new GrayscaleProcessorBlock();
            
            var h264Encoder = new H264EncoderBlock();

            var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output_grayscale.mp4");
            var mp4Sink = new MP4SinkBlock(new MP4SinkSettings(outputFile));

            pipeline.AddBlock(source);
            pipeline.AddBlock(processor);
            pipeline.AddBlock(h264Encoder);
            pipeline.AddBlock(mp4Sink);

            pipeline.Connect(source.Output, processor.Input);
            pipeline.Connect(processor.Output, h264Encoder.Input);
            pipeline.Connect(h264Encoder.Output, mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video));

            pipeline.OnError += (sender, e) =>
            {
                Console.WriteLine($"Pipeline error: {e.Message}");
            };

            pipeline.OnStop += (sender, e) =>
            {
                Console.WriteLine("Pipeline stopped");
            };

            var duration = TimeSpan.FromSeconds(10);
            Console.WriteLine($"Creating {duration.TotalSeconds} seconds of grayscale video...");

            Console.WriteLine("Starting pipeline...");
            await pipeline.StartAsync();
            Console.WriteLine("Pipeline started");

            Console.WriteLine($"Recording for {duration.TotalSeconds} seconds...");
            await Task.Delay(duration);

            Console.WriteLine("Stopping pipeline...");
            await pipeline.StopAsync();
            Console.WriteLine("Pipeline stopped");
            
            pipeline.Dispose();
            
            VisioForgeX.DestroySDK();

            Console.WriteLine($"Grayscale video saved to: {outputFile}");
            Console.WriteLine("Done!");
        }
    }
}