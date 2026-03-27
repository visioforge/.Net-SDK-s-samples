# Media Blocks SDK .Net - h264-data-player (C#/WinForms)

This application plays H264 video data by pushing raw H264 bytes through the pipeline, parsing, decoding, and rendering the video.

## Used media blocks

* `PushSourceBlock` - Push-based data source
* `H264ParseBlock` - H.264 stream parsing
* `H264DecoderBlock` - H.264/AVC video decoding
* `VideoRendererBlock` - Real-time video display

## Pipeline

```mermaid
graph LR
    PushSourceBlock --> H264ParseBlock --> H264DecoderBlock --> VideoRendererBlock
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
