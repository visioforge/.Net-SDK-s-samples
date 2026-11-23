# Video Edit SDK .Net - cut-video-short-console (C#/Console)

The code of the video short "Cut a Video Without Re-encoding in a Few Lines of C#": a console app that copies 1:00 to 1:30 of `movie.mp4` into `cut.mp4` with `VideoEditCore.FastEdit_CutFileAsync`. The streams are copied, not re-encoded, so the cut keeps the source's quality: 30 seconds of a 720p H.264 movie took 0.6 s, the app's start included. If the cut fails, the reason is printed before "Failed". The cut starts on the keyframe at or before the start position. Put a video named `movie.mp4` in the folder you start the app from: both file names are relative to the working directory (with `dotnet run`, the folder you run it in; in Visual Studio, the output folder). The `VisioForge.DotNet.Core.Redist.FFMPEG.x64` package provides the FFmpeg executable the cut runs. The written guide is [cut a video without re-encoding](https://www.visioforge.com/help/docs/dotnet/videoedit/code-samples/cut-video-without-reencoding/).

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/video-edit-sdk-net)
