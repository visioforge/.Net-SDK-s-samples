using System;
using System.Threading.Tasks;
using Gst;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.GStreamer;

namespace DeviceEnumeratorDiag
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== GStreamer Device Enumeration Diagnostic ===");
            Console.WriteLine("=== Event-based monitoring (WPF-style) ===");
            Console.WriteLine();

            // Init SDK (same as WPF demo: await VisioForgeX.InitSDKAsync())
            await VisioForgeX.InitSDKAsync();
            Console.WriteLine($"SDK initialized. GStreamer version: {Gst.Application.VersionString()}");
            Console.WriteLine();

            // Subscribe to events BEFORE starting monitors (same order as WPF demo)
            Console.WriteLine("Subscribing to events...");
            DeviceEnumerator.Shared.OnVideoSourceAdded += (sender, e) =>
            {
                Console.WriteLine($"  [EVENT] Video Added: [{e.API}] {e.DisplayName} (Internal: {e.InternalName}, Path: {e.DevicePath})");
            };

            DeviceEnumerator.Shared.OnVideoSourceRemoved += (sender, e) =>
            {
                Console.WriteLine($"  [EVENT] Video Removed: [{e.API}] {e.DisplayName}");
            };

            DeviceEnumerator.Shared.OnAudioSourceAdded += (sender, e) =>
            {
                Console.WriteLine($"  [EVENT] Audio Source Added: [{e.API}] {e.DisplayName} (Internal: {e.InternalName}, Path: {e.DevicePath})");
            };

            DeviceEnumerator.Shared.OnAudioSourceRemoved += (sender, e) =>
            {
                Console.WriteLine($"  [EVENT] Audio Source Removed: [{e.API}] {e.DisplayName}");
            };

            DeviceEnumerator.Shared.OnAudioSinkAdded += (sender, e) =>
            {
                Console.WriteLine($"  [EVENT] Audio Sink Added: [{e.API}] {e.DisplayName} (Internal: {e.InternalName})");
            };

            DeviceEnumerator.Shared.OnAudioSinkRemoved += (sender, e) =>
            {
                Console.WriteLine($"  [EVENT] Audio Sink Removed: [{e.API}] {e.DisplayName}");
            };

            // Start monitors (same as WPF demo lines 218-220)
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("Starting Video Source Monitor...");
            Console.WriteLine("========================================");
            await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("Starting Audio Source Monitor...");
            Console.WriteLine("========================================");
            await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();

            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("Starting Audio Sink Monitor...");
            Console.WriteLine("========================================");
            await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();

            // Give bus callbacks time to fire
            Console.WriteLine();
            Console.WriteLine("Waiting 5 seconds for bus callbacks to fire...");
            await Task.Delay(5000);

            // Now also test direct enumeration for comparison
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("Direct enumeration (VideoSources/AudioSources/AudioOutputs):");
            Console.WriteLine("========================================");

            var videoSources = await DeviceEnumerator.Shared.VideoSourcesAsync();
            Console.WriteLine($"\n  VideoSources count: {videoSources.Length}");
            foreach (var vs in videoSources)
            {
                Console.WriteLine($"    [{vs.API}] {vs.Name} (Internal: {vs.InternalName}, Path: {vs.DevicePath})");
            }

            var audioSources = await DeviceEnumerator.Shared.AudioSourcesAsync();
            Console.WriteLine($"\n  AudioSources count: {audioSources.Length}");
            foreach (var src in audioSources)
            {
                Console.WriteLine($"    [{src.API}] {src.Name} (Internal: {src.InternalName}, Path: {src.DevicePath})");
            }

            var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync();
            Console.WriteLine($"\n  AudioOutputs count: {audioOutputs.Length}");
            foreach (var ao in audioOutputs)
            {
                Console.WriteLine($"    [{ao.API}] {ao.Name} (Internal: {ao.InternalName}, Path: {ao.DevicePath}, Guid: {ao.Guid})");
            }

            // DirectSound-specific enumeration
            Console.WriteLine("\n========================================");
            Console.WriteLine("DirectSound-specific devices:");
            Console.WriteLine("========================================");

            var dsAudioSources = await DeviceEnumerator.Shared.AudioSourcesAsync(VisioForge.Core.Types.X.Sources.AudioCaptureDeviceAPI.DirectSound);
            Console.WriteLine($"\n  DirectSound Sources count: {dsAudioSources.Length}");
            foreach (var src in dsAudioSources)
            {
                Console.WriteLine($"    {src.Name} (Internal: {src.InternalName}, Path: {src.DevicePath})");
                var formats = src.Formats;
                foreach (var fmt in formats)
                {
                    Console.WriteLine($"      Format: {fmt}");
                }
            }

            var dsAudioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync(VisioForge.Core.Types.X.Output.AudioOutputDeviceAPI.DirectSound);
            Console.WriteLine($"\n  DirectSound Outputs count: {dsAudioOutputs.Length}");
            foreach (var ao in dsAudioOutputs)
            {
                Console.WriteLine($"    {ao.Name} (Internal: {ao.InternalName}, Path: {ao.DevicePath}, Guid: {ao.Guid})");
            }

            Console.WriteLine("\n=== Done ===");
        }
    }
}
