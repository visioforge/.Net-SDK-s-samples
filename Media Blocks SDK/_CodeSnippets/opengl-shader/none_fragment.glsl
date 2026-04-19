#version 100
#ifdef GL_ES
precision mediump float;
#endif

// Receive texture coordinates from vertex shader
varying vec2 v_texcoord;

// The default texture sampler in GStreamer is usually "tex"
uniform sampler2D tex;

void main() {
    gl_FragColor = texture2D( tex, v_texcoord );
}
