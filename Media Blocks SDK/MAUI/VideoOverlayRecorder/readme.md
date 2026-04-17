# Media Blocks SDK .Net - VideoOverlayRecorder (C#/MAUI)

This application plays media files using the universal source decoder, splits video stream for multiple outputs.

## Used media blocks

* `UniversalSourceBlock` - Universal media file playback
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    UniversalSourceBlock -- video --> OverlayManagerBlock
    OverlayManagerBlock -- video --> TeeBlock-Video
    TeeBlock-Video -- video --> VideoRendererBlock
    TeeBlock-Video -- video --> MP4OutputBlock

    UniversalSourceBlock -- audio --> TeeBlock-Audio
    TeeBlock-Audio -- audio --> AudioRendererBlock
    TeeBlock-Audio -- audio --> MP4OutputBlock
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
