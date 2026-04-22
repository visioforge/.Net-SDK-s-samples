using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Controls;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoDecoders;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoDecoders;
using VisioForge.Core.Types.X.VideoEncoders;

namespace EncoderConcurrencyTest
{
    /// <summary>
    /// One source → encoder → decoder → renderer pipeline with its own VideoView.
    /// Encapsulates the pipeline so the main window can create and dispose them freely
    /// from UI events. Supports H264, HEVC, and AV1 encoders and decoders.
    /// </summary>
    public partial class PipelineTile : UserControl, IDisposable
    {
        private MediaBlocksPipeline _pipeline;
        private VirtualVideoSourceBlock _source;
        private MediaBlock _encoder;
        private object _encoderSettings;
        private MediaBlock _decoder;
        private VideoRendererBlock _renderer;

        /// <summary>
        /// Guards against double-dispose and against doing the last-chance
        /// cleanup after a normal <see cref="StopAsync"/> already ran.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// True after <see cref="StartAsync"/> if the pipeline failed to start
        /// (driver cap, runtime rejection, etc.). Used by the main window's
        /// "Fill to limit" loop to stop once the host runs out of capacity.
        /// </summary>
        public bool StartFailed { get; private set; }

        /// <summary>
        /// Last status / error text surfaced by the tile. Useful for aggregated
        /// reporting when <see cref="StartFailed"/> is true.
        /// </summary>
        public string LastStatus { get; private set; } = string.Empty;

        /// <summary>
        /// The concrete encoder type this tile is actually running (e.g.
        /// "GPU_Nvidia_H264", "MediaFoundation_H264"). Empty until the pipeline
        /// starts successfully. Used by the main window to count live sessions per
        /// runtime independently of <see cref="VisioForge.Core.Types.X.VideoEncoders.EncoderRuntimeTracker"/>,
        /// which only sees sessions routed through Auto* settings.
        /// </summary>
        public string ResolvedRuntimeLabel { get; private set; } = string.Empty;

        public PipelineTile()
        {
            InitializeComponent();
        }

        public async Task StartAsync(int pipelineIndex, int width, int height, int fps,
                                     CodecChoice codec, EncoderChoice encoder,
                                     DecoderChoice decoder, long? adapterLuid)
        {
            try
            {
                lbHeader.Text = $"#{pipelineIndex}  {codec}  {width}x{height}@{fps}  enc={encoder}  dec={decoder}";

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;

                var srcSettings = new VirtualVideoSourceSettings(width, height, new VideoFrameRate(fps, 1));
                _source = new VirtualVideoSourceBlock(srcSettings);

                var (encBlock, encIn, encOut, encSettings) =
                    BuildEncoder(codec, encoder, width, height, fps, adapterLuid);
                _encoder = encBlock;
                _encoderSettings = encSettings;

                var (decBlock, decIn, decOut) = BuildDecoder(codec, decoder);
                _decoder = decBlock;

                _renderer = new VideoRendererBlock(_pipeline, VideoView1);

                _pipeline.Connect(_source.Output, encIn);
                _pipeline.Connect(encOut, decIn);
                _pipeline.Connect(decOut, _renderer.Input);

                var started = await _pipeline.StartAsync();
                if (!started)
                {
                    StartFailed = true;
                    LastStatus = "Failed to start pipeline. Check driver/session limits.";
                    lbStatus.Text = LastStatus;
                }
                else
                {
                    ResolvedRuntimeLabel = DescribeResolvedSettings(_encoderSettings);
                    LastStatus = $"Running. Runtime: {ResolvedRuntimeLabel}";
                    lbStatus.Text = LastStatus;
                }
            }
            catch (Exception ex)
            {
                StartFailed = true;
                LastStatus = "Start error: " + ex.Message;
                lbStatus.Text = LastStatus;

                // StartAsync allocates blocks one at a time (source, encoder, decoder,
                // renderer) before wiring them together. If a throw happens before the
                // pipeline reached PLAYING, these native elements are not yet owned by
                // the pipeline and StopAsync alone would leak them. Dispose everything
                // we created so far, in reverse order, and null the fields so a later
                // Dispose() does not double-free.
                try { _renderer?.Dispose(); } catch { }
                try { (_decoder as IDisposable)?.Dispose(); } catch { }
                try { (_encoder as IDisposable)?.Dispose(); } catch { }
                try { _source?.Dispose(); } catch { }
                try
                {
                    if (_pipeline != null)
                    {
                        _pipeline.OnError -= Pipeline_OnError;
                        await _pipeline.DisposeAsync();
                        _pipeline = null;
                    }
                }
                catch { }

                _renderer = null;
                _decoder = null;
                _encoder = null;
                _source = null;
                _encoderSettings = null;
            }
        }

