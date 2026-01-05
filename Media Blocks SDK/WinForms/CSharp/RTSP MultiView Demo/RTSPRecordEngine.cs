using System;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    public class RTSPRecordEngine : IAsyncDisposable
    {
        public MediaBlocksPipeline Pipeline { get; private set; }

        private MediaBlock _muxer;

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
            // Validate codec compatibility with target container
            string targetContainer = MP4 ? "mp4" : "mpegts";
            
            var mediaInfo = rtspSettings.GetInfo();
            if (!CodecValidationHelper.IsCodecCompatibleWithContainer(mediaInfo, targetContainer, out string errorMessage))
            {
                throw new CodecNotCompatibleException(errorMessage);
            }

            Pipeline = new MediaBlocksPipeline();
            Pipeline.OnError += OnError;
            // Pipeline.Debug_Mode = true;

            _rtspRawSource = new RTSPRAWSourceBlock(rtspSettings);

            if (MP4)
            {
                _muxer = new MP4SinkBlock(new MP4SinkSettings(Filename));
            }
            else
            {
                _muxer = new MPEGTSSinkBlock(new MPEGTSSinkSettings(Filename));
            }

            var inputVideoPad = (_muxer as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Video);

            Pipeline.Connect(_rtspRawSource.VideoOutput, inputVideoPad);

            if (rtspSettings.AudioEnabled)
            {
               var inputAudioPad = (_muxer as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Audio);

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

        public async ValueTask DisposeAsync()
        {
            if (!disposedValue)
            {
                if (Pipeline != null)
                {
                    Pipeline.OnError -= OnError;
                    await Pipeline.DisposeAsync();
                    Pipeline = null;
                }

                (_muxer as IDisposable)?.Dispose();
                _muxer = null;


                _rtspRawSource?.Dispose();
                _rtspRawSource = null;

                _decodeBin?.Dispose();
                _decodeBin = null;

                _audioEncoder?.Dispose();
                _audioEncoder = null;

                disposedValue = true;
            }
        }
    }
}
