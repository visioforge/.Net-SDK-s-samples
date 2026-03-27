# Media Blocks SDK .Net - SRT Source Demo (C#/WPF)

Esta aplicación recibe video vía protocolo de streaming seguro SRT.

## Bloques de medios utilizados

* `SRTSourceBlock` - SRT stream input
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    SRTSourceBlock -- video --> VideoRendererBlock
    SRTSourceBlock -- audio --> AudioRendererBlock
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
