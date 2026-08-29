# Video Edit SDK X .Net - SimpleEdit (C#/MAUI)

Joins the clips picked from the device gallery into a single MP4 with `VideoEditCoreX`.
The same code runs on Android, iOS, MacCatalyst and Windows.

* `ADD CLIP` appends a gallery video to the timeline (`Input_AddAudioVideoFile`).
* `PREVIEW` plays the timeline into the `VideoView` - preview mode is a null `Output_Format`.
* `RENDER MP4` writes the result to the app data directory. `MP4Output` picks the encoders
  that fit the running platform, so no encoder is named in the sample.

`VisioForgeX.InitSDKAsync()` must run before the first `VideoEditCoreX` call, otherwise the
native GStreamer stack is not loaded and the constructor throws `DllNotFoundException`.

## Supported platforms

* Android
* iOS
* MacCatalyst
* Windows

---

[Visit the product page.](https://www.visioforge.com/video-edit-sdk-net)
