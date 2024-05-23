# Media Blocks SDK .Net - RTSP View CLI demo

This SDK sample demonstrates how to build a simple RTSP viewer using VisioForge's Media Blocks API in C#. It initializes a media pipeline, sets up an RTSP source with user authentication, and renders the video stream. The program accepts three command-line arguments for the RTSP stream URL, username, and password. Audio support is optional and can be enabled by uncommenting the relevant sections. The application showcases error handling and clean resource management with a straightforward interface for stopping the stream and disposing of the pipeline.

## Used blocks

- [RTSPSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/RTSPSourceBlock/) - captures video from an RTSP source
- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)