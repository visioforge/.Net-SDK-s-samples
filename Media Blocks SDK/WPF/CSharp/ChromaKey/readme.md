# ChromaKey Demo - Media Blocks SDK .Net

This demo application demonstrates the ChromaKey (green screen) functionality using the Media Blocks SDK for .Net.

## Features

- **Video Source**: Connect to any camera/video capture device OR use video files for chroma video input
- **Background Source**: Use either an image file or solid color as background
- **Real-time ChromaKey Processing**: Remove green/blue/custom color backgrounds in real-time
- **Advanced ChromaKey Settings**: Full control over all GStreamer alpha element properties
- **Audio Support**: Optional audio input and output (including audio from video files)
- **Video File Support**: Play MP4, AVI, MKV, WebM, MOV, and many other video formats
- **Preview Only**: No capture functionality - focus on real-time preview

## Requirements

- Windows 10/11 x64
- .NET 4.6.1 or later
- Video capture device (webcam, capture card, etc.)
- VisioForge Media Blocks SDK
- SkiaSharp (for color handling)

## How to Use

1. **Start the Application**: Run the executable or launch from Visual Studio

2. **Configure Video Source**:
   - **Camera/Capture Device**: Select your video input device, choose format and frame rate
   - **Video File**: Select a video file (MP4, AVI, MKV, WebM, MOV, etc.) and enable looping if desired
   - Optionally enable horizontal flip for the chroma video

3. **Configure Background**:
   - **Image Background**: Specify path to background image file (JPG, PNG, BMP)
   - **Color Background**: Enable "Use solid color background" and select color

4. **ChromaKey Settings**:
   - **Chroma Color**: Choose Green, Blue, or Custom color to remove
   - **Custom Color**: When using Custom, click the color button to select any color
   - **Alpha**: Overall transparency level (0.0-1.0)
   - **Sensitivity (Angle)**: Size of color cube to change (0-180)
   - **Noise Level**: Size of noise radius for cleaning (0-64)
   - **Black Sensitivity**: Sensitivity to dark colors (0-255)
   - **White Sensitivity**: Sensitivity to bright colors (0-255)
   - **Prefer Passthrough**: Performance optimization for alpha=1.0
   - **Legacy Edge Smoothing**: Deprecated - automatically maps to black/white sensitivity

5. **Audio (Optional)**:
   - Select audio input device if available
   - Choose audio output device for monitoring
   - Adjust volume level

6. **Start Preview**: Click "Start Preview" to begin real-time processing

## Tips for Best Results

1. **Lighting**: Use even, diffused lighting on the chroma background
2. **Background**: Use a clean, wrinkle-free green/blue screen
3. **Distance**: Keep subject away from chroma background to avoid color spill
4. **Settings**: 
   - Start with default sensitivity (20) and adjust as needed
   - Use black/white sensitivity for fine-tuning edge detection
   - Adjust noise level to remove artifacts
   - Use alpha for overall transparency control
5. **Performance**: Enable "Prefer Passthrough" for better performance when alpha=1.0

## Troubleshooting

- **No video devices**: Make sure your camera/capture device is properly connected
- **Poor chroma key quality**: 
  - Adjust lighting and sensitivity settings
  - Fine-tune black/white sensitivity values
  - Adjust noise level to remove artifacts
- **Performance issues**: 
  - Try lower video resolution or frame rate
  - Enable "Prefer Passthrough" option
- **Audio issues**: Check audio device selection and formats
- **Color accuracy**: The demo now uses SkiaSharp for better color precision

For more information, visit [VisioForge website](https://www.visioforge.com)