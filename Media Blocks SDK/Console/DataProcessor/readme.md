# Media Blocks SDK .Net - DataProcessor (C#/Console)

This application generates synthetic video frames for testing and benchmarking, saves output to MP4 format.

## Used media blocks

* `VirtualVideoSourceBlock` - Synthetic video generation
* `H264EncoderBlock` - H.264/AVC video encoding
* `MP4SinkBlock` - MP4 file output

## Pipeline

```mermaid
graph LR
    VirtualVideoSourceBlock -- video --> DataProcessorBlock --> H264EncoderBlock --> MP4SinkBlock
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
