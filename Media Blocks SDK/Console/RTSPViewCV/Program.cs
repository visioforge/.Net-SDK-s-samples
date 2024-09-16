using System;
using VisioForge.Core.CV;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;

namespace RTSPViewCV
{
    internal class Program
    {
        static DNNFaceDetectorBlock _faceDetector;

        static MediaBlocksPipeline _pipeline;

        static VideoRendererBlock _videoRenderer;

        static RTSPSourceBlock _source;

        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("RTSPViewCV sample with face detection.");
                Console.WriteLine("Usage: RTSPViewCV URL username password");
                return;
            }

            bool audioEnabled = false;

            // Uncomment for audio
            // AudioRendererBlock _audioRenderer;
            // audioEnabled = true;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;

            string url = args[0]; 
            string username = args[1];
            string password = args[2];

            var rtspSettings = RTSPSourceSettings.CreateAsync(new Uri(url), username, password, audioEnabled).Result;

            _source = new RTSPSourceBlock(rtspSettings);
            //_source = new FileSourceBlock(@"c:\samples\!video.avi");

            _videoRenderer = new VideoRendererBlock(_pipeline, null) { IsSync = false };

            _faceDetector = new DNNFaceDetectorBlock();
            _faceDetector.OnFaceDetected += FaceDetector_OnFaceDetected;

            _pipeline.Connect(_source.VideoOutput, _faceDetector.Input);
            _pipeline.Connect(_faceDetector.Output, _videoRenderer.Input);

            //if (rtspSettings.AudioEnabled)
            //{
            //    _audioRenderer = new AudioRendererBlock();
            //    _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
            //}

            _pipeline.Start();

            Console.WriteLine("Press any key to stop!");
            Console.ReadLine();

            _pipeline.Stop();
            _pipeline.Dispose();
        }

        private static void FaceDetector_OnFaceDetected(object sender, VisioForge.Core.Types.Events.CVFaceDetectedEventArgs e)
        {
            Console.WriteLine($"Face detected at [{e.TimeStamp}]");
        }

        private static void _pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
