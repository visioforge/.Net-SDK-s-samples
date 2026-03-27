# Media Blocks SDK .Net - video-capture-image-overlay (C#/Console)

Esta aplicación captura la salida de audio del sistema, divide el flujo de video para múltiples salidas.

## Bloques de medios utilizados

* `SystemAudioSourceBlock` - System audio capture
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -->|Video| ImageOverlayCairoBlock -->|Video| VideoTeeBlock[TeeBlock]
    SystemAudioSourceBlock -->|Audio| AudioTeeBlock[TeeBlock]
    VideoTeeBlock -->|Video| VideoRendererBlock
    AudioTeeBlock -->|Audio| AudioRendererBlock
    VideoTeeBlock -->|Video| MP4OutputBlock
    AudioTeeBlock -->|Audio| MP4OutputBlock
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
