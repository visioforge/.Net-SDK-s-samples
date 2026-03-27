# Media Blocks SDK .Net - Stream Player Demo (C#/WinForms)

This application demonstrates the SDK capabilities.

## Used media blocks

* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    StreamSourceBlock -- data --> DecodeBinBlock
    DecodeBinBlock -- video --> VideoRendererBlock
    DecodeBinBlock -- audio --> AudioRendererBlock
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
