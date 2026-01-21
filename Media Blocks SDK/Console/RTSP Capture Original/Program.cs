using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace RTSP_Capture_Original
{
    /// <summary>
    /// Console application demonstrating RTSP stream capture with keyframe synchronization.
    /// 
    /// This demo showcases the new keyframe synchronization features in RTSPRAWSourceBlock:
    /// 
    /// 1. WaitForKeyframe property:
    ///    - When set to true, the source will wait for an I-frame (keyframe) before starting playback
    ///    - This ensures clean video start without artifacts that can occur when starting from P-frames
    ///    - Particularly important for recording scenarios where you want a clean start
    /// 
    /// 2. SyncAudioWithKeyframe property:
    ///    - When set to true, audio data is synchronized with the first video keyframe
    ///    - Prevents audio from starting before video is ready
    ///    - Maintains proper A/V sync from the beginning of playback
    /// 
    /// 3. Output format flexibility:
    ///    - Supports both MP4 and MPEG-TS output formats
    ///    - MPEG-TS is ideal for streaming and broadcast applications
    ///    - MP4 provides better compression and compatibility
    /// 
    /// 4. Smart audio encoding:
    ///    - Automatically detects if source audio is already AAC
    ///    - Only re-encodes audio when necessary, preserving quality
    /// 
    /// Benefits of keyframe synchronization:
    /// - Clean video start without compression artifacts
    /// - Proper A/V synchronization from the first frame
    /// - Better recording quality when capturing RTSP streams
    /// - Reduced buffering and startup issues
    /// 
    /// Trade-offs:
    /// - Slightly longer startup time (waiting for keyframe)
    /// - Can be disabled for ultra-low latency scenarios
    /// </summary>
    /// <summary>
    /// Represents the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            Console.WriteLine("RTSP Camera Capture Utility (MP4/MPEG-TS)");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();

            // Ask for RTSP URL - This is the address of the IP camera or RTSP stream
            Console.Write("Enter RTSP URL (e.g. rtsp://camera-ip:554/stream): ");
            string rtspUrl = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(rtspUrl))
            {
                Console.WriteLine("Invalid URL. Exiting...");
                return;
            }

            // Ask for credentials - Many IP cameras require authentication
            Console.Write("Enter username (press Enter if none): ");
            string username = Console.ReadLine();

            Console.Write("Enter password (press Enter if none): ");
            string password = Console.ReadLine();

            // Ask for output format
            Console.WriteLine("Select output format:");
            Console.WriteLine("1. MP4 (recommended for playback)");
            Console.WriteLine("2. MPEG-TS (recommended for streaming/broadcast)");
            Console.Write("Enter choice (1 or 2): ");
            string formatChoice = Console.ReadLine();

            bool useMP4 = formatChoice != "2";
            string defaultExtension = useMP4 ? ".mp4" : ".ts";
            string formatName = useMP4 ? "MP4" : "MPEG-TS";

            // Ask for output file location - Default to the user's Videos folder
            string defaultFilename = $"rtsp_capture{defaultExtension}";
            string myVideosFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), defaultFilename);
            Console.WriteLine($"Enter output {formatName} file path (default: {myVideosFolder}): ");
            string outputFilePath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(outputFilePath))
            {
                outputFilePath = myVideosFolder;
            }

            // Ensure correct extension
            if (!outputFilePath.EndsWith(defaultExtension, StringComparison.OrdinalIgnoreCase))
            {
                outputFilePath = Path.ChangeExtension(outputFilePath, defaultExtension);
                Console.WriteLine($"Output file path adjusted to: {outputFilePath}");
            }

            // Make sure the directory exists for the output file
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Display recording information
            Console.WriteLine();
            Console.WriteLine($"Capturing from: {rtspUrl}");
            Console.WriteLine($"Saving to: {outputFilePath}");
            Console.WriteLine();
            Console.WriteLine("Press any key to stop recording...");

            Console.WriteLine("Creating RTSP source with keyframe synchronization...");

            var rtspUri = new Uri(rtspUrl);

            // Create RTSP source settings with media info
            var rtspSettings = await RTSPRAWSourceSettings.CreateAsync(
                rtspUri,
                username,
                password,
                audioEnabled: true);

            // Configure additional RTSP parameters
            rtspSettings.Latency = 100; // Low latency mode
            rtspSettings.AllowedProtocols = RTSPSourceProtocol.TCP; // Use TCP for reliable transport
            rtspSettings.DoRTCP = true; // Enable RTCP for better sync
            rtspSettings.RTPBlockSize = 65536; // Larger RTP block size for better performance
            rtspSettings.UDPBufferSize = 524288; // Larger UDP buffer if using UDP
            rtspSettings.WaitForKeyframe = true; // Wait for I-frame before starting
            rtspSettings.SyncAudioWithKeyframe = true; // Sync audio with video keyframe

            // Get media info to check audio codec
            var mediaInfo = rtspSettings.GetInfo();
            bool audioNeedsEncoding = false;
            string audioCodec = "none";

            if (rtspSettings.AudioEnabled && mediaInfo != null && mediaInfo.AudioStreams.Count > 0)
            {
                audioCodec = mediaInfo.AudioStreams[0].Codec?.ToUpperInvariant() ?? "";
                // Check if audio is NOT already AAC
                audioNeedsEncoding = !audioCodec.Contains("AAC") && !audioCodec.Contains("MP4A");
                Console.WriteLine($"Detected audio codec: {audioCodec}");
                if (audioNeedsEncoding)
                {
                    Console.WriteLine("Audio will be encoded to AAC for compatibility.");
                }
                else
                {
                    Console.WriteLine("Audio is already AAC, no re-encoding needed.");
                }
            }

            // Create the pipeline
            var pipeline = new MediaBlocksPipeline();

            // Create RTSP source block (keyframe sync configured in settings)
            var rtspSource = new RTSPRAWSourceBlock(rtspSettings);

            // Add source to pipeline
            pipeline.AddBlock(rtspSource);

            // Create appropriate sink based on format choice
            MediaBlock sinkBlock;
            if (useMP4)
            {
                // Create MP4 sink for recording         
                sinkBlock = new MP4SinkBlock(new MP4SinkSettings(outputFilePath));
            }
            else
            {
                // Create MPEG-TS sink for recording
                sinkBlock = new MPEGTSSinkBlock(new MPEGTSSinkSettings(outputFilePath));
            }
            pipeline.AddBlock(sinkBlock);

            // Create dynamic input pads for video and audio
            var videoInputPad = (sinkBlock as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Video);
            MediaBlockPad audioInputPad = null;
            if (rtspSettings.AudioEnabled)
            {
                audioInputPad = (sinkBlock as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Audio);
            }

            // Connect the pipeline
            Console.WriteLine("Connecting pipeline components...");

            // Connect video directly to sink (raw H264/H265 stream)
            pipeline.Connect(rtspSource.VideoOutput, videoInputPad);

            // Connect audio with optional AAC encoding
            if (rtspSettings.AudioEnabled && audioInputPad != null)
            {
                if (audioNeedsEncoding)
                {
                    // Audio needs to be re-encoded to AAC
                    Console.WriteLine("Setting up audio re-encoding pipeline...");

                    // Create decoder block (audio only)
                    var decodeBin = new DecodeBinBlock(false, true, false)
                    {
                        DisableAudioConverter = true
                    };
                    pipeline.AddBlock(decodeBin);

                    // Create AAC encoder
                    var aacEncoder = new AACEncoderBlock(new AVENCAACEncoderSettings());
                    pipeline.AddBlock(aacEncoder);

                    // Connect: RTSP audio -> decoder -> AAC encoder -> sink
                    pipeline.Connect(rtspSource.AudioOutput, decodeBin.Input);
                    pipeline.Connect(decodeBin.AudioOutput, aacEncoder.Input);
                    pipeline.Connect(aacEncoder.Output, audioInputPad);
                }
                else
                {
                    // Audio is already AAC, connect directly
                    pipeline.Connect(rtspSource.AudioOutput, audioInputPad);
                }
            }

            // Start the pipeline
            Console.WriteLine("Starting recording with keyframe synchronization...");
            await pipeline.StartAsync();

            Console.WriteLine($"Recording to {formatName} file: {outputFilePath}");
            Console.WriteLine("The recording will start from the first keyframe with synchronized audio.");
            if (audioNeedsEncoding && rtspSettings.AudioEnabled)
            {
                Console.WriteLine($"Audio is being transcoded from {audioCodec} to AAC.");
            }
            Console.WriteLine("Press any key to stop recording...");
            Console.ReadKey();

            // Stop and cleanup
            await pipeline.StopAsync();
            pipeline.Dispose();

            Console.WriteLine($"Recording stopped. {formatName} file saved to: {outputFilePath}");
        }
    }
}
