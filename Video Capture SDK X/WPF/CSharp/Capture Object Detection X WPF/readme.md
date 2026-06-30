# Video Capture SDK X .Net — Capture Object Detection X (C#/WPF)

Previews a live camera with **VideoCaptureCoreX** and inserts a **YOLO object detector** into the
capture pipeline through the X-engine processing-block API:

```csharp
var detector = new YOLOObjectDetectorBlock(new YoloDetectorSettings(modelPath)
{
    ConfidenceThreshold = 0.25f,
    DrawDetections = true,    // boxes are drawn straight into the preview frame
});
detector.OnObjectsDetected += (s, e) => { /* e.Objects */ };

core.Video_Source = new VideoCaptureDeviceSourceSettings(device) { Format = format };
core.Video_Processing_AddBlock(detector);     // add BEFORE StartAsync
await core.StartAsync();
```

The engine owns and disposes the inserted block when capture stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Select a **camera** from the drop-down.
2. Pick a YOLO `.onnx` model (e.g. YOLOX / YOLOv8 / RT-DETR).
3. Click **Start** — bounding boxes are drawn over the live preview and each detection is logged.

Windows / WPF (`net10.0-windows`). Models are not bundled — pick one with the file picker.
