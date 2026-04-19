#version 100
#ifdef GL_ES
precision mediump float;
#endif

// Receive texture coordinates from vertex shader
varying vec2 v_texcoord;

// The default texture sampler in GStreamer is usually "tex"
uniform sampler2D tex;

void main() {
    // Sample the original texture color
    vec4 color = texture2D(tex, v_texcoord);

    // Convert to grayscale using luminosity method
    float gray = dot(color.rgb, vec3(0.299, 0.587, 0.114));

    // Output the final color (grayscale)
    gl_FragColor = vec4(vec3(gray), color.a);
}
