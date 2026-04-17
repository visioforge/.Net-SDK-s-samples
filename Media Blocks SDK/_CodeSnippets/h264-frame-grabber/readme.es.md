# Media Blocks SDK .Net - h264-frame-grabber (C#/WinForms)

Esta aplicación lee un archivo MP4, desmultiplexa el flujo de video H264, lo analiza y captura fotogramas de datos H264 sin procesar usando un capturador de muestras.

## Bloques de medios utilizados

* `BasicFileSourceBlock` - Fuente de medios basada en archivo
* `ParseBinBlock` - Desmultiplexación automática de flujos
* `H264ParseBlock` - Análisis de flujo H.264
* `DataSampleGrabberBlock` - Captura de fotogramas de datos sin procesar
* `NullRendererBlock` - Salida nula (descarta fotogramas)

## Pipeline

```mermaid
graph LR
    BasicFileSourceBlock --> ParseBinBlock -- video --> H264ParseBlock --> DataSampleGrabberBlock --> NullRendererBlock
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
