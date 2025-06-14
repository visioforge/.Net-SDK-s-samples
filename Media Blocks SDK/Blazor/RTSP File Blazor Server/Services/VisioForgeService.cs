using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;

namespace RTSP_Webcam_Server.Services;

public class VisioForgeService : IDisposable
{
    private MediaBlocksPipeline? _pipeline;
    private RTSPServerBlock? _rtspBlock;
    private UniversalSourceBlock? _fileSource;
    private bool _isInitialized;
    private bool _isStreaming;
    private readonly string _mediaFolderPath;

    public bool IsInitialized => _isInitialized;
    public bool IsStreaming => _isStreaming;
    public string? RtspUrl { get; private set; }

    public VisioForgeService()
    {
        // Set default media folder path - you can change this to your preferred location
        _mediaFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Media");
        
        // Create media folder if it doesn't exist
        if (!Directory.Exists(_mediaFolderPath))
        {
            Directory.CreateDirectory(_mediaFolderPath);
        }
    }

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

    public string[] GetAvailableMediaFiles()
    {
        if (!_isInitialized)
            throw new InvalidOperationException("VisioForge SDK is not initialized.");

        if (!Directory.Exists(_mediaFolderPath))
            return Array.Empty<string>();

        var supportedExtensions = new[] { ".mp4", ".avi", ".mov", ".mkv", ".wmv", ".flv", ".webm", ".m4v", ".3gp", ".ts", ".mts" };
        
        var files = Directory.GetFiles(_mediaFolderPath)
            .Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLowerInvariant()))
            .Select(Path.GetFileName)
            .Where(fileName => fileName != null)
            .Cast<string>()
            .OrderBy(fileName => fileName)
            .ToArray();

        return files;
    }

    public string GetMediaFolderPath()
    {
        return _mediaFolderPath;
    }

    public async Task<bool> StartStreamingAsync(string fileName, int port = 8554)
    {
        if (!_isInitialized)
            throw new InvalidOperationException("VisioForge SDK is not initialized.");

        if (_isStreaming)
            return false;

        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentException("File name cannot be empty.", nameof(fileName));

        var filePath = Path.Combine(_mediaFolderPath, fileName);
        
        if (!File.Exists(filePath))
            throw new ArgumentException($"File '{fileName}' does not exist in the media folder.", nameof(fileName));

        try
        {
            // Create pipeline
            _pipeline = new MediaBlocksPipeline();

            // Create file source settings
            var fileSourceSettings = await UniversalSourceSettings.CreateAsync(filePath);
            var fileInfo = fileSourceSettings.GetInfo();
            
            // Check if file has video streams
            if (fileInfo.VideoStreams.Count == 0)
            {
                throw new InvalidOperationException("The selected file does not contain any video streams.");
            }

            // Create a universal source block for the selected file
            _fileSource = new UniversalSourceBlock(fileSourceSettings);

            // Create an RTSP server block
            var rtspServerSettings = new RTSPServerSettings(H264EncoderBlock.GetDefaultSettings(), null)
            {
                Port = port,
            };

            _rtspBlock = new RTSPServerBlock(rtspServerSettings);
            RtspUrl = _rtspBlock.Settings.URL;

            // Connect the file source to the RTSP server block
            _pipeline.Connect(_fileSource.Output, _rtspBlock.Input);

            // Start the pipeline
            await _pipeline.StartAsync();

            _isStreaming = true;
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error starting stream: {ex.Message}");
            await StopStreamingAsync();
            throw;
        }
    }

    public async Task StopStreamingAsync()
    {
        if (!_isStreaming) return;

        try
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync(force: true);
                await _pipeline.DisposeAsync();
            }
            
            _pipeline = null;
            _fileSource = null;
            _rtspBlock = null;
            RtspUrl = null;
            _isStreaming = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error stopping stream: {ex.Message}");
        }
    }

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