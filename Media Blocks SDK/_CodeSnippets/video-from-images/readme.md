# Media Blocks SDK .Net - video-from-images (C#/Console)

This application splits video stream for multiple outputs.

## Used media blocks

* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display

## Pipeline

```mermaid
graph LR
    PushSourceBlock -->|JPEG| JPEGDecoderBlock -->|Video| TeeBlock
    TeeBlock -->|Video| VideoRendererBlock
    TeeBlock -->|Video| MP4OutputBlock
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
