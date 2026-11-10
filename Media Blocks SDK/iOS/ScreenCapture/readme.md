# Media Blocks SDK .Net - ScreenCapture (C#/iOS)

This application captures system audio output, captures desktop/screen content, saves output to MP4 format, splits video stream for multiple outputs.

## Used media blocks

* `ScreenSourceBlock` - Screen capture
* `H264EncoderBlock` - H.264/AVC video encoding
* `MP4SinkBlock` - MP4 file output
* `TeeBlock` - Stream splitting
* `VideoRendererBlock` - Real-time video display

## Pipeline

```mermaid
graph LR
    ScreenSourceBlock --> TeeBlock
    TeeBlock -- preview --> VideoRendererBlock
    TeeBlock -- record --> H264EncoderBlock
    H264EncoderBlock --> MP4SinkBlock
```

## Running on your device

The demo runs on a real iPhone or iPad only: the screen is captured by the `ScreenCaptureExtension` broadcast extension, which the simulator does not run. To sign it with your own team, change these identifiers together:

* the bundle IDs `com.visioforge.screencapture` (`ScreenCapture/Info.plist`) and `com.visioforge.screencapture.extension` (`ScreenCaptureExtension/Info.plist`, `ExtensionBundleId` in `AppDelegate.cs`); the extension ID must start with the app ID;
* the App Group `group.com.visioforge.screencapture` in both `Entitlements.plist` files and `AppGroupId` in `AppDelegate.cs` and `SampleHandler.cs`. The app and the extension exchange frames through this group, so all four must match.

## Supported frameworks

* .Net 4.7.2
* .Net Core 3.1
* .Net 5
* .Net 6
* .Net 7
* .Net 8
* .Net 9
* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk)
