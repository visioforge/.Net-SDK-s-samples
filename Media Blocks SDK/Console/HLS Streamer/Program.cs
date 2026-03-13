using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;

namespace HLSStreamer
{
    /// <summary>
    /// Represents the program.
    /// </summary>
    internal class Program
    {
        private const string URL = "http://localhost:8088/";

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static async Task Main(string[] args)
        {
            VisioForgeX.InitSDK();

            Console.Clear();

            Console.WriteLine("HLS Streamer - streams video and audio using the HLS protocol.");
            Console.WriteLine("H264 and AAC encoders are used.");
            Console.WriteLine();

            // Enumerate video devices
            var videoDevices = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (videoDevices.Length == 0)
            {
                Console.WriteLine("No video capture devices found.");
                return;
            }

            Console.WriteLine("Available video devices:");
            for (int i = 0; i < videoDevices.Length; i++)
            {
                Console.WriteLine($"  {i}: [{videoDevices[i].API}] {videoDevices[i].Name}");
            }

            Console.Write("Select video device number: ");
            if (!int.TryParse(Console.ReadLine(), out int videoIndex) || videoIndex < 0 || videoIndex >= videoDevices.Length)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Console.WriteLine();

            // Enumerate audio devices
            var audioDevices = await DeviceEnumerator.Shared.AudioSourcesAsync();
            if (audioDevices.Length == 0)
            {
                Console.WriteLine("No audio capture devices found.");
                return;
            }

            Console.WriteLine("Available audio devices:");
            for (int i = 0; i < audioDevices.Length; i++)
            {
                Console.WriteLine($"  {i}: [{audioDevices[i].API}] {audioDevices[i].Name}");
            }

            Console.Write("Select audio device number: ");
            if (!int.TryParse(Console.ReadLine(), out int audioIndex) || audioIndex < 0 || audioIndex >= audioDevices.Length)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Console.WriteLine();

            // Pipeline
            var pipeline = new MediaBlocksPipeline();
            pipeline.OnError += Pipeline_OnError;

            // Video source
            var videoSettings = new VideoCaptureDeviceSourceSettings(videoDevices[videoIndex]);
            var videoSource = new SystemVideoSourceBlock(videoSettings);

            // Audio source
            var audioSettings = new AudioCaptureDeviceSourceSettings(audioDevices[audioIndex]);
            var audioSource = new SystemAudioSourceBlock(audioSettings);

            // H264/AAC encoders
            var h264Settings = new OpenH264EncoderSettings();
            var h264Encoder = new H264EncoderBlock(h264Settings);
            var aacEncoder = new AACEncoderBlock();

            // HLS sink
            var settings = new HLSSinkSettings
            {
                Location = Path.Combine(AppContext.BaseDirectory, "segment_%05d.ts"),
                MaxFiles = 10,
                PlaylistLength = 5,
                PlaylistLocation = Path.Combine(AppContext.BaseDirectory, "playlist.m3u8"),
                PlaylistRoot = URL.TrimEnd('/'),
                SendKeyframeRequests = true,
                TargetDuration = TimeSpan.FromSeconds(5),
                Custom_HTTP_Server_Enabled = true,
                Custom_HTTP_Server_Port = 8088
            };

            var hlsSink = new HLSSinkBlock(settings);

            // Connect everything
            pipeline.Connect(videoSource.Output, h264Encoder.Input);
            pipeline.Connect(audioSource.Output, aacEncoder.Input);

            pipeline.Connect(h264Encoder.Output, hlsSink.CreateNewInput(MediaBlockPadMediaType.Video));
            pipeline.Connect(aacEncoder.Output, hlsSink.CreateNewInput(MediaBlockPadMediaType.Audio));

            // Start
            var startResult = pipeline.Start();
            if (!startResult)
            {
                Console.WriteLine("Failed to start the pipeline. Check GStreamer installation and dependencies.");
                pipeline.Dispose();
                return;
            }

            Console.WriteLine("Pipeline started successfully. Generating HLS segments...");
            Console.WriteLine("Please wait a few seconds for the first segment to be created.");
            Console.WriteLine($"Then open {URL}index.htm in your web browser.");
            Console.WriteLine("Press 'Enter' to stop streaming");
            Console.ReadLine();

            // Cleanup
            Console.WriteLine("Stopping pipeline...");
            pipeline.Stop();
            pipeline.Dispose();
            Console.WriteLine("Pipeline stopped and disposed.");
        }

        /// <summary>
        /// Handles the OnError event of the pipeline.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisioForge.Core.Types.Events.ErrorsEventArgs"/> instance containing the event data.</param>
        private static void Pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
        }
    }
}
