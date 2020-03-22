#version 330 core

layout(location = 0) in vec4 aPosition;
layout(location = 1) in vec2 aTextureCoordinates;

uniform mat4 uViewProjection;
uniform mat4 uTransform;

out vec2 vTextureCoordinates;

void main() {
    gl_Position = uViewProjection * uTransform * aPosition;
    vTextureCoordinates = aTextureCoordinates;
}