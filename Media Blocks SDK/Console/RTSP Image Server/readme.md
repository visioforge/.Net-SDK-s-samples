# Media Blocks SDK .Net - RTSP Image Server (C#/Console)

This application demonstrates streaming images via RTSP using the VisioForge Media Blocks SDK.

## Description

This console application creates an RTSP server that streams a sequence of 5 JPG images in an infinite loop. Each image is displayed for 1 second before transitioning to the next image.

The application uses `VirtualVideoSourceBlock` to generate a video stream at 25 FPS, and `VideoSampleGrabberBlock` to intercept each frame and replace it with a custom image loaded from disk. The modified frames are then encoded with H.264 and streamed via RTSP.

## Features

* VirtualVideoSourceBlock generates the video stream
* VideoSampleGrabberBlock intercepts and replaces frames with custom images
* RTSP server for network streaming
* Infinite loop playback with 1 second per image
* H.264 video encoding
* Supports custom JPG images (place them in the Images folder)

## Used media blocks

* `VirtualVideoSourceBlock` - Generates a test pattern video stream
* `VideoSampleGrabberBlock` - Intercepts frames and replaces them with custom images
* `H264EncoderBlock` - H.264/AVC video encoding (via RTSPServerBlock)
* `RTSPServerBlock` - RTSP streaming server

## How to use

1. Run the application
2. The application will generate 5 test images in the `Images` folder if they don't exist
3. Connect to the RTSP stream using a media player (e.g., VLC, ffplay)
   - Default URL: `rtsp://localhost:8554/stream`
4. Press any key to stop the server

## Viewing the stream

You can view the RTSP stream using:

### VLC Media Player
```
vlc rtsp://localhost:8554/stream
```

### ffplay
```
ffplay -rtsp_transport tcp rtsp://localhost:8554/stream
```

### GStreamer
```
gst-launch-1.0 rtspsrc location=rtsp://localhost:8554/stream ! decodebin ! autovideosink
```

## Setup

1. Place your JPG images in the `Images` folder (next to the executable)
2. Name them `image1.jpg`, `image2.jpg`, `image3.jpg`, `image4.jpg`, `image5.jpg`
3. Run the application - it will stream your images in sequence
4. Empty or invalid image files will be replaced with black placeholders

## Supported frameworks

* .Net Framework 4.7.2
* .Net 5 and later

## Supported platforms

* Windows (x64)
* Linux (x64)
* macOS (ARM64, x64)

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk)
