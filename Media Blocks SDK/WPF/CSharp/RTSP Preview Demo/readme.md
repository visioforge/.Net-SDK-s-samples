# Media Blocks SDK .Net - RTSP Preview Demo (C#/WPF)

This application connects to RTSP/IP cameras for live video streaming, supports ONVIF camera discovery and control.

## Used media blocks

* `RTSPSourceBlock` - RTSP stream input
* `VideoRendererBlock` - Real-time video display
* `AudioRendererBlock` - Real-time audio playback

## Pipeline

```mermaid
graph LR
    RTSPSourceBlock -- video --> VideoRendererBlock
    RTSPSourceBlock -- audio --> AudioRendererBlock
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
