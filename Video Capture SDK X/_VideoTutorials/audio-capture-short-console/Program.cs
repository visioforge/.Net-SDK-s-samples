await VisioForgeX.InitSDKAsync();
await using var rec = new VideoCaptureCoreX();
rec.OnError += (_, e) =>
    Console.WriteLine(e.Message);
var mics = await DeviceEnumerator.Shared
    .AudioSourcesAsync();
var mic = args.Length > 0
    ? mics.First(d => d.Name.Contains(args[0]))
    : mics.First(d => d.IsDefault);
rec.Audio_Source =
    mic.CreateSourceSettingsVC();
rec.Audio_Play = false;
rec.Audio_Record = true;
rec.Outputs_Add(new MP3Output("mic.mp3"));
if (!await rec.StartAsync()) return;
Console.ReadLine();
await rec.StopAsync();
