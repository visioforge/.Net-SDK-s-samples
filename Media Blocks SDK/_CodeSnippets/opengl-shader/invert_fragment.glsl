#version 100

#ifdef GL_ES
precision mediump float;
#endif

varying vec2 v_texcoord;
uniform sampler2D tex;

void main() 
{
    // Sample the color from the texture
    vec4 color = texture2D(tex, v_texcoord);

    // Invert the RGB colors
    vec3 invertedColor = vec3(1.0) - color.rgb;

    // Output the inverted color, preserve alpha from the original texture
    gl_FragColor = vec4(invertedColor, color.a);
}
