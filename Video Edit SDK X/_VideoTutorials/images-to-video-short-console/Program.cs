using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.VideoEdit;
using VisioForge.Core.VideoEditX;

// The folder of images, and the video to write.
var pics = Directory.GetFiles(args[0], "*.jpg").Order().ToArray();

await VisioForgeX.InitSDKAsync();
using var edit = new VideoEditCoreX();
var done = new TaskCompletionSource<bool>();
edit.OnError += (_, e) => Console.WriteLine(e.Message);
edit.OnStop += (_, e) => done.TrySetResult(e.Successful);

// Each image stays for 3 seconds, and the next one
// starts 1 second before it ends.
var show = TimeSpan.FromSeconds(3);
var cross = TimeSpan.FromSeconds(1);
var step = show - cross;

for (var n = 0; n < pics.Length; n++)
{
    var at = step * n;
    edit.Input_AddImageFile(pics[n], show, at);

    // The crossfade fills the second the two images share.
    if (n > 0)
        edit.Video_Transitions.Add(
            new VideoTransition(
                VideoTransitionType.Crossfade, at, at + cross));
}

var end = step * (pics.Length - 1) + show;
edit.Video_Transition_Add_FadeIn(TimeSpan.Zero, cross);
edit.Video_Transition_Add_FadeOut(end - cross, end);

edit.Output_VideoSize = new Size(1920, 1080);
edit.Output_VideoFrameRate = new VideoFrameRate(30);
edit.Output_Format = new MP4Output(args[1]);

// Start returns false when the render cannot begin;
// OnStop fires when the file is finished.
var saved = edit.Start() && await done.Task;
Console.WriteLine(saved ? $"Saved: {args[1]}" : "Not saved.");
