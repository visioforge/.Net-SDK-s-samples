@REM @echo off
@REM :: BatchGotAdmin
@REM ::-------------------------------------
@REM REM  --> Check for permissions
@REM >nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system"

@REM REM --> If error flag set, we do not have admin.
@REM if '%errorlevel%' NEQ '0' (
@REM     echo Requesting administrative privileges...
@REM     goto UACPrompt
@REM ) else ( goto gotAdmin )

@REM :UACPrompt
@REM     echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
@REM     set params = %*:"="
@REM     echo UAC.ShellExecute "cmd.exe", "/c %~s0 %params%", "", "runas", 1 >> "%temp%\getadmin.vbs"

@REM     "%temp%\getadmin.vbs"
@REM     del "%temp%\getadmin.vbs"
@REM     exit /B

@REM :gotAdmin
@REM     pushd "%CD%"
@REM     CD /D "%~dp0"
@REM ::--------------------------------------



cd WinForms

cd CSharp

del /S /Q "Audio Capture\bin\*"
del /S /Q "Audio Capture\obj\*"
del /S /Q "Audio Capture\obj_netcore\*"

del /S /Q "Computer Vision\bin\*"
del /S /Q "Computer Vision\obj\*"
del /S /Q "Computer Vision\obj_netcore\*"

del /S /Q "Decklink Demo\bin\*"
del /S /Q "Decklink Demo\obj\*"
del /S /Q "Decklink Demo\obj_netcore\*"

del /S /Q "DV Capture\bin\*"
del /S /Q "DV Capture\obj\*"
del /S /Q "DV Capture\obj_netcore\*"

del /S /Q "IP Capture\bin\*"
del /S /Q "IP Capture\obj\*"
del /S /Q "IP Capture\obj_netcore\*"

del /S /Q "Kinect 2 Demo\bin\*"
del /S /Q "Kinect 2 Demo\obj\*"
del /S /Q "Kinect 2 Demo\obj_netcore\*"

del /S /Q "Kinect Demo\bin\*"
del /S /Q "Kinect Demo\obj\*"
del /S /Q "Kinect Demo\obj_netcore\*"

del /S /Q "Main Demo\bin\*"
del /S /Q "Main Demo\obj\*"
del /S /Q "Main Demo\obj_netcore\*"

del /S /Q "Multiple IP cams\bin\*"
del /S /Q "Multiple IP cams\obj\*"
del /S /Q "Multiple IP cams\obj_netcore\*"

del /S /Q "Multiple video streams\bin\*"
del /S /Q "Multiple video streams\obj\*"
del /S /Q "Multiple video streams\obj_netcore\*"

del /S /Q "Multiple web cams\bin\*"
del /S /Q "Multiple web cams\obj\*"
del /S /Q "Multiple web cams\obj_netcore\*"

del /S /Q "Push Source Demo\bin\*"
del /S /Q "Push Source Demo\obj\*"
del /S /Q "Push Source Demo\obj_netcore\*"

del /S /Q "Screen Capture\bin\*"
del /S /Q "Screen Capture\obj\*"
del /S /Q "Screen Capture\obj_netcore\*"

del /S /Q "Simple VideoCapture\bin\*"
del /S /Q "Simple VideoCapture\obj\*"
del /S /Q "Simple VideoCapture\obj_netcore\*"

del /S /Q "Timeshift Demo\bin\*"
del /S /Q "Timeshift Demo\obj\*"
del /S /Q "Timeshift Demo\obj_netcore\*"

del /S /Q "Video From Images Demo\bin\*"
del /S /Q "Video From Images Demo\obj\*"
del /S /Q "Video From Images Demo\obj_netcore\*"

del /S /Q "Window Capture\bin\*"
del /S /Q "Window Capture\obj\*"
del /S /Q "Window Capture\obj_netcore\*"

cd _CodeSnippets

del /S /Q "face-detection\bin\*"
del /S /Q "face-detection\obj\*"
del /S /Q "face-detection\obj_netcore\*"

del /S /Q "screen-capture\bin\*"
del /S /Q "screen-capture\obj\*"
del /S /Q "screen-capture\obj_netcore\*"

del /S /Q "speaker-capture\bin\*"
del /S /Q "speaker-capture\obj\*"
del /S /Q "speaker-capture\obj_netcore\*"

del /S /Q "webcam-preview\bin\*"
del /S /Q "webcam-preview\obj\*"
del /S /Q "webcam-preview\obj_netcore\*"

cd ..

cd ..

cd ..
