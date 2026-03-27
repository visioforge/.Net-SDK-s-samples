# Media Blocks SDK .Net - KLV Demo (C#/WPF)

This application handles KLV metadata for streaming.

## Used media blocks

* `BasicFileSourceBlock` - MPEG-TS file source
* `MPEGTSDemuxBlock` - MPEG-TS demuxer
* `KLVFileSinkBlock` - KLV metadata file output

## Pipeline

```mermaid
graph LR
    BasicFileSourceBlock --> MPEGTSDemuxBlock -- metadata --> KLVFileSinkBlock
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
