# Media Blocks SDK .Net - SimpleVideoCaptureMVVM (C#/Avalonia)

Esta aplicacion captura video de una camara con grabacion opcional a archivo MP4, usando el patron MVVM.

## Bloques de medios utilizados

* `SystemVideoSourceBlock` - Captura de video de la camara
* `TeeBlock` - Division de flujo para vista previa y grabacion
* `VideoRendererBlock` - Visualizacion de video en tiempo real
* `MP4OutputBlock` - Salida de grabacion a archivo MP4

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -- video --> TeeBlock_Video
    TeeBlock_Video -- video --> VideoRendererBlock
    TeeBlock_Video -- video --> MP4OutputBlock
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
