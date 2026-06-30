# Media Player SDK X .Net — Player Face Recognition X (C#/WPF)

Plays a media file with **MediaPlayerCoreX** and inserts a **deep-learning face recognizer** into the
playback pipeline through the X-engine processing-block API. Faces are matched 1:N against an enrolled
gallery (YuNet detector + SFace/ArcFace embedding):

```csharp
var face = new FaceRecognitionBlock(new FaceRecognitionSettings(detModelPath, embModelPath)
{
    Gallery = gallery,           // names enrolled from photos
    EmbeddingModel = FaceEmbeddingModel.SFace,
    DrawResults = true,          // labelled boxes are drawn straight into the rendered frame
});
face.OnFacesIdentified += (s, e) => { /* e.Faces[].Identity / .Similarity */ };

var source = await UniversalSourceSettings.CreateAsync(filePath, renderVideo: true, renderAudio: false);
player.Video_Processing_AddBlock(face);   // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches its event
handler and drops the reference; a fresh block is created for the next run. A separate, app-owned
recognizer instance is used only to compute embeddings during enrollment (never added to the engine).

## Running

1. On the **Models** tab, download (or browse for) the YuNet detector and an SFace/AuraFace embedding model.
2. On the **Enrollment** tab, type a name and pick one or more clear, front-facing photos of that person.
3. On the **Source** tab, pick a media file containing those people.
4. Click **Start** — recognized faces are boxed and labelled on the video, with each match logged on the
   **Faces** tab. Unknown faces are boxed as `Unknown`.

Models are cached under `%USERPROFILE%/VisioForge/models` and are **not** shipped with the SDK.
Windows / WPF (`net10.0-windows`).
