@echo off
setlocal
set "SVC=VFVidCapNetSrv"
set "EXE=%~dp0bin\Debug\net10.0-windows\ScreenCaptureService.exe"
if not exist "%EXE%" set "EXE=%~dp0bin\Release\net10.0-windows\ScreenCaptureService.exe"
if not exist "%EXE%" set "EXE=%~dp0bin\Debug\net472\ScreenCaptureService.exe"
if not exist "%EXE%" set "EXE=%~dp0bin\Release\net472\ScreenCaptureService.exe"
if not exist "%EXE%" (
    echo Build the project first: no ScreenCaptureService.exe under bin\Debug or bin\Release.
    pause
    exit /b 1
)
sc.exe create %SVC% binPath= "%EXE%" start= auto DisplayName= "VisioForge Sample Service - Screen Capture"
pause
