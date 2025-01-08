# Media Blocks SDK .Net - RTSP View CV CLI demo

This SDK sample demonstrates how to create a real-time face detection application using the VisioForge Media Blocks. The program initializes a face detector and configures a media pipeline to process video from an RTSP stream. It showcases how to set up an RTSP source, a video renderer, and a sample grabber block to capture video frames for face detection. Users can start the application with command-line arguments specifying the RTSP stream URL, username, and password. The sample also includes event handlers for detected faces and pipeline errors, providing a comprehensive example of integrating real-time video processing and face detection in .NET applications.

## Used blocks

- [RTSPSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/RTSPSourceBlock/) - captures video from an RTSP source
- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [VideoSampleGrabberBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoProcessing/VideoSampleGrabberBlock/) - captures video frames for processing

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