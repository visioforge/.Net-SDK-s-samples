# Media Blocks SDK .Net - lut-sample (C#/Console)

This application generates synthetic video frames for testing and benchmarking, splits video stream for multiple outputs.

## Used media blocks

* `VirtualVideoSourceBlock` - Synthetic video generation
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display

## Pipeline

```mermaid
graph LR
    VirtualVideoSourceBlock -->|Video| TeeBlock
    TeeBlock -->|Video| LUTProcessorBlock -->|Video| VideoRendererBlock1[VideoRendererBlock]
    TeeBlock -->|Video| VideoRendererBlock2[VideoRendererBlock]
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
