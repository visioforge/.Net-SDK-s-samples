# Media Blocks SDK .Net - Encoder Concurrency Test (C#/WPF)

This application measures how many encoding pipelines your hardware can run at the same time. Each tile is a separate `MediaBlocksPipeline` with its own source, encoder, decoder and renderer, so the concurrent-session limit of a hardware runtime (NVIDIA consumer drivers cap NVENC at 8 sessions, Intel QSV and AMD AMF have their own limits) shows up as the tile that refuses to start.

The source is synthetic by default, so no camera is needed. Switch the source to `Webcam` to encode real footage instead, or keep the virtual one and test the encoder alone.

## How to use it

* `Codec` selects H264, HEVC or AV1; `Encoder` and `Decoder` list every runtime the SDK ships for that codec, not only the ones this machine has - start with your GPU vendor's entry (NVIDIA, AMD or Intel), or a CPU one if there is no GPU encoder.
* `Add pipeline` starts one more tile. `Fill to limit` keeps adding tiles until one fails to start; the result stays in the status bar, next to the live per-runtime counts, until the pipelines change.
* `Remove last` and `Stop all` tear the tiles down; a failed start leaves the count one below the limit that was reached.

## Used media blocks

* `VirtualVideoSourceBlock`, `SystemVideoSourceBlock` - the tile's source
* `H264EncoderBlock`, `HEVCEncoderBlock`, `AV1EncoderBlock` - one encoder per tile, the runtime being tested
* `H264DecoderBlock`, `HEVCDecoderBlock`, `AV1DecoderBlock` - the matching decoder
* `VideoRendererBlock` - per-tile preview

## Pipeline

One tile; the main window builds as many of them as `Fill to limit` reaches.

```mermaid
graph LR
    Source["VirtualVideoSourceBlock / SystemVideoSourceBlock"] -- video --> Encoder["H264/HEVC/AV1EncoderBlock"]
    Encoder -- encoded --> Decoder["H264/HEVC/AV1DecoderBlock"]
    Decoder -- video --> VideoRendererBlock
```

## Supported frameworks

* .Net 4.7.2
* .Net 5
* .Net 6
* .Net 7
* .Net 8
* .Net 9
* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk)
