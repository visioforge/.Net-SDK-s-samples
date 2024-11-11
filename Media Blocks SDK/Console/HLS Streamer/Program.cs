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
    internal class Program
    {
        private const string URL = "http://localhost:8088/";

        static void Main(string[] args)
        {           
            Console.WriteLine("The HLS Streamer app can stream sample video and audio sources using the HLS protocol. You can open localhost IP with port 8088 in your browser. H264 and AAC encoders were used.");

            // Pipeline
            var pipeline = new MediaBlocksPipeline();
            pipeline.OnError += Pipeline_OnError;

            // video and audio sources
            var virtualVideoSource = new VirtualVideoSourceSettings
            {
                Width = 1280,
                Height = 720,
                FrameRate = VideoFrameRate.FPS_25,
            };

            var videoSource = new VirtualVideoSourceBlock(virtualVideoSource);

            var virtualAudioSource = new VirtualAudioSourceSettings
            {
                Channels = 2,
                SampleRate = 44100,
            };

            var audioSource = new VirtualAudioSourceBlock(virtualAudioSource);

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
                PlaylistRoot = URL,
                SendKeyframeRequests = true,
                TargetDuration = 5,
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
            pipeline.Start();

            Console.WriteLine($"Open {URL} in your web browser. Press 'Enter' to stop");
            Console.ReadLine();
        }

        private static void Pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}