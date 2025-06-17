# Enhanced GenICam Source Demo

## Overview

This demo application has been significantly enhanced to provide comprehensive camera information and capabilities for GenICam-compatible cameras. The application now displays detailed camera properties, technical specifications, and real-time settings.

## Features

### Enhanced User Interface

The application now features a modern, tabbed interface with three main sections:

1. **Camera Selection Panel**
   - Camera dropdown with automatic detection
   - Start/Stop/Refresh controls
   - Real-time recording timer

2. **Camera Information Tabs**
   - **Basic Info**: Vendor, model, serial number, device ID, protocol, address, sensor size, status
   - **Technical Specs**: Supported pixel formats, resolution capabilities, feature availability
   - **Current Settings**: Real-time camera configuration and status

3. **Video Display**
   - Larger, dedicated video display area
   - Full-screen video support

### Comprehensive Camera Information

#### Basic Information
- **Vendor Name**: Camera manufacturer
- **Model Name**: Camera model
- **Serial Number**: Unique device identifier
- **Device ID**: GenICam device identifier
- **Protocol**: Communication protocol (GigE, USB3, etc.)
- **Network Address**: IP address for network cameras
- **Sensor Size**: Maximum sensor resolution
- **Connection Status**: Real-time connection state

#### Technical Specifications
- **Supported Pixel Formats**: Complete list of available image formats
- **Resolution Capabilities**: 
  - Width and height ranges with increments
  - Maximum sensor dimensions
- **Frame Rate Support**: Available frame rate ranges
- **Binning Support**: Horizontal and vertical binning capabilities
- **Feature Availability**: Real-time detection of camera features
  - Exposure control
  - Gain control
  - Frame rate control
  - Binning support

#### Current Settings Display
- **Current Region**: Active ROI (X, Y, Width, Height)
- **Active Pixel Format**: Currently selected image format
- **Exposure Time**: Current exposure setting in microseconds
- **Gain**: Current gain value in dB
- **Frame Rate**: Current acquisition frame rate
- **Binning**: Current binning configuration
- **Acquisition Status**: Running/Stopped state
- **Connection Status**: Real-time connection monitoring

### Advanced Camera Features

The application includes sophisticated camera feature detection and testing:

#### Automatic Feature Discovery
- Detection of common GenICam features
- Support for string, integer, float, and boolean features
- Graceful error handling for unsupported features

#### Feature Testing
- Device temperature monitoring (if available)
- Firmware version detection
- Advanced trigger mode detection
- Automatic exposure/gain mode status

#### Debug Information
The application provides detailed debug output including:
- Camera capability bounds (exposure, gain, frame rate)
- Available GenICam features
- Feature accessibility testing
- Error diagnostics

## Technical Implementation

### Enhanced Architecture
- **AravisCamera Integration**: Direct camera instance creation for detailed information
- **Comprehensive Error Handling**: Graceful degradation when features are unavailable
- **Real-time Updates**: Automatic refresh of camera settings and status
- **Memory Management**: Proper disposal of camera resources

### Key Components

1. **Camera Information Management**
   ```csharp
   private GenICamSourceInfo _currentCameraInfo;
   private AravisCamera _currentCamera;
   ```

2. **Advanced Feature Detection**
   ```csharp
   ShowAdvancedCameraFeatures();
   TestCameraFeatures();
   ```

3. **Real-time Status Updates**
   ```csharp
   UpdateCurrentCameraSettings();
   UpdateConnectionStatus();
   ```

### Supported Camera Features

The application can detect and display information for cameras supporting:
- **GenICam Standard**: Full GenICam 3.0+ compatibility
- **GigE Vision**: Network-based cameras
- **USB3 Vision**: USB 3.0 cameras
- **Camera Link**: Industrial cameras (via appropriate transport layers)

## Usage Instructions

### Basic Operation
1. **Launch Application**: Start the enhanced demo
2. **Camera Detection**: Cameras are automatically detected and listed
3. **Select Camera**: Choose camera from dropdown
4. **View Information**: Explore the three information tabs
5. **Start Streaming**: Click "Start" to begin video capture
6. **Monitor Status**: View real-time settings and status

### Advanced Features
- **Refresh Cameras**: Use "Refresh" button to re-scan for cameras
- **Update Settings**: Click "Update Current Settings" to refresh real-time values
- **Debug Output**: Monitor Visual Studio Output window for detailed information

## Requirements

### Software Dependencies
- VisioForge Media Blocks SDK .Net
- Aravis library (Windows: VisioForge.CrossPlatform.GenICam.Windows.x64)
- .NET 8.0 or later
- WPF Framework

### Hardware Support
- GenICam-compatible cameras
- GigE Vision cameras
- USB3 Vision cameras
- Compatible network adapters (for GigE cameras)

## Development Notes

### Code Structure
- **MainWindow.xaml**: Enhanced UI with tabbed interface
- **MainWindow.xaml.cs**: Comprehensive camera information logic
- **Camera Information Methods**: Dedicated region for camera data handling
- **Advanced Camera Information Methods**: Feature testing and diagnostics

### Error Handling
The application includes robust error handling:
- Graceful degradation when cameras are unavailable
- Detailed error messages for troubleshooting
- Safe disposal of camera resources
- Network timeout handling for GigE cameras

### Performance Considerations
- Efficient camera enumeration
- Lazy loading of detailed camera information
- Optimized UI updates
- Memory-conscious resource management

## Troubleshooting

### Common Issues
1. **No Cameras Found**: Ensure camera drivers are installed and cameras are connected
2. **Network Cameras**: Verify network configuration and firewall settings
3. **Permission Issues**: Run as administrator if needed for camera access
4. **Feature Unavailable**: Some cameras may not support all GenICam features

### Debug Information
Enable debug output to see:
- Camera detection process
- Feature availability testing
- Error details and stack traces
- Performance metrics

## Future Enhancements

Potential future improvements:
- Camera settings configuration UI
- Image capture and saving
- Multiple camera support
- Real-time histogram display
- Advanced trigger configuration
- Camera calibration tools

## License

This enhanced demo maintains the same license as the original VisioForge Media Blocks SDK demonstration applications. 

## Used blocks

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renders video
- [GenICamSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/GenICamSourceBlock/) - captures video from GenICam source

## Supported frameworks

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8
- .Net 9

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
