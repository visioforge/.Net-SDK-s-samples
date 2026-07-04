# Media Blocks SDK .Net - VLM Captioning Demo (C#/WPF)

Runs the **Florence-2** vision-language model on video frames using the `VLMBlock`. Depending on the
selected task the model can caption the scene, detect objects, run OCR, or ground a phrase (draw a box
around the region a piece of text refers to). Generation is expensive, so it runs on a background thread
throttled by a processing interval; other frames just redraw the most recent result over the video.

## Run

1. On the **Model** tab, press **Download** to fetch the Florence-2 ONNX model set (cached under
   `%USERPROFILE%/VisioForge/models/vlm`), or point the folder box at your own copy.
2. On the **Settings** tab, pick a **Task**:
   - **Caption** / **DetailedCaption** / **MoreDetailedCaption** — describe the whole frame in text.
   - **ObjectDetection** — detect and label objects with boxes.
   - **OCR** / **OcrWithRegion** — read text in the frame.
   - **PhraseGrounding** — type a phrase in the **Text input** box and the model boxes the region it
     refers to.
   Tune the processing interval and the max generated tokens for your hardware.
3. Pick a source on the **Source** tab, press **Start**, and watch captions, boxes, or recognized text
   drawn over the video.

## Models

Florence-2 is a four-part ONNX pipeline (vision encoder, token embedder, text encoder, and a merged
autoregressive decoder) plus a BART byte-level BPE tokenizer:

| File | Role |
|------|------|
| `florence2-base-vision-encoder.onnx` | Image feature encoder. |
| `florence2-base-embed-tokens.onnx` | Token embedder. |
| `florence2-base-encoder.onnx` | Text encoder. |
| `florence2-base-decoder-merged.onnx` | Autoregressive decoder (greedy / argmax). |
| `florence2-vocab.json`, `florence2-merges.txt`, `florence2-added-tokens.json` | BART tokenizer (vocab, merges, and the `<loc_N>` / task special tokens). |

The **Download** button fetches the full set from the VisioForge samples release. Model weights are
**not** shipped with the SDK NuGet packages — they are downloaded on first use and cached under
`%USERPROFILE%/VisioForge/models/vlm`.
