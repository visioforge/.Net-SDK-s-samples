# Media Blocks SDK .Net - h264-data-player (C#/WinForms)

Esta aplicación reproduce datos de video H264 empujando bytes H264 sin procesar a través del pipeline, analizando, decodificando y renderizando el video.

## Bloques de medios utilizados

* `PushSourceBlock` - Fuente de datos basada en push
* `H264ParseBlock` - Análisis de flujo H.264
* `H264DecoderBlock` - Decodificación de video H.264/AVC
* `VideoRendererBlock` - Visualización de video en tiempo real

## Pipeline

```mermaid
graph LR
    PushSourceBlock --> H264ParseBlock --> H264DecoderBlock --> VideoRendererBlock
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
