using System;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.MediaPlayer.GST;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    internal class HTTPPlayEngine : IDisposable, IPlayEngine
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private FileSourceBlock _source;

        private bool disposedValue;

        public string URL { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool AudioEnabled { get; set; }

        public event EventHandler<ErrorsEventArgs> OnError;

        public HTTPPlayEngine(string url, string login, string password, IVideoView videoView, bool audioEnabled)
        {
            URL = url;
            Login = login;
            Password = password;
            AudioEnabled = audioEnabled;

            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += _pipeline_OnError;

            //var rtspSettings = new RTSPSourceSettings(new Uri(url), audioEnabled);
            //rtspSettings.Login = login;
            //rtspSettings.Password = password;
            //_source = new FileSourceBlock(rtspSettings);

            var urix = url;
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                var uri1 = new Uri(url);
                urix = new UriBuilder(uri1) { UserName = login, Password = password }.Uri.ToString();
            }

            _source = new FileSourceBlock(urix);

            _videoRenderer = new VideoRendererBlock(videoView);

            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);

            if (audioEnabled)
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
            return _pipeline.StartAsync();
        }

        public Task<bool> StopAsync()
        {
            return _pipeline.StopAsync();
        }

        public bool IsStarted()
        {
            return _pipeline.State == PlaybackState.Play;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                if (_pipeline != null)
                {
                    _pipeline.OnError -= _pipeline_OnError;
                    _pipeline.Dispose();
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

        ~HTTPPlayEngine()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
