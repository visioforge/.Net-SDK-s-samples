# Changelog

## 15.5.66

* [Media Blocks SDK .Net/Media Player SDK .Net (crossplatform)] Added MP3+CDG Karaoke Player demo
* [Media Blocks SDK .Net] Added CDGSourceBlock for MP3+CDG karaoke files playback
* [ALL] Improved madVR support

## 15.5.65

* WinUI VideoView updated to fix issues during audio files playback

## 15.5.63

* [Video Capture SDK .Net] Improved VNC source support for the VideoCaptureCoreX engine.

## 15.5.61

* [Video Capture SDK .Net] Added VNC source support for the VideoCaptureCoreX engine. You can use VNCSourceSettings class to configure Video_Source.
* [Media Blocks SDK .Net] Added VNC source support. You can use VNCSourceBlock class as a video source block.

## 15.5.60

* [Video Capture SDK .Net] Video_Resize property has been changed to IVideoResizeSettings type. You can use VideoResizeSettings class to perform classic resize the same as before or use MaxineUpscaleSettings/MaxineSuperResSettings to perform AI resing on Nvidia GPU using Nvidia Maxine SDK (SDK or SDK models are required to deploy).

## 15.5.57

* [ALL] Resolved issues with NDI sources detection in the local network

## 15.5.50

* [ALL] Added KLVParser class to read and decode data from KLV binary files.
* [ALL] Added KLVFileSink block. You can export KLV data from MPEG-TS files.
* [Media Blocks SDK .Net] Added KLV demo.

## 15.5.45

* [Video Capture SDK .Net] Added MJPEG network streamer.

## 15.5.43

* [ALL] Added WASAPI 2 support.
* [Media Blocks SDK .Net] Updated Video Effects API. Added Grayscale media block.

## 15.5.42

* [Media Blocks SDK .Net] Added Live Video Compositor API and sample.

## 15.5.41

* [ALL] Updated Avalonia VideoView control. Resolved issues with video playback on Windows on HighDPI displays.

## 15.5.40

* [Video Capture SDK .Net] Added CustomVideoFrameRate property to MFOutput. You can set a custom frame rate if your source provides an incorrect frame rate (IP camera, for example).

## 15.5.39

* [Video Capture SDK .Net] Updated NVENC encoder. Resolved issue with high-definition video capture.

## 15.5.37

* [Video Capture SDK .Net] Resolved issue with TV Tuning on Avermedia devices

## 15.5.36

* [Media Blocks SDK .Net] Added OpenCV blocks: CVDewarp, CVDilate, CVEdgeDetect, CVEqualizeHistogram, CVErode, CVFaceBlur, CVFaceDetect, CVHandDetect, CVLaplace, CVMotionCells, CVSmooth, CVSobel, CVTemplateMatch, CVTextOverlay, CVTracker

## 15.5.35

* [CV] Resolved the issue with wrong face coordinates.
* [CV, Media Blocks SDK .Net] Added Face Detector block.
* [Media Blocks SDK .Net] Added rav1e AV1 video encoder.
* [Media Blocks SDK .Net] Added GIF video encoder.

## 15.5.34

* [Media Blocks SDK .Net] Added NDI Sink and NDI source blocks.
  
## 15.5.32

* [ALL] Resolved NDI SDK detection issues.

## 15.5.31

* [Media Blocks SDK .Net] Updated Speex encoder.

## 15.5.30

* [Media Blocks SDK .Net] Updated Video Mixer block.

## 15.5.29

* [ALL] Added Save/Load methods for output format to serialize into JSON.
* [Media Blocks SDK .Net] Added MJPEG HTTP Live streaming sink block.
* [ALL] Resolved MP4 HW QSV H264 regression.

## 15.5.27

* [ALL] WinForms and WPF VideoView stability updates.
* [Media Player SDK .Net] Removed FilenamesOrURL legacy property. Please use Playlist_... API instead.
* [Media Blocks SDK .Net] Added fade-in/out feature for image overlay block.

## 15.5.25

* [ALL] Telemetry update

## 15.5.24

* [ALL] SDKs updated to use the ObservableCollection instead of List in public API.
* [ALL] Updated MP4 HW output. Improved NVENC performance.

## 15.5.23

* [Media Blocks SDK .Net] Added Video Compositor sample.

