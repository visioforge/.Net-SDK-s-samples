# VB.NET VideoEffects Dialogs for .NET 8

This directory contains VB.NET versions of the VideoEffects dialog forms for use with VisioForge SDK.

## Files

### Interface
- **IVideoEffectsSettingsDialog.vb** - Interface definition for video effects settings dialogs

### Image Logo Dialog
- **ImageLogoSettingsDialog.vb** - Main form code for image logo settings
- **ImageLogoSettingsDialog.Designer.vb** - Designer-generated UI code for image logo settings

### Text Logo Dialog
- **TextLogoSettingsDialog.vb** - Main form code for text logo settings
- **TextLogoSettingsDialog.Designer.vb** - Designer-generated UI code for text logo settings

### Project File
- **VideoEffects_VB_net8.vbproj** - .NET 8 VB.NET project file

## Building

To build this project:

```bash
dotnet build VideoEffects_VB_net8.vbproj
```

## Usage

These dialogs can be used in your VB.NET WinForms applications to configure video effects for VisioForge SDK components.

### Example

```vb
' Create and show the dialog
Dim dialog As New ImageLogoSettingsDialog()
dialog.ShowDialog()
```

## Requirements

- .NET 8.0 or later
- Windows OS (for Windows Forms support)
- VisioForge.DotNet.Core package (automatically referenced)

## Notes

- This is a library project that compiles to a DLL
- The dialogs are designed to work with VisioForge Media Player, Video Capture, and Video Edit SDKs
- All dialogs implement the `IVideoEffectsSettingsDialog` interface

## License

Copyright (c) 2006-2021 VisioForge
