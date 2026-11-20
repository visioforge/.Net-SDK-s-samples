await VisioForgeX.InitSDKAsync();
await using var cam = new VideoCaptureCoreX();
cam.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var cams = await DeviceEnumerator.Shared
    .VideoSourcesAsync();
cam.Video_Source =
    new VideoCaptureDeviceSourceSettings(cams[0]);
cam.Outputs_Add(new MP4Output("webcam.mp4"));
if (!await cam.StartAsync()) return;
Console.ReadLine();
await cam.StopAsync();
