# SimplePlayerUno

A simple media player demo application built with Uno Platform and VisioForge MediaPlayerCoreX SDK.

## Features

- Play local video/audio files
- Playback controls (Play, Pause, Stop)
- Seek functionality with timeline slider
- Volume control
- Playback speed control (0.5x, 1x, 2x)
- Position and duration display

## Product Page

[VisioForge Media Player SDK .NET](https://www.visioforge.com/media-player-sdk-net)

## Supported Platforms

- Windows (WinUI)
- Android
- iOS
- macCatalyst

## Requirements

- .NET 10.0 SDK
- Visual Studio 2022 with Uno Platform extension
- For Android: Android SDK 34
- For iOS/macCatalyst: Xcode with current SDK

## Building

Open the solution in Visual Studio and select the desired target platform to build and run.

## Project Structure

- `App.xaml` / `App.xaml.cs` - Application entry point
- `MainPage.xaml` / `MainPage.xaml.cs` - Main player interface
- `GlobalUsings.cs` - Global using statements

## Dependencies

- VisioForge.Core - Core SDK functionality
- VisioForge.Core.UI.Uno - Uno Platform UI components
- VisioForge.Libs - Supporting libraries
- Platform-specific native packages for media processing
