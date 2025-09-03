#version 100
#ifdef GL_ES
precision mediump float;
#endif

// Typical attribute declarations for ES 2.0
attribute vec4 a_position;
attribute vec2 a_texcoord;

// Pass texture coordinates to the fragment shader
varying vec2 v_texcoord;

void main() {
    // Assign the vertex position
    gl_Position = a_position;
    // Forward texture coordinates
    v_texcoord = a_texcoord;
}