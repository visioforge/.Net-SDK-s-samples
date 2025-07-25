# vfp_search - Video Fragment Search Tool

## Overview

`vfp_search` is a command-line tool that searches for a video fragment (like a commercial, intro, or specific scene) within a larger video. It uses pre-generated fingerprints to quickly locate where the fragment appears in the main video.

## Features

- Find video fragments within full-length videos
- Detect commercials in broadcast recordings
- Locate specific scenes or clips
- Fast search without re-processing videos
- Returns exact timestamps of matches

## Usage

```bash
vfp_search -f "fragment.vsigx" -m "main_video.vsigx" [options]
```

### Required Parameters

- `-f, --fragment` : Path to the fragment fingerprint file (the video segment to search for)
- `-m, --main` : Path to the main video fingerprint file (where to search)

### Optional Parameters

- `-d, --md` : Maximum acceptable difference (default: 500)
- `-l, --license` : VisioForge license key (default: "TRIAL")

## Examples

### Search for a commercial in a TV recording
```bash
vfp_search -f "commercial.vsigx" -m "tv_recording.vsigx"
```

### Search with stricter matching
```bash
vfp_search -f "intro.vsigx" -m "movie.vsigx" -d 50
```

### Using license key
```bash
vfp_search -f "scene.vsigx" -m "full_movie.vsigx" -l "YOUR-LICENSE-KEY"
```

## Output

The tool outputs:
- Number of matches found
- Timestamp for each match (format: HH:MM:SS)
- Difference score for each match
- Total processing time

Example output:
```
Starting analyze.
Analyze finished. Elapsed time: 0:00:01.234
Search results: 3
00:05:32
01:23:45
02:15:18
```

## Workflow Example

1. Generate fingerprint for the fragment (e.g., 30-second commercial):
```bash
vfp_gen -i "commercial.mp4" -o "commercial.vsigx" -t search
```

2. Generate fingerprint for the full video:
```bash
vfp_gen -i "broadcast.mp4" -o "broadcast.vsigx" -t compare
```

3. Search for the commercial in the broadcast:
```bash
vfp_search -f "commercial.vsigx" -m "broadcast.vsigx"
```

## Use Cases

1. **Advertisement Detection**: Find and skip commercials in recorded TV shows
2. **Content Monitoring**: Detect when specific content appears in broadcasts
3. **Scene Location**: Find specific scenes across multiple video files
4. **Intro/Outro Detection**: Locate recurring segments in series
5. **Copyright Monitoring**: Find unauthorized use of video clips

## Best Practices

- Use "search" type fingerprints for fragments (`-t search` in vfp_gen)
- Use "compare" type fingerprints for main videos (`-t compare` in vfp_gen)
- Fragments should be at least 5-10 seconds for reliable detection
- Lower difference thresholds (< 100) for exact matches
- Higher thresholds (100-500) for similar content with modifications

## Performance Notes

- Search speed depends on main video length
- Memory usage is proportional to fingerprint sizes
- Typically processes hours of video in seconds

## Error Handling

The tool will exit with an error if:
- Either fingerprint file doesn't exist
- Fragment is longer than the main video
- Fingerprint files are corrupted
- Incompatible fingerprint types

## Limitations

- Fragment must be continuous (no cuts or edits)
- Very short fragments (< 5 seconds) may produce false positives
- Heavily modified content may not be detected

## Related Tools

- `vfp_gen` : Generate fingerprints from video files
- `vfp_compare` : Compare two complete videos
- `MMT` : GUI tool for media monitoring with fragment search