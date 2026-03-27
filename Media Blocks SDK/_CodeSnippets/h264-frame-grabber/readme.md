# Media Blocks SDK .Net - h264-frame-grabber (C#/WinForms)

This application reads an MP4 file, demuxes the H264 video stream, parses it, and grabs raw H264 data frames using a sample grabber.

## Used media blocks

* `BasicFileSourceBlock` - File-based media source
* `ParseBinBlock` - Automatic stream demuxing
* `H264ParseBlock` - H.264 stream parsing
* `DataSampleGrabberBlock` - Raw data frame capture
* `NullRendererBlock` - Null output (discard frames)

## Pipeline

```mermaid
graph LR
    BasicFileSourceBlock --> ParseBinBlock -- video --> H264ParseBlock --> DataSampleGrabberBlock --> NullRendererBlock
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
