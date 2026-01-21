using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using SkiaSharp;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;

namespace RTSP_Image_Server
{
    /// <summary>
    /// Represents the program for RTSP Image Server.
    /// </summary>
    internal class Program
    {
        private static MediaBlocksPipeline _pipeline;
        private static VirtualVideoSourceBlock _virtualSource;
        private static VideoSampleGrabberBlock _sampleGrabber;
        private static byte[][] _imageData;
        private static int _currentImageIndex = 0;
        private static DateTime _lastImageSwitch = DateTime.Now;
        private const int IMAGE_WIDTH = 1280;
        private const int IMAGE_HEIGHT = 720;
        private const int FPS = 25; // VirtualVideoSource frame rate
        private const double IMAGE_DISPLAY_SECONDS = 1.0; // Display each image for 1 second

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        static async Task Main(string[] args)
        {
            Console.WriteLine("RTSP Image Server - VisioForge Media Blocks SDK");
            Console.WriteLine("================================================");
            Console.WriteLine();

            // Initialize the VisioForge SDK
            Console.WriteLine("Initializing VisioForge SDK...");
            VisioForgeX.InitSDK();

            // Load images as raw byte arrays
            Console.WriteLine("Loading images...");
            _imageData = LoadImagesAsRawData();

            if (_imageData == null || _imageData.Length == 0)
            {
                Console.WriteLine("Error: No images loaded. Exiting.");
                VisioForgeX.DestroySDK();
                return;
            }

            Console.WriteLine($"Loaded {_imageData.Length} images.");

            // Create pipeline
            Console.WriteLine("Creating pipeline...");
            CreatePipeline();

            // Start the pipeline
            Console.WriteLine("Starting the pipeline...");
            await _pipeline.StartAsync();

            Console.WriteLine();
            Console.WriteLine("RTSP Server is running!");
            Console.WriteLine("Press any key to stop the server and exit.");
            Console.WriteLine();

            Console.ReadKey();

            // Stop the pipeline
            Console.WriteLine("Stopping the pipeline...");
            await _pipeline.StopAsync();

            Console.WriteLine("Pipeline stopped.");

            // Clean up
            if (_sampleGrabber != null)
            {
                _sampleGrabber.OnVideoFrameBuffer -= SampleGrabber_OnVideoFrameBuffer;
            }

            _pipeline.Dispose();

            VisioForgeX.DestroySDK();

            Console.WriteLine("Exiting...");
        }

