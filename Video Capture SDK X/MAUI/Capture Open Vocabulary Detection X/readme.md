# Video Capture SDK X .Net — Capture Open Vocabulary Detection X (C#/MAUI)

Previews a camera with **VideoCaptureCoreX** and inserts an **open-vocabulary detector**
(**OWLv2** / **Grounding DINO**) into the capture pipeline through the X-engine processing-block API.
Unlike a fixed-class YOLO model, an open-vocabulary detector finds whatever you describe in plain
text, so the prompts can be edited while capture runs:

```csharp
var settings = new OpenVocabularyDetectorSettings(modelPath, vocabPath, mergesPath, prompts)
{
    Model = OpenVocabularyModel.OWLv2,   // or OpenVocabularyModel.GroundingDINO
    DrawDetections = true,               // boxes are drawn straight into the preview frame
};

var detector = new OpenVocabularyDetectorBlock(settings);
detector.OnObjectsDetected += (s, e) => { /* e.Objects */ };

core.Video_Source = videoSourceSettings;
core.Video_Processing_AddBlock(detector);   // add BEFORE StartAsync
await core.StartAsync();

detector.SetPrompts(new[] { "a person", "a red car" });   // change prompts live
```

The engine owns and disposes the inserted block when capture stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Models

Weights are **not** bundled. Each model is a *set* of files downloaded on demand into
`FileSystem.AppDataDirectory/models/openvocab`:

| Model                  | Files                                                            |
|------------------------|------------------------------------------------------------------|
| OWLv2 (base, ensemble) | `owlv2-base-ensemble.onnx`, `owlv2-vocab.json`, `owlv2-merges.txt` |
| Grounding DINO (tiny)  | `grounding-dino-tiny.onnx`, `bert-vocab.txt`                     |

## Running

1. Pick a model in the picker and tap **DOWNLOAD** (one-time; a progress bar tracks each file).
2. Type comma-separated prompts (e.g. `a person, a car, a dog`) and tap **APPLY** to change them live.
3. Tap **CAMERA** to choose a device (cycles through the available cameras).
4. Tap **START** — live boxes for the matching prompts are drawn over the camera preview.

Targets Android, iOS, Mac Catalyst and Windows.
