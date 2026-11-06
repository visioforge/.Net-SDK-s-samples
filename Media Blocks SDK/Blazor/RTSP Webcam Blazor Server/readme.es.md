# Media Blocks SDK .Net - RTSP Webcam Blazor Server (C#/Blazor)

Esta aplicación demuestra las capacidades del SDK.

## Bloques de medios utilizados

* `H264EncoderBlock` - H.264/AVC video encoding

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -- video --> RTSPServerBlock
```

## Compilación en macOS

La compilación Release y `dotnet publish -c Release` generan el app bundle para la CPU del equipo; publicar escribe además un instalador `.pkg` en su carpeta de publicación. Para la otra arquitectura, publique con `-r osx-x64` o `-r osx-arm64`, por ejemplo `dotnet publish -c Release -r osx-x64`.

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
