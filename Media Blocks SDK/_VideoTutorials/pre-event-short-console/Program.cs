await VisioForgeX.InitSDKAsync();
await using var p = new MediaBlocksPipeline();
p.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var cam = new RTSPSourceBlock(
    await RTSPSourceSettings.CreateAsync(
        new Uri(args[0]), "admin", "password",
        audioEnabled: false));
var h264 = new H264EncoderBlock();
var settings = new PreEventRecordingSettings
{
    PreEventDuration = TimeSpan.FromSeconds(10),
    PostEventDuration = TimeSpan.FromSeconds(5)
};
var pre = new PreEventRecordingBlock(settings)
    { AudioEnabled = false };
var saved = new TaskCompletionSource<string>(
    TaskCreationOptions
        .RunContinuationsAsynchronously);
pre.OnRecordingStopped += (_, e) =>
    saved.TrySetResult(e.Filename);
p.Connect(cam.VideoOutput, h264.Input);
p.Connect(h264.Output, pre.VideoInput);
if (!await p.StartAsync()) return;
var file = Path.GetFullPath("event.mp4");
do
{
    Console.WriteLine("Enter: the event");
    if (Console.ReadLine() is null) return;
    pre.TriggerRecording(file);
}
while (pre.State ==
    PreEventRecordingState.Buffering);
Console.WriteLine(await saved.Task);
await p.StopAsync();
