# Media Player SDK X .Net — Player Live Subtitles X (C#/WPF)

Plays a media file with **MediaPlayerCoreX** and inserts a **Whisper speech-to-text block** into the
audio pipeline through the X-engine processing-block API. The block taps the decoded audio and raises
`OnSpeechRecognized`; the recognized segments go into a `CaptionTimeline`, and a 200 ms `DispatcherTimer`
asks it which caption belongs on screen at the current playback position — so a caption is revealed when
playback reaches it, not the moment Whisper returned it.

```csharp
var stt = new SpeechToTextBlock(new SpeechToTextSettings(modelPath)
{
    Language = "en",
    Provider = OnnxExecutionProvider.CPU,
    EnableVad = false,
});
stt.OnSpeechRecognized += (s, e) => _captions.Add(e);   // streaming thread, no UI marshalling needed

// The speech-to-text block sits serially in the engine's audio chain, so a real speaker output would
// underrun on a long inference. Audio therefore ends in a null renderer, and IsSync decides the pace.
player.Audio_OutputBlock = new NullRendererBlock(MediaBlockPadMediaType.Audio) { IsSync = realTime };
player.Audio_Play = true;
player.Audio_Processing_AddBlock(stt);        // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();

// lbSubtitle.Text = _captions.TextAt(player.Position_Get());  — on a 200 ms timer
```

## The two modes

* **Real-time playback (default, checked)** — `IsSync = true`. The pipeline is paced at 1x, video plays
  normally and captions appear with the words. There is no speaker output: the audio ends in the null
  renderer, which only supplies the clock.
* **Unchecked** — `IsSync = false`. Maximum-speed offline transcription: the file is consumed as fast as
  Whisper allows and the transcript fills in far quicker than real time. Playback position races ahead,
  so every caption is immediately due and the subtitle keeps up with it.

The engine owns and disposes the inserted block when playback stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Pick a media file with speech with the `...` button.
2. Pick a Whisper GGML `.bin` model (e.g. `ggml-base.bin`).
3. Leave **Real-time playback** checked for 1x playback, or uncheck it to transcribe at full speed.
4. Click **Start** — recognized text appears as a subtitle over the video and in the transcript log.

Windows / WPF (`net10.0-windows`). Models are not bundled — pick one with the file picker.
