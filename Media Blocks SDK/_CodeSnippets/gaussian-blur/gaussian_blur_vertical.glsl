#version 100
#ifdef GL_ES
precision mediump float;
#endif

// Receive texture coordinates from vertex shader
varying vec2 v_texcoord;

// The texture sampler
uniform sampler2D tex;

// Blur parameters
uniform float blur_radius;  // Blur radius in pixels (1.0 to 10.0)
uniform float tex_height;   // Texture height for calculating pixel offsets

// 9-tap Gaussian kernel weights (precomputed for sigma = 2.0)
// These weights are normalized to sum to 1.0
// Using defines instead of array for GLSL ES 2.0 compatibility
#define WEIGHT0 0.227027
#define WEIGHT1 0.1945946
#define WEIGHT2 0.1216216
#define WEIGHT3 0.054054
#define WEIGHT4 0.016216

void main() {
    // Calculate the texel size (1.0 / texture height)
    float texelSize = 1.0 / tex_height;
    
    // Sample the center pixel with the highest weight
    vec3 result = texture2D(tex, v_texcoord).rgb * WEIGHT0;
    
    // Apply vertical Gaussian blur - unrolled loop for GLSL ES 2.0 compatibility
    float offset1 = 1.0 * blur_radius * texelSize;
    result += texture2D(tex, v_texcoord + vec2(0.0, offset1)).rgb * WEIGHT1;
    result += texture2D(tex, v_texcoord - vec2(0.0, offset1)).rgb * WEIGHT1;
    
    float offset2 = 2.0 * blur_radius * texelSize;
    result += texture2D(tex, v_texcoord + vec2(0.0, offset2)).rgb * WEIGHT2;
    result += texture2D(tex, v_texcoord - vec2(0.0, offset2)).rgb * WEIGHT2;
    
    float offset3 = 3.0 * blur_radius * texelSize;
    result += texture2D(tex, v_texcoord + vec2(0.0, offset3)).rgb * WEIGHT3;
    result += texture2D(tex, v_texcoord - vec2(0.0, offset3)).rgb * WEIGHT3;
    
    float offset4 = 4.0 * blur_radius * texelSize;
    result += texture2D(tex, v_texcoord + vec2(0.0, offset4)).rgb * WEIGHT4;
    result += texture2D(tex, v_texcoord - vec2(0.0, offset4)).rgb * WEIGHT4;
    
    gl_FragColor = vec4(result, 1.0);
}