using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.Types;
using VisioForge.Core;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.UI.WPF;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.AudioEncoders;

namespace Multiple_Encoders
{
    /// <summary>
    /// Represents an independent video capture and encoding engine instance.
    /// </summary>
    internal class EncodeEngine
    {
        private VideoCaptureCoreX _core;

        private VideoView _videoView;

        public EncodeEngine(VideoView videoView)
        {
            _videoView = videoView;
        }

        /// <summary>
        /// Asynchronously starts the capture and encoding process.
        /// </summary>
        /// <param name="videoSource">The video source device info.</param>
        /// <param name="audioSource">The audio source device info.</param>
        /// <param name="videoEncoder">The video encoder settings.</param>
        /// <param name="filename">The output filename.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task StartAsync(
            VideoCaptureDeviceInfo videoSource, 
            AudioCaptureDeviceInfo audioSource,
            IVideoEncoder videoEncoder,
            string filename)
        {
            _core = new VideoCaptureCoreX(_videoView);
            _core.Audio_Record = true;

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            if (videoSource != null)
            {
                var formatItem = videoSource.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);

                videoSourceSettings = new VideoCaptureDeviceSourceSettings(videoSource)
                {
                    Format = formatItem.ToFormat()
                };

                videoSourceSettings.Format.FrameRate = frameRate;
            }

            _core.Video_Source = videoSourceSettings;

            // audio source
            if (audioSource != null)
            {
                IVideoCaptureBaseAudioSourceSettings audioSourceSettings = audioSource.CreateSourceSettingsVC();
                _core.Audio_Source = audioSourceSettings;
            }

            // output
            var mp4Output = new MP4Output(filename, videoEncoder, new MFAACEncoderSettings());
            _core.Outputs_Add(mp4Output, autostart: true);

            // start
            await _core.StartAsync();
        }

        /// <summary>
        /// Asynchronously stops the capture and encoding process and disposes of resources.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task StopAsync()
        {
            if (_core != null)
            {
                await _core.StopAsync();
                await _core.DisposeAsync();

                _core = null;
            }
        }
    }
}
