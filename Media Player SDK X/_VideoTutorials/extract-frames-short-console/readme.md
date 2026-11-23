# Media Player SDK .Net - extract-frames-short-console (C#/Console)

The code of the short video "Extract Frames From a Video in a Few Lines of C#": a console app that saves one frame a minute from `movie.mp4` as PNG files, `frame-30.png` to `frame-510.png`, with `MediaInfoReaderX.GetFileSnapshotSKBitmap`. Put a video named `movie.mp4` in the folder you start the app from: both file names are relative to the working directory (with `dotnet run`, the folder you run it in; in Visual Studio, the output folder). A position past the end of the file, or a file that cannot be decoded, gives no frame, and that PNG is skipped. The written guide, with `System.Drawing.Bitmap` and raw RGB output, is [extracting video frames in .NET](https://www.visioforge.com/help/docs/dotnet/mediaplayer/code-samples/get-frame-from-video-file/).

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/media-player-sdk-net)
