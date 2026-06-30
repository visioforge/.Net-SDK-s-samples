# Media Player SDK X .Net — Player Live Subtitles X (C#/MAUI)

Plays a media file with **MediaPlayerCoreX** and inserts a **Whisper speech-to-text** block into the
audio pipeline through the X-engine processing-block API. Recognized text is shown as a live subtitle:

```csharp
var stt = new SpeechToTextBlock(new SpeechToTextSettings(whisperModelPath)
{
    Language = "en",
    Provider = OnnxExecutionProvider.CPU,
    EnableVad = false,
});
stt.OnSpeechRecognized += (s, e) => { /* e.Segments[].Text */ };

// Route playback to a speaker so the file is still audible. Registering an audio processing
// block also keeps the audio chain alive on its own, so this is optional — without an output
// device the block still runs, but audio is sent to a null renderer instead of the speakers.
var outputs = await player.Audio_OutputDevicesAsync();
if (outputs.Length > 0) player.Audio_OutputDevice = new AudioRendererSettings(outputs[0]);

player.Audio_Processing_AddBlock(stt);   // add BEFORE OpenAsync/PlayAsync
player.Audio_Play = true;                // the audio chain (and the block) builds only when audio is active
await player.OpenAsync(source);
await player.PlayAsync();
```

The block taps the audio for transcription; this demo sends audio output to a null renderer, so the file plays without speaker sound (set `Audio_OutputDevice` as shown above to also hear it).
The engine owns and disposes the block when playback stops; the app only detaches its handler.

## Running

1. Tap **MODEL** and pick a Whisper GGML model (`ggml-*.bin`, e.g. `ggml-base.bin`).
2. Tap **OPEN FILE** and pick a media file with speech.
3. Tap **START** — the recognized text appears as a subtitle at the bottom of the video.

Targets Android, iOS, Mac Catalyst and Windows. Models are not bundled — pick one with the file picker.
