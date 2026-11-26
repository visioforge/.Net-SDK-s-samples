# Media Blocks SDK .Net - rtsp-save-original-winforms (C#/WinForms)

The sample of the video tutorial "Save an RTSP Camera to MP4 Without Re-encoding in C#": a WinForms app that records an IP camera into an MP4 file in the Videos folder, keeping the camera's own encoded video. Type the camera's RTSP URL, login and password (both boxes are masked) and click Start. `RTSPRAWSourceBlock` hands over the camera's encoded streams, and `MP4SinkBlock` writes them: the video goes in as the camera sent it, with no decoder and no encoder. AAC sound goes in as it is; G.711 or any other codec is decoded and encoded to AAC, the only part that is re-encoded. TCP transport keeps the camera's own frame timing. While it records, the window shows the time, the file size and the app's CPU load. Stop writes the MP4 index, and the file plays everywhere. The [guide](https://www.visioforge.com/help/docs/dotnet/mediablocks/Guides/rtsp-save-original-stream/) explains each step.

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk-net)
