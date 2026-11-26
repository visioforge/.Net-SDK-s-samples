# Media Blocks SDK .Net - rtsp-save-original-short-console (C#/Console)

The sample of the short video "Save an RTSP Camera to MP4 Without Re-encoding in C#": a console app that writes an IP camera's own H.264 or H.265 video and AAC sound into `camera.mp4`, with no decoder and no encoder. Pass the camera's RTSP URL as the first argument and put its user name and password into `RTSPRAWSourceSettings.CreateAsync`. `RTSPRAWSourceBlock` hands over the camera's encoded streams, TCP transport keeps the camera's own frame timing, and `MP4SinkBlock` takes the video and the sound on two inputs. Press Enter to stop: `StopAsync` writes the MP4 index, and the file plays everywhere. Sound goes in only when it is AAC: a camera with no microphone, or one that sends G.711 or another codec, gives a video-only file. The [WinForms sample](../rtsp-save-original-winforms) encodes such sound to AAC, and the [guide](https://www.visioforge.com/help/docs/dotnet/mediablocks/Guides/rtsp-save-original-stream/) explains both.

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk-net)
