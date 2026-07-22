---
title: VisioForge .NET SDKs — Changelog and Release Notes
description: Version history for Video Capture, Media Player, Video Edit, and Media Blocks SDKs. New features, bug fixes, API changes, and platform updates.
hide_table_of_contents: true
tags:
  - Video Capture SDK
  - Media Player SDK
  - Media Blocks SDK
  - Video Edit SDK
  - .NET
  - DirectShow
  - Windows
  - Capture
  - Playback
  - Streaming
  - Editing
primary_api_classes:
  - VideoCaptureCore
  - VideoCaptureCoreX
  - VideoView
  - MediaPlayerCoreX
  - DeviceEnumerator
---

# Changelog

Changes and updates for all .Net SDKs.

## 2026.7.22

* [Core] MAUI apps now build cleanly for Android 16: the bundled HarfBuzzSharp native library is updated to a 16 KB page-size-aligned build, removing the `XA0141` ("Android 16 will require 16 KB page sizes") warning on Android app builds.

## 2026.7.21

* [Media Blocks SDK .Net] Added **AMD Alveo MA35D** hardware acceleration (via the AMD AMA Video SDK) on Linux: H.264, HEVC and AV1 encoders (`AMAH264EncoderSettings` / `AMAHEVCEncoderSettings` / `AMAAV1EncoderSettings`), matching decoders, and an `AMAScalerBlock`. A specific MA35D card is selected with the `Device` property (`-1` auto-selects), so you can pin encoding/decoding to the accelerator rather than the host GPU. Requires the AMD AMA Video SDK (kernel driver + GStreamer plugins) to be installed.

## 2026.7.10

* [Media Blocks SDK .Net] Added **`AudioEventDetectorBlock`** — on-device audio event detection that recognizes real-world sounds (siren, dog bark, glass break, alarm, music, speech, and hundreds more from the 521-class AudioSet ontology) in live or file audio using a YAMNet ONNX classifier. Audio passes through unchanged; detections are raised via `OnAudioEvent` with a label, confidence, and start/end time, using score smoothing and hysteresis so one continuous sound is a single event rather than a burst of duplicates. Optional class allowlist and a live top-K scores event. Works in `VideoCaptureCoreX`/`MediaPlayerCoreX` via `Audio_Processing_AddBlock`.
* [Demos] Added an **Audio Event Detection** WPF sample (Media Blocks SDK): open a file or select a microphone, live event log with label/confidence/time, class-filter box, and threshold slider.

## 2026.7.9

* [Core] Video stream info now reports the pixel aspect ratio (`VideoStreamInfo.ParNumerator`/`ParDenominator`) when the negotiated caps carry it, so anamorphic sources can be displayed at the correct proportions.
* [Media Blocks SDK .Net] Fixed pipeline restart after a failed start: blocks no longer report themselves as built when their Build fails, so a retried start rebuilds them instead of running a half-built pipeline.
* [Media Blocks SDK .Net] File output blocks (M4A/MP4/MKV/AVI) now fail cleanly instead of throwing an unhandled exception when configured with an unsupported encoder, so the pipeline reports a normal start error you can handle.
* [Core] Fixed stale frame dimensions after a mid-stream resolution change in video frame grabbing: frame callbacks and snapshots kept reporting the old width/height/stride, so the frame data could be mis-read at the new size.
* [Media Blocks SDK .Net] Added AI auto-reframe (`AutoReframeBlock`): converts landscape footage into vertical 9:16 (or 1:1, 4:5) video that dynamically crops around the detected subject with smooth, jitter-free tracking — ideal for Shorts/Reels/TikTok.
* [Demos] Added an **Auto Reframe** WPF sample (Media Blocks SDK): open a landscape file, follow the subject in a side-by-side original/reframed preview (9:16, 1:1, or 4:5), configure smoothing, dead zone, detection interval, and the followed class, and optionally export the reframed output to MP4.
* [Media Blocks SDK .Net] Added on-device **speaker diarization** ("who spoke when"): the new `SpeakerDiarizationBlock` analyses the audio as it plays and, once the recording has finished, reports every speech turn with the speaker who made it. Diarization is inherently offline — a voice heard at minute 1 can only be matched to the same voice at minute 40 once the whole recording has been heard — so the turns are raised at end-of-stream (`OnSpeakerSegment`, or `GetTimeline()` in one piece); check `IsTimelineComplete` before reading them. Pair it with speech-to-text via `DiarizedTranscriptBuilder` for a speaker-labeled transcript. Works with `MediaPlayerCoreX`/`VideoCaptureCoreX` and manual Media Blocks pipelines. Set `NumSpeakers` when you know the count, or leave it at `-1` and tune `ClusterThreshold` (a cosine distance — smaller yields more speakers).
* [Media Blocks SDK .Net] Speaker diarization is **multilingual**: alongside the default English WeSpeaker voiceprint model you can select the Apache-2.0 3D-Speaker ERes2NetV2 embedding (`SpeakerDiarizationSettings.EmbeddingModel = ERes2NetV2Multilingual`) for far better speaker separation on non-English or mixed-language audio. The feature front-end adapts to the chosen model automatically, so no other code changes are needed when you switch.
* [Media Blocks SDK .Net] Fixed degraded **speech-to-text accuracy on any source that is not already 16 kHz mono** — that is, on essentially every camera, capture card, media file and RTSP stream. The audio front-end decimated to the 16 kHz the model needs without band-limiting first, so everything above 8 kHz folded back into the speech band and corrupted the features both Whisper and the voice-activity detector consume. The audio is now low-pass filtered before the rate conversion.
* [Media Blocks SDK .Net][Video Capture SDK .Net] Added **PTZ auto-tracking** — an ONVIF PTZ camera can now automatically follow a detected object. `PTZAutoTrackingController` turns detections from `ObjectAnalyticsBlock` (or `YOLOObjectDetectorBlock`) into continuous pan/tilt/zoom commands with a configurable dead zone, sticky target tracking, a lost-target timeout (with optional return-to-preset), and command rate limiting. Target selection by largest object, first detected, tracker ID, or class label. Includes the new "PTZ Auto Tracking" WPF demo.
* [Media Blocks SDK .Net][Video Capture SDK .Net] PTZ auto-tracking can now run an **idle preset patrol** — when no target reappears for a configurable delay, the camera cycles through a list of ONVIF presets (with a per-preset dwell time) until a new target is acquired, which immediately aborts the patrol and resumes tracking.
* [Demos] Added a **PTZ Auto Tracking** WPF sample for the Media Blocks SDK — the same ONVIF auto-tracking built on a low-level `MediaBlocksPipeline` (RTSP source → `ObjectAnalyticsBlock` → video renderer, with `PTZAutoTrackingController` driving the camera).
* [Media Blocks SDK .Net] Added **`VideoStabilizationBlock`** — real-time video stabilization that removes camera shake by estimating global inter-frame motion (translation and rotation) with OpenCV optical flow, smoothing the camera trajectory, and warping each frame back onto the smoothed path. Configurable smoothing radius, crop/zoom ratio, and per-frame correction limits; all tunable live. Requires the OpenCV redistributable (Windows).
* [Media Blocks SDK .Net][Video Capture SDK .Net][Media Player SDK .Net] `VideoStabilizationBlock` can now be used with the X engines: pass it to `Video_Processing_AddBlock()` on `VideoCaptureCoreX` or `MediaPlayerCoreX` to stabilize a live camera or a playback stream, with live retuning through `ApplySettings()`.
* [Demos] Added a **Video Stabilization** WPF sample (Media Blocks SDK): open a file, preview stabilized playback, record the stabilized result to MP4, and adjust the smoothing radius and crop ratio live.
* [Demos] Added a **Video Stabilization Capture X** WPF sample (Video Capture SDK X): stabilize a live camera with `VideoCaptureCoreX` and tune the stabilizer while the capture runs.
* [Demos] Added a **Video Stabilization Camera** WPF sample (Media Blocks SDK): stabilize a live camera with a hand-built `MediaBlocksPipeline` (camera source → stabilizer → renderer), with live tuning.

## 2026.7.8

* [Video Edit SDK .Net] Fixed a native process crash (fail-fast) when rendering FLAC output from a timeline with more than one clip (or a gap before the audio clip) in `VideoEditCoreX`.
* [Video Capture SDK .Net] Fixed empty WMA audio-only recordings from the legacy `VideoCaptureCore` engine: the default WMA profile was variable-bitrate (VBR), which the WM ASF Writer cannot produce from a live capture source, so the file contained only an ASF header with no audio data. The default is now an equivalent constant-bitrate WMA profile.
* [Core][Video Capture SDK .Net][Media Blocks SDK .Net] Fixed a **32-bit (x86)** ABI bug that mis-sized the native `GMutex` field (as a pointer) in the GStreamer object layout, shifting every element's field offsets by 8 bytes on x86. This made the element pad list read as empty and caused a NullReferenceException crash whenever the video/audio sample grabber, snapshots, or a frame-processing block was used on 32-bit. Frame grabbing, snapshots, and per-frame processing now work correctly on x86 (x64 unaffected).

## 2026.7.6

* [Media Blocks SDK .Net] Fixed an intermittent "Unable to create sample grabber element" failure that could occur when starting several camera pipelines (e.g. multiple RTSP cameras) at the same time. Managed element construction is now thread-safe.
* [Media Blocks SDK .Net] Fixed a NullReferenceException crash in the video sample grabber (and related processing elements) that could occur on the streaming thread when a frame buffer was momentarily unavailable.

## 2026.7.3

