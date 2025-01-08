# Media Blocks SDK .Net - RTSP MultiView Demo (WinForms)

This SDK sample demonstrates how to create a multi-view RTSP streaming application using the VisioForge Media Blocks SDK. The application supports real-time playback and recording of RTSP streams, with the ability to select different camera feeds and adjust settings such as URL, login credentials, and whether to use hardware or software decoding. Users can also customize GPU decoding options, toggle audio playback, and log video or audio frame reception. The UI provides controls for starting and stopping stream playback and recording, with options for re-encoding audio and choosing output formats. Additionally, the sample includes features for reading media information and discovering ONVIF devices, illustrating the SDK's versatility in handling various media processing tasks.

## Features

- Play multiple RTSP streams
- Capture original streams to disk
- Capture reencoded streams to disk
- RAW video and audio frames access

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video frames
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio frames
- [RTSPSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/RTSPSourceBlock/) - reads RTSP streams

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
