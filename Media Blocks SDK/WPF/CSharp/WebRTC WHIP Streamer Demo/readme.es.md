# Media Blocks SDK .Net - WebRTC WHIP Streamer Demo (C#/WPF)

Esta aplicación captura video de una cámara o pantalla, captura audio de un micrófono, los codifica en H.264/Opus y los transmite a través de WebRTC usando el protocolo WHIP (WebRTC-HTTP Ingestion Protocol) con soporte opcional para servidor STUN y token de autenticación.

## Bloques de medios utilizados

* `SystemVideoSourceBlock` - Camera video capture
* `ScreenSourceBlock` - Screen capture using Direct3D 11
* `SystemAudioSourceBlock` - Microphone audio capture
* `VideoRendererBlock` - Real-time video preview
* `AudioRendererBlock` - Real-time audio playback
* `TeeBlock` - Stream splitting for preview and encoding paths
* `H264EncoderBlock` - H.264/AVC video encoding
* `OPUSEncoderBlock` - Opus audio encoding
* `WHIPSinkBlock` - WebRTC WHIP streaming output

## Frameworks soportados

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk)
