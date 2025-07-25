# vfp_compare - Video Fingerprint Comparison Tool

## Overview

`vfp_compare` is a command-line tool that compares two video fingerprint files to determine if the videos are similar or identical. It's useful for detecting duplicate videos, finding similar content, or verifying video integrity.

## Features

- Compare pre-generated video fingerprints
- Fast comparison without re-processing videos
- Configurable similarity threshold
- Returns numerical difference score

## Usage

```bash
vfp_compare -f "fingerprint1.vsigx" -s "fingerprint2.vsigx" [options]
```

### Required Parameters

- `-f, --f1` : Path to the first fingerprint file
- `-s, --f2` : Path to the second fingerprint file

### Optional Parameters

- `-d, --md` : Maximum acceptable difference (default: 500)
- `-l, --license` : VisioForge license key (default: "TRIAL")

## Examples

### Basic comparison
```bash
vfp_compare -f "video1.vsigx" -s "video2.vsigx"
```

### Comparison with custom threshold
```bash
vfp_compare -f "original.vsigx" -s "copy.vsigx" -d 100
```

### Using license key
```bash
vfp_compare -f "file1.vsigx" -s "file2.vsigx" -l "YOUR-LICENSE-KEY"
```

## Output

The tool outputs:
- Difference score (lower = more similar)
- Comparison result based on threshold
- Processing time

### Understanding Difference Scores

- **0-5**: Nearly identical videos (same content, minor encoding differences)
- **5-15**: Very similar videos (same content, different quality/compression)
- **15-30**: Similar videos (same content with edits, logos, or watermarks)
- **30-100**: Related content with significant differences
- **100-300**: Different videos with some similar scenes
- **300+**: Completely different videos

## Use Cases

1. **Duplicate Detection**: Find exact copies of videos in different formats
2. **Quality Comparison**: Compare different encodings of the same video
3. **Edit Detection**: Identify if a video has been modified
4. **Copyright Verification**: Check if content matches original source

## Workflow Example

1. Generate fingerprints for videos:
```bash
vfp_gen -i "original.mp4" -o "original.vsigx" -t compare
vfp_gen -i "suspect.mp4" -o "suspect.vsigx" -t compare
```

2. Compare the fingerprints:
```bash
vfp_compare -f "original.vsigx" -s "suspect.vsigx"
```

## Performance Notes

- Comparison is nearly instantaneous
- Memory usage is minimal (loads fingerprints only)
- No video decoding required

## Error Handling

The tool will exit with an error if:
- Either fingerprint file doesn't exist
- Fingerprint files are corrupted
- Fingerprints were generated with incompatible settings

## Best Practices

- Use "compare" type fingerprints (generated with `-t compare`) for best results
- Keep fingerprints with their source videos for reference
- Document the difference threshold used for your use case

## Related Tools

- `vfp_gen` : Generate fingerprints from video files
- `vfp_search` : Search for fragments within videos
- `DVS` : GUI tool for finding duplicate videos in folders