using Gst.App;
using Gst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using VisioForge.Core.MediaBlocks;
using Gst.Audio;

namespace SimpleVideoCapture
{
    class AppSrcTest
    {
        private Pipeline pipeline;
        private AppSrc appsrc;

        public AppSrcTest()
        {
            // Initialize GStreamer
            //Gst.Application.Init();

            MediaBlocksPipeline.InitSDK();

            // Create the pipeline
            pipeline = new Pipeline("audioPipeline");

            // Create and configure the appsrc element
            appsrc = new AppSrc("appsrc");
            appsrc.Format = Format.Time;
            appsrc.StreamType = AppStreamType.Stream;
            appsrc.IsLive = true;
            appsrc.Caps = Caps.FromString("audio/x-raw, format=(string)S16LE, channels=(int)2, rate=(int)44100, layout=(string)interleaved, channel-mask=(bitmask)0x0000000000000003");

            // Create and add the autoaudiosink element
            var audiosink = ElementFactory.Make("osxaudiosink", "osxaudiosink");

            // Create and add the audioconvert element
            var audioconvert = ElementFactory.Make("audioconvert", "audioconvert");

            // Create and add the audioresample element
            var audioresample = ElementFactory.Make("audioresample", "audioresample");

            //var capsfilter = ElementFactory.Make("capsfilter", "audio-renderer-capsfilter");
            //var filter_caps = Caps.FromString("audio/x-raw, format=(string)S16LE");
            //capsfilter.SetProperty("caps", new GLib.Value(filter_caps));

            // Add the elements to the pipeline
            pipeline.Add(appsrc, audiosink, audioconvert, audioresample);

            // Link the elements
            appsrc.Link(audioconvert);
            audioconvert.Link(audioresample);
            audioresample.Link(audiosink);

            // Handle the NeedData event
            appsrc.NeedData += OnNeedData;
        }

        long _totalDataSize = 0;
        System.DateTime? _startTime = null;

        private void OnNeedData(object sender, NeedDataArgs args)
        {
            if (_startTime == null)
            {
                _startTime = System.DateTime.Now;
            }

            // Assuming you have a method to get your PCM data
            byte[] audioData = GetAudioData();

            // Push the data into the pipeline
            if (audioData != null)
            {
                var buffer = new Gst.Buffer((uint)audioData.Length);
                var dataPtr = Marshal.AllocHGlobal(audioData.Length);
                Marshal.Copy(audioData, 0, dataPtr, audioData.Length);
                buffer.Fill(0, dataPtr, audioData.Length);
                appsrc.PushBuffer(buffer);

                _totalDataSize += audioData.Length;
                System.Diagnostics.Debug.WriteLine("Pushed {0} bytes, timestamp {1}", _totalDataSize, (System.DateTime.Now - _startTime).Value.ToString());
            }
        }

        public void Start()
        {
            pipeline.SetState(State.Playing);
        }

        public void Stop()
        {
            pipeline.SetState(State.Null);
        }

        private byte[] GetAudioData()
        {
            // Your method to retrieve the audio data
            // This should return a byte array containing the PCM audio data
            byte[] audioData = new byte[8192];
            Random.Shared.NextBytes(audioData); // Placeholder

            return audioData;
        }
    }
}

//class Program
//{
//    static void Main(string[] args)
//    {
//        AudioPlayer player = new AudioPlayer();
//        player.Start();

//        Console.WriteLine("Press Enter to stop...");
//        Console.ReadLine();

//        player.Stop();
//    }
//}

