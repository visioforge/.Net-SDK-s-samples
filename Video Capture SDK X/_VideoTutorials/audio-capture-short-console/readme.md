# Video Capture SDK .Net - audio-capture-short-console (C#/Console)

The code of the short video "Record a Microphone to MP3 in a Few Lines of C#": a console app that records the default microphone to `mic.mp3` until Enter is pressed. To record another input, pass a part of its name that no other device has, exactly as the Windows sound settings show it (case and accents count), as the first argument. Each output device is listed as a loopback input under its own name, so passing an output's name, such as `Speakers`, records what that output plays. A device can be listed under more than one audio API, and the first entry whose name contains the text is used, whatever its API. With no default input, or no name that matches, the app stops with an exception. The recording is not played back to the speakers (`Audio_Play = false`). Stop with Enter: closing the window or Ctrl+C ends the app without `StopAsync`, and the MP3 file is left unfinished. More audio capture scenarios, system sound among them, are in the [audio capture guide](https://www.visioforge.com/help/docs/dotnet/videocapture/audio-capture/).

## Supported frameworks

* .Net 10

---

[Visit the product page.](https://www.visioforge.com/video-capture-sdk-net)
