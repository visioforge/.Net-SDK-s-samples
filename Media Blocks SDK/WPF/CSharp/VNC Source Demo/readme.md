# Media Blocks SDK .Net - VNC Source Demo (WPF)

The provided code sample demonstrates how to integrate VisioForge's MediaBlocks SDK for creating a VNC (Virtual Network Computing) source viewer within a WPF application.

The application initializes a media pipeline, establishes a VNC source connection using user-specified settings (such as host, port, and password), and renders the video output to the UI. It features start and stop functionality for the VNC viewer, along with a basic UI for inputting connection details.

Additionally, the application incorporates error handling within the media pipeline and updates the recording time, showcasing the SDK's capabilities for real-time media processing and display.

## Features

- Play video from VNC/RFB source

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- `VNCSourceBlock` - reads and decodes video/audio from a VNC/RFB source

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8
- .Net 9

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
