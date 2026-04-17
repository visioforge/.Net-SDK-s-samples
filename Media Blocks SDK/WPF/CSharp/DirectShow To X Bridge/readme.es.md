# Media Blocks SDK .Net - DirectShow To X Bridge (C#/WPF)

Esta aplicación demuestra las capacidades del SDK.

## Bloques de medios utilizados

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

## Frameworks soportados

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
