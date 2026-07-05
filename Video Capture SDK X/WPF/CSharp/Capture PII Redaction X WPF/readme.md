# Capture PII Redaction demo (VideoCaptureCoreX, WPF)

Redacts personally identifiable information — faces, license plates, and on-screen text —
on the live `VideoCaptureCoreX` camera preview.

The `PIIRedactionBlock` is inserted into the engine through the one-line
`Video_Processing_AddBlock(...)` API. The block taps the camera frames, blurs / pixelates /
fills the detected regions in place, and raises `OnRegionsRedacted`, all while the engine
renders the live preview.

## Usage

1. Pick a camera on the **Source** tab (it opens at an HD or best-available format).
2. On the **Redaction** tab choose which categories to redact (faces / plates / text), the
   redaction style (Gaussian blur, pixelate, solid fill), and the strength. Categories and
   style can be toggled live while capture runs.
3. On the **Models** tab press **Download all models** to fetch the face, plate, and text
   models on first run (cached under `%USERPROFILE%\VisioForge\models`), or use the **...**
   buttons to browse to your own.
4. Press **Start**.

## Models

All models are downloaded on demand from the SDK samples GitHub release into
`%USERPROFILE%\VisioForge\models`:

- Face detector — YuNet (MIT).
- License plate detector — FastALPR YOLOv9-T (MIT).
- On-screen text — PP-OCRv5 detection + recognition + dictionary (Apache-2.0). Recognition
  filters out non-text detections; leave the regex empty to redact all text, or enter a
  pattern (e.g. an e-mail regex) to redact only matches.

Model weights are **not** shipped inside the SDK / NuGet packages.

## Notes

- Frames before the first detection cycle pass through unredacted.
- The engine owns the inserted block once started and disposes it on stop; a fresh block is
  created for every capture session.
