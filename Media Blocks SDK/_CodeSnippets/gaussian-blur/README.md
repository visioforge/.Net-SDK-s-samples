# Gaussian Blur Shader Demo for VisioForge MediaBlocks SDK

This demo demonstrates how to implement a configurable Gaussian blur effect using GLSL shaders with the GLShaderBlock in the VisioForge MediaBlocks SDK.

## Features

- **Three Blur Modes**:
  - **Two-Pass Standard**: Efficient 9-tap Gaussian blur with separate horizontal and vertical passes
  - **Two-Pass High Quality**: 13-tap Gaussian blur for higher quality results
  - **Single-Pass Simple**: Basic 3x3 blur kernel for faster processing

- **Real-time Controls**:
  - Adjustable blur radius/strength (0-10)
  - Mode switching during playback
  - Video playback controls (play, pause, stop, seek)

## Shader Implementation Details

### Two-Pass Blur (Recommended)

The two-pass approach is the most efficient way to implement Gaussian blur:

1. **First Pass**: Applies horizontal blur using a 1D kernel
2. **Second Pass**: Applies vertical blur using a 1D kernel

This approach reduces computational complexity from O(n²) to O(2n) for an n-tap kernel.

### Shader Files

- `gaussian_blur_vertex.glsl` - Standard vertex shader for texture coordinate passing
- `gaussian_blur_horizontal.glsl` - 9-tap horizontal blur (standard quality)
- `gaussian_blur_vertical.glsl` - 9-tap vertical blur (standard quality)
- `gaussian_blur_hq_horizontal.glsl` - 13-tap horizontal blur (high quality)
- `gaussian_blur_hq_vertical.glsl` - 13-tap vertical blur (high quality)
- `gaussian_blur_combined.glsl` - Single-pass 3x3 blur (simple/fast)

### Uniform Parameters

The shaders use the following uniforms that can be dynamically adjusted:

- `blur_radius` - Controls the blur strength (1.0 to 10.0)
- `blur_strength` - Alternative blur control for single-pass shader (0.0 to 1.0)
- `tex_width` - Texture width for calculating horizontal offsets
- `tex_height` - Texture height for calculating vertical offsets

## Pipeline Architecture

The MediaBlocks pipeline is structured as follows:

```
[Video File] -> [UniversalSourceBlock] -> [GLUploadBlock] -> 
[GLShaderBlock (H-Blur)] -> [GLShaderBlock (V-Blur)] -> 
[GLDownloadBlock] -> [VideoRendererBlock] -> [Display]
```

For single-pass mode, only one GLShaderBlock is used.

## Usage

1. **Build and Run**: Open the project in Visual Studio and build with x64 configuration
2. **Select Video**: Click "Select File" to choose a video file
3. **Configure Blur**:
   - Choose blur mode from dropdown
   - Adjust blur radius with the slider
4. **Play**: Click "Start" to begin playback with blur effect

## Code Integration

### Setting Up GLShaderBlock

```csharp
// Load shader source
var vertexShader = File.ReadAllText("gaussian_blur_vertex.glsl");
var fragmentShader = File.ReadAllText("gaussian_blur_horizontal.glsl");

// Create shader settings with uniforms
var shaderSettings = new GLShaderSettings(vertexShader, fragmentShader);
shaderSettings.Uniforms["blur_radius"] = 2.0f;
shaderSettings.Uniforms["tex_width"] = 1920.0f;

// Create shader block
var blurShader = new GLShaderBlock(shaderSettings);
```

### Updating Parameters Dynamically

```csharp
// Update blur strength at runtime
blurShader.Settings.Uniforms["blur_radius"] = newRadius;
blurShader.Update();
```

### Complete Pipeline Setup

```csharp
// Create blocks
var source = new UniversalSourceBlock(settings);
var glUpload = new GLUploadBlock();
var blurH = new GLShaderBlock(horizontalSettings);
var blurV = new GLShaderBlock(verticalSettings);
var glDownload = new GLDownloadBlock();
var renderer = new VideoRendererBlock(pipeline, videoView);

// Connect pipeline
pipeline.Connect(source.VideoOutput, glUpload.Input);
pipeline.Connect(glUpload.Output, blurH.Input);
pipeline.Connect(blurH.Output, blurV.Input);
pipeline.Connect(blurV.Output, glDownload.Input);
pipeline.Connect(glDownload.Output, renderer.Input);
```

## Performance Considerations

1. **GPU Acceleration**: All blur processing happens on the GPU for optimal performance
2. **Two-Pass Efficiency**: Separable filters reduce computation significantly
3. **Texture Cache**: GPU texture cache improves memory access patterns
4. **Real-time Processing**: Suitable for real-time video processing at 1080p and beyond

## Requirements

- VisioForge Media Blocks SDK .Net
- Redists

## Customization

You can modify the blur kernels by:

1. Adjusting the weight arrays in the fragment shaders
2. Changing the number of taps (samples)
3. Implementing different blur algorithms (box blur, motion blur, etc.)
4. Adding additional uniform parameters for more control

## License

This demo is part of the VisioForge MediaBlocks SDK examples and follows the SDK licensing terms.
