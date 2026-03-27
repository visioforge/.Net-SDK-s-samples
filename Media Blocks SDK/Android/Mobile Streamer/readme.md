# Media Blocks SDK .Net - Mobile Streamer (C#/Android)

This application captures system audio output, streams to YouTube Live, streams to Facebook Live, splits video stream for multiple outputs.

## Used media blocks

* `SystemVideoSourceBlock` - System video camera capture
* `SystemAudioSourceBlock` - System audio capture
* `H264EncoderBlock` - H.264/AVC video encoding
* `AACEncoderBlock` - AAC audio encoding
* `YouTubeSinkBlock` - YouTube Live streaming
* `FacebookLiveSinkBlock` - Facebook Live streaming
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock --> TeeBlock_Video
    TeeBlock_Video -- preview --> VideoRendererBlock
    TeeBlock_Video -- stream --> H264EncoderBlock
    H264EncoderBlock -- video --> StreamingSink[YouTubeSinkBlock / FacebookLiveSinkBlock]

    SystemAudioSourceBlock --> TeeBlock_Audio
    TeeBlock_Audio -- preview --> AudioRendererBlock
    TeeBlock_Audio -- stream --> AACEncoderBlock
    AACEncoderBlock -- audio --> StreamingSink
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
