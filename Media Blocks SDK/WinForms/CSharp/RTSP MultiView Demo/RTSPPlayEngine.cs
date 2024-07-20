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
    internal class RTSPPlayEngine : IAsyncDisposable, IPlayEngine
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private RTSPSourceBlock _source;

        private bool disposedValue;

        public string URL { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool AudioEnabled { get; set; }

        public event EventHandler<ErrorsEventArgs> OnError;

        public event EventHandler<DataFrameEventArgs> OnAudioRAWFrame;

        public event EventHandler<DataFrameEventArgs> OnVideoRAWFrame;

        public RTSPPlayEngine(RTSPSourceSettings rtspSettings, IVideoView videoView)
        {
            URL = rtspSettings.Uri.ToString();
            Login = rtspSettings.Login;
            Password = rtspSettings.Password;
            AudioEnabled = rtspSettings.AudioEnabled;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;

            _source = new RTSPSourceBlock(rtspSettings);

            _videoRenderer = new VideoRendererBlock(_pipeline, videoView);

            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);

            if (rtspSettings.AudioEnabled)
            {
                _audioRenderer = new AudioRendererBlock();
                _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
            }
        }

        private void _pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            OnError?.Invoke(this, e);
        }

        public Task<bool> StartAsync()
        {
            _source.OnAudioRAWFrame += OnAudioRAWFrame;
            _source.OnVideoRAWFrame += OnVideoRAWFrame;

            return _pipeline.StartAsync();
        }

        public Task<bool> StopAsync()
        {
            _source.OnAudioRAWFrame -= OnAudioRAWFrame;
            _source.OnVideoRAWFrame -= OnVideoRAWFrame;

            return _pipeline.StopAsync();
        }

        public bool IsStarted()
        {
            return _pipeline.State == PlaybackState.Play;
        }

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
