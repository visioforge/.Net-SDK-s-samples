using System;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.GST.AudioEncoders;
using VisioForge.Core.Types.GST.Sinks;
using VisioForge.Core.Types.MediaPlayer.GST;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    public class RTSPRecordEngine : IDisposable
    {
        private MediaBlocksPipeline _pipeline;

        private MPEGTSSinkBlock _tsSink;

        private RTSPRAWSourceBlock _rtspRawSource;

        private DecodeBinBlock _decodeBin;

        private AACEncoderBlock _aacEncoder;

        private bool disposedValue;

        public event EventHandler<ErrorsEventArgs> OnError;

        public string Filename { get; set; } = "output.ts";

        public bool ReencodeAudio { get; set; }

        public Task<bool> StartAsync(RTSPRAWSourceSettings rtspSettings)
        {
            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += OnError;

            _rtspRawSource = new RTSPRAWSourceBlock(rtspSettings);

            _tsSink = new MPEGTSSinkBlock(new MPEGTSSinkSettings(Filename));

            _pipeline.Connect(_rtspRawSource.VideoOutput, _tsSink.CreateNewInput(MediaBlockPadMediaType.Video));

            if (rtspSettings.AudioEnabled)
            {
                if (ReencodeAudio)
                {
                    _decodeBin = new DecodeBinBlock();
                    _aacEncoder = new AACEncoderBlock(new AACEncoderSettings());

                    _pipeline.Connect(_rtspRawSource.AudioOutput, _decodeBin.Input);
                    _pipeline.Connect(_decodeBin.Output, _aacEncoder.Input);
                    _pipeline.Connect(_aacEncoder.Output, _tsSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
                else
                {
                    _pipeline.Connect(_rtspRawSource.AudioOutput, _tsSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
            }

            return _pipeline.StartAsync();
        }

        public Task<bool> StopAsync()
        {
            if (_pipeline == null)
                return Task.FromResult(false);

            _pipeline.OnError -= OnError;

            return _pipeline.StopAsync();

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
                    _pipeline.OnError -= OnError;
                    _pipeline.Dispose();
                    _pipeline = null;
                }

                _tsSink?.Dispose();
                _tsSink = null;

                _rtspRawSource?.Dispose();
                _rtspRawSource = null;

                _decodeBin?.Dispose();
                _decodeBin = null;

                _aacEncoder?.Dispose();
                _aacEncoder = null;

                disposedValue = true;
            }
        }
        ~RTSPRecordEngine()
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
