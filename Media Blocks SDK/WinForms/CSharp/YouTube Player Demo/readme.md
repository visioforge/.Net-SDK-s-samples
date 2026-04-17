# Media Blocks SDK .Net - YouTube Player Demo (C#/WinForms)

This application plays media files using the universal source decoder.

## Used media blocks

* `UniversalSourceBlock` - Universal media file playback
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    UniversalSourceBlock_Video -- video --> VideoRendererBlock
    UniversalSourceBlock_Video -- audio --> AudioRendererBlock
    UniversalSourceBlock_Audio -- audio --> AudioRendererBlock
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
