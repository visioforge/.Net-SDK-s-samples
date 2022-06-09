using System;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
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

        public HTTPPlayEngine(string url, string login, string password, IVideoView videoView, bool audioEnabled)
        {
            URL = url;
            Login = login;
            Password = password;
            AudioEnabled = audioEnabled;

            _pipeline = new MediaBlocksPipeline();

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

            _videoRenderer = new VideoRendererBlock(videoView, true);

            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);

            if (audioEnabled)
            {
                _audioRenderer = new AudioRendererBlock(true);
                _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
            }
        }

        public bool Start()
        {
            return _pipeline.Start();
        }

        public bool Stop()
        {
            return _pipeline.Stop();
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
                    // TODO: dispose managed state (managed objects)
                }

                _pipeline?.Dispose();
                _pipeline = null;

                _videoRenderer?.Dispose();
                _videoRenderer = null;

                _audioRenderer?.Dispose();
                _audioRenderer = null;

                _source?.Dispose();
                _source = null;

                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~HTTPPlayEngine()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
