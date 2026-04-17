# Media Blocks SDK .Net - NDI Source Demo (C#/WPF)

This application receives video via NDI network protocol.

## Used media blocks

* `NDISourceBlock` - NDI network input
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    NDISourceBlock -- video --> VideoRendererBlock
    NDISourceBlock -- audio --> AudioRendererBlock
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
