using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Unity;

/// <summary>
/// Plays a media file with the VisioForge MediaBlocks SDK and renders it into a RawImage
/// via <see cref="VisioForgeVideoView"/>:
///   UniversalSourceBlock → BufferSinkBlock(RGBA) → VisioForgeVideoView (Texture2D)
///                       \→ AudioRendererBlock (system default device)
/// All the GStreamer environment setup and the texture plumbing live in the shared
/// VisioForgeEnvironment / VisioForgeVideoView helpers — this script is just the pipeline.
/// </summary>
[RequireComponent(typeof(RawImage))]
public class MediaBlocksPlayer : MonoBehaviour
{
    [SerializeField, Tooltip("Absolute path to the media file to play.")]
    private string _filePath = @"C:\Samples\!video.avi";

    [SerializeField, Tooltip("Auto-play in Start().")]
    private bool _autoPlayOnStart = true;

    [SerializeField, Tooltip("Render audio through the system default device.")]
    private bool _renderAudio = true;

    [SerializeField, Tooltip("Use a synthetic test pattern instead of the file (diagnostic baseline).")]
    private bool _useTestPattern = false;

    [SerializeField, Tooltip("How the video is fitted into the RawImage.")]
    private VideoViewAspectMode _aspectMode = VideoViewAspectMode.Letterbox;

    private VisioForgeVideoView _videoView;
    private MediaBlocksPipeline _pipeline;
    private UniversalSourceBlock _source;
    private VirtualVideoSourceBlock _virtualSource;
    private BufferSinkBlock _videoSink;
    private AudioRendererBlock _audioRenderer;

    private volatile bool _playing;

    public bool IsPlaying => _playing;
    public string FilePath { get => _filePath; set => _filePath = value; }

    private void Awake()
    {
        _videoView = new VisioForgeVideoView(GetComponent<RawImage>(), _aspectMode);
    }

    private void Update()
    {
        _videoView?.Update();
    }

    private async void Start()
    {
        VisioForgeEnvironment.InitializeSdk();

        if (_autoPlayOnStart && (!string.IsNullOrEmpty(_filePath) || _useTestPattern))
        {
            try
            {
                await PlayAsync(_filePath);
            }
            catch (Exception ex)
            {
                Debug.LogError($"[MediaBlocksPlayer] PlayAsync failed: {ex}");
            }
        }
    }

    public async Task PlayAsync(string filePath)
    {
        // Validate cheap preconditions BEFORE allocating anything, so a bad path can never
        // leave a half-built pipeline behind. Test pattern needs no file.
        if (!_useTestPattern)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path is empty. Set File Path or enable Use Test Pattern.", nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Media file not found.", filePath);
        }

        if (_playing)
            await StopAsync();

        try
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += OnPipelineError;
            _pipeline.OnStop += OnPipelineStop;

            _videoSink = new BufferSinkBlock(VideoFormatX.RGBA);
            _videoSink.OnVideoFrameBuffer += _videoView.OnFrameBuffer;

            if (_useTestPattern)
            {
                _virtualSource = new VirtualVideoSourceBlock();
                _pipeline.Connect(_virtualSource.Output, _videoSink.Input);
            }
            else
            {
                // ignoreMediaInfoReader:true skips the gst-discoverer pre-probe (fails under this
                // Unity runtime); decodebin negotiates the codec at pipeline build.
                var settings = await UniversalSourceSettings.CreateAsync(
                    filePath, renderVideo: true, renderAudio: _renderAudio, ignoreMediaInfoReader: true);

                // StopAsync / OnDestroy may have run during the await and nulled _pipeline; bail
                // before building blocks we'd then orphan and before dereferencing _pipeline.
                if (_pipeline == null) return;

                _source = new UniversalSourceBlock(settings);

                if (_source.VideoOutput == null)
                    throw new InvalidOperationException($"Source '{filePath}' produced no video output.");

                _pipeline.Connect(_source.VideoOutput, _videoSink.Input);

                if (_renderAudio && _source.AudioOutput != null)
                {
                    _audioRenderer = new AudioRendererBlock();
                    _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
                }
            }

            if (!await _pipeline.StartAsync())
                throw new InvalidOperationException("MediaBlocksPipeline failed to start.");

            _playing = true;
            Debug.Log($"[MediaBlocksPlayer] Playing: {(_useTestPattern ? "test pattern" : filePath)}");
        }
        catch
        {
            // Setup failed mid-way. Tear down exactly like StopAsync so we never orphan the
            // pipeline (with its event handlers) or leave a dangling OnVideoFrameBuffer
            // subscription that would double up on the next PlayAsync.
            if (_videoSink != null)
                _videoSink.OnVideoFrameBuffer -= _videoView.OnFrameBuffer;

            if (_pipeline != null)
            {
                _pipeline.OnError -= OnPipelineError;
                _pipeline.OnStop -= OnPipelineStop;
                try { await _pipeline.StopAsync(true); } catch { }
                try { await _pipeline.DisposeAsync(); } catch { }
            }

            _pipeline = null;
            _source = null;
            _virtualSource = null;
            _videoSink = null;
            _audioRenderer = null;
            _playing = false;
            throw;
        }
    }

    public async Task StopAsync()
    {
        var pipeline = _pipeline;
        if (pipeline == null)
            return;

        _playing = false;

        if (_videoSink != null)
            _videoSink.OnVideoFrameBuffer -= _videoView.OnFrameBuffer;

        // Detach handlers and clear the fields up front so that a throw from StopAsync /
        // DisposeAsync can't leave the dead pipeline reachable via live subscriptions or a
        // non-null _pipeline (which would make the next PlayAsync orphan it).
        pipeline.OnError -= OnPipelineError;
        pipeline.OnStop -= OnPipelineStop;
        _pipeline = null;
        _source = null;
        _virtualSource = null;
        _videoSink = null;
        _audioRenderer = null;

        try
        {
            await pipeline.StopAsync(true);
        }
        finally
        {
            await pipeline.DisposeAsync();
        }
    }

    private void OnPipelineError(object sender, ErrorsEventArgs e)
    {
        Debug.LogError($"[MediaBlocksPlayer] Pipeline error: {e.Message}");
    }

    private void OnPipelineStop(object sender, StopEventArgs e)
    {
        _playing = false;
    }

    private async void OnDestroy()
    {
        try
        {
            await StopAsync();
        }
        catch (Exception ex)
        {
            Debug.LogError($"[MediaBlocksPlayer] StopAsync on destroy failed: {ex}");
        }

        _videoView?.Dispose();
        _videoView = null;

        // NOTE: do NOT call VisioForgeX.DestroySDK() here. The SDK is process-global and
        // initialized once (VisioForgeEnvironment.InitializeSdk). In the Unity Editor the
        // domain is reused across Play/Stop, so destroying the SDK on Stop and then reusing
        // the stale managed state on the next Play crashes the native GStreamer registry.
        // The per-play pipeline is fully torn down by StopAsync above; the SDK stays alive.
    }
}
