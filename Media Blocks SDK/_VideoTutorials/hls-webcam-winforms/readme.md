# Media Blocks SDK .Net - hls-webcam-winforms (C#/WinForms)

The sample of the video tutorial "Stream a Webcam over HLS in C#": a WinForms app that streams a camera and a microphone over HLS and serves the stream itself, with no web server to install. Pick the camera and the microphone and click Start. `TeeBlock` splits the camera between the preview in the window and `H264EncoderBlock`; the microphone goes through `AACEncoderBlock`; `HLSSinkBlock` writes MPEG-TS segments of about 2 seconds and the playlist into the `hls` folder, and its built-in HTTP server serves that folder with the viewer page `hls/index.htm` (hls.js). Open `http://localhost:8088/` in a browser and the camera plays there. The [guide](https://www.visioforge.com/help/docs/dotnet/general/network-streaming/hls-streaming/) explains each setting.

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk-net)