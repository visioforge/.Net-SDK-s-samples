# Pre-Event Recording Demo - VideoCaptureCoreX - Avalonia

This demo showcases pre-event (circular buffer) recording functionality using VideoCaptureCoreX, allowing you to capture video/audio that occurred BEFORE a trigger event.

## Features

- Continuous buffering of encoded video/audio in memory
- Configurable pre-event duration (5-60 seconds)
- Configurable post-event duration (5-30 seconds)
- On-demand recording trigger
- Post-event timer extension capability
- Cross-platform (Windows, macOS, Linux)
- Simple high-level API

## How It Works

VideoCaptureCoreX continuously buffers encoded H.264 video and AAC audio frames using the `PreEventRecordingOutput`. When you trigger a recording:

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
5. **Start:** Click "Start" to begin buffering
6. **Trigger Recording:** When an event occurs, click "Trigger Recording"
   - Output file: `event_YYYYMMDD_HHmmss.mp4`
7. **Extend (Optional):** Click "Extend" to reset the post-event timer
8. **Stop Recording (Optional):** Manually stop before post-event duration ends

## Use Cases

- **Security cameras**: Capture footage before motion/sound detection
- **Dashcam applications**: Save video before and after an incident
- **Sports replay**: Instant replay with pre-buffer
- **Scientific experiments**: Capture unpredictable events
- **Quality control**: Record manufacturing defects with context

## Technical Details

- **API**: VideoCaptureCoreX high-level output-based API
- **Buffer Type:** Encoded frames (H.264 + AAC) in memory
- **Container Format:** MP4 (via mp4mux)
- **Pre-Event Output Index:** 0 (first output)
- **State Tracking:** `GetPreEventRecordingState(0)` returns current state
- **Events:** `OnPreEventRecordingStarted`, `OnPreEventRecordingStopped`

## Implementation Notes

This demo uses **VideoCaptureCoreX** for simplified integration:

```csharp
VideoCapture1 = new VideoCaptureCoreX(VideoView1 as IVideoView);
VideoCapture1.Video_Source = videoSourceSettings;
VideoCapture1.Audio_Source = audioSourceSettings;
VideoCapture1.Audio_Record = true;

var preEventOutput = new PreEventRecordingOutput(
    settings: new PreEventRecordingSettings
    {
        PreEventDuration = TimeSpan.FromSeconds(30),
        PostEventDuration = TimeSpan.FromSeconds(10)
    },
    videoEnc: new OpenH264EncoderSettings(),
    audioEnc: new VOAACEncoderSettings()
);

VideoCapture1.Outputs_Add(preEventOutput);

// Later: trigger recording
VideoCapture1.TriggerPreEventRecording(0, filename);
```

The `PreEventRecordingOutput` is automatically wired into the VideoCaptureCoreX pipeline and handles all buffering, encoding, and file writing internally.

For manual pipeline control, see the **Media Blocks SDK** demos which use `PreEventRecordingBlock` directly.

## Platform-Specific Notes

### macOS
- Camera access permission prompt on first run
- Uses AVFoundation for video capture
- Microphone permission required for audio

### Windows
- DirectShow for video capture
- Media Foundation for encoding

### Linux
- Video4Linux2 (v4l2) for video capture
- PulseAudio for audio

## Requirements

- Windows 10/11 x64 / macOS 13+ / Linux
- .NET 10.0+
- VisioForge VideoCaptureCoreX SDK
- Video capture device (webcam, capture card, etc.)
- Audio capture device (optional)
