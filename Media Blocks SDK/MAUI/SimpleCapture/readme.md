# Media Blocks SDK .Net - MAUI Simple Video Capture Demo

This SDK sample demonstrates how to create a cross-platform MAUI simple media capture application using the VisioForge Media Blocks SDK .Net. The application is capable of capturing video and audio from system devices, encoding them in real-time, and saving the output to an MP4 file. It features device selection for video cameras, microphones, and audio output devices, along with basic controls for starting and stopping the preview and capture processes. Additionally, it handles permission requests for camera and microphone access, ensuring compliance with platform-specific privacy requirements. The use of a media block pipeline facilitates the flexible configuration and dynamic management of media sources, renderers, encoders, and sinks within the application.

## Features

- Preview camera video
- Capture video and audio to MP4 file

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [SystemVideoSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemVideoSourceBlock/) - captures video from the webcam
- [SystemAudioSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemAudioSourceBlock/) - captures audio from the system
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio
- [TeeBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Special/TeeBlock/) - splits the media stream into two paths
- [H264EncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoEncoders/H264EncoderBlock/) - encodes the video stream using H264
- [AACEncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioEncoders/AACEncoderBlock/) - encodes the audio stream using AAC
- [MP4SinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/MP4SinkBlock/) - saves video to an MP4 file
- [OPUSEncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioEncoders/OPUSEncoderBlock/) - encodes the audio stream using OPUS

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
