# Media Blocks SDK .Net - RTSP MultiViewSync Demo (C#/WPF)

Esta aplicación se conecta a cámaras RTSP/IP para transmisión de video en vivo.

## Bloques de medios utilizados

* `RTSPSourceBlock` - RTSP stream input
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    RTSPSourceBlock1[RTSPSourceBlock 1] -- video --> VideoRendererBlock1[VideoRendererBlock 1]
    RTSPSourceBlock2[RTSPSourceBlock 2] -- video --> VideoRendererBlock2[VideoRendererBlock 2]
    RTSPSourceBlock3[RTSPSourceBlock 3] -- video --> VideoRendererBlock3[VideoRendererBlock 3]
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
