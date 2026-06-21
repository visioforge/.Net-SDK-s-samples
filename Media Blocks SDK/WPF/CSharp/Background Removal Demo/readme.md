# Background Removal Demo (WPF)

Real-time AI background removal (matting) with the VisioForge Media Blocks SDK .Net.
The demo runs an ONNX segmentation model on the live video and replaces the background
with a blur of the original, a solid color, a static image, or transparency.

## What it shows

- The new **`BackgroundRemovalBlock`** (`VisioForge.Core.MediaBlocks.AI`) inserted between a
  video source and the renderer: `source → BackgroundRemovalBlock → VideoRendererBlock`.
- All four replacement modes: **Blur**, **Solid color**, **Image**, and **Transparent (alpha)**.
- Running the matting model less often (`Frames to skip`) while still compositing the cached
  matte on every frame, so the background never flickers.

## Pipeline

```text
SystemVideoSourceBlock / UniversalSourceBlock / RTSPSourceBlock
        │
        ▼
BackgroundRemovalBlock   (ONNX matting model → foreground alpha → background replaced in-place)
        │
        ▼
VideoRendererBlock (VideoView)
```

## Models

The SDK does not ship model weights. Pick a model on the **Background** tab:

- **PP-MattingV2** (PaddleSeg, Apache-2.0) — recommended default. Real-time human matting,
  faster and more accurate than MODNet; runs in real time on a DirectML GPU.
- **MODNet** (portrait matting, Apache-2.0) — lightweight, real-time on CPU or GPU.
- **Custom model…** — browse to any single-channel-alpha `.onnx`.

The SDK also supports BiRefNet (MIT) for higher-quality offline/batch matting, but it is far
too heavy for live preview (~1 fps even on a GPU), so it is not offered in this live demo.

Use **Download** to fetch a model into `%USERPROFILE%\VisioForge\models`, or **Browse…** to
point at a local `.onnx`. The execution provider (DirectML GPU on Windows, CPU fallback) is
selected automatically and printed to the log.

## Requirements

- Windows, .NET 10, x64.
- A DirectX 12 GPU is used automatically when present (DirectML); otherwise it runs on the CPU.
