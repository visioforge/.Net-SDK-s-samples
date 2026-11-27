await VisioForgeX.InitSDKAsync();
await using var p = new MediaBlocksPipeline();
p.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var cams = await DeviceEnumerator.Shared
    .VideoSourcesAsync();
var cam = new SystemVideoSourceBlock(
    new VideoCaptureDeviceSourceSettings(
        cams[0]));
// Serves the page and the signalling itself
var webrtc = new WebRTCSinkBlock(new()
{
    WebServerAddress = "http://127.0.0.1:8090/",
    WebServerDirectory = Path.Combine(
        AppContext.BaseDirectory, "wwwroot")
});
p.Connect(cam.Output, webrtc.CreateNewInput(
    MediaBlockPadMediaType.Video));
if (!await p.StartAsync()) return;
// http://localhost:8090/?signalling=8443
Console.ReadLine();
await p.StopAsync();
