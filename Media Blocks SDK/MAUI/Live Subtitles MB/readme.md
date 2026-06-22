# VisioForge Media Blocks SDK .NET

## Live Subtitles Demo (MAUI)

This cross-platform MAUI application transcribes the audio of a media file into subtitles
**fully on-device** using OpenAI Whisper (Whisper.net / GGML) with Silero VAD voice-activity
detection. No camera and no cloud service are used — audio never leaves the device.

## Features

- **On-device speech-to-text**: Whisper runs locally; nothing is sent to a server.
- **Silero VAD**: voice-activity detection trims silence so only speech is transcribed.
- **Auto language detection**: Whisper detects the spoken language automatically.
- **Cross-platform**: Windows, Android, iOS, and macOS (Mac Catalyst).
- **Live subtitle log**: recognized lines accumulate as `[mm:ss] text` in a scrollable area.

## Models

No model files are bundled. On the first run the app downloads:

- **Whisper base GGML model** (~150 MB) via `WhisperGgmlDownloader`.
- **Silero VAD** ONNX model (MIT) from the official repository.

Both are cached under the app data directory and reused on subsequent runs. The first
transcription therefore takes longer while the Whisper model downloads.

## How to Use

1. Launch the app.
2. Tap **PICK FILE & TRANSCRIBE**. On the first run the model downloads (status shows progress).
3. Pick any media file with an audio track (mp4 / mkv / wav / mp3 / m4a / ...).
4. Watch recognized subtitle lines appear in the scrollable area.
5. The pipeline stops automatically when the file ends, or tap **STOP** to stop early.

If the chosen file has no audio track, or the model download fails, the app shows an alert.

## Implementation Details

### Pipeline Architecture

```
[UniversalSourceBlock (audio)] → [SpeechToTextBlock] → [AudioRendererBlock]
```

- **UniversalSourceBlock**: decodes the picked file, audio-only (`renderVideo: false`).
- **SpeechToTextBlock**: transcribes speech with Whisper + Silero VAD on a worker thread,
  raising `OnSpeechRecognized` for each recognized segment.
- **AudioRendererBlock**: terminates the audio branch.

### Settings

```csharp
var settings = new SpeechToTextSettings(whisperModelPath)
{
    Language = "auto",
    Provider = OnnxExecutionProvider.Auto, // GPU when available, else CPU
    EnableVad = true,
};
settings.Vad.ModelPath = sileroModelPath;
```

`OnSpeechRecognized` is raised on a worker thread, so the demo marshals UI updates with
`Dispatcher.Dispatch`.

## Platform-Specific Notes

### Android

- The file picker handles storage access; no extra runtime permission is needed for picking.
- The base model download (~150 MB) needs network access and storage space.

### iOS / macOS

- The Mono interpreter is enabled (`UseInterpreter`) so Whisper.net's model downloader works
  under AOT.
- Allow the first-run model download to complete before transcribing.

### Windows

- No special permissions required.
- GPU execution is used automatically when available, otherwise CPU.

## Building and Running

```bash
# Windows
dotnet build -f net10.0-windows10.0.19041.0

# Android
dotnet build -f net10.0-android

# iOS
dotnet build -f net10.0-ios

# macOS (Mac Catalyst)
dotnet build -f net10.0-maccatalyst
```

## Pipeline

```mermaid
graph LR
    UniversalSourceBlock -- audio --> SpeechToTextBlock
    SpeechToTextBlock -- audio --> AudioRendererBlock
```

## Supported Frameworks

- .NET 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk)
