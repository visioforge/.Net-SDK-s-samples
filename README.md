# VisioForge .Net SDKs - Sample Projects

This repository contains sample projects demonstrating the capabilities of VisioForge .Net SDKs for video/audio capture, editing, playback, and processing.

## Repository Structure

- **Media Blocks SDK** - Modular pipeline-based video processing framework
- **Video Capture SDK** - Video and audio capture with encoding
- **Video Capture SDK X** - Cross-platform video capture (Windows, Linux, macOS, Android, iOS)
- **Media Player SDK** - Advanced media playback
- **Media Player SDK X** - Cross-platform media player
- **Video Edit SDK** - Video editing and conversion
- **Video Edit SDK X** - Cross-platform video editing
- **Video Fingerprinting SDK** - Audio/video content recognition

## Quick Start

1. Clone this repository
2. Open a project solution (.sln) in Visual Studio or your preferred IDE
3. Build the solution to restore NuGet packages automatically
4. Run the demo application

Most demo applications contain unmanaged NuGet redist packages specific to the SDK and platform used. The packages are automatically downloaded during the build process.

## NuGet Packages

### Core SDK Packages

| Package | Description | NuGet Link |
|---------|-------------|------------|
| VisioForge.DotNet.MediaBlocks | Media Blocks SDK - modular video processing | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.MediaBlocks.svg)](https://www.nuget.org/packages/VisioForge.DotNet.MediaBlocks/) |
| VisioForge.DotNet.VideoCapture | Video Capture SDK - capture and encode | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.VideoCapture.svg)](https://www.nuget.org/packages/VisioForge.DotNet.VideoCapture/) |
| VisioForge.DotNet.MediaPlayer | Media Player SDK - advanced playback | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.MediaPlayer.svg)](https://www.nuget.org/packages/VisioForge.DotNet.MediaPlayer/) |
| VisioForge.DotNet.VideoEdit | Video Edit SDK - editing and conversion | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.VideoEdit.svg)](https://www.nuget.org/packages/VisioForge.DotNet.VideoEdit/) |
| VisioForge.DotNet.Core | Core shared functionality | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core/) |

### Cross-Platform Core Packages

| Package | Platform | NuGet Link |
|---------|----------|------------|
| VisioForge.CrossPlatform.Core.Windows.x64 | Windows x64 | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.Core.Windows.x64.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.Core.Windows.x64/) |
| VisioForge.CrossPlatform.Core.Linux.x64 | Linux x64 | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.Core.Linux.x64.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.Core.Linux.x64/) |
| VisioForge.CrossPlatform.Core.macOS | macOS | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.Core.macOS.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.Core.macOS/) |
| VisioForge.CrossPlatform.Core.Android | Android | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.Core.Android.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.Core.Android/) |
| VisioForge.CrossPlatform.Core.iOS | iOS | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.Core.iOS.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.Core.iOS/) |
| VisioForge.CrossPlatform.Core.macCatalyst | Mac Catalyst | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.Core.macCatalyst.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.Core.macCatalyst/) |

### Redistribution Packages (Windows)

| Package | Description | NuGet Link |
|---------|-------------|------------|
| VisioForge.DotNet.Core.Redist.VideoCapture.x64 | Video Capture redist x64 | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.Redist.VideoCapture.x64.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.Redist.VideoCapture.x64/) |
| VisioForge.DotNet.Core.Redist.MediaPlayer.x64 | Media Player redist x64 | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.Redist.MediaPlayer.x64.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.Redist.MediaPlayer.x64/) |
| VisioForge.DotNet.Core.Redist.VideoEdit.x64 | Video Edit redist x64 | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.Redist.VideoEdit.x64.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.Redist.VideoEdit.x64/) |
| VisioForge.DotNet.Core.Redist.LAV.x64 | LAV Filters x64 | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.Redist.LAV.x64.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.Redist.LAV.x64/) |
| VisioForge.DotNet.Core.Redist.FFMPEG.x64 | FFmpeg redist x64 | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.Redist.FFMPEG.x64.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.Redist.FFMPEG.x64/) |
| VisioForge.DotNet.Core.Redist.MP4.x64 | MP4 support x64 | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.Redist.MP4.x64.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.Redist.MP4.x64/) |
| VisioForge.DotNet.Core.Redist.WebM.x64 | WebM support x64 | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.Redist.WebM.x64.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.Redist.WebM.x64/) |

