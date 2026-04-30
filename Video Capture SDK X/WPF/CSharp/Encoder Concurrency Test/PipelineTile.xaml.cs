using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.VideoCaptureX;

namespace EncoderConcurrencyTestX
{
    /// <summary>
    /// One VideoCaptureCoreX instance with VirtualVideoSource → preview (VideoView) and
    /// VirtualVideoSource → encoder → MP4 file. Encapsulates the capture engine so the
    /// main window can create and dispose tiles freely from UI events. Supports H264,
    /// HEVC, and AV1 encoders.
    /// </summary>
    public partial class PipelineTile : UserControl, IDisposable
    {
        private VideoCaptureCoreX _core;
        private IVideoEncoder _encoderSettings;
        private string _outputFile;
        private bool _disposed;

        public bool StartFailed { get; private set; }

        public string LastStatus { get; private set; } = string.Empty;

        public string ResolvedRuntimeLabel { get; private set; } = string.Empty;

        public PipelineTile()
        {
            InitializeComponent();
        }

        public async Task StartAsync(int pipelineIndex,
                                     IVideoCaptureBaseVideoSourceSettings sourceSettings,
                                     string sourceLabel,
                                     int width, int height, int fps,
                                     CodecChoice codec, EncoderChoice encoder, long? adapterLuid)
        {
            try
            {
                lbHeader.Text = $"#{pipelineIndex}  [{sourceLabel}]  {codec}  {width}x{height}@{fps}  enc={encoder}";

                _core = new VideoCaptureCoreX(VideoView1 as IVideoView);
                _core.OnError += Core_OnError;

                _core.Video_Source = sourceSettings;
                _core.Audio_Record = false;
                _core.Audio_Play = false;
                _core.Audio_Source = null;

                _encoderSettings = BuildEncoder(codec, encoder, width, height, fps, adapterLuid);

                var dir = Path.Combine(Path.GetTempPath(), "VFEncoderConcurrency");
                Directory.CreateDirectory(dir);
                _outputFile = Path.Combine(dir, $"tile_{pipelineIndex}_{Guid.NewGuid():N}.mp4");

                var output = new MP4Output(_outputFile, _encoderSettings);
                _core.Outputs_Clear();
                _core.Outputs_Add(output, autostart: true);

                var started = await _core.StartAsync();
                if (!started)
                {
                    StartFailed = true;
                    LastStatus = "Failed to start capture. Check driver/session limits.";
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

                // The core may have allocated native resources before throwing — make sure
                // we tear it down here, otherwise it leaks for the rest of the session.
                try
                {
                    if (_core != null)
                    {
                        _core.OnError -= Core_OnError;
                        await _core.DisposeAsync();
                        _core = null;
                    }
                }
                catch { }

                _encoderSettings = null;
                TryDeleteOutput();
            }
        }

        // ================================================================
        //  Encoder construction — codec-aware dispatch
        // ================================================================

        private static IVideoEncoder BuildEncoder(CodecChoice codec, EncoderChoice choice,
            int width, int height, int fps, long? adapterLuid)
        {
            uint bitrate = ComputeBitrate(width, height, fps);

            switch (codec)
            {
                case CodecChoice.HEVC:
                    return BuildHEVCEncoderSettings(choice, bitrate, adapterLuid);

                case CodecChoice.AV1:
                    return BuildAV1EncoderSettings(choice, bitrate, adapterLuid);

                case CodecChoice.H264:
                default:
                    return BuildH264EncoderSettings(choice, bitrate, adapterLuid);
            }
        }

        private static IH264EncoderSettings BuildH264EncoderSettings(EncoderChoice choice, uint bitrate, long? adapterLuid)
        {
            switch (choice)
            {
                case EncoderChoice.NVENC:
                    return new NVENCH264EncoderSettings { Bitrate = bitrate };

                case EncoderChoice.QSV:
                    return new QSVH264EncoderSettings { Bitrate = bitrate };

                case EncoderChoice.MediaFoundation:
                    return new MFH264EncoderSettings { Bitrate = bitrate };

                case EncoderChoice.D3D12:
                    return new D3D12H264EncoderSettings { Bitrate = bitrate, AdapterLuid = adapterLuid };

                case EncoderChoice.OpenH264:
                    return new OpenH264EncoderSettings { Bitrate = bitrate };

                case EncoderChoice.AMF:
                default:
                    return new AMFH264EncoderSettings { Bitrate = bitrate };
            }
        }

        private static IHEVCEncoderSettings BuildHEVCEncoderSettings(EncoderChoice choice, uint bitrate, long? adapterLuid)
        {
            switch (choice)
            {
                case EncoderChoice.NVENC:
                    return new NVENCHEVCEncoderSettings { Bitrate = bitrate };

                case EncoderChoice.QSV:
                    return new QSVHEVCEncoderSettings { Bitrate = bitrate };

                case EncoderChoice.MediaFoundation:
                    return new MFHEVCEncoderSettings { Bitrate = bitrate };

                case EncoderChoice.D3D12:
                    return new D3D12HEVCEncoderSettings { Bitrate = bitrate, AdapterLuid = adapterLuid };

                case EncoderChoice.AMF:
                default:
                    return new AMFHEVCEncoderSettings { Bitrate = bitrate };
            }
        }

        private static IAV1EncoderSettings BuildAV1EncoderSettings(EncoderChoice choice, uint bitrate, long? adapterLuid)
        {
            switch (choice)
            {
                case EncoderChoice.NVENC:
                    return new NVENCAV1EncoderSettings { Bitrate = bitrate };

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
                    // AMFAV1EncoderSettings has no AdapterLuid property today; the engine
                    // will use the system-default AMD GPU.
                    return new AMFAV1EncoderSettings { Bitrate = bitrate };
            }
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

        private static string DescribeResolvedSettings(IVideoEncoder settings)
        {
            return settings switch
            {
                IH264EncoderSettings h264 => h264.GetEncoderType().ToString(),
                IHEVCEncoderSettings hevc => hevc.GetEncoderType().ToString(),
                IAV1EncoderSettings av1 => av1.GetEncoderType().ToString(),
                _ => settings?.GetType().Name ?? "unknown",
            };
        }

        private void Core_OnError(object sender, ErrorsEventArgs e)
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
                if (_core != null)
                {
                    _core.OnError -= Core_OnError;
                    try
                    {
                        await _core.StopAsync();
                    }
                    finally
                    {
                        try { await _core.DisposeAsync(); } catch { }
                        _core = null;
                    }
                }
            }
            catch (Exception ex)
            {
                lbStatus.Text = "Stop error: " + ex.Message;
            }
            finally
            {
                TryDeleteOutput();
            }
        }

        private void TryDeleteOutput()
        {
            if (string.IsNullOrEmpty(_outputFile))
            {
                return;
            }

            try
            {
                if (File.Exists(_outputFile))
                {
                    File.Delete(_outputFile);
                }
            }
            catch (IOException)
            {
                // The file may still be locked by the muxer briefly after stop on some
                // runtimes — leftovers in %TEMP%\VFEncoderConcurrency are acceptable for
                // a stress-test demo.
            }
            catch (UnauthorizedAccessException)
            {
            }

            _outputFile = null;
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;

            try
            {
                if (_core != null)
                {
                    _core.OnError -= Core_OnError;
                    _core.Dispose();
                    _core = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"PipelineTile.Dispose last-chance cleanup failed: {ex.Message}");
            }

            _encoderSettings = null;
            TryDeleteOutput();

            GC.SuppressFinalize(this);
        }
    }
}
