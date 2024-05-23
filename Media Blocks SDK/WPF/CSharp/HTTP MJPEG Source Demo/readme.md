# Media Blocks SDK .Net - HTTP MJPEG Source Demo (WPF)

The provided sample demonstrates how to build an application using the VisioForge Media Blocks SDK .Net for streaming MJPEG video from a URL to a WPF application. It initializes a media pipeline with HTTP source, JPEG decoder, and video renderer blocks, offering functionality to start and stop video streaming. Additionally, it includes error handling to debug issues within the media pipeline, showcasing the SDK's capabilities for real-time video processing and rendering in a Windows environment.

## Features

- Play video from the network MJPEG source

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [HTTPSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/HTTPSourceBlock/) - reads HTTP data from the network
- `JPEGDecoderBlock` - decodes JPEG frames

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
