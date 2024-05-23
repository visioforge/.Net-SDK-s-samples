# Media Blocks SDK .Net - Decklink Demo (WPF)

The provided code is for a demo application using the VisioForge Media Blocks SDK, specifically focusing on media processing and Decklink device integration. The application showcases the creation of a media processing pipeline, including video and audio source selection (either from Decklink devices or files), real-time video and audio rendering, video effects, and encoding to various formats such as MP4, WebM, MXF, and MPEG2. It utilizes a wide array of VisioForge's Media Blocks for handling different media processing tasks, such as video resizing, adding text or image overlays, and capturing from or outputting to Decklink devices. The GUI allows for dynamic configuration of input and output settings, including device selection, video mode, and output file format, demonstrating the SDK's versatility in multimedia applications.

## Used blocks

### Decklink source and output

- [DecklinkVideoSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Decklink/DecklinkVideoSourceBlock/) - captures video from Decklink device
- [DecklinkAudioSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Decklink/DecklinkAudioSourceBlock/) - captures audio from Decklink device
- [DecklinkAudioSinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Decklink/DecklinkAudioSinkBlock/) - outputs audio to Decklink device
- [DecklinkVideoSinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Decklink/DecklinkVideoSinkBlock/) - outputs video to Decklink device

### MP4 file output

- [MP4SinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/MP4SinkBlock/) - muxes compressed video and audio to MP4
- [H264EncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoEncoders/H264EncoderBlock/) - encodes video to H264
- [AACEncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioEncoders/AACEncoderBlock/) - encodes audio to AAC

### WebM file output

- [WebMSinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/WebMSinkBlock/) - muxes compressed video and audio to WebM
- [VorbisEncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioEncoders/VorbisEncoderBlock/) - encodes audio to Vorbis
- [VPXEncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoEncoders/VPXEncoderBlock/) - encodes video to VP8/VP9

### MPEG-TS file output

- [MPEGTSSinkSettings](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/MPEGTSSinkBlock/) - muxes compressed video and audio to MPEG-TS
- `MPEG2EncoderBlock` - encodes video to MPEG2
- [MP2EncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioEncoders/MP2EncoderBlock/) - encodes audio to MP2

### MXF file output

- [MXFSinkBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sinks/MXFSinkBlock/) - muxes compressed video and audio to MXF
- [DNxHDEncoderBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoEncoders/DNxHDEncoderBlock/) - encodes video to DNxHD

### Other blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio
- [VideoResizeBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoProcessing/VideoResizeBlock/) - resizes video
- `VideoEffectsWinBlock` - applies video effects
- [TeeBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Special/TeeBlock/) - duplicates video and audio streams
- [UniversalSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/UniversalSourceBlock/) - reads video and audio from file

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
