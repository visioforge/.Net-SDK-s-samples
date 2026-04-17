# Media Blocks SDK .Net - Simple Player Demo (C#/WinForms)

Esta aplicación reproduce archivos multimedia usando el decodificador universal.

## Bloques de medios utilizados

* `UniversalSourceBlock` - Reproducción universal de archivos multimedia
* `VideoRendererBlock` - Visualización de video en tiempo real
* `AudioRendererBlock` - Reproducción de audio en tiempo real

## Pipeline

```mermaid
graph LR
    UniversalSourceBlock -- video --> VideoRendererBlock
    UniversalSourceBlock -- audio --> AudioRendererBlock
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
