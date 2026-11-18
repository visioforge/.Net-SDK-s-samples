await VisioForgeX.InitSDKAsync();
await using var cam = new VideoCaptureCoreX();
cam.OnError += (_, e) =>
    Console.WriteLine(e.Message);
cam.Video_Source = await RTSPSourceSettings
    .CreateAsync(new Uri(args[0]), "admin",
        "password", audioEnabled: false);
cam.Outputs_Add(new MP4Output("ipcam.mp4"));
if (!await cam.StartAsync()) return;
Console.ReadLine();
await cam.StopAsync();
