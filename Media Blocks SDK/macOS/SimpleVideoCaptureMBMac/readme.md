# Media Blocks SDK .Net - macOS Simple Video Capture Demo

The provided code is a sample for creating a simple video capture application using the VisioForge Media Blocks SDK on macOS. It demonstrates how to set up a media pipeline for capturing video and audio from system devices, render them in real-time, and manage device permissions and selections. Key features include requesting camera access, enumerating video and audio sources, selecting formats and frame rates, and integrating with the macOS UI for displaying video. The code leverages the power of asynchronous programming to handle device operations and updates the UI based on the current capture state. This sample serves as a foundation for developing more complex media applications on macOS using VisioForge's MediaBlocks SDK.

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
