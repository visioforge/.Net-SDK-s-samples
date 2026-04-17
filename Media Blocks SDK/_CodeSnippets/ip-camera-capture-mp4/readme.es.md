# Media Blocks SDK .Net - ip-camera-capture-mp4 (C#/WinForms)

Esta aplicación se conecta a una cámara RTSP/IP para transmisión de video en vivo, previsualiza el video y audio, y graba ambos en un archivo MP4.

## Bloques de medios utilizados

* `RTSPSourceBlock` - Entrada de flujo RTSP
* `TeeBlock` - División de flujo (video y audio)
* `VideoRendererBlock` - Visualización de video en tiempo real
* `AudioRendererBlock` - Reproducción de audio en tiempo real
* `MP4OutputBlock` - Salida de archivo MP4

## Pipeline

```mermaid
graph LR
    RTSPSourceBlock -- video --> TeeBlock_Video["TeeBlock (Video)"]
    TeeBlock_Video --> VideoRendererBlock
    TeeBlock_Video --> MP4OutputBlock
    RTSPSourceBlock -- audio --> TeeBlock_Audio["TeeBlock (Audio)"]
    TeeBlock_Audio --> AudioRendererBlock
    TeeBlock_Audio --> MP4OutputBlock
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
