# RTSP RAW Camera with H264 Callback Sample

## Overview

This sample demonstrates a **two-pipeline architecture** for receiving an RTSP H.264 camera stream, intercepting the raw encoded data, and then decoding/displaying it. The key innovation is the `H264PushSourceBlock` -- a custom MediaBlock that accepts raw H.264 data via a `PushData()` method and feeds it into a separate GStreamer decoding pipeline.

This pattern gives you full access to the raw encoded H.264 bytes between capture and decode, enabling use cases like:

- Recording the original stream to disk while simultaneously previewing
- Analyzing or modifying NAL units before decoding
- Forwarding the raw stream over a custom transport
- Applying frame-level filtering or statistics on the encoded bitstream

## Architecture

```
Pipeline 1 (Grabber)                          Pipeline 2 (Player)
========================                      =====================================

  RTSPRAWSourceBlock                            H264PushSourceBlock (AppSrc)
        |                                              |
        v                                              v
  BufferSinkBlock ──── OnDataFrame ────>          H264ParseBlock
                       callback copies               |
                       raw H264 bytes                 v
                       and calls                 H264DecoderBlock (FFmpeg)
                       PushData()                     |
                                                      v
                                              VideoSampleGrabberBlock (debug)
                                                      |
                                                      v
                                              VideoRendererBlock (WPF display)
```

### Pipeline 1: Grabber

Connects to the RTSP camera and captures raw H.264 encoded data:

- **RTSPRAWSourceBlock** -- connects to the RTSP camera URL over TCP, negotiates the stream, and outputs raw encoded H.264 access units (NAL units in AVC/length-prefixed format).
- **BufferSinkBlock** -- receives each encoded frame and fires the `OnDataFrameBuffer` event, providing the raw byte array, data size, and presentation timestamp (PTS).

### Pipeline 2: Player

Receives the raw H.264 data via `PushData()`, parses, decodes, and renders it:

- **H264PushSourceBlock** -- wraps a GStreamer `appsrc` element. Accepts raw H.264 data from application code, converts it from AVC format to Annex B byte-stream format, and pushes it into the pipeline.
- **H264ParseBlock** -- GStreamer's `h264parse` element. Parses the byte-stream, extracts SPS/PPS parameter sets, detects access unit boundaries, and outputs properly formatted parsed H.264.
- **H264DecoderBlock** -- FFmpeg-based `avdec_h264` decoder. Decodes H.264 access units into raw video frames (I420/NV12).
- **VideoSampleGrabberBlock** -- optional debug block that fires a callback for each decoded video frame, used to verify decoding is working.
- **VideoRendererBlock** -- renders the decoded video frames to the WPF `VideoView` control.

## H264PushSourceBlock -- How It Works

The `H264PushSourceBlock` is the bridge between the two pipelines. It is implemented in [H264PushSourceBlock.cs](../../../../../VisioForge.Core/MediaBlocks/Sources/H264PushSourceBlock.cs).

### GStreamer AppSrc Configuration

During `Build()`, the block creates and configures a GStreamer `appsrc` element:

```csharp
_appsrc = new AppSrc("h264src");
_appsrc.Caps = Caps.FromString("video/x-h264, stream-format=byte-stream, alignment=nal");
_appsrc.Format = Format.Time;
_appsrc.StreamType = AppStreamType.Stream;
_appsrc["is-live"] = true;
_appsrc["do-timestamp"] = false;  // Timestamps set manually per buffer
_appsrc.Block = false;
```

| Property | Value | Purpose |
|----------|-------|---------|
| `Caps` | `video/x-h264, stream-format=byte-stream, alignment=nal` | Tells downstream elements the data format |
| `Format` | `Time` | Timestamps are in nanoseconds (GStreamer time) |
| `StreamType` | `Stream` | Continuous data stream (not seekable) |
| `is-live` | `true` | Data arrives in real-time from a live source |
| `do-timestamp` | `false` | Application provides PTS on each buffer |
| `Block` | `false` | `PushBuffer()` returns immediately, never blocks |

### AVC-to-Byte-Stream Conversion

**This was the critical fix that made everything work.**

RTSP sources (via `RTSPRAWSourceBlock` / `BufferSinkBlock`) deliver H.264 data in **AVC format** -- each NAL unit is prefixed with a 4-byte big-endian length:

```
AVC format:     [00 00 00 17][23 bytes of NAL data][00 00 1C CC][7372 bytes of NAL data]...
                 ^^^^^^^^^^^                        ^^^^^^^^^^^
                 length = 23                        length = 7372
```

But the GStreamer caps declare `stream-format=byte-stream`, which expects **Annex B format** -- each NAL unit is prefixed with a 4-byte start code:

```
Byte-stream:    [00 00 00 01][23 bytes of NAL data][00 00 00 01][7372 bytes of NAL data]...
                 ^^^^^^^^^^^                        ^^^^^^^^^^^
                 start code                         start code
```

Since both the AVC length prefix and the Annex B start code are exactly 4 bytes, `PushData()` converts in-place by replacing each length prefix with `00 00 00 01`:

