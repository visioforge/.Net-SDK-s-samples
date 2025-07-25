# MMT Live - Real-Time Media Monitoring Tool

## Overview

MMT Live is a real-time version of the Media Monitoring Tool that can detect video fragments in live streams or during live playback. It's designed for monitoring broadcasts in real-time, detecting advertisements as they air, and triggering immediate actions when specific content is detected.

## Key Features

- **Real-Time Detection**: Identify fragments as video plays
- **Live Stream Support**: Monitor RTSP, HTTP, and file streams
- **Instant Notifications**: Immediate alerts when content detected
- **Continuous Monitoring**: 24/7 operation capability
- **Ad Detection**: Real-time commercial identification
- **Low Latency**: Near-instantaneous detection
- **Live Preview**: Monitor stream while processing

## Differences from Standard MMT

| Feature | MMT | MMT Live |
|---------|-----|----------|
| Processing | Post-recording | Real-time |
| Input | Files only | Files + Streams |
| Detection | Batch | Continuous |
| Results | After completion | Immediate |
| Use Case | Analysis | Monitoring |

## User Interface

### Main Components

1. **Live Media Player**: Shows current stream/playback
2. **Fragment Library**: Pre-loaded detection targets
3. **Detection Log**: Real-time detection events
4. **Status Indicators**: Stream health and processing state
5. **Settings Panel**: Live adjustment of parameters

## How to Use

### Setup Workflow

1. **Prepare Fragment Library**:
   - Load commercials/clips to detect
   - Generate fingerprints in advance
   - Organize by priority/category

2. **Configure Input Source**:
   - File: Select video for monitoring
   - Stream: Enter RTSP/HTTP URL
   - Device: Select capture device

3. **Set Detection Parameters**:
   - Sensitivity threshold
   - Minimum match duration
   - Alert preferences

4. **Start Monitoring**:
   - Click "Start" to begin
   - Video plays while analyzing
   - Detections appear immediately

### Real-Time Operation

- **Continuous Processing**: Analyzes video as it plays
- **Rolling Buffer**: Maintains recent video history
- **Instant Matching**: Compares against fragment library
- **Event Logging**: Records all detections with timestamps

## Use Cases

### 1. Broadcast Compliance
- Ensure ads play as scheduled
- Verify content restrictions
- Monitor competitor advertising
- Track program segments

### 2. Live Stream Monitoring
- Detect copyrighted content
- Monitor multiple channels
- Track brand appearances
- Quality assurance

### 3. Automated Actions
- Trigger recording on detection
- Send notifications/alerts
- Switch streams automatically
- Generate real-time reports

### 4. Advertisement Tracking
- Count commercial airings
- Verify ad placement
- Monitor ad frequency
- Competitive analysis

## Configuration

### Input Sources

**File Playback**:
- Simulates live monitoring
- Useful for testing
- Supports all video formats

**RTSP Streams**:
```
rtsp://camera.example.com:554/stream
rtsp://username:password@server/path
```

**HTTP Streams**:
```
http://server.com/stream.m3u8
http://server.com/live.mjpeg
```

### Detection Settings

- **Buffer Size**: Video history (5-60 seconds)
- **Check Interval**: How often to analyze (1-5 seconds)
- **Confidence Threshold**: Match quality (70-95%)
- **Fragment Priority**: Which fragments to check first

## Performance Optimization

### System Requirements

- **CPU**: Multi-core recommended
- **RAM**: 8-16GB for smooth operation
- **Network**: Stable connection for streams
- **Storage**: Fast SSD for fragment library

### Optimization Tips

1. **Fragment Library**:
   - Keep under 100 active fragments
   - Pre-generate all fingerprints
   - Remove unused fragments

2. **Stream Quality**:
   - Use consistent bitrate
   - Avoid very high resolutions
   - Ensure stable connection

3. **Processing**:
   - Adjust check interval based on CPU
   - Use appropriate buffer size
   - Enable GPU acceleration if available

## Advanced Features

### Multi-Stream Monitoring

- Monitor multiple streams simultaneously
- Separate detection threads per stream
- Consolidated reporting
- Resource management

### Custom Actions

Configure actions for detections:
- Email notifications
- HTTP webhooks
- File logging
- Database recording
- Stream recording triggers

### Detection Zones

- Define time windows for detection
- Schedule different fragment sets
- Ignore certain time periods
- Priority scheduling

## Troubleshooting

### No Detections
- Verify fragments are loaded
- Check stream is playing
- Confirm fingerprints generated
- Adjust sensitivity lower

### High CPU Usage
- Reduce check frequency
- Lower stream resolution
- Decrease buffer size
- Limit active fragments

### Stream Issues
- Check network connectivity
- Verify stream URL
- Test in media player first
- Monitor bandwidth usage

### Delayed Detections
- Increase processing priority
- Reduce buffer size
- Check system resources
- Optimize fragment count

## Best Practices

### Preparation
1. Test fragments in standard MMT first
2. Optimize fragment quality and length
3. Build comprehensive fragment library
4. Document expected detections

### Operation
1. Monitor system resources
2. Regular fragment library updates
3. Periodic detection accuracy checks
4. Maintain detection logs

### Maintenance
1. Clean old detection logs
2. Update fragment fingerprints
3. Review false positives/negatives
4. Optimize based on results

## Integration Options

### API Integration
- REST API for detection events
- WebSocket for real-time updates
- Database logging options
- Third-party integrations

### Automation
- Scheduled monitoring
- Automatic report generation
- Alert escalation
- Stream switching

## Comparison with Alternatives

**vs Standard MMT**:
- Real-time vs post-processing
- Continuous vs batch operation
- Immediate vs delayed results

**vs Manual Monitoring**:
- Automated vs human observation
- 24/7 vs limited hours
- Consistent vs variable accuracy

## Related Tools

- `MMT`: Post-recording analysis version
- `vfp_search`: Command-line fragment search
- `DVS`: Duplicate video detection