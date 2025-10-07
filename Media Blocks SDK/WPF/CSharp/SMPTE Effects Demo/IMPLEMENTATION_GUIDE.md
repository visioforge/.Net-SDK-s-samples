# SMPTE Media Blocks Implementation Documentation

## Summary

This implementation successfully adds SMPTE transition media blocks to the VisioForge MediaFramework .NET SDK, providing professional video transition effects using GStreamer's SMPTE elements.

## Implementation Details

### 1. Media Block Types Added

#### SMPTEBlock
- **GStreamer Element**: `smpte`
- **Purpose**: Standard SMPTE transition effects between two video sources
- **Parameters**:
  - `Type` (SMPTETransitionType enum): Professional transition patterns matching GStreamer's exact values (BarWipeLeftToRight, BoxWipeTopLeft, BarnDoorVertical, etc.)
  - `Border` (0-50): Border width in pixels for transition edge
  - `Depth` (0.0-1.0): Controls transition progress
  - `Invert` (bool): Reverses transition direction

#### SMPTEAlphaBlock
- **GStreamer Element**: `smptealpha`
- **Purpose**: Alpha-based SMPTE transitions with transparency support
- **Parameters**:
  - `Type` (SMPTETransitionType enum): Professional transition patterns matching GStreamer's exact values
  - `Border` (0-50): Border width in pixels
  - `Position` (0.0-1.0): Controls transition position/progress
  - `Invert` (bool): Reverses transition direction

### 2. Code Structure

The implementation follows the established MediaFramework patterns:

```
VideoEffects/
├── SMPTEVideoEffect.cs          # Settings class for SMPTE
├── SMPTEAlphaVideoEffect.cs     # Settings class for SMPTE Alpha
GStreamer/VideoEffects/
├── SMPTEFilter.cs               # GStreamer wrapper for smpte element
├── SMPTEAlphaFilter.cs          # GStreamer wrapper for smptealpha element
MediaBlocks/VideoProcessing/
├── SMPTEBlock.cs                # Media block for SMPTE transitions
├── SMPTEAlphaBlock.cs           # Media block for SMPTE Alpha transitions
```

### 3. Enums Updated

- **VideoEffectID**: Added `SMPTE` and `SMPTEAlpha`
- **MediaBlockType**: Added `SMPTE` and `SMPTEAlpha`

### 4. WPF Demo Application

Created comprehensive demo application: `_SETUP/FILES/Demos/Media Blocks SDK/WPF/CSharp/SMPTE Effects Demo/`

#### Demo Features:
- **File Loading**: Browse and load video files for testing
- **Effect Toggle**: Enable/disable SMPTE effects and switch between SMPTE and SMPTE Alpha
- **Real-time Controls**:
  - Transition type dropdown with professional SMPTE patterns
  - Border slider (0-50) for edge width control
  - Depth/Position slider (0.0-1.0) for transition progress
  - Invert checkbox for direction reversal
- **Playback Controls**: Full media player with timeline, play/pause/stop
- **Volume Control**: Audio volume adjustment
- **Debug Output**: Real-time logging for troubleshooting

#### Demo UI Layout:
```
[File Browser] [...]                    [Debug Mode]
[Video Display Area]                    [SMPTE Controls]
                                        ├── Enable SMPTE
                                        ├── Use SMPTE Alpha
                                        ├── Transition Type (dropdown)
                                        ├── Border (0-50)
                                        ├── Depth/Position
                                        └── Invert
[Timeline Slider]                       [Log Output]
[Play Controls] [Volume]
```

### 5. Project Files

Multiple framework support provided:
- `SMPTE Effects Demo MB WPF net472.csproj` (.NET Framework 4.7.2)
- `SMPTE Effects Demo MB WPF net6.csproj` (.NET 6.0)
- `SMPTE Effects Demo MB WPF net8.csproj` (.NET 8.0)

## Professional Use Cases

### SMPTE Block Applications:
- Standard video transitions in professional editing
- Broadcast-quality wipe effects
- Linear transition patterns
- Multi-source video switching

### SMPTE Alpha Block Applications:
- Compositing with transparency
- Overlay transitions
- Advanced alpha blending effects
- Professional video production workflows

## Integration Examples

### Basic SMPTE Usage:
```csharp
var smpteSettings = new SMPTEVideoEffect()
{
    Type = SMPTETransitionType.BarWipeLeftToRight,  // Left-to-right bar wipe
    Border = 5,      // 5-pixel border
    Depth = 0.5,     // 50% transition
    Invert = false   // Normal direction
};

var smpteBlock = new SMPTEBlock(smpteSettings);
pipeline.Connect(source.VideoOutput, smpteBlock.Input);
pipeline.Connect(smpteBlock.Output, renderer.Input);
```

### Advanced SMPTE Alpha Usage:
```csharp
var smpteAlphaSettings = new SMPTEAlphaVideoEffect()
{
    Type = SMPTETransitionType.DiagonalTopLeft,  // Diagonal wipe
    Border = 10,      // 10-pixel border
    Position = 0.75,  // 75% transition
    Invert = true     // Reversed direction
};

var smpteAlphaBlock = new SMPTEAlphaBlock(smpteAlphaSettings);
pipeline.Connect(source.VideoOutput, smpteAlphaBlock.Input);
pipeline.Connect(smpteAlphaBlock.Output, compositor.Input);
```

## Technical Notes

1. **GStreamer Dependencies**: Requires GStreamer's SMPTE plugin to be available
2. **Element Availability**: Both blocks include `IsAvailable()` methods to check for plugin availability
3. **Real-time Updates**: Settings can be modified during playback for live effect adjustments
4. **Memory Management**: Proper disposal patterns implemented for all blocks and filters
5. **Error Handling**: Comprehensive error reporting through pipeline context

## Future Enhancements

Potential improvements for future versions:
- Additional SMPTE transition patterns
- Animation curves for smooth transitions
- Multi-input SMPTE mixing
- Custom transition pattern support
- Performance optimizations for real-time use

This implementation provides a solid foundation for professional video transition effects within the MediaFramework ecosystem.