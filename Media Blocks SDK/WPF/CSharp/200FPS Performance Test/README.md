# 200 FPS Performance Test Demo

## Purpose

This demo application tests the WPF VideoView performance with high frame rate video streams (200 FPS). It demonstrates:
1. Frame dropping in the WPF VideoView to handle frame rates exceeding the monitor refresh rate
2. How sequential pipeline with `IsSync=false` allows both processing and display

## Features

- Generates a 200 FPS virtual video source using `VirtualVideoSourceBlock`
- Uses `VideoSampleGrabberBlock` to count all frames from the source
- Displays real-time FPS counter showing SampleGrabber frame rate
- VideoRenderer set with `IsSync=false` for non-blocking operation
- Tests WPF VideoView frame dropping mechanism

## How It Works

### Pipeline Architecture
```
VirtualVideoSource (200 FPS) → VideoSampleGrabber (200 FPS) → QueueBlock → VideoRenderer (display)
```

Sequential pipeline with QueueBlock between SampleGrabber and Renderer to decouple processing speeds.

### Frame Processing
1. **Source**: Generates frames at 200 FPS
2. **SampleGrabber**: Receives and counts all 200 FPS (fast operation, just increments counters)
3. **QueueBlock**: Buffers frames between SampleGrabber and Renderer, prevents Renderer backpressure from affecting SampleGrabber
4. **VideoRenderer**: Receives frames with `IsSync=false` (appsink processes asynchronously)
5. **VideoView**: Drops frames for display to match monitor refresh rate (e.g., 60/144 FPS)

### Key Settings
- **Sequential pipeline**: Source → SampleGrabber → Queue → Renderer
- **QueueBlock**: Critical for decoupling - prevents slow Renderer from blocking SampleGrabber
- **VideoSampleGrabberBlock**: Fast processing (just counting), processes all frames
- **VideoRendererBlock.IsSync = false**: Appsink operates asynchronously
- **VideoView frame dropping**: Additional frame dropping at WPF UI level for display
- **BufferSink.Drop = true**: Appsink configured to drop old frames when buffer is full

### Why QueueBlock is Essential
Without QueueBlock, even though SampleGrabber is fast, the appsink's callback in VideoRenderer blocks the pipeline because it marshals to the WPF UI thread. The appsink's `drop` property only drops frames when its internal queue is full, but if the callback is blocking, new frames can't even reach the queue. QueueBlock provides an asynchronous buffer that allows:
- SampleGrabber to push frames without waiting for Renderer
- Queue to absorb backpressure from slow Renderer
- Renderer to process at its own pace without blocking upstream

## Technical Details

### VideoView Frame Dropping (`VideoView.cs`)
- Uses `Dispatcher.BeginInvoke` with `DispatcherPriority.Render`
- Implements atomic flag (`_frameProcessing`) to detect if a frame is being rendered
- Drops incoming display frames if the previous frame hasn't finished rendering
- Prevents frame queue buildup and memory issues

### Pipeline Non-Blocking (`IsSync=false`)
- Setting `IsSync=false` on VideoRendererBlock makes the GStreamer sink non-blocking
- The sink doesn't synchronize with pipeline clock
- Allows upstream elements (including SampleGrabber) to run at full speed
- Essential for scenarios where you need to process all frames but can't display all

## Expected Behavior

- **SampleGrabber FPS**: ~200 FPS (full source rate)
- **Display FPS**: Limited by monitor refresh rate (60 Hz = 60 FPS, 144 Hz = 144 FPS)
- **No lag**: Frame dropping prevents backlog and maintains real-time display
- **All frames processed**: SampleGrabber receives every frame for recording/analysis

## Use Cases

This configuration is ideal for:
- Recording at high frame rates while displaying at monitor refresh
- Video analysis requiring all frames
- Real-time processing at full source rate
- Preventing display from blocking capture/processing

## Build Requirements

- .NET 8.0 or later
- Windows OS
- VisioForge Media Framework SDK

## Usage

1. Click "Start 200 FPS Test" to begin
2. Observe the "SampleGrabber FPS" counter (should show ~200 FPS)
3. Note that display is smooth despite high source rate
4. Monitor total frames received
5. Click "Stop" to end the test

