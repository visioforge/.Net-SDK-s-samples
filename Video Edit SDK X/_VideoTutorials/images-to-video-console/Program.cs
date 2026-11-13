using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.VideoEdit;
using VisioForge.Core.VideoEditX;

// The images, in file-name order, and where the video goes.
var folder = args.Length > 0 ? args[0] : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "slides");
var images = Directory.Exists(folder) ? Directory.GetFiles(folder, "*.jpg").Order().ToArray() : [];
var output = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "slideshow.mp4");
if (images.Length == 0)
{
    Console.WriteLine($"No .jpg files in {folder}");
    return;
}

await VisioForgeX.InitSDKAsync();

var edit = new VideoEditCoreX();
var done = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
edit.OnError += (s, e) => Console.WriteLine(e.Message);
edit.OnProgress += (s, e) => Console.Write($"\rRendering: {e.Progress}%");
edit.OnStop += (s, e) => done.TrySetResult(e.Successful);

// Each image is on screen for 3 seconds, and the next one starts 1 second before it ends.
var show = TimeSpan.FromSeconds(3);
var overlap = TimeSpan.FromSeconds(1);
VideoTransitionType[] transitions =
[
    VideoTransitionType.Crossfade,
    VideoTransitionType.BarWipeLr,
    VideoTransitionType.IrisRect,
    VideoTransitionType.SinglesweepCwt,
    VideoTransitionType.BarndoorV,
];

for (int i = 0; i < images.Length; i++)
{
    var start = (show - overlap) * i;
    edit.Input_AddImageFile(images[i], show, start);

    // The transition fills the second where this image and the one before it overlap.
    if (i > 0)
    {
        var type = transitions[(i - 1) % transitions.Length];
        edit.Video_Transitions.Add(new VideoTransition(type, start, start + overlap));
    }
}

// Fade in from black at the start, and out to black at the end.
var total = (show - overlap) * (images.Length - 1) + show;
edit.Video_Transition_Add_FadeIn(TimeSpan.Zero, overlap);
edit.Video_Transition_Add_FadeOut(total - overlap, total);

edit.Output_VideoSize = new Size(1920, 1080);
edit.Output_VideoFrameRate = new VideoFrameRate(30);
edit.Output_Format = new MP4Output(output);

// Start returns false, with the reason in OnError, when the render cannot begin.
var saved = edit.Start() && await done.Task;
Console.WriteLine(saved ? $"\nSaved: {output}" : "\nThe video was not saved.");

edit.Dispose();
VisioForgeX.DestroySDK();
