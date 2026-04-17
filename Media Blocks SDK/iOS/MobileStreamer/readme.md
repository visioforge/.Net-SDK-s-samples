# Media Blocks SDK .Net - MobileStreamer (C#/iOS)

This application captures system audio output, streams to YouTube Live, streams to Facebook Live, splits video stream for multiple outputs.

## Used media blocks

* `SystemVideoSourceBlock` - System video camera capture
* `SystemAudioSourceBlock` - System audio capture
* `H264EncoderBlock` - H.264/AVC video encoding
* `AACEncoderBlock` - AAC audio encoding
* `OPUSEncoderBlock` - OPUS audio encoding
* `YouTubeSinkBlock` - YouTube Live streaming
* `FacebookLiveSinkBlock` - Facebook Live streaming
* `SRTMPEGTSSinkBlock` - SRT MPEG-TS streaming
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock --> TeeBlock
    TeeBlock -- preview --> VideoRendererBlock
    TeeBlock -- stream --> H264EncoderBlock
    H264EncoderBlock -- video --> StreamingSink

    SystemAudioSourceBlock --> AudioEncoder
    AudioEncoder -- audio --> StreamingSink

    StreamingSink["YouTubeSinkBlock / FacebookLiveSinkBlock / SRTMPEGTSSinkBlock"]
    AudioEncoder["AACEncoderBlock / OPUSEncoderBlock"]
```

## Supported frameworks

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
