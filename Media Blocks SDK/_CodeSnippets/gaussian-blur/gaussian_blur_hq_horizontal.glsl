#version 100
#ifdef GL_ES
precision mediump float;
#endif

// Receive texture coordinates from vertex shader
varying vec2 v_texcoord;

// The texture sampler
uniform sampler2D tex;

// Blur parameters
uniform float blur_radius;  // Blur radius multiplier (1.0 to 10.0)
uniform float tex_width;    // Texture width for calculating pixel offsets

// 13-tap Gaussian kernel weights for higher quality blur
// These are precomputed for sigma = 3.0 and normalized
// Using defines for GLSL ES 2.0 compatibility
#define WEIGHT0 0.133571
#define WEIGHT1 0.125794
#define WEIGHT2 0.106483
#define WEIGHT3 0.080657
#define WEIGHT4 0.054670
#define WEIGHT5 0.033159
#define WEIGHT6 0.018012

void main() {
    float texelSize = 1.0 / tex_width;
    
    // Start with center pixel
    vec4 color = texture2D(tex, v_texcoord);
    vec3 result = color.rgb * WEIGHT0;
    float totalAlpha = color.a * WEIGHT0;
    
    // Apply horizontal blur with 13 taps - unrolled for GLSL ES 2.0
    float offset;
    vec4 sampleRight, sampleLeft;
    
    offset = 1.0 * blur_radius * texelSize;
    sampleRight = texture2D(tex, v_texcoord + vec2(offset, 0.0));
    sampleLeft = texture2D(tex, v_texcoord - vec2(offset, 0.0));
    result += sampleRight.rgb * WEIGHT1 + sampleLeft.rgb * WEIGHT1;
    totalAlpha += sampleRight.a * WEIGHT1 + sampleLeft.a * WEIGHT1;
    
    offset = 2.0 * blur_radius * texelSize;
    sampleRight = texture2D(tex, v_texcoord + vec2(offset, 0.0));
    sampleLeft = texture2D(tex, v_texcoord - vec2(offset, 0.0));
    result += sampleRight.rgb * WEIGHT2 + sampleLeft.rgb * WEIGHT2;
    totalAlpha += sampleRight.a * WEIGHT2 + sampleLeft.a * WEIGHT2;
    
    offset = 3.0 * blur_radius * texelSize;
    sampleRight = texture2D(tex, v_texcoord + vec2(offset, 0.0));
    sampleLeft = texture2D(tex, v_texcoord - vec2(offset, 0.0));
    result += sampleRight.rgb * WEIGHT3 + sampleLeft.rgb * WEIGHT3;
    totalAlpha += sampleRight.a * WEIGHT3 + sampleLeft.a * WEIGHT3;
    
    offset = 4.0 * blur_radius * texelSize;
    sampleRight = texture2D(tex, v_texcoord + vec2(offset, 0.0));
    sampleLeft = texture2D(tex, v_texcoord - vec2(offset, 0.0));
    result += sampleRight.rgb * WEIGHT4 + sampleLeft.rgb * WEIGHT4;
    totalAlpha += sampleRight.a * WEIGHT4 + sampleLeft.a * WEIGHT4;
    
    offset = 5.0 * blur_radius * texelSize;
    sampleRight = texture2D(tex, v_texcoord + vec2(offset, 0.0));
    sampleLeft = texture2D(tex, v_texcoord - vec2(offset, 0.0));
    result += sampleRight.rgb * WEIGHT5 + sampleLeft.rgb * WEIGHT5;
    totalAlpha += sampleRight.a * WEIGHT5 + sampleLeft.a * WEIGHT5;
    
    offset = 6.0 * blur_radius * texelSize;
    sampleRight = texture2D(tex, v_texcoord + vec2(offset, 0.0));
    sampleLeft = texture2D(tex, v_texcoord - vec2(offset, 0.0));
    result += sampleRight.rgb * WEIGHT6 + sampleLeft.rgb * WEIGHT6;
    totalAlpha += sampleRight.a * WEIGHT6 + sampleLeft.a * WEIGHT6;
    
    gl_FragColor = vec4(result, totalAlpha);
}