# Video Capture SDK .Net - KLV MPEG-TS Recorder (C#/WPF)

Records an IP camera UDP MPEGTS stream to an MPEG-TS file with KLV metadata passthrough.

## How to use

1. Start the UDP stream using the included script:

   ```cmd
   stream-klv-udp.cmd
   ```

   This loops `C:\Samples\KLV\KLV2.ts` over UDP multicast `239.1.1.1:1234`.

2. Run the application and click **Start**.
3. KLV packets will appear in the log panel on the right.
4. Click **Stop** to finalize the recording.

## Key features

- Opens UDP MPEGTS stream via FFMPEG engine
- Receives KLV metadata packets via `OnDataFrameBuffer` event (filtered by `DataFrameType.KLV`)
- Records to MPEG-TS with KLV metadata stream using MF hardware encoder pipeline

---

[Visit the product page.](https://www.visioforge.com/video-capture-sdk-net)