## 15.5.21

* [Media Blocks SDK .Net] Added YouTubeSink and FacebookLiveSink blocks with custom YouTube/Facebook configurations. RTMPSink can stream to YouTube/Facebook the same as before.

## 15.5.20

* [Media Blocks SDK .Net] Added SqueezeBack video mixer block.

## 15.5.19

* [ALL] Updated scrolling text logo. Added the Preload method to render a text overlay before playback.

## 15.5.17

* [ALL] Updated scrolling text logo (performance)
* [Media Blocks SDK .Net] Updated Decklink sink blocks

## 15.5.16

* [ALL] Resolved crash with a text logo with a custom resolution

## 15.5.12

* [Media Blocks SDK .Net] Added Intel QuickSync H264, HEVC, VP9 and MJPEG encoders support.
* [Video Edit SDK .Net] Added FastEdit_ExtractAudioStreamAsync method to extract the audio stream from the video file.
* [Video Edit SDK .Net] Added "Audio Extractor" WinForms sample.

## 15.5.11

* [Media Blocks SDK .Net] Updated MP4SinkBlock. The sink can split output files by duration, file size or timecode. Use MP4SplitSinkSettings instead MP4SinkSettings to configure.
* [Video Capture SDK .Net] Added the OnMJPEGLowLatencyRAWFrame event that fired when the MJPEG low latency engine received a RAW frame from a camera.

## 15.5.10

* [Media Blocks SDK .Net] Added VideoEffectsBlock to use video effects, available in Windows SDKs

## 15.5.9

* [Media Blocks SDK .Net] Updated Decklink source
* [Media Blocks SDK .Net] Added Decklink Demo (WPF)

## 15.5.8

* [ALL] Resolved the DeinterlaceBlend video effect crash
* [ALL] Used 3rd-party libraries moved to VisioForge.Libs.External assembly/NuGet

## 15.5.7

* [ALL] Added Nvidia Maxine Video Effects SDK (BETA) and sample app for Media Player SDK .Net and Video Capture SDK .Net

## 15.5.4

* [Video Capture SDK .Net] Added Decklink_Input_GetVideoFramesCount/Decklink_Input_GetVideoFramesCountAsync API to get total and dropped frames for the Decklink source

## 15.5.2

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
* Updated RTSP MultiView demo (added GPU decoding, added RAW streams access)
* Added OnLoop event into Media Player SDK .Net
* Added Loop feature into Media Blocks SDK .Net
* Avalonia VideoView downgrade to 0.10.12 because of Avalonia UI problems with NativeControl
* Added File Encryptor demo for Video Edit SDK .Net

## 15.3

* App start-up time improved for PCs with Decklink cards
* NDI SDK v5 support
* Resolved an issue with MKV Legacy output (wrong cast exception).
* Zoom and pan effects performance optimizations
* Added basic Media Blocks API (WIP)
* Added HLS network streaming to Video Edit SDK .Net
* Added Rotate property to WPF VideoView. You can rotate the video by 90, 180, or 270 degrees. Also, you can use GetImageLayer() method to get the Image layer and apply custom transforms
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
* IPCameraSourceSettings.URL property type changed from string to a "System.Uri"
* Added DirectCapture ASF output for IP cameras

## 15.1

* Disabled Sentry debug messages in the console
* Added Icecast streaming
* VideoStreamInfo.FrameRate property type changed to VideoFrameRate (with numerator and denominator) from double
* Updated WPF VideoView, resolved the issue for IP cameras stream playback
* API breaking change: VisioForge.Controls, VisioForge.Controls.UI, VisioForge.Controls.UI.Dialogs, and VisioForge.Tools merged inside VisioForge.Core
* Audio effect API now uses string name instead of index
* Added Android support in Media Player SDK .Net
* Added a new GStreamer-based cross-platform engine to support Windows and other platforms within the v15 development cycle

## 15.0

