await VisioForgeX.InitSDKAsync();
await using var p = new MediaBlocksPipeline();
p.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var file = new UniversalSourceBlock(
    await UniversalSourceSettings.CreateAsync(
        args[0]));
var udp = new UDPMPEGTSSinkBlock(
    new UDPSinkSettings
    { Host = "127.0.0.1", Port = 5004 });
var h264 = new H264EncoderBlock();
p.Connect(file.VideoOutput, h264.Input);
p.Connect(h264.Output, udp.CreateNewInput(
    MediaBlockPadMediaType.Video));
if (file.AudioOutput != null)
{
    var aac = new AACEncoderBlock();
    p.Connect(file.AudioOutput, aac.Input);
    p.Connect(aac.Output, udp.CreateNewInput(
        MediaBlockPadMediaType.Audio));
}
if (!await p.StartAsync()) return;
Console.WriteLine("udp://127.0.0.1:5004");
Console.ReadLine();
await p.StopAsync();
