# Media Blocks SDK .Net - WebRTC WHIP Streamer Demo (C#/WPF)

This application captures video from a camera or screen, captures audio from a microphone, encodes them to H.264/Opus, and streams via WebRTC using the WHIP (WebRTC-HTTP Ingestion Protocol) with optional STUN server and authentication token support.

## Used media blocks

* `SystemVideoSourceBlock` - Camera video capture
* `ScreenSourceBlock` - Screen capture using Direct3D 11
* `SystemAudioSourceBlock` - Microphone audio capture
* `VideoRendererBlock` - Real-time video preview
* `AudioRendererBlock` - Real-time audio playback
* `TeeBlock` - Stream splitting for preview and encoding paths
* `H264EncoderBlock` - H.264/AVC video encoding
* `OPUSEncoderBlock` - Opus audio encoding
* `WHIPSinkBlock` - WebRTC WHIP streaming output

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk)
