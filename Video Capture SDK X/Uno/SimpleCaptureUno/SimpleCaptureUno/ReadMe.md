# Simple Capture Uno - Video Capture SDK X

This sample demonstrates how to use the VisioForge Video Capture SDK X with Uno Platform for cross-platform video capture applications.

## Features

- Camera preview
- Audio/Video capture to MP4 file
- Camera, microphone, and speaker device selection
- Cross-platform support (Windows, Android, iOS, macOS)

## Requirements

- .NET 10.0
- Uno Platform 6.4+
- VisioForge SDK license for production use

## Building

### Windows

```bash
dotnet build -f net10.0-windows10.0.19041
```

### Android

```bash
dotnet build -f net10.0-android
```

### iOS

```bash
dotnet build -f net10.0-ios
```

### macOS (Mac Catalyst)

```bash
dotnet build -f net10.0-maccatalyst
```

## Usage

1. Launch the application
2. Click the device buttons to cycle through available cameras, microphones, and speakers
3. Click "PREVIEW" to start camera preview
4. Click "CAPTURE" to start recording to MP4 file
5. Click "STOP" (red button) to stop recording
6. Click "STOP" on preview to stop the preview

## Notes

- On mobile platforms (iOS/Android), the preview starts automatically
- Captured videos are saved to platform-specific locations:
  - Windows: My Videos folder
  - Android: App's external files directory (Movies)
  - iOS: Documents/Library folder
  - macOS: /tmp folder
