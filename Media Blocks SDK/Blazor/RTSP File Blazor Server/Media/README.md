# Media Folder

This folder is where you should place your video files for RTSP streaming.

## Supported File Formats

The following video formats are supported:
- MP4 (`.mp4`)
- AVI (`.avi`)
- MOV (`.mov`)
- MKV (`.mkv`)
- WMV (`.wmv`)
- FLV (`.flv`)
- WEBM (`.webm`)
- M4V (`.m4v`)
- 3GP (`.3gp`)
- TS (`.ts`)
- MTS (`.mts`)

## How to Use

1. Copy your video files into this `Media` folder
2. Start the RTSP File Blazor Server application
3. The application will automatically detect and list all supported video files
4. Select a file from the dropdown in the web interface
5. Click "Start Streaming" to begin RTSP streaming
6. Use the generated RTSP URL in your preferred video player (VLC, FFmpeg, etc.)

## Requirements

- Video files must contain at least one video stream
- Audio-only files are not supported for RTSP streaming
- Make sure the files are not corrupted or in use by other applications

## Example Usage

After placing video files in this folder, you can access them through the web interface at:
`http://localhost:5000` (or your configured port)

The RTSP stream will be available at:
`rtsp://localhost:8554/live` (or your configured RTSP port) 