using System;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.Sources;

namespace RTSPView
{
    internal class Program
    {      
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("RTSPView sample.");
                Console.WriteLine("Usage: RTSPView URL username password");
                return;
            }

            MediaBlocksPipeline _pipeline;

            VideoRendererBlock _videoRenderer;

            bool audioEnabled = false;

            // Uncomment for audio
            // AudioRendererBlock _audioRenderer;
            // audioEnabled = true;

            RTSPSourceBlock _source;

            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += _pipeline_OnError;

            string url = args[0]; 
            string username = args[1];
            string password = args[2];

            var rtspSettings = new RTSPSourceSettings(new Uri(url), audioEnabled);
            rtspSettings.Login = username;
            rtspSettings.Password = password;

            _source = new RTSPSourceBlock(rtspSettings);

            _videoRenderer = new VideoRendererBlock(_pipeline, null);

            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);

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

        private static void _pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
