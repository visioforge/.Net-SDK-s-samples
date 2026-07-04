# Media Player SDK X .Net — Player Semantic Video Search X (C#/WPF)

Indexes a video file into **CLIP image embeddings** with **MediaPlayerCoreX**, then searches it with a
natural-language query. A `VideoEmbeddingBlock` is inserted into the player through the X-engine
processing-block API, and the player is run **unsynchronized** so the file is indexed at full decode
speed instead of in real time:

```csharp
_player = new MediaPlayerCoreX(VideoView1);
_player.Video_Renderer_IsSync = false;   // index at full decode speed (set BEFORE OpenAsync)

var source = await UniversalSourceSettings.CreateAsync(filePath, renderVideo: true, renderAudio: false);
await _player.OpenAsync(source);

var settings = new VideoEmbeddingSettings(vision, text, vocab, merges)
{
    Provider = provider,
    Index = index,
    SourceTag = filePath,
    SampleInterval = TimeSpan.FromSeconds(1.0 / fps),
    BackpressureNoDrop = true,            // 0 dropped samples
};

var embeddingBlock = new VideoEmbeddingBlock(settings);
embeddingBlock.OnFrameEmbedding += (s, e) => { /* progress */ };
_player.Video_Processing_AddBlock(embeddingBlock);   // add BEFORE PlayAsync
await _player.PlayAsync();
// At end-of-file the player raises OnStop -> finish indexing and reset the button.
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches its event
handler and drops the reference; a fresh block is created for the next run.

## Run

1. On the **Models** tab, press **Download** to fetch the four CLIP files (cached under
   `%USERPROFILE%/VisioForge/models/clip`), or point the boxes at your own model:
   - `clip-vitb32-vision.onnx` — CLIP image (vision) encoder.
   - `clip-vitb32-text.onnx` — CLIP text encoder.
   - `clip-vocab.json`, `clip-merges.txt` — CLIP byte-level BPE tokenizer.
2. On the **Index** tab, pick a video file and press **Index**. The file races by in the preview while its
   frames are embedded; the progress bar and frame count update as it runs. You can **Save** the index to a
   `.vfei` file and **Load** it back later to skip re-indexing.
3. On the **Search** tab, type a query and press **Search**. Results appear as ranked thumbnails with a
   timestamp and a contrastive-margin score.

## How search works

Both CLIP towers share one embedding space, so an image and a text query are directly comparable by cosine
similarity (all embeddings are L2-normalized). Frames are ranked by a **contrastive margin** — the query's
cosine minus the best cosine of a set of generic "background" prompts — which cancels CLIP's per-prompt bias
so that a query for an absent concept returns nothing. The **Min margin** slider controls the threshold.

Search is decoupled from the player (it uses a standalone `ClipEmbeddingEngine`), so it keeps working after
indexing finishes and the player has been torn down.

## Models

Model weights are **not** shipped with the SDK NuGet packages — they are downloaded on first use and cached
under `%USERPROFILE%/VisioForge/models/clip`.

Windows / WPF (`net10.0-windows`).
