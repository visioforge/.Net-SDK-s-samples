# Media Blocks SDK .Net - HLS Streamer (C#/Console)

This application generates synthetic video and audio and streams it using the HLS (HTTP Live Streaming) protocol. The demo includes a built-in HTTP server for easy testing.

## Features

* Generates synthetic video (1280x720 @ 25fps)
* Generates synthetic audio (stereo, 44.1kHz)
* Encodes using H.264 and AAC
* Creates HLS segments with .m3u8 playlist
* Includes built-in HTTP server on port 8088
* Automatically manages segment files

## Used media blocks

* `VirtualVideoSourceBlock` - Synthetic video generation
* `VirtualAudioSourceBlock` - Synthetic audio generation
* `H264EncoderBlock` - H.264/AVC video encoding
* `AACEncoderBlock` - AAC audio encoding
* `HLSSinkBlock` - HLS streaming output

## How to use

1. Run the application
2. Wait a few seconds for the first HLS segment to be created
3. Open http://localhost:8088/index.htm in your web browser
4. The video should start playing automatically
5. Press Enter in the console to stop streaming

## Configuration

You can modify the HLS settings in `Program.cs`:

* `TargetDuration` - Duration of each segment (default: 5 seconds)
* `MaxFiles` - Maximum number of segment files to keep (default: 10)
* `PlaylistLength` - Number of segments in playlist (default: 5)
* `Custom_HTTP_Server_Port` - HTTP server port (default: 8088)

## Supported frameworks

* .Net 4.7.2
* .Net Core 3.1
* .Net 5
* .Net 6
* .Net 7
* .Net 8
* .Net 9
* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-blocks-sdk)