```csharp
private static void ConvertAvcToByteStream(byte[] data, int length)
{
    int offset = 0;
    while (offset + 4 <= length)
    {
        int nalLength = (data[offset] << 24) | (data[offset + 1] << 16) |
                        (data[offset + 2] << 8) | data[offset + 3];

        // Skip if already a start code
        if (data[offset] == 0 && data[offset + 1] == 0 &&
            data[offset + 2] == 0 && data[offset + 3] == 1) { /* skip */ }

        // Replace length prefix with start code
        data[offset]     = 0x00;
        data[offset + 1] = 0x00;
        data[offset + 2] = 0x00;
        data[offset + 3] = 0x01;

        offset += 4 + nalLength;
    }
}
```

Without this conversion, `h264parse` receives data that doesn't match the declared caps and silently produces no output -- buffers enter the parser but nothing comes out.

### PushData Flow

```
BufferSink_OnDataFrame callback
    |
    |  1. Copy raw bytes from unmanaged memory
    v
byte[] data  (AVC format from RTSP)
    |
    |  2. ConvertAvcToByteStream() -- in-place replacement
    v
byte[] data  (Annex B byte-stream)
    |
    |  3. Create Gst.Buffer, set PTS, map and copy data
    v
Gst.Buffer with PTS
    |
    |  4. _appsrc.PushBuffer(buffer)
    v
GStreamer pipeline: appsrc -> h264parse -> avdec_h264 -> renderer
```

### Timestamps

Each buffer receives a presentation timestamp (PTS) from the RTSP source:

```csharp
buffer.Pts = (ulong)(timestamp.TotalMilliseconds * Constants.MSECOND);
```

`Constants.MSECOND` converts milliseconds to GStreamer's nanosecond time base. The `do-timestamp=false` setting on `appsrc` ensures these manually-set timestamps are used rather than auto-generated ones.

## Pipeline Startup Sequence

The startup order is critical for live streaming:

```
1. Create player pipeline and connect all blocks
2. Preload player pipeline (StartAsync with onlyPreload: true)
   - Transitions pipeline to PAUSED state
   - Build() is called on all blocks (appsrc created here)
   - Pads are linked: appsrc.src -> h264parse.sink -> decoder.sink -> renderer.sink

3. Create grabber pipeline (RTSP source + buffer sink)
4. Start grabber pipeline (StartAsync)
   - RTSP connection established
   - H264 frames start arriving via OnDataFrame callback
   - PushData() pushes converted data into the paused player pipeline
   - h264parse begins accumulating and parsing NAL units

5. Wait ~1 second for data to flow (h264parse needs SPS/PPS + first IDR frame)

6. Resume player pipeline (ResumeAsync)
   - Transitions from PAUSED to PLAYING
   - h264parse outputs parsed access units
   - Decoder starts producing decoded frames
   - Renderer displays video
```

### Why Preload First?

The player pipeline is preloaded (PAUSED) before the grabber starts, so that:
- All GStreamer elements are created and linked
- The `appsrc` is ready to accept data via `PushBuffer()`
- `h264parse` can start accumulating SPS/PPS/IDR NAL units while paused
- When resumed to PLAYING, there's already data queued for decoding

## Diagnostics

### Pad Probe

The block includes an optional pad probe for debugging buffer flow:

```csharp
_h264Source.EnablePadProbe();  // Call AFTER preload (appsrc must exist)
```

The probe logs buffer size and PTS for the first 10 buffers and every 100th buffer thereafter. If `probeCount` stays at 0, buffers are not leaving `appsrc` (indicating a caps/format mismatch).

### GetDiagnostics()

Returns a snapshot of the block state:

```
appsrc state=Playing, peer=sink, pushCount=250, probeCount=250, caps=[video/x-h264, ...]
```

- `state` -- GStreamer element state (Paused/Playing)
- `peer` -- name of the downstream element's sink pad (confirms linking)
- `pushCount` -- total `PushData()` calls
- `probeCount` -- buffers that actually flowed through the output pad
- `caps` -- negotiated caps on the output pad

### NAL Unit Analysis

The sample includes `AnalyzeH264StartCodes()` which inspects the first bytes of each frame to identify:
- Data format: AVC (length-prefixed) vs byte-stream (start codes)
- NAL unit types: SPS (7), PPS (8), IDR keyframe (5), non-IDR slice (1), SEI (6), AUD (9)
- Number of NAL units per buffer

## Key Debugging Lessons

1. **AVC vs Byte-Stream Mismatch**: The most common issue when pushing H.264 data into GStreamer. RTSP sources typically output AVC format (length-prefixed NAL units), but `h264parse` with `stream-format=byte-stream` caps expects Annex B start codes. The symptom is: `PushBuffer()` returns `Ok`, the appsrc is in Playing state, pads are linked -- but `h264parse` produces no output and the decoder never receives any data.

2. **Pad Probe Timing**: `EnablePadProbe()` must be called after `StartAsync(onlyPreload: true)` because the appsrc element is created during `Build()`, which is triggered by the preload. Calling it before results in `_appsrc` being null and the probe silently not being installed.

3. **Pipeline State Ordering**: The player pipeline must be preloaded before the grabber starts, and resumed only after initial data has been pushed. This ensures `h264parse` has accumulated SPS/PPS parameter sets needed to begin parsing.

## Files

| File | Description |
|------|-------------|
| `MainWindow.xaml` | WPF UI with video view, URL input, statistics display, and log panel |
| `MainWindow.xaml.cs` | Two-pipeline orchestration, data callback, and diagnostics |
| `H264PushSourceBlock.cs` | Custom MediaBlock wrapping GStreamer `appsrc` with AVC-to-byte-stream conversion |
| `MediaBlockType.cs` | Enum entry `H264PushSource` for the new block type |
