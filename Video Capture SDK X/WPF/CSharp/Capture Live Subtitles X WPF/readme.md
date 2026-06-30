# Video Capture SDK X .Net — Capture Live Subtitles X (C#/WPF)

Previews a live camera with **VideoCaptureCoreX** and inserts a **Whisper speech-to-text block** into
the audio pipeline through the X-engine processing-block API. The block taps the live microphone audio
(passing it through unchanged) and raises `OnSpeechRecognized`, shown as a live subtitle over the preview:

```csharp
var stt = new SpeechToTextBlock(new SpeechToTextSettings(modelPath)
{
    Language = "en",
    Provider = OnnxExecutionProvider.CPU,
    EnableVad = false,
});
stt.OnSpeechRecognized += (s, e) => { /* e.Segments[].Text */ };

core.Video_Source = new VideoCaptureDeviceSourceSettings(camera) { Format = format };
core.Audio_Source = mic.CreateSourceSettingsVC(mic.GetDefaultFormat());
core.Audio_OutputBlock = new NullRendererBlock(MediaBlockPadMediaType.Audio) { IsSync = false }; // builds the audio chain, no speaker output
core.Audio_Processing_AddBlock(stt);          // add BEFORE StartAsync
await core.StartAsync();
```

The engine owns and disposes the inserted block when capture stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Select a **camera** and a **microphone** from the drop-downs.
2. Pick a Whisper GGML `.bin` model (e.g. `ggml-base.bin`).
3. Click **Start** — recognized speech appears as a subtitle over the preview and in the transcript log.

Windows / WPF (`net10.0-windows`). Models are not bundled — pick one with the file picker.
