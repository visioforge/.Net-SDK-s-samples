#version 100
#ifdef GL_ES
precision mediump float;
#endif

// Receive texture coordinates from vertex shader
varying vec2 v_texcoord;

// The texture sampler
uniform sampler2D tex;

// Blur parameters
uniform float blur_radius;   // Blur radius multiplier (0.0 to 10.0)
uniform float tex_width;     // Texture width
uniform float tex_height;    // Texture height
uniform float blur_quality;  // Quality factor (1.0 = low, 2.0 = medium, 3.0 = high)

// Gaussian function to compute weights dynamically
float gaussian(float x, float sigma) {
    return exp(-(x * x) / (2.0 * sigma * sigma));
}

void main() {
    vec2 texelSize = vec2(1.0 / tex_width, 1.0 / tex_height);
    
    // Adjust sigma based on blur radius
    float sigma = blur_radius * 2.0;
    
    // Calculate kernel size based on quality setting
    int kernelSize = int(blur_radius * blur_quality * 2.0 + 1.0);
    if (kernelSize > 15) kernelSize = 15; // Limit for performance
    
    vec3 color = vec3(0.0);
    float totalWeight = 0.0;
    
    // Apply adaptive Gaussian blur
    for (int y = -7; y <= 7; y++) {
        if (abs(y) > kernelSize / 2) continue;
        
        for (int x = -7; x <= 7; x++) {
            if (abs(x) > kernelSize / 2) continue;
            
            vec2 offset = vec2(float(x), float(y)) * texelSize * blur_radius;
            float distance = length(vec2(float(x), float(y)));
            float weight = gaussian(distance, sigma);
            
            color += texture2D(tex, v_texcoord + offset).rgb * weight;
            totalWeight += weight;
        }
    }
    
    // Normalize the result
    color /= totalWeight;
    
    gl_FragColor = vec4(color, 1.0);
}