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

## Pipeline

```mermaid
graph LR
    RTSPSourceBlock -- video --> TeeBlock_Video[TeeBlock]
    TeeBlock_Video -- video --> VideoRendererBlock
    TeeBlock_Video -- video --> H264EncoderBlock --> MP4SinkBlock
    RTSPSourceBlock -- audio --> TeeBlock_Audio[TeeBlock]
    TeeBlock_Audio -- audio --> AudioRendererBlock
    TeeBlock_Audio -- audio --> AACEncoderBlock --> MP4SinkBlock
```

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk)
