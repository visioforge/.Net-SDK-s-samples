# DVS - Duplicate Video Scanner

## Overview

DVS (Duplicate Video Scanner) is a Windows desktop application that scans folders to find duplicate or similar videos. It uses video fingerprinting technology to compare videos based on their content rather than file properties, making it effective at finding duplicates even when videos have different formats, resolutions, or bitrates.

## Features

- **Batch Processing**: Scan multiple folders simultaneously
- **Smart Comparison**: Finds duplicates even with different encodings
- **Format Support**: Works with AVI, WMV, MP4, MPG, MOV, TS, FLV, MKV, and more
- **Visual Preview**: Built-in media player for reviewing detected duplicates
- **Flexible Settings**: Configurable similarity thresholds and scan options
- **Progress Tracking**: Real-time progress bars and status updates
- **Export Results**: Save scan results for later review

## User Interface

### Main Window Components

1. **Source Folders Panel**: Add/remove folders to scan
2. **Settings Panel**: Configure scan parameters
3. **Results Panel**: View and manage found duplicates
4. **Media Player**: Preview videos before taking action
5. **Status Bar**: Monitor current operation status

## How to Use

### Basic Workflow

1. **Add Folders**:
   - Click "Add" button to select folders containing videos
   - Add multiple folders for comprehensive scanning
   - Use "Remove" to delete folders from the list

2. **Configure Settings**:
   - Select video formats to include in scan
   - Set comparison sensitivity (1-100%)
   - Choose processing options

3. **Start Scan**:
   - Click "Process" to begin scanning
   - DVS generates fingerprints for all videos
   - Videos are compared pairwise for duplicates

4. **Review Results**:
   - Duplicate groups appear in the results panel
   - Click on videos to preview them
   - Use context menu for file operations

### Settings Options

- **Supported Formats**: Check/uncheck video formats to include
- **Minimum File Size**: Skip small video files
- **Include Subfolders**: Recursively scan subdirectories
- **Comparison Threshold**: Adjust sensitivity (lower = stricter matching)

## Understanding Results

### Similarity Scores

- **95-100%**: Nearly identical (same video, different encoding)
- **85-95%**: Very similar (minor edits, logos added)
- **70-85%**: Similar content (significant edits)
- **Below 70%**: Different videos

### Result Grouping

DVS groups duplicates by similarity:
- Each group contains videos that match each other
- The first video in a group is the "reference"
- File details show size, duration, and path

## Use Cases

1. **Storage Cleanup**: Find and remove duplicate videos to free space
2. **Media Organization**: Identify multiple copies across folders
3. **Quality Management**: Keep highest quality version of duplicates
4. **Archive Maintenance**: Ensure no duplicate copies in backups
5. **Content Verification**: Check if videos are truly different

## Advanced Features

### Fingerprint Caching

- DVS can save fingerprints for faster subsequent scans
- Enable "Save signatures" option
- Cached fingerprints stored with videos

### Batch Operations

- Select multiple videos for bulk actions
- Delete duplicates while keeping one copy
- Move duplicates to a separate folder
- Export file lists for external processing

### Custom Ignore Areas

- Define regions to ignore (logos, timestamps)
- Useful for broadcast recordings
- Improves accuracy for watermarked content

## Performance Tips

1. **Initial Scan**: First scan is slowest (generates all fingerprints)
2. **Subsequent Scans**: Much faster with cached fingerprints
3. **Large Libraries**: Process in batches for better memory usage
4. **Network Drives**: Copy to local drive for faster processing

## Troubleshooting

### Common Issues

1. **No Duplicates Found**:
   - Check threshold setting (try increasing)
   - Verify video formats are selected
   - Ensure folders contain video files

2. **Too Many False Positives**:
   - Decrease comparison threshold
   - Check if videos have common intros/outros
   - Use ignore areas for logos

3. **Slow Performance**:
   - Process fewer files at once
   - Check available disk space
   - Close other applications

## System Requirements

- Windows 7 or later (64-bit)
- .NET Framework 8.0 or later
- 4GB RAM minimum (8GB recommended)
- Adequate storage for fingerprint cache

## File Management

### Safe Duplicate Removal

1. Always preview before deleting
2. Keep the highest quality version
3. Consider keeping different formats
4. Use "Move to folder" instead of delete

### Organizing Results

- Sort by file size to find space savings
- Sort by similarity to review closest matches
- Group by folder to see distribution

## Best Practices

1. **Test First**: Run on a small folder to verify settings
2. **Backup Important Files**: Before bulk deletions
3. **Review Carefully**: Some "duplicates" may be intentional
4. **Use Appropriate Thresholds**: Adjust based on content type
5. **Regular Scans**: Periodic scans prevent duplicate accumulation

## Related Tools

- `vfp_compare`: Command-line tool for comparing two videos
- `Image Comparer`: Similar tool for finding duplicate images
- `MMT`: Media monitoring tool for broadcast analysis