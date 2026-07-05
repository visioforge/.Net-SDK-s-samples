# Media Player SDK X .Net — Player PII Redaction X (C#/MAUI)

Plays a media file with **MediaPlayerCoreX** and inserts a **PIIRedactionBlock** into the
playback pipeline through the X-engine processing-block API. The block taps the decoded video,
blurs / pixelates / fills detected faces, license plates, and on-screen text in place, and
raises `OnRegionsRedacted`:

```csharp
var redaction = new PIIRedactionBlock(settings);
redaction.OnRegionsRedacted += (s, e) => { /* e.Regions */ };

player.Video_Processing_AddBlock(redaction);   // add BEFORE OpenAsync/PlayAsync
await player.OpenAsync(source);
await player.PlayAsync();
```

The engine owns and disposes the inserted block when playback stops, so the app only detaches
its event handler and drops the reference; a fresh block is created for the next run.

## Running

1. On the **Models** row, tap **Download models** to fetch the face, plate, and text models
   into the app-data cache.
2. Tap **OPEN FILE** and pick a video.
3. Choose the categories to redact (faces / plates / text), the style (blur / pixelate / fill),
   and the strength, then tap **START**. Categories and style can be changed while it runs.

Targets Android, iOS, Mac Catalyst and Windows. All models are downloaded on demand from the SDK
samples GitHub release into the app-data cache. Model weights are not shipped inside the SDK / NuGet packages.