* Added StatusOverlay property for VideoCapture class. Assign TextStatusOverlay object to this property to add text status overlay, for example, to show "Connecting..." text during IP camera connecting.
* RTSP Live555 IP camera engine has been removed. Please use RTSP Low Latency or FFMPEG engines.
* Resolved SDK_Version possible issue.
* Added Settings_Load API. You can load the settings file saved by Settings_JSON. Be sure that device names are correct.
* Resolved issue with an exception if separate capture started before Start/StartAsync method call.
* RTP support for the VLC source engine.
* API breaking change: SDK_State property has been removed. We do not have TRIAL and FULL SDK versions anymore.
* API breaking change: DirectShow_Filters_Show_Dialog, DirectShow_Filters_Has_Dialog, Audio_Codec_HasDialog, Audio_Codec_ShowDialog, Video_Codec_HasDialog, Video_Codec_ShowDialog, Filter_Supported_LAV, Filter_Exists_MatroskaMuxer, Filter_Exists_OGGMuxer, Filter_Exists_VorbisEncoder, Filter_Supported_EVR, Filter_Supported_VMR9 and Filter_Supported_NVENC has been moved to VisioForge.Tools.FilterHelpers class.
* VFAudioStreamInfo/VFVideoStreamInfo duration type changed to Timespan.
* Decklink types from VisioForge.Types assembly moved to VisioForge.Types.Decklink namespace.
* Telemetry updated.
* Custom redist loader updated.
* NDI update.
* API breaking change: Status property changes to State, type is PlaybackState in all SDKs.
* API breaking change: UI controls split into Core (VideoCaptureCore, MediaPlayerCore, VideoEditCore) and VideoView.
* API breaking change: Video_CaptureDevice... properties merged into Video_CaptureDevice property of VideoCaptureSource type.
* API breaking change: Audio_CaptureDevice... properties merged into Audio_CaptureDevice property of AudioCaptureSource type.
* API breaking change: In Media Player SDK Source_Stream... properties were merged into the Source_MemoryStream property of MemoryStreamSource type
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
* The timestamp issue that happened during MP4v11 separate capture pause/resume was resolved
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
* INotifyPropertyChanged support in WinForms/WPF wrappers to provide MVVM applications support
* Resolved issue with RTMPS streaming to the Facebook
* IP camera source added to the TimeShift demo
* Added separate output support for MOV
* Added fast-start FFMPEG flag for MP4v11 output that used FFMPEG MP4 muxer
* Added GPU decoding for the IP Camera source in demo applications
* Added CustomRedist_DisableDialog property to disable the redist message dialog
* Removed Kinect assemblies and demos. Please contact us if you still need Kinect packages
* MP4v10 default profile has been changed to Baseline / 5.0 for better browsers compatibility

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
* Fixed issue with resizing on pause for WPF controls.
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
* Added NuGet redists. Deployment never was so simple!

## 12.0

* Async / await API for all SDKs
* Breaking API change: All time-related API now uses TimeSpan instead of long (milliseconds)
* Tag reader/writer - correct logo loading for some video formats
* Removed legacy DirectX 9 video effects
* Fixed audio conversion progress issue in Video Edit SDK .Net
* Improved .Net Core compatibility
* Virtual Camera SDK output added to Media Player SDK .Net (as one of the video renderers)
* NewTek NDI devices support added to Video Capture SDK .Net as a new engine for IP cameras
* Added Video_Effects_MergeImageLogos and Video_Effects_MergeTextLogos properties. If you have 3 or more logos you can set these properties to true to optimize video effects' performance
* Added playlist type option for HLS network streaming
* Added integrated lightweight HTTP server for HLS network streaming
* Added VR 360° videos support in Media Player SDK .Net
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
* Updated FFMPEG.exe output using pipes instead virtual devices
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
* Added Play_PauseAtFirstFrame property in Media Player SDK .Net. If true playback will be paused on the first frame
* Multiple screen support in Screen Capture demo in Video Capture SDK .Net
* Resolved issue with network streams playback in Media Player SDK .Net WPF applications
* Added low latency HTTP MJPEG stream playback (IP cameras or other sources) in Video Capture SDK .Net
* Added Fake Audio Source DirectShow filter, which produces a tone signal
* Updated Computer Vision demo in Video Capture SDK .Net
* Added Frame_GetCurrentFromRenderer method to all SDKs. Using this method you can get the currently rendered video frame directly from the video renderer.
* Added low latency RTSP source playback in Video Capture SDK .Net

## 11.0

* Fixed bug with MP4 v11 output, custom GOP settings
* Updated MJPEG Decoder
* Fixed bug with MP4 v11 output, Windows 7 now fully supported
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
