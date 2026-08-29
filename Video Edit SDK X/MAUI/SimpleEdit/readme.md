# Video Edit SDK X .Net - SimpleEdit (C#/MAUI)

Joins the clips picked from the device gallery into a single MP4 with `VideoEditCoreX`.
The same code runs on Android, iOS, MacCatalyst and Windows.

* `ADD CLIP` appends a gallery video to the timeline (`Input_AddAudioVideoFile`).
* `PREVIEW` plays the timeline into the `VideoView` - preview mode is a null `Output_Format`.
* `RENDER MP4` writes the result to the app data directory, using
  `H264EncoderBlock.GetDefaultSettings()` - the SDK's platform selector, which prefers a
  hardware encoder (VideoToolbox, MediaCodec, NVENC/AMF/QSV) and falls back to software.
  `MP4Output`'s own default only consults it on Android.

`VisioForgeX.InitSDKAsync()` must run before the first `VideoEditCoreX` call, otherwise the
native GStreamer stack is not loaded and the constructor throws `DllNotFoundException`.

## Supported platforms

* Android
* iOS
* MacCatalyst
* Windows

---

[Visit the product page.](https://www.visioforge.com/video-edit-sdk-net)
