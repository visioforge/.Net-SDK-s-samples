await VisioForgeX.InitSDKAsync();
SetLicenseKey("TRIAL");
var clip = await
    GetSearchFingerprintForVideoFileAsync(
        new VFPFingerprintSource("clip.mp4"),
        Console.WriteLine);
var movie = await
    GetSearchFingerprintForVideoFileAsync(
        new VFPFingerprintSource("movie.mp4"),
        Console.WriteLine);
if (clip != null && movie != null)
{
    var found = await SearchAsync(
        clip, movie, clip.Duration, 500, true);
    foreach (var at in found)
        Console.WriteLine(
            $"Found at {at:hh\\:mm\\:ss}");
    if (found.Count == 0)
        Console.WriteLine("Not found");
}
VisioForgeX.DestroySDK();