        // ================================================================
        //  Encoder construction — codec-aware dispatch
        // ================================================================

        private static (MediaBlock block, MediaBlockPad input, MediaBlockPad output, object settings) BuildEncoder(
            CodecChoice codec, EncoderChoice choice, int width, int height, int fps, long? adapterLuid)
        {
            uint bitrate = ComputeBitrate(width, height, fps);

            switch (codec)
            {
                case CodecChoice.HEVC:
                {
                    var settings = BuildHEVCEncoderSettings(choice, bitrate, adapterLuid);
                    var block = new HEVCEncoderBlock(settings);
                    return (block, block.Input, block.Output, settings);
                }

                case CodecChoice.AV1:
                {
                    var settings = BuildAV1EncoderSettings(choice, bitrate, adapterLuid);
                    var block = new AV1EncoderBlock(settings);
                    return (block, block.Input, block.Output, settings);
                }

                case CodecChoice.H264:
                default:
                {
                    var settings = BuildH264EncoderSettings(choice, bitrate, adapterLuid);
                    var block = new H264EncoderBlock(settings);
                    return (block, block.Input, block.Output, settings);
                }
            }
        }

        private static IH264EncoderSettings BuildH264EncoderSettings(EncoderChoice choice, uint bitrate, long? adapterLuid)
        {
            switch (choice)
            {
                case EncoderChoice.NVENC:
                    return new NVENCH264EncoderSettings { Bitrate = bitrate, AdapterLuid = adapterLuid };

                case EncoderChoice.QSV:
                    return new QSVH264EncoderSettings { Bitrate = bitrate, AdapterLuid = adapterLuid };

                case EncoderChoice.MediaFoundation:
                    return new MFH264EncoderSettings { Bitrate = bitrate };

                case EncoderChoice.D3D12:
                    return new D3D12H264EncoderSettings { Bitrate = bitrate, AdapterLuid = adapterLuid };

                case EncoderChoice.OpenH264:
                    return new OpenH264EncoderSettings { Bitrate = bitrate };

                case EncoderChoice.AMF:
                default:
                    return new AMFH264EncoderSettings { Bitrate = bitrate, AdapterLuid = adapterLuid };
            }
        }

        private static IHEVCEncoderSettings BuildHEVCEncoderSettings(EncoderChoice choice, uint bitrate, long? adapterLuid)
        {
            switch (choice)
            {
                case EncoderChoice.NVENC:
                    return new NVENCHEVCEncoderSettings { Bitrate = bitrate, AdapterLuid = adapterLuid };

                case EncoderChoice.QSV:
                    return new QSVHEVCEncoderSettings { Bitrate = bitrate, AdapterLuid = adapterLuid };

                case EncoderChoice.MediaFoundation:
                    return new MFHEVCEncoderSettings { Bitrate = bitrate };

                case EncoderChoice.D3D12:
                    return new D3D12HEVCEncoderSettings { Bitrate = bitrate, AdapterLuid = adapterLuid };

                case EncoderChoice.AMF:
                default:
                    return new AMFHEVCEncoderSettings { Bitrate = bitrate, AdapterLuid = adapterLuid };
            }
        }

        private static IAV1EncoderSettings BuildAV1EncoderSettings(EncoderChoice choice, uint bitrate, long? adapterLuid)
        {
            switch (choice)
            {
                case EncoderChoice.NVENC:
                    return new NVENCAV1EncoderSettings { Bitrate = bitrate, AdapterLuid = adapterLuid };

                case EncoderChoice.QSV:
                    return new QSVAV1EncoderSettings { Bitrate = bitrate };

                case EncoderChoice.SVTAV1:
                    return new SVTAV1EncoderSettings { TargetBitrate = (int)bitrate };

                case EncoderChoice.RAV1E:
                    return new RAV1EEncoderSettings();

                case EncoderChoice.AOM:
                    return new AOMAV1EncoderSettings();

                case EncoderChoice.AMF:
                default:
                    // AMFAV1EncoderSettings has no AdapterLuid property today; the pipeline
                    // will use the system-default AMD GPU.
                    return new AMFAV1EncoderSettings { Bitrate = bitrate };
            }
        }

