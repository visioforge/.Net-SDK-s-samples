using System;
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.MediaPlayer;
using VisioForge.Core.Types.X.Sources;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    /// <summary>
    /// The RTSP play engine.
    /// </summary>
    internal class RTSPPlayEngine : IAsyncDisposable, IPlayEngine
    {
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The RTSP source.
        /// </summary>
        private RTSPSourceBlock _source;

        /// <summary>
        /// Value indicating whether the object is disposed.
        /// </summary>
        private bool disposedValue;

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether audio is enabled.
        /// </summary>
        public bool AudioEnabled { get; set; }

        /// <summary>
        /// Occurs when error.
        /// </summary>
        public event EventHandler<ErrorsEventArgs> OnError;

        /// <summary>
        /// Occurs when an audio RAW frame is received.
        /// </summary>
        public event EventHandler<DataFrameEventArgs> OnAudioRAWFrame;

        /// <summary>
        /// Occurs when a video RAW frame is received.
        /// </summary>
        public event EventHandler<DataFrameEventArgs> OnVideoRAWFrame;

        /// <summary>
        /// Initializes a new instance of the <see cref="RTSPPlayEngine"/> class.
        /// </summary>
        /// <param name="rtspSettings">The RTSP settings.</param>
        /// <param name="videoView">The video view.</param>
        public RTSPPlayEngine(RTSPSourceSettings rtspSettings, IVideoView videoView)
        {
            URL = rtspSettings.Uri.ToString();
            Login = rtspSettings.Login;
            Password = rtspSettings.Password;
            AudioEnabled = rtspSettings.AudioEnabled;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;

            _source = new RTSPSourceBlock(rtspSettings);

            _videoRenderer = new VideoRendererBlock(_pipeline, videoView) { IsSync = false };

            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);

            if (rtspSettings.AudioEnabled)
            {
                _audioRenderer = new AudioRendererBlock() { IsSync = false };
                _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
            }
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void _pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            OnError?.Invoke(this, e);
        }

        /// <summary>
        /// Start async.
        /// </summary>
        public Task<bool> StartAsync()
        {
            _source.OnAudioRAWFrame += OnAudioRAWFrame;
            _source.OnVideoRAWFrame += OnVideoRAWFrame;

            return _pipeline.StartAsync();
        }

        /// <summary>
        /// Stop async.
        /// </summary>
        public Task<bool> StopAsync()
        {
            _source.OnAudioRAWFrame -= OnAudioRAWFrame;
            _source.OnVideoRAWFrame -= OnVideoRAWFrame;

            return _pipeline.StopAsync();
        }

        /// <summary>
        /// Is started.
        /// </summary>
        public bool IsStarted()
        {
            return _pipeline.State == PlaybackState.Play;
        }

        /// <summary>
        /// Dispose async.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            if (!disposedValue)
            {
                if (_pipeline != null)
                {
                    _pipeline.OnError -= _pipeline_OnError;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }

                _videoRenderer?.Dispose();
                _videoRenderer = null;

                _audioRenderer?.Dispose();
                _audioRenderer = null;

                _source?.Dispose();
                _source = null;

                disposedValue = true;
            }
        }
    }
}
