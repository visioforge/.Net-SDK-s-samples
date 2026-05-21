# VisioForge MediaBlocks SDK — Unity Integration Guide

Step-by-step guide for using the **VisioForge Media Blocks SDK .NET** inside **Unity 6**
on **Windows x64**, distributed as a ready-to-import **`.unitypackage`**.

The package is fully self-contained: the managed SDK (a `net48` build), the native GStreamer
runtime, two reusable rendering scripts, and two ready-to-run sample scenes
(`SimplePlayer` — file playback, `RTSPViewer` — RTSP camera). You do **not** build anything
from source — just import and press Play.

---

## 0. Prerequisites

| | |
|---|---|
| Unity | **6 (6000.x)** — verified on 6000.4.6f1 |
| Platform | **Windows x64** (Editor + Player) |
| Package | `VisioForge.MediaBlocks.Unity-<version>.unitypackage` (download from visioforge.com) |

> **No system GStreamer required, and no NuGet.** Everything the SDK needs is inside the
> package. If you happen to have a GStreamer install on your `PATH`, that's fine — the bundled
> scripts prune it from the *process* PATH at startup so the bundled copy is used. You never
> need to modify the system PATH.

---

## 1. Create or open your Unity project

Use an existing Unity 6 project, or create a new one (any template).

> ⚠️ **Two Windows pitfalls when choosing the project location:**
>
> - **MAX_PATH (260 chars).** Unity's package cache produces deep paths. A deep project root
>   overflows 260 chars and Unity fails with `EPERM rename`. Keep the root shallow
>   (e.g. `C:\unity\MyApp`).
> - **Use NTFS — not a Dev Drive / ReFS volume.** Importing this package writes thousands of
>   small native files, and the Editor's import/compile is heavy small-file I/O. On a Dev Drive
>   (ReFS) that workload is **dramatically slower** (a cold import can take many minutes instead
>   of seconds) and is also more prone to the import `EPERM` race. Put the Unity project — and
>   test it — on a plain **NTFS** drive (e.g. `C:\unity\MyApp`). The same applies to any
>   network/virtual/slow filesystem: keep the project local on NTFS.

---

## 2. Import the package

**Assets → Import Package → Custom Package…** → select the `.unitypackage` → **Import** (keep
all items checked).

On first import the package's setup helper pops a dialog:

> **VisioForge MediaBlocks SDK** requires two project settings — *Api Compatibility Level =
> .NET Framework* and *Enter Play Mode Options → Disable Domain Reload*. **Apply** / **Skip**.

Click **Apply** and you're done — the two required settings are configured for you. (If you
click **Skip**, set them by hand — see §3.) The Console logs what was applied.

---

## 3. (Only if you clicked **Skip**) Set the two required project settings

Both are mandatory; the SDK will not work without them.

1. **Api Compatibility Level = .NET Framework**
   *Edit → Project Settings → Player → Other Settings → Configuration → Api Compatibility
   Level: `.NET Framework`.* The Unity 6 default is `.NET Standard 2.1`, which **cannot load
   this SDK build** (symptom: `TypeLoadException` when the player starts).

2. **Disable Domain Reload**
   *Edit → Project Settings → Editor → Enter Play Mode Settings → enable "Enter Play Mode
   Options" and turn "Reload Domain" OFF* (leave "Reload Scene" on). The SDK runs GStreamer
   on a native GLib main-loop thread Unity cannot abort; with domain reload **on**, exiting
   Play mode hangs and re-initializing GStreamer in the same process crashes. With it **off**,
   the SDK initializes once and survives Play/Stop cycles.

---

## 4. Run a sample scene

The package ships two ready scenes under **`Assets/Scenes/`**. To open one: in the **Project**
window (bottom) browse to `Assets/Scenes/` and **double-click** the scene — do **not** stay on
your project's default empty scene.

When the scene opens, the **Hierarchy** (left) shows: **Canvas → RawImage**, **EventSystem**,
**Main Camera**, **Global Light 2D**. The player component is on the **RawImage** GameObject.

> **The RawImage looks empty (white) before you press Play — that is normal.** The video texture
> is created at runtime; nothing is drawn until the pipeline starts.

**`SimplePlayer.unity`** — local file playback:

1. Open `Assets/Scenes/SimplePlayer.unity`.
2. Select the **RawImage** GameObject in the Hierarchy.
3. In the **`MediaBlocksPlayer`** component (Inspector, right) set **File Path**
   (default `C:\Samples\!video.avi`).
4. Press **▶ Play** — the video appears in the RawImage (Game view) and audio plays through the
   system default device.

**`RTSPViewer.unity`** — RTSP camera:

1. Open `Assets/Scenes/RTSPViewer.unity`.
2. Select the **RawImage** GameObject in the Hierarchy.
3. In the **`RTSPViewerPlayer`** component set **Rtsp Url**, **Login**, **Password**.
4. Press **▶ Play** — the RTSP stream renders in the RawImage.

In both cases the Console logs progress (`GST_PLUGIN_PATH`, `Native DLL dir`, `Playing …`).

> **Use it in your own scene** instead of the samples: add a **Canvas → Raw Image**, then **Add
> Component →** `MediaBlocksPlayer` *or* `RTSPViewerPlayer`. Both aspect modes (`Stretch` /
> `Letterbox` / `Crop`, default Letterbox) and the RectTransform/flip are handled for you by the
> bundled `VisioForgeVideoView` — you don't write texture code. To switch a scene from file to
> RTSP playback (or back), just swap the player component on the GameObject.

