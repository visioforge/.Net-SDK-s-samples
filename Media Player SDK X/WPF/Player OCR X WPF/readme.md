# Media Player SDK X .Net — Player OCR X (C#/WPF)

Plays a media file with **MediaPlayerCoreX** and inserts a **PaddleOCR text recognizer** into the
playback pipeline through the X-engine processing-block API:

```csharp
var ocr = new OcrBlock(new OcrSettings(detModelPath, recModelPath, dictPath, clsModelPath)
{
    DrawResults = true,    // recognized text is drawn straight into the rendered frame
});
ocr.OnTextDetected += (s, e) => { /* e.Regions[].Text / .Confidence */ };

var source = await UniversalSourceSettings.CreateAsync(filePath, renderVideo: true, renderAudio: false);
player.Video_Processing_AddBlock(ocr);   // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches its
event handler and drops the reference; a fresh block is created for the next run.

## Running

1. Pick a media file with the `...` button.
2. The Apache-2.0 PP-OCRv5 mobile models (detection, angle classifier, recognition) and the Latin
   dictionary ship next to the executable and are pre-filled. Browse for your own models if needed.
3. Click **Start** — recognized text is drawn over the video and each region is logged.

Windows / WPF (`net10.0-windows`).
