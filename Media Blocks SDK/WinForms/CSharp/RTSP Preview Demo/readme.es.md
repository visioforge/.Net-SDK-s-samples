# Media Blocks SDK .Net - RTSP Preview Demo (C#/WinForms)

Esta aplicación se conecta a cámaras RTSP/IP para transmisión de video en vivo, soporta descubrimiento y control de cámaras ONVIF, soporta transmisión de ultra baja latencia.

## Bloques de medios utilizados

* `RTSPSourceBlock` - Entrada de flujo RTSP
* `VideoRendererBlock` - Visualización de video en tiempo real
* `AudioRendererBlock` - Reproducción de audio en tiempo real

## Pipeline

```mermaid
graph LR
    RTSPSourceBlock -- video --> VideoRendererBlock
    RTSPSourceBlock -- audio --> AudioRendererBlock
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
