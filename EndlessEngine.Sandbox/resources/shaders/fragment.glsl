#version 330 core

in vec2 vTextureCoordinates;

uniform sampler2D uTexture;

layout(location = 0) out vec4 color;

void main() {
    color = texture(uTexture, vTextureCoordinates);
}