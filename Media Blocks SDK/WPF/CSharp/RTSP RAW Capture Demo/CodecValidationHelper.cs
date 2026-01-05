using System;
using VisioForge.Core.Types.MediaInfo;
using VisioForge.Core.Types.X;

namespace RTSP_RAW_Capture_Demo
{
    /// <summary>
    /// Helper class for validating video codec compatibility with container formats.
    /// </summary>
    internal static class CodecValidationHelper
    {
        /// <summary>
        /// Checks if the video codec is compatible with RAW capture to MP4 or MPEG-TS containers.
        /// Only H.264 and H.265/HEVC codecs are supported for RAW capture to MP4/MPEG-TS.
        /// </summary>
        /// <param name="mediaInfo">The media information containing stream details.</param>
        /// <param name="targetContainer">The target container format ("mp4" or "mpegts").</param>
        /// <param name="errorMessage">Error message if codec is incompatible.</param>
        /// <returns><c>true</c> if codec is compatible; otherwise, <c>false</c>.</returns>
        public static bool IsCodecCompatibleWithContainer(MediaFileInfo mediaInfo, string targetContainer, out string errorMessage)
        {
            errorMessage = null;

            if (mediaInfo == null)
            {
                errorMessage = "Media information is not available.";
                return false;
            }

            if (mediaInfo.VideoStreams.Count == 0 && (mediaInfo.RTPStreams == null || mediaInfo.RTPStreams.Count == 0))
            {
                errorMessage = "No video streams detected in the RTSP source.";
                return false;
            }

            // Get the video codec
            string codec = null;
            if (mediaInfo.VideoStreams.Count > 0)
            {
                codec = mediaInfo.VideoStreams[0].Codec?.ToLowerInvariant();
            }
            else if (mediaInfo.RTPStreams != null && mediaInfo.RTPStreams.Count > 0)
            {
                // Try to get codec from RTP streams
                foreach (var rtpStream in mediaInfo.RTPStreams)
                {
                    if (rtpStream.Type == CapsType.Video)
                    {
                        codec = rtpStream.EncodingName?.ToLowerInvariant();
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(codec))
            {
                errorMessage = "Unable to determine video codec from RTSP source.";
                return false;
            }

            // Check if target container is MP4 or MPEG-TS
            targetContainer = targetContainer?.ToLowerInvariant();
            if (targetContainer == "mp4" || targetContainer == "mpegts" || targetContainer == "ts")
            {
                // MP4 and MPEG-TS containers only support H.264 and H.265/HEVC for RAW capture
                bool isH264 = codec.Contains("h264") || codec.Contains("avc");
                bool isH265 = codec.Contains("h265") || codec.Contains("hevc");
                
                if (!isH264 && !isH265)
                {
                    errorMessage = $"The '{codec.ToUpperInvariant()}' codec is not compatible with RAW capture to {targetContainer.ToUpperInvariant()} containers. " +
                                   $"Only H.264 and H.265/HEVC codecs are supported for RAW capture to MP4/MPEG-TS output. " +
                                   $"For other codecs (including MJPEG, VP8, VP9, etc.), please use RTSPSourceBlock with video encoder instead of RTSPRAWSourceBlock, " +
                                   $"or choose a different output format.";
                    return false;
                }
            }

            // H.264 and H.265/HEVC are compatible with MP4 and MPEG-TS
            return true;
        }

        /// <summary>
        /// Gets the detected video codec name from the media information.
        /// </summary>
        /// <param name="mediaInfo">The media information.</param>
        /// <returns>The codec name, or null if not available.</returns>
        public static string GetVideoCodec(MediaFileInfo mediaInfo)
        {
            if (mediaInfo == null)
            {
                return null;
            }

            if (mediaInfo.VideoStreams.Count > 0)
            {
                return mediaInfo.VideoStreams[0].Codec;
            }

            if (mediaInfo.RTPStreams != null && mediaInfo.RTPStreams.Count > 0)
            {
                foreach (var rtpStream in mediaInfo.RTPStreams)
                {
                    if (rtpStream.Type == CapsType.Video)
                    {
                        return rtpStream.EncodingName;
                    }
                }
            }

            return null;
        }
    }
}
