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
        public MediaBlocksPipeline Pipeline { get; private set; }

        private MPEGTSSinkBlock _tsMuxer;

        private MP4SinkBlock _mp4Muxer;

        private RTSPRAWSourceBlock _rtspRawSource;

        private DecodeBinBlock _decodeBin;

        private AACEncoderBlock _audioEncoder;

        //private MP3EncoderBlock _audioEncoder;

        private bool disposedValue;

        public event EventHandler<ErrorsEventArgs> OnError;

        public string Filename { get; set; } = "output.ts";

        public bool ReencodeAudio { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether MP4 output used instead MPEG-TS.
        /// </summary>
        public bool MP4 { get; set; }

        public Task<bool> StartAsync(RTSPRAWSourceSettings rtspSettings)
        {
            Pipeline = new MediaBlocksPipeline(true);
            Pipeline.OnError += OnError;
            // Pipeline.Debug_Mode = true;

            _rtspRawSource = new RTSPRAWSourceBlock(rtspSettings);

            MediaBlockPad inputVideoPad;
            MediaBlockPad inputAudioPad;

            if (MP4)
            {
                _mp4Muxer = new MP4SinkBlock(new MP4SinkSettings(Filename));
                inputVideoPad = _mp4Muxer.CreateNewInput(MediaBlockPadMediaType.Video);
                inputAudioPad = _mp4Muxer.CreateNewInput(MediaBlockPadMediaType.Audio);
            }
            else
            {
                _tsMuxer = new MPEGTSSinkBlock(new MPEGTSSinkSettings(Filename));
                inputVideoPad = _tsMuxer.CreateNewInput(MediaBlockPadMediaType.Video);
                inputAudioPad = _tsMuxer.CreateNewInput(MediaBlockPadMediaType.Audio);
            }

            Pipeline.Connect(_rtspRawSource.VideoOutput, inputVideoPad);

            if (rtspSettings.AudioEnabled)
            {
                if (ReencodeAudio)
                {
                    _decodeBin = new DecodeBinBlock(false, true, false)
                    {
                        DisableAudioConverter = true
                    };

                    _audioEncoder = new AACEncoderBlock(new AVENCAACEncoderSettings());

                    //_audioEncoder = new MP3EncoderBlock(new MP3EncoderSettings());

                    Pipeline.Connect(_rtspRawSource.AudioOutput, _decodeBin.Input);
                    Pipeline.Connect(_decodeBin.AudioOutput, _audioEncoder.Input);
                    Pipeline.Connect(_audioEncoder.Output, inputAudioPad);
                }
                else
                {
                    Pipeline.Connect(_rtspRawSource.AudioOutput, inputAudioPad);
                }
            }

            return Pipeline.StartAsync();
        }

        public Task<bool> StopAsync()
        {
            if (Pipeline == null)
                return Task.FromResult(false);

            Pipeline.OnError -= OnError;

            return Pipeline.StopAsync();

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                if (Pipeline != null)
                {
                    Pipeline.OnError -= OnError;
                    Pipeline.Dispose();
                    Pipeline = null;
                }

                _mp4Muxer?.Dispose();
                _mp4Muxer = null;

                _tsMuxer?.Dispose();
                _tsMuxer = null;

                _rtspRawSource?.Dispose();
                _rtspRawSource = null;

                _decodeBin?.Dispose();
                _decodeBin = null;

                _audioEncoder?.Dispose();
                _audioEncoder = null;

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
