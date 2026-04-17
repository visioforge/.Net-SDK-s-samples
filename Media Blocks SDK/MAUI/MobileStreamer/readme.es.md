# Media Blocks SDK .Net - MobileStreamer (C#/MAUI)

Esta aplicación captura la salida de audio del sistema, transmite a YouTube Live, streams to Facebook Live, divide el flujo de video para múltiples salidas.

## Bloques de medios utilizados

* `SystemVideoSourceBlock` - Camera device capture
* `SystemAudioSourceBlock` - System audio capture
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display
* `H264EncoderBlock` - H.264/AVC video encoding
* `AACEncoderBlock` - AAC audio encoding
* `YouTubeSinkBlock` - YouTube Live streaming
* `FacebookLiveSinkBlock` - Facebook Live streaming
* `RTMPSinkBlock` - RTMP streaming

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -- video --> TeeBlock
    TeeBlock -- video --> VideoRendererBlock
    TeeBlock -- video --> H264EncoderBlock
    H264EncoderBlock -- video --> Sink[YouTubeSinkBlock / FacebookLiveSinkBlock / RTMPSinkBlock]
    SystemAudioSourceBlock -- audio --> AACEncoderBlock
    AACEncoderBlock -- audio --> Sink
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
