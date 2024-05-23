# Media Blocks SDK .Net - Simple Video Capture Demo (WinForms)

The provided code is a comprehensive example of how to create a simple video capture application using the VisioForge Media Blocks SDK. This application initializes the SDK, enumerates video and audio devices, and allows the user to select input sources and configure their settings. It features a GUI for device selection and configuration, real-time video and audio capture, encoding to H.264/AAC formats, and multiplexing into an MP4 container. The code also demonstrates handling of video and audio rendering, as well as using sample grabbers for frame manipulation. This sample is designed to showcase the SDK's capabilities in building multimedia applications with custom capture and processing workflows.

## Features

- Capture video from webcams to MP4 file
- Video preview
- Video and audio sample grabbers

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [SystemVideoSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemVideoSourceBlock/) - captures video from the webcam
- [SystemAudioSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemAudioSourceBlock/) - captures audio from the system
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio
- [TeeBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Special/TeeBlock/) - splits the media stream into two paths
- [H264EncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoEncoders/H264EncoderBlock/) - encodes the video stream using H264
- [AACEncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioEncoders/AACEncoderBlock/) - encodes the audio stream using AAC
- [MP4SinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/MP4SinkBlock/) - saves video to an MP4 file
- [VideoSampleGrabberBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoProcessing/VideoSampleGrabberBlock/) - grab video frames
- [AudioSampleGrabberBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioProcessing/AudioSampleGrabberBlock/) - grab audio frames

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
