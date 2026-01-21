using System;
using System.Diagnostics;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.ONVIFX;
using VisioForge.Core.Types.X.Sources;

namespace RTSPView
{
    /// <summary>
    /// Represents the program.
    /// </summary>
    internal class Program
    {      
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
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

            bool audioEnabled = true;

            RTSPSourceBlock _source;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;

            string url = args[0];
            string username = args[1];
            string password = args[2];

            var rtspSettings = RTSPSourceSettings.CreateAsync(new Uri(url), username, password, audioEnabled).Result;
            audioEnabled = rtspSettings.GetInfo().AudioStreams.Count > 0;

            _source = new RTSPSourceBlock(rtspSettings);

            _videoRenderer = new VideoRendererBlock(_pipeline, null) { IsSync = false };

            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);

            if (audioEnabled)
            {
                var audioRenderer = new AudioRendererBlock() { IsSync = false };
                _pipeline.Connect(_source.AudioOutput, audioRenderer.Input);
            }

            _pipeline.Start();

            Console.WriteLine("Press any key to stop!");
            Console.ReadLine();

            _pipeline.Stop();
            _pipeline.Dispose();
        }

        /// <summary>
        /// Handles the OnError event of the pipeline.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisioForge.Core.Types.Events.ErrorsEventArgs"/> instance containing the event data.</param>
        private static void _pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
