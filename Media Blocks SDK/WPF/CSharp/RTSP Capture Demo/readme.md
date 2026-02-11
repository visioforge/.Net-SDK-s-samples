# Media Blocks SDK .Net - RTSP Capture Demo (C#/WPF)

This application connects to RTSP streams from IP cameras, displays live preview with optional low-latency mode, and can record the stream to MP4 or MPEG-TS files. It includes ONVIF camera discovery and control features.

## Used media blocks

* `RTSPSourceBlock` - RTSP stream source
* `VideoRendererBlock` - Real-time video preview
* `AudioRendererBlock` - Real-time audio playback
* `TeeBlock` - Stream splitting for preview and recording paths
* `H264EncoderBlock` - H.264/AVC video encoding
* `AACEncoderBlock` - AAC audio encoding
* `MP4SinkBlock` - MP4 file output
* `MPEGTSSinkBlock` - MPEG-TS file output

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk)