---

## How the rendering works

The shared helpers do the heavy lifting; the player is just the pipeline:

1. **`VisioForgeEnvironment.Configure()`** — `[RuntimeInitializeOnLoadMethod]` before the
   scene loads: prune system GStreamer from the *process* PATH, point `SetDllDirectoryW` +
   process PATH at the bundled natives, set `GST_PLUGIN_PATH` and `SSL_CERT_FILE`. The native
   runtime lives in `StreamingAssets/VisioForge/x64`, resolved via
   `Application.streamingAssetsPath` — a real directory in both the Editor and a standalone
   build, so the same path works for both.
2. **`VisioForgeEnvironment.InitializeSdk()`** — `VisioForgeX.InitSDK()` then
   `Gst.Registry.Get().ScanPath(pluginDir)`. The explicit scan is required because Unity's
   in-process plugin scan does not reliably pick up `GST_PLUGIN_PATH`. The SDK is initialized
   **once per process** — never `DestroySDK()` on Stop (see lifecycle below).
3. **Pipeline** — `<source> → BufferSinkBlock(VideoFormatX.RGBA)` for video, plus
   `AudioRendererBlock` for audio. `BufferSink` raises `OnVideoFrameBuffer` with raw RGBA.
4. **`VisioForgeVideoView`** — `OnFrameBuffer` (GStreamer thread) copies the frame into a
   **reused double buffer** (`Marshal.Copy`); `Update()` (main thread) swaps it to the front
   buffer, uploads via `Texture2D.LoadRawTextureData` + `Apply`, and applies the aspect mode
   (RectTransform + uvRect, with the V-flip for GStreamer's top-down rows).
   - **Never** allocate a fresh `byte[]` per frame: at 25-60 fps that's 90-220 MB/s of garbage;
     Unity's GC then runs constantly and the finalizer thread races GStreamer's GLib.Object
     toggle-ref cleanup → **Editor crash within a second**.

### Editor lifecycle (why Disable Domain Reload)

GStreamer runs on a native GLib main-loop thread Unity cannot abort, and `gst_deinit` cannot
be re-initialized in the same process. So:
- **Disable Domain Reload** (§2/§3) → Play/Stop reuses the live SDK instead of tearing it down
  and re-initializing (which would hang or crash).
- **Never `DestroySDK()` on Stop** — the SDK is process-global; only the per-play pipeline is
  disposed (`StopAsync`).
- An `[InitializeOnLoad]` reload guard in `VisioForgeEnvironment` calls
  `VisioForgeX.StopMainLoop()` on `beforeAssemblyReload`/`quitting` so a script recompile or
  Editor quit unloads the domain without hanging. If you hit instability after a recompile,
  restart the Editor.

---

## Standalone builds

`File → Build Settings → Windows x64 → Build` produces a standalone player that works without
any extra steps: the native runtime in `Assets/StreamingAssets/VisioForge/x64` is copied
verbatim by Unity into `<game>_Data/StreamingAssets/VisioForge/x64`, and the managed SDK
assemblies in `Assets/Plugins` are staged automatically. The same `streamingAssetsPath` load
path used in the Editor resolves there too.

---

## Troubleshooting

| Symptom | Cause | Fix |
|---|---|---|
| `TypeLoadException` on play | Api Compatibility Level is `.NET Standard 2.1` | Set it to `.NET Framework` (§3) — or re-import and click **Apply** |
| Editor **hangs on "Reloading domain"** on Play/Stop or after a recompile | Native GLib main-loop thread can't be aborted | Disable Domain Reload (§3); the reload guard calls `StopMainLoop()` |
| Editor **crashes on the 2nd Play** | `DestroySDK()` ran on Stop, then re-init in the same process | Don't `DestroySDK()` on Stop; keep Disable Domain Reload on |
| `GStreamer libraries not found` / native runtime not found | Package imported partially | Re-import the package with all items checked |
| Pipeline hangs on start; log shows `cannot register existing type 'GstBaseSink'` | Two copies of GStreamer in the process (system + bundled) | The scripts prune the process PATH automatically — fully restart the Editor |
| `no such element factory "videoconvert"` / `Failed to build block 'BufferSink'` | Plugins not scanned | The scripts call `Gst.Registry.Get().ScanPath()` after `InitSDK()`; restart the Editor |
| File source: `Unable to read file info` | gst-discoverer pre-probe fails in this runtime | Use `ignoreMediaInfoReader: true` (file) / `readInfo: false` (RTSP) |
| MPEG-4/MP3 won't decode (H.264 does) | Package built without the FFmpeg/libav overlay | Use a package built with libav (the default) |
| Video is upside-down | GStreamer vs Unity texture origin | `RawImage.uvRect = new Rect(0, 1, 1, -1)` (the scripts do this) |
| Editor crashes after ~1 s of video | Per-frame allocation → GC → finalizer race | Use the reused double-buffer pattern (the scripts do this) |

---

## Known limitations

- **Windows x64 only** — the bundled native runtime is Windows x64. Other platforms need their
  own GStreamer build deployed.
- **Audio** routes to the system default device; Unity `AudioSource` integration is TBD.
