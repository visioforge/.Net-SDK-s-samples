# Media Player SDK X .Net — Player Open Vocabulary Detection X (C#/WPF)

Plays a video file with **MediaPlayerCoreX** and inserts an **open-vocabulary object detector**
(**OWLv2** / **Grounding DINO**) into the playback pipeline through the X-engine processing-block API.
Type free-text prompts (e.g. `a person`, `a red car`) and the model finds matching objects while the
file plays — no fixed class list.

```csharp
var settings = new OpenVocabularyDetectorSettings(modelPath, vocabPath, mergesPath, prompts)
{
    Model = OpenVocabularyModel.GroundingDINO,
    ConfidenceThreshold = 0.25f,
    DrawDetections = true,    // boxes are drawn straight into the rendered frame
};
var detector = new OpenVocabularyDetectorBlock(settings);
detector.OnObjectsDetected += (s, e) => { /* e.Objects */ };

var source = await UniversalSourceSettings.CreateAsync(filePath, renderVideo: true, renderAudio: false);
player.Video_Processing_AddBlock(detector);   // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();

// Prompts can be changed live while the file plays:
detector.SetPrompts(new[] { "a dog", "a bicycle" });
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Pick a video file on the **Media file** tab.
2. On the **Model** tab choose OWLv2 or Grounding DINO and click **Download model files**
   (weights are cached under `%USERPROFILE%\VisioForge\models\openvocab` — they are NOT shipped with the SDK).
3. On the **Prompts** tab add the free-text prompts you want to detect.
4. Click **Start** — bounding boxes are drawn over the video and each detection is logged.

Windows / WPF (`net10.0-windows`).
