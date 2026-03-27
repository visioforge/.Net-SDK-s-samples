# Media Blocks SDK .Net - video-preview-webcam-frame-capture (C#/Console)

This application captures system audio output, captures individual video frames for analysis or processing.

## Used media blocks

* `SystemAudioSourceBlock` - System audio capture
* `VideoSampleGrabberBlock` - Frame capture/analysis
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -->|Video| VideoSampleGrabberBlock -->|Video| VideoRendererBlock
    SystemAudioSourceBlock -->|Audio| AudioRendererBlock
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
