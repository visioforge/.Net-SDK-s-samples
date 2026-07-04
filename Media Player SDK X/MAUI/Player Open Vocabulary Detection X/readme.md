# Media Player SDK X .Net — Player Open Vocabulary Detection X (C#/MAUI)

Plays a video file with **MediaPlayerCoreX** and inserts an **open-vocabulary object detector**
(**OWLv2** / **Grounding DINO**) into the playback pipeline through the X-engine processing-block API.
Type free-text prompts (e.g. `a person`, `a red car`) and the model finds matching objects while the
file plays — no fixed class list.

```csharp
var settings = new OpenVocabularyDetectorSettings(modelPath, vocabPath, mergesPath, prompts)
{
    Model = OpenVocabularyModel.GroundingDINO,
    DrawDetections = true,    // boxes are drawn straight into the rendered frame
};
var detector = new OpenVocabularyDetectorBlock(settings);
detector.OnObjectsDetected += (s, e) => { /* e.Objects */ };

player.Video_Processing_AddBlock(detector);   // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();

// Prompts can be changed live while the file plays:
detector.SetPrompts(new[] { "a dog", "a bicycle" });
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Pick a model (OWLv2 or Grounding DINO) and tap **DOWNLOAD** — the model file set is cached under the
   app data directory (`models/openvocab`). Weights are NOT shipped with the SDK.
2. Type the free-text prompts to detect and tap **APPLY**.
3. Tap **OPEN FILE** and pick a video.
4. Tap **START** — bounding boxes are drawn over the video and the most confident detection is shown.

Targets Android, iOS, Mac Catalyst and Windows.
