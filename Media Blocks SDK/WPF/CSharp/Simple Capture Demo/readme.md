# Media Blocks SDK .Net - Simple Capture Demo (WPF)

This SDK sample demonstrates how to build a simple video capture application using the VisioForge Media Blocks SDK .Net in a WPF environment. The application initializes a media pipeline for capturing video and audio from system devices, rendering them in real-time, and optionally encoding and saving the output to an MP4 file. It showcases device enumeration, video and audio source selection, real-time video and audio rendering, and file output capabilities.

The sample includes error handling and UI elements for device and format selection, demonstrating an integrated approach to media capture and processing with VisioForge's technology.

## Features

- Capture video from webcams to MP4 file
- Video preview
  
## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [SystemVideoSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemVideoSourceBlock/) - captures video from the webcam
- [SystemAudioSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemAudioSourceBlock/) - captures audio from the system
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio
- [TeeBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Special/TeeBlock/) - splits the media stream into two paths
- [H264EncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoEncoders/H264EncoderBlock/) - encodes the video stream using H264
- [AACEncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioEncoders/AACEncoderBlock/) - encodes the audio stream using AAC
- [MP4SinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/MP4SinkBlock/) - saves video to an MP4 file

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
