# Media Blocks SDK .Net - Screen Capture Demo (macOS)

This SDK sample illustrates how to create a screen capture and recording application using the VisioForge Media Blocks SDK .Net within a WPF framework. The application demonstrates how to configure a media block pipeline to capture screen content and system audio, displaying and encoding them into a file. It features the integration of screen and audio source blocks, video and audio renderer blocks, and encoding blocks for H264 video and AAC audio, culminating in the saving of the final output as an MP4 file.

Furthermore, the sample includes options for selecting audio input and output devices through device enumeration, incorporates error handling mechanisms, and provides the ability to switch between preview and recording modes.

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
- .Net 9

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
