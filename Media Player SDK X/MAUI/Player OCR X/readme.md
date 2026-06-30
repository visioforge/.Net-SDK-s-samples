# Media Player SDK X .Net — Player OCR X (C#/MAUI)

Plays a media file with **MediaPlayerCoreX** and inserts a **PaddleOCR text recognizer**
(`OcrBlock`) into the playback pipeline through the X-engine processing-block API:

```csharp
var ocr = new OcrBlock(new OcrSettings(detModelPath, recModelPath, dictPath, clsModelPath)
{
    DrawResults = true,    // recognized text regions are drawn straight into the rendered frame
    FramesToSkip = 5,
});
ocr.OnTextDetected += (s, e) => { /* e.Regions[i].Text */ };

player.Video_Processing_AddBlock(ocr);   // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Tap **OPEN FILE** and pick a video.
2. Tap **START** — recognized text regions are drawn over the video and the first line is shown.

Targets Android, iOS, Mac Catalyst and Windows. The Apache-2.0 **PP-OCRv5** mobile models
(detection, recognition, classification + Latin dictionary) are bundled as `MauiAsset` resources
and copied to app-data on first run, so nothing needs downloading.
