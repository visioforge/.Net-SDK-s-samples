# Media Blocks SDK .Net - ScreenCaptureMB (C#/MAUI)

Esta aplicación captura contenido de escritorio/pantalla, guarda la salida en formato MP4, divide el flujo de video para múltiples salidas.

## Bloques de medios utilizados

* `ScreenSourceBlock` - Desktop screen capture
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display
* `H264EncoderBlock` - H.264/AVC video encoding
* `MP4SinkBlock` - MP4 file output

## Pipeline

```mermaid
graph LR
    ScreenSourceBlock -- video --> TeeBlock
    TeeBlock -- video --> VideoRendererBlock
    TeeBlock -- video --> H264EncoderBlock
    H264EncoderBlock -- video --> MP4SinkBlock
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
