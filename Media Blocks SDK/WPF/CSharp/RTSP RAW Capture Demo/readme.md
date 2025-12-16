# RTSP RAW Capture Demo

This WPF demo application demonstrates how to:

1. **Preview RTSP streams** with H264/HEVC decoding for display
2. **Record RTSP streams to MP4 or MPEG-TS files** without video re-encoding (saving H264/HEVC as-is)
3. **Optional audio re-encoding** to AAC for compatibility

## Features

### Preview Mode
- Connect to RTSP streams (H264/HEVC)
- Decode video for real-time preview
- Audio playback support
- Live video display in WPF VideoView control

### Recording Mode
- **Save video without re-encoding** - H264/HEVC streams are saved as-is to MP4 or MPEG-TS files
- **Optional audio re-encoding** - Choose whether to save audio as-is or re-encode to AAC
- Supports both MP4 and MPEG-TS output formats
- Authentication support (username/password)

## Usage

1. **Enter RTSP URL** - Input your RTSP stream URL (e.g., `rtsp://192.168.1.100:554/stream`)
2. **Authentication (optional)** - Enter login and password if required
3. **Enable Audio** - Check the box to capture audio stream

### Preview
1. Click **"Start Preview"** to view the stream
2. Click **"Stop Preview"** to stop viewing

### Recording
1. Choose output file path and format (MP4 or MPEG-TS)
2. Select **"Re-encode Audio"** checkbox if needed:
   - **Checked**: Audio will be decoded and re-encoded to AAC
   - **Unchecked**: Audio stream saved as-is without re-encoding
3. Click **"Start Record"** to begin recording
4. Click **"Stop Record"** to stop and finalize the file

## Technical Details

### Preview Pipeline
Uses `RTSPSourceBlock` with full decoding:
- RTSP stream → Decoder → Video Renderer (for display)
- RTSP stream → Decoder → Audio Renderer (for playback)

### Recording Pipeline
Uses `RTSPRAWSourceBlock` for efficient recording without video re-encoding:
- **Video**: RTSP stream → Muxer (no decoding/encoding) - saves H264/HEVC as-is
- **Audio** (if "Re-encode Audio" is checked): RTSP stream → Decoder → AAC Encoder → Muxer
- **Audio** (if "Re-encode Audio" is unchecked): RTSP stream → Muxer (no decoding/encoding)

This approach provides:
- **Maximum performance** - No CPU-intensive video re-encoding
- **Lossless video quality** - Original H264/HEVC stream preserved
- **Flexibility** - Choose whether to re-encode audio based on compatibility needs

## Requirements

- Windows 10/11
- .NET 10.0
- VisioForge Media Blocks SDK
- RTSP stream source (IP camera, video server, etc.)

## Related Demos

- **RTSP Preview Demo** - Basic RTSP preview functionality
- **RTSP MultiView Demo (WinForms)** - Multiple RTSP streams with recording
- **RTSP Restreamer** - Re-stream RTSP to other protocols

## Support

For more information and video tutorials, visit:
- https://www.visioforge.com/video-tutorials
- https://www.visioforge.com/

## License

Copyright (c) 2025 VisioForge