        // ================================================================
        //  Decoder construction — codec-aware dispatch
        // ================================================================

        private static (MediaBlock block, MediaBlockPad input, MediaBlockPad output) BuildDecoder(
            CodecChoice codec, DecoderChoice choice)
        {
            switch (codec)
            {
                case CodecChoice.HEVC:
                    return BuildHEVCDecoder(choice);

                case CodecChoice.AV1:
                    return BuildAV1Decoder(choice);

                case CodecChoice.H264:
                default:
                    return BuildH264Decoder(choice);
            }
        }

        private static (MediaBlock block, MediaBlockPad input, MediaBlockPad output) BuildH264Decoder(DecoderChoice choice)
        {
            switch (choice)
            {
                case DecoderChoice.NVENC_NVDEC:
                    if (H264DecoderBlock.IsAvailable(H264DecoderType.GPU_Nvidia_H264))
                    {
                        var nv = new NVH264DecoderBlock();
                        return (nv, nv.Input, nv.Output);
                    }
                    break;

                case DecoderChoice.AMF:
                    if (H264DecoderBlock.IsAvailable(H264DecoderType.GPU_AMD_AMF_H264))
                    {
                        var amf = new H264DecoderBlock(new AMFH264DecoderSettings());
                        return (amf, amf.Input, amf.Output);
                    }
                    break;

                case DecoderChoice.QSV:
                    if (H264DecoderBlock.IsAvailable(H264DecoderType.GPU_Intel_QSV_H264))
                    {
                        var qsv = new H264DecoderBlock(new QSVH264DecoderSettings());
                        return (qsv, qsv.Input, qsv.Output);
                    }
                    break;

                case DecoderChoice.D3D11:
                    if (H264DecoderBlock.IsAvailable(H264DecoderType.D3D11_H264))
                    {
                        var d11 = new H264DecoderBlock(new D3D11H264DecoderSettings());
                        return (d11, d11.Input, d11.Output);
                    }
                    break;

                case DecoderChoice.FFmpeg:
                    if (H264DecoderBlock.IsAvailable(H264DecoderType.FFMPEG))
                    {
                        var ff = new H264DecoderBlock(new FFMPEGH264DecoderSettings());
                        return (ff, ff.Input, ff.Output);
                    }
                    break;

                case DecoderChoice.OpenH264:
                    if (H264DecoderBlock.IsAvailable(H264DecoderType.OpenH264))
                    {
                        var oh = new H264DecoderBlock(new OpenH264DecoderSettings());
                        return (oh, oh.Input, oh.Output);
                    }
                    break;

                case DecoderChoice.Auto:
                default:
                    if (H264DecoderBlock.IsAvailable(H264DecoderType.GPU_Nvidia_H264))
                    {
                        var nv = new NVH264DecoderBlock();
                        return (nv, nv.Input, nv.Output);
                    }
                    break;
            }

            var sw = new H264DecoderBlock();
            return (sw, sw.Input, sw.Output);
        }

        private static (MediaBlock block, MediaBlockPad input, MediaBlockPad output) BuildHEVCDecoder(DecoderChoice choice)
        {
            switch (choice)
            {
                case DecoderChoice.NVENC_NVDEC:
                    if (HEVCDecoderBlock.IsAvailable(HEVCDecoderType.GPU_Nvidia_HEVC))
                    {
                        var nv = new NVH265DecoderBlock();
                        return (nv, nv.Input, nv.Output);
                    }
                    break;

                case DecoderChoice.AMF:
                    if (HEVCDecoderBlock.IsAvailable(HEVCDecoderType.GPU_AMD_AMF_HEVC))
                    {
                        var amf = new HEVCDecoderBlock(new AMFHEVCDecoderSettings());
                        return (amf, amf.Input, amf.Output);
                    }
                    break;

                case DecoderChoice.QSV:
                    if (HEVCDecoderBlock.IsAvailable(HEVCDecoderType.GPU_Intel_QSV_HEVC))
                    {
                        var qsv = new HEVCDecoderBlock(new QSVHEVCDecoderSettings());
                        return (qsv, qsv.Input, qsv.Output);
                    }
                    break;

                case DecoderChoice.D3D11:
                    if (HEVCDecoderBlock.IsAvailable(HEVCDecoderType.D3D11_HEVC))
                    {
                        var d11 = new HEVCDecoderBlock(new D3D11HEVCDecoderSettings());
                        return (d11, d11.Input, d11.Output);
                    }
                    break;

                case DecoderChoice.FFmpeg:
                    if (HEVCDecoderBlock.IsAvailable(HEVCDecoderType.FFMPEG))
                    {
                        var ff = new HEVCDecoderBlock(new FFMPEGHEVCDecoderSettings());
                        return (ff, ff.Input, ff.Output);
                    }
                    break;

                case DecoderChoice.Auto:
                default:
                    if (HEVCDecoderBlock.IsAvailable(HEVCDecoderType.GPU_Nvidia_HEVC))
                    {
                        var nv = new NVH265DecoderBlock();
                        return (nv, nv.Input, nv.Output);
                    }
                    break;
            }

            var sw = new HEVCDecoderBlock();
            return (sw, sw.Input, sw.Output);
        }

