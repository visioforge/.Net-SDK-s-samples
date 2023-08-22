// Authors
//   Copyright (C) 2014 Stephan Sundermann <stephansundermann@gmail.com>

using Gst;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace GstreamerSharp
{
    internal class Playback
    {
        const int ChunkSize = 4096;
        const int SampleRate = 44100;

        static Gst.App.AppSrc AppSource;
        static Element Pipeline;

        static long NumSamples;   // Number of samples generated so far (for timestamp generation)
        static float a, b, c, d;     // For waveform generation

        //static uint Sourceid;        // To control the GSource

        static GLib.MainLoop MainLoop;  // GLib's Main Loop

        // This method is called by the idle GSource in the mainloop, to feed CHUNK_SIZE bytes into appsrc.
        // The idle handler is added to the mainloop when appsrc requests us to start sending data (need-data signal)
        // and is removed when appsrc has enough data (enough-data signal).

        //private static IntPtr _dataX = Marshal.AllocCoTaskMem(4096);

        static bool PushData()
        {
            //var numSamples = ChunkSize / 2; // Because each sample is 16 bits
            //MapInfo map;

            // Create a new empty buffer
            //var buffer = new Gst.Buffer(null, ChunkSize, AllocationParams.Zero);

            // Set its timestamp and duration
            //buffer.Pts = Util.Uint64Scale((ulong)NumSamples, (ulong)Constants.SECOND, (ulong)SampleRate);
            //buffer.Dts = Util.Uint64Scale((ulong)NumSamples, (ulong)Constants.SECOND, (ulong)SampleRate);
            //buffer.Duration = Util.Uint64Scale((ulong)NumSamples, (ulong)Constants.SECOND, (ulong)SampleRate);

            var buffer = Gst.Buffer.gst_buffer_new();
            var memory = Memory.gst_memory_new_wrapped(
                (int)Gst.MemoryFlags.Readonly,
                Data,
                new UIntPtr(ChunkSize),
                new UIntPtr(_offset),
                new UIntPtr(ChunkSize),
                IntPtr.Zero,
                null);
            Gst.Buffer.gst_buffer_append_memory(buffer, memory);


            // Generate some psychodelic waveforms
            //buffer.Map(out map, MapFlags.Write);
            //c += d;
            //d -= c / 1000f;
            //var freq = 1100f + 1000f * d;
            //short[] data = new short[numSamples];
            //for (int i = 0; i < numSamples; i++)
            //{
            //    a += b;
            //    b -= a / freq;
            //    data[i] = (short)(500f * a);
            //}
            //// convert the short[] to a byte[] by marshalling
            //var native = Marshal.AllocHGlobal(data.Length * sizeof(short));
            //Marshal.Copy(data, 0, native, data.Length);
            //byte[] bytedata = new byte[2 * data.Length];
            //Marshal.Copy(native, bytedata, 0, data.Length * sizeof(short));
            //Marshal.FreeCoTaskMem(native);

            //map.Data = bytedata;
            //buffer.Unmap(map);

            //NumSamples += numSamples;

            // Push the buffer into the appsrc
            //var ret = AppSource.PushBuffer(buffer);
            var ret = (Gst.FlowReturn)Gst.App.AppSrc.gst_app_src_push_buffer(AppSource.Handle, buffer);

            // Free the buffer now that we are done with it
            // buffer.Owned = true;
            //buffer.Dispose();

            //Gst.Buffer.gst_buffer_unref(buffer);
            //Marshal.FreeCoTaskMem(map.DataPtr);

            if (ret != FlowReturn.Ok)
            {
                // We got some error, stop sending data
                return false;
            }

            _offset += ChunkSize;

            return true;
        }

        // This signal callback triggers when appsrc needs  Here, we add an idle handler
        // to the mainloop to start pushing data into the appsrc
        static void StartFeed(object sender, Gst.App.NeedDataArgs args)
        {
            PushData();
            //if (Sourceid == 0)
            //{
            //    System.Diagnostics.Debug.WriteLine("Start feeding");
            //    Sourceid = GLib.Idle.Add(PushData);
            //}
        }

        // This callback triggers when appsrc has enough data and we can stop sending.
        // We remove the idle handler from the mainloop
        static void StopFeed(object sender, EventArgs args)
        {
            //if (Sourceid != 0)
            //{
            //    System.Diagnostics.Debug.WriteLine("Stop feeding");
            //    GLib.Source.Remove(Sourceid);
            //    Sourceid = 0;
            //}
        }

        // This function is called when playbin has created the appsrc element, so we have a chance to configure it.
        static void SourceSetup(object sender, GLib.SignalArgs args)
        {

            var source = new Gst.App.AppSrc(((Element)args.Args[0]).Handle);
            System.Diagnostics.Debug.WriteLine("Source has been created. Configuring.");
            AppSource = source;

            //var caps = Caps.FromString("video/x-msvideo");
            //var caps = Caps.FromString("video/x-h264");
            //caps.SetValue("stream-format", new GLib.Value("byte-stream"));
            //var caps = Caps.FromString("video/quicktime");
            //caps.SetValue("variant", new GLib.Value("iso"));
            //var caps = Caps.FromString("video/mpegts");
            //caps.SetValue("systemstream", new GLib.Value("true"));

            //var caps = Caps.FromString("video/x-raw");
            //caps.SetValue("format", new GLib.Value("RGBA"));
            //caps.SetValue("width", new GLib.Value(640));
            //caps.SetValue("height", new GLib.Value(480));
            //source["caps"] = caps;

            //Element.SetProperty("caps", new GLib.Value(caps));

            // Configure appsrc
            var info = new Gst.Audio.AudioInfo();
            Gst.Audio.AudioChannelPosition[] position = { };
            info.SetFormat(Gst.Audio.AudioFormat.S16, SampleRate, 1, position);
            var audioCaps = info.ToCaps();
            source["caps"] = audioCaps;

            source["format"] = Format.Bytes;
            source.StreamType = Gst.App.AppStreamType.Seekable;
            source.Size = (long)DataSize;

            source.NeedData += StartFeed;
            //source.EnoughData += StopFeed;
            source.SeekData += Source_SeekData;
        }

        static ulong _offset = 0;

        private static void Source_SeekData(object o, Gst.App.SeekDataArgs args)
        {
            _offset = (ulong)args.Object;
            System.Diagnostics.Debug.WriteLine("SeekData: " + _offset);

            args.RetVal = true;
        }

        // This function is called when an error message is posted on the bus
        static void HandleError(object sender, GLib.SignalArgs args)
        {
            GLib.GException err;
            string debug;
            var msg = (Message)args.Args[0];

            // Print error details on the screen
            msg.ParseError(out err, out debug);
            System.Diagnostics.Debug.WriteLine("Error received from element {0}: {1}", msg.Src.Name, err.Message);
            System.Diagnostics.Debug.WriteLine("Debugging information: {0}", debug != null ? debug : "none");

            MainLoop.Quit();
        }

        static IntPtr Data;

        static ulong DataSize;

        private static void OnLog(Gst.DebugCategory category, Gst.DebugLevel level, string file, string function, int line, GLib.Object _object, Gst.DebugMessage message)
        {
            System.Diagnostics.Debug.WriteLine(message.Get());
        }

        static LogFunction LogFunctionX = new LogFunction(OnLog);

        public static void MainXXX(string[] args)
        {
            byte[] data = File.ReadAllBytes(@"c:\samples\!video.ts");
            Data = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, Data, data.Length);
            DataSize = (ulong)data.Length;

            // Initialize Gstreamer
            Gst.Application.Init(ref args);

            Gst.Debug.SetDefaultThreshold(DebugLevel.Info);
            Gst.Debug.AddLogFunction(LogFunctionX);

            b = 1;
            d = 1;


            // Create the playbin element
            Pipeline = Parse.Launch("playbin name=xplaybin uri=appsrc://");
            Pipeline.Connect("source-setup", SourceSetup);

            //var videoSink = ElementFactory.Make("d3dvideosink");
            //var playbin = ((Gst.Bin)Pipeline).GetByName("xplaybin");
            // Pipeline.SetProperty("video-sink", new GLib.Value(videoSink.Raw));


            // Instruct the bus to emit signals for each received message, and connect to the interesting signals
            var bus = Pipeline.Bus;
            bus.AddSignalWatch();
            bus.Connect("message::error", HandleError);

            // Start playing the pipeline
            Pipeline.SetState(State.Playing);

            // Create a GLib Main Loop and set it to run
            MainLoop = new GLib.MainLoop();
            MainLoop.Run();

            // Free resources
            Pipeline.SetState(State.Null);
        }
    }
}