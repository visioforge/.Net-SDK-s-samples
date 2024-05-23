# Media Blocks SDK .Net - Video Mixer Demo (WinForms)

The provided SDK sample showcases the implementation of a video mixing application using the VisioForge Media Blocks SDK .Net. The application allows users to mix two video streams into one output. It features a CPUMixerEngine class that handles the mixing process, including stream addition and error handling. The main form, Form1, offers a GUI where users can select video files, adjust the position and size of the streams, and start or stop the mixing process. The sample demonstrates initializing the SDK, setting up video streams with user-defined coordinates and dimensions, and managing the video mixing pipeline, including starting, stopping, and error-logging functionalities.

## Features

- Play multiple video streams from video files
- Mix video streams using CPU or GPU

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [VideoMixerBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoProcessing/VideoMixerBlock/) - mixes video streams
- [NullRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Special/NullRendererBlock/) - discards video and audio data
- [UniversalSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/UniversalSourceBlock/) - reads video files

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
