# Media Blocks SDK .Net - Video Compositor Demo (C#/WPF)

Esta aplicación reproduce archivos multimedia usando el decodificador universal, captura contenido de escritorio/pantalla, transmite vía protocolo de red NDI, compone múltiples fuentes de video en una sola salida, divide el flujo de video para múltiples salidas, aplica composición de croma (pantalla verde).

## Bloques de medios utilizados

* `UniversalSourceBlock` - Universal media file playback
* `ScreenSourceBlock` - Desktop screen capture
* `NDISinkBlock` - NDI network output
* `VideoCompositorBlock` - Multi-source compositing
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display

## Pipeline

```mermaid
graph LR
    Source1["Source 1"] -- video --> VideoMixerBlock
    Source2["Source 2"] -- video --> VideoMixerBlock
    SourceN["Source N"] -- video --> VideoMixerBlock
    VideoMixerBlock -- video --> TeeBlock
    TeeBlock -- video --> VideoRendererBlock
    TeeBlock -- video --> OutputSink["MP4/YouTube/NDI Output"]
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
