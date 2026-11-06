# Media Blocks SDK .Net - RTSP Webcam Blazor Server (C#/Blazor)

This application demonstrates the SDK capabilities.

## Used media blocks

* `H264EncoderBlock` - H.264/AVC video encoding

## Pipeline

```mermaid
graph LR
    SystemVideoSourceBlock -- video --> RTSPServerBlock
```

## Building on macOS

A Release build and `dotnet publish -c Release` build the app bundle for the host CPU; publish also writes a `.pkg` installer of it into its publish folder. For the other architecture, publish with `-r osx-x64` or `-r osx-arm64`, for example `dotnet publish -c Release -r osx-x64`.

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
