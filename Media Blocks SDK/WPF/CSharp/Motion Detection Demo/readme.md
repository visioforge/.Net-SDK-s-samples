# Media Blocks SDK .Net - Motion Detection Demo (WPF)

This SDK sample demonstrates how to build a motion detection application using the VisioForge Media Blocks SDK .Net with OpenCV in a WPF environment. The application captures video from a webcam and applies real-time motion detection using the CVMotionCellsBlock, which divides the video frame into a grid of cells and detects motion within each cell.

## Features

- Real-time video capture from webcam
- Motion detection using OpenCV CVMotionCellsBlock
- Configurable motion detection parameters:
  - Grid size (columns and rows)
  - Sensitivity threshold
  - Motion cells threshold
- Visual overlay showing detected motion cells
- Motion event logging with timestamps
- Live motion statistics display
- No audio or recording functionality (preview only)

## Used blocks

- [SystemVideoSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemVideoSourceBlock/) - captures video from the webcam
- [CVMotionCellsBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/OpenCV/CVMotionCellsBlock/) - detects motion using OpenCV cell-based analysis
- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video with motion detection overlay

## Motion Detection Parameters

- **Grid X/Y**: Defines the grid resolution for motion detection (4-32 columns, 4-24 rows)
- **Sensitivity**: Controls how sensitive the detector is to motion (0.1-1.0)
- **Motion Cells Threshold**: Minimum percentage of cells that must detect motion (0.01-0.5)
- **Display Motion Overlay**: Shows red overlay on detected motion cells

## Required NuGet Packages

- VisioForge.CrossPlatform.Core.Windows.x64
- VisioForge.CrossPlatform.Libav.Windows.x64.UPX
- VisioForge.CrossPlatform.OpenCV.Windows.x64

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8
- .Net 9

## How to Use

1. Select your webcam from the "Video input device" dropdown
2. Choose the desired video format and frame rate
3. Adjust motion detection parameters in the "Motion Detection" tab
4. Click "Start" to begin motion detection
5. Motion events will be logged in the "Log" tab
6. Motion statistics are displayed at the bottom of the window
7. Click "Stop" to stop the preview

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
