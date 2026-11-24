# Video Fingerprinting SDK - find-clip-short-console (C#/Console)

The code of the short video "Find a Video Clip Inside Hours of Footage in a Few Lines of C#": a console app that finds every place where `clip.mp4` appears in `movie.mp4` and prints its start times. `VFPAnalyzer.GetSearchFingerprintForVideoFileAsync` makes a fingerprint of each file, and `VFPAnalyzer.SearchAsync` returns the start of every match, so a clip that is re-encoded or scaled is still found. The app prints nothing while it reads the files: in the video, a 10-second 480p clip is found at all five places in 2 hours 18 minutes of 720p video, and the run takes about nine minutes. Put both files in the folder you start the app from: the file names are relative to the working directory (with `dotnet run`, the folder you run it in; in Visual Studio, the output folder). Without a license key the SDK runs in trial mode and shows an "Unregistered version" message once; click OK and the search goes on. The written guide is [finding video fragments in larger video content](https://www.visioforge.com/help/docs/vfp/dotnet/samples/how-to-search-one-video-fragment-in-another/).

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/video-fingerprinting-sdk)
