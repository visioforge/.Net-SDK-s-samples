# Live Subtitles (console)

Minimal console sample for the `SpeechToTextBlock` (Whisper ASR + Silero VAD). On first run it downloads the
Whisper GGML model and the Silero VAD model into `%USERPROFILE%\VisioForge\models` (if not already cached), then
transcribes a media file and prints the recognized text with timestamps.

## Usage

```
LiveSubtitles <media-file> [language] [--realtime]
```

- `<media-file>` — any video/audio file (mp4, mkv, wav, mp3, m4a, ...).
- `[language]` — ISO 639-1 code (`en`, `es`, ...) or `auto` (default).
- `--realtime` — play the file at 1x through the speakers and print each caption when playback reaches it. Off by
  default: this sample is a speed harness, so it transcribes as fast as Whisper allows and reports `speed=...x`
  (which reads ~1x with `--realtime`, as expected). In real-time mode the transcriber sits behind a 10-second
  queue that absorbs an inference burst; the queue is deliberately not leaky, so a machine that cannot keep up
  stutters the playback rather than dropping audio and shifting every later caption out of step.

The models are not shipped with the SDK; they are downloaded once and reused. Whisper runs on CUDA when available,
otherwise CPU. Press Enter to stop early; otherwise the app stops when the file finishes playing.

## Platforms

Windows and Linux only. Whisper.net declares its P/Invokes against `__Internal`, which requires static whisper.cpp
archives; `Whisper.net.Runtime` ships those for iOS/MacCatalyst/tvOS but not for macOS, so a `net10.0-macos` build
cannot link and the sample does not declare that target.
