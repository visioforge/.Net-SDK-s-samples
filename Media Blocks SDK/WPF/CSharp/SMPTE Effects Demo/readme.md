# Media Blocks SDK .Net - SMPTE Effects Demo (WPF)

This SDK sample demonstrates the SMPTE transition effects in the VisioForge Media Blocks SDK .Net. SMPTE wipes from the video to its grayscale copy over the configured duration, using one of the standard SMPTE patterns. SMPTE Alpha writes the transition mask at a fixed position into the alpha channel of the video. The effect settings apply when playback starts.

## Features

- Load and play video files with SMPTE transition effects
- Configure SMPTE transition type using professional transition patterns (enum-based selection)
- Adjust border width for transition edges
- SMPTE: mask depth in bits (1-24) and transition duration
- SMPTE Alpha: transition position (0.0-1.0)
- Invert transition direction

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio
- [UniversalSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/UniversalSourceBlock/) - decodes media files
- `TeeBlock` - splits the video for the second SMPTE input
- `GrayscaleBlock` - makes the second SMPTE input grayscale
- `SMPTEBlock` - applies SMPTE transition effects
- `SMPTEAlphaBlock` - applies SMPTE alpha transition effects

## Supported frameworks

- .Net 4.7.2
- .Net 5
- .Net 6
- .Net 7
- .Net 8
- .Net 9
- .Net 10

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)