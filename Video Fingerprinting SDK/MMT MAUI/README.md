# MMT MAUI - Media Monitoring Tool (MAUI Version)

## Overview
This is a MAUI (Multi-platform App UI) version of the VisioForge Video Fingerprinting SDK Media Monitoring Tool (MMT), ported from the original WPF application.

## Features
- **Cross-platform support**: Windows and macOS
- **Video fingerprinting**: Generate and compare video fingerprints
- **Ad detection**: Detect advertisements in broadcast videos
- **Database management**: Cache fingerprints for faster processing
- **Ignored areas**: Define regions to exclude from fingerprinting
- **CSV export**: Export results to CSV format

## Building the Project

### Prerequisites
- Visual Studio 2022 with .NET MAUI workload
- .NET 8.0 SDK
- Windows 10 SDK (for Windows builds)
- Xcode (for macOS builds)

### Build Instructions

#### Using Visual Studio
1. Open `MMT_MAUI.csproj` in Visual Studio 2022
2. Select your target platform (Windows or macOS)
3. Build and run the project

#### Command Line (may require Visual Studio installation)
```bash
# Windows build
msbuild MMT_MAUI.csproj /t:Build /p:Configuration=Debug /p:TargetFramework=net8.0-windows10.0.19041.0

# macOS build
msbuild MMT_MAUI.csproj /t:Build /p:Configuration=Debug /p:TargetFramework=net8.0-maccatalyst
```

## Usage

### Adding Video Files
1. **Broadcast Dump Tab**: Add broadcast video files or folders to analyze
2. **Ad Samples Tab**: Add advertisement samples to search for

### Configuration
1. **Settings Tab**: Adjust the difference level for fingerprint matching sensitivity
2. **Ignored Areas Tab**: Define rectangular areas to exclude from fingerprinting (e.g., logos, watermarks)

### Running Analysis
1. Add broadcast videos and ad samples
2. Click "Start" to begin the fingerprinting and analysis process
3. Results will be displayed in the right panel showing:
   - Ad file name
   - Position (timestamp) in the broadcast
   - Broadcast file name

### Exporting Results
Click "Save results" to export the findings to a CSV file for further analysis.

## Known Limitations
- Video playback functionality is simplified (shows file path instead of playing)
- Folder selection uses a workaround (select any file in the folder)
- XML export is not implemented in the MAUI version

## Technical Details
- Uses VisioForge Video Fingerprinting SDK for core functionality
- Implements MediaBlocks architecture for media processing
- Cross-platform UI built with .NET MAUI

## Project Structure
- `MainPage.xaml/cs` - Main UI and business logic
- `Settings.cs` - Application settings management
- `ResultsViewModel.cs` - Data model for results display
- `FileScanner.cs` - Video file discovery
- `CsvSerializer.cs` - CSV export functionality

## Dependencies
- VisioForge.Core
- VisioForge.Core.UI.MAUI
- VisioForge.Libs
- Microsoft.Maui.Controls
- VisioForge.CrossPlatform.Core (platform-specific packages)