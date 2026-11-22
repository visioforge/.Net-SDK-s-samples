# Media Blocks SDK .Net - rtsp-server-short-console (C#/Console)

The sample of the short video "Stream an MP4 File as an RTSP Server in a Few Lines of C#": a console app that serves a video file as an RTSP stream at `rtsp://127.0.0.1:8554/live` until Enter is pressed. The server encodes the video to H.264, and the audio to AAC when the file has an audio track. Pass the file path as the first argument, then open the URL in VLC or `ffplay`. The file plays once, in real time, from the moment the app starts: a client that connects later joins it mid-file. The server accepts clients on every network interface, so other machines reach it at this machine's IP address. The [RTSP Server block guide](https://www.visioforge.com/help/docs/dotnet/mediablocks/RTSPServer/) covers the settings, authentication and a camera source.

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk-net)
