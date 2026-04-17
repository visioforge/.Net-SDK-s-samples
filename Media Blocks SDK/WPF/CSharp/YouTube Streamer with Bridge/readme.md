# Media Blocks SDK .Net - YouTube Streamer with Bridge (C#/WPF)

This application captures system audio output, streams to YouTube Live, splits video stream for multiple outputs.

## Used media blocks

* `SystemVideoSourceBlock` - Camera video capture
* `SystemAudioSourceBlock` - System audio capture
* `BridgeVideoSinkBlock` / `BridgeVideoSourceBlock` - Video bridge between pipelines
* `BridgeAudioSinkBlock` / `BridgeAudioSourceBlock` - Audio bridge between pipelines
* `H264EncoderBlock` - H.264/AVC video encoding
* `AACEncoderBlock` - AAC audio encoding
* `YouTubeSinkBlock` - YouTube Live streaming
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    subgraph Preview Pipeline
        SystemVideoSourceBlock -- video --> TeeBlock_Video[TeeBlock]
        TeeBlock_Video -- video --> VideoRendererBlock
        TeeBlock_Video -- video --> BridgeVideoSinkBlock
        SystemAudioSourceBlock -- audio --> TeeBlock_Audio[TeeBlock]
        TeeBlock_Audio -- audio --> AudioRendererBlock
        TeeBlock_Audio -- audio --> BridgeAudioSinkBlock
    end
    subgraph Streaming Pipeline
        BridgeVideoSourceBlock -- video --> H264EncoderBlock --> YouTubeSinkBlock
        BridgeAudioSourceBlock -- audio --> AACEncoderBlock --> YouTubeSinkBlock
    end
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
