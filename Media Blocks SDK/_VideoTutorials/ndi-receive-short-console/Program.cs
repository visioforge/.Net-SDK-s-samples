await VisioForgeX.InitSDKAsync();
await using var p = new MediaBlocksPipeline();
p.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var settings = await NDISourceSettings
    .CreateAsync(p.GetContext(), args[0], null);
if (settings == null) return;
var ndi = new NDISourceBlock(settings);
var video = new VideoRendererBlock(p, null);
p.Connect(ndi.VideoOutput, video.Input);
if (settings.GetInfo().AudioStreams.Count > 0)
    p.Connect(ndi.AudioOutput,
        new AudioRendererBlock().Input);
if (!await p.StartAsync()) return;
Console.ReadLine();
await p.StopAsync();
