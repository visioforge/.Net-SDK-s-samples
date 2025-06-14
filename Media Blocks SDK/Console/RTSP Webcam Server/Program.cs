using System;
using System.Threading;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;

namespace RTSP_Webcam_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing VisioForge SDK.");
            // Initialize the VisioForge SDK
            VisioForgeX.InitSDK();

            var cameras = DeviceEnumerator.Shared.VideoSources();
            Console.WriteLine("Select the web camera");
            for (int i = 0; i < cameras.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {cameras[i].DisplayName}");
            }

            Console.Write("Enter the number of the camera: ");
            VideoCaptureDeviceInfo cameraInfo = null;
            if (int.TryParse(Console.ReadLine(), out int cameraIndex) && cameraIndex > 0 && cameraIndex <= cameras.Length)
            {
                cameraInfo = cameras[cameraIndex - 1];
                Console.WriteLine($"Selected camera: {cameraInfo.DisplayName}");
            }
            else
            {
                Console.WriteLine("Invalid selection. Exiting.");

                VisioForgeX.DestroySDK();
                return;
            }

            // Create pipeline
            var pipeline = new MediaBlocksPipeline();

            // Create a video source block for the selected camera
            var videoSourceSettings = new VideoCaptureDeviceSourceSettings(cameraInfo);
            videoSourceSettings.Format = cameraInfo.GetHDVideoFormatAndFrameRate(out var frameRate).ToFormat();
            videoSourceSettings.Format.FrameRate = frameRate;

            var cameraSource = new SystemVideoSourceBlock(videoSourceSettings);

            // Create an RTSP server block
            var rtspServerSettings = new RTSPServerSettings(H264EncoderBlock.GetDefaultSettings(), null)
            {
                Port = 8554, // Default RTSP port
            };

            var rtspBlock = new RTSPServerBlock(rtspServerSettings);

            Console.WriteLine("RTSP Server URL: " + rtspBlock.Settings.URL);

            // Connect the camera source to the RTSP server block
            pipeline.Connect(cameraSource.Output, rtspBlock.Input);

            // Start the pipeline
            Console.WriteLine("Starting the pipeline...");

            new Thread(() => {
                pipeline.Start();
            }).Start();

            Console.WriteLine("Pipeline started. Press any key to stop the server and exit.");
            Console.ReadKey();

            // Stop the pipeline
            Console.WriteLine("Stopping the pipeline...");

            pipeline.Stop();

            Console.WriteLine("Pipeline stopped.");

            // Clean up
            pipeline.Dispose();

            VisioForgeX.DestroySDK();
        }
    }
}
