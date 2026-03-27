# Media Blocks SDK .Net - video-capture-webcam-mp4 (C#/Console)

This application captures system audio output, splits video stream for multiple outputs.

## Used media blocks

* `SystemAudioSourceBlock` - System audio capture
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -->|Video| VideoTeeBlock[TeeBlock]
    SystemAudioSourceBlock -->|Audio| AudioTeeBlock[TeeBlock]
    VideoTeeBlock -->|Video| VideoRendererBlock
    AudioTeeBlock -->|Audio| AudioRendererBlock
    VideoTeeBlock -->|Video| MP4OutputBlock
    AudioTeeBlock -->|Audio| MP4OutputBlock
```

## Supported frameworks

* .Net 4.7.2
* .Net Core 3.1
* .Net 5
* .Net 6
* .Net 7
* .Net 8
* .Net 9
* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk)
