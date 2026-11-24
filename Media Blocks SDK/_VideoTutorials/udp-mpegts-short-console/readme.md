# Media Blocks SDK .Net - udp-mpegts-short-console (C#/Console)

The sample of the short video "UDP Video Streaming in a Few Lines of C#": a console app that sends a video file as an MPEG-TS stream over UDP to `udp://127.0.0.1:5004` until Enter is pressed. The video is encoded to H.264, and the audio to AAC when the file has an audio track. Pass the path of a file with a video track as the first argument, then open the stream with `ffplay udp://127.0.0.1:5004` or `vlc udp://@:5004`. The file is sent once, in real time, from the moment the app starts: a receiver started later joins it mid-file. To send the stream to another machine, put that machine's IP address, or a multicast address, into `Host`. The [UDP streaming guide](https://www.visioforge.com/help/docs/dotnet/general/network-streaming/udp/) covers multicast, several receivers and the sink settings.

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk-net)
