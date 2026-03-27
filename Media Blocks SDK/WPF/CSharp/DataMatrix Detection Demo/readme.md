# Media Blocks SDK .Net - DataMatrix Detection Demo (C#/WPF)

This application performs real-time DataMatrix code detection from a camera source with on-screen display.

## Used media blocks

* `SystemVideoSourceBlock` - System camera capture
* `DataMatrixDecoderBlock` - DataMatrix code detection and decoding
* `VideoRendererBlock` - Real-time video display

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -- video --> DataMatrixDecoderBlock
    DataMatrixDecoderBlock -- video --> VideoRendererBlock
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
