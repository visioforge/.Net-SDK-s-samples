await using var core = new VideoEditCore();
core.OnError += (s, e) =>
    Console.WriteLine(e.Message);
var ok = await core.FastEdit_CutFileAsync(
    "movie.mp4",
    TimeSpan.FromSeconds(60),
    TimeSpan.FromSeconds(90),
    "cut.mp4");
Console.WriteLine(ok ? "Done" : "Failed");