        /// <summary>
        /// Loads images from the "Images" directory as raw BGRA byte arrays.
        /// </summary>
        /// <returns>An array of byte arrays containing raw pixel data.</returns>
        private static byte[][] LoadImagesAsRawData()
        {
            var imagesDir = Path.Combine(AppContext.BaseDirectory, "Images");
            var imageFiles = Directory.GetFiles(imagesDir, "*.jpg");

            if (imageFiles.Length == 0)
            {
                Console.WriteLine("Error: No JPG images found in Images directory.");
                Console.WriteLine("Please add JPG images to the Images folder.");
                return null;
            }

            var imageDataList = new byte[imageFiles.Length][];

            for (int i = 0; i < imageFiles.Length; i++)
            {
                Console.WriteLine($"  Loading: {Path.GetFileName(imageFiles[i])}");

                try
                {
                    using (var fileStream = File.OpenRead(imageFiles[i]))
                    {
                        // Check if file is empty
                        if (fileStream.Length == 0)
                        {
                            Console.WriteLine($"    Warning: {Path.GetFileName(imageFiles[i])} is empty. Using black placeholder.");
                            imageDataList[i] = CreateBlackImage();
                            continue;
                        }

                        using (var skData = SKData.Create(fileStream))
                        using (var skImage = SKImage.FromEncodedData(skData))
                        {
                            if (skImage == null)
                            {
                                Console.WriteLine($"    Warning: {Path.GetFileName(imageFiles[i])} is not a valid image. Using black placeholder.");
                                imageDataList[i] = CreateBlackImage();
                                continue;
                            }

                            using (var bitmap = SKBitmap.FromImage(skImage))
                            {
                                // Resize if needed and ensure BGRA format
                                SKBitmap processedBitmap;
                                if (bitmap.Width != IMAGE_WIDTH || bitmap.Height != IMAGE_HEIGHT || bitmap.ColorType != SKColorType.Bgra8888)
                                {
                                    processedBitmap = new SKBitmap(IMAGE_WIDTH, IMAGE_HEIGHT, SKColorType.Bgra8888, SKAlphaType.Unpremul);
                                    using (var canvas = new SKCanvas(processedBitmap))
                                    {
                                        canvas.Clear(SKColors.Black);
                                        canvas.DrawBitmap(bitmap, new SKRect(0, 0, IMAGE_WIDTH, IMAGE_HEIGHT));
                                    }
                                }
                                else
                                {
                                    processedBitmap = bitmap;
                                }

                                try
                                {
                                    // Copy pixel data to byte array
                                    var stride = IMAGE_WIDTH * 4; // BGRA = 4 bytes per pixel
                                    var dataSize = stride * IMAGE_HEIGHT;
                                    var data = new byte[dataSize];

                                    var pixels = processedBitmap.GetPixels();
                                    Marshal.Copy(pixels, data, 0, dataSize);

                                    imageDataList[i] = data;
                                }
                                finally
                                {
                                    if (processedBitmap != bitmap)
                                    {
                                        processedBitmap.Dispose();
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"    Error loading {Path.GetFileName(imageFiles[i])}: {ex.Message}. Using black placeholder.");
                    imageDataList[i] = CreateBlackImage();
                }
            }

            return imageDataList;
        }

        /// <summary>
        /// Creates a black placeholder image.
        /// </summary>
        /// <returns>A byte array containing black BGRA pixels.</returns>
        private static byte[] CreateBlackImage()
        {
            var stride = IMAGE_WIDTH * 4; // BGRA = 4 bytes per pixel
            var dataSize = stride * IMAGE_HEIGHT;
            return new byte[dataSize]; // All zeros = black image
        }

        /// <summary>
        /// Configures the media pipeline.
        /// </summary>
        private static void CreatePipeline()
        {
            _pipeline = new MediaBlocksPipeline();

            // Create virtual video source
            var virtualSourceSettings = new VirtualVideoSourceSettings
            {
                Width = IMAGE_WIDTH,
                Height = IMAGE_HEIGHT,
                Format = VideoFormatX.BGRA,
                FrameRate = new VideoFrameRate(FPS, 1),
                Pattern = VirtualVideoSourcePattern.SMPTE
            };

            _virtualSource = new VirtualVideoSourceBlock(virtualSourceSettings);

            // Create video sample grabber to intercept and modify frames
            _sampleGrabber = new VideoSampleGrabberBlock(VideoFormatX.BGRA);
            _sampleGrabber.OnVideoFrameBuffer += SampleGrabber_OnVideoFrameBuffer;

            // Create RTSP server block
            var rtspServerSettings = new RTSPServerSettings(H264EncoderBlock.GetDefaultSettings(), null)
            {
                Port = 8554, // Default RTSP port
            };

            var rtspBlock = new RTSPServerBlock(rtspServerSettings);

            Console.WriteLine($"RTSP Server URL: {rtspBlock.Settings.URL}");

            // Connect the blocks: VirtualSource -> SampleGrabber -> RTSP Server
            _pipeline.Connect(_virtualSource.Output, _sampleGrabber.Input);
            _pipeline.Connect(_sampleGrabber.Output, rtspBlock.Input);

            // Add error handler
            _pipeline.OnError += (sender, e) =>
            {
                Console.WriteLine($"[ERROR] {e.Level}: {e.Message}");
            };
        }

        /// <summary>
        /// Event handler for the VideoSampleGrabber to replace frames with the current image.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VideoFrameXBufferEventArgs"/> instance containing the event data.</param>
        private static void SampleGrabber_OnVideoFrameBuffer(object sender, VideoFrameXBufferEventArgs e)
        {
            // Check if it's time to switch to the next image
            var elapsed = (DateTime.Now - _lastImageSwitch).TotalSeconds;
            if (elapsed >= IMAGE_DISPLAY_SECONDS)
            {
                _currentImageIndex = (_currentImageIndex + 1) % _imageData.Length;
                _lastImageSwitch = DateTime.Now;
                Console.WriteLine($"Switching to image {_currentImageIndex + 1}");
            }

            // Replace the frame data with the current image
            var frame = e.Frame;
            var currentImage = _imageData[_currentImageIndex];

            // Copy the image data to the frame buffer
            Marshal.Copy(currentImage, 0, frame.Data, currentImage.Length);

            // Set UpdateData to true to indicate the frame has been modified
            e.UpdateData = true;
        }
    }
}
