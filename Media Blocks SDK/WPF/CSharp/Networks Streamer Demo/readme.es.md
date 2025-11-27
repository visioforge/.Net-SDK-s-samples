# Media Blocks SDK .Net - Networks Streamer Demo (C#/WPF)

Esta aplicación captura la salida de audio del sistema, captura contenido de escritorio/pantalla, guarda la salida en formato MP4, genera segmentos de streaming HLS, transmite vía protocolo de red NDI, transmite a YouTube Live, streams to Facebook Live, divide el flujo de video para múltiples salidas.

## Bloques de medios utilizados

* `SystemAudioSourceBlock` - System audio capture
* `ScreenSourceBlock` - Desktop screen capture
* `H264EncoderBlock` - H.264/AVC video encoding
* `AACEncoderBlock` - AAC audio encoding
* `MP4SinkBlock` - MP4 file output
* `HLSSinkBlock` - HLS streaming output
* `NDISinkBlock` - NDI network output
* `YouTubeSinkBlock` - YouTube Live streaming
* `FacebookLiveSinkBlock` - Facebook Live streaming
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Frameworks soportados

* .Net 4.7.2
* .Net Core 3.1
* .Net 5
* .Net 6
* .Net 7
* .Net 8
* .Net 9

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk)
