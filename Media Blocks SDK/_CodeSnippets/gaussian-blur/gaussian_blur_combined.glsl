#version 100
#ifdef GL_ES
precision mediump float;
#endif

// Receive texture coordinates from vertex shader
varying vec2 v_texcoord;

// The texture sampler
uniform sampler2D tex;

// Blur parameters
uniform float blur_strength; // Blur strength from 0.0 to 1.0
uniform float tex_width;     // Texture width
uniform float tex_height;    // Texture height

void main() {
    // Single-pass approximation of Gaussian blur
    // This is less efficient than two-pass but simpler for demonstration
    
    vec2 texelSize = vec2(1.0 / tex_width, 1.0 / tex_height);
    vec4 color = vec4(0.0);
    
    // Define offsets and weights for a 3x3 kernel
    // Center weight
    color += texture2D(tex, v_texcoord) * 0.25;
    
    // Cross pattern (horizontal and vertical neighbors)
    float crossWeight = 0.125;
    color += texture2D(tex, v_texcoord + vec2(texelSize.x * blur_strength, 0.0)) * crossWeight;
    color += texture2D(tex, v_texcoord - vec2(texelSize.x * blur_strength, 0.0)) * crossWeight;
    color += texture2D(tex, v_texcoord + vec2(0.0, texelSize.y * blur_strength)) * crossWeight;
    color += texture2D(tex, v_texcoord - vec2(0.0, texelSize.y * blur_strength)) * crossWeight;
    
    // Diagonal neighbors
    float diagWeight = 0.0625;
    color += texture2D(tex, v_texcoord + texelSize * blur_strength) * diagWeight;
    color += texture2D(tex, v_texcoord - texelSize * blur_strength) * diagWeight;
    color += texture2D(tex, v_texcoord + vec2(texelSize.x, -texelSize.y) * blur_strength) * diagWeight;
    color += texture2D(tex, v_texcoord + vec2(-texelSize.x, texelSize.y) * blur_strength) * diagWeight;
    
    gl_FragColor = color;
}