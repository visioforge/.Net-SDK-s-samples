# Media Player SDK X .Net - SkinnedPlayer (C#/MAUI)

This sample application demonstrates how to create a highly customizable media player using the **Media Player SDK X** in a **.NET MAUI** application. It showcases the flexibility of the SDK's skinning engine and cross-platform capabilities.

## Key Features

- **Advanced Media Playback**: Utilizes `MediaPlayerCoreX` for robust high-performance video and audio playback across different platforms.
- **Customizable UI**: Integrates `SkinPlayerControls` to provide a ready-to-use, skinnable user interface for player controls (play, pause, seek, volume, etc.).
- **Dynamic Skinning Engine**: Demonstrates loading skins from embedded resources and switching between them at runtime.
  - Includes **Default** and **Violet** skins as examples.
  - Uses `SkinManager` to manage and apply `vfskin` theme files.
- **Cross-Platform**: Built on .NET MAUI, supporting Windows, Android, iOS, and macOS from a single codebase.
- **Device Management**: Shows how to initialize audio output devices (where applicable).

## Getting Started

1. Open `SkinnedPlayer.csproj` in Visual Studio.
2. Ensure you have the necessary MAUI workloads installed.
3. Build and run the project on your desired platform or emulator (Windows, Android, iOS, or macOS).
4. Use the **Skin** button in the UI to toggle between the *Default* and *Violet* themes instantly.

## Supported Frameworks

* .NET 6
* .NET 7
* .NET 8
* .NET 9
* .NET 10

## Supported Platforms

* **Windows**: (Via Windows App SDK)
* **Android**: API 23+
* **iOS**: 15.0+
* **macOS**: Catalyst 15.0+

---

[Visit the product page.](https://www.visioforge.com/media-player-sdk-net)
