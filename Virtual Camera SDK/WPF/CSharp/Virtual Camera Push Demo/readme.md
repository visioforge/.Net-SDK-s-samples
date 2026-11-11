# Virtual Camera SDK .Net - Push Demo (C#/WPF)

This application draws a moving picture with WPF and pushes it to the VisioForge Virtual Camera with
`VirtualVideoWriter.PushFrameBgra`, and sends a 440 Hz tone to the VisioForge Virtual Audio Card with
`VirtualAudioWriter`. Zoom, OBS and browsers see the camera as a webcam, and DirectShow applications also see the
Virtual Audio Card as a microphone.

## Used packages

* `VisioForge.DotNet.VirtualCamera` - the push API
* `VisioForge.DotNet.Core.Redist.VirtualCamera.x64` - the virtual camera and virtual audio card filters
* `VisioForge.DotNet.Core.Redist.Shared.x64` - the native BGRA to YUY2 conversion

## How to use

1. Click "Register Virtual Camera (Admin)" once and accept the UAC prompt.
2. Optionally enter your Virtual Camera SDK license key; without it the picture carries a TRIAL strip.
3. Click "Start" and pick "VisioForge Virtual Camera" in the other application, and "VisioForge Virtual Audio Card" in a DirectShow
   application.

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/virtual-camera-sdk)
