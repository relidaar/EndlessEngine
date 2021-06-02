// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="OpenGLShaderLibrary.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.OpenGL
{
    /// <summary>
    /// Class OpenGLShaderLibrary.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IShaderLibrary" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IShaderLibrary" />
    public class OpenGLShaderLibrary : IShaderLibrary
    {
        /// <summary>
        /// The shaders
        /// </summary>
        private readonly IDictionary<string, IShader> _shaders;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLShaderLibrary"/> class.
        /// </summary>
        public OpenGLShaderLibrary()
        {
            _shaders = new Dictionary<string, IShader>();
        }

        /// <summary>
        /// Adds the specified shader.
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception">Shader already exists</exception>
        public void Add(IShader shader)
        {
            if (shader == null)
                throw new ArgumentNullException();

            if (_shaders.ContainsKey(shader.Name))
                throw new Exception("Shader already exists");

            _shaders[shader.Name] = shader;
        }

        /// <summary>
        /// Loads the specified shader.
        /// </summary>
        /// <param name="name">The shader name.</param>
        /// <param name="vertexShaderPath">The vertex shader path.</param>
        /// <param name="fragmentShaderPath">The fragment shader path.</param>
        /// <returns>IShader.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IShader Load(string name, string vertexShaderPath, string fragmentShaderPath)
        {
            if (string.IsNullOrWhiteSpace(name) || 
                string.IsNullOrWhiteSpace(vertexShaderPath) || 
                string.IsNullOrWhiteSpace(fragmentShaderPath))
                throw new ArgumentNullException();

            var shader = new OpenGLShader(name, vertexShaderPath, fragmentShaderPath);
            Add(shader);
            return shader;
        }

        /// <summary>
        /// Gets the specified shader.
        /// </summary>
        /// <param name="name">The shader name.</param>
        /// <returns>IShader.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public IShader Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException();
            
            if (!_shaders.ContainsKey(name))
                throw new KeyNotFoundException();

            return _shaders[name];
        }
    }
}