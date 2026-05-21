using System;
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
/// Displays a live RTSP camera stream with the VisioForge MediaBlocks SDK, rendered into a
/// RawImage via <see cref="VisioForgeVideoView"/>:
///   RTSPSourceBlock → BufferSinkBlock(RGBA) → VisioForgeVideoView (Texture2D)
///                  \→ AudioRendererBlock (system default device)
/// Environment setup and texture plumbing live in the shared VisioForgeEnvironment /
/// VisioForgeVideoView helpers — this script is just the pipeline.
/// </summary>
[RequireComponent(typeof(RawImage))]
public class RTSPViewerPlayer : MonoBehaviour
{
    [SerializeField, Tooltip("RTSP URL, e.g. rtsp://192.168.1.10:554/stream")]
    private string _rtspUrl = "rtsp://192.168.1.10:554/stream";

    [SerializeField, Tooltip("RTSP username (leave empty if the stream needs no auth).")]
    private string _login = "";

    [SerializeField, Tooltip("RTSP password.")]
    private string _password = "";

    [SerializeField, Tooltip("Auto-connect in Start().")]
    private bool _autoPlayOnStart = true;

    [SerializeField, Tooltip("Render audio through the system default device.")]
    private bool _renderAudio = true;

    [SerializeField, Tooltip("How the video is fitted into the RawImage.")]
    private VideoViewAspectMode _aspectMode = VideoViewAspectMode.Letterbox;

    private VisioForgeVideoView _videoView;
    private MediaBlocksPipeline _pipeline;
    private RTSPSourceBlock _source;
    private BufferSinkBlock _videoSink;
    private AudioRendererBlock _audioRenderer;

    private volatile bool _playing;

    public bool IsPlaying => _playing;
    public string RtspUrl { get => _rtspUrl; set => _rtspUrl = value; }

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

        if (_autoPlayOnStart && !string.IsNullOrEmpty(_rtspUrl))
        {
            try
            {
                await PlayAsync(_rtspUrl, _login, _password);
            }
            catch (Exception ex)
            {
                Debug.LogError($"[RTSPViewer] Connect failed: {ex}");
            }
        }
    }

    public async Task PlayAsync(string rtspUrl, string login, string password)
    {
        if (string.IsNullOrEmpty(rtspUrl))
            throw new ArgumentException("RTSP URL is empty.", nameof(rtspUrl));

        if (_playing)
            await StopAsync();

        try
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += OnPipelineError;
            _pipeline.OnStop += OnPipelineStop;

            // readInfo:false skips the gst-discoverer pre-probe (fails under this Unity runtime,
            // and probing a live stream adds connect latency); decodebin negotiates at PLAYING.
            var settings = await RTSPSourceSettings.CreateAsync(
                new Uri(rtspUrl), login ?? string.Empty, password ?? string.Empty,
                audioEnabled: _renderAudio, readInfo: false);

            // StopAsync / OnDestroy may have run during the await and nulled _pipeline; bail
            // before building blocks we'd then orphan and before dereferencing _pipeline.
            if (_pipeline == null) return;

            _source = new RTSPSourceBlock(settings);

            if (_source.VideoOutput == null)
                throw new InvalidOperationException("RTSP source produced no video output.");

            _videoSink = new BufferSinkBlock(VideoFormatX.RGBA);
            _videoSink.OnVideoFrameBuffer += _videoView.OnFrameBuffer;
            _pipeline.Connect(_source.VideoOutput, _videoSink.Input);

            if (_renderAudio && _source.AudioOutput != null)
            {
                _audioRenderer = new AudioRendererBlock();
                _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
            }

            if (!await _pipeline.StartAsync())
                throw new InvalidOperationException("MediaBlocksPipeline failed to start.");

            _playing = true;
            Debug.Log($"[RTSPViewer] Streaming {rtspUrl}");
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
        Debug.LogError($"[RTSPViewer] Pipeline error: {e.Message}");
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
            Debug.LogError($"[RTSPViewer] StopAsync on destroy failed: {ex}");
        }

        _videoView?.Dispose();
        _videoView = null;

        // Do NOT DestroySDK here — the SDK is process-global and initialized once; tearing it
        // down on Stop and reusing it on the next Play crashes the native GStreamer registry.
    }
}