        private static (MediaBlock block, MediaBlockPad input, MediaBlockPad output) BuildAV1Decoder(DecoderChoice choice)
        {
            switch (choice)
            {
                case DecoderChoice.NVENC_NVDEC:
                    if (AV1DecoderBlock.IsAvailable(AV1DecoderType.NVIDIA))
                    {
                        var nv = new NVAV1DecoderBlock();
                        return (nv, nv.Input, nv.Output);
                    }
                    break;

                case DecoderChoice.Dav1d:
                    if (AV1DecoderBlock.IsAvailable(AV1DecoderType.Dav1d))
                    {
                        var dav1d = new AV1DecoderBlock(new AV1DecoderSettings { DecoderType = AV1DecoderType.Dav1d });
                        return (dav1d, dav1d.Input, dav1d.Output);
                    }
                    break;

                case DecoderChoice.Auto:
                default:
                    if (AV1DecoderBlock.IsAvailable(AV1DecoderType.NVIDIA))
                    {
                        var nv = new NVAV1DecoderBlock();
                        return (nv, nv.Input, nv.Output);
                    }
                    break;
            }

            var sw = new AV1DecoderBlock();
            return (sw, sw.Input, sw.Output);
        }

        // ================================================================
        //  Helpers
        // ================================================================

        private static uint ComputeBitrate(int width, int height, int fps)
        {
            // Rough bitrate heuristic: pixels*fps/10000 ≈ Kbps.
            // 1080p60 → 1920*1080*60/10000 ≈ 12,440 Kbps ≈ 12 Mbit — matches the high-quality baseline.
            var pixels = (long)width * height;
            var bits = (uint)(pixels * fps / 10000);
            return Math.Max(1500u, bits);
        }

        private static string DescribeResolvedSettings(object settings)
        {
            return settings switch
            {
                IH264EncoderSettings h264 => h264.GetEncoderType().ToString(),
                IHEVCEncoderSettings hevc => hevc.GetEncoderType().ToString(),
                IAV1EncoderSettings av1 => av1.GetEncoderType().ToString(),
                _ => "unknown",
            };
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbStatus.Text = "Pipeline error: " + e.Message;
            }));
        }

        public async Task StopAsync()
        {
            try
            {
                if (_pipeline != null)
                {
                    _pipeline.OnError -= Pipeline_OnError;
                    try
                    {
                        await _pipeline.StopAsync();
                    }
                    finally
                    {
                        try { await _pipeline.DisposeAsync(); } catch { }
                        _pipeline = null;
                    }
                }
            }
            catch (Exception ex)
            {
                lbStatus.Text = "Stop error: " + ex.Message;
            }
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;

            // Happy-path callers (BtRemoveLast_Click, BtStopAll_Click) await
            // StopAsync() first, which already disposes _pipeline and nulls it.
            // If _pipeline is still non-null here, StopAsync was never called
            // (or threw mid-way) and the native elements would otherwise leak.
            // Run a best-effort synchronous teardown as a last chance.
            try
            {
                if (_pipeline != null)
                {
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.Dispose();
                    _pipeline = null;
                }
            }
            catch (Exception ex)
            {
                // Dispose must not throw. Log for the demo developer, continue.
                Debug.WriteLine($"PipelineTile.Dispose last-chance cleanup failed: {ex.Message}");
            }

            _source = null;
            _encoder = null;
            _encoderSettings = null;
            _decoder = null;
            _renderer = null;

            GC.SuppressFinalize(this);
        }
    }
}
