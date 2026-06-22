# Media Blocks SDK .Net - OCR Text Recognition Demo (C#/WPF)

Recognizes text in a webcam, video file, or RTSP/IP-camera stream using the `OcrBlock`
(multi-stage PaddleOCR PP-OCR ONNX pipeline: text detection → angle classification → recognition).

## Run

1. Build and run. The Apache-2.0 PP-OCRv5 mobile models (`*_det.onnx`, `*_cls_infer.onnx`,
   `*_rec_mobile_infer.onnx`) and the Latin dictionary (`ppocrv5_latin_dict.txt`) ship next to the
   executable and are pre-selected on the **OCR** tab.
2. Pick a source on the **Source** tab, press **Start**, and watch the recognized text appear on
   the **Recognized text** tab (and, if enabled, drawn over the video).

## Models

The bundled models recognize Latin text. To recognize another language, download the matching
PP-OCRv5 recognition model and its dictionary (Apache-2.0) and select them on the **OCR** tab.
The block runs on the CPU or, when available, the GPU (DirectML on Windows, CoreML on Apple, CUDA).
