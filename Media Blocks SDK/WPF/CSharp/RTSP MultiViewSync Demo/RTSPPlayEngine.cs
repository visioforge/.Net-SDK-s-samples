using System;
using System.Threading.Tasks;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace RTSP_MultiViewSync_Demo
{
    internal class RTSPPlayEngine : IAsyncDisposable
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

        public RTSPPlayEngine(RTSPSourceSettings rtspSettings, IVideoView videoView)
        {
            URL = rtspSettings.Uri.ToString();
            Login = rtspSettings.Login;
            Password = rtspSettings.Password;
            AudioEnabled = rtspSettings.AudioEnabled;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;
            _pipeline.OnStop += async (sender, args) =>
            {
                if (_pipeline != null)
                {
                    await _pipeline.DisposeAsync();
                }
            };

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

        public Task<bool> PreloadAsync()
        {
            return _pipeline.StartAsync(true);
        }

        public Task<bool> StartAsync()
        {
            return _pipeline.StartAsync();
        }

        public Task ResumeAsync()
        {
            return _pipeline.ResumeAsync();
        }

        public Task<bool> StopAsync()
        {
            return _pipeline.StopAsync(true);
        }

        public bool IsStarted()
        {
            return _pipeline.State == PlaybackState.Play;
        }

        public bool IsPaused()
        {
            return _pipeline.State == PlaybackState.Pause;
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
