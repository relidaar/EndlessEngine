// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="OpenGLGraphicsFactory.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.OpenGL
{
    /// <summary>
    /// Class OpenGLGraphicsFactory.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IGraphicsFactory" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IGraphicsFactory" />
    public class OpenGLGraphicsFactory : IGraphicsFactory
    {
        /// <summary>
        /// Creates the vertex buffer.
        /// </summary>
        /// <param name="vertices">The vertices.</param>
        /// <returns>IVertexBuffer.</returns>
        public IVertexBuffer CreateVertexBuffer(params float[] vertices)
        {
            return new OpenGLVertexBuffer(vertices);
        }

        /// <summary>
        /// Creates the index buffer.
        /// </summary>
        /// <param name="indices">The indices.</param>
        /// <returns>IIndexBuffer.</returns>
        public IIndexBuffer CreateIndexBuffer(params int[] indices)
        {
            return new OpenGLIndexBuffer(indices);
        }

        /// <summary>
        /// Creates the vertex array.
        /// </summary>
        /// <returns>IVertexArray.</returns>
        public IVertexArray CreateVertexArray()
        {
            return new OpenGLVertexArray();
        }

        /// <summary>
        /// Creates the buffer layout.
        /// </summary>
        /// <param name="elements">The buffer elements.</param>
        /// <returns>IBufferLayout.</returns>
        public IBufferLayout CreateBufferLayout(params BufferElement[] elements)
        {
            return new OpenGLBufferLayout(elements);
        }

        /// <summary>
        /// Creates the window.
        /// </summary>
        /// <param name="properties">The window properties.</param>
        /// <param name="graphicsSettings">The graphics settings.</param>
        /// <returns>IWindow.</returns>
        public IWindow CreateWindow(in WindowProperties properties, in GraphicsSettings graphicsSettings)
        {
            return new OpenGLWindow(properties, graphicsSettings);
        }

        /// <summary>
        /// Creates the window.
        /// </summary>
        /// <param name="properties">The window properties.</param>
        /// <returns>IWindow.</returns>
        public IWindow CreateWindow(in WindowProperties properties)
        {
            return new OpenGLWindow(properties);
        }

        /// <summary>
        /// Creates the window.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="title">The title.</param>
        /// <param name="graphicsSettings">The graphics settings.</param>
        /// <returns>IWindow.</returns>
        public IWindow CreateWindow(int width, int height, string title, in GraphicsSettings graphicsSettings)
        {
            return new OpenGLWindow(width, height, title, graphicsSettings);
        }

        /// <summary>
        /// Creates the window.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="title">The title.</param>
        /// <returns>IWindow.</returns>
        public IWindow CreateWindow(int width, int height, string title)
        {
            return new OpenGLWindow(width, height, title);
        }

        /// <summary>
        /// Creates the renderer.
        /// </summary>
        /// <param name="shaderSettings">The shader settings.</param>
        /// <returns>IRenderer.</returns>
        public IRenderer CreateRenderer(in ShaderSettings shaderSettings)
        {
            return new OpenGLRenderer(this, shaderSettings);
        }

        /// <summary>
        /// Creates the renderer.
        /// </summary>
        /// <returns>IRenderer.</returns>
        public IRenderer CreateRenderer()
        {
            return new OpenGLRenderer(this);
        }

        /// <summary>
        /// Creates the shader.
        /// </summary>
        /// <param name="name">The shader name.</param>
        /// <param name="vertexShaderPath">The vertex shader path.</param>
        /// <param name="fragmentShaderPath">The fragment shader path.</param>
        /// <returns>IShader.</returns>
        public IShader CreateShader(string name, string vertexShaderPath, string fragmentShaderPath)
        {
            return new OpenGLShader(name, vertexShaderPath, fragmentShaderPath);
        }

        /// <summary>
        /// Creates the shader library.
        /// </summary>
        /// <returns>IShaderLibrary.</returns>
        public IShaderLibrary CreateShaderLibrary()
        {
            return new OpenGLShaderLibrary();
        }

        /// <summary>
        /// Creates the texture.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="textureData">The texture data.</param>
        /// <returns>ITexture.</returns>
        public ITexture CreateTexture(string path, in TextureData textureData)
        {
            return new OpenGLTexture(path, textureData);
        }

        /// <summary>
        /// Creates the texture.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="data">The data.</param>
        /// <param name="textureData">The texture data.</param>
        /// <returns>ITexture.</returns>
        public ITexture CreateTexture(int width, int height, object data, in TextureData textureData)
        {
            return new OpenGLTexture(width, height, data, textureData);
        }
    }
}