await VisioForgeX.InitSDKAsync();
await using var p = new MediaBlocksPipeline();
p.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var file = new UniversalSourceBlock(
    await UniversalSourceSettings.CreateAsync(
        args[0]));
var ndi = new NDISinkBlock("VisioForge NDI");
p.Connect(file.VideoOutput,
    ndi.CreateNewInput(Video));
p.Connect(file.AudioOutput,
    ndi.CreateNewInput(Audio));
if (!await p.StartAsync()) return;
Console.ReadLine();
await p.StopAsync();
