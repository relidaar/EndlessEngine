﻿#version 330 core

layout(location = 0) in vec4 aPosition;

uniform mat4 uTransform;

void main() {
    gl_Position = uTransform * aPosition;
}