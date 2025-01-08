# Media Blocks SDK .Net - Social Networks Streamer Demo (WPF)

This SDK sample demonstrates the integration and use of the VisioForge MediaBlocks SDK within a WPF application to stream video and audio to various platforms, including YouTube and Facebook Live, or using the HLS protocol.
You can also stream using an HTTP MJPEG stream or to an AWS S3 bucket.

It shows how to set up a media pipeline using device enumeration for video and audio sources, video and audio rendering blocks, encoding with H.264 and AAC, and using different sink blocks for streaming.

The application allows users to select their input devices, configure source settings, and stream to their chosen platform with real-time video and audio. It also provides error handling and dynamic streaming status updates.

## Features

- Video streaming to YouTube and Facebook Live
- Video streaming using HLS and MJPEG over HTTP protocols
- Video streaming to AWS S3 bucket
- Video preview

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio
- [SystemVideoSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemVideoSourceBlock/) - captures video from a device
- [SystemAudioSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemAudioSourceBlock/) - captures audio from a device
- [YouTubeSinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/YouTubeSinkBlock/) - streams video to YouTube
- [FacebookLiveSinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/FacebookLiveSinkBlock/) - streams video to Facebook Live
- `AWSS3SinkBlock` - streams video to AWS S3 bucket
- [MP4SinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/MP4SinkBlock/) - saves video to an MP4 file
- [HTTPMJPEGLiveSinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/HTTPMJPEGLiveSinkBlock/) - streams video using the MJPEG over HTTP protocol
- [HLSSinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/HLSSinkBlock/) - streams video using the HLS protocol
- [SRTMPEGTSSinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/SRTMPEGTSSinkBlock/) - streams video using the SRT protocol with MPEG-TS muxer
- [H264EncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoEncoders/H264EncoderBlock/) - encodes video using H.264

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8
- .Net 9

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
