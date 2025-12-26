# Custom Source Player Demo

This WPF demo application demonstrates how to use the Media Player SDK .NET with a custom DirectShow source filter using `MediaPlayerSourceMode.CustomSource`.

## Features

- Custom DirectShow source filter integration via CLSID
- Video playback with custom source filters
- Audio rendering with device selection
- Volume control
- Timeline seeking
- Play, Pause, Resume, Stop controls

## Usage

1. Enter the path to the media file you want to play
2. Enter the CLSID of your custom DirectShow source filter in the format `{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}`
3. Select the audio output device
4. Click "Start" to begin playback

## Custom Source Filter Requirements

The custom DirectShow source filter must:

- Be registered on the system
- Implement the `IFileSourceFilter` interface
- Support the media format of the file you're trying to play

## Example CLSID

For testing purposes, you can use the sample filter CLSID: `{B98D13E7-55DB-4385-A33D-09FD1BA26338}`

## Key Code Points

The main configuration for custom source mode:

```csharp
// Configure custom source mode
_player.Source_Mode = MediaPlayerSourceMode.CustomSource;
_player.Source_Custom_CLSID = "{B98D13E7-55DB-4385-A33D-09FD1BA26338}";

// Add file to playlist
_player.Playlist_Add(filename);

// Start playback
await _player.PlayAsync();
```

## Requirements

- Windows 10 or later
- .NET 4.7.2, .NET 5.0+, or later
- Custom DirectShow source filter registered on the system

## Related Documentation

For more information about Media Player SDK .NET, visit the [VisioForge documentation](https://www.visioforge.com/video-capture-sdk-net).
