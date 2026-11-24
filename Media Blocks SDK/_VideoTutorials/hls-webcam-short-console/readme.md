# Media Blocks SDK .Net - hls-webcam-short-console (C#/Console)

The sample of the short video "Live HLS Streaming From a Webcam in a Few Lines of C#": a console app that streams the first webcam live over HLS until Enter is pressed. `SystemVideoSourceBlock` captures the camera, `H264EncoderBlock` encodes the video to H.264, and `HLSSinkBlock` cuts it into MPEG-TS segments and writes the `playlist.m3u8` playlist into the `hls` subfolder of the app folder, after deleting what a previous run left there. The sink's built-in HTTP server serves only that subfolder, on port 8088: open `http://localhost:8088/` in a browser, and `index.htm`, copied into `hls` at build time, plays the playlist with hls.js. The first segment is ready about five seconds after the start; reload the page if it opened earlier. The stream has video only. The [HLS streaming guide](https://www.visioforge.com/help/docs/dotnet/general/network-streaming/hls-streaming/) adds audio and the sink settings.

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk-net)
