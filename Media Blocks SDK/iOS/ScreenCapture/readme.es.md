# Media Blocks SDK .Net - ScreenCapture (C#/iOS)

Esta aplicación captura la salida de audio del sistema, captura contenido de escritorio/pantalla, guarda la salida en formato MP4, divide el flujo de video para múltiples salidas.

## Bloques de medios utilizados

* `ScreenSourceBlock` - Screen capture
* `H264EncoderBlock` - H.264/AVC video encoding
* `MP4SinkBlock` - MP4 file output
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display

## Pipeline

```mermaid
graph LR
    ScreenSourceBlock --> TeeBlock
    TeeBlock -- preview --> VideoRendererBlock
    TeeBlock -- record --> H264EncoderBlock
    H264EncoderBlock --> MP4SinkBlock
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
