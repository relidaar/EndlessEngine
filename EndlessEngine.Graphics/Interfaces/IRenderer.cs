// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 04-13-2020
// ***********************************************************************
// <copyright file="IRenderer.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using EndlessEngine.Math;

namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IRenderer
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Initializes the specified shader.
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <param name="vertexArray">The vertex array.</param>
        void Init(IShader shader, IVertexArray vertexArray);
        
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Init();
        
        /// <summary>
        /// Uses the default shader.
        /// </summary>
        void UseDefaultShader();

        /// <summary>
        /// Clears the screen.
        /// </summary>
        void Clear();
        
        /// <summary>
        /// Sets the background color of the window.
        /// </summary>
        /// <param name="color">The color.</param>
        void SetClearColor(in Color color);
        
        /// <summary>
        /// Sets the background color of the window.
        /// </summary>
        /// <param name="r">The R value.</param>
        /// <param name="g">The G value.</param>
        /// <param name="b">The B value.</param>
        /// <param name="a">The A value.</param>
        void SetClearColor(int r, int g, int b, int a = 255);
        
        /// <summary>
        /// Sets the background color of the window.
        /// </summary>
        /// <param name="r">The R value.</param>
        /// <param name="g">The G value.</param>
        /// <param name="b">The B value.</param>
        /// <param name="a">The A value.</param>
        void SetClearColor(float r, float g, float b, float a = 1f);

        /// <summary>
        /// Sets the scene.
        /// </summary>
        /// <param name="camera">The camera.</param>
        void SetScene(ICamera camera);
        
        /// <summary>
        /// Sets the scene.
        /// </summary>
        /// <param name="camera">The camera.</param>
        /// <param name="shader">The shader.</param>
        void SetScene(ICamera camera, IShader shader);

        /// <summary>
        /// Draws the specified figure.
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <param name="vertexArray">The vertex array.</param>
        /// <param name="transform">The transform.</param>
        void Draw(IShader shader, IVertexArray vertexArray, in Matrix4 transform);
        
        /// <summary>
        /// Draws the specified colored square.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="size">The size.</param>
        /// <param name="color">The color.</param>
        void Draw(in Vector2 position, in Vector2 size, in Color color);
        
        /// <summary>
        /// Draws the specified texture.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="size">The size.</param>
        /// <param name="texture">The texture.</param>
        /// <param name="tilingFactor">The tiling factor.</param>
        void Draw(in Vector2 position, in Vector2 size, ITexture texture, float tilingFactor = 1.0f);
        
        /// <summary>
        /// Draws the specified sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        /// <param name="tilingFactor">The tiling factor.</param>
        void Draw(Sprite sprite, float tilingFactor = 1.0f);
    }
}