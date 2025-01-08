# Media Blocks SDK .Net - Video Compositor Demo (WPF)

This SDK sample demonstrates a comprehensive approach to video composition and streaming using the VisioForge Media Blocks SDK .Net in a WPF application. The code showcases the creation and management of a media pipeline capable of capturing video from various sources such as cameras, screens, or files.

It also illustrates how to configure output streams for different platforms, including MP4 files, YouTube, Facebook Live, and NDI. Furthermore, the sample includes functionality for real-time video mixing, previewing, and the dynamic modification of source properties, demonstrating the API's flexibility in handling complex video processing tasks.

## Features

- Video mixing of several video sources
- Video preview

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio
- [MP4OutputBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/MP4SinkBlock/) - saves video to an MP4 file
- [YouTubeOutputBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/YouTubeSinkBlock/) - streams video to YouTube
- [FacebookLiveOutputBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/FacebookLiveSinkBlock/) - streams video to Facebook Live
- [SystemVideoSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemVideoSourceBlock/) - captures video from a device
- [SystemAudioSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemAudioSourceBlock/) - captures audio from a device
- [NDISinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/NDISinkBlock/) - sends video using NDI
- [VideoMixerBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoProcessing/VideoMixerBlock/) - mixes video streams
- [VirtualAudioSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/VirtualAudioSourceBlock/) - creates an audio source
  
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
