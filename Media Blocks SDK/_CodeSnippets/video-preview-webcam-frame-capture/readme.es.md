# Media Blocks SDK .Net - video-preview-webcam-frame-capture (C#/Console)

Esta aplicación captura la salida de audio del sistema, captura fotogramas individuales para análisis o procesamiento.

## Bloques de medios utilizados

* `SystemAudioSourceBlock` - System audio capture
* `VideoSampleGrabberBlock` - Frame capture/analysis
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -->|Video| VideoSampleGrabberBlock -->|Video| VideoRendererBlock
    SystemAudioSourceBlock -->|Audio| AudioRendererBlock
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
