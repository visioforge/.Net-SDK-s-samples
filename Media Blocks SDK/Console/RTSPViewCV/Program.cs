using System;
using VisioForge.Core.CVD;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.Sources;

namespace RTSPViewCV
{
    internal class Program
    {
        static FaceDetector _faceDetector;

        static MediaBlocksPipeline _pipeline;

        //static NullRendererBlock _videoRenderer;

        static VideoRendererBlock _videoRenderer;

        static VideoSampleGrabberBlock _sampleGrabber;

        static RTSPSourceBlock _source;

        //static FileSourceBlock _source;

        static void InitFaceDetector(bool eyes = false, bool nose = false, bool mouth = false)
        {
            _faceDetector = new FaceDetector();
            _faceDetector.OnFaceDetected += FaceDetector_OnFaceDetected;

            _faceDetector.Init();

            _faceDetector.DrawEnabled = true;
            _faceDetector.UpdateSettings();
        }

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

            InitFaceDetector();

            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += _pipeline_OnError;

            string url = args[0]; 
            string username = args[1];
            string password = args[2];

            var rtspSettings = new RTSPSourceSettings(new Uri(url), audioEnabled);
            rtspSettings.Login = username;
            rtspSettings.Password = password;

            _source = new RTSPSourceBlock(rtspSettings);
            //_source = new FileSourceBlock(@"c:\samples\!video.avi");

            _videoRenderer = new VideoRendererBlock(_pipeline, null);

            _sampleGrabber = new VideoSampleGrabberBlock(VisioForge.Core.GStreamer.SampleFormat.RGB);
            _sampleGrabber.OnVideoFrameBuffer += _sampleGrabber_OnVideoFrameBuffer; ;

            _pipeline.Connect(_source.VideoOutput, _sampleGrabber.Input);
            _pipeline.Connect(_sampleGrabber.Output, _videoRenderer.Input);

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

        private static void _sampleGrabber_OnVideoFrameBuffer(object sender, VisioForge.Core.Types.Events.VideoFrameBufferEventArgs e)
        {
            //Console.WriteLine($"Video frame received. [{e.Frame.Timestamp}]");

            _faceDetector?.Process(e.Frame);            
        }

        private static void _pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
