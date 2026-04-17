# Media Blocks SDK .Net - DataMatrix Detection Demo (C#/WPF)

Esta aplicación realiza detección de códigos DataMatrix en tiempo real desde una fuente de cámara con visualización en pantalla.

## Bloques de medios utilizados

* `SystemVideoSourceBlock` - Captura de cámara del sistema
* `DataMatrixDecoderBlock` - Detección y decodificación de códigos DataMatrix
* `VideoRendererBlock` - Visualización de video en tiempo real

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -- video --> DataMatrixDecoderBlock
    DataMatrixDecoderBlock -- video --> VideoRendererBlock
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
