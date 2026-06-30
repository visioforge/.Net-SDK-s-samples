# Media Player SDK X .Net — Player Live Subtitles X (C#/WPF)

Plays a media file with **MediaPlayerCoreX** and inserts a **Whisper speech-to-text block** into the
audio pipeline through the X-engine processing-block API. The block taps the decoded audio (audio output
goes to a null renderer, so it plays without speaker sound) and raises `OnSpeechRecognized`, shown as a live subtitle:

```csharp
var stt = new SpeechToTextBlock(new SpeechToTextSettings(modelPath)
{
    Language = "en",
    Provider = OnnxExecutionProvider.CPU,
    EnableVad = false,
});
stt.OnSpeechRecognized += (s, e) => { /* e.Segments[].Text */ };

// The audio chain (and the inserted block) is only built when audio playback is active,
// so assign an output device and keep Audio_Play = true.
player.Audio_OutputDevice = new AudioRendererSettings((await player.Audio_OutputDevicesAsync())[0]);
player.Audio_Play = true;
player.Audio_Processing_AddBlock(stt);        // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Pick a media file with speech with the `...` button.
2. Pick a Whisper GGML `.bin` model (e.g. `ggml-base.bin`).
3. Click **Start** — recognized text appears as a subtitle over the video and in the transcript log.

Windows / WPF (`net10.0-windows`). Models are not bundled — pick one with the file picker.
