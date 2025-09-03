#version 100
#ifdef GL_ES
precision mediump float;
#endif

// Receive texture coordinates from vertex shader
varying vec2 v_texcoord;

// The texture sampler
uniform sampler2D tex;

// Blur parameters
uniform float blur_radius;   // Blur radius in pixels (1.0 to 10.0)
uniform float tex_width;     // Texture width
uniform float tex_height;    // Texture height

void main() {
    vec2 texelSize = vec2(1.0 / tex_width, 1.0 / tex_height);
    
    // Box blur - all weights are equal
    vec3 color = vec3(0.0);
    float samples = 0.0;
    
    // Calculate kernel size based on blur radius
    int kernelSize = int(blur_radius);
    if (kernelSize > 7) kernelSize = 7; // Limit for performance
    
    // Apply box blur (uniform weights)
    for (int y = -kernelSize; y <= kernelSize; y++) {
        for (int x = -kernelSize; x <= kernelSize; x++) {
            vec2 offset = vec2(float(x), float(y)) * texelSize;
            color += texture2D(tex, v_texcoord + offset).rgb;
            samples += 1.0;
        }
    }
    
    // Average all samples
    color /= samples;
    
    gl_FragColor = vec4(color, 1.0);
}