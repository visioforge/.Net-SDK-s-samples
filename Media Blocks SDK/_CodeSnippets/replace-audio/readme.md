# Media Blocks SDK .Net - replace-audio (C#/Console)

This application saves output to MP4 format.

## Used media blocks

* `MP4SinkBlock` - MP4 file output

## Pipeline

```mermaid
graph LR
    BasicFileSourceBlock1[BasicFileSourceBlock - Video] -->|Data| ParseBinBlock -->|Video| MP4SinkBlock
    BasicFileSourceBlock2[BasicFileSourceBlock - Audio] -->|Data| AudioParseBlock[MPEGAudioParseBlock] -->|Audio| MP4SinkBlock
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
