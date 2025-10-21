# VisioForge Media Blocks SDK .Net

## RTSP Preview Demo (C#/WPF, cross-platform engine)

The provided code is a comprehensive example of a Windows application developed using the VisioForge Media Blocks SDK .Net, which is designed for previewing IP camera streams using the RTSP.

Also, the app demonstrates how to enumerate IP cameras in the local network using the ONVIF protocol.

## Used blocks

- [RTSPSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources#rtsp-source-block) - captures video from an RTSP source
- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering) - renders video
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering) - renders audio

## Low Latency Mode

The RTSP source now supports low latency mode for real-time streaming applications. **Important:** For true low latency, you must configure BOTH the RTSP source and the video renderer.

The demo includes a "Low latency mode" checkbox that automatically configures everything correctly.

### Manual Configuration

```csharp
var rtsp = await RTSPSourceSettings.CreateAsync(
    new Uri(cbIPURL.Text), 
    edIPLogin.Text, 
    edIPPassword.Text, 
    audioEnabled);

// 1. Enable low latency mode on RTSP source (latency=80ms, no buffering)
rtsp.LowLatencyMode = true;

_rtspSource = new RTSPSourceBlock(rtsp);
_videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

// 2. Disable sync on video renderer (critical for low latency!)
_videoRenderer.IsSync = false;

_pipeline.Connect(_rtspSource.VideoOutput, _videoRenderer.Input);
```

### Expected Results

| Configuration | Latency | Use Case |
|---------------|---------|----------|
| Default (sync=true, LowLatencyMode=false) | 1-2 seconds | Recording, playback |
| LowLatencyMode=true only | 500-800ms | Improved but still buffering |
| **Both enabled** | **60-120ms** | **Real-time surveillance ✓** |

### Why Both Settings Are Needed

1. **LowLatencyMode=true** - Reduces RTSP source buffering (latency=80ms instead of 1000ms)
2. **IsSync=false** - Disables video renderer clock synchronization (displays frames immediately)

Without both settings, the video renderer will still wait for clock synchronization even if the RTSP source has low latency.

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8
- .Net 9

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk-net)
