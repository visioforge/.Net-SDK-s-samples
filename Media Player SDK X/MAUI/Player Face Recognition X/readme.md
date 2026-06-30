# Media Player SDK X .Net — Player Face Recognition X (C#/MAUI)

Plays a media file with **MediaPlayerCoreX** and inserts a deep-learning **face recognizer** into the
playback pipeline through the X-engine processing-block API. The recognizer detects faces with
**YuNet**, embeds each one (**SFace** 128-D or **AuraFace**/ArcFace 512-D), and matches it 1:N against an
enrolled gallery, drawing labelled boxes straight into the rendered frame:

```csharp
var face = new FaceRecognitionBlock(new FaceRecognitionSettings(detectorPath, embeddingPath)
{
    Gallery = gallery,                 // shared enrolled gallery (1:N matching)
    EmbeddingModel = FaceEmbeddingModel.SFace,
    DrawResults = true,                // boxes/labels drawn into the rendered frame
    RecognitionThreshold = 0.36f,
});
face.OnFacesIdentified += (s, e) => { /* e.Faces: Identity + Similarity */ };

player.Video_Processing_AddBlock(face);   // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches its event
handler and drops the reference; a fresh block is created for the next run. A separate, app-owned
recognizer block computes the enrollment embeddings and is disposed on cleanup.

## Running

1. Tap **Download models** to fetch the YuNet detector and the selected embedding model (SFace or
   AuraFace). Weights are not bundled — they download into the app-data folder.
2. Enter a **person name**, tap **Enroll photo(s)**, and pick one or more clear, front-facing photos.
   Repeat for each person. Use **Save** / **Load** to persist the gallery (`faces.vfg`).
3. Tap **OPEN FILE** and pick a video.
4. Tap **START** — labelled boxes are drawn over each face and recognized identities (with similarity)
   are shown.

Targets Android, iOS, Mac Catalyst and Windows. Models and galleries are stored under the app-data
directory.
