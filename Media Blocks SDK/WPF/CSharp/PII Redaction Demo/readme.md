# Media Blocks SDK .Net - PII Redaction Demo (C#/WPF)

Automatically obscures personally identifiable information in live video from a webcam, video file,
or RTSP/IP-camera stream using the `PIIRedactionBlock`. Three PII categories are detected and
redacted, each individually toggleable — even while the pipeline runs:

- **Faces** — YuNet face detector (MIT).
- **License plates** — FastALPR YOLOv9-T plate detector (MIT). Detection only: plate characters are
  never read.
- **On-screen text** — PP-OCRv5 detection + recognition (Apache-2.0). Recognition always runs: it is what
  filters the detector's false positives (on a real scene the detector alone fires on textures and edges), so
  the detection, recognition, and dictionary models are all required when the text category is enabled. By
  default every recognized text region is redacted; an optional **text filter regex** narrows this to only the
  matching regions (e.g. `[\w.+-]+@[\w-]+\.[\w.]+` for e-mail addresses).

Redaction styles: **Gaussian blur**, **Pixelate** (mosaic), and **Solid fill** — switchable live.
Detection runs on a background worker so live video never stalls; the streaming thread redacts every
frame with the most recent regions, expanded by a configurable padding and held for a configurable
time after the detector last reported them, so regions stay covered through motion and detector
flicker.

## Run

1. On the **Models** tab the plate and text models are pre-filled (they ship next to the demo
   executable). Press **Download** to fetch the YuNet face detector (cached under
   `%USERPROFILE%/VisioForge/models`), or point the box at your own model.
2. On the **Redaction** tab pick the categories, the style, and tune the blur radius / mosaic size /
   fill color. Optionally enter a text filter regex to redact only matching text.
3. Pick a source on the **Source** tab and press **Start**. Detected region counts are listed on the
   **Events** tab.

## Models

| Stage | File | License | Source |
|-------|------|---------|--------|
| Face detector | `face_detection_yunet_2023mar.onnx` | MIT | [OpenCV Zoo — face_detection_yunet](https://github.com/opencv/opencv_zoo/tree/main/models/face_detection_yunet) |
| Plate detector | `yolo-v9-t-640-license-plates-end2end.onnx` | MIT | [FastALPR / open-image-models](https://github.com/ankandrew/open-image-models) |
| Text detection | `ch_PP-OCRv5_mobile_det.onnx` | Apache-2.0 | [PaddleOCR PP-OCRv5](https://github.com/PaddlePaddle/PaddleOCR) |
| Text recognition (always required for text) | `latin_PP-OCRv5_rec_mobile_infer.onnx` + `ppocrv5_latin_dict.txt` | Apache-2.0 | [PaddleOCR PP-OCRv5](https://github.com/PaddlePaddle/PaddleOCR) |

Model weights are **not** shipped with the SDK NuGet packages.

## Notes

- Frames arriving before the first detection cycle completes pass through unredacted. For
  guaranteed-complete redaction of a file, play it at reduced speed (or process offline) rather than
  redacting a live view.
- The event log reports only categories and box counts — recognized content (plate numbers, text)
  is never exported by the block.
