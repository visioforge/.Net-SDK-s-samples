# Media Blocks SDK .Net - webrtc-whip-winforms (C#/WinForms)

The sample of the video tutorial "Stream a Camera to a Browser over WebRTC in C#": a WinForms app that sends a camera to web browsers with no media server, and optionally publishes it to a media server with WHIP. Pick the camera and click Start. `WebRTCSinkBlock` serves the viewer page from `wwwroot` and runs the signalling itself; open `http://localhost:8090/?signalling=8443` in a browser and the camera plays there, encoded to VP8 for each viewer. The window counts the viewers. With a WHIP URL in the second box (MediaMTX takes `http://<server>:8889/<stream name>/whip`), `TeeBlock` also sends the camera through `H264EncoderBlock` to `WHIPSinkBlock`, and the media server serves it to any number of viewers. The [guide](https://www.visioforge.com/help/docs/dotnet/mediablocks/Guides/webrtc-whip/) explains each step.

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk-net)
