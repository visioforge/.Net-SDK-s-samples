# Video Capture SDK X .Net — Capture Face Recognition X (C#/MAUI)

Previews a camera with **VideoCaptureCoreX** and inserts a deep-learning **face recognizer** into the
capture pipeline through the X-engine processing-block API. The recognizer matches each detected face 1:N
against an enrolled gallery and draws labelled boxes straight into the preview:

```csharp
var face = new FaceRecognitionBlock(new FaceRecognitionSettings(detModelPath, embModelPath)
{
    Gallery = gallery,                 // the shared, enrolled gallery
    EmbeddingModel = FaceEmbeddingModel.SFace,
    DrawResults = true,                // labelled boxes drawn into the preview frame
    DetectionConfidenceThreshold = 0.6f,
    RecognitionThreshold = 0.36f,
});
face.OnFacesIdentified += (s, e) => { /* e.Faces -> Identity / Similarity */ };

core.Video_Source = videoSourceSettings;
core.Video_Processing_AddBlock(face);   // add BEFORE StartAsync
await core.StartAsync();
```

The engine owns and disposes the inserted block when capture stops, so the app only detaches its event
handler and drops the reference; a fresh block is created for the next run. A second, app-owned
`FaceRecognitionBlock` is used to compute embeddings during enrollment and is disposed on cleanup.

## Models

A two-stage pipeline is used: **YuNet** face detector (MIT) plus an **SFace** (128-D, Apache-2.0) or
**AuraFace / ArcFace** (512-D, Apache-2.0) embedder. Weights are **not shipped** with the SDK — tap
**Download models** to fetch them into the app-data directory.

## Running

1. Tap **Download models** to fetch the detector + embedder.
2. Type a person name, tap **Enroll photo(s)**, and pick one or more clear, front-facing photos of them.
   Repeat for each person. **Save**/**Load** persists the gallery to app data.
3. Tap **CAMERA** to choose a device, then **START** — recognized faces are labelled over the preview.

Targets Android, iOS, Mac Catalyst and Windows.
