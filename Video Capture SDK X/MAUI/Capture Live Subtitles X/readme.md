# Video Capture SDK X .Net — Capture Live Subtitles X (C#/MAUI)

Previews a camera with **VideoCaptureCoreX** and transcribes the **microphone** by inserting a
**Whisper speech-to-text** block into the audio pipeline through the X-engine processing-block API.
Recognized text is shown as a live subtitle over the preview:

```csharp
var stt = new SpeechToTextBlock(new SpeechToTextSettings(whisperModelPath)
{
    Language = "en",
    Provider = OnnxExecutionProvider.CPU,
    EnableVad = false,
});
stt.OnSpeechRecognized += (s, e) => { /* e.Segments[].Text */ };

core.Video_Source = videoSourceSettings;
core.Audio_Source = micSourceSettings;
core.Audio_OutputBlock = new NullRendererBlock(MediaBlockPadMediaType.Audio) { IsSync = false }; // builds the audio chain, no speaker output
core.Audio_Processing_AddBlock(stt);      // add BEFORE StartAsync
await core.StartAsync();
```

A non-synced null renderer set as `Audio_OutputBlock` builds the audio chain the block is inserted into —
no speaker output and no recording file are needed. The block passes audio through unchanged.
The engine owns and disposes the block when capture stops; the app only detaches its handler.

## Running

1. Tap **MODEL** and pick a Whisper GGML model (`ggml-*.bin`).
2. Tap **CAMERA** and **MIC** to choose devices.
3. Tap **START** and speak — the transcript appears as a subtitle over the preview.

Targets Android, iOS, Mac Catalyst and Windows. Models are not bundled — pick one with the file picker.
