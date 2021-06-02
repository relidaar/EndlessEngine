// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="IGraphicsFactory.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IGraphicsFactory
    /// </summary>
    public interface IGraphicsFactory
    {
        /// <summary>
        /// Creates the vertex buffer.
        /// </summary>
        /// <param name="vertices">The vertices.</param>
        /// <returns>IVertexBuffer.</returns>
        IVertexBuffer CreateVertexBuffer(params float[] vertices);
        
        /// <summary>
        /// Creates the index buffer.
        /// </summary>
        /// <param name="indices">The indices.</param>
        /// <returns>IIndexBuffer.</returns>
        IIndexBuffer CreateIndexBuffer(params int[] indices);
        
        /// <summary>
        /// Creates the vertex array.
        /// </summary>
        /// <returns>IVertexArray.</returns>
        IVertexArray CreateVertexArray();
        
        /// <summary>
        /// Creates the buffer layout.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <returns>IBufferLayout.</returns>
        IBufferLayout CreateBufferLayout(params BufferElement[] elements);

        /// <summary>
        /// Creates the window.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="resizable">Is window resizable.</param>
        /// <param name="graphicsSettings">The graphics settings.</param>
        /// <returns>IWindow.</returns>
        IWindow CreateWindow(in WindowProperties properties, bool resizable, in GraphicsSettings graphicsSettings);
        
        /// <summary>
        /// Creates the window.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="resizable">Is window resizable.</param>
        /// <returns>IWindow.</returns>
        IWindow CreateWindow(in WindowProperties properties, bool resizable);

        /// <summary>
        /// Creates the window.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="title">The title.</param>
        /// <param name="resizable">Is window resizable.</param>
        /// <param name="graphicsSettings">The graphics settings.</param>
        /// <returns>IWindow.</returns>
        IWindow CreateWindow(int width, int height, string title, bool resizable, in GraphicsSettings graphicsSettings);

        /// <summary>
        /// Creates the window.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="title">The title.</param>
        /// <param name="resizable">Is window resizable.</param>
        /// <returns>IWindow.</returns>
        IWindow CreateWindow(int width, int height, string title, bool resizable);

        /// <summary>
        /// Creates the renderer.
        /// </summary>
        /// <param name="shaderSettings">The shader settings.</param>
        /// <returns>IRenderer.</returns>
        IRenderer CreateRenderer(in ShaderSettings shaderSettings);
        
        /// <summary>
        /// Creates the renderer.
        /// </summary>
        /// <returns>IRenderer.</returns>
        IRenderer CreateRenderer();

        /// <summary>
        /// Creates the shader.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="vertexShaderPath">The vertex shader path.</param>
        /// <param name="fragmentShaderPath">The fragment shader path.</param>
        /// <returns>IShader.</returns>
        IShader CreateShader(string name, string vertexShaderPath, string fragmentShaderPath);
        
        /// <summary>
        /// Creates the shader library.
        /// </summary>
        /// <returns>IShaderLibrary.</returns>
        IShaderLibrary CreateShaderLibrary();

        /// <summary>
        /// Creates the texture.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="textureData">The texture data.</param>
        /// <returns>ITexture.</returns>
        ITexture CreateTexture(string path, in TextureData textureData);
        
        /// <summary>
        /// Creates the texture.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="data">The data.</param>
        /// <param name="textureData">The texture data.</param>
        /// <returns>ITexture.</returns>
        ITexture CreateTexture(int width, int height, object data, in TextureData textureData);
    }
}