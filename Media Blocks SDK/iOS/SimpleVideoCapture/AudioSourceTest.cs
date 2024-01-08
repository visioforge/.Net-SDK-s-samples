using Gst.App;
using Gst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks;
using AVFoundation;
using VisioForge.Core.GStreamer.Sinks;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.GStreamer.Sources;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Sinks;

namespace SimpleVideoCapture
{
    internal class AudioSourceTest
    {
        private MediaBlocksPipeline pipeline;
        private Element src;

        private Timer _timer;

        public AudioSourceTest()
        {
            // Initialize GStreamer
            //Gst.Application.Init();

            MediaBlocksPipeline.InitSDK();

            // Create the pipeline
            //  pipeline = new Pipeline("audioPipeline");

            pipeline = new MediaBlocksPipeline();

            // var src = new SystemAudioSourceBlock(new OSXAudioSourceSettings());
            //var src = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings());

        

            //if (!src.Out.Link(audioSink.In))
            //{
            //    throw new Exception("Unable to link audio source and audio sink.");
            //}

            //var res = AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.PlayAndRecord);

            //            if (AVAudioSession.SharedInstance().Category != AVAudioSession.CategoryRecord
            //                && AVAudioSession.SharedInstance().Category != AVAudioSession.CategoryPlayAndRecord)
            //            {
            //                throw new Exception("AVAudioCategory not set to RECORD or PLAY_AND_RECORD. Please set it using AVAudioSession class.");
            //            }

            // src = ElementFactory.Make("audiotestsrc", "audiotestsrc");
            // pipeline.Add(src);

            //var src = new IOSAudioSource(null, new OSXAudioSourceSettings());
            //src.Init(null, pipeline);

            //var audioSink = new IOSAudioSink(null);
            //audioSink.Init(pipeline, new VisioForge.Core.Types.X.AudioInfoX(VisioForge.Core.Types.X.AudioFormatX.S16LE, 44100, 2));

            //if (!src.Out.Link(audioSink.In))
            //{
            //    throw new Exception("Unable to link audio source and audio sink.");
            //}

            // Create and add the autoaudiosink element
            // var audiosink = ElementFactory.Make("osxaudiosink", "osxaudiosink");

            // Create and add the audioconvert element
            // var audioconvert = ElementFactory.Make("audioconvert", "audioconvert");

            // Create and add the audioresample element
            //var audioresample = ElementFactory.Make("audioresample", "audioresample");
            // var capsSrc = Caps.FromString("audio/x-raw, format=(string)S16LE, channels=(int)2, rate=(int)44100");
            // var capsRen = Caps.FromString("audio/x-raw, format=(string)S16LE, channels=(int)2, rate=(int)44100, layout=(string)interleaved, channel-mask=(bitmask)0x0000000000000003");

            //var capsfilter = ElementFactory.Make("capsfilter", "audio-renderer-capsfilter");
            //var filter_caps = Caps.FromString("audio/x-raw, format=(string)S16LE");
            //capsfilter.SetProperty("caps", new GLib.Value(filter_caps));

            // Add the elements to the pipeline
            // pipeline.Add(src, audiosink, audioconvert, audioresample);

            // Link the elements
            //  src.LinkFiltered(audioSink.In, capsSrc);
            // audioconvert.Link(audioresample);
            // audioresample.LinkFiltered(audiosink, capsRen);

            _timer = new Timer(new TimerCallback(timerCallbac), this, 0, 100);
        }

        private static void timerCallbac(object state)
        {
            var test = (AudioSourceTest)state;

            if (test.pipeline != null)
            {
                // test.pipeline.QueryDuration(Gst.Format.Time, out var duration);
                // test.pipeline.QueryPosition(Gst.Format.Time, out var position);

                // var durationSec = (double)duration / Gst.Constants.MSECOND;
                //  var positionSec = (double)position / Gst.Constants.MSECOND;

                //  System.Diagnostics.Debug.WriteLine("Duration: " + durationSec.ToString("F2") + ", position: " + positionSec.ToString("F2"));

                System.Diagnostics.Debug.WriteLine("Duration: " + test.pipeline.Duration().ToString() + ", position: " + test.pipeline.Position_Get().ToString());
            }
        }

        public async System.Threading.Tasks.Task StartAsync()
        {
            var src = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync("http://test.visioforge.com/audio.mp3", renderAudio: true, renderVideo: false));

            var audioSink = new IOSAudioSinkBlock(new VisioForge.Core.Types.X.AudioInfoX(VisioForge.Core.Types.X.AudioFormatX.S16LE, 44100, 2));

            pipeline.Connect(src.Output, audioSink.Input);

            await pipeline.StartAsync();
        }

        //public void Stop()
        //{
        //    pipeline.SetState(State.Null);
        //}
    }
}
