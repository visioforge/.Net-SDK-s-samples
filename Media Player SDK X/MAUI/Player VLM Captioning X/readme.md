# Media Player SDK X .Net — Player VLM Captioning X (C#/MAUI)

Plays a media file with **MediaPlayerCoreX** and inserts a **Florence-2 vision-language model (VLM)**
into the playback pipeline through the X-engine processing-block API. The VLM captions frames, detects
objects, reads text (OCR), or grounds phrases — selected by `VLMTask`:

```csharp
var vlm = new VLMBlock(new VLMSettings(modelFolder)
{
    Task = VLMTask.Caption,          // Caption / DetailedCaption / OCR / ObjectDetection / PhraseGrounding / ...
    TextInput = null,                // only used by the Phrase Grounding task
    DrawResults = true,              // caption bar + region boxes are drawn into the rendered frame
    ProcessingInterval = TimeSpan.FromSeconds(1),
    MaxNewTokens = 256,
});
vlm.OnResultGenerated += (s, e) => { /* e.Text, e.Task, e.Regions, e.InferenceTimeMs */ };

player.Video_Processing_AddBlock(vlm);   // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Tap **DOWNLOAD** to fetch the seven Florence-2 model files (~500 MB, one time; cached in app data).
2. Pick a **VLM task** from the picker. For **Phrase Grounding**, type the caption to ground in the text box.
3. Tap **OPEN FILE** and pick a video.
4. Tap **START** — the caption / recognized text and inference time appear below the video, and results
   are drawn over the frame.

Florence-2 runs on the CPU only; expect seconds per frame. Targets Android, iOS, Mac Catalyst and Windows.
Models are not bundled — download them in-app.
