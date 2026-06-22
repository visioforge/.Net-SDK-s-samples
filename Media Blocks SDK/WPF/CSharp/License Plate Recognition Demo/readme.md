# Media Blocks SDK .Net - License Plate Recognition (ANPR) Demo (C#/WPF)

Reads vehicle number plates from a webcam, video file, or RTSP/IP-camera stream using the
`LicensePlateRecognizerBlock`. The block runs a specialized two-stage pipeline: a dedicated
license-plate detector (YOLOv9-T) locates plates in the frame, then a plate-specific OCR model
reads the characters of each cropped plate. Recognition runs on a background thread, so live video
never stalls.

## Run

1. Build and run. The MIT-licensed FastALPR models ship next to the executable and are pre-selected
   on the **ANPR models** tab:
   - `yolo-v9-t-640-license-plates-end2end.onnx` — plate detector.
   - `cct_s_v1_global.onnx` — global OCR head (USA + 90+ countries).
   - `european_mobile_vit_v2_ocr.onnx` — European OCR head.
2. Pick a **Region** (Global or Europe) on the **ANPR models** tab to choose the OCR head.
3. Tune detection / OCR confidence and the frame-skip rate on the **Settings** tab.
4. Pick a source, press **Start**, and watch recognized plates on the **Plates** tab (and drawn over
   the video when enabled).

## Models

The models come from the FastALPR family (MIT):

- Detector — [open-image-models](https://github.com/ankandrew/open-image-models)
- OCR heads — [fast-plate-ocr](https://github.com/ankandrew/fast-plate-ocr)
