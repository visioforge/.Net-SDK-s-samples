# Media Blocks SDK .Net - GenICam Source Demo (C#/WPF)

Esta aplicación divide el flujo de video para múltiples salidas.

## Bloques de medios utilizados

* `GenICamSourceBlock` - GenICam camera source
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display
* `H264EncoderBlock` - H.264/AVC video encoding
* `MP4OutputBlock` - MP4 file output

## Pipeline

```mermaid
graph LR
    GenICamSourceBlock -- video --> TeeBlock
    TeeBlock -- video --> VideoRendererBlock
    TeeBlock -- video --> MP4OutputBlock
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
