# MediaBlocks DataMatrix Detection Demo

A WPF application demonstrating real-time DataMatrix 2D barcode detection using the VisioForge Media Blocks SDK with LibDMTX integration.

## Features

- Real-time DataMatrix detection from multiple sources:
  - Web cameras
  - Video files
  - Screen capture
- Advanced DataMatrix-specific features:
  - Symbol size detection (rows x columns)
  - Corner position tracking
  - Frame-level timestamps
  - Configurable frame skip for performance optimization
  - Adjustable decode timeout
  - Multi-code detection support
- Live video preview with DataMatrix overlay
- Detection history with comprehensive metadata
- Debug logging support
- Performance optimization controls

## Requirements

- .NET 4.7.2 or later
- VisioForge Media Blocks SDK

## DataMatrix Settings

### Frame Skip
Controls how many frames to skip between processing (0 = process every frame, higher values reduce CPU usage)

### Decode Timeout
Maximum time in milliseconds to spend decoding each frame (100-2000ms range)

### Max Codes
Maximum number of DataMatrix codes to detect in a single frame

### Debug Logging
Enable detailed logging for troubleshooting detection issues

## Usage

1. Select a video source:
   - Choose from available cameras in the dropdown
   - Select video format and frame rate
2. Configure DataMatrix detection settings:
   - Adjust Frame Skip for performance vs. accuracy trade-off
   - Set Decode Timeout based on expected code complexity
   - Configure Max Codes if expecting multiple codes per frame
3. Click "Start" to begin scanning
4. Detected DataMatrix codes appear in the list with:
   - Symbol dimensions (rows x columns)
   - Decoded text value
   - Detection timestamp and frame number
   - Corner positions in the image
5. Click "Stop" to end scanning
6. Use "Clear DataMatrix Codes" to reset the detection list

## Implementation Details

The demo uses:
- `DataMatrixDecoderBlock` for DataMatrix detection using LibDMTX
- `VideoRendererBlock` for video preview
- `SystemVideoSourceBlock` for camera input
- Asynchronous frame processing to maintain smooth video playback
- Configurable performance optimization parameters

## Performance Optimization

- **Frame Skip**: Increase to reduce CPU usage by processing fewer frames
- **Timeout**: Lower values prevent the decoder from spending too much time on difficult images
- **Video Format**: Use lower resolutions for faster processing
- **Frame Rate**: Lower frame rates reduce processing load

## Common Use Cases

- Industrial tracking systems
- Document processing with embedded DataMatrix codes
- Inventory management
- Quality control and verification
- Medical device tracking
- Pharmaceutical product authentication

## Notes

- DataMatrix detection requires proper lighting and camera focus
- Square DataMatrix codes are typically easier to detect than rectangular ones
- The decoder can handle various DataMatrix sizes from 10x10 to 144x144
- Enable debug logging to troubleshoot detection issues
- Maximum 100 detections are kept in history (oldest removed automatically)