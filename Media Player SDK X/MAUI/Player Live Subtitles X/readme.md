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

// The block sits serially in the audio chain, so a speaker output would underrun while Whisper
// runs: audio ends in a null renderer. Synced paces the pipeline at 1x for real-time playback,
// unsynced lets it run as fast as Whisper can transcribe.
player.Audio_OutputBlock = new NullRendererBlock(MediaBlockPadMediaType.Audio) { IsSync = realTime };

player.Audio_Processing_AddBlock(stt);   // add BEFORE OpenAsync/PlayAsync
player.Audio_Play = true;                // the audio chain (and the block) builds only when audio is active
await player.OpenAsync(source);
await player.PlayAsync();
```

The block taps the audio for transcription; audio output goes to a null renderer, so the file plays without speaker sound.
Recognized segments are buffered in a `CaptionTimeline` and the subtitle label is filled from `player.Position_Get()`
on a 200 ms timer, so a caption appears when playback reaches it rather than when Whisper finishes it.
The engine owns and disposes the block when playback stops; the app only detaches its handler.

## Running

1. Tap **MODEL** and pick a Whisper GGML model (`ggml-*.bin`, e.g. `ggml-base.bin`).
2. Tap **OPEN FILE** and pick a media file with speech.
3. Leave **Real-time playback** on to watch the file at 1x with captions in step; switch it off to transcribe as fast as the machine allows.
4. Tap **START** — the recognized text appears as a subtitle at the bottom of the video.

Targets Android, iOS, Mac Catalyst and Windows. Models are not bundled — pick one with the file picker.
