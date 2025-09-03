# Decklink Fill+Key Broadcast Demo

A professional WPF application demonstrating real-time broadcast graphics with Decklink Fill+Key output using Media Blocks SDK .Net.

## About Fill+Key Mode

Fill+Key is a professional Decklink mode for overlaying graphics with transparent areas over primary video. This mode uses two SDI outputs:
- **Fill** - Carries the main image with graphics composited
- **Key** - Carries the alpha channel (transparency mask) for keying

### Typical Use Cases:
- Live broadcast titles and graphics overlays
- Television channel logos and bugs
- Virtual studio environments
- Real-time compositing
- Lower thirds for news broadcasts
- Sports graphics and information panels

## Features

### Core Functionality
- **Real-time WPF UserControl capture** at broadcast frame rates (25/30/50/60 fps)
- **Dual Decklink output** for true Fill+Key operation
- **Full alpha channel support** using BGRA format with proper alpha handling
- **Live graphics overlay** with animations and transitions
- **Multiple background sources**: Video files, Decklink input, test patterns, or graphics-only

### Graphics Capabilities
- Professional lower thirds with gradient backgrounds
- Live clock display
- Network logo/watermark
- LIVE indicator with pulsing animation
- Multiple animation styles (slide, fade, wipe)
- Customizable positioning (top/bottom, left/center/right)

### Technical Features
- Pre-multiplied to straight alpha conversion for proper Decklink keying
- External keyer mode for true Fill+Key with two outputs
- Configurable frame rates and buffer sizes
- Real-time preview of both background and graphics
- Debug mode with frame saving capability
- Comprehensive logging system

## Requirements

- Windows 10/11 64-bit
- .NET 4.7.2 or later
- Blackmagic Decklink hardware (Duo 2 or similar with multiple outputs)
- Decklink Desktop Video drivers installed

## Hardware Setup

### Configuring Decklink for Fill+Key
1. Open **Blackmagic Desktop Video Setup**
2. Select your Decklink card (e.g., Duo 2)
3. Set operation mode to **Fill+Key** (if available in hardware)
4. Configure video format (1080p25/30 for broadcast)
5. Save settings

### Hardware Connections
For Decklink Duo 2 with 4 SDI connectors:
- **SDI Out 1**: Fill signal → Video mixer (main input)
- **SDI Out 2**: Key signal → Video mixer (key input)
- The video mixer uses the Key signal to determine transparency areas

Note: The Decklink Duo 2 appears as multiple devices (e.g., "DeckLink Duo (1)", "DeckLink Duo (2)", etc.)

## Installation

1. Install Blackmagic Desktop Video drivers for your Decklink hardware
2. Configure Decklink for Fill+Key mode (see Hardware Setup above)
3. Build the project using Visual Studio 2022 or later
4. Ensure NuGet packages are restored

## Usage

### Basic Setup
1. Launch the application
2. Select your Decklink output device in "Decklink Setup" tab
3. Configure video mode (typically HD1080p25 or HD1080p30)
4. Enable "Enable Fill+Key Output" checkbox
5. Select "ARGB 8-bit" format for Fill+Key mode
6. The system will automatically use the next consecutive device for Key output

### Graphics Configuration
1. In "Graphics Content" tab, customize:
   - Title and subtitle text
   - Position on screen
   - Animation style
2. Toggle additional elements:
   - Clock display
   - Logo/watermark
   - LIVE indicator

### Background Source (Optional)
1. Choose background type in "Background Source" tab:
   - No Background (graphics only with alpha)
   - Video File (browse for video)
   - Decklink Input (live video feed)
   - Test Pattern (SMPTE bars)

### Broadcasting
1. Click "Start Broadcast" to begin
2. Graphics are captured in real-time and sent to Decklink with Fill+Key
3. Use "Show/Hide Graphics" to toggle overlay visibility
4. Monitor status and timing in the interface

## Key Implementation Details

### Fill+Key Mode Operation
When Fill+Key mode is enabled with ARGB format:
- Device N outputs the Fill signal (composited video)
- Device N+1 outputs the Key signal (alpha channel)
- Both outputs use External keyer mode
- ARGB format is required for alpha channel support

### Alpha Channel Handling
The system captures WPF UserControls with transparent backgrounds and preserves the alpha channel through the entire pipeline:
```csharp
// Capture with alpha preservation
var renderBitmap = new RenderTargetBitmap(1920, 1080, 96, 96, PixelFormats.Pbgra32);
// Convert pre-multiplied to straight alpha for Decklink
ConvertPreMultipliedToStraightAlpha(pixels);
```

### Decklink Configuration
Critical settings for Fill+Key operation:
```csharp
// Fill output configuration
fillSettings.KeyerMode = DecklinkKeyerMode.External
fillSettings.VideoFormat = DecklinkVideoFormat.ARGB_8bit

// Key output configuration  
keySettings.KeyerMode = DecklinkKeyerMode.Off
keySettings.VideoFormat = DecklinkVideoFormat.ARGB_8bit
```

### Pipeline Architecture
```
Graphics Source (PushVideoSourceBlock with BGRA)
    ↓
[Optional: VideoMixer with background]
    ↓
Tee Block (split for preview and dual output)
    ├→ Video Renderer (Preview)
    ├→ Decklink Fill Sink (Device N)
    └→ Decklink Key Sink (Device N+1)
```

## Troubleshooting

### No Decklink devices found
- Ensure Desktop Video drivers are installed
- Check Device Manager for Decklink hardware
- Restart after driver installation

### Not enough devices for Fill+Key
- Fill+Key requires two consecutive Decklink outputs
- Ensure your Decklink card has multiple outputs available
- Check that devices appear as separate entries (e.g., Duo (1), Duo (2))

### Graphics not showing transparency
- Verify "Enable Fill+Key Output" is checked
- Ensure "ARGB 8-bit" format is selected
- Check that UserControl has transparent background
- Verify alpha conversion is enabled

### GStreamer negotiation errors
- Ensure all pipeline elements use compatible formats
- Test pattern must use RGBA format for mixer compatibility
- Check that video dimensions match across all sources (1920x1080)

### Performance issues
- Reduce frame rate if needed
- Adjust buffer size (1-10 frames)
- Close unnecessary applications
- Ensure hardware acceleration is available

## Advanced Features

### Custom Graphics
Replace `LowerThirdControl` with your own UserControl:
- Must be 1920x1080 resolution
- Must have `Background="Transparent"`
- Can include any WPF elements, animations, or effects

### Multiple Channel Support
The system supports multiple Decklink cards for multi-channel broadcast operations. Each Fill+Key pair requires two consecutive device numbers.

### Frame Debugging
Enable "Save Captured Frames" in Advanced tab to save raw frame data for analysis. Frames are saved periodically to avoid disk space issues.

## License

This demo requires a valid MediaBlocks SDK license for production use. Trial mode will include watermarks.

## Support

For technical support and licensing:
- MediaBlocks SDK Documentation: https://www.visioforge.com/
- API Reference: https://api.visioforge.com/dotnet/
- Discord Community: https://discord.gg/yvXUG56WCH
- Decklink Support: https://www.blackmagicdesign.com/support/