﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Math;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLShader : IShader
    {
        private readonly uint _id;
        private readonly IDictionary<string, int> _uniforms;

        public OpenGLShader(string name, string vertexShaderPath, string fragmentShaderPath)
        {
            if (string.IsNullOrWhiteSpace(name) || 
                string.IsNullOrWhiteSpace(vertexShaderPath) || 
                string.IsNullOrWhiteSpace(fragmentShaderPath))
                throw new ArgumentNullException();

            if (File.Exists(vertexShaderPath) || File.Exists(fragmentShaderPath))
                throw new FileNotFoundException();

            Name = name;

            var vertexSource = new[] {File.ReadAllText(vertexShaderPath)};
            var fragmentSource = new[] {File.ReadAllText(fragmentShaderPath)};

            _uniforms = new Dictionary<string, int>();
            var vertexShader = CreateShader(vertexSource, ShaderType.VertexShader);
            var fragmentShader = CreateShader(fragmentSource, ShaderType.FragmentShader);

            _id = Gl.CreateProgram();

            Gl.AttachShader(_id, vertexShader);
            Gl.AttachShader(_id, fragmentShader);
            Gl.LinkProgram(_id);

            Gl.DetachShader(_id, vertexShader);
            Gl.DetachShader(_id, fragmentShader);
            Gl.DeleteShader(vertexShader);
            Gl.DeleteShader(fragmentShader);
        }

        public string Name { get; }

        public void Bind()
        {
            Gl.UseProgram(_id);
        }

        public void Unbind()
        {
            Gl.UseProgram(0);
        }

        private static uint CreateShader(string[] source, ShaderType type)
        {
            var id = Gl.CreateShader(type);
            Gl.ShaderSource(id, source);
            Gl.CompileShader(id);

            Gl.GetShader(id, ShaderParameterName.CompileStatus, out var compiled);
            if (compiled != 0)
                return id;

            Gl.GetShader(id, ShaderParameterName.InfoLogLength, out var logLength);
            var shaderLog = new StringBuilder(logLength);
            Gl.GetShaderInfoLog(id, logLength, out _, shaderLog);

            Gl.DeleteShader(id);
            throw new InvalidOperationException($"unable to compile shader: {shaderLog}");
        }

        private int GetUniformLocation(string name)
        {
            if (name == null)
                throw new ArgumentNullException();

            if (_uniforms.ContainsKey(name))
                return _uniforms[name];

            var location = Gl.GetUniformLocation(_id, name);
            _uniforms[name] = location;

            return location;
        }

        #region Uniforms

        public void SetUniform(string name, float value)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform1(location, value);
        }

        public void SetUniform(string name, float v1, float v2)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform2(location, v1, v2);
        }

        public void SetUniform(string name, float v1, float v2, float v3)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform3(location, v1, v2, v3);
        }

        public void SetUniform(string name, float v1, float v2, float v3, float v4)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform4(location, v1, v2, v3, v4);
        }

        public void SetUniform(string name, int value)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform1(location, value);
        }

        public void SetUniform(string name, int v1, int v2)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform2(location, v1, v2);
        }

        public void SetUniform(string name, int v1, int v2, int v3)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform3(location, v1, v2, v3);
        }

        public void SetUniform(string name, int v1, int v2, int v3, int v4)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform4(location, v1, v2, v3, v4);
        }

        public void SetUniform(string name, in Vector2 vector)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform2(location, vector.Data as float[]);
        }

        public void SetUniform(string name, in Vector3 vector)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform3(location, vector.Data as float[]);
        }

        public void SetUniform(string name, in Vector4 vector)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform4(location, vector.Data as float[]);
        }

        public void SetUniform(string name, bool transpose, in Matrix2 matrix)
        {
            var location = GetUniformLocation(name);
            Gl.UniformMatrix2(location, transpose, matrix.Array);
        }

        public void SetUniform(string name, bool transpose, in Matrix3 matrix)
        {
            var location = GetUniformLocation(name);
            Gl.UniformMatrix3(location, transpose, matrix.Array);
        }

        public void SetUniform(string name, bool transpose, in Matrix4 matrix)
        {
            var location = GetUniformLocation(name);
            Gl.UniformMatrix4(location, transpose, matrix.Array);
        }

        #endregion
    }
}