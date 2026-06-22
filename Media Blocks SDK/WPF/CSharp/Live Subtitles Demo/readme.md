# Live Subtitles Demo (WPF)

Real-time, on-device speech-to-text with the Media Blocks SDK .Net. Audio is transcribed live with
**Whisper** (via Whisper.net / GGML), gated by **Silero VAD** so silence is skipped, and the recognized
text is rendered as a subtitle overlay on the video and optionally written to a `.srt` file. No audio leaves
the machine.

## What it shows

- `SpeechToTextBlock` placed in-line on the audio branch (audio passes through unchanged to the renderer).
- `OnSpeechRecognized` driving a live caption overlay (`OverlayManagerBlock` + `SubtitleRenderer`) and a
  scrolling transcript list.
- Optional `.srt` side-car output.
- CPU / CUDA execution and `auto` language detection or a fixed language.

## Models (downloaded at runtime, not shipped)

- **Whisper GGML** weights — use the in-app *Download* button (Tiny / Base / Small) or *Browse* to a local
  `ggml-*.bin`. Downloaded via Whisper.net's model downloader and cached under
  `%USERPROFILE%/VisioForge/models`.
- **Silero VAD** (`silero_vad.onnx`) — *Download* fetches the official MIT model, or *Browse* to a local copy.

All four components (Whisper.net, whisper.cpp, the Whisper GGML weights, Silero VAD) are MIT-licensed.

## Usage

1. Choose a source: a webcam + microphone, or a media file (video + audio).
2. On the **Models** tab, download or browse to a Whisper model and the Silero VAD model.
3. (Optional) On **Options**, set the language, task (transcribe / translate), provider, and SRT output.
4. Click **Start**. Captions appear on the video with a short delay; the transcript list fills in.

> Tip: a CPU runs Tiny/Base in real time. For Small/Medium, use a CUDA GPU. Whisper.net selects its native
> runtime automatically from the referenced runtime packages and the available hardware.
