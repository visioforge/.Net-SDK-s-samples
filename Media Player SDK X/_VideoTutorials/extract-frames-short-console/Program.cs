await VisioForgeX.InitSDKAsync();
for (var sec = 30; sec < 540; sec += 60)
{
    using var frame = MediaInfoReaderX
        .GetFileSnapshotSKBitmap("movie.mp4",
            TimeSpan.FromSeconds(sec));
    if (frame == null) continue;
    using var png = frame.Encode(
        SKEncodedImageFormat.Png, 100);
    File.WriteAllBytes($"frame-{sec}.png",
        png.ToArray());
}
VisioForgeX.DestroySDK();
