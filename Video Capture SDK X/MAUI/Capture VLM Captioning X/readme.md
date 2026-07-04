# Video Capture SDK X .Net — Capture VLM Captioning X (C#/MAUI)

Previews a camera with **VideoCaptureCoreX** and inserts a **Florence-2 VLM captioning** block into the
capture pipeline through the X-engine processing-block API:

```csharp
var vlm = new VLMBlock(new VLMSettings(modelsFolder)
{
    Task = VLMTask.Caption,
    DrawResults = true,       // captions / region boxes are drawn straight into the preview frame
});
vlm.OnResultGenerated += (s, e) => { /* e.Task, e.Text, e.Regions, e.InferenceTimeMs */ };

core.Video_Source = videoSourceSettings;
core.Video_Processing_AddBlock(vlm);   // add BEFORE StartAsync
await core.StartAsync();
```

The engine owns and disposes the inserted block when capture stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Tap **DOWNLOAD** once to fetch the Florence-2 ONNX models (~500 MB, cached locally).
2. Pick a **VLM task** (Caption, Detailed Caption, Phrase Grounding, etc.). The text box is enabled only
   for Phrase Grounding.
3. Tap **CAMERA** to choose a device.
4. Tap **START** — the latest caption is shown below the preview; results are also drawn into the frame.

Florence-2 runs on CPU here, so expect seconds per frame. Targets Android, iOS, Mac Catalyst and Windows.
Models are not bundled — download them on first run.
