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
uniform float tex_height;   // Texture height for calculating pixel offsets

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
    float texelSize = 1.0 / tex_height;
    
    // Start with center pixel
    vec4 color = texture2D(tex, v_texcoord);
    vec3 result = color.rgb * WEIGHT0;
    float totalAlpha = color.a * WEIGHT0;
    
    // Apply vertical blur with 13 taps - unrolled for GLSL ES 2.0
    float offset;
    vec4 sampleUp, sampleDown;
    
    offset = 1.0 * blur_radius * texelSize;
    sampleUp = texture2D(tex, v_texcoord + vec2(0.0, offset));
    sampleDown = texture2D(tex, v_texcoord - vec2(0.0, offset));
    result += sampleUp.rgb * WEIGHT1 + sampleDown.rgb * WEIGHT1;
    totalAlpha += sampleUp.a * WEIGHT1 + sampleDown.a * WEIGHT1;
    
    offset = 2.0 * blur_radius * texelSize;
    sampleUp = texture2D(tex, v_texcoord + vec2(0.0, offset));
    sampleDown = texture2D(tex, v_texcoord - vec2(0.0, offset));
    result += sampleUp.rgb * WEIGHT2 + sampleDown.rgb * WEIGHT2;
    totalAlpha += sampleUp.a * WEIGHT2 + sampleDown.a * WEIGHT2;
    
    offset = 3.0 * blur_radius * texelSize;
    sampleUp = texture2D(tex, v_texcoord + vec2(0.0, offset));
    sampleDown = texture2D(tex, v_texcoord - vec2(0.0, offset));
    result += sampleUp.rgb * WEIGHT3 + sampleDown.rgb * WEIGHT3;
    totalAlpha += sampleUp.a * WEIGHT3 + sampleDown.a * WEIGHT3;
    
    offset = 4.0 * blur_radius * texelSize;
    sampleUp = texture2D(tex, v_texcoord + vec2(0.0, offset));
    sampleDown = texture2D(tex, v_texcoord - vec2(0.0, offset));
    result += sampleUp.rgb * WEIGHT4 + sampleDown.rgb * WEIGHT4;
    totalAlpha += sampleUp.a * WEIGHT4 + sampleDown.a * WEIGHT4;
    
    offset = 5.0 * blur_radius * texelSize;
    sampleUp = texture2D(tex, v_texcoord + vec2(0.0, offset));
    sampleDown = texture2D(tex, v_texcoord - vec2(0.0, offset));
    result += sampleUp.rgb * WEIGHT5 + sampleDown.rgb * WEIGHT5;
    totalAlpha += sampleUp.a * WEIGHT5 + sampleDown.a * WEIGHT5;
    
    offset = 6.0 * blur_radius * texelSize;
    sampleUp = texture2D(tex, v_texcoord + vec2(0.0, offset));
    sampleDown = texture2D(tex, v_texcoord - vec2(0.0, offset));
    result += sampleUp.rgb * WEIGHT6 + sampleDown.rgb * WEIGHT6;
    totalAlpha += sampleUp.a * WEIGHT6 + sampleDown.a * WEIGHT6;
    
    gl_FragColor = vec4(result, totalAlpha);
}