# MediaBlocks Barcode Detection Demo

A WPF application demonstrating real-time barcode detection using the VisioForge Media Blocks SDK.

## Features

- Real-time barcode detection from multiple sources:
  - Web cameras
  - Video files
  - Screen capture
- Support for various barcode formats:
  - QR codes
  - DataMatrix
  - Code128, Code39
  - EAN-13, UPC-A
  - And other standard 1D/2D barcodes
- Live video preview with barcode overlay
- Detection history with timestamps
- Duplicate detection prevention
- Sound notification on detection

## Requirements

- .NET 4.7.2 or later
- Windows x64
- VisioForge Media Blocks SDK

## Usage

1. Select a video source type (Camera, Video File, or Screen)
2. Choose the specific source:
   - For Camera: Select from available cameras
   - For Video File: Click "Select File..." to browse
   - For Screen: Automatically captures primary monitor
3. Click "Start" to begin scanning
4. Detected barcodes appear in the list with:
   - Barcode type (QR Code, EAN-13, etc.)
   - Decoded value
   - Detection timestamp
5. Click "Stop" to end scanning
6. Use "Clear" to reset the detection list

## Implementation Details

The demo uses:
- `BarcodeDetectorBlock` for barcode detection
- `VideoRendererBlock` for video preview
- Various source blocks for input flexibility

## Notes

- The detector prevents duplicate detections within a 2-second window
- Enable/disable sound notifications using the checkbox
- Maximum 100 barcodes are kept in history (oldest removed automatically)