# Media Blocks SDK .Net - Simple Video Capture Demo (C#/WinForms)

This application captures system audio output, saves output to MP4 format, captures individual video frames for analysis or processing, captures audio samples for analysis, splits video stream for multiple outputs.

## Used media blocks

* `SystemAudioSourceBlock` - System audio capture
* `H264EncoderBlock` - H.264/AVC video encoding
* `AACEncoderBlock` - AAC audio encoding
* `MP4SinkBlock` - MP4 file output
* `VideoSampleGrabberBlock` - Frame capture/analysis
* `AudioSampleGrabberBlock` - Audio sample capture
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -- video --> VideoSampleGrabberBlock
    VideoSampleGrabberBlock -- video --> TeeBlock-Video
    TeeBlock-Video -- video --> VideoRendererBlock
    TeeBlock-Video -- video --> H264EncoderBlock
    H264EncoderBlock -- h264 --> MP4SinkBlock

    SystemAudioSourceBlock -- audio --> AudioSampleGrabberBlock
    AudioSampleGrabberBlock -- audio --> TeeBlock-Audio
    TeeBlock-Audio -- audio --> AudioRendererBlock
    TeeBlock-Audio -- audio --> AACEncoderBlock
    AACEncoderBlock -- aac --> MP4SinkBlock
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
