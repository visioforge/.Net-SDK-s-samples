await VisioForgeX.InitSDKAsync();
await using var p = new MediaBlocksPipeline();
p.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var cams = await DeviceEnumerator.Shared
    .VideoSourcesAsync();
var cam = new SystemVideoSourceBlock(
    new VideoCaptureDeviceSourceSettings(
        cams[0]));
var reader = new BarcodeDetectorBlock(
    BarcodeDetectorMode.InputOnly);
var seen = new HashSet<string>();
reader.OnBarcodeDetected += (_, e) =>
{
    if (seen.Add(e.Value))
        Console.WriteLine(
            $"{e.BarcodeType}: {e.Value}");
};
p.Connect(cam.Output, reader.Input);
if (!await p.StartAsync()) return;
Console.ReadLine();
await p.StopAsync();
