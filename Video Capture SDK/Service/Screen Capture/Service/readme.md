# Video Capture SDK .Net - Service

This application demonstrates the SDK capabilities.

## Supported frameworks

* .Net 4.7.2
* .Net Core 3.1
* .Net 5
* .Net 6
* .Net 7
* .Net 8
* .Net 9
* .Net 10

## Installation

Build the project, then run `install.bat` as administrator. It registers the **VFVidCapNetSrv** service with `sc.exe`; run `uninstall.bat` as administrator to remove it. Build the helper project in the `..\Helper` folder and copy its whole build output folder (`bin\<Debug|Release>\<framework>`) next to the service executable - the helper exe alone cannot start.

---

[Visit the product page.](https://www.visioforge.com/video-capture-sdk-net)
