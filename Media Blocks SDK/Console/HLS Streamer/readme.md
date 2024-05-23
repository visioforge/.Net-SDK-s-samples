# Media Blocks SDK .Net - HLS Streaming Demo

The HLS Streamer app, built using VisioForge's Media Blocks SDK, showcases a straightforward way to stream video and audio content via the HLS (HTTP Live Streaming) protocol. It uses H264 and AAC encoders for video and audio compression to create a virtual streaming pipeline that outputs the media to an HLS sink. The application serves the streamed content on a local HTTP server accessible through http://localhost:8088/, demonstrating the integration of video and audio sources, encoders, and streaming output within a .NET environment. This example is ideal for developers looking to implement HLS streaming in their applications, providing a template for source-to-sink media processing and streaming.

## Features

- HLS streaming

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio
- [HLSSinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/HLSSinkBlock/) - streams video using the HLS protocol
- [H264EncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoEncoders/H264EncoderBlock/) - encodes a video stream using H264
- [AACEncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioEncoders/AACEncoderBlock/) - encodes an audio stream using AAC
- [VirtualVideoSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/VirtualVideoSourceBlock/) - generates a video stream
- [VirtualAudioSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/VirtualAudioSourceBlock/) - generates an audio stream

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
