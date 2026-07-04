# Media Player SDK X .Net — Player VLM Captioning X (C#/WPF)

Plays a video file with **MediaPlayerCoreX** and inserts a **Florence-2 vision-language captioning**
block into the playback pipeline through the X-engine processing-block API:

```csharp
var settings = new VLMSettings(modelFolder)
{
    Task = VLMTask.Caption,        // caption / detailed caption / object detection / OCR / phrase grounding / ...
    TextInput = "a person",        // only used by PhraseGrounding
    DrawResults = true,            // results are drawn straight into the rendered frame
    ProcessingInterval = TimeSpan.FromSeconds(1.0),
    MaxNewTokens = 256,
};

var vlm = new VLMBlock(settings);
vlm.OnResultGenerated += (s, e) => { /* e.Text, e.Regions, e.Task, e.InferenceTimeMs, e.Timestamp */ };

var source = await UniversalSourceSettings.CreateAsync(filePath, renderVideo: true, renderAudio: false);
player.Video_Processing_AddBlock(vlm);   // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run. The task and phrase
text can be changed live and take effect on the next inference.

## Running

1. Pick a video file with the `...` button.
2. Point the model folder at the Florence-2 assets, or press **Download model files** to fetch them.
3. Choose a task, then click **Start** — captions/regions are drawn over the video and logged in the table.

Windows / WPF (`net10.0-windows`). Florence-2 weights are **not** bundled — they are cached under
`%USERPROFILE%\VisioForge\models\vlm` on first download.