* [Media Blocks SDK .Net] Added **`PIIRedactionBlock`** — automatic on-video redaction of personally identifiable information: faces (YuNet), vehicle license plates (FastALPR detector), and on-screen text (PP-OCRv5 detection + recognition — recognition filters out the detector's non-text false positives — with an optional regex filter that redacts only matching text such as e-mails or phone numbers). Redaction styles: Gaussian blur, pixelate, and solid fill. Each category can be toggled live; regions are padded and held between detection cycles so PII stays covered through motion and detector flicker. Works in `VideoCaptureCoreX`/`MediaPlayerCoreX` via `Video_Processing_AddBlock`.
* [Demos] Added a **PII Redaction** WPF sample (Media Blocks SDK): webcam, file, or RTSP source with live category/style switching.
* [Demos] Added **Player PII Redaction X** and **Capture PII Redaction X** samples (WPF and MAUI) — live face/plate/text redaction on `MediaPlayerCoreX` (file playback) and `VideoCaptureCoreX` (camera) via `Video_Processing_AddBlock`.

## 2026.7.2

* [Media Blocks SDK .Net] Added an **open-vocabulary object-detection** block (`OpenVocabularyDetectorBlock`) that detects objects from free-text prompts (OWLv2 / Grounding DINO) instead of a fixed class list, with prompts swappable at runtime. It can also drive `ObjectAnalyticsBlock` as a detector for tripwire / zone analytics.
* [Media Blocks SDK .Net] Added a **Florence-2 vision-language** block (`VLMBlock`) for frame captioning, OCR, phrase grounding, and object detection.
* [Media Blocks SDK .Net] Added a **CLIP video-embedding** block (`VideoEmbeddingBlock`) with a semantic frame-search index, for natural-language search over indexed video.
* [Media Blocks SDK .Net] `VideoEmbeddingBlock` can index a file at full decode speed with no dropped samples via `VideoEmbeddingSettings.BackpressureNoDrop` (backpressures the pipeline instead of dropping frames when the encoder is busy).
* [Media Blocks SDK .Net] `OpenVocabularyDetectorBlock` confidence and IoU thresholds can now be adjusted at runtime (`SetConfidenceThreshold` / `SetIoUThreshold`); the new value takes effect on the next frame without rebuilding the pipeline.
* [Demos] Added three WPF samples: **Open Vocabulary Detection**, **VLM Captioning**, and **Semantic Video Search**.
* [Media Player SDK .Net] Added `MediaPlayerCoreX.Video_Renderer_IsSync` — set it to `false` to run the video renderer without clock synchronization so a file is processed at full decode speed (for offline AI indexing / analysis) instead of in real time; `null` (default) keeps the automatic behavior.
* [Demos] Added **X-engine** versions of the new AI samples (WPF and MAUI): **Open Vocabulary Detection** and **VLM Captioning** for both `VideoCaptureCoreX` (camera) and `MediaPlayerCoreX` (file), plus **Semantic Video Search** for `MediaPlayerCoreX`. Each inserts the AI block through the `Video_Processing_AddBlock` API.

## 2026.6.30

* [Demos] Added **Face Recognition** and **OCR** demos for the X engines, in both WPF and MAUI: **Player Face Recognition X** and **Player OCR X** (`MediaPlayerCoreX`), plus **Capture Face Recognition X** and **Capture OCR X** (`VideoCaptureCoreX`). Each inserts the AI block through the `Video_Processing_AddBlock` API — the face demos enroll people from photos and label them on the video; the OCR demos draw and log recognized text.
* [Demos] Added a **Capture Live Subtitles X** WPF sample (`VideoCaptureCoreX` with on-device Whisper speech-to-text subtitles).

## 2026.6.29

* [Media Blocks SDK .Net] Speech-to-text (`SpeechToTextBlock`) now always transcribes the full input losslessly — the source is paced to Whisper so no audio is ever dropped. The previous live drop-buffer mode and the `SpeechToTextSettings.BackpressureWhenBusy` option were removed (the lossless behavior is now the only mode).

## 2026.6.27

* [Video Capture SDK .Net] `VideoCaptureCoreX` can now insert AI processing blocks — object detection, OCR, face recognition, license-plate recognition, object analytics, background removal, generic ONNX inference, and Whisper speech-to-text — directly into the capture pipeline through `Video_Processing_AddBlock` / `Audio_Processing_AddBlock`, with on-frame overlays and detection events.
* [Media Player SDK .Net] `MediaPlayerCoreX` gains the same `Video_Processing_AddBlock` / `Audio_Processing_AddBlock` API to run AI processing (object detection, OCR, speech-to-text, and more) on played files and streams.
* [Demos] Added a **Player AI Processing** demo (WPF): plays a file in `MediaPlayerCoreX` with a YOLO object detector or a Whisper speech-to-text block inserted through the new processing-block API.
* [Demos] Added four **MAUI** AI demos (Android/iOS/Mac Catalyst/Windows) for the new X-engine processing-block API: **Player Object Detection X** and **Player Live Subtitles X** (`MediaPlayerCoreX`), plus **Capture Object Detection X** and **Capture Live Subtitles X** (`VideoCaptureCoreX`).
* [Media Blocks SDK .Net] Fixed an `AccessViolationException` ("Attempted to read or write protected memory") that could crash the application when using text overlays (`OverlayManagerBlock` / `OverlayManagerText`) — most reliably reproduced by adding a text overlay right after `StartAsync` and then stopping. The font-enumeration path freed Pango-owned font objects it did not own, corrupting memory during a later garbage collection or pipeline shutdown.
* [Media Blocks SDK .Net] Fixed a related intermittent fatal crash ("Attempt to execute managed code after the .NET runtime thread state has been destroyed") that could abort the process during text overlay or font enumeration when a background media thread was recycled, or at application exit. The available-fonts / monospace-detection path no longer attaches a managed callback to Pango's internal font map.

## 2026.6.24
* [Media Blocks SDK .Net] Fixed a rare crash during pipeline shutdown or garbage collection in applications with many active GStreamer objects, such as multi-camera RTSP capture with sample grabbers, bridges, and file outputs.
* [Media Blocks SDK .Net] `FaceRecognitionBlock` — enrolling a face from a photo that carries an EXIF orientation tag (typical of phone camera shots) now works; the image is rotated upright before detection instead of reporting "no face found".
* [Demos] Added a **Face Recognition Uno** demo (Uno Platform): live camera 1:N face recognition with on-frame name/box overlay, photo enrollment, and switchable SFace / AuraFace embedding models. Android-focused.
* [Demos] The Face Recognition demos (WPF and CLI) now let you pick the embedding model: **SFace (128-D)** or **AuraFace (512-D, ArcFace family, Apache-2.0)** — a higher-accuracy, commercially licensed 512-D embedder downloaded on demand. The CLI adds an `--embedding sface|auraface` switch.
* [Demos] Face Recognition WPF demo: switching the embedding model now automatically rebuilds the gallery from the enrolled photos, so changing models no longer makes every face read as **Unknown** (embeddings from different models are not comparable).
* [Demos] Face Recognition MAUI demo: added the same SFace/AuraFace embedder selection and automatic gallery rebuild, plus a **video-file source** with a seek bar and a real-time / max-speed playback toggle (in addition to the live camera).

## 2026.6.23

* [Media Blocks SDK .Net] Unity samples now use Unity's default Enter Play Mode behavior (Domain + Scene Reload); disabling Domain Reload is no longer required. The SDK survives the Editor's Play/Stop and script-recompile domain reloads via a built-in reload guard.

## 2026.6.21

* [Video Capture SDK X .Net] Added **Android audio playback capture** support to `VideoCaptureCoreX` — assign `AndroidAudioPlaybackCaptureSourceSettings` to `Audio_Source` to record the audio played by **other apps** (system AudioPlaybackCapture API, Android 10 / API 29+, on top of a `MediaProjection` token) straight to a file. Includes a new native Android "Audio Playback Capture" demo built on `VideoCaptureCoreX` that records another app's audio to an `.m4a` file. Only apps that allow playback capture (usage MEDIA/GAME/UNKNOWN and not opted out) can be captured.

## 2026.6.20

* [Media Blocks SDK .Net] `VideoSampleGrabberBlock` now works as a terminal block: if you leave its output unconnected (e.g. you only poll `GetLastFrameAsSKBitmap()` or handle `OnVideoFrameBuffer`), the block self-terminates so frames keep flowing. Previously a grabber with an unconnected output stalled after the first frame, so every snapshot returned the same initial image.
* [Media Blocks SDK .Net] `VideoSampleGrabberBlock.GetLastFrameAsSKBitmap()` and `GetLastFrameAsBitmap()` now return `null` when no frame has been captured yet, instead of throwing a `NullReferenceException`.
* [Media Blocks SDK .Net] Setting `VideoSampleGrabberBlock.SaveLastFrame = false` now discards the cached frame, so toggling it back on later never hands back a stale frame captured during an earlier session.
* [Media Blocks SDK .Net] `KLVParser` now reads MISB KLV packets larger than 127 bytes. Standard MISB ST 0601 metadata uses BER long-form lengths, and the parser previously threw on the common 1- and 2-byte long-form lengths — so real-world packets failed to parse. All BER length forms are now decoded correctly.

## 2026.6.19

* [Media Blocks SDK .Net] Added **Android audio playback capture** — the new `AndroidAudioPlaybackCaptureSourceBlock` records the audio played by **other apps** using the system AudioPlaybackCapture API (Android 10 / API 29+) on top of a `MediaProjection` token, with a configurable format and usage filter (`AndroidAudioPlaybackCaptureSourceSettings`). Includes a new native Android "Audio Playback Capture" demo that records another app's audio to an `.m4a` file. Only apps that allow playback capture (usage MEDIA/GAME/UNKNOWN and not opted out) can be captured.
* [Media Blocks SDK .Net] Speech-to-text (`SpeechToTextBlock`) gains a lossless file-transcription mode: set `SpeechToTextSettings.BackpressureWhenBusy = true` to pace a file source to the transcription engine so no audio is dropped and the pipeline position tracks the transcription frontier — ideal for transcribing a file as fast as the engine allows without losing speech. The new `SpeechToTextBlock.RequestStop()` lets you stop promptly mid-file, and an `OnEndOfStream` event fires when transcription finishes.

## 2026.6.18

* [Media Blocks SDK .Net] Fixed WMV/ASF output where the video stream was written with a roughly 1000-hour timestamp offset while audio started at zero — players saw a broken duration and the video and audio never shared a timeline. WMV/ASF files now have correctly aligned, overlapping video and audio timestamps.
* [Media Blocks SDK .Net] Fixed MP4 recordings produced from a still/image source (`ImageVideoSourceBlock`, live mode) ending up unreadable ("moov atom not found") — a live image source now finalizes its file correctly on stop.
* [Media Blocks SDK .Net] VP9 WebM output now uses a real-time-capable speed/quality default: `VP9EncoderSettings.CPUUsed` defaults to `4` instead of `0`. The previous slowest/highest-quality default could not keep up with a live source, so the recorded video track could be truncated to about a second while audio ran the full length. Set `CPUUsed = 0` to restore maximum quality for offline encoding.
* [Media Blocks SDK .Net] The rav1e AV1 encoder (`RAV1EEncoderSettings`) now defaults to the fastest speed preset (`SpeedPreset = 10`) instead of `6`. rav1e is a quality-oriented, very slow software encoder; the previous default could encode well under real time (~1 fps at 720p), stalling live and short captures. Lower `SpeedPreset` for higher quality in offline encoding where throughput does not matter.

## 2026.6.14

* [Media Blocks SDK .Net] The AI blocks — `YOLOObjectDetectorBlock`, `OcrBlock`, object analytics, ANPR, `BackgroundRemovalBlock` (`VisioForge.DotNet.Core.AI`) and `SpeechToTextBlock` (`VisioForge.DotNet.Core.AI.Whisper`) — now build and run cross-platform on Linux, macOS, iOS, and Android, including .NET MAUI, in addition to Windows.
* [Media Blocks SDK .Net] On-device speech-to-text (`SpeechToTextBlock`, Whisper + Silero VAD) now runs on iOS and Android.
* [Demos] Added three .NET MAUI sample apps: **YOLO Object Detection**, **OCR Text Recognition**, and **Live Subtitles** (on-device Whisper speech-to-text). The existing Live Subtitles console sample is now cross-platform (Windows, Linux, macOS).
* [Media Blocks SDK .Net] Fixed a crash that could occur when stopping live speech-to-text with `SpeechToTextBlock` configured with `EnableVad = false` (fixed-window mode) — stopping the pipeline at end-of-stream while a transcription was in progress could terminate the process. Transcription of the in-progress window now completes cleanly during shutdown.
* [Media Blocks SDK .Net] `SpeechToTextSettings.FixedWindowSeconds` is now clamped to 1–30 s and `SileroVadSettings.MaxSpeechMs` no longer accepts "0 = unlimited" (a non-positive value falls back to the 15 s cap), so a single transcription window — and the time a stop waits for it to finish — stays bounded.

## 2026.6.13

* [Media Blocks SDK .Net] Added **live speech-to-text / subtitles** — the new `SpeechToTextBlock` (in the new `VisioForge.DotNet.Core.AI.Whisper` package) transcribes the audio stream in real time with Whisper (Whisper.net / GGML) on a background worker, gated by Silero VAD so silence is skipped and not mis-transcribed. Audio passes through unchanged. It raises `OnSpeechRecognized`, can auto-render captions onto video via `SubtitleRenderer` + `OverlayManagerBlock`, and can write `.srt` / `.vtt` side-car files. Runs fully on-device (CPU or NVIDIA CUDA); Whisper and Silero models are downloaded at runtime. Includes a new WPF Live Subtitles demo.
* [Media Blocks SDK .Net] Added **AI background removal (matting)** — the new `BackgroundRemovalBlock` runs an ONNX segmentation model (for example MODNet) to estimate a per-pixel foreground mask and replaces the background in real time with a blur of the original, a solid color, a static image, or transparency. Includes a new WPF Background Removal demo. The background is composited on every frame, so running the model less often (frame skipping) lowers CPU/GPU load without flicker.

## 2026.6.11

* [Media Blocks SDK .Net] Added **Object Analytics** — multi-object tracking with stable IDs, directed tripwire line crossing (In/Out counts), and polygon zone occupancy on top of ONNX object detection. Includes a turnkey `ObjectAnalyticsBlock`, a pure C# analytics API (`ByteTracker`, `LineZone`, `PolygonZone`), overlay rendering with traces and counters, a new analytics mode in the YOLO Object Detection demo, and separate Tripwire and Polygon Zone demo applications.

## 2026.6.8

* [Video Capture SDK .Net] Updated the bundled FFmpeg DirectShow source and encoder filters to **FFmpeg 8.1.1**, with refreshed codec libraries (VP8/VP9, Opus, Vorbis, Speex, SRT) and current OpenSSL — bringing newer format support and upstream security and stability fixes to FFmpeg-based capture and output.

## 2026.6.7

* [Media Blocks SDK .Net] Fixed a crash when reusing a `TSAnalyzerBlock` across runs: after the block is stopped, analyzing a second transport stream with the same instance in a new pipeline now works instead of failing during rebuild.
* [Media Blocks SDK .Net] Fixed MPEG-TS output with KLV metadata aborting (no valid file produced) when a video frame arrived with an out-of-order/duplicate timestamp — the muxer now keeps the stream writable, so KLV-bearing transport streams record reliably.
* [Core] Fixed native memory steadily growing while reading media information for many different files in sequence with `MediaInfoReaderX`; per-file discovery resources are now released after each read.

## 2026.6.6

* [Media Player SDK .Net] **New "Modern Player" MAUI demo.** A from-scratch cross-platform sample (Android, iOS, macCatalyst, Windows) built on `MediaPlayerCoreX` with a dark glassmorphism UI, a YouTube-style seek preview (a thumbnail popup follows the scrub bar — generated in the background from the opened file), a live video + audio effects drawer (brightness/contrast/saturation/hue, gamma, blur/sharpen, grayscale, edge, deinterlace, color presets, flip/rotate, 3D-LUT; plus gain, pitch, 10-band equalizer, reverb, echo, true-bass, and karaoke), frame snapshot, playback-speed control, and volume/mute.
* [Media Player SDK .Net] [Media Blocks SDK .Net] Fixed opening local media files by absolute file path on Android, iOS, macOS, and Linux. A path starting with `/` (the form returned by the native file pickers) previously failed with a URI-format error; `MediaPlayerCoreX.OpenAsync(string)`, `MediaInfoReaderX`, and `UniversalSourceSettings.CreateAsync(string)` now open such files correctly. Windows paths were unaffected.
* [Media Blocks SDK .Net] **OCR — text recognition:** new `OcrBlock` recognizes text in any video or image source using a multi-stage PaddleOCR (PP-OCRv5) ONNX pipeline — text detection, automatic 180° orientation handling, and text-line recognition. Runs on CPU or GPU (DirectML on Windows, CoreML on Apple, CUDA) and is fully cross-platform (Windows/Linux/macOS/Android). It raises the recognized regions per frame (text, confidence, and the text polygon) and can optionally draw the boxes and recognized text directly into the video. Works with the permissive Apache-2.0 PP-OCRv5 mobile models (100+ languages available); the models ship with the sample, not the package.
* [Media Blocks SDK .Net] **ANPR — license plate recognition:** new `LicensePlateRecognizerBlock` reads vehicle number plates from a live stream or file using a specialized two-stage pipeline — a dedicated license-plate detector locates each plate, then a plate-specific OCR model (a global head covering the USA and 90+ countries, or a European head) reads its characters. Recognition runs on a background thread so live video never stalls; recognized plates (text, confidence, bounding box) are raised per frame and optionally drawn over the video. Cross-platform and GPU-accelerated (DirectML / CUDA / CoreML). The MIT-licensed models ship with the sample, not the package.

## 2026.6.4

* [Media Blocks SDK .Net] **AI inference package renamed:** the AI/ONNX inference package is now published as `VisioForge.DotNet.Core.AI` (previously `VisioForge.DotNet.Core.ONNX`). Update your `PackageReference` to the new id — the API and namespaces of the inference blocks are unchanged.
* [Media Blocks SDK .Net] **Object detection: more models, permissive default.** `YOLOObjectDetectorBlock` now decodes three model families via the new `YoloDetectorSettings.Model` property — **YOLOX** and **RT-DETR / D-FINE** (both Apache-2.0) in addition to YOLOv8/v11. Each family's frame preprocessing (resize mode, normalization, channel order) and the model's input size are applied automatically, so you only pick the family and the `.onnx` file. The Object Detection demo now ships a ready-to-run **Apache-2.0** model (YOLOX-nano) and works out of the box without any third-party model download. RT-DETR / D-FINE detectors are end-to-end (NMS-free).
* [Media Blocks SDK .Net] **TS analyzer — ETSI TR 101 290 monitoring:** `TSAnalyzerBlock` now reports a structured TR 101 290 Priority 1/2/3 check list (sync loss, sync-byte errors, PAT/PMT/PID errors, continuity-count errors, transport errors, CRC errors, PCR/PTS errors, and SI/SDT/EIT/TDT errors), each with its priority, error count, and pass/fail status — turning the block into a broadcast-grade transport-stream monitor.
* [Media Blocks SDK .Net] **TS analyzer — service information:** the report now exposes per-program SDT service names, service provider, and service type, the network name, and the stream UTC time (TDT/TOT), so programs show up as their real service name instead of just a program number.
* [Media Blocks SDK .Net] **TS analyzer — audio language:** elementary-stream entries now carry the ISO 639 audio language parsed from the PMT descriptors.
* [Media Blocks SDK .Net] **TS analyzer — scrambling detection:** per-PID and per-program scrambling state is now reported (transport-scrambling-control and free_CA_mode), along with a scrambled-packet count.
* [Media Blocks SDK .Net] **TS analyzer — null and effective bitrate:** the report adds the null-packet count, the null (stuffing) bitrate, and the effective (useful) bitrate, plus per-PID instantaneous and peak bitrate alongside the existing cumulative average.
* [Media Blocks SDK .Net] **TS analyzer — PCR timing and PTS/DTS:** PCR statistics now include maximum jitter and PCR repetition errors, and the report tracks PTS/DTS presence per PID and audio/video synchronization offset.
* [Media Blocks SDK .Net] **TS analyzer — codec details:** video elementary streams now report parsed codec details (resolution, frame rate, profile, level, chroma format, and display aspect ratio) for H.264, HEVC, and MPEG-2. Frame rate and aspect ratio are reported from the MPEG-1/2 sequence header.
* [Media Blocks SDK .Net] **TS analyzer — optional EPG:** when enabled, the analyzer parses EIT events (event id, start time, duration, name, description) and exposes them as an EPG event list. The new analysis options (service info, EPG, scrambling, TR 101 290, PTS/DTS, codec details) are configurable on `TSAnalyzerSettings`. The WPF and console demos display all of the new information.
* [Video Capture SDK .Net] Fixed audio capture failing to start with certain WDM capture cards (for example the Viewcast Osprey 460E) when the device was selected by its device path — the device enumerated correctly but capture aborted with an "audio output pin is null" error. Such devices now bind reliably.
* [Media Blocks SDK .Net] Fixed a `MediaBlocksPipeline` becoming unusable after a media file played to its end. Once a source reached End-of-Stream, the next `StartAsync()` was permanently rejected with "Already starting or start in progress." and the pipeline could not be restarted without recreating it — for example when switching from a finished file back to a live camera. Playback now shuts down cleanly at end-of-stream exactly like an explicit `StopAsync()` (sources stopped, resources released), so the same pipeline can be started again.

## 2026.6.3

* [Media Blocks SDK .Net] **MPEG-TS analyzer:** new `TSAnalyzerBlock` analyzes a transport stream and reports the program/service line-up (PAT/PMT/PSI), the per-PID stream types and codecs, per-PID and total bitrate, continuity-counter errors, and PCR timing (interval min/avg/max and discontinuity count). It accepts a raw MPEG-TS byte stream from a file, UDP, or SRT source and can run terminal (`Input`) or inline passthrough (`InputOutput`); subscribe to `OnAnalysisUpdated` for periodic snapshots or call `GetReport()`. New WPF and console demos ("TS Analyzer Demo", "TS Analyzer CLI") show file and live UDP/SRT analysis.
* [Media Blocks SDK .Net] **Raw MPEG-TS UDP source:** new `UDPRAWMPEGTSSourceBlock` receives a live UDP unicast or multicast transport stream and exposes the untouched MPEG-TS byte stream without demuxing — for analysis or passthrough remuxing/recording. The advertised packet size is configurable via `UDPRAWMPEGTSSourceSettings.PacketSize` (188 by default, or 192 for M2TS-style streams).
* [Media Blocks SDK .Net] **Split-recording segment events:** `MP4SinkBlock`, `MPEGTSSinkBlock`, and `MP4OutputBlock` now raise `OnSegmentCreated` and `OnSegmentClosed` when configured for split recording (`MP4SplitSinkSettings` / `MPEGTSSplitSinkSettings`). The arguments carry the segment file path, fragment index, and timing (running time, plus start offset and duration on close) — so you can be notified when a segment file is finished and, for example, rename it to include its start/end time.
* [Media Blocks SDK .Net] **Custom split-segment file names:** the same blocks add an `OnSegmentFileNameRequested` event, raised just before each new segment file is created, letting you supply a custom file name (for example one that embeds the segment start date/time). Leave it unset to keep the default name from the location pattern.
* [Media Blocks SDK .Net] **New AI inference blocks:** `OnnxInferenceBlock` runs any ONNX Runtime model over the live video frames and raises an event with the raw model outputs, while `YOLOObjectDetectorBlock` performs YOLOv8/v11 object detection, draws bounding boxes and labels directly on the video (label text auto-scales to the frame resolution so it stays readable on 720p/1080p/4K, or pin a fixed size via `YoloDetectorSettings.LabelFontSize`), and raises a detections event (with class, confidence, and box for each object). Both support frame skipping to tune throughput. On Windows the package uses the DirectML ONNX Runtime build, so inference runs on any DirectX 12 GPU (NVIDIA, AMD, or Intel) out of the box; the execution provider defaults to `Auto`, which picks the fastest available backend (DirectML/CUDA/CoreML) and transparently falls back to the CPU. Use `OnnxInferenceEngine.GetAvailableProviders()` to detect what is available and the new `ActiveProvider` property on either block to see which provider engaged. The `VisioForge.DotNet.Core.ONNX` package targets the full SDK framework matrix (.NET Framework 4.6.1 through .NET 10); inference requires a 64-bit (x64 or ARM64) ONNX Runtime native build.

## 2026.6.2

* [Video Capture SDK .Net] Fixed KLV metadata progressively drifting out of sync with the video (about 2 seconds per source loop) on the receiving side when restreaming a looping KLV-bearing MPEG-TS via `UDP_FFMPEG_EXE`. KLV and video now stay aligned across source loop boundaries.
* [Video Capture SDK .Net] Unity: new VideoCaptureCoreX samples — local webcam preview + MP4 recording (Windows, macOS) and IP/RTSP camera viewing (Windows, Android, macOS, iOS).
* [Video Edit SDK .Net] Unity: new VideoEditCoreX sample — combine clips, apply effects, preview the timeline in Unity, and render to MP4.

## 2026.5.31

* [Media Blocks SDK .Net] **New `UDPRAWSourceBlock`:** receives a live UDP stream (MPEG-TS, RTP, or raw elementary) and exposes the parsed, still-encoded media without decoding — ideal for recording or remuxing without re-encoding. MPEG-TS feeds are auto-detected; RTP and raw modes let you set the codec, RTP payload type, and a multicast address. It exposes all common video and audio codecs (video: H264, H265, VP8, VP9, AV1, MPEG-2, MJPEG; audio: AAC, MP3/MPEG audio, AC-3, Opus, FLAC); RTP can also carry audio on a separate port (`AudioPort` / `AudioCodec`). A codec without a dedicated parser is passed through unchanged rather than dropped, so a connected recorder/muxer is never starved.
* [Demos] **New WPF "UDP RAW Capture Demo" (Media Blocks SDK .Net):** records a live UDP H264/H265 feed to MP4 files **without re-encoding**, with selectable transport (Auto / MPEG-TS / RTP / raw), starting a new file on a configurable interval and splitting on key-frames so no data is lost between files, while previewing the stream.
* [Media Player SDK .Net] Unity: new MediaPlayerCoreX sample — play files and network URLs with seek, pause and volume, rendered into a Unity `Texture2D`.

## 2026.5.29

* [Media Blocks SDK .Net] **Unity 6 (.NET Standard 2.1) build flavor:** the managed SDK now ships as a single `netstandard2.1` assembly compatible with Unity's IL2CPP backend (Api Compatibility Level = .NET Standard 2.1). This lets Unity projects target the SDK without requiring the .NET Framework 4.x compatibility surface. The existing net48 Unity package remains supported.
* [Media Blocks SDK .Net] **Unity macOS Standalone player support (Universal arm64 + x86_64):** the Unity 6 ns2.1 `.unitypackage` now ships a third platform flavor for macOS Standalone (in addition to Windows and Android). Includes pre-built P/Invoke for macOS `.dylib` names, the bundled CrossPlatform.Core.macOS native runtime (GStreamer dylibs + `libgioopenssl` TLS backend + `ca-certificates.crt`), and a one-time `Configure()` bootstrap that prunes any system / homebrew GStreamer from `DYLD_LIBRARY_PATH` before the loader runs.
* [Core] **New API:** `VisioForgeX.StopMainLoop()` — explicit teardown of the internal GLib main loop independent of `DestroySDK()`, for scenarios that need to release the loop without tearing the SDK down.

## 2026.5.22

* [Demos] **Unity `.unitypackage` distribution:** the Unity 6 (net48) integration now ships as a single self-contained `.unitypackage`
* [Demos] **New Unity 6 (net48) samples:** `SimplePlayer` (file playback) and `RTSPViewer` (live RTSP camera) render a `MediaBlocksPipeline` into a Unity `RawImage` via a reusable `VisioForgeVideoView` component (Stretch / Letterbox / Crop). The bundled native + managed runtime is set up automatically; a step-by-step setup guide is included.

## 2026.5.20

* [Media Blocks SDK .Net] **Fix:** native memory leak in `OverlayManagerFilter` and `PanZoomFilter` on iOS/AOT builds.

## 2026.5.19

* [Media Blocks SDK .Net] **Fix:** `CVMotionCellsBlock`, `CVFaceDetectBlock`, `CVHandDetectBlock`, `CVTemplateMatchBlock` — event subscriptions added after `StartAsync` sometimes were silently dropped.
* [Media Blocks SDK .Net] **Fix:** `CVMotionCellsSettings.Gap` and `PostNoMotion` are now rounded and clamped to the ranges accepted by the underlying `motioncells` element (`Gap` → `[1, 60]` s, `PostNoMotion` → `[0, 180]` s). Previously sub-second values truncated to `0` and were silently rejected.
* [Media Blocks SDK .Net] **Docs:** `CVMotionCellsSettings.GridSize` XML-doc clarified that the minimum is 8x8 (constraint of the underlying `motioncells` element); smaller values are silently rejected.

## 2026.5.18

* [Media Blocks SDK .Net] **New API:** `SRTSinkSettings.PreResolveHostname` and `SRTSourceSettings.PreResolveHostname` (`bool`, default `false`). When set to `true`, the SDK resolves any DNS hostname in the SRT URI to a literal IPv4 on the managed side (via `System.Net.Dns`) before handing the URI to the native code.

## 2026.5.16

* [Core] Public-API XML documentation is now validated for correct syntax across the shipped NuGet packages.

## 2026.5.15

* [Core] Added `D3D11Composable` WPF renderer mode: a pure FrameworkElement video panel built on a D3D11 shared texture + `D3DImage` bridge that composes natively with the WPF visual tree (transforms, opacity, z-order, rounded clips) and keeps frames GPU-resident end-to-end. New type: `D3D11ComposablePanel`.
* [Core] Added true-peak (dBTP) metering per ITU-R BS.1770-4: new `TruePeakComputer` (4× polyphase FIR oversampling, per-channel running peak, NaN/Inf-safe) and `VUMeterXData.TruePeak[]` channel array fired alongside the existing sample-peak/RMS data.
* [Core] Added `VolumeMeterLED` WPF control: segmented LED-bar VU meter with broadcast-style green/yellow/red zones, optional peak-hold marker (configurable fall time), optional dB scale labels, optional RMS overlay bar, horizontal/vertical orientation.
* [Core] NuGet packages now ship XML documentation generated from real summaries for the full public API surface (previously the doc files were empty).

## 2026.5.14

* [Avalonia] Updated Avalonia, Avalonia.Desktop, Avalonia.Fonts.Inter, Avalonia.Themes.Fluent from 12.0.1 to 12.0.3.
* [WinForms] Resolve issue with WinForms designer when using `VideoView` in .Net Framework 4.x projects
* [Dependencies] Closed two transitive security advisories: pinned `System.Drawing.Common` per-TFM on bare/cross-platform `netN.0` (was 5.0.1 via DlibDotNet — GHSA-rxg9-xrhp-64gj, critical) and added explicit `SharpCompress 0.48.1` CPM pin to lift the transitive floor from MongoDB.Driver (was 0.30.1 — GHSA-6c8g-7p36-r338, moderate); bumped MongoDB.Driver 3.8.0 → 3.8.1.
* [Breaking] `VisioForge.Core.CVD` and `VisioForge.Core.FaceAI` assemblies are no longer strong-named. The underlying `DlibDotNet` dependency is unsigned, so the strong-name chain was already broken at runtime; the `<SignAssembly>` flag was dropped to silence CS8002. Consumers that referenced these assemblies by fully-qualified strong name (`PublicKeyToken=...`) or used `[InternalsVisibleTo("VisioForge.Core.CVD, PublicKey=...")]` must remove the strong-name assertion when upgrading.

## 2026.5.10

* [Core] `CustomMixerSourceBlock`: reliability and throughput improvements under heavy load.

## 2026.5.8

* [Dependencies] Upgraded MongoDB.Driver.GridFS 2.30.0 to MongoDB.Driver 3.8.0; pinned Snappier 1.3.1 to resolve NU1903 high-severity vulnerability (GHSA-pggp-6c3x-2xmx)

## 2026.5.2

* [Core] Breaking change: licensing APIs now accept only raw certificate bytes. Removed file-path and stream-based certificate setters across shared licensing, public SDK wrappers, legacy Windows wrappers, tests, and licensing docs. Applications must load `.vflicense` files into memory and call `SetLicenseCertificateAsync(byte[])`.
* [Core] `AudioMixerBlock`: `AudioMixerSettings.IgnoreInactivePads` is now opt-in (default `false`). The 2026.4.30 release briefly forced it `true`, which broke single-input mixers — silent live audio and corrupted MP4 output. Multi-stream consumers (`MediaPlayerCoreX` additional audio streams, `LiveVideoCompositor`, and `AudioMixerSourceSettings`-based multi-source capture) now opt in explicitly. If you wired a multi-stream `AudioMixerBlock` on 2026.4.30–2026.5.1 and relied on the implicit `true`, set `AudioMixerSettings.IgnoreInactivePads = true` explicitly.

## 2026.4.25

* [Core] Fixed WinForms designer exception on `VideoView` in net472 demos — SkiaSharp 3 migration regression
* [Core] Added transitive `SkiaSharp.NativeAssets.Linux` dependency for bare cross-platform TFMs (`netcoreapp3.1`, `net5.0`–`net10.0`) so consumers publishing to `linux-x64`/`arm64` no longer need to add the package manually; main `SkiaSharp` already covers Win32/macOS/iOS/Android/MacCatalyst/tvOS via per-TFM nuspec groups
* [Avalonia] Migrated SDK and all 28 demos from Avalonia 11.3.8 to **12.0.1**: replaced `Avalonia.Diagnostics` with `AvaloniaUI.DiagnosticsSupport 2.2.1`, switched to `ReactiveUI.Avalonia 12.0.1`, updated `RxApp.MainThreadScheduler` → `RxSchedulers.MainThreadScheduler` (ReactiveUI 23.x), new `UseReactiveUI(_ => { })` signature, moved Android `CustomizeAppBuilder` from `MainActivity` to new `MainApplication : AvaloniaAndroidApplication<App>`, migrated `SaveFileDialog`/`OpenFileDialog`/`FileDialogFilter` to `IStorageProvider.SaveFilePickerAsync`/`OpenFilePickerAsync` in 4 demos. SkiaSharp pinned to 3.119.3-preview.1.1 (required by Avalonia.Skia 12).

## 2026.4.23

* [NuGet] Extracted Intel Quick Sync Video (QSV) plugin (`gstqsv.dll`) from `VisioForge.CrossPlatform.Core.Windows.x64/x86` into new optional packages `VisioForge.CrossPlatform.Core.Windows.Intel.x64` and `VisioForge.CrossPlatform.Core.Windows.Intel.x86`; each depends on the corresponding base Core package
* [Video Capture SDK .Net] Fixed FFMPEG.exe pipe output argument ordering so resize/aspect options are emitted after all inputs, including KLV metadata pipe input

## 2026.4.21

* [Core] Added `AutoAV1EncoderSettings`: auto-selecting AV1 encoder that walks AMF → NVENC → QSV → SVT-AV1 via `EncoderRuntimeTracker`, mirroring `AutoH264EncoderSettings` / `AutoHEVCEncoderSettings`; AV1 sessions now participate in per-runtime slot accounting
* [Core] Added typed `AV1Encoder.CanCreateSession(IAV1EncoderSettings, out string)` probe so AV1 runtime selection can detect driver rejections before wiring a pipeline
* [Core] Added `MFH264EncoderSettings`, `D3D12H264EncoderSettings`, `D3D12HEVCEncoderSettings` — alternative Windows runtimes (`mfh264enc`, `d3d12h264enc`, `d3d12h265enc`) with independent per-adapter session counters for bypassing per-runtime caps (e.g., AMD iGPU 2-session ceiling)
* [Core] Added `AutoH264EncoderSettings` / `AutoHEVCEncoderSettings`: auto-selecting encoder that probes runtimes in order (AMF → NVENC → QSV → MF → D3D12 → software), tracks in-flight sessions via `EncoderRuntimeTracker`, and falls back when a runtime's cap is reached
* [Demo] Added `Encoder Concurrency Test` WPF demo (Media Blocks SDK): spawn multiple source→encoder→decoder→renderer pipelines with configurable resolution, frame rate, encoder runtime, and adapter to exercise concurrent-session limits end-to-end

## 2026.4.18

* [Media Blocks SDK] UniversalSourceBlock: added `VideoFlipRotate` option for automatic video orientation correction using image-orientation metadata
* [Core] VOAACEncoderSettings deprecated in favor of `AVENCAACEncoderSettings`
* [Core] RTSPXOutput: now accepts any `IAACEncoderSettings`, not just VOAAC
* [Core] MediaInfoReaderCore: preserves image-orientation flip metadata during media info reading
* [Core] H264Encoder: fixed thread-safety issue in KeyFrameDetected callback
* [iOS] PhotoGalleryHelper: requests `PHAccessLevel.AddOnly` for iOS 26 compatibility
* [Android] GStreamer Android NuGet rebuilt with zbar barcode plugin, bumped to 2026.4.18
* [Platform] macOS demos migrated from net9.0-macos to net10.0-macos
* [Dependencies] Uno.Sdk bumped 6.4.24 → 6.5.31
* [Media Blocks SDK] LiveVideoCompositor V2: added `OnRenderStatistics` event with `ActualFps`, `ConfiguredFps`, `FramesDelivered`, and `LastFrameTimestamp` payload for detecting when the compositor falls behind the configured frame rate under heavy load
* [Media Blocks SDK] LiveVideoCompositor V1 (`VisioForge.Core.LiveVideoCompositor`) marked `[Obsolete]` — migrate to `VisioForge.Core.LiveVideoCompositorV2` (identical class names, single-line `using` swap); V1 will be removed in a future release
* [Demos] WPF LVC Demo and MAUI LVC Demo show the real vs configured output FPS in the UI; WinForms Video Mixer Player migrated from V1 to V2

## 2026.4.11

* [Media Player SDK X] Added `Play_PauseAtFirstFrame` property to MediaPlayerCoreX — pauses at the first rendered frame for preview/thumbnail scenarios, matching the existing MediaPlayerCore API
* [Core] Migrated SkiaSharp from 2.88.9 to 3.119.2 — updated text rendering to SKFont API, replaced SKFilterQuality with SKSamplingOptions, switched SVG library from SkiaSharp.Svg to Svg.Skia
* [UI] Updated SkiaSharp.Views.WPF and SkiaSharp.Views.Maui.Controls to 3.119.2; WPF skins now use DrawImage with high-quality Mitchell resampling

## 2026.4.8

* [Android] Added live camera switching (SwitchCamera) to SystemVideoSourceBlock — switches between front/back cameras without recreating the GStreamer pipeline, preserving resolution and frame rate
* [Video Capture SDK X] Added Video_Source_SwitchCamera for live camera switching on Android without pipeline restart
* [Video Capture SDK X] Added Video_Renderer_IsSync and Audio_Renderer_IsSync properties (default false) for lower-latency live preview
* [Android] New NuGet native version v2026.4.1

## 2026.3.27

* [Core] Fixed UNC path media info reading failure: `MediaInfoReaderAlt` now correctly handles SDK initialization guard, null caps in `OnPadAdded`, and falls through to `MediaInfoReaderX` on failure. `IsSambaURL()` extended to detect `file://host/path` UNC URIs. `OpenAsync` uses `uri.LocalPath` for correct Windows UNC path.

## 2026.3.18

* [Media Blocks SDK .Net] Fixed missed context menu issue in WPF VideoView

## 2026.3.17

* [Media Blocks SDK .Net] Added UDPSinkBlock and MultiUDPSinkBlock for raw UDP streaming output with single and multi-destination support
* [Media Blocks SDK .Net] Added UDPMPEGTSSinkBlock and MultiUDPMPEGTSSinkBlock for MPEG-TS multiplexed UDP streaming with single and multi-destination support
* [Media Blocks SDK .Net] Added UDPSinkSettings, MultiUDPSinkSettings, and UDPSinkSettingsBase for UDP sink configuration with IPv6 support and URL parsing
* [Media Blocks SDK .Net] Added UDP MPEG-TS streamer demo (screen capture to UDP output)

## 2026.3.11

* [Core] Device enumeration: Blackmagic ATEM and Web Presenter devices now appear in regular video/audio device lists instead of being filtered as Decklink hardware. These devices use standard USB/UVC drivers, not the Decklink SDK. Applies to both DirectShow and GStreamer enumeration paths.
* [Core] RTSP info reader: Added audio channel count and sample rate parsing from SDP rtpmap and GStreamer pad caps.

## 2026.2.16

* [Media Blocks SDK .Net] Added PreEventRecordingBlock for circular buffer (pre-event) video recording with configurable buffer duration, keyframe-aware drain, and automatic post-event stop
* [Video Capture SDK .Net] VideoCaptureCoreX: Added pre-event recording API with TriggerPreEventRecording, ExtendPreEventRecording, StopPreEventRecording, and state query methods
* [Video Capture SDK .Net] VideoCaptureCoreX: Added PreEventRecordingOutput for configuring circular buffer recording with MP4, MPEG-TS, and MKV container support

## 2026.2.12

* [Media Blocks SDK .Net] Added OnNetworkSourceDisconnect event for detecting network source disconnections (RTSP, HTTP, SRT, NDI, RTMP, etc.) with detailed error information and source URI

## 2026.2.11

* [Media Player SDK .Net], [Media Blocks SDK .Net] Fixed audio effects pipeline routing

## 2026.2.10

* [Core] Added UNC (SMB/Samba) network path support for file sources across all X-engines, fixing File.Exists() failures on network shares
* [Media Blocks SDK .Net], [Video Capture SDK .Net] Added mouse click highlight support for screen capture with auto-subscribe/unsubscribe, manual click input, and real-time settings update

## 2026.2.8

* [Media Blocks SDK .Net] Added OverlayManagerImageSequence: image sequence overlay with per-frame durations, looping, position/size animation, fade effects, and easing support
* [Media Blocks SDK .Net] Added ImageSequenceItem data class for defining image sequence frames
* [Media Blocks SDK .Net] OverlayManagerBlock: Added convenience methods for image sequence overlays (Video_Overlay_AddImageSequence, UpdateImageSequencePosition, AnimateImageSequence, ImageSequenceFadeIn/Out)
* [Core] Extracted OverlayManagerEasingHelper: shared easing functions for all overlay animation types (Image, Fade, Pan, Squeezeback, ImageSequence)

## 2026.2.4

* [Media Blocks SDK .Net] Added H264PushSourceBlock for pushing raw H.264 encoded data into a decoding pipeline, with automatic AVC-to-byte-stream conversion and PTS rebasing
* [Core] Added RtspDescribeClient: lightweight cross-platform RTSP DESCRIBE client for fast stream discovery (~100-200ms), with SDP parsing and Basic/Digest auth support
* [Core] RTSPSourceSettings: Added fast RTSP discovery path using RtspDescribeClient
* [Core] RTSPRAWSourceSettings: Added fast RTSP discovery path using RtspDescribeClient
* [Core] UniversalSourceSettings: Added fast RTSP discovery path for rtsp:// and rtsps:// URIs

## 2026.2.2

* [Core] VideoCaptureDeviceInfo: Extended Windows device path population to support Media Foundation (MF) devices in addition to KS
* [Core] VideoCaptureDeviceInfo: Fixed pre-existing bug where V4L2 device path validation checked wrong variable
* [Core] VideoCaptureDeviceSourceSettings: Added FindByDevicePath() static methods for restoring saved camera profiles by device path
* [Core] DeviceEnumerator: Added FindVideoSourceByDevicePathAsync() method for looking up devices by path
* [Media Blocks SDK .Net] Added RIST (Reliable Internet Stream Transport) MPEG-TS sink output support
* [Media Blocks SDK .Net] Added WebRTC WHIP (WebRTC-HTTP Ingestion Protocol) output support
* [Video Capture SDK .Net] Added WebRTC WHIP streaming output
* [Video Capture SDK .Net] Added RIST streaming output

## 2026.1.16

* [Media Blocks SDK .Net] BridgeVideoSourceSettings: Added DoTimestamp property to enable fresh timestamp generation for cross-pipeline scenarios

## 2026.1.15

* [Media Blocks SDK .Net] DecklinkVideoSinkSettings: Made Mode parameter required in constructor to prevent frame rate mismatch issues (was defaulting to Unknown mode causing unexpected 23.98fps output)
* [Media Blocks SDK .Net] DecklinkVideoSinkSettings: Made DeviceNumber and Mode properties read-only for immutability
* [Core] DecklinkVideoOutputDialog (WPF): Added Video Mode selector for configuring output frame rate

## 2026.1.12

* [Core] WPF VideoView: Fixed crash (System.ExecutionEngineException) when minimizing window during video overlay playback

## 2026.1.11

* [Media Blocks SDK .Net] RTSPSourceBlock: Fixed video freeze when audio capture is disabled for cameras with multiple audio streams
* [Media Blocks SDK .Net] RTSPRAWSourceBlock: Added fakesink handling for disabled audio streams to prevent pipeline stalls
* [Core] MediaInfoReaderCore: Added logging for discovered audio, video, and RTP streams
* [Core] MediaInfoReaderCore: Fixed excessive block size (5MB) being set for RTSP sources, improving discovery speed

## 2026.1.10

* [Video Capture SDK .Net] DSFFMPEGEXEPipeOutput: Fixed preview lag during video capture with optimized pipe handling and queue processing
* [Video Capture SDK .Net] FFMPEG EXE output: Added real-time encoding optimizations for VP8/VP9, fixed MJPEG quality mode, improved default H264MFSettings defaults

## 2026.1.6

* [Video Capture SDK .Net] VideoCaptureCoreX: Fixed video capture resolution issue when ResizeVideoEffect is applied

## 2025.12.12

* [Media Blocks SDK .Net] Added PitchBlock for audio pitch shifting with semitone control (-12 to +12 range)
* [Media Player SDK X .Net] CDGSource: Added pitch shifting support with EnablePitchShifting option and real-time PitchSemitones control
* [Media Player SDK X .Net / Media Blocks SDK .Net] CDGSourceSettings: Added ZIP archive support for karaoke files (MP3+CDG pairs inside ZIP)

## 2025.11.8

* [Media Blocks SDK .Net] OverlayManagerVideo and OverlayManagerDecklinkVideo: Changed AudioOutput property type from MediaBlock to AudioOutputDeviceInfo for direct audio device selection. Audio is now handled internally via AudioRenderer with automatic channel conversion support.

## 2025.11.4

* .Net 10 support for all SDKs

## 2025.11.3

* WPF VideoView update: Added RotationAngle, RotateCrop, and RotationStretch properties to support rotated video rendering

## 2025.11.1

* [Media Blocks SDK .Net] Add synchronized overlay group support for OverlayManagerBlock

## 2025.10.10

* [**Windows SDKs**] Updated VideoEffectRotate with no-crop option

## 2025.10.6

### 🚀 Major Feature: Ultra-Low Latency RTSP Streaming

* **[Media Blocks SDK .Net]** Revolutionary low latency mode for RTSP sources achieving **60-120ms total latency** (10-14x improvement over default 1-2 seconds)
  * Added `RTSPSourceSettings.LowLatencyMode` property for one-line enablement of optimized streaming
  * Automatic pipeline optimization: RTSP source (80ms), queue buffers (10-20ms), and renderer sync control
  * GStreamer integration: `latency=80ms`, `buffer-mode=0`, queue `max-size-buffers=2` with `leaky=downstream`
  * Perfect for real-time surveillance, security systems, live monitoring, and interactive video applications

* **[Media Blocks SDK .Net]** Enhanced RTSPSourceBlock with comprehensive low latency configuration
  * Added `RTSPBufferMode` enum with 5 modes (None, Auto, Slave, Buffer, Synced) for fine-grained jitter buffer control
  * Added `RTSPNTPTimeSource` enum (NTP, RunningTime, Clock) for NTP timestamp synchronization in multi-camera scenarios
  * New properties: `LowLatencyMode`, `BufferMode`, `DropOnLatency`, `NTPSync`, `NTPTimeSource`
  * Optimized `QueueElement` with automatic low latency configuration (2 frame max, leaky downstream mode)

* **[Video Capture SDK X .Net]** Full low latency mode support for RTSP sources
  * Compatible with `VideoCaptureCoreX` engine across all platforms
  * Same simple API: `RTSPSourceSettings.LowLatencyMode = true`
  * Works seamlessly with IP Capture demo and RTSP MultiView demo

* **[Cross-Platform Support]** Low latency RTSP streaming now available on all platforms:
  * Windows (WPF, WinForms, Console, Blazor)
  * macOS (MAUI, Console)
  * Linux (Console, WPF with Mono)
  * Android (MAUI, Native)
  * iOS (MAUI)

* **[Demo Applications]** Updated 6 demos with low latency mode UI controls:
  * Media Blocks SDK: RTSP Preview Demo (WPF), RTSP MultiView Demo (WinForms), MAUI RTSPViewer, Android RTSP Client
  * Video Capture SDK X: IP Capture (WPF), RTSP MultiView Demo (WinForms)
  * All demos include easy-to-use checkboxes or default-enabled low latency for optimal user experience

* **[Documentation]** Official help documentation updated with a low-latency section and best practices.

* **[Testing]** Validated on real IP cameras across all platforms. Performance benchmarks: Windows (85ms), macOS (95ms), Linux (80ms), Android (110ms), iOS (100ms).

* **[Backward Compatibility]** 100% backward compatible implementation:
  * Default behavior unchanged - existing code works without modification
  * Low latency mode is opt-in via explicit property
  * No performance impact when not using low latency mode
  * Queue optimization only applied when `LowLatencyMode=true`

## 2025.10.3

* [Media Blocks SDK .Net] Added DASH (Dynamic Adaptive Streaming over HTTP) sink support with DASHSinkBlock and DASHOutput classes
* [Media Blocks SDK .Net] Added UniversalSourceBlockV2 with improved memory usage and performance
* [X-engines] Fixed uvch264src not starting on Linux by properly selecting the appropriate source pad based on video format (vidsrc for H264, vfsrc for raw/MJPEG)

## 2025.9.5

* [Video Fingerprinting SDK] Improved support for flipped videos

## 2025.9.3

* [Media Blocks SDK .Net] Added DataMatrix barcode support using DataMatrixDecoderBlock block

## 2025.9.1

* [Video Fingerprinting SDK] Improved support for flipped videos

## 2025.8.9

* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved issue with Snapshot_GetSK call on Android (wrong colorspace)

## 2025.8.6

* [X-engines] Updated RTSP RAW source block. Added WaitForKeyframe and SyncAudioWithKeyframe properties. Block can wait for keyframes because some cameras may not send them as first frames.

## 2025.8.4

* [X-engines] Added NDI source support in Live Video Compositor

## 2025.8.2

* [ALL] New ONVIF manager code in VisioForge.Core.ONVIFX. Full implementation of various ONVIF services including Device Management, Media v1/v2, PTZ, Events, Imaging, Analytics, Recording, and Replay services.

## 2025.8.1

* [Media Player SDK] Added PauseOnStop property to MediaPlayerCoreX

## 2025.6.30

* [X-engines] Added animated GIF support to `ImageVideoSourceBlock`/`ImageVideoSourceSettings` classes
* [X-engines] Resolved issues with delayed file start in Live Video Compositor
* [X-engines] Update video mixer API to use GUIDs instead of integer indexes for video sources

## 2025.6.27

* [Video Capture SDK] Resolved issue with RTSP Low Latency engine with some cameras

## 2025.6.5

* [X-engines] Resolved issue with NDI sources playback without audio streams

## 2025.6.3

* [X-engines] Updated GenICam source support for USB Vision cameras. Added GenTL source support.

## 2025.6.2

* [X-engines] Added deinterlace support for interlaced Decklink video sources

## 2025.6.1

* [Live Video Compositor] Resolved issue with file sources paused on start, and resumed with error

## 2025.5.1

* [ALL] Update NuGet dependency packages to the latest versions
* [X-engines] Resolved issue with RTMP network streaming to a custom server

## 2025.4.8

* [ALL] Added Absolute Move API to the `ONVIFDeviceX` class. You can use this API to move the ONVIF camera to the specified absolute position.

## 2025.2.24

* [X-engine] By default, Media Foundation device enumeration is disabled. You can enable it using the `DeviceEnumerator.Shared.IsEnumerateMediaFoundationDevices` property.

## 2025.2.18

* [Media Player SDK.Net] Added loop support for the cross-platform engine.
* [ALL] Updated RTSP-X engine output, fixed crash issue with RTSP output and VLC player frequent reconnects
* [X-engines] Changed face detector support to use IFaceDetector interface
* [Live Video Compositor] Fixed registration issues with custom video view attached to video input
  
## 2025.2.9

* [X-engines] Updated NDI connection speed

## 2025.2.4

* [X-engines] RTSP Server Media Block and RTSPServerOutput added to Video Capture SDK. You can use the RTSPServerBlock to create an RTSP server and stream video and audio to it.

## 2025.2.1

* [X-engines] Added NVENC and AMF AV1 encoders support

## 2025.1.25

* [Windows] Resolved HTTPS issue with the not loaded SSL certificates

## 2025.1.22

* [Windows] Resolved issue with missed ONVIF sources while enumerating on PC with multiple network interfaces
* [Media Blocks SDK .Net] Added the `OnEOS` event to `MediaBlockPad` class. You can use this event to get the EOS (End of Stream) event from the media block. It can be useful if you have several file sources with a different duration and you need to stop the pipeline when the first source ends.
* [Media Blocks SDK .Net] Added the `SendEOS` method to `MediaBlocksPipeline` class. You can use this method to send the EOS (End of Stream) event to the pipeline.
  
## 2025.1.18

* [NuGet] `VisioForge.Core.UI.Apple`, `VisioForge.Core.UI.Android`, and `VisioForge.Core.UI.WinUI` packages are merged into the `VisioForge.DotNet.Core` package. All namespaces are the same.
* [Media Blocks SDK .Net] Added the `ZOrder` property to `LVCVideoInput` and `LVCVideoAudioInput` classes. You can use this property to set the Z-order for the video input.

## 2025.1.14

* [NuGet] `VisioForge.Core.UI.WPF` and `VisioForge.Core.UI.WinForms` packages are merged into the `VisioForge.DotNet.Core` package. In WPF projects you have to update the XAML code if the assembly names are used. All namespaces are the same.

## 2025.1.11

* [Video Capture SDK .Net] Resolved QSV H264 FFMPEG encoder issue with the wrong symbols in parameters

## 2025.1.7

* [Cross-platform] Added `libcamera` source support for Linux/Raspberry Pi.

## 2025.1.5

* [Cross-platform] Improved previous frame playback in Media Player SDK .Net (Cross-platform engine)

## 2025.1.4

* [Cross-platform] Resolved issue with AMD AMF plugin initialization

## 2025.1.1

* [Cross-platform] Resolved memory leak in `OverlayManagerImage`

## 2025.1.0

* [Cross-platform] Updated Live Video Compositor engine. Improved Decklink support for input and output. Improved performance. The new engine classes are located in the `VisioForge.Core.LiveVideoCompositorV2` namespace.

## 2025.0.29

* [Cross-platform] Default video renderer on Windows has been changed to DirectX 11

## 2025.0.17

* [Media Blocks SDK .Net] Added libCamera source support (can be used on Raspberry Pi)

## 2025.0.16

* [Media Blocks SDK .Net] Resolved issue with adding several AudioRendererBlocks to the pipeline

## 2025.0.14

* [Media Blocks SDK .Net] Added the "PushJPEGSourceSettings" class to configure the JPEG source for the "PushSourceBlock". You can use this class to set the JPEG source settings for the "PushSourceBlock". Also "video-from-images" sample added.

## 2025.0.7

* [ALL] Resolved window capture issues in cross-platform SDKs
* [Media Blocks SDK .Net] Added the Bridge Source Switch sample

## 2025.0.5

* [iOS] Resolved issues with playback speed for some video files
* [iOS] Added iOS Simulator support for all SDKs. Camera source is not supported in the simulator.

## 2025.0.3

* [MacOS] Resolved wrong stride issue for vertical camera videos on MacOS
* [Video Capture SDK .Net] Resolved background color issue for the scrolling text overlay

## 2025.0

* [ALL] .Net 9 support
* [Media Blocks SDK .Net] Added `AVIOutputBlock` to save video and audio streams to the AVI file format
* [Media Blocks SDK .Net] `TeeBlock` constructor now accepts the media type as a parameter
* [Video Capture SDK .Net] Added `Video_CaptureDevice_SetDefault` and `Audio_CaptureDevice_SetDefault` methods to the `VideoCaptureCore` class. You can use this method to set the default video and audio capture devices
* [Cross-platform] Improved `Metal` video rendering performance on Apple devices
* [All] Improved performance of common video processing operations in Windows classic SDKs
* [CV] Added DNN face detectors for the `Media Blocks SDK .Net` and `Video Capture SDK .Net`
* [Mobile] Improved AOT compatibility for iOS and Android
* [WinUI] Improved performance of the `WinUI` video rendering
* [Media Blocks SDK .Net] Added the `GetLastFrameAsSKBitmap` and `GetLastFrameAsBitmap` methods to `VideoSampleGrabberBlock` to get the last frame as a `SkiaSharp.SKBitmap` or `System.Drawing.Bitmap`
* [Video Capture SDK .Net] `VideoCaptureCore`: Added the `AddFakeAudioSource` property to `FFMPEGEXEOutput`. The `Network_Streaming_Audio_Enabled` property of `VideoCaptureCore` should be set to false to use this fake audio.
* [ALL] Improved WinUI (and MAUI on Windows) VideoView performance
* [Video Capture SDK .Net] `VideoCaptureCore`: Added the `PIP_Video_CaptureDevice_CameraControl_` API to control the camera settings for the Picture-in-Picture mode
* [X-engines] Added the headers support for the HTTP sources created using the `HTTPSourceSettings` class
* [X-engines] Updated Avalonia samples, with projects for macOS, Linux, and Windows
* [X-engines] Added NuGet redist packages for macOS and MacCatalyst (including MAUI)
* [Video Capture SDK .Net] `VideoCaptureCore`: Added device path support for `PIP_Video_CaptureDevice_CameraControl` API
* [Video Capture SDK .Net] `VideoCaptureCore`: Added the `FFMPEG_MaxLoadTimeout` property for IP camera sources. It allows you to set the maximum time to wait for the FFMPEG source to load the stream
* [X-engines] Updated Linux support for `ALSA`, `PulseAudio` and `PipeWire` audio devices
* [X-engines] Updated Linux support for `V4L2` devices
* [X-engines] Avalonia samples has be changed to a modern 1-project structure
* [X-engines] Resolved issue with `MAUI` crashes on Windows after `SkiaSharp` update
* [X-engines] Resolved issue with `TextureView` crashes on Android in `MAUI` applications
* [X-engines] Resolved playback issue for http sources using the `UniversalSourceBlock`
* [X-engines] Added Mobile Streamer sample for Android
* [X-engines] Added `OverlayManagerBlock` support for Android (now it's available for all platforms)
* [Video Capture SDK .Net] `VideoCaptureCoreX`: Added `CustomVideoProcessor`/`CustomAudioProcessor` properties for all output formats. You can use these properties to set custom video/audio processing blocks for the output format.
* [Media Blocks SDK .Net] Added the `KeyFrameDetectorBlock` to detect key frames in video streams (H264, H265, VP8, VP9, AV1, etc.)
* [Media Blocks SDK .Net] Fixed licensing issue for the `LiveVideoCompositor` class
  
## 15.10.0

* [Windows] Updated window capture API to capture only the specified parent window by default. Added the `UpdateHotkey` method to the `WindowCaptureForm` class to update the hotkey for the window capture form.
* [X-engines] Better AOT compatibility for default MAUI settings in iOS.
* [Media Blocks SDK .Net] Added the `DNNFaceDetectorBlock` to detect faces and blur/pixelate them using OpenCV and DNN models.
* [Media Blocks SDK .Net] Added the `MKVOutputBlock` to save video and audio streams to the MKV file format.
* [X-engines] Better support for video source size dynamic changing in MAUI applications.
* [X-engines] Resolved an issue with two or more VU meters in the same pipeline.
* [X-engines] Resolved volume/mute error issue with audio mixer in Live Video Compositor engine.
* [X-engines] The `Spinnaker` source for `FLIR`/`Teledyne` cameras is included in the main package and no longer requires an additional plugin.
* [Video Capture SDK .Net] Resolved the issue with the `SeparateCapture` API if no `VideoView` was used.
* [X-engines] The `MediaBlocksPipeline` constructor no longer has the `live` parameter. For more customizable pipelines, video and audio renderers got the `IsSync` property (`true` by default).
* [X-engines] Resolved `VideoViewTX` crash in MAUI Android applications.
* [X-engines] `IVideoEncoder` interface added to the `MPEG2VideoEncoder` class. It allows the use of `MPEG2VideoEncoder` with `MPEGTSOutput`, `AVIOutput`, and other output classes.
* [X-engines] Resolved the issue with window capture using the `ScreenCaptureD3D11SourceSettings` class. If the rectangle was incorrect or not specified, it caused an error.
* [X-engines] `Metal` renderer was added to SDK for Apple devices and used by default for iOS and MAUI.
* [Media Blocks SDK .Net] Added the MAUI Screen Capture sample.
* [Video Capture SDK .Net] VideoCaptureCore: Added the `VLC_CustomDefaultFrameRate` property to `IPCameraSourceSettings` to set a custom frame rate for the VLC IP camera source if the source does not provide the correct frame rate.
* [Media Blocks SDK .Net] `RTSPSourceBlock`: If the RTSP source has audio but you've disabled the audio stream in `RTSPSourceSettings`, SDK will add a null renderer automatically to prevent warnings.
* [ALL] Resolved issue with `VideoFrameX.ToBitmap()` call (wrong color space)
* [Windows] Updated KLV support in MPEG-TS output
* [Windows] Resolved MediaPlayerCore serialization issue
* [ALL] Video renderer settings class no longer contains background color. Use the VideoView background color property instead.
* [X-engines] Updated GStreamer libraries
* [X-engines] Resolved video rendering issues on Android and iOS
* [X-engines] iOS crash fixed during VideoViewGL usage
* [X-engines] Added default AAC encoder for iOS
* [X-engines] iOS camera source update for high frame rate support
* [Windows] Updated VLC source - improved file loading speed
* [Media Blocks SDK .Net]: Added the `UniversalDemuxBlock` allows to demux video and audio streams from a file in MP4, MKV, AVI, MOV, TS, VOB, FLV, OGG, and WebM formats
* [Windows] Resolved FFMPEG stability issues
* [X-engines] Resolved issue with loopback audio source using VideoCaptureCoreX and audio capture to file
* [X-engines] Added SRT source and sink support in Media Blocks SDK .Net and Video Capture SDK .Net
* [Video Capture SDK .Net] VideoCaptureCore: The `IP_Camera_ONVIF_ListSourcesAsyncEx` method got an overload version with a callback for a more responsible UI
* [X-engines] RTSP source compatibility update
* [X-engines] `Breaking API change`. Starting with this update, the SDK uses `IAudioRendererSettings` interface implementations for audio output configuration. WASAPI output got the custom configuration classes. Output_AudioDevice properties of `VideoCaptureCoreX`/`MediaPlayerCoreX` type have been changed to `IAudioRendererSettings`. You can create the `AudioRendererSettings` class instance from `AudioOutputDeviceInfo` using the default constructor.
* [X-engines] Resolved problem with missed Media Foundation sources during device enumeration
* [X-engines] Resolved RTSP source problems with audio connection in some situations
* [X-engines] Added the RTSP Preview Demo to Media Blocks SDK .Net
* [Windows] FFMPEG outputs and source updated to FFMPEG v7.0.
* [X-engines] Fixed rare crashes in RTSP source when camera information is not available for some reason (network issue)
* [X-engines] Resolved an issue with `WASAPI/WASAPI2` audio renderer usage
* [X-engines] Resolved an issue with the audio loopback audio source on Windows
* [X-engines] Improved iOS video rendering performance and stability
* [X-engines] Added AWS S3 Sink output for Media Blocks SDK .Net
* [X-engines] Added Allied Vision USB3/GigE cameras support in Media Blocks SDK .Net and Video Capture SDK .Net

## 15.9

* [X-engines] Resolved wrong aspect ratio with video resize effect/block
* [X-engines] Updated GStreamer redist
* [X-engines] Added Basler USB3/GigE cameras support in Media Blocks SDK .Net and Video Capture SDK .Net
* [Video Edit SDK .Net] VideoEditCoreX: The TextOverlay class changed to use SkiaSharp-based font settings. Additionally, you can set the custom font file name or configure all rendering parameters using custom SKPaint.
* [Windows] Added Stream support in `MediaInfoReader`. You can get the video/audio file information from a stream (DB, network, memory, etc.).
* [X-engines] Updated Live Video Compositor engine, which improved support of the file sources
* [Video Capture SDK .Net] Added camera-covered detector into the `Computer Vision Demo` and the `VisioForge.Core.CV` package
* [X-engines] Added API to get snapshots from video files using MediaInfoReaderX: GetFileSnapshotBitmap, GetFileSnapshotSKBitmap, GetFileSnapshotRGB
* [X-engines] iOS support in MAUI samples
* [X-engines] Resolved memory leak issue for RTSP sources
* [Media Player SDK .Net] MediaPlayerCore: Added support for data streams in video files using the FFMPEG source engine. Add the OnDataFrameBuffer event to get data frames (KLV or other) from the video file.
* [Video Capture SDK .Net] VideoCaptureCore: Added support for data streams in video files using the IP Capture FFMPEG source engine. Add the OnDataFrameBuffer event to get data frames (KLV or other) from the MPEG-TS UDP network stream or other supported source.
* [Video Capture SDK .Net] VideoCaptureCore: Added the FFMPEG_CustomOptions property to the IPCameraSourceSettings class. This property allows you to set custom FFMPEG options for the IP camera source
* [Windows] Fixed the hang problem with the FFMPEG source when a network connection is lost
* [Media Blocks SDK .Net] Added RTSP MultiView in Sync Demo
* [X-engines] Added support for FLIR/Teledyne cameras (USB3Vision/GigE) using the Spinnaker SDK
* [Video Edit SDK .Net] VideoEditCoreX: Added support for .Net Stream usage as an input source
* The IAsyncDisposable interface was added to all SDK's core classes. The `DisposeAsync` call should be used to dispose of the core objects using async methods.  
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved issues with Android video capture (sometimes started only one time)
* [Media Blocks SDK .Net] Added HLS streaming sample
* [Video Capture SDK .Net] VideoCaptureCore: Resolved crash if the `multiscreen` is enabled and screens added as window's handles (WinForms)
* [X-engines] Improved MAUI video rendering speed
* [X-engines] Resolved MAUI media playback issues (decoding) in MAUI Android
* [X-engines] Resolved an issue with the H264 webcam sources (sometimes not connected)
* [X-engines] Resolved an issue with audio stream playback in the Live VideoCompositor engine
* [Media Blocks SDK .Net] Resolved a bad audio issue while mixing using the Live Video Compositor engine
* [Media Blocks SDK .Net] Added Decklink output and file source into the Live Video Compositor sample
* [Media Player SDK .Net] MediaPlayerCore: Added growing MPEG-TS file support for the VLC engine. You can play growing MPEG-TS files while it's recorded
  
## 15.8

* [X-engines] [API breaking change] DeviceEnumerator can now be used only by using `DeviceEnumerator.Shared` property. One enumerator per app is required. DeviceEnumerator objects used by API have been removed
* [X-engines] [API breaking change] Android Activity is not required anymore to create SDK engines
* [X-engines] [API breaking change] X-engines require additional initialization and de-initialization steps. To initialize SDK, use the `VisioForge.Core.VisioForgeX.InitSDK()` call. To de-initialize SDK, use the `VisioForge.Core.VisioForgeX.DestroySDK()` call. You need to initialize SDK before any SDK class usage and de-initialize SDK before the application exits.
* [Windows] Improved MAUI video rendering performance in Windows
* [Windows] Added a mouse highlight for screen capture sources
* [Windows] Resolved a CallbackOnCollectedDelegate call issue with the BasicWindow class
* [Avalonia] Resolved an issue with Avalonia VideoView resize
* [X-engines] Added the StartPosition and StopPosition properties to UniversalSourceSettings. You can use these properties to set the start and stop positions for the file source.
* [ALL] Resolved the issue with passwords with special characters used for RTSP sources
* [ALL] Resolved the rare video flip issue with the Virtual Camera SDK engine
* [ALL] The VisioForge MJPEG Decoder filter was removed from the SDK's NuGet packages. You can optionally add it to your project by file copying or COM registration deployment.
* [X-engines] Fixed memory leak in the OverlayManager
* [Media Blocks SDK .Net] Resolved issue with the VideoSampleGrabberBlock, SetLastFrame option
* [Video Capture SDK .Net] VideoCaptureCoreX: WASAPI and WASAPI2 audio sources can be used now with the VideoCaptureCoreX engine
* [X-engines] DeviceEnumerator got events to notify about devices added/removed: OnVideoSourceAdded, OnVideoSourceRemoved, OnAudioSourceAdded, OnAudioSourceRemoved, OnAudioSinkAdded, OnAudioSinkRemoved
* [X-engines] Added custom error handler support for MediaBlocks, VideoCaptureCoreX, and MediaPlayerCoreX engines. Use the IMediaBlocksPipelineCustomErrorHandler interface and the SetCustomErrorHandler method to set a custom error handler.
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved issue with incorrect device index error for KS video sources (Windows)
* [Video Capture SDK .Net] VideoCaptureCore: Added Virtual_Camera_Output_AlternativeAudioFilterName property to set a custom audio filter for the Virtual Camera SDK output
* [Video Edit SDK .Net] VideoEditCore: Added Virtual_Camera_Output_AlternativeAudioFilterName property to set a custom audio filter for the Virtual Camera SDK output
* [Media Player SDK .Net] MediaPlayerCore: Added Virtual_Camera_Output_AlternativeAudioFilterName property to set a custom audio filter for the Virtual Camera SDK output
* [Video Capture SDK .Net] VideoCaptureCoreX: Added NDI streaming support and sample app.
* [Media Blocks SDK .Net] Added the BufferSink block to get video/audio frames from the pipeline
* [Media Blocks SDK .Net] Added the CustomMediaBlock class to create custom media blocks for any GStreamer element
* [Media Blocks SDK .Net] Added the UpdateChannel method to update the channel of the bridge source or sink
* [Media Player SDK .Net] MediaPlayerCore: Updated Tempo effect.
* [X-engines] Updated device enumerator. Removed unwanted firewall dialog when listing NDI sources.
* [X-engines] Fixed an issue with the video mixer when adding/removing video sources.
* [Media Blocks SDK .Net] Added VideoCropBlock and VideoAspectRatioCropBlock blocks to crop video frames.
* [Media Blocks SDK .Net] Resolved wrong frame rate issue with VideoRateBlock.
* [All] Resolved an issue with the Tempo audio effect.
* [Video Capture SDK .Net] VideoCaptureCore: Added WASAPI audio renderer support for the VideoCaptureCore engine.

## 15.7

* [ALL] .Net 8 support
* [Video Capture SDK .Net] VideoCaptureCore: Fixed problem with the OnNetworkSourceDisconnect event being called twice.
* [X-engines] Added the MPEG-2 video encoder.
* [X-engines] Added the MP2 audio encoder.
* [X-engines] Resolved Decklink enumeration issues.
* [X-engines] Default VP8/VP9 settings changed to live recording.
* [X-engines] Added DNxHD video encoder support.
* [Video Capture SDK .Net] VideoCaptureCoreX: Fixed problem with audio source format setting (regression).
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved WPF native rendering issue with a pop-up window.
* [All] Avalonia 11.0.5 support.
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved licensing issues.
* [Video Capture SDK .Net] VideoCaptureCore: Start/StartAsync method will return false if the video capture device is already used by another application.
* [All] Updated VLC source (libVLC 3.0.19).
* [All] Updated FFMPEG sources and encoders. Resolved issue with missed MSVC dependencies.
* [Video Capture SDK] Updated ONVIF engine.
* [Cross-platform SDKs] Updated Decklink source. Resolved the issue with the incorrect device name.
* [All] SkiaSharp security updates.
* [Cross-platform SDKs] Updated Overlay Manager. Added OverlayManagerDateTime class to draw current date time and custom text.
* [Cross-platform SDKs] Updated OverlayManagerImage. Resolved issue with System.Drawing.Bitmap usage.
* [ALL] VideoCaptureCore: Resolved rare crash issue with WinUI VideoView
* [Video Capture SDK .Net] VideoCaptureCore: Updated FFMPEG.exe output. Improved support of x264 and x265 encoders of custom FFMPEG builds.

## 15.6

* [Video Capture SDK .Net] VideoCaptureCore: Improved video crop performance on modern CPUs
* [ALL] VideoCaptureCore, MediaPlayerCore, VideoEditCore: Added the static CreateAsync method that can be used instead of the constructor to create engines without UI lag.
* [Video Capture SDK .Net] VideoCaptureCore: Resolved issues with video crop.
* [Video Capture SDK .Net] VideoCaptureCoreX: Added video overlays API. The Overlay Manager Demo shows how to use it.
* [Video Capture SDK .Net] Improved HW encoder detection. If you have several GPUs, sometimes only the major GPU can be used for video encoding.
* [Cross-platform SDKs] Updated Avalonia VideoView. Resolved issue with VideoView recreation.
* [Media Player SDK .Net] MediaPlayerCoreX: Resolved startup issue with the Android version of the MediaPlayerCoreX engine.
* [Media Player SDK .Net] MediaPlayerCore: Video_Stream_Index property has been replaced with Video_Stream_Select/Video_Stream_SelectAsync methods.
* [Media Player SDK .Net] MediaPlayerCoreX: Added Video_Stream_Select method.
* [Video Capture SDK .Net] VideoCaptureCore: Network_Streaming_WMV_Maximum_Clients property moved to WMVOutput class. You can set the maximum number of clients for network WMV output.
* [All] Updated WPF rendering. Improved performance for 4K and 8K videos.
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved issue with multiple outputs used.
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved issue with OnAudioFrameBuffer event.
* [Video Capture SDK .Net] Decklink source changed to improve startup speed. The Decklink_CaptureDevices method has been replaced by async Decklink_CaptureDevicesAsync.
* [Media Player SDK .Net] MediaPlayerCoreX: Added Custom_Video_Outputs/Custom_Audio_Outputs properties to set custom video/audio renderers
* [Media Player SDK .Net] MediaPlayerCoreX: Added Decklink Output Player Demo (WPF)
* [Video Edit SDK .Net] Added Multiple Audio Tracks Demo (WPF)
* [Video Edit SDK .Net] Updated MP4 output for multiple audio tracks
* [Cross-platform SDKs] Updated device enumerator
* [Video Capture SDK .Net] Resolved issue with VU meter in cross-platform engine
* [Cross-platform SDKs] Resolved issue with VU Meter (event not fired)
* [Media Player SDK .Net] Updated memory playback
* [ALL] Added IAsyncDisposable interface support for cross-platform core classes. It should be used to dispose of the core objects in async methods.
* [Video Capture SDK .Net] Added madVR support for mutiscreen
* [Video Capture SDK .Net] Resolved NDI enumerating issue in the VideoCaptureCore engine
* [Media Player SDK .Net] Added madVR Demo
* [Video Capture SDK .Net] Added madVR Demo
* [ALL] Resolved madVR issues in all SDKs
* [Media Blocks SDK .Net] Added NDI Source demo
* [Video Capture SDK .Net] Added NDI support for cross-platform engine
* [ALL] Resolve the "image not found" issue with the WinUI NuGet package
* [Media Blocks SDK .Net/Media Player SDK .Net (cross-platform)] Added MP3+CDG Karaoke Player demo
* [Media Blocks SDK .Net] Added CDGSourceBlock for MP3+CDG karaoke files playback
* [ALL] Improved madVR support
* WinUI VideoView updated to fix issues during audio file playback
* [Video Capture SDK .Net] Improved VNC source support for the VideoCaptureCoreX engine.
* [Video Capture SDK .Net] Added VNC source support for the VideoCaptureCoreX engine. You can use VNCSourceSettings class to configure Video_Source.
* [Media Blocks SDK .Net] Added VNC source support. You can use the VNCSourceBlock class as a video source block.
* [Video Capture SDK .Net] Video_Resize property has been changed to IVideoResizeSettings type. You can use the VideoResizeSettings class to perform classic resize the same as before or use MaxineUpscaleSettings/MaxineSuperResSettings to perform AI resizing on Nvidia GPU using Nvidia Maxine SDK (SDK or SDK models are required to deploy).
* [ALL] Resolved issues with NDI source detection in the local network
* [ALL] Added KLVParser class to read and decode data from KLV binary files.
* [ALL] Added KLVFileSink block. You can export KLV data from MPEG-TS files.
* [Media Blocks SDK .Net] Added KLV demo.
* [Video Capture SDK .Net] Added MJPEG network streamer.
* [ALL] Added WASAPI 2 support.
* [Media Blocks SDK .Net] Updated Video Effects API. Added Grayscale media block.
* [Media Blocks SDK .Net] Added Live Video Compositor API and sample.
* [ALL] Updated Avalonia VideoView control. Resolved issues with video playback on Windows on HighDPI displays.
* [Video Capture SDK .Net] Added CustomVideoFrameRate property to MFOutput. You can set a custom frame rate if your source provides an incorrect frame rate (IP camera, for example).
* [Video Capture SDK .Net] Updated NVENC encoder. Resolved issue with high-definition video capture.
* [Video Capture SDK .Net] Resolved issue with TV Tuning on Avermedia devices
* [Media Blocks SDK .Net] Added OpenCV blocks: CVDewarp, CVDilate, CVEdgeDetect, CVEqualizeHistogram, CVErode, CVFaceBlur, CVFaceDetect, CVHandDetect, CVLaplace, CVMotionCells, CVSmooth, CVSobel, CVTemplateMatch, CVTextOverlay, CVTracker
* [CV] Resolved the issue with wrong face coordinates.
* [CV, Media Blocks SDK .Net] Added Face Detector block.
* [Media Blocks SDK .Net] Added rav1e AV1 video encoder.
* [Media Blocks SDK .Net] Added GIF video encoder.
* [Media Blocks SDK .Net] Added NDI Sink and NDI source blocks.
* [ALL] Resolved NDI SDK detection issues.
* [Media Blocks SDK .Net] Updated Speex encoder.
* [Media Blocks SDK .Net] Updated Video Mixer block.
* [ALL] Added Save/Load methods for output format to serialize into JSON.
* [Media Blocks SDK .Net] Added MJPEG HTTP Live streaming sink block.
* [ALL] Resolved MP4 HW QSV H264 regression.
* [ALL] WinForms and WPF VideoView stability updates.
* [Media Player SDK .Net] Removed FilenamesOrURL legacy property. Please use the `Playlist` API instead.
* [Media Blocks SDK .Net] Added fade-in/out feature for image overlay block.
* [ALL] Telemetry update
* [ALL] SDKs updated to use the `ObservableCollection` instead of the `List` in public API.
* [ALL] Updated MP4 HW output. Improved NVENC performance.
* [Media Blocks SDK .Net] Added Video Compositor sample.
* [Media Blocks SDK .Net] Added YouTubeSink and FacebookLiveSink blocks with custom YouTube/Facebook configurations. The `RTMPSink` can stream to YouTube/Facebook in the same way as before.
* [Media Blocks SDK .Net] Added SqueezeBack video mixer block.
* [ALL] Updated scrolling text logo. We've added the Preload method to render a text overlay before playback.
* [ALL] Updated scrolling text logo (performance)
* [Media Blocks SDK .Net] Updated Decklink sink blocks
* [ALL] Resolved crashes with a text logo with a custom resolution
* [Media Blocks SDK .Net] Added Intel QuickSync H264, HEVC, VP9, and MJPEG encoders support.
* [Video Edit SDK .Net] Added FastEdit_ExtractAudioStreamAsync method to extract the audio stream from the video file.
* [Video Edit SDK .Net] Added "Audio Extractor" WinForms sample.
* [Media Blocks SDK .Net] Updated MP4SinkBlock. The sink can split output files by duration, file size, or timecode. Use MP4SplitSinkSettings instead of MP4SinkSettings to configure.
* [Video Capture SDK .Net] Added the OnMJPEGLowLatencyRAWFrame event that fired when the MJPEG low latency engine received a RAW frame from a camera.
* [Media Blocks SDK .Net] Added VideoEffectsBlock to use video effects, available in Windows SDKs
* [Media Blocks SDK .Net] Updated Decklink source
* [Media Blocks SDK .Net] Added Decklink Demo (WPF)
* [ALL] Resolved the DeinterlaceBlend video effect crash
* [ALL] Used 3rd-party libraries moved to VisioForge.Libs.External assembly/NuGet
* [ALL] Added Nvidia Maxine Video Effects SDK (BETA) and sample app for Media Player SDK .Net and Video Capture SDK .Net
* [Video Capture SDK .Net] Added Decklink_Input_GetVideoFramesCount/Decklink_Input_GetVideoFramesCountAsync API to get total and dropped frames for the Decklink source
* [ALL] VisioForge HW encoders update

## 15.5

* .Net 7 support
* Added NetworkDisconnect event support to MJPEG Low Latency IP camera engine
* Added Linux support for the VideoEditCoreX-based demos
* Added OnRTSPLowLatencyRAWFrame event to get RAW frames from RTSP stream, using RTSP Low Latency engine
* Added AutoTransitions property to the VideoEditCoreX engine
* System.Drawing.Rectangle and System.Drawing.Size types are replaced by VisioForge.Types.Rectangle and VisioForge.Types.Size in all crossplatform APIs
* MAUI samples (BETA) are added
* Improved compatibility with Snap Camera for MP4 HW encoding
* Online licensing updated
* Added Camera Light demo
* Added segments support in Media Player SDK .Net (Cross-platform engine)
* Added Playlist API in Media Player SDK .Net (Windows-only engine)
* Resolved issues with the "rtsp_source_create_audio_resampler" call in the RTSP Low Latency engine in Video Capture SDK .Net (Windows-only engine)
* Added support for multiple Decklink outputs in Video Capture SDK .Net and Video Edit SDK .Net  (Windows-only engine)
* Resolved issues with the reverse playback engine in Media Player SDK .Net (Windows-only engine)
* ONVIFControl and other ONVIF-related APIs are available for all platforms
* API breaking change: the frame rate changed from double to VideoFrameRate in all APIs
* Added GPU HW decoding for VLC engine
* Resolved issue with WPF HighDPI apps that use EVR
* Resolved issue with MediaPlayerCore.Video_Renderer_SetCustomWindowHandle method
* Added previous frame playback in Media Player SDK .Net (Cross-platform engine)
* Added WPF Screen Capture Demo to Media Blocks SDK .Net

## 15.4

* Resolved an issue with ignored Play_PauseAtFirstFrame property
* Updated HighDPI support in WinForms samples
* Resolved an issue with HighDPI support for the Direct2D video renderer
* Added additional API to ONVIFControl class: GetDeviceCapabilities, GetMediaEndpoints
* Resolved forced reencoding issue with FFMPEG files joining without reencoding
* Sentry update
* Added video interpolation settings for Zoom and Pan video effects
* Added GtkSharp UI framework support for video rendering
* FastEdit API has been changed to async
* Resolved screen flip issue with Video_Effects_AllowMultipleStreams property of Video Capture SDK .Net core
* Updated RTSP MultiView demo (added GPU decoding, added RAW stream access)
* Added OnLoop event into Media Player SDK .Net
* Added Loop feature into Media Blocks SDK .Net
* Avalonia VideoView was downgraded to 0.10.12 because of Avalonia UI problems with NativeControl
* Added File Encryptor demo for Video Edit SDK .Net

## 15.3

* App start-up time improved for PCs with Decklink cards
* NDI SDK v5 support
* Resolved an issue with MKV Legacy output (wrong cast exception).
* Zoom and pan effects performance optimizations
* Added basic Media Blocks API (WIP)
* Added HLS network streaming to Video Edit SDK .Net
* Added Rotate property to WPF VideoView. You can rotate the video by 90, 180, or 270 degrees. Also, you can use the GetImageLayer() method to get the Image layer and apply custom transforms
* API change - FilterHelpers renamed to FilterDialogHelper
* VisioForge.Types and VisioForge.MediaFramework assemblies merged into VisioForge.Core
* UI classes moved to VisioForge.Core.UI.* assemblies and independent NuGet packages
* VisioForge.Types renamed to VisioForge.Core.Types
* VisioForge.Core no longer depends on the Windows Forms framework

## 15.2

* Added HorizontalAlignment and VerticalAlignment properties to the text and image logos
* Updated ONVIF support, resolved an issue with username and password specified in URL but not specified in source settings
* Resolved an issue with the FFMPEG.exe output dialog
* Resolved an issue with the separate capture in a service applications
* SDK migrated to System.Text.Json from NewtonsoftJson
* Updated DirectCapture output for IP cameras
* Video processing performance optimizations
* IPCameraSourceSettings.URL property type changed from string to a `System.Uri`
* Added DirectCapture ASF output for IP cameras

## 15.1

* Disabled Sentry debug messages in the console
* Added Icecast streaming
* VideoStreamInfo.FrameRate property type changed to VideoFrameRate (with numerator and denominator) from double
* Updated WPF VideoView, resolved the issue for IP camera stream playback
* API breaking change: `VisioForge.Controls`, `VisioForge.Controls.UI`, `VisioForge.Controls.UI.Dialogs`, and `VisioForge.Tools` assemblies are merged inside the `VisioForge.Core` assembly
* Audio effect API now uses string name instead of index
* Added Android support in Media Player SDK .Net
* Added a new GStreamer-based cross-platform engine to support Windows and other platforms within the v15 development cycle

## 15.0

* Added StatusOverlay property for VideoCapture class. Assign the `TextStatusOverlay` object to this property to add text status overlay, for example, to show "Connecting..." text during IP camera connecting.
* RTSP Live555 IP camera engine has been removed. Please use RTSP Low Latency or FFMPEG engines.
* Resolved SDK_Version possible issue.
* Added Settings_Load API. You can load the settings file saved by Settings_JSON. Be sure that device names are correct.
* Resolved issue with an exception if separate capture started before Start/StartAsync method call.
* RTP support for the VLC source engine.
* API breaking change: SDK_State property has been removed. We do not have TRIAL and FULL SDK versions anymore.
* API breaking change: DirectShow_Filters_Show_Dialog, DirectShow_Filters_Has_Dialog, Audio_Codec_HasDialog, Audio_Codec_ShowDialog, Video_Codec_HasDialog, Video_Codec_ShowDialog, Filter_Supported_LAV, Filter_Exists_MatroskaMuxer, Filter_Exists_OGGMuxer, Filter_Exists_VorbisEncoder, Filter_Supported_EVR, Filter_Supported_VMR9 and Filter_Supported_NVENC has been moved to VisioForge.Tools.FilterHelpers class.
* The `VFAudioStreamInfo`/`VFVideoStreamInfo` classes use the `Timespan` for the duration.
* Decklink types from VisioForge.Types assembly moved to VisioForge.Types.Decklink namespace.
* Telemetry updated.
* Custom redist loader updated.
* NDI update.
* API breaking change: The `Status` property was renamed to the `State`. The property type is `PlaybackState` in all SDKs.
* API breaking change: UI controls split into Core (VideoCaptureCore, MediaPlayerCore, VideoEditCore) and VideoView.
* API breaking change: Video_CaptureDevice... properties merged into Video_CaptureDevice property of VideoCaptureSource type.
* API breaking change: Audio_CaptureDevice... properties merged into Audio_CaptureDevice property of AudioCaptureSource type.
* API breaking change: In the Media Player SDK, the `Source_Stream` API properties were merged into the `Source_MemoryStream` property of the `MemoryStreamSource` type
* Updated DVD playback
* Updated FFMPEG source
* API breaking change: Media Player SDK types moved from VisioForge.Types namespace to VisioForge.Types.MediaPlayer
* API breaking change: Video Capture SDK types moved from VisioForge.Types namespace to VisioForge.Types.VideoCapture
* API breaking change: Video Edit SDK types moved from VisioForge.Types namespace to "VisioForge.Types.VideoEdit"
* API breaking change: Output types moved from VisioForge.Types namespace to VisioForge.Types.Output
* API breaking change: Video Effects types moved from VisioForge.Types namespace to VisioForge.Types.VideoEffects
* API breaking change: Audio Effects types moved from VisioForge.Types namespace to VisioForge.Types.AudioEffects
* API breaking change: Event types moved from VisioForge.Types namespace to VisioForge.Types.Events
* Added Video_Renderer_SetCustomWindowHandle method to set custom video renderer by Win32 window/control HWND handle

## 14.4

* Windows 11 support
* Telemetry update
* Resolved issues with Picture-in-Picture in 2x2 mode
* Resolved issues with MJPEG Low Latency source in .Net 5/.Net 6/.Net Core 3.1
* Resolved issue with UDP network streaming for Decklink source
* VFMP4v11Output renamed to VFMP4HWOutput
* Added Microsoft H265 encoder support
* Added Intel QuickSync H265 encoder support
* Added OnDecklinkInputDisconnected/OnDecklinkInputReconnected events
* Updated Decklink output
* Resolved issues with Separate capture for MP4 HW, MOV, MPEG-TS, and MKVv2 outputs
* Added Video_CaptureDevice_CustomPinName property. You can use this property to set a custom output pin name for a video capture device with several output video pins
* Custom redist configuration updated
* Updated IP camera RTSP Low Latency engine

## 14.3

* An issue with Video Resize filter creation for NuGet redists has been resolved
* Telemetry update
* Updated VFDirectCaptureMP4Output output
* .Net 6 (preview) support
* Nvidia CUDA removed. NVENC is a modern alternative and is available for H264/HEVC encoding.
* IP camera MJPEG Low Latency engine has been updated
* The NDI source listing has been updated
* Improved ONVIF support
* Added .Net Core 3.1 support for RTSP Low Latency source engine
* Resolved issues with Picture-in-Picture for 2x2 mode
* Split project and solutions by independent files for .Net Framework 4.7.2, .Net Core 3.1, .Net 5 and .Net 6

## 14.2

* An issue with audio stream capture with enabled Virtual Camera SDK output was resolved
* VFMP4v8v10Output was replaced with VFMP4Output
* The "CanStart" method was added for Video_CaptureDevices items. The method returns true if the device can start and is not used exclusively in another app
* Added async/await API to the ONVIFControl
* An issue with wrong ColorKey processing in the Text Overlay video effect was resolved
* Added forced frame rate support for the RTSP Low Latency IP camera source
* MP4v11 AMD encoders were updated
* The timestamp issue that happened during the MP4v11 separate capture pause/resume was resolved
* FFMPEG.exe network streaming update
* FFMPEG output was updated to the latest FFMPEG version
* VC++ redist is no longer required to be installed. VC++ linking changed to static (except optional XIPH output)
* Many base DirectShow filters moved to the VisioForge_BaseFilters module

## 14.1

* Added WPF VideoView control. You can push video frames from the OnVideoFrameBuffer event to control to render them
* Correct default transparency value for a text logo
* ONVIF support added to .Net 5 / .Net Core 3.1 builds
* Added IP_Camera_ONVIF_ListSourcesAsync method to discover ONVIF cameras in the local network
* (BREAKING API CHANGE) Changed video capture device API for frame rates enumerating to support modern 4K cameras
* Updated MJPEG Decoder (improved performance)
* Removed MP4 v8 legacy encoders
* INotifyPropertyChanged support in WinForms/WPF wrappers to provide MVVM application support
* Resolved issue with RTMPS streaming to Facebook
* IP camera source added to the TimeShift demo
* Added separate output support for MOV
* Added fast-start FFMPEG flag for MP4v11 output that used FFMPEG MP4 muxer
* Added GPU decoding for the IP Camera source in demo applications
* Added CustomRedist_DisableDialog property to disable the redist message dialog
* Removed Kinect assemblies and demos. Please contact us if you still need Kinect packages
* MP4v10 default profile has been changed to Baseline / 5.0 for better browser compatibility

## 14.0

* .Net 5.0 support
* Resolved issue with not visible Decklink sources in NuGet SDK version
* Resolved issue with device added/removed notifier
* Added alternative NDI source in Video Capture SDK .Net
* Added NDI streaming (server) in Video Capture SDK .Net
* Resolved Separate Capture usage issue for NuGet deployment
* Resolved issue with merged text/image logos
* Updated device notifier
* Added CameraPowerLineControl class to control webcam power line frequency option
* Legacy audio effects have been removed.
* Removed HTTP_FFMPEG, RTSP_UDP_FFMPEG, RTSP_TCP_FFMPEG and RTSP_HTTP_FFMPEG from VFIPSource enumeration. You can use the Auto_FFMPEG value
* Updated HLS server. Correct error reporting about used port
* Added NDI streaming (server) in Video Edit SDK .Net
* Added NDI streaming (server) in Media Player SDK .Net
* Added IP_Camera_CheckAvailable method in Video Capture SDK .Net
* Updated FFMPEG Source filter, more supported codecs, and added GPU decoding

## 12.1

* Migrated to .Net 4.6
* Added Debug_DisableMessageDialogs property to disable error dialog if OnError event is not implemented.
* Fixed issue with resizing on the pause for WPF controls.
* Updated ONVIF engine in Video Capture SDK .Net
* Updated What You Hear source in Video Capture SDK .Net
* Added OnPause/OnResume events
* Updated YouTube demo in Media Player SDK .Net
* Improved support of webcams with integrated H264 encoder in Video Capture SDK .Net
* Updated VLC source
* Removed unwanted warning in MP4 v11 output
* One installer for TRIAL and FULL versions
* Same NuGet packages for TRIAL and FULL versions
* .Net Core NuGet packaged merged with .Net Framework package
* Added NuGet redists. Deployment was never so simple!

## 12.0

* Async / await API for all SDKs
* Breaking API change: All time-related API now uses TimeSpan instead of long (milliseconds)
* Tag reader/writer - correct logo loading for some video formats
* Removed legacy DirectX 9 video effects
* Fixed audio conversion progress issue in Video Edit SDK .Net
* Improved .Net Core compatibility
* Virtual Camera SDK output added to Media Player SDK .Net (as one of the video renderers)
* NewTek NDI devices support added to Video Capture SDK .Net as a new engine for IP cameras
* Added Video_Effects_MergeImageLogos and Video_Effects_MergeTextLogos properties. If you have three or more logos, you can set these properties to true to optimize video effects' performance
* Added playlist type option for HLS network streaming
* Added integrated lightweight HTTP server for HLS network streaming
* Added VR 360° video support in Media Player SDK .Net
* Improved DirectX 11 video processing
* Added MPEG-TS AAC-only no video support for MPEG-TS output
* Improved What You Hear audio source
* Several new demo applications
* Improved MP4 v11 output
* Separate capture for MP4 v11 can split files without frame lose
* Many minor bugfixes
* .Net Core assemblies updated to .Net Core 3.1 LTS
* Updated demos repository on GitHub

## 11.4

* Added ASP.Net MVC video conversion demo app to Video Edit SDK .Net
* Alternative OSD implementation to handle Windows 10 changes
* Updated GPU video effects
* Updated memory source in Media Player SDK .Net
* Updated OSD API
* Resolved issues with video encryption using binary keys
* Update screen capture demos for Video Capture SDK .Net, added window selection to capture. You can capture any window, including windows in the background
* Mosaic effect added for Computer Vision demo in Video Capture SDK .Net
* Added Multiple IP Cameras Demo (WPF) in Video Capture SDK .Net
* Added custom video resize option for MP4v11 output
* Merge module (MSM) redists added to all SDKs
* Updated FFMPEG.exe output using pipes instead of virtual devices
* Resolved issue with PIP custom output resolution option in Video Capture SDK .Net
* Resolved issue with file lock using LAV engine in Media Player SDK .Net
* Added DirectX11-based GPU video processing

## 11.3

* Resolved issue with audio renderer connection if Virtual Camera SDK output enabled in Video Capture SDK
* Improved subtitles support with autoloading in Media Player SDK .Net
* Updated audio fade-in/fade-out effects
* Added MIDI and KAR files support in Media Player SDK .Net
* Added CDG karaoke files support (and new demo application) in Media Player SDK .Net
* Added Async playback in Media Player SDK .Net
* Updated integrated JSON serializer
* Added optional GPU decoding in Media Player SDK .Net. Available decoding engines: DXVA2, Direct3D 11, nVidia CUVID, Intel QuickSync
* Added .Net Core 3.0 support, including WinForms and WPF demo apps (Windows only)

## 11.2

* Added Loop property to Video Edit SDK .Net
* Updated audio enhancer
* Updated RTSP Low Latency source
* Resolved crop issue for Decklink source
* Added property to use TCP or UDP in RTSP Low Latency engine
* Deployment without COM registration and admin rights for Video Edit SDK and Media Player SDK (BETA)
* Updated video mixer with improved performance
* Added YouTube playback code snippet
* Added method to move OSD

## 11.1

* Fixed seeking issue with some MP4 files in Video Edit SDK
* Fixed stretch/letterbox issue in the WPF version of all SDKs
* Fixed issue with an equalizer on sample rate 16000 or less
* Fixed problem with sample grabber for DirectShow source in Media Player SDK
* Fixed encrypted files playback in Media Player SDK
* Added DVDInfoReader class to read info about DVD files
* Resolved issue with wrong file name in OnSeparateCaptureStopped event
* Improved barcode detection quality for rotated images
* The minimal .Net Framework version is .Net 4.5 now
* Improved YouTube playback in Media Player SDK. Added OnYouTubeVideoPlayback event to select video quality for playback
* Added the `Play_PauseAtFirstFrame` property to the Media Player SDK .Net. If true playback will be paused on the first frame
* Multiple screen support in Screen Capture demo in Video Capture SDK .Net
* Resolved issue with network stream playback in Media Player SDK .Net WPF applications
* Added low latency HTTP MJPEG stream playback (IP cameras or other sources) in Video Capture SDK .Net
* Added Fake Audio Source DirectShow filter, which produces a tone signal
* Updated Computer Vision demo in Video Capture SDK .Net
* Added Frame_GetCurrentFromRenderer method to all SDKs. Using this method, you can get the currently rendered video frame directly from the video renderer.
* Added low latency RTSP source playback in Video Capture SDK .Net

## 11.0

* Fixed bug with MP4 v11 output, custom GOP settings
* Updated MJPEG Decoder
* Fixed bug with MP4 v11 output. Added Windows 7 full support
* OnStop event of Video Edit SDK returns a successful status
* Video Capture SDK Main Demo update - multiscreen can automatically use connected external displays
* Media Player SDK Main Demo update - multiscreen can automatically use connected external displays
* Added fade-in / fade-out for text logo
* Updated Decklink output
* Video Edit SDK can fast-cut files from network sources (HTTP/HTTPS)
* Added Computer Vision demo, with cars/pedestrian counter and face/eyes/nose/mouth detector/tracker
* Updated MP4 output to use alternative muxer that provides constant frame rate
* Added MPEG-TS output
* Added MOV output
