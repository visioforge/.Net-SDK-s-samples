# MMT - Media Monitoring Tool

## Overview

MMT (Media Monitoring Tool) is a Windows desktop application designed to find video fragments within larger videos. It's primarily used for detecting commercials, advertisements, intros, outros, or any specific video segments within broadcast recordings or video collections. Unlike DVS which compares whole videos, MMT specializes in locating where specific clips appear within longer content.

## Key Features

- **Fragment Detection**: Find short video clips within long recordings
- **Batch Processing**: Search multiple fragments in multiple videos
- **Advertisement Monitoring**: Detect and track commercial appearances
- **Timeline Visualization**: See exactly when fragments appear
- **Media Preview**: Built-in player for reviewing detections
- **Export Capabilities**: Save results in CSV format
- **Database Support**: Build libraries of fragments for repeated searches

## User Interface

### Main Components

1. **Media Player**: Preview videos and detections
2. **Broadcast Dump Tab**: Manage videos to search within
3. **Ads/Fragments Tab**: Manage video fragments to search for
4. **Results Tab**: View detection results and statistics
5. **Settings Tab**: Configure search parameters
6. **Status Bar**: Monitor processing progress

## How to Use

### Basic Workflow

1. **Add Broadcast Content**:
   - Use "Broadcast dump" tab
   - Add files or folders containing full-length videos
   - These are the videos you'll search within

2. **Add Fragments**:
   - Switch to "Ads/fragments" tab
   - Add commercials, intros, or clips to find
   - Can add individual files or folders

3. **Configure Settings**:
   - Set detection sensitivity
   - Choose processing options
   - Configure output preferences

4. **Process**:
   - Click "Process" to start analysis
   - MMT generates fingerprints for all content
   - Searches for each fragment in each broadcast

5. **Review Results**:
   - View detections in the Results tab
   - See timestamps and confidence scores
   - Preview matches in the media player

## Use Cases

### 1. Commercial Detection
- Monitor TV recordings for specific advertisements
- Track commercial frequency and placement
- Generate reports for advertising analytics

### 2. Content Monitoring
- Find copyrighted content in uploads
- Detect unauthorized use of video clips
- Monitor brand appearances

### 3. Broadcast Analysis
- Locate program segments (intros, outros)
- Find news segments across multiple broadcasts
- Track recurring content

### 4. Quality Control
- Verify ad insertion in broadcasts
- Check for missing segments
- Ensure content compliance

## Settings and Options

### Detection Parameters

- **Sensitivity**: Adjust match threshold (1-100)
  - Higher = Stricter matching (fewer false positives)
  - Lower = Looser matching (may miss variations)

- **Time Shift**: Maximum temporal displacement allowed
- **Ignore Areas**: Define regions to exclude (logos, tickers)

### Processing Options

- **Multi-threading**: Use multiple CPU cores
- **Memory Limit**: Control RAM usage
- **Fingerprint Caching**: Save for faster re-processing

## Understanding Results

### Result Information

Each detection shows:
- **Fragment Name**: Which clip was found
- **Broadcast File**: Where it was found
- **Timestamp**: Exact position (HH:MM:SS)
- **Duration**: Length of the match
- **Confidence**: Match quality (percentage)

### Confidence Scores

- **95-100%**: Exact match
- **85-95%**: High confidence (minor differences)
- **70-85%**: Likely match (some modifications)
- **Below 70%**: Possible match (review needed)

## Advanced Features

### Fragment Database

- Build libraries of common fragments
- Save fingerprints for reuse
- Organize by categories (commercials, intros, etc.)

### Batch Analysis

- Process multiple broadcasts overnight
- Queue large sets of fragments
- Generate comprehensive reports

### CSV Export

Results can be exported with:
- Detection timestamps
- File paths
- Confidence scores
- Fragment details

## Best Practices

### Fragment Preparation

1. **Optimal Length**: 10-60 seconds works best
2. **Clean Cuts**: Avoid partial frames at start/end
3. **Full Quality**: Use highest quality source available
4. **No Modifications**: Don't crop or edit fragments

### Broadcast Files

1. **Consistent Format**: Similar encoding preferred
2. **Complete Files**: Avoid corrupted recordings
3. **Reasonable Length**: Split very long recordings

### Performance Optimization

1. **Pre-generate Fingerprints**: Save processing time
2. **Process in Batches**: Don't overload memory
3. **Use SSD Storage**: Faster file access
4. **Close Other Apps**: Maximize available resources

## Troubleshooting

### No Detections Found
- Check fragment quality and length
- Verify broadcast contains the fragment
- Adjust sensitivity settings
- Ensure proper time range

### Too Many False Positives
- Increase sensitivity threshold
- Check for common elements (black frames)
- Use longer fragments
- Define ignore areas

### Performance Issues
- Reduce number of simultaneous files
- Enable fingerprint caching
- Check available disk space
- Monitor RAM usage

## Typical Workflows

### Commercial Monitoring
1. Record broadcast streams
2. Create fragment library of commercials
3. Run MMT daily/weekly
4. Export reports for clients

### Content Verification
1. Prepare authorized content clips
2. Monitor video platforms
3. Detect unauthorized usage
4. Document violations

## System Requirements

- Windows 7 or later (64-bit)
- .NET Framework 8.0
- 8GB RAM recommended
- Fast storage for video files
- Multi-core CPU beneficial

## Related Tools

- `vfp_search`: Command-line fragment search
- `MMT Live`: Real-time monitoring version
- `DVS`: Find duplicate complete videos