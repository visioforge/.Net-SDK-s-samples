# LibVisual Audio Visualizer Demo

This demo application showcases a WPF project that builds successfully with **net8.0-windows** target framework for the VisioForge Media Blocks SDK.

## Project Status

✅ **Successfully builds with net8.0-windows target framework**

This demo project demonstrates that the WPF application can be built with .NET 8 Windows targeting. The LibVisual GStreamer plugin support has been implemented in the core MediaBlocks SDK, but the actual visualizer functionality will be available once the new MediaBlocks are included in future NuGet package releases.

## Features

The demo includes UI for the following LibVisual visualizers (will be functional in future releases):

1. **LibVisual Corona** - Sun-like corona effects with radial flares
2. **LibVisual Infinite** - Flowing infinite tunnel and geometric patterns  
3. **LibVisual Bumpscope** - 3D bump mapped surfaces with texture
4. **LibVisual LV Analyzer** - Traditional spectrum analyzer display
5. **LibVisual LV Scope** - Oscilloscope-style waveform visualization
6. **LibVisual Jakdaw** - Organic bird-like flowing patterns
7. **LibVisual Jess** - Distinctive geometric and abstract patterns
8. **LibVisual Oinksie** - Playful and fun particle-based animations

## Requirements

- .NET 8.0 Windows runtime
- Windows operating system
- VisioForge MediaBlocks SDK NuGet packages

## Build Success

The project successfully builds with:
- Target Framework: `net8.0-windows`
- Platform Target: `x64`
- NuGet package references to VisioForge MediaBlocks SDK

## Development Notes

This demo project serves as a foundation for when the LibVisual MediaBlock classes are included in the published NuGet packages. The core implementation has been completed and added to the codebase - it just needs to be included in the next package release to be functional.

## Usage

Currently, the demo shows the UI but displays status messages indicating the LibVisual functionality is in development. Once the NuGet packages are updated with the new MediaBlocks, users will be able to:

1. Click "Browse..." to select an audio file
2. Choose a visualizer from the dropdown
3. Click "Start" to begin playback with visualization
4. Use Pause/Resume controls as needed
5. Click "Stop" to end playback