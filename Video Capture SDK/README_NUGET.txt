Call Build on required project to restore NuGet packages for project and build it. Do not call build for entire solution.

If you have error about missed DLL's please call "Update-Package -reinstall" in NuGet console.

If restore doesn't helpled please remove "NuGetPackageImportStamp" tags from your project file and call restore again.