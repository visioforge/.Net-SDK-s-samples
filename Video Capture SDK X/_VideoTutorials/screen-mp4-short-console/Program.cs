await VisioForgeX.InitSDKAsync();
await using var cap = new VideoCaptureCoreX();
cap.OnError += (_, e) =>
    Console.WriteLine(e.Message);
cap.Video_Source =
    new ScreenCaptureD3D11SourceSettings
    {
        FrameRate = new VideoFrameRate(30)
    };
cap.Outputs_Add(new MP4Output("screen.mp4"));
if (!await cap.StartAsync()) return;
Console.ReadLine();
await cap.StopAsync();
