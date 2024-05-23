# Media Blocks SDK .Net - Screen Capture Demo (WPF)

This SDK sample demonstrates how to implement a screen capture and recording application using the VisioForge Media Blocks SDK .Net in a WPF environment. The application showcases the setup of a media block pipeline for capturing screen content along with system audio, rendering both to the user interface and encoding them into a file. It highlights the usage of screen and audio source blocks, video and audio renderer blocks, encoding blocks for H264 video and AAC audio, and saving the output to an MP4 file.

Additionally, it includes device enumeration for selecting audio input and output devices, error handling, and the capability to toggle between preview and recording modes.

## Features

- Capture video from screen to MP4 file
- Video preview

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [ScreenSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/ScreenSourceBlock/) - captures video from the screen
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

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
