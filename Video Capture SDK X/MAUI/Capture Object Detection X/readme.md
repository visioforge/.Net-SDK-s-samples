# Video Capture SDK X .Net — Capture Object Detection X (C#/MAUI)

Previews a camera with **VideoCaptureCoreX** and inserts a **YOLO object detector** into the capture
pipeline through the X-engine processing-block API:

```csharp
var detector = new YOLOObjectDetectorBlock(new YoloDetectorSettings(modelPath)
{
    ConfidenceThreshold = 0.25f,
    DrawDetections = true,    // boxes are drawn straight into the preview frame
});
detector.OnObjectsDetected += (s, e) => { /* e.Objects */ };

core.Video_Source = videoSourceSettings;
core.Video_Processing_AddBlock(detector);   // add BEFORE StartAsync
await core.StartAsync();
```

The engine owns and disposes the inserted block when capture stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Tap **MODEL** and pick a YOLO `.onnx` model.
2. Tap **CAMERA** to choose a device (the second camera is preselected on mobile).
3. Tap **START** — live boxes are drawn over the camera preview.

Targets Android, iOS, Mac Catalyst and Windows. Models are not bundled — pick one with the file picker.
