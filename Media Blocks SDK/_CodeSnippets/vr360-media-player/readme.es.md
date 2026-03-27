# Media Blocks SDK .Net - vr360-media-player (C#/Console)

Esta aplicación reproduce archivos multimedia usando el decodificador universal.

## Bloques de medios utilizados

* `UniversalSourceBlock` - Universal media file playback
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    UniversalSourceBlock -->|Video| VR360ProcessorBlock -->|Video| VideoRendererBlock
    UniversalSourceBlock -->|Audio| AudioRendererBlock
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
