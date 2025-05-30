---
title: .Net SDKs Updates and Release History
description: Detailed changelog for .Net video processing SDKs, including Video Capture, Media Player, Video Edit and Media Blocks. Track latest features, improvements, and fixes across versions. Essential reference for developers implementing video solutions.
sidebar_label: Changelog
hide_table_of_contents: true
---

# Changelog

Changes and updates for all .Net SDKs.

## 2025.5.1

* [ALL] Update NuGet dependency packages to the latest versions
* [X-engines] Resolved issue with RTMP network streaming to a custom server

## 2025.4.8

* [ALL] Added Absolute Move API to the `ONVIFDeviceX` class. You can use this API to move the ONVIF camera to the specified absolute position.

## 2025.2.24

* [X-engine] By default, Media Foundation device enumeration is disabled. You can enable it using the `DeviceEnumerator.Shared.IsEnumerateMediaFoundationDevices` property.

## 2025.2.18

* [Media Player SDK.Net] Added loop support for the cross-platform engine.
* [ALL] Updated RTSP-X engine output, fixed crash issue with RTSP output and VLC player frequent reconnects
* [X-engines] Changed face detector support to use IFaceDetector interface
* [Live Video Compositor] Fixed registration issues with custom video view attached to video input
  
## 2025.2.9

* [X-engines] Updated NDI connection speed

## 2025.2.4

* [X-engines] RTSP Server Media Block and RTSPServerOutput added to Video Capture SDK. You can use the RTSPServerBlock to create an RTSP server and stream video and audio to it.

## 2025.2.1

* [X-engines] Added NVENC and AMF AV1 encoders support

## 2025.1.25

* [Windows] Resolved HTTPS issue with the not loaded SSL certificates

## 2025.1.22

* [Windows] Resolved issue with missed ONVIF sources while enumerating on PC with multiple network interfaces
* [Media Blocks SDK .Net] Added the `OnEOS` event to `MediaBlockPad` class. You can use this event to get the EOS (End of Stream) event from the media block. It can be useful if you have several file sources with a different duration and you need to stop the pipeline when the first source ends.
* [Media Blocks SDK .Net] Added the `SendEOS` method to `MediaBlocksPipeline` class. You can use this method to send the EOS (End of Stream) event to the pipeline.
  
## 2025.1.18

* [NuGet] `VisioForge.Core.UI.Apple`, `VisioForge.Core.UI.Android`, and `VisioForge.Core.UI.WinUI` packages are merged into the `VisioForge.DotNet.Core` package. All namespaces are the same.
* [Media Blocks SDK .Net] Added the `ZOrder` property to `LVCVideoInput` and `LVCVideoAudioInput` classes. You can use this property to set the Z-order for the video input.

## 2025.1.14

* [NuGet] `VisioForge.Core.UI.WPF` and `VisioForge.Core.UI.WinForms` packages are merged into the `VisioForge.DotNet.Core` package. In WPF projects you have to update the XAML code if the assembly names are used. All namespaces are the same.

## 2025.1.11

* [Video Capture SDK .Net] Resolved QSV H264 FFMPEG encoder issue with the wrong symbols in parameters

## 2025.1.7

* [Cross-platform] Added `libcamera` source support for Linux/Raspberry Pi.

## 2025.1.5

* [Cross-platform] Improved previous frame playback in Media Player SDK .Net (Cross-platform engine)

## 2025.1.4

* [Cross-platform] Resolved issue with AMD AMF plugin initialization

## 2025.1.1

* [Cross-platform] Resolved memory leak in `OverlayManagerImage`

## 2025.1.0

* [Cross-platform] Updated Live Video Compositor engine. Improved Decklink support for input and output. Improved performance. The new engine classes are located in the `VisioForge.Core.LiveVideoCompositorV2` namespace.

## 2025.0.29

* [Cross-platform] Default video renderer on Windows has been changed to DirectX 11

## 2025.0.17

* [Media Blocks SDK .Net] Added libCamera source support (can be used on Raspberry Pi)

## 2025.0.16

* [Media Blocks SDK .Net] Resolved issue with adding several AudioRendererBlocks to the pipeline

## 2025.0.14

* [Media Blocks SDK .Net] Added the "PushJPEGSourceSettings" class to configure the JPEG source for the "PushSourceBlock". You can use this class to set the JPEG source settings for the "PushSourceBlock". Also "video-from-images" sample added.

## 2025.0.7

* [ALL] Resolved window capture issues in cross-platform SDKs
* [Media Blocks SDK .Net] Added the Bridge Source Switch sample

## 2025.0.5

* [iOS] Resolved issues with playback speed for some video files
* [iOS] Added iOS Simulator support for all SDKs. Camera source is not supported in the simulator.

## 2025.0.3

* [MacOS] Resolved wrong stride issue for vertical camera videos on MacOS
* [Video Capture SDK .Net] Resolved background color issue for the scrolling text overlay

## 2025.0

