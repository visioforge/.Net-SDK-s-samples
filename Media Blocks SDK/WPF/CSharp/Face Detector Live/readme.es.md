# Media Blocks SDK .Net - Face Detector Live (C#/WPF)

Esta aplicación incluye detección facial con IA.

## Bloques de medios utilizados

* `SystemVideoSourceBlock` - Webcam video capture
* `DNNFaceDetectorBlock` - DNN-based face detection/blur
* `VideoRendererBlock` - Real-time video display

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -- video --> DNNFaceDetectorBlock -- video --> VideoRendererBlock
```

## Frameworks soportados

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
