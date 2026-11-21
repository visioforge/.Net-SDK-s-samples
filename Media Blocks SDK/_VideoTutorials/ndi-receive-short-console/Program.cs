await VisioForgeX.InitSDKAsync();
await using var p = new MediaBlocksPipeline();
p.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var ndi = new NDISourceBlock(
    await NDISourceSettings.CreateAsync(
        p.GetContext(), args[0], null));
var video = new VideoRendererBlock(p, null);
p.Connect(ndi.VideoOutput, video.Input);
var audio = new AudioRendererBlock();
p.Connect(ndi.AudioOutput, audio.Input);
if (!await p.StartAsync()) return;
Console.ReadLine();
await p.StopAsync();
