# Media Blocks SDK .Net - SimpleVideoCaptureMVVM (C#/Avalonia)

This application captures video from a camera with optional recording to MP4 file, using the MVVM pattern.

## Used media blocks

* `SystemVideoSourceBlock` - Camera video capture
* `TeeBlock` - Stream splitting for preview and recording paths
* `VideoRendererBlock` - Real-time video display
* `MP4OutputBlock` - MP4 file recording output

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -- video --> TeeBlock_Video
    TeeBlock_Video -- video --> VideoRendererBlock
    TeeBlock_Video -- video --> MP4OutputBlock
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
