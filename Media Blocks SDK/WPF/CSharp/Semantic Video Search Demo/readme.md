# Media Blocks SDK .Net - Semantic Video Search Demo (C#/WPF)

Indexes a video by **CLIP image embeddings** and then searches it with a natural-language query, using the
`VideoEmbeddingBlock`. Every sampled frame is turned into an embedding and added to an in-memory index; a
text query ("a person on a bike", "a red car at night") is embedded into the same space and matched by
cosine similarity, so you can jump straight to the moments that look like the query — no object classes or
keywords required.

## Run

1. On the **Models** tab, press **Download** to fetch the four CLIP files (cached under
   `%USERPROFILE%/VisioForge/models/clip`), or point the boxes at your own model:
   - `clip-vitb32-vision.onnx` — CLIP image (vision) encoder.
   - `clip-vitb32-text.onnx` — CLIP text encoder.
   - `clip-vocab.json`, `clip-merges.txt` — CLIP byte-level BPE tokenizer.
2. On the **Index** tab, pick a video file and press **Index** to embed its frames (about one frame per
   second). The progress bar and frame count update as it runs. You can **Save** the index to a `.vfei`
   file and **Load** it back later to skip re-indexing.
3. On the **Search** tab, type a query and press **Search**. Results appear as ranked thumbnails with a
   timestamp and similarity score; click one to preview the source video at that moment.

## Models

Both towers share one embedding space, so an image and a text query are directly comparable by cosine
similarity. All embeddings are L2-normalized. The **Download** button fetches the files from the
VisioForge samples release. Model weights are **not** shipped with the SDK NuGet packages — they are
downloaded on first use and cached under `%USERPROFILE%/VisioForge/models/clip`.
