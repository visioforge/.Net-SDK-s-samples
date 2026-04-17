# Media Blocks SDK .Net - SimpleVideoCapture (C#/iOS)

This application captures system audio output, saves output to MP4 format, splits video stream for multiple outputs.

## Used media blocks

* `SystemVideoSourceBlock` - System video camera capture
* `SystemAudioSourceBlock` - System audio capture
* `H264EncoderBlock` - H.264/AVC video encoding
* `AACEncoderBlock` - AAC audio encoding
* `MP4SinkBlock` - MP4 file output
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock --> TeeBlock
    TeeBlock -- preview --> VideoRendererBlock
    TeeBlock -- record --> H264EncoderBlock
    H264EncoderBlock -- video --> MP4SinkBlock

    SystemAudioSourceBlock --> AACEncoderBlock
    AACEncoderBlock -- audio --> MP4SinkBlock
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
