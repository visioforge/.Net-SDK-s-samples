await VisioForgeX.InitSDKAsync();
await using var p = new MediaBlocksPipeline();
p.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var rtsp = await RTSPRAWSourceSettings
    .CreateAsync(new Uri(args[0]), "login",
        "password", audioEnabled: true);
rtsp.AllowedProtocols = RTSPSourceProtocol.TCP;
var cam = new RTSPRAWSourceBlock(rtsp);
var mp4 = new MP4SinkBlock(
    new MP4SinkSettings("camera.mp4"));
p.Connect(cam.VideoOutput, mp4.CreateNewInput(
    MediaBlockPadMediaType.Video));
// Only AAC sound fits MP4 as it is
var aac = rtsp.GetInfo().AudioStreams
    .Any(a => a.Codec is "MPEG4-GENERIC"
        or "MP4A-LATM");
if (aac)
{
    var audioIn = mp4.CreateNewInput(
        MediaBlockPadMediaType.Audio);
    p.Connect(cam.AudioOutput, audioIn);
}
if (!await p.StartAsync()) return;
Console.ReadLine();
await p.StopAsync();
