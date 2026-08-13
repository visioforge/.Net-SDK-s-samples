# DynamicTextOverlay Console Demo

Records FullHD 50 fps video with a text overlay whose last line is rebuilt on **every frame** from a
live sensor value, the wall clock and the frame timestamp — and a second overlay that is visible only
for the first two seconds.

This is the pattern to use when a caption has to track something that changes: a sensor readout, a
clock, a frame counter, an operator name. There is no "apply" step and no need to remove and re-add
the overlay — nothing touches the pipeline.

## What it shows

### `TextProvider` — text rebuilt per frame

```csharp
var readout = new OverlayManagerText(string.Empty, 60, 80);
readout.Color = SKColors.Yellow;
readout.Font.Size = 40;

readout.TextProvider = ts => "CAMERA 1\nOPERATOR: DEMO\nREC\n"
    + $"SENSOR {_sensorValue:F1}  {DateTime.Now:HH:mm:ss}  T {ts:mm\\:ss\\.ff}";

overlay.Video_Overlay_Add(readout);
```

The callback receives the frame timestamp, counted from the pipeline start. It is called once per
frame on the GStreamer streaming thread, **while the overlay list is locked** — the same lock
`Video_Overlay_Add` and `Video_Overlay_Remove` take. Blocking on another thread from inside it risks
a deadlock rather than a dropped frame, so read a field the other thread has already written (as
`_sensorValue` is here) instead of calling back into a UI dispatcher. Returning `null` falls back to
`Text`; a callback that throws is logged once and is then not called again, so
assign `TextProvider` again to re-enable it.

This is cheap: the text layout (line splitting and measurement) is cached on the element and
recomputed only when the string, font or geometry actually changes, so a value that stays the same
costs nothing beyond the call itself.

If your updates are driven by your own events rather than by the frame clock, just assign `Text` from
wherever the value arrives — that is safe from any thread and appears on the next frame.

### `EndTime` — a time-limited overlay

```csharp
var banner = new OverlayManagerText("STARTING UP", 60, 460)
{
    EndTime = TimeSpan.FromSeconds(2)
};
```

Either time bound on its own defines a window. A zero `StartTime` means "from the beginning", and a
zero `EndTime` means "no end".

## Running

```bash
dotnet run -c Debug -- /path/to/output.mp4
```

Windows: `net10.0-windows`. macOS: `net10.0-macos`. Linux: `net8.0`.

## Verifying the result

```bash
ffprobe -v error -select_streams v:0 \
  -show_entries stream=width,height,r_frame_rate,nb_frames \
  -of default=noprint_wrappers=1 output.mp4

ffmpeg -ss 1.0 -i output.mp4 -frames:v 1 at_1s.png    # banner visible, T 00:01.xx
ffmpeg -ss 4.0 -i output.mp4 -frames:v 1 at_4s.png    # banner gone, T 00:04.xx
```

The console prints the number of `TextProvider` calls at the end; it matches `nb_frames` exactly —
one call per frame, no more.

## Related

- `OverlayManagerCallback` — for drawing anything beyond text, it hands you the Cairo context for the
  frame.
- The [OverlayManagerBlock guide](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoProcessing/OverlayManagerBlock)
  documents every overlay element type.
