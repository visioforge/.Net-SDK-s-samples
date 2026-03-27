# Media Blocks SDK .Net - DirectShow To X Bridge (C#/WPF)

This application demonstrates the SDK capabilities.

## Used media blocks

* `PushVideoSourceBlock` - Push video frames from DirectShow
* `PushAudioSourceBlock` - Push audio frames from DirectShow
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    PushVideoSourceBlock -- video --> VideoRendererBlock
    PushAudioSourceBlock -- audio --> AudioRendererBlock
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
