# Pre-Event Recording Demo - Media Blocks SDK - WPF

This demo showcases pre-event (circular buffer) recording functionality using the Media Blocks SDK, allowing you to capture video/audio that occurred BEFORE a trigger event.

## Features

- Continuous buffering of encoded video/audio in memory
- Configurable pre-event duration (5-60 seconds)
- Configurable post-event duration (5-30 seconds)
- On-demand recording trigger
- Post-event timer extension capability
- Real-time buffer status display
- Text overlay with timestamp
- Audio recording support

## How It Works

The demo continuously buffers encoded H.264 video and AAC audio frames in a circular buffer (`PreEventRecordingBlock`). When you trigger a recording:

1. The buffer is drained starting from the nearest keyframe
2. Buffered frames (pre-event) are written to an MP4 file
3. Live frames continue to be recorded for the post-event duration
4. Recording automatically stops after the post-event period
5. The system returns to buffering mode

## Usage

1. **Select Devices:** Choose video device and format from the dropdowns
2. **Optional Audio:** Check "Record audio" and select an audio device
3. **Configure Durations:**
   - **Pre-event**: How many seconds to capture BEFORE the trigger (5-60s)
   - **Post-event**: How many seconds to capture AFTER the trigger (5-30s)
4. **Set Output Folder:** Specify where recorded files should be saved
5. **Start Pipeline:** Click "Start Pipeline" to begin buffering
6. **Trigger Recording:** When an event occurs, click "Trigger Recording"
   - The system captures the last N seconds (pre-event buffer)
   - Plus the next M seconds (post-event duration)
   - Output file is named: `event_YYYYMMDD_HHmmss.mp4`
7. **Extend (Optional):** If the event continues, click "Extend" to reset the post-event timer
8. **Stop Recording (Optional):** Manually stop recording before the post-event duration ends

## Use Cases

- **Security cameras**: Capture footage before motion/sound detection
- **Dashcam applications**: Save video before and after an incident
- **Sports replay**: Instant replay with pre-buffer
- **Scientific experiments**: Capture unpredictable events
- **Quality control**: Record manufacturing defects with context

## Technical Details

- **Buffer Type:** Encoded frames (H.264 + AAC) in memory
- **Container Format:** MP4 (via mp4mux)
- **Keyframe Alignment:** Output always starts from a video keyframe for proper playback
- **Timestamp Rebasing:** Video and audio timestamps are rebased to start at ~0 for MP4 compatibility
- **Time Base Handling:** Supports different time bases for video and audio sources
- **State Machine:** Idle → Buffering → Recording → PostEventRecording → Buffering

## Implementation Notes

This demo uses the **Media Blocks SDK** pipeline-based architecture:

```csharp
VideoSource → TextOverlay → Tee → [Renderer, H264Encoder → PreEventRecordingBlock]
AudioSource → Tee → [Renderer, AACEncoder → PreEventRecordingBlock]
```

The `PreEventRecordingBlock` maintains the circular buffer and handles:
- Frame buffering with time/size eviction
- Keyframe-aware draining
- MP4 muxing and file writing
- State management and events

For a simpler integration approach, see the **VideoCaptureCoreX** demos which use a high-level output-based API.

## Requirements

- Windows 10/11 x64
- .NET 10.0+
- VisioForge Media Blocks SDK
- Video capture device (webcam, capture card, etc.)
- Audio capture device (optional)
