# Live Subtitles (console)

Minimal console sample for the `SpeechToTextBlock` (Whisper ASR + Silero VAD). On first run it downloads the
Whisper GGML model and the Silero VAD model into `%USERPROFILE%\VisioForge\models` (if not already cached), then
transcribes a media file and prints the recognized text with timestamps.

## Usage

```
LiveSubtitles <media-file> [language]
```

- `<media-file>` — any video/audio file (mp4, mkv, wav, mp3, m4a, ...).
- `[language]` — ISO 639-1 code (`en`, `es`, ...) or `auto` (default).

The models are not shipped with the SDK; they are downloaded once and reused. Whisper runs on CUDA when available,
otherwise CPU. Press Enter to stop early; otherwise the app stops when the file finishes playing.