* [ALL] .Net 9 support
* [Media Blocks SDK .Net] Added `AVIOutputBlock` to save video and audio streams to the AVI file format
* [Media Blocks SDK .Net] `TeeBlock` constructor now accepts the media type as a parameter
* [Video Capture SDK .Net] Added `Video_CaptureDevice_SetDefault` and `Audio_CaptureDevice_SetDefault` methods to the `VideoCaptureCore` class. You can use this method to set the default video and audio capture devices
* [Cross-platform] Improved `Metal` video rendering performance on Apple devices
* [All] Improved performance of common video processing operations in Windows classic SDKs
* [CV] Added DNN face detectors for the `Media Blocks SDK .Net` and `Video Capture SDK .Net`
* [Mobile] Improved AOT compatibility for iOS and Android
* [WinUI] Improved performance of the `WinUI` video rendering
* [Media Blocks SDK .Net] Added the `GetLastFrameAsSKBitmap` and `GetLastFrameAsBitmap` methods to `VideoSampleGrabberBlock` to get the last frame as a `SkiaSharp.SKBitmap` or `System.Drawing.Bitmap`
* [Video Capture SDK .Net] `VideoCaptureCore`: Added the `AddFakeAudioSource` property to `FFMPEGEXEOutput`. The `Network_Streaming_Audio_Enabled` property of `VideoCaptureCore` should be set to false to use this fake audio.
* [ALL] Improved WinUI (and MAUI on Windows) VideoView performance
* [Video Capture SDK .Net] `VideoCaptureCore`: Added the `PIP_Video_CaptureDevice_CameraControl_` API to control the camera settings for the Picture-in-Picture mode
* [X-engines] Added the headers support for the HTTP sources created using the `HTTPSourceSettings` class
* [X-engines] Updated Avalonia samples, with projects for macOS, Linux, and Windows
* [X-engines] Added NuGet redist packages for macOS and MacCatalyst (including MAUI)
* [Video Capture SDK .Net] `VideoCaptureCore`: Added device path support for `PIP_Video_CaptureDevice_CameraControl` API
* [Video Capture SDK .Net] `VideoCaptureCore`: Added the `FFMPEG_MaxLoadTimeout` property for IP camera sources. It allows you to set the maximum time to wait for the FFMPEG source to load the stream
* [X-engines] Updated Linux support for `ALSA`, `PulseAudio` and `PipeWire` audio devices
* [X-engines] Updated Linux support for `V4L2` devices
* [X-engines] Avalonia samples has be changed to a modern 1-project structure
* [X-engines] Resolved issue with `MAUI` crashes on Windows after `SkiaSharp` update
* [X-engines] Resolved issue with `TextureView` crashes on Android in `MAUI` applications
* [X-engines] Resolved playback issue for http sources using the `UniversalSourceBlock`
* [X-engines] Added Mobile Streamer sample for Android
* [X-engines] Added `OverlayManagerBlock` support for Android (now it's available for all platforms)
* [Video Capture SDK .Net] `VideoCaptureCoreX`: Added `CustomVideoProcessor`/`CustomAudioProcessor` properties for all output formats. You can use these properties to set custom video/audio processing blocks for the output format.
* [Media Blocks SDK .Net] Added the `KeyFrameDetectorBlock` to detect key frames in video streams (H264, H265, VP8, VP9, AV1, etc.)
* [Media Blocks SDK .Net] Fixed licensing issue for the `LiveVideoCompositor` class
  
## 15.10.0

* [Windows] Updated window capture API to capture only the specified parent window by default. Added the `UpdateHotkey` method to the `WindowCaptureForm` class to update the hotkey for the window capture form.
* [X-engines] Better AOT compatibility for default MAUI settings in iOS.
* [Media Blocks SDK .Net] Added the `DNNFaceDetectorBlock` to detect faces and blur/pixelate them using OpenCV and DNN models.
* [Media Blocks SDK .Net] Added the `MKVOutputBlock` to save video and audio streams to the MKV file format.
* [X-engines] Better support for video source size dynamic changing in MAUI applications.
* [X-engines] Resolved an issue with two or more VU meters in the same pipeline.
* [X-engines] Resolved volume/mute error issue with audio mixer in Live Video Compositor engine.
* [X-engines] The `Spinnaker` source for `FLIR`/`Teledyne` cameras is included in the main package and no longer requires an additional plugin.
* [Video Capture SDK .Net] Resolved the issue with the `SeparateCapture` API if no `VideoView` was used.
* [X-engines] The `MediaBlocksPipeline` constructor no longer has the `live` parameter. For more customizable pipelines, video and audio renderers got the `IsSync` property (`true` by default).
* [X-engines] Resolved `VideoViewTX` crash in MAUI Android applications.
* [X-engines] `IVideoEncoder` interface added to the `MPEG2VideoEncoder` class. It allows the use of `MPEG2VideoEncoder` with `MPEGTSOutput`, `AVIOutput`, and other output classes.
* [X-engines] Resolved the issue with window capture using the `ScreenCaptureD3D11SourceSettings` class. If the rectangle was incorrect or not specified, it caused an error.
* [X-engines] `Metal` renderer was added to SDK for Apple devices and used by default for iOS and MAUI.
* [Media Blocks SDK .Net] Added the MAUI Screen Capture sample.
* [Video Capture SDK .Net] VideoCaptureCore: Added the `VLC_CustomDefaultFrameRate` property to `IPCameraSourceSettings` to set a custom frame rate for the VLC IP camera source if the source does not provide the correct frame rate.
* [Media Blocks SDK .Net] `RTSPSourceBlock`: If the RTSP source has audio but you've disabled the audio stream in `RTSPSourceSettings`, SDK will add a null renderer automatically to prevent warnings.
* [ALL] Resolved issue with `VideoFrameX.ToBitmap()` call (wrong color space)
* [Windows] Updated KLV support in MPEG-TS output
* [Windows] Resolved MediaPlayerCore serialization issue
* [ALL] Video renderer settings class no longer contains background color. Use the VideoView background color property instead.
* [X-engines] Updated GStreamer libraries
* [X-engines] Resolved video rendering issues on Android and iOS
* [X-engines] iOS crash fixed during VideoViewGL usage
* [X-engines] Added default AAC encoder for iOS
* [X-engines] iOS camera source update for high frame rate support
* [Windows] Updated VLC source - improved file loading speed
* [Media Blocks SDK .Net]: Added the `UniversalDemuxBlock` allows to demux video and audio streams from a file in MP4, MKV, AVI, MOV, TS, VOB, FLV, OGG, and WebM formats
* [Windows] Resolved FFMPEG stability issues
* [X-engines] Resolved issue with loopback audio source using VideoCaptureCoreX and audio capture to file
* [X-engines] Added SRT source and sink support in Media Blocks SDK .Net and Video Capture SDK .Net
* [Video Capture SDK .Net] VideoCaptureCore: The `IP_Camera_ONVIF_ListSourcesAsyncEx` method got an overload version with a callback for a more responsible UI
* [X-engines] RTSP source compatibility update
* [X-engines] `Breaking API change`. Starting with this update, the SDK uses `IAudioRendererSettings` interface implementations for audio output configuration. WASAPI output got the custom configuration classes. Output_AudioDevice properties of `VideoCaptureCoreX`/`MediaPlayerCoreX` type have been changed to `IAudioRendererSettings`. You can create the `AudioRendererSettings` class instance from `AudioOutputDeviceInfo` using the default constructor.
* [X-engines] Resolved problem with missed Media Foundation sources during device enumeration
* [X-engines] Resolved RTSP source problems with audio connection in some situations
* [X-engines] Added the RTSP Preview Demo to Media Blocks SDK .Net
* [Windows] FFMPEG outputs and source updated to FFMPEG v7.0.
* [X-engines] Fixed rare crashes in RTSP source when camera information is not available for some reason (network issue)
* [X-engines] Resolved an issue with `WASAPI/WASAPI2` audio renderer usage
* [X-engines] Resolved an issue with the audio loopback audio source on Windows
* [X-engines] Improved iOS video rendering performance and stability
* [X-engines] Added AWS S3 Sink output for Media Blocks SDK .Net
* [X-engines] Added Allied Vision USB3/GigE cameras support in Media Blocks SDK .Net and Video Capture SDK .Net

## 15.9

* [X-engines] Resolved wrong aspect ratio with video resize effect/block
* [X-engines] Updated GStreamer redist
* [X-engines] Added Basler USB3/GigE cameras support in Media Blocks SDK .Net and Video Capture SDK .Net
* [Video Edit SDK .Net] VideoEditCoreX: The TextOverlay class changed to use SkiaSharp-based font settings. Additionally, you can set the custom font file name or configure all rendering parameters using custom SKPaint.
* [Windows] Added Stream support in `MediaInfoReader`. You can get the video/audio file information from a stream (DB, network, memory, etc.).
* [X-engines] Updated Live Video Compositor engine, which improved support of the file sources
* [Video Capture SDK .Net] Added camera-covered detector into the `Computer Vision Demo` and the `VisioForge.Core.CV` package
* [X-engines] Added API to get snapshots from video files using MediaInfoReaderX: GetFileSnapshotBitmap, GetFileSnapshotSKBitmap, GetFileSnapshotRGB
* [X-engines] iOS support in MAUI samples
* [X-engines] Resolved memory leak issue for RTSP sources
* [Media Player SDK .Net] MediaPlayerCore: Added support for data streams in video files using the FFMPEG source engine. Add the OnDataFrameBuffer event to get data frames (KLV or other) from the video file.
* [Video Capture SDK .Net] VideoCaptureCore: Added support for data streams in video files using the IP Capture FFMPEG source engine. Add the OnDataFrameBuffer event to get data frames (KLV or other) from the MPEG-TS UDP network stream or other supported source.
* [Video Capture SDK .Net] VideoCaptureCore: Added the FFMPEG_CustomOptions property to the IPCameraSourceSettings class. This property allows you to set custom FFMPEG options for the IP camera source
* [Windows] Fixed the hang problem with the FFMPEG source when a network connection is lost
* [Media Blocks SDK .Net] Added RTSP MultiView in Sync Demo
* [X-engines] Added support for FLIR/Teledyne cameras (USB3Vision/GigE) using the Spinnaker SDK
* [Video Edit SDK .Net] VideoEditCoreX: Added support for .Net Stream usage as an input source
* The IAsyncDisposable interface was added to all SDK's core classes. The `DisposeAsync` call should be used to dispose of the core objects using async methods.  
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved issues with Android video capture (sometimes started only one time)
* [Media Blocks SDK .Net] Added HLS streaming sample
* [Video Capture SDK .Net] VideoCaptureCore: Resolved crash if the `multiscreen` is enabled and screens added as window's handles (WinForms)
* [X-engines] Improved MAUI video rendering speed
* [X-engines] Resolved MAUI media playback issues (decoding) in MAUI Android
* [X-engines] Resolved an issue with the H264 webcam sources (sometimes not connected)
* [X-engines] Resolved an issue with audio stream playback in the Live VideoCompositor engine
* [Media Blocks SDK .Net] Resolved a bad audio issue while mixing using the Live Video Compositor engine
* [Media Blocks SDK .Net] Added Decklink output and file source into the Live Video Compositor sample
* [Media Player SDK .Net] MediaPlayerCore: Added growing MPEG-TS file support for the VLC engine. You can play growing MPEG-TS files while it's recorded
  
## 15.8

* [X-engines] [API breaking change] DeviceEnumerator can now be used only by using `DeviceEnumerator.Shared` property. One enumerator per app is required. DeviceEnumerator objects used by API have been removed
* [X-engines] [API breaking change] Android Activity is not required anymore to create SDK engines
* [X-engines] [API breaking change] X-engines require additional initialization and de-initialization steps. To initialize SDK, use the `VisioForge.Core.VisioForgeX.InitSDK()` call. To de-initialize SDK, use the `VisioForge.Core.VisioForgeX.DestroySDK()` call. You need to initialize SDK before any SDK class usage and de-initialize SDK before the application exits.
* [Windows] Improved MAUI video rendering performance in Windows
* [Windows] Added a mouse highlight for screen capture sources
* [Windows] Resolved a CallbackOnCollectedDelegate call issue with the BasicWindow class
* [Avalonia] Resolved an issue with Avalonia VideoView resize
* [X-engines] Added the StartPosition and StopPosition properties to UniversalSourceSettings. You can use these properties to set the start and stop positions for the file source.
* [ALL] Resolved the issue with passwords with special characters used for RTSP sources
* [ALL] Resolved the rare video flip issue with the Virtual Camera SDK engine
* [ALL] The VisioForge MJPEG Decoder filter was removed from the SDK's NuGet packages. You can optionally add it to your project by file copying or COM registration deployment.
* [X-engines] Fixed memory leak in the OverlayManager
* [Media Blocks SDK .Net] Resolved issue with the VideoSampleGrabberBlock, SetLastFrame option
* [Video Capture SDK .Net] VideoCaptureCoreX: WASAPI and WASAPI2 audio sources can be used now with the VideoCaptureCoreX engine
* [X-engines] DeviceEnumerator got events to notify about devices added/removed: OnVideoSourceAdded, OnVideoSourceRemoved, OnAudioSourceAdded, OnAudioSourceRemoved, OnAudioSinkAdded, OnAudioSinkRemoved
* [X-engines] Added custom error handler support for MediaBlocks, VideoCaptureCoreX, and MediaPlayerCoreX engines. Use the IMediaBlocksPipelineCustomErrorHandler interface and the SetCustomErrorHandler method to set a custom error handler.
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved issue with incorrect device index error for KS video sources (Windows)
* [Video Capture SDK .Net] VideoCaptureCore: Added Virtual_Camera_Output_AlternativeAudioFilterName property to set a custom audio filter for the Virtual Camera SDK output
* [Video Edit SDK .Net] VideoEditCore: Added Virtual_Camera_Output_AlternativeAudioFilterName property to set a custom audio filter for the Virtual Camera SDK output
* [Media Player SDK .Net] MediaPlayerCore: Added Virtual_Camera_Output_AlternativeAudioFilterName property to set a custom audio filter for the Virtual Camera SDK output
* [Video Capture SDK .Net] VideoCaptureCoreX: Added NDI streaming support and sample app.
* [Media Blocks SDK .Net] Added the BufferSink block to get video/audio frames from the pipeline
* [Media Blocks SDK .Net] Added the CustomMediaBlock class to create custom media blocks for any GStreamer element
* [Media Blocks SDK .Net] Added the UpdateChannel method to update the channel of the bridge source or sink
* [Media Player SDK .Net] MediaPlayerCore: Updated Tempo effect.
* [X-engines] Updated device enumerator. Removed unwanted firewall dialog when listing NDI sources.
* [X-engines] Fixed an issue with the video mixer when adding/removing video sources.
* [Media Blocks SDK .Net] Added VideoCropBlock and VideoAspectRatioCropBlock blocks to crop video frames.
* [Media Blocks SDK .Net] Resolved wrong frame rate issue with VideoRateBlock.
* [All] Resolved an issue with the Tempo audio effect.
* [Video Capture SDK .Net] VideoCaptureCore: Added WASAPI audio renderer support for the VideoCaptureCore engine.

## 15.7

* [ALL] .Net 8 support
* [Video Capture SDK .Net] VideoCaptureCore: Fixed problem with the OnNetworkSourceDisconnect event being called twice.
* [X-engines] Added the MPEG-2 video encoder.
* [X-engines] Added the MP2 audio encoder.
* [X-engines] Resolved Decklink enumeration issues.
* [X-engines] Default VP8/VP9 settings changed to live recording.
* [X-engines] Added DNxHD video encoder support.
* [Video Capture SDK .Net] VideoCaptureCoreX: Fixed problem with audio source format setting (regression).
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved WPF native rendering issue with a pop-up window.
* [All] Avalonia 11.0.5 support.
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved licensing issues.
* [Video Capture SDK .Net] VideoCaptureCore: Start/StartAsync method will return false if the video capture device is already used by another application.
* [All] Updated VLC source (libVLC 3.0.19).
* [All] Updated FFMPEG sources and encoders. Resolved issue with missed MSVC dependencies.
* [Video Capture SDK] Updated ONVIF engine.
* [Cross-platform SDKs] Updated Decklink source. Resolved the issue with the incorrect device name.
* [All] SkiaSharp security updates.
* [Cross-platform SDKs] Updated Overlay Manager. Added OverlayManagerDateTime class to draw current date time and custom text.
* [Cross-platform SDKs] Updated OverlayManagerImage. Resolved issue with System.Drawing.Bitmap usage.
* [ALL] VideoCaptureCore: Resolved rare crash issue with WinUI VideoView
* [Video Capture SDK .Net] VideoCaptureCore: Updated FFMPEG.exe output. Improved support of x264 and x265 encoders of custom FFMPEG builds.

## 15.6

* [Video Capture SDK .Net] VideoCaptureCore: Improved video crop performance on modern CPUs
* [ALL] VideoCaptureCore, MediaPlayerCore, VideoEditCore: Added the static CreateAsync method that can be used instead of the constructor to create engines without UI lag.
* [Video Capture SDK .Net] VideoCaptureCore: Resolved issues with video crop.
* [Video Capture SDK .Net] VideoCaptureCoreX: Added video overlays API. The Overlay Manager Demo shows how to use it.
* [Video Capture SDK .Net] Improved HW encoder detection. If you have several GPUs, sometimes only the major GPU can be used for video encoding.
* [Cross-platform SDKs] Updated Avalonia VideoView. Resolved issue with VideoView recreation.
* [Media Player SDK .Net] MediaPlayerCoreX: Resolved startup issue with the Android version of the MediaPlayerCoreX engine.
* [Media Player SDK .Net] MediaPlayerCore: Video_Stream_Index property has been replaced with Video_Stream_Select/Video_Stream_SelectAsync methods.
* [Media Player SDK .Net] MediaPlayerCoreX: Added Video_Stream_Select method.
* [Video Capture SDK .Net] VideoCaptureCore: Network_Streaming_WMV_Maximum_Clients property moved to WMVOutput class. You can set the maximum number of clients for network WMV output.
* [All] Updated WPF rendering. Improved performance for 4K and 8K videos.
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved issue with multiple outputs used.
* [Video Capture SDK .Net] VideoCaptureCoreX: Resolved issue with OnAudioFrameBuffer event.
* [Video Capture SDK .Net] Decklink source changed to improve startup speed. The Decklink_CaptureDevices method has been replaced by async Decklink_CaptureDevicesAsync.
* [Media Player SDK .Net] MediaPlayerCoreX: Added Custom_Video_Outputs/Custom_Audio_Outputs properties to set custom video/audio renderers
* [Media Player SDK .Net] MediaPlayerCoreX: Added Decklink Output Player Demo (WPF)
* [Video Edit SDK .Net] Added Multiple Audio Tracks Demo (WPF)
* [Video Edit SDK .Net] Updated MP4 output for multiple audio tracks
* [Cross-platform SDKs] Updated device enumerator
* [Video Capture SDK .Net] Resolved issue with VU meter in cross-platform engine
* [Cross-platform SDKs] Resolved issue with VU Meter (event not fired)
* [Media Player SDK .Net] Updated memory playback
* [ALL] Added IAsyncDisposable interface support for cross-platform core classes. It should be used to dispose of the core objects in async methods.
* [Video Capture SDK .Net] Added madVR support for mutiscreen
* [Video Capture SDK .Net] Resolved NDI enumerating issue in the VideoCaptureCore engine
* [Media Player SDK .Net] Added madVR Demo
* [Video Capture SDK .Net] Added madVR Demo
* [ALL] Resolved madVR issues in all SDKs
* [Media Blocks SDK .Net] Added NDI Source demo
* [Video Capture SDK .Net] Added NDI support for cross-platform engine
* [ALL] Resolve the "image not found" issue with the WinUI NuGet package
* [Media Blocks SDK .Net/Media Player SDK .Net (cross-platform)] Added MP3+CDG Karaoke Player demo
* [Media Blocks SDK .Net] Added CDGSourceBlock for MP3+CDG karaoke files playback
* [ALL] Improved madVR support
* WinUI VideoView updated to fix issues during audio file playback
* [Video Capture SDK .Net] Improved VNC source support for the VideoCaptureCoreX engine.
* [Video Capture SDK .Net] Added VNC source support for the VideoCaptureCoreX engine. You can use VNCSourceSettings class to configure Video_Source.
* [Media Blocks SDK .Net] Added VNC source support. You can use the VNCSourceBlock class as a video source block.
* [Video Capture SDK .Net] Video_Resize property has been changed to IVideoResizeSettings type. You can use the VideoResizeSettings class to perform classic resize the same as before or use MaxineUpscaleSettings/MaxineSuperResSettings to perform AI resizing on Nvidia GPU using Nvidia Maxine SDK (SDK or SDK models are required to deploy).
* [ALL] Resolved issues with NDI source detection in the local network
* [ALL] Added KLVParser class to read and decode data from KLV binary files.
* [ALL] Added KLVFileSink block. You can export KLV data from MPEG-TS files.
* [Media Blocks SDK .Net] Added KLV demo.
* [Video Capture SDK .Net] Added MJPEG network streamer.
* [ALL] Added WASAPI 2 support.
* [Media Blocks SDK .Net] Updated Video Effects API. Added Grayscale media block.
* [Media Blocks SDK .Net] Added Live Video Compositor API and sample.
* [ALL] Updated Avalonia VideoView control. Resolved issues with video playback on Windows on HighDPI displays.
* [Video Capture SDK .Net] Added CustomVideoFrameRate property to MFOutput. You can set a custom frame rate if your source provides an incorrect frame rate (IP camera, for example).
* [Video Capture SDK .Net] Updated NVENC encoder. Resolved issue with high-definition video capture.
* [Video Capture SDK .Net] Resolved issue with TV Tuning on Avermedia devices
* [Media Blocks SDK .Net] Added OpenCV blocks: CVDewarp, CVDilate, CVEdgeDetect, CVEqualizeHistogram, CVErode, CVFaceBlur, CVFaceDetect, CVHandDetect, CVLaplace, CVMotionCells, CVSmooth, CVSobel, CVTemplateMatch, CVTextOverlay, CVTracker
* [CV] Resolved the issue with wrong face coordinates.
* [CV, Media Blocks SDK .Net] Added Face Detector block.
* [Media Blocks SDK .Net] Added rav1e AV1 video encoder.
* [Media Blocks SDK .Net] Added GIF video encoder.
* [Media Blocks SDK .Net] Added NDI Sink and NDI source blocks.
* [ALL] Resolved NDI SDK detection issues.
* [Media Blocks SDK .Net] Updated Speex encoder.
* [Media Blocks SDK .Net] Updated Video Mixer block.
* [ALL] Added Save/Load methods for output format to serialize into JSON.
* [Media Blocks SDK .Net] Added MJPEG HTTP Live streaming sink block.
* [ALL] Resolved MP4 HW QSV H264 regression.
* [ALL] WinForms and WPF VideoView stability updates.
* [Media Player SDK .Net] Removed FilenamesOrURL legacy property. Please use the `Playlist` API instead.
* [Media Blocks SDK .Net] Added fade-in/out feature for image overlay block.
* [ALL] Telemetry update
* [ALL] SDKs updated to use the `ObservableCollection` instead of the `List` in public API.
* [ALL] Updated MP4 HW output. Improved NVENC performance.
* [Media Blocks SDK .Net] Added Video Compositor sample.
* [Media Blocks SDK .Net] Added YouTubeSink and FacebookLiveSink blocks with custom YouTube/Facebook configurations. The `RTMPSink` can stream to YouTube/Facebook in the same way as before.
* [Media Blocks SDK .Net] Added SqueezeBack video mixer block.
* [ALL] Updated scrolling text logo. We've added the Preload method to render a text overlay before playback.
* [ALL] Updated scrolling text logo (performance)
* [Media Blocks SDK .Net] Updated Decklink sink blocks
* [ALL] Resolved crashes with a text logo with a custom resolution
* [Media Blocks SDK .Net] Added Intel QuickSync H264, HEVC, VP9, and MJPEG encoders support.
* [Video Edit SDK .Net] Added FastEdit_ExtractAudioStreamAsync method to extract the audio stream from the video file.
* [Video Edit SDK .Net] Added "Audio Extractor" WinForms sample.
* [Media Blocks SDK .Net] Updated MP4SinkBlock. The sink can split output files by duration, file size, or timecode. Use MP4SplitSinkSettings instead of MP4SinkSettings to configure.
* [Video Capture SDK .Net] Added the OnMJPEGLowLatencyRAWFrame event that fired when the MJPEG low latency engine received a RAW frame from a camera.
* [Media Blocks SDK .Net] Added VideoEffectsBlock to use video effects, available in Windows SDKs
* [Media Blocks SDK .Net] Updated Decklink source
* [Media Blocks SDK .Net] Added Decklink Demo (WPF)
* [ALL] Resolved the DeinterlaceBlend video effect crash
* [ALL] Used 3rd-party libraries moved to VisioForge.Libs.External assembly/NuGet
* [ALL] Added Nvidia Maxine Video Effects SDK (BETA) and sample app for Media Player SDK .Net and Video Capture SDK .Net
* [Video Capture SDK .Net] Added Decklink_Input_GetVideoFramesCount/Decklink_Input_GetVideoFramesCountAsync API to get total and dropped frames for the Decklink source
* [ALL] VisioForge HW encoders update

## 15.5

* .Net 7 support
* Added NetworkDisconnect event support to MJPEG Low Latency IP camera engine
* Added Linux support for the VideoEditCoreX-based demos
* Added OnRTSPLowLatencyRAWFrame event to get RAW frames from RTSP stream, using RTSP Low Latency engine
* Added AutoTransitions property to the VideoEditCoreX engine
* System.Drawing.Rectangle and System.Drawing.Size types are replaced by VisioForge.Types.Rectangle and VisioForge.Types.Size in all crossplatform APIs
* MAUI samples (BETA) are added
* Improved compatibility with Snap Camera for MP4 HW encoding
* Online licensing updated
* Added Camera Light demo
* Added segments support in Media Player SDK .Net (Cross-platform engine)
* Added Playlist API in Media Player SDK .Net (Windows-only engine)
* Resolved issues with the "rtsp_source_create_audio_resampler" call in the RTSP Low Latency engine in Video Capture SDK .Net (Windows-only engine)
* Added support for multiple Decklink outputs in Video Capture SDK .Net and Video Edit SDK .Net  (Windows-only engine)
* Resolved issues with the reverse playback engine in Media Player SDK .Net (Windows-only engine)
* ONVIFControl and other ONVIF-related APIs are available for all platforms
* API breaking change: the frame rate changed from double to VideoFrameRate in all APIs
* Added GPU HW decoding for VLC engine
* Resolved issue with WPF HighDPI apps that use EVR
* Resolved issue with MediaPlayerCore.Video_Renderer_SetCustomWindowHandle method
* Added previous frame playback in Media Player SDK .Net (Cross-platform engine)
* Added WPF Screen Capture Demo to Media Blocks SDK .Net

## 15.4

* Resolved an issue with ignored Play_PauseAtFirstFrame property
* Updated HighDPI support in WinForms samples
* Resolved an issue with HighDPI support for the Direct2D video renderer
* Added additional API to ONVIFControl class: GetDeviceCapabilities, GetMediaEndpoints
* Resolved forced reencoding issue with FFMPEG files joining without reencoding
* Sentry update
* Added video interpolation settings for Zoom and Pan video effects
* Added GtkSharp UI framework support for video rendering
* FastEdit API has been changed to async
* Resolved screen flip issue with Video_Effects_AllowMultipleStreams property of Video Capture SDK .Net core
* Updated RTSP MultiView demo (added GPU decoding, added RAW stream access)
* Added OnLoop event into Media Player SDK .Net
* Added Loop feature into Media Blocks SDK .Net
* Avalonia VideoView was downgraded to 0.10.12 because of Avalonia UI problems with NativeControl
* Added File Encryptor demo for Video Edit SDK .Net

## 15.3

* App start-up time improved for PCs with Decklink cards
* NDI SDK v5 support
* Resolved an issue with MKV Legacy output (wrong cast exception).
* Zoom and pan effects performance optimizations
* Added basic Media Blocks API (WIP)
* Added HLS network streaming to Video Edit SDK .Net
* Added Rotate property to WPF VideoView. You can rotate the video by 90, 180, or 270 degrees. Also, you can use the GetImageLayer() method to get the Image layer and apply custom transforms
* API change - FilterHelpers renamed to FilterDialogHelper
* VisioForge.Types and VisioForge.MediaFramework assemblies merged into VisioForge.Core
* UI classes moved to VisioForge.Core.UI.* assemblies and independent NuGet packages
* VisioForge.Types renamed to VisioForge.Core.Types
* VisioForge.Core no longer depends on the Windows Forms framework

## 15.2

* Added HorizontalAlignment and VerticalAlignment properties to the text and image logos
* Updated ONVIF support, resolved an issue with username and password specified in URL but not specified in source settings
* Resolved an issue with the FFMPEG.exe output dialog
* Resolved an issue with the separate capture in a service applications
* SDK migrated to System.Text.Json from NewtonsoftJson
* Updated DirectCapture output for IP cameras
* Video processing performance optimizations
* IPCameraSourceSettings.URL property type changed from string to a `System.Uri`
* Added DirectCapture ASF output for IP cameras

## 15.1

* Disabled Sentry debug messages in the console
* Added Icecast streaming
* VideoStreamInfo.FrameRate property type changed to VideoFrameRate (with numerator and denominator) from double
* Updated WPF VideoView, resolved the issue for IP camera stream playback
* API breaking change: `VisioForge.Controls`, `VisioForge.Controls.UI`, `VisioForge.Controls.UI.Dialogs`, and `VisioForge.Tools` assemblies are merged inside the `VisioForge.Core` assembly
* Audio effect API now uses string name instead of index
* Added Android support in Media Player SDK .Net
* Added a new GStreamer-based cross-platform engine to support Windows and other platforms within the v15 development cycle

## 15.0

* Added StatusOverlay property for VideoCapture class. Assign the `TextStatusOverlay` object to this property to add text status overlay, for example, to show "Connecting..." text during IP camera connecting.
* RTSP Live555 IP camera engine has been removed. Please use RTSP Low Latency or FFMPEG engines.
* Resolved SDK_Version possible issue.
* Added Settings_Load API. You can load the settings file saved by Settings_JSON. Be sure that device names are correct.
* Resolved issue with an exception if separate capture started before Start/StartAsync method call.
* RTP support for the VLC source engine.
* API breaking change: SDK_State property has been removed. We do not have TRIAL and FULL SDK versions anymore.
* API breaking change: DirectShow_Filters_Show_Dialog, DirectShow_Filters_Has_Dialog, Audio_Codec_HasDialog, Audio_Codec_ShowDialog, Video_Codec_HasDialog, Video_Codec_ShowDialog, Filter_Supported_LAV, Filter_Exists_MatroskaMuxer, Filter_Exists_OGGMuxer, Filter_Exists_VorbisEncoder, Filter_Supported_EVR, Filter_Supported_VMR9 and Filter_Supported_NVENC has been moved to VisioForge.Tools.FilterHelpers class.
* The `VFAudioStreamInfo`/`VFVideoStreamInfo` classes use the `Timespan` for the duration.
* Decklink types from VisioForge.Types assembly moved to VisioForge.Types.Decklink namespace.
* Telemetry updated.
* Custom redist loader updated.
* NDI update.
* API breaking change: The `Status` property was renamed to the `State`. The property type is `PlaybackState` in all SDKs.
* API breaking change: UI controls split into Core (VideoCaptureCore, MediaPlayerCore, VideoEditCore) and VideoView.
* API breaking change: Video_CaptureDevice... properties merged into Video_CaptureDevice property of VideoCaptureSource type.
* API breaking change: Audio_CaptureDevice... properties merged into Audio_CaptureDevice property of AudioCaptureSource type.
* API breaking change: In the Media Player SDK, the `Source_Stream` API properties were merged into the `Source_MemoryStream` property of the `MemoryStreamSource` type
* Updated DVD playback
* Updated FFMPEG source
* API breaking change: Media Player SDK types moved from VisioForge.Types namespace to VisioForge.Types.MediaPlayer
* API breaking change: Video Capture SDK types moved from VisioForge.Types namespace to VisioForge.Types.VideoCapture
* API breaking change: Video Edit SDK types moved from VisioForge.Types namespace to "VisioForge.Types.VideoEdit"
* API breaking change: Output types moved from VisioForge.Types namespace to VisioForge.Types.Output
* API breaking change: Video Effects types moved from VisioForge.Types namespace to VisioForge.Types.VideoEffects
* API breaking change: Audio Effects types moved from VisioForge.Types namespace to VisioForge.Types.AudioEffects
* API breaking change: Event types moved from VisioForge.Types namespace to VisioForge.Types.Events
* Added Video_Renderer_SetCustomWindowHandle method to set custom video renderer by Win32 window/control HWND handle

## 14.4

* Windows 11 support
* Telemetry update
* Resolved issues with Picture-in-Picture in 2x2 mode
* Resolved issues with MJPEG Low Latency source in .Net 5/.Net 6/.Net Core 3.1
* Resolved issue with UDP network streaming for Decklink source
* VFMP4v11Output renamed to VFMP4HWOutput
* Added Microsoft H265 encoder support
* Added Intel QuickSync H265 encoder support
* Added OnDecklinkInputDisconnected/OnDecklinkInputReconnected events
* Updated Decklink output
* Resolved issues with Separate capture for MP4 HW, MOV, MPEG-TS, and MKVv2 outputs
* Added Video_CaptureDevice_CustomPinName property. You can use this property to set a custom output pin name for a video capture device with several output video pins
* Custom redist configuration updated
* Updated IP camera RTSP Low Latency engine

## 14.3

* An issue with Video Resize filter creation for NuGet redists has been resolved
* Telemetry update
* Updated VFDirectCaptureMP4Output output
* .Net 6 (preview) support
* Nvidia CUDA removed. NVENC is a modern alternative and is available for H264/HEVC encoding.
* IP camera MJPEG Low Latency engine has been updated
* The NDI source listing has been updated
* Improved ONVIF support
* Added .Net Core 3.1 support for RTSP Low Latency source engine
* Resolved issues with Picture-in-Picture for 2x2 mode
* Split project and solutions by independent files for .Net Framework 4.7.2, .Net Core 3.1, .Net 5 and .Net 6

## 14.2

* An issue with audio stream capture with enabled Virtual Camera SDK output was resolved
* VFMP4v8v10Output was replaced with VFMP4Output
* The "CanStart" method was added for Video_CaptureDevices items. The method returns true if the device can start and is not used exclusively in another app
* Added async/await API to the ONVIFControl
* An issue with wrong ColorKey processing in the Text Overlay video effect was resolved
* Added forced frame rate support for the RTSP Low Latency IP camera source
* MP4v11 AMD encoders were updated
* The timestamp issue that happened during the MP4v11 separate capture pause/resume was resolved
* FFMPEG.exe network streaming update
* FFMPEG output was updated to the latest FFMPEG version
* VC++ redist is no longer required to be installed. VC++ linking changed to static (except optional XIPH output)
* Many base DirectShow filters moved to the VisioForge_BaseFilters module

## 14.1

* Added WPF VideoView control. You can push video frames from the OnVideoFrameBuffer event to control to render them
* Correct default transparency value for a text logo
* ONVIF support added to .Net 5 / .Net Core 3.1 builds
* Added IP_Camera_ONVIF_ListSourcesAsync method to discover ONVIF cameras in the local network
* (BREAKING API CHANGE) Changed video capture device API for frame rates enumerating to support modern 4K cameras
* Updated MJPEG Decoder (improved performance)
* Removed MP4 v8 legacy encoders
* INotifyPropertyChanged support in WinForms/WPF wrappers to provide MVVM application support
* Resolved issue with RTMPS streaming to Facebook
* IP camera source added to the TimeShift demo
* Added separate output support for MOV
* Added fast-start FFMPEG flag for MP4v11 output that used FFMPEG MP4 muxer
* Added GPU decoding for the IP Camera source in demo applications
* Added CustomRedist_DisableDialog property to disable the redist message dialog
* Removed Kinect assemblies and demos. Please contact us if you still need Kinect packages
* MP4v10 default profile has been changed to Baseline / 5.0 for better browser compatibility

## 14.0

* .Net 5.0 support
* Resolved issue with not visible Decklink sources in NuGet SDK version
* Resolved issue with device added/removed notifier
* Added alternative NDI source in Video Capture SDK .Net
* Added NDI streaming (server) in Video Capture SDK .Net
* Resolved Separate Capture usage issue for NuGet deployment
* Resolved issue with merged text/image logos
* Updated device notifier
* Added CameraPowerLineControl class to control webcam power line frequency option
* Legacy audio effects have been removed.
* Removed HTTP_FFMPEG, RTSP_UDP_FFMPEG, RTSP_TCP_FFMPEG and RTSP_HTTP_FFMPEG from VFIPSource enumeration. You can use the Auto_FFMPEG value
* Updated HLS server. Correct error reporting about used port
* Added NDI streaming (server) in Video Edit SDK .Net
* Added NDI streaming (server) in Media Player SDK .Net
* Added IP_Camera_CheckAvailable method in Video Capture SDK .Net
* Updated FFMPEG Source filter, more supported codecs, and added GPU decoding

## 12.1

* Migrated to .Net 4.6
* Added Debug_DisableMessageDialogs property to disable error dialog if OnError event is not implemented.
* Fixed issue with resizing on the pause for WPF controls.
* Updated ONVIF engine in Video Capture SDK .Net
* Updated What You Hear source in Video Capture SDK .Net
* Added OnPause/OnResume events
* Updated YouTube demo in Media Player SDK .Net
* Improved support of webcams with integrated H264 encoder in Video Capture SDK .Net
* Updated VLC source
* Removed unwanted warning in MP4 v11 output
* One installer for TRIAL and FULL versions
* Same NuGet packages for TRIAL and FULL versions
* .Net Core NuGet packaged merged with .Net Framework package
* Added NuGet redists. Deployment was never so simple!

## 12.0

* Async / await API for all SDKs
* Breaking API change: All time-related API now uses TimeSpan instead of long (milliseconds)
* Tag reader/writer - correct logo loading for some video formats
* Removed legacy DirectX 9 video effects
* Fixed audio conversion progress issue in Video Edit SDK .Net
* Improved .Net Core compatibility
* Virtual Camera SDK output added to Media Player SDK .Net (as one of the video renderers)
* NewTek NDI devices support added to Video Capture SDK .Net as a new engine for IP cameras
* Added Video_Effects_MergeImageLogos and Video_Effects_MergeTextLogos properties. If you have three or more logos, you can set these properties to true to optimize video effects' performance
* Added playlist type option for HLS network streaming
* Added integrated lightweight HTTP server for HLS network streaming
* Added VR 360° video support in Media Player SDK .Net
* Improved DirectX 11 video processing
* Added MPEG-TS AAC-only no video support for MPEG-TS output
* Improved What You Hear audio source
* Several new demo applications
* Improved MP4 v11 output
* Separate capture for MP4 v11 can split files without frame lose
* Many minor bugfixes
* .Net Core assemblies updated to .Net Core 3.1 LTS
* Updated demos repository on GitHub

## 11.4

* Added ASP.Net MVC video conversion demo app to Video Edit SDK .Net
* Alternative OSD implementation to handle Windows 10 changes
* Updated GPU video effects
* Updated memory source in Media Player SDK .Net
* Updated OSD API
* Resolved issues with video encryption using binary keys
* Update screen capture demos for Video Capture SDK .Net, added window selection to capture. You can capture any window, including windows in the background
* Mosaic effect added for Computer Vision demo in Video Capture SDK .Net
* Added Multiple IP Cameras Demo (WPF) in Video Capture SDK .Net
* Added custom video resize option for MP4v11 output
* Merge module (MSM) redists added to all SDKs
* Updated FFMPEG.exe output using pipes instead of virtual devices
* Resolved issue with PIP custom output resolution option in Video Capture SDK .Net
* Resolved issue with file lock using LAV engine in Media Player SDK .Net
* Added DirectX11-based GPU video processing

## 11.3

* Resolved issue with audio renderer connection if Virtual Camera SDK output enabled in Video Capture SDK
* Improved subtitles support with autoloading in Media Player SDK .Net
* Updated audio fade-in/fade-out effects
* Added MIDI and KAR files support in Media Player SDK .Net
* Added CDG karaoke files support (and new demo application) in Media Player SDK .Net
* Added Async playback in Media Player SDK .Net
* Updated integrated JSON serializer
* Added optional GPU decoding in Media Player SDK .Net. Available decoding engines: DXVA2, Direct3D 11, nVidia CUVID, Intel QuickSync
* Added .Net Core 3.0 support, including WinForms and WPF demo apps (Windows only)

## 11.2

* Added Loop property to Video Edit SDK .Net
* Updated audio enhancer
* Updated RTSP Low Latency source
* Resolved crop issue for Decklink source
* Added property to use TCP or UDP in RTSP Low Latency engine
* Deployment without COM registration and admin rights for Video Edit SDK and Media Player SDK (BETA)
* Updated video mixer with improved performance
* Added YouTube playback code snippet
* Added method to move OSD

## 11.1

* Fixed seeking issue with some MP4 files in Video Edit SDK
* Fixed stretch/letterbox issue in the WPF version of all SDKs
* Fixed issue with an equalizer on sample rate 16000 or less
* Fixed problem with sample grabber for DirectShow source in Media Player SDK
* Fixed encrypted files playback in Media Player SDK
* Added DVDInfoReader class to read info about DVD files
* Resolved issue with wrong file name in OnSeparateCaptureStopped event
* Improved barcode detection quality for rotated images
* The minimal .Net Framework version is .Net 4.5 now
* Improved YouTube playback in Media Player SDK. Added OnYouTubeVideoPlayback event to select video quality for playback
* Added the `Play_PauseAtFirstFrame` property to the Media Player SDK .Net. If true playback will be paused on the first frame
* Multiple screen support in Screen Capture demo in Video Capture SDK .Net
* Resolved issue with network stream playback in Media Player SDK .Net WPF applications
* Added low latency HTTP MJPEG stream playback (IP cameras or other sources) in Video Capture SDK .Net
* Added Fake Audio Source DirectShow filter, which produces a tone signal
* Updated Computer Vision demo in Video Capture SDK .Net
* Added Frame_GetCurrentFromRenderer method to all SDKs. Using this method, you can get the currently rendered video frame directly from the video renderer.
* Added low latency RTSP source playback in Video Capture SDK .Net

## 11.0

* Fixed bug with MP4 v11 output, custom GOP settings
* Updated MJPEG Decoder
* Fixed bug with MP4 v11 output. Added Windows 7 full support
* OnStop event of Video Edit SDK returns a successful status
* Video Capture SDK Main Demo update - multiscreen can automatically use connected external displays
* Media Player SDK Main Demo update - multiscreen can automatically use connected external displays
* Added fade-in / fade-out for text logo
* Updated Decklink output
* Video Edit SDK can fast-cut files from network sources (HTTP/HTTPS)
* Added Computer Vision demo, with cars/pedestrian counter and face/eyes/nose/mouth detector/tracker
* Updated MP4 output to use alternative muxer that provides constant frame rate
* Added MPEG-TS output
* Added MOV output
