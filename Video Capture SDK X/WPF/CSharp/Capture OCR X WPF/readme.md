# Video Capture SDK X .Net — Capture OCR X (C#/WPF)

Previews a camera with **VideoCaptureCoreX** and inserts a **PaddleOCR text recognizer** into the live
pipeline through the X-engine processing-block API:

```csharp
var ocr = new OcrBlock(new OcrSettings(detModelPath, recModelPath, dictPath, clsModelPath)
{
    DrawResults = true,    // recognized text is drawn straight into the preview frame
});
ocr.OnTextDetected += (s, e) => { /* e.Regions[].Text / .Confidence */ };

core.Video_Source = new VideoCaptureDeviceSourceSettings(device) { Format = format };
core.Video_Processing_AddBlock(ocr);   // add BEFORE StartAsync
await core.StartAsync();
```

The engine owns and disposes the inserted block when capture stops, so the app only detaches its event
handler and drops the reference; a fresh block is created for the next run.

## Running

1. Pick a camera from the drop-down.
2. The Apache-2.0 PP-OCRv5 mobile models (detection, angle classifier, recognition) and the Latin
   dictionary ship next to the executable and are pre-filled. Browse for your own models if needed.
3. Click **Start** and point the camera at some text — recognized text is drawn over the preview and
   each region is logged.

Windows / WPF (`net10.0-windows`).