### UI Framework Packages

| Package | Framework | NuGet Link |
|---------|-----------|------------|
| VisioForge.DotNet.Core.UI.WinUI | WinUI 3 | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.UI.WinUI.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.UI.WinUI/) |
| VisioForge.DotNet.Core.UI.MAUI | .NET MAUI | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.UI.MAUI.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.UI.MAUI/) |
| VisioForge.DotNet.Core.UI.Avalonia | Avalonia UI | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.UI.Avalonia.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.UI.Avalonia/) |

### Specialty Packages

| Package | Description | NuGet Link |
|---------|-------------|------------|
| VisioForge.DotNet.Core.FaceAI | Face detection and recognition | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.FaceAI.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.FaceAI/) |
| VisioForge.FaceAI.Models | Pre-trained AI models | [![NuGet](https://img.shields.io/nuget/v/VisioForge.FaceAI.Models.svg)](https://www.nuget.org/packages/VisioForge.FaceAI.Models/) |
| VisioForge.DotNet.Core.CV | Computer Vision functionality | [![NuGet](https://img.shields.io/nuget/v/VisioForge.DotNet.Core.CV.svg)](https://www.nuget.org/packages/VisioForge.DotNet.Core.CV/) |
| VisioForge.CrossPlatform.OpenCV.Windows.x64 | OpenCV integration | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.OpenCV.Windows.x64.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.OpenCV.Windows.x64/) |
| VisioForge.CrossPlatform.Libav.Windows.x64 | Libav framework | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.Libav.Windows.x64.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.Libav.Windows.x64/) |

### Camera Integration Packages

| Package | Description | NuGet Link |
|---------|-------------|------------|
| VisioForge.CrossPlatform.Basler.Windows.x64 | Basler camera support | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.Basler.Windows.x64.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.Basler.Windows.x64/) |
| VisioForge.CrossPlatform.Spinnaker.Windows.x64 | FLIR/Spinnaker camera support | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.Spinnaker.Windows.x64.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.Spinnaker.Windows.x64/) |
| VisioForge.CrossPlatform.GenICam.Windows.x64 | GenICam standard support | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.GenICam.Windows.x64.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.GenICam.Windows.x64/) |
| VisioForge.CrossPlatform.AlliedVision.Windows.x64 | Allied Vision camera support | [![NuGet](https://img.shields.io/nuget/v/VisioForge.CrossPlatform.AlliedVision.Windows.x64.svg)](https://www.nuget.org/packages/VisioForge.CrossPlatform.AlliedVision.Windows.x64/) |

[Browse all VisioForge NuGet packages](https://www.nuget.org/packages?q=visioforge)

## Supported Frameworks

- .NET Framework 4.7.2, 4.8
- .NET 5, 6, 7, 8, 9, 10
- .NET Core 3.1

## Supported Platforms

- **Windows**: x64, x86 (WPF, WinForms, Console, WinUI, Blazor)
- **Linux**: x64 (Ubuntu, Debian, and other distributions)
- **macOS**: x64, ARM64
- **Android**: ARM64, x86_64
- **iOS**: ARM64
- **Mac Catalyst**

## System Requirements

- **Operating System**: Windows 7 SP1 or later, Linux (various distributions), macOS 10.13+
- **Development**: Visual Studio 2019+, Visual Studio Code, or JetBrains Rider
- **Runtime**: Appropriate .NET runtime for your target framework

## Product Pages

- [Video Capture SDK .Net](https://www.visioforge.com/video-capture-sdk-net)
- [Video Edit SDK .Net](https://www.visioforge.com/video-edit-sdk-net)
- [Media Player SDK .Net](https://www.visioforge.com/media-player-sdk-net)
- [Media Blocks SDK .Net](https://www.visioforge.com/media-blocks-sdk-net)

## Documentation & Support

- [Online Documentation](https://www.visioforge.com/help/docs/dotnet/)
- [API Reference](https://www.visioforge.com/help/docs/dotnet/)
- [Support Portal](https://visioforge.com/support/)
- [Changelog](./changelog.md)

## Resources

- [Website](https://visioforge.com/)
- [Twitter](https://twitter.com/VisioForge)

## License

See [LICENSE](LICENSE) file for license information. Commercial licenses are required for most use cases. Visit the [VisioForge website](https://visioforge.com/) for licensing details.
