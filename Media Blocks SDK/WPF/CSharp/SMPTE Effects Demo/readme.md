# Media Blocks SDK .Net - SMPTE Effects Demo (WPF)

This SDK sample demonstrates how to use the SMPTE transition effects in the VisioForge Media Blocks SDK .Net. The application showcases both SMPTE and SMPTE Alpha transition effects with various configuration options. Users can load video files, apply different SMPTE transition patterns, adjust transition parameters like type, border, depth/position, and invert direction. The demo includes real-time preview of transitions and demonstrates the professional video editing capabilities of the SMPTE effects.

## Features

- Load and play video files with SMPTE transition effects
- Configure SMPTE transition type using professional transition patterns (enum-based selection)
- Adjust border width for transition edges
- Control transition depth/position (0.0-1.0)
- Invert transition direction
- Real-time preview of both SMPTE and SMPTE Alpha effects
- Professional video editing transition patterns

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering/) - renders audio
- [UniversalSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/UniversalSourceBlock/) - decodes media files
- `SMPTEBlock` - applies SMPTE transition effects
- `SMPTEAlphaBlock` - applies SMPTE alpha transition effects

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