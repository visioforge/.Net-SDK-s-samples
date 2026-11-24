await VisioForgeX.InitSDKAsync();
await using var p = new MediaBlocksPipeline();
p.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var cams = await DeviceEnumerator.Shared
    .VideoSourcesAsync();
var cam = new SystemVideoSourceBlock(
    new VideoCaptureDeviceSourceSettings(
        cams[0]));
var h264 = new H264EncoderBlock();
var dir = Path.Combine(
    AppContext.BaseDirectory, "hls");
Directory.CreateDirectory(dir);
var old = Directory.GetFiles(dir, "*.ts");
foreach (var f in old) File.Delete(f);
var m3u8 = Path.Combine(dir, "playlist.m3u8");
File.Delete(m3u8);
var hls = new HLSSinkBlock(new HLSSinkSettings
{
    Location = Path.Combine(
        dir, "segment_%05d.ts"),
    PlaylistLocation = m3u8,
    Custom_HTTP_Server_Enabled = true,
    Custom_HTTP_Server_Port = 8088
});
p.Connect(cam.Output, h264.Input);
p.Connect(h264.Output, hls.CreateNewInput(
    MediaBlockPadMediaType.Video));
if (!await p.StartAsync()) return;
Console.WriteLine("http://localhost:8088/");
Console.ReadLine();
await p.StopAsync();
