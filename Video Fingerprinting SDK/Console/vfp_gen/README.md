# vfp_gen - Video Fingerprint Generator

## Overview

`vfp_gen` is a command-line tool that generates video fingerprints (signatures) from video files. These fingerprints can be used for video comparison, duplicate detection, or fragment searching.

## Features

- Generate fingerprints optimized for either comparison or search operations
- Process full videos or specific durations
- Support for all major video formats (MP4, AVI, MKV, MOV, etc.)
- Cross-platform compatibility (Windows x64)

## Usage

```bash
vfp_gen -i "input_video.mp4" -o "output.vsigx" [options]
```

### Required Parameters

- `-i, --input` : Path to the input video file
- `-o, --output` : Path where the fingerprint file will be saved (typically with .vsigx extension)

### Optional Parameters

- `-t, --type` : Fingerprint type (default: "search")
  - `search` : Optimized for finding this video as a fragment within other videos
  - `compare` : Optimized for comparing entire videos
- `-d, --duration` : Duration to analyze in milliseconds (default: 0 = full file)
- `-l, --license` : VisioForge license key (default: "TRIAL")

## Examples

### Generate a search fingerprint for the entire video
```bash
vfp_gen -i "commercial.mp4" -o "commercial.vsigx"
```

### Generate a comparison fingerprint
```bash
vfp_gen -i "movie.mp4" -o "movie_compare.vsigx" -t compare
```

### Generate fingerprint for first 30 seconds only
```bash
vfp_gen -i "video.mp4" -o "video_30s.vsigx" -d 30000
```

### Use with license key
```bash
vfp_gen -i "video.mp4" -o "output.vsigx" -l "YOUR-LICENSE-KEY"
```

## Output

The tool generates a binary fingerprint file (`.vsigx`) containing:
- Fingerprint data
- Video metadata (duration, dimensions, frame rate)
- Source filename reference
- Unique identifier

## Use Cases

1. **Content Identification**: Generate fingerprints for a video library to identify duplicates
2. **Advertisement Detection**: Create fingerprints of commercials to find them in broadcasts
3. **Scene Detection**: Generate fingerprints of specific scenes to locate them in full movies
4. **Copyright Protection**: Create fingerprints of copyrighted content for monitoring

## Performance Notes

- Fingerprint generation is CPU-intensive
- Processing time depends on video duration and resolution
- Generated fingerprint files are typically small (KB to MB range)
- The tool shows progress percentage during processing

## Error Handling

The tool will exit with an error message if:
- Input file doesn't exist
- Output file cannot be created/overwritten
- Video format is not supported
- Insufficient memory for processing

## Related Tools

- `vfp_compare` : Compare two fingerprint files
- `vfp_search` : Search for a fingerprint within another fingerprint