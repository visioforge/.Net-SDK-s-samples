# Unity RTSP Viewer — VisioForge MediaBlocks SDK (net48)

Displays a live **RTSP camera** stream in a Unity 6 `RawImage`:

```
RTSPSourceBlock → BufferSinkBlock(VideoFormatX.RGBA)   (video → Texture2D)
               \→ AudioRendererBlock                    (audio → system device)
```

Sibling of the [SimplePlayer](../SimplePlayer/) file-playback sample. The full
step-by-step setup (project creation, API compatibility level, binary deployment, scene,
troubleshooting) is in **[../CLIENT_GUIDE.md](../CLIENT_GUIDE.md)** — read that first.

## Quick start

```powershell
cd _SOURCE
./deploy-unity-natives.ps1 -UnityProjectRoot C:\unity\RTSPViewer
./deploy-unity-managed.ps1 -UnityProjectRoot C:\unity\RTSPViewer -Tfm net48
```

Open `C:\unity\RTSPViewer` in Unity 6, open `Assets/Scenes/SampleScene.unity`, select the
RawImage, and set on the **RTSPViewerPlayer** component:

- **Rtsp Url** — e.g. `rtsp://192.168.1.10:554/stream`
- **Login** / **Password** — camera credentials (leave empty for open streams)

Press ▶ Play.

## RTSP specifics

- **`RTSPSourceSettings.CreateAsync(uri, login, password, audioEnabled, readInfo: false)`** —
  `readInfo: false` skips the gst-discoverer pre-probe (it fails under this Unity runtime and
  adds connect latency on a live stream); `decodebin` negotiates the codec at PLAYING.
- **Codecs** — H.264/H.265 cameras decode with the bundled `openh264`/`d3d11`/`nvcodec`
  plugins. MPEG-4 / MJPEG cameras need the Libav overlay (deployed by default).
- **Transport** — defaults to the SDK's RTSP defaults (TCP/UDP auto). Tune via
  `RTSPSourceSettings` (`RTSPSourceProtocol`, latency/buffer mode) if needed.

Everything else matches SimplePlayer: the shared **`VisioForgeVideoView`** (RawImage render
+ Stretch/Letterbox/Crop aspect, pick it via the **Aspect Mode** field) and
**`VisioForgeEnvironment`** (env setup, `InitializeSdk`, Editor reload guard) helpers, plus
the required **Disable Domain Reload** setting and once-per-process SDK init. See
[../CLIENT_GUIDE.md](../CLIENT_GUIDE.md).
