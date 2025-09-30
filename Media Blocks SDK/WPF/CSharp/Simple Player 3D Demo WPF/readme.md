# Simple Player 3D Demo WPF - Media Blocks SDK

This is a minimal WPF sample that demonstrates how to use the Media Blocks SDK to play video files with a 3D overlay using WPF's Viewport3D.

## Features

- Video playback using Media Blocks SDK
- VideoView control for video rendering
- Viewport3D overlay with an animated rainbow cube
- The 3D cube rotates continuously over the video
- Full playback controls (Play, Pause, Resume, Stop)
- Audio output device selection
- Volume control
- Timeline seeking

## Rainbow Cube

The sample creates a 3D cube with six faces, each colored differently to create a rainbow effect:

- Front face: Red
- Back face: Orange
- Top face: Yellow
- Bottom face: Green
- Right face: Blue
- Left face: Violet

The cube rotates continuously on a diagonal axis, creating a dynamic 3D effect over the playing video.

## Usage

1. Build and run the application
2. Select or enter a video file path
3. Click "Start" to begin playback
4. The rotating rainbow cube will appear over the video

## Technical Details

The sample demonstrates:

- Layering Viewport3D over VideoView in WPF
- Creating 3D geometry (cube) with MeshGeometry3D
- Applying different materials to each face
- Animating 3D models with RotateTransform3D
- Integration of 3D graphics with video playback
