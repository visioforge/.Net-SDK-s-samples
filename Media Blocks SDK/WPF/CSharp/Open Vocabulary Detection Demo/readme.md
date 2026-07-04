# Media Blocks SDK .Net - Open Vocabulary Detection Demo (C#/WPF)

Detects objects described by **free-text prompts** instead of a fixed class list, using the
`OpenVocabularyDetectorBlock`. Type prompts like `a person`, `a red car`, or `a dog on a leash`, and the
block draws a box around every matching object. Two model families are supported: **OWLv2** and
**Grounding DINO**. Inference runs on a background thread, so live video never stalls, and prompts can be
changed at runtime without restarting the pipeline.

## Run

1. On the **Model** tab, pick a model family (OWLv2 or Grounding DINO) and press **Download** to fetch the
   ONNX models (cached under `%USERPROFILE%/VisioForge/models/openvocab`), or point the boxes at your own
   files.
2. On the **Prompts** tab, add one or more free-text prompts (start with the defaults `a person` /
   `a car`). Use **Apply** to swap the prompt set while the pipeline is running.
3. On the **Settings** tab, tune the confidence threshold and the frame-skip rate (open-vocabulary models
   are heavier than YOLO, so skipping frames keeps playback smooth).
4. Pick a source on the **Source** tab, press **Start**, and watch labeled boxes drawn over the video.
   Each detection's label is the matched prompt and its class id is that prompt's zero-based index, so the
   block can also feed an `ObjectAnalyticsBlock` for tripwire / zone analytics.

## Models

| Family | Files | Notes |
|--------|-------|-------|
| OWLv2 | `owlv2-base-ensemble.onnx`, `owlv2-vocab.json`, `owlv2-merges.txt` | CLIP-style byte-level BPE tokenizer (vocab + merges). |
| Grounding DINO | `grounding-dino-tiny.onnx`, `bert-vocab.txt` | BERT WordPiece tokenizer (vocab only, no merges). |

The **Download** button fetches the selected family from the VisioForge samples release. Model weights are
**not** shipped with the SDK NuGet packages — they are downloaded on first use and cached under
`%USERPROFILE%/VisioForge/models/openvocab`.
