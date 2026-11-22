await VisioForgeX.InitSDKAsync();
await using var p = new MediaBlocksPipeline();
p.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var file = new UniversalSourceBlock(
    await UniversalSourceSettings.CreateAsync(
        args[0]));
var aac = file.AudioOutput == null ? null
    : AACEncoderBlock.GetDefaultSettings();
var rtsp = new RTSPServerBlock(
    new RTSPServerSettings(
        H264EncoderBlock.GetDefaultSettings(),
        aac));
p.Connect(file.VideoOutput, rtsp.VideoInput);
if (aac != null)
    p.Connect(file.AudioOutput, rtsp.AudioInput);
if (!await p.StartAsync()) return;
Console.WriteLine(rtsp.Settings.URL);
Console.ReadLine();
await p.StopAsync();
