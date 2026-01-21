using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;

namespace RTSP_Webcam_Server.Services;

/// <summary>
/// VisioForge service implementation.
/// </summary>
public class VisioForgeService : IDisposable
{
    private MediaBlocksPipeline? _pipeline;
    private RTSPServerBlock? _rtspBlock;
    private SystemVideoSourceBlock? _cameraSource;
    private bool _isInitialized;
    private bool _isStreaming;

    public bool IsInitialized => _isInitialized;
    public bool IsStreaming => _isStreaming;
    public string? RtspUrl { get; private set; }

        /// <summary>
        /// Initialize async.
        /// </summary>
    public async Task InitializeAsync()
    {
        if (_isInitialized) return;

        await Task.Run(() =>
        {
            Console.WriteLine("Initializing VisioForge SDK.");
            VisioForgeX.InitSDK();
            _isInitialized = true;
        });
    }

    /// <summary>
    /// Get available cameras.
    /// </summary>
    public VideoCaptureDeviceInfo[] GetAvailableCameras()
    {
        if (!_isInitialized)
            throw new InvalidOperationException("VisioForge SDK is not initialized.");

        return DeviceEnumerator.Shared.VideoSources();
    }

        /// <summary>
        /// Start streaming async.
        /// </summary>
    public async Task<bool> StartStreamingAsync(VideoCaptureDeviceInfo cameraInfo, int port = 8554)
    {
        if (!_isInitialized)
            throw new InvalidOperationException("VisioForge SDK is not initialized.");

        if (_isStreaming)
            return false;

        try
        {
            // Create pipeline
            _pipeline = new MediaBlocksPipeline();

            // Create a video source block for the selected camera
            var videoSourceSettings = new VideoCaptureDeviceSourceSettings(cameraInfo);
            videoSourceSettings.Format = cameraInfo.GetHDVideoFormatAndFrameRate(out var frameRate).ToFormat();
            videoSourceSettings.Format.FrameRate = frameRate;

            _cameraSource = new SystemVideoSourceBlock(videoSourceSettings);

            // Create an RTSP server block
            var rtspServerSettings = new RTSPServerSettings(H264EncoderBlock.GetDefaultSettings(), null)
            {
                Port = port,
            };

            _rtspBlock = new RTSPServerBlock(rtspServerSettings);
            RtspUrl = _rtspBlock.Settings.URL;

            // Connect the camera source to the RTSP server block
            _pipeline.Connect(_cameraSource.Output, _rtspBlock.Input);

            // Start the pipeline
            await Task.Run(() => _pipeline.Start());

            _isStreaming = true;
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error starting stream: {ex.Message}");
            await StopStreamingAsync();
            return false;
        }
    }

        /// <summary>
        /// Stop streaming async.
        /// </summary>
    public async Task StopStreamingAsync()
    {
        if (!_isStreaming) return;

        try
        {
            await Task.Run(() =>
            {
                _pipeline?.Stop();
                _pipeline?.Dispose();
                _pipeline = null;
                _cameraSource = null;
                _rtspBlock = null;
                RtspUrl = null;
                _isStreaming = false;
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error stopping stream: {ex.Message}");
        }
    }

        /// <summary>
        /// Dispose.
        /// </summary>
    public void Dispose()
    {
        if (_isStreaming)
        {
            Task.Run(async () => await StopStreamingAsync()).Wait();
        }

        if (_isInitialized)
        {
            VisioForgeX.DestroySDK();
            _isInitialized = false;
        }
    }
} 