# Video Capture SDK .Net - USB Camera (C#/Android)

This application previews a USB (UVC) camera attached to an Android device over OTG and records it to
MP4 using the `VideoCaptureCoreX` engine.

Such cameras are invisible to the regular video capture device source, because Android only exposes
them through Camera2 on devices whose vendor ships the External Camera HAL - many, including Samsung,
do not. Assigning an `AndroidUVCSourceSettings` to `Video_Source` reads the camera directly instead,
and the rest of the engine - outputs, effects, snapshots - works as it does with any other source.

The recording is video-only. A UVC video interface carries no audio, and the phone microphone is not
a substitute: a webcam with a built-in mic also registers as a USB audio input, which Android then
prefers for recording - and that input cannot be opened while this bridge is streaming from the same
physical device, so adding an audio source fails the whole pipeline. Use a camera without a
microphone, or an audio source Android does not route to the camera, if you need sound.

## Requirements

* An Android device with USB host (OTG) support, running Android 9 (API level 28) or later.
* The `android.permission.CAMERA` permission, declared **and granted at runtime**. Android refuses to
  hand a USB video device to an app without it, even though the Android camera API is never used.
* Permission for the USB device itself, requested with `AndroidUVCDevices.RequestPermissionAsync`.

Note that a camera enumerating at USB High Speed offers markedly lower frame rates than on a desktop:
a Logitech BRIO, for example, tops out at 1080p30 (MJPEG) with no 4K modes available at all. Call
`AndroidUVCDevices.GetModes` to see what a given camera really offers before requesting a resolution.

## One recording per run, today

Restarting a stopped output pipeline is a known limitation: the **second** `StartCaptureAsync` on the
same output index returns `true` and writes no file, silently. This demo therefore leaves the record
button off after one recording rather than offering a take that cannot succeed, and it checks the
return value *and* whether the file exists after stopping instead of claiming a save. To record more
than once, recreate the engine between recordings.

## Handling a disconnected camera

`VideoCaptureCoreX` does not observe the end-of-stream that a vanished camera produces, so this demo
registers a receiver for Android's `ACTION_USB_DEVICE_DETACHED` broadcast, finishes the recording, and
stops the engine. Without it the preview would freeze on the last frame with the status line still
reading "Streaming".

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/video-capture-sdk-net)
