# Media Blocks SDK .Net - iOS Simple Video Capture Demo

This sample demonstrates the implementation of a simple video capture and processing application using the VisioForge Media Blocks SDK. It showcases how to enumerate video sources, capture video and audio from a selected camera and microphone, apply video effects like grayscale, render the video on-screen, and optionally encode and save the video to a file. The code also includes functionality for switching between cameras, stopping the capture, and saving the captured video to the iOS photo library. Advanced features such as audio and video sample grabbers are utilized to process frames, and custom UI elements are added to control the capture process. The application leverages the VisioForge SDK's MediaBlocks architecture for modular media processing, demonstrating a practical example of real-time video capture and manipulation on iOS devices.

## Features

- Preview camera video
- Capture video and audio to MP4 file
- Add sample video effects
- Switch between cameras
- Add sample grabbers for audio and video

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

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
