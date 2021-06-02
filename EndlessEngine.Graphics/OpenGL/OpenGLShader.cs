// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="OpenGLShader.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Math;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    /// <summary>
    /// Class OpenGLShader.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IShader" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IShader" />
    public class OpenGLShader : IShader
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly uint _id;
        
        /// <summary>
        /// The uniforms
        /// </summary>
        private readonly IDictionary<string, int> _uniforms;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLShader"/> class.
        /// </summary>
        /// <param name="name">The shader name.</param>
        /// <param name="vertexShaderPath">The vertex shader path.</param>
        /// <param name="fragmentShaderPath">The fragment shader path.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public OpenGLShader(string name, string vertexShaderPath, string fragmentShaderPath)
        {
            if (string.IsNullOrWhiteSpace(name) || 
                string.IsNullOrWhiteSpace(vertexShaderPath) || 
                string.IsNullOrWhiteSpace(fragmentShaderPath))
                throw new ArgumentNullException();

            if (!File.Exists(vertexShaderPath) || !File.Exists(fragmentShaderPath))
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

        /// <summary>
        /// Gets the shader name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        /// Binds this instance.
        /// </summary>
        public void Bind()
        {
            Gl.UseProgram(_id);
        }

        /// <summary>
        /// Unbinds this instance.
        /// </summary>
        public void Unbind()
        {
            Gl.UseProgram(0);
        }

        /// <summary>
        /// Creates the shader.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.UInt32.</returns>
        /// <exception cref="InvalidOperationException">unable to compile shader: {shaderLog}</exception>
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

        /// <summary>
        /// Gets the uniform location.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void SetUniform(string name, float value)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform1(location, value);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        public void SetUniform(string name, float v1, float v2)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform2(location, v1, v2);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        /// <param name="v3">The third element.</param>
        public void SetUniform(string name, float v1, float v2, float v3)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform3(location, v1, v2, v3);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        /// <param name="v3">The third element.</param>
        /// <param name="v4">The fourth element.</param>
        public void SetUniform(string name, float v1, float v2, float v3, float v4)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform4(location, v1, v2, v3, v4);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void SetUniform(string name, int value)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform1(location, value);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        public void SetUniform(string name, int v1, int v2)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform2(location, v1, v2);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        /// <param name="v3">The third element.</param>
        public void SetUniform(string name, int v1, int v2, int v3)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform3(location, v1, v2, v3);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        /// <param name="v3">The third element.</param>
        /// <param name="v4">The fourth element.</param>
        public void SetUniform(string name, int v1, int v2, int v3, int v4)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform4(location, v1, v2, v3, v4);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="vector">The vector.</param>
        public void SetUniform(string name, in Vector2 vector)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform2(location, vector.Data as float[]);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="vector">The vector.</param>
        public void SetUniform(string name, in Vector3 vector)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform3(location, vector.Data as float[]);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="vector">The vector.</param>
        public void SetUniform(string name, in Vector4 vector)
        {
            var location = GetUniformLocation(name);
            Gl.Uniform4(location, vector.Data as float[]);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="transpose">if set to <c>true</c> [transpose].</param>
        /// <param name="matrix">The matrix.</param>
        public void SetUniform(string name, bool transpose, in Matrix2 matrix)
        {
            var location = GetUniformLocation(name);
            Gl.UniformMatrix2(location, transpose, matrix.Array);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="transpose">if set to <c>true</c> [transpose].</param>
        /// <param name="matrix">The matrix.</param>
        public void SetUniform(string name, bool transpose, in Matrix3 matrix)
        {
            var location = GetUniformLocation(name);
            Gl.UniformMatrix3(location, transpose, matrix.Array);
        }

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="transpose">if set to <c>true</c> [transpose].</param>
        /// <param name="matrix">The matrix.</param>
        public void SetUniform(string name, bool transpose, in Matrix4 matrix)
        {
            var location = GetUniformLocation(name);
            Gl.UniformMatrix4(location, transpose, matrix.Array);
        }

        #endregion
    }
}