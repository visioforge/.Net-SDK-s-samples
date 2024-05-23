
# Media Blocks SDK .Net - SRT Source Demo (WPF)

The provided code sample demonstrates how to integrate VisioForge's MediaBlocks SDK to create an SRT source viewer within a WPF application.

The Secure Reliable Transport (SRT) streaming protocol enables the delivery of high-quality, low-latency video and audio streams over the internet. Originally developed by Haivision, SRT optimizes streaming performance across unpredictable networks like the public internet by addressing challenges such as packet loss, jitter, and fluctuating bandwidth. It uses end-to-end encryption to ensure security and integrates error recovery mechanisms to maintain stream integrity. SRT is an open-source protocol, widely adopted for its ability to maintain the quality and security of media streams in various broadcast and streaming applications.

The application sets up a media pipeline and connects to an SRT source based on settings provided by the user, such as the host, port, and password. It then displays the video output on the user interface. This application also includes start and stop controls for the SRT viewer and a simple user interface for entering connection details.

Furthermore, the application features error management within the media pipeline and updates the recording time, demonstrating the SDK's potential for real-time media processing and display.

## Features

- Play video from SRT source

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [SRTSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SRTSourceBlock/) - reads and decodes video/audio from an SRT source
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
