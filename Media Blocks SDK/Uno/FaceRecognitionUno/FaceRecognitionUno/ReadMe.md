# Face Recognition Uno - Media Blocks SDK

This sample demonstrates real-time face recognition from a live camera using the VisioForge Media Blocks SDK with Uno Platform. The pipeline is `camera -> FaceRecognitionBlock -> video renderer`; detected faces are boxed and labelled with the matched identity on the preview.

## Features

- Live camera preview with on-frame face detection and recognition overlay
- Enroll people from a gallery photo (name + picture), persisted across runs
- Save / load the face gallery (`.vfg`) with an embedding-family sidecar
- Switchable embedding model: SFace (128-D) or AuraFace (512-D, ArcFace)
- Models (YuNet detector + embedder) downloaded on demand
- Android-focused; also cross-targets Windows

## How to use

1. Tap **DOWNLOAD MODELS** (first run only).
2. Enter a name, tap **ENROLL PHOTO** and pick a clear front-facing photo.
3. Tap **START** - point the camera at the enrolled person; the overlay shows the name and match score.
4. Optionally **SAVE GALLERY** to reuse the enrolled identities next time.

## Product Page

[VisioForge Media Blocks SDK .NET](https://www.visioforge.com/media-blocks-sdk-net)

## Requirements

- .NET 10.0
- Uno Platform 6.4+
- Android API 24+ (required by ONNX Runtime)
- VisioForge SDK license for production use
