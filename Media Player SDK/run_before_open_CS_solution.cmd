@echo off
:: BatchGotAdmin
::-------------------------------------
REM  --> Check for permissions
>nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system"

REM --> If error flag set, we do not have admin.
if '%errorlevel%' NEQ '0' (
    echo Requesting administrative privileges...
    goto UACPrompt
) else ( goto gotAdmin )

:UACPrompt
    echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
    set params = %*:"="
    echo UAC.ShellExecute "cmd.exe", "/c %~s0 %params%", "", "runas", 1 >> "%temp%\getadmin.vbs"

    "%temp%\getadmin.vbs"
    del "%temp%\getadmin.vbs"
    exit /B

:gotAdmin
    pushd "%CD%"
    CD /D "%~dp0"
::--------------------------------------



cd WinForms

cd CSharp

del /S /Q "Audio Player\bin\*"
del /S /Q "Audio Player\obj\*"
del /S /Q "Audio Player\obj_netcore\*"

del /S /Q "DVD Player\bin\*"
del /S /Q "DVD Player\obj\*"
del /S /Q "DVD Player\obj_netcore\*"

del /S /Q "Karaoke Demo\bin\*"
del /S /Q "Karaoke Demo\obj\*"
del /S /Q "Karaoke Demo\obj_netcore\*"

del /S /Q "Main Demo\bin\*"
del /S /Q "Main Demo\obj\*"
del /S /Q "Main Demo\obj_netcore\*"

del /S /Q "Memory Stream\bin\*"
del /S /Q "Memory Stream\obj\*"
del /S /Q "Memory Stream\obj_netcore\*"

del /S /Q "Multiple Video Streams\bin\*"
del /S /Q "Multiple Video Streams\obj\*"
del /S /Q "Multiple Video Streams\obj_netcore\*"

del /S /Q "Seamless Playback\bin\*"
del /S /Q "Seamless Playback\obj\*"
del /S /Q "Seamless Playback\obj_netcore\*"

del /S /Q "Simple Video Player\bin\*"
del /S /Q "Simple Video Player\obj\*"
del /S /Q "Simple Video Player\obj_netcore\*"

del /S /Q "Two Windows\bin\*"
del /S /Q "Two Windows\obj\*"
del /S /Q "Two Windows\obj_netcore\*"

del /S /Q "Video Mixing Demo\bin\*"
del /S /Q "Video Mixing Demo\obj\*"
del /S /Q "Video Mixing Demo\obj_netcore\*"

cd _CodeSnippets

del /S /Q "read-file-info\bin\*"
del /S /Q "read-file-info\obj\*"
del /S /Q "read-file-info\obj_netcore\*"

del /S /Q "youtube-player\bin\*"
del /S /Q "youtube-player\obj\*"
del /S /Q "youtube-player\obj_netcore\*"

cd ..

cd ..

cd ..
