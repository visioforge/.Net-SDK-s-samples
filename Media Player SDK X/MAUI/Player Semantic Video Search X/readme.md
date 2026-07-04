# Media Player SDK X .Net — Player Semantic Video Search X (C#/MAUI)

Indexes a video file into per-frame **CLIP embeddings** with **MediaPlayerCoreX**, then finds the moments
that best match a natural-language query — for example "a red car", "a person waving", or "sunset over
water". A `VideoEmbeddingBlock` is inserted into the player through the X-engine processing-block API, and
the player is run **unsynchronized** so the file is indexed at full decode speed instead of in real time:

```csharp
_player = new MediaPlayerCoreX(videoView.GetVideoView());
_player.Video_Renderer_IsSync = false;   // index at full decode speed (set BEFORE OpenAsync)

var source = await UniversalSourceSettings.CreateAsync(filePath, renderVideo: true, renderAudio: false);
await _player.OpenAsync(source);

var settings = new VideoEmbeddingSettings(vision, text, vocab, merges)
{
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

## How it works

A `VideoEmbeddingBlock` taps sampled frames (one per second by default), encodes each into an
L2-normalized CLIP image embedding on a background worker, and appends it to a shared `FrameEmbeddingIndex`.
With `Video_Renderer_IsSync = false` and `BackpressureNoDrop = true`, the file decodes faster than real time
and no sample is dropped.

To search, a standalone `ClipEmbeddingEngine` encodes your query with the CLIP **text** tower into the same
space, and frames are ranked by a **contrastive margin** — the query's cosine minus the best cosine of a set
of generic "background" prompts — which cancels CLIP's per-prompt bias so a query for an absent concept
returns nothing. The **Min margin** slider controls the threshold. Search is decoupled from the player, so
it keeps working after indexing finishes and the player has been torn down.

## Features

- **Semantic search** over a picked video file.
- **Cross-Platform**: Windows, Android, iOS, and macOS (Mac Catalyst).
- **CLIP ViT-B/32** dual-tower model (vision + text) via ONNX Runtime.
- **Persistable index**: Save the in-memory index to a `.vfei` file and Load it back later.
- **Live preview** of the file while it is indexed at full speed.

## Models

Model weights are **not** bundled with the app (they are large) — tap **DOWNLOAD MODELS** to fetch them at
runtime. Four files are downloaded from the SDK samples release:

- `clip-vitb32-vision.onnx` — CLIP vision tower (image encoder, with projection)
- `clip-vitb32-text.onnx` — CLIP text tower (query encoder, with projection)
- `clip-vocab.json` — CLIP tokenizer vocabulary
- `clip-merges.txt` — CLIP tokenizer BPE merges

Download source: `https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v2`

They are cached under the app data directory in `models/clip/` (`FileSystem.AppDataDirectory`), which is
writable on every platform. A download is skipped when the file is already present with a plausible size.

## How to Use

1. **Download models**: tap **DOWNLOAD MODELS** and wait for the four CLIP files to download.
2. **Open a video**: tap **OPEN FILE** and pick a video.
3. **Start indexing**: tap **START**. The indexed-frame count updates live; the file races by in the preview
   and indexing finishes at the end of the clip (search stays available afterwards).
4. **Search**: type a query (e.g. `a red car`) and tap **SEARCH**. The matching frames appear with their
   timestamp and contrastive-margin score.
5. **Save / Load / Clear** the index with the buttons at the bottom (index files use the `.vfei` format).

## Building and Running

```bash
# Windows
dotnet build -f net10.0-windows10.0.19041.0

# Android
dotnet build -f net10.0-android

# iOS
dotnet build -f net10.0-ios

# macOS (Mac Catalyst)
dotnet build -f net10.0-maccatalyst
```

## Supported Frameworks

- .NET 10

---

[Visit the product page.](https://www.visioforge.com/media-player-sdk-net)
