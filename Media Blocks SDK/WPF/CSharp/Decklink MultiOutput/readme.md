# Media Blocks SDK .Net - Decklink MultiOutput Demo (WPF)

This sample demonstrates how to use the Media Blocks SDK .Net to create a simple app streaming generated video to multiple Decklink outputs.

Decklink cards are professional video capture and playback cards from Blackmagic Design. They are widely used in the broadcast industry.

## Used blocks

- [VirtualVideoSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/VirtualVideoSourceBlock/) - generates video
- [ScreenSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/ScreenSourceBlock/) - captures screen or window
- [DecklinkVideoSinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Decklink/DecklinkVideoSinkBlock/) - outputs video to Decklink device
- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [TeeBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Special/TeeBlock/) - duplicates video and audio streams

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
