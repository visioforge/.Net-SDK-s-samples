# Media Blocks SDK .Net - pre-event-short-console (C#/Console)

The sample of the short video "Record the 10 Seconds Before an Event in C#": a console app that keeps the last ten seconds of an IP camera in memory and, when Enter is pressed, saves them to `event.mp4` together with five more seconds of live video. Pass the camera's RTSP URL as the first argument and put its user name and password into `RTSPSourceSettings.CreateAsync`. `RTSPSourceBlock` receives the stream, `H264EncoderBlock` encodes the video to H.264, and `PreEventRecordingBlock` holds the encoded frames in a ring buffer. `TriggerRecording` writes the buffer to the file from its first key frame and records on; the file closes five seconds after the buffered video has been written, and the app prints its path and exits. Press Enter again if the first press came before the first frame arrived; if no frame ever arrives, each Enter prints the error, and Ctrl+C quits. The file has video only. The [pre-event recording guide](https://www.visioforge.com/help/docs/dotnet/mediablocks/Guides/pre-event-recording/) adds audio, motion detection as the trigger, and MPEG-TS output.

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk-net)
