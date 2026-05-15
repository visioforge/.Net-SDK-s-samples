# CustomGrayscaleBlock Console Demo

A teaching sample that shows how to wrap a single GStreamer element
(`videobalance`, with `saturation = 0`, which produces grayscale) as a
MediaBlock and use it in a MediaBlocks pipeline.

> The SDK already ships [`GrayscaleBlock`](../../../../VisioForge.Core/MediaBlocks/VideoProcessing/GrayscaleBlock.cs)
> and `VideoBalanceBlock` built on the same element. This sample demonstrates
> the *technique* of wrapping a GStreamer element as a MediaBlock — grayscale
> is just a convenient example.

## What the sample shows

Two ways to wrap a GStreamer element, side by side:

| | Path A — `CustomMediaBlock` | Path B — typed subclass `MyGrayscaleBlock` |
|---|---|---|
| Subclassing | None | Inherits `MediaBlock`, implements `IMediaBlockInternals` |
| File count | 0 extra | One `.cs` (`MyGrayscaleBlock.cs`) |
| Element name | `"videobalance"` passed as data | Hardcoded in `Build()` |
| Properties | `settings.ElementParams["saturation"] = 0.0` | `_element.SetProperty("saturation", new GLib.Value(0.0))` |
| Strong typing / IDE help | No | Yes |
| Static `IsAvailable()` | No | Yes |
| Reusable in many places | Awkward | Natural |

Both pipelines are identical otherwise:

```mermaid
graph LR
    VirtualVideoSourceBlock -- video --> GrayscaleBlock -- video --> H264EncoderBlock --> MP4SinkBlock
```

`GrayscaleBlock` above is either a `CustomMediaBlock("videobalance", saturation=0.0)`
or a `new MyGrayscaleBlock()`.

## Files

- [`Program.cs`](Program.cs) — runs both pipelines, writes two MP4 files.
- [`MyGrayscaleBlock.cs`](MyGrayscaleBlock.cs) — the typed subclass. Reading
  this file is the point of the demo.
- [`CustomGrayscaleBlock.csproj`](CustomGrayscaleBlock.csproj) — console
  project, cross-platform target frameworks.

## Run

```cmd
dotnet run -c Release
```

Two MP4 files are written to your videos folder:

- Windows: `%USERPROFILE%\Videos\custom_grayscale_pathA.mp4` and `…_pathB.mp4`
- macOS: `~/Movies/…`
- Linux: `~/Videos/…`

## Further reading

The companion HELP article walks through the implementation step by step:

> *Build your own MediaBlock from a GStreamer element in C# .NET* —
> `docs/dotnet/mediablocks/Guides/custom-mediablock-from-gstreamer-element.md`
