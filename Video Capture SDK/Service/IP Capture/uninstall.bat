@echo off
sc.exe stop VFVidCapIPCaptureSrv >nul 2>&1
ping -n 4 127.0.0.1 >nul
sc.exe delete VFVidCapIPCaptureSrv
pause
