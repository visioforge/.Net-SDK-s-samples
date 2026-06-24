# Face Recognition CLI (Media Blocks SDK)

Console version of the Face Recognition demo. It runs the `FaceRecognitionBlock` over a video file in two
stages:

1. **Discovery / enrollment** (`--enroll N`) — scans the video with an empty gallery, collects every face
   embedding, clusters them by cosine similarity, and enrolls the `N` most frequent, mutually-distinct people
   as `Person 01..NN`. The gallery is saved next to the video as `faces.vfg`.
2. **Recognition** — matches faces against the gallery, burns boxes + names + landmarks into an annotated
   `*_faces.mp4`, and prints per-identity hit counts.

The two-stage pipeline (YuNet detector → align → SFace embedding → 1:N gallery match) runs on CPU/CUDA/
DirectML/CoreML through ONNX Runtime. Model weights are **not** shipped with the SDK; on first run the
detector (YuNet, MIT) and embedder (SFace, Apache-2.0) are downloaded to `%USERPROFILE%\VisioForge\models`.

## Usage

```text
FaceRecognitionCLI <video> [options]

  --enroll N           Auto-discover and enroll the N most frequent distinct faces (default 0).
  --gallery <file.vfg> Gallery to load instead of auto-enrolling; also the save target. When omitted, the
                       auto-built gallery is saved next to the video as faces.vfg.
  --out <file.mp4>     Annotated output path (default <video>_faces.mp4).
  --threshold T        Recognition cosine threshold (default 0.36).
  --det-confidence T   Detector confidence threshold (default 0.6).
  --min-cluster N      Minimum samples for an auto-enrolled identity (default 4).
  --skip N             Frames to skip between recognitions in the output pass (default 0).
  --discovery-skip N   Frames to skip during discovery (default 2).
  --timeout S          Per-pass timeout in seconds (default 1800).
  --audio              Mux the source audio into the annotated output (off by default; output is video-only).
```

## Example

```text
FaceRecognitionCLI clip.mp4 --enroll 5
```

Discovers the 5 most frequent faces in `clip.mp4`, enrolls them, and writes `clip_faces.mp4` with each
recognized person labelled.
