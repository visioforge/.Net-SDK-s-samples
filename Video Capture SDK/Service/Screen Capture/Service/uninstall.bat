@echo off
sc.exe stop VFVidCapNetSrv >nul 2>&1
ping -n 4 127.0.0.1 >nul
sc.exe delete VFVidCapNetSrv
pause
