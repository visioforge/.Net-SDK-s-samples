# Video Capture SDK .Net - Snapshot Sample (VB.NET/WinForms)

This application demonstrates how to capture snapshots from a camera using the Video Capture SDK .Net.

## Features

- Camera selection and configuration
- Video preview with configurable resolution (default: 1280x720 at 25 fps)
- Take snapshots from the live video feed
- Display captured snapshots in a PictureBox

## Key Implementation

The sample uses `VideoCaptureCore` with the following key settings:

- `Video_Still_Frames_Grabber_Enabled = True` - Enables frame grabbing
- `Frame_GetCurrent()` - Captures the current frame as a Bitmap
- Audio is disabled for this preview-only sample

## Supported frameworks

* .Net 4.7.2
* .Net Core 3.1
* .Net 5
* .Net 6
* .Net 7
* .Net 8
* .Net 9

---

[Visit the product page.](https://www.visioforge.com/video-capture-sdk-net)
