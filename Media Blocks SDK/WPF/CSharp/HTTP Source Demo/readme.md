# Media Blocks SDK .Net - HTTP Source Demo (WPF)

The provided sample demonstrates how to build an application using the VisioForge Media Blocks SDK .Net for playing video from a HTTP URL in a WPF application. 
It initializes a media pipeline with HTTP source, universal demuxer+decoder, and video renderer blocks, offering functionality to start and stop video streaming.

## Features

- Play video from the network HTTP source

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [HTTPSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/HTTPSourceBlock/) - reads HTTP data from the network
- `DecodeBinBlock` - demuxes and decodes video data

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
