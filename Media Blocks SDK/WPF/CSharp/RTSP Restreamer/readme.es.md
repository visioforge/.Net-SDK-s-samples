# Media Blocks SDK .Net - RTSP Restreamer (C#/WPF)

Esta aplicación se conecta a cámaras RTSP/IP para transmisión de video en vivo, divide el flujo de video para múltiples salidas.

## Bloques de medios utilizados

* `RTSPSourceBlock` - RTSP stream input
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display
* `TextOverlayBlock` - Text overlay
* `RTSPServerBlock` - RTSP server output

## Pipeline

```mermaid
graph LR
    RTSPSourceBlock -- video --> TeeBlock
    TeeBlock -- video --> VideoRendererBlock
    TeeBlock -- video --> TextOverlayBlock --> RTSPServerBlock
    RTSPSourceBlock -- audio --> RTSPServerBlock
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
