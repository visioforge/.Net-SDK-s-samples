@echo off
echo Building Gaussian Blur Demo...
echo.

REM Build the project
dotnet build -c Debug

if %ERRORLEVEL% NEQ 0 (
    echo.
    echo Build failed! Please check for errors above.
    pause
    exit /b 1
)

echo.
echo Build successful! Running the demo...
echo.

REM Run the application
cd bin\Debug\net8.0-windows
start GaussianBlurDemo.exe

echo.
echo Demo launched!
pause