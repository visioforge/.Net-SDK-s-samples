# Video Capture SDK X .Net — Capture OCR X (C#/MAUI)

Previews a camera with **VideoCaptureCoreX** and inserts a **PaddleOCR text recognizer** into the
capture pipeline through the X-engine processing-block API:

```csharp
var settings = new OcrSettings(detModelPath, recModelPath, dictPath, clsModelPath)
{
    DrawResults = true,    // recognized text is drawn straight into the preview frame
    FramesToSkip = 5,
};

var ocr = new OcrBlock(settings);
ocr.OnTextDetected += (s, e) => { /* e.Regions[].Text */ };

core.Video_Source = videoSourceSettings;
core.Video_Processing_AddBlock(ocr);   // add BEFORE StartAsync
await core.StartAsync();
```

The engine owns and disposes the inserted block when capture stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Models

The PP-OCRv5 mobile models (detection, recognition, angle classification) and the Latin character
dictionary ship with the app as `MauiAsset` raw resources under `Resources/Raw`. On first run they
are copied to the app-data directory so ONNX Runtime can open them by path. The models are
PaddleOCR / PaddlePaddle assets distributed under the Apache-2.0 license.

## Running

1. Tap **SELECT CAMERA** to choose a device.
2. Tap **START** — recognized text is drawn over the camera preview and the latest line plus the
   region count are shown in the status bar.

Targets Android, iOS, Mac Catalyst and Windows.
