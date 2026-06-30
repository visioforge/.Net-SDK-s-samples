# Media Player SDK X .Net — Player Object Detection X (C#/MAUI)

Plays a media file with **MediaPlayerCoreX** and inserts a **YOLO object detector** into the
playback pipeline through the X-engine processing-block API:

```csharp
var detector = new YOLOObjectDetectorBlock(new YoloDetectorSettings(modelPath)
{
    ConfidenceThreshold = 0.25f,
    DrawDetections = true,    // boxes are drawn straight into the rendered frame
});
detector.OnObjectsDetected += (s, e) => { /* e.Objects */ };

player.Video_Processing_AddBlock(detector);   // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Tap **MODEL** and pick a YOLO `.onnx` model (e.g. YOLOX / YOLOv8 / RT-DETR).
2. Tap **OPEN FILE** and pick a video.
3. Tap **START** — bounding boxes are drawn over the video and the most confident detection is shown.

Targets Android, iOS, Mac Catalyst and Windows. Models are not bundled — pick one with the file picker.
