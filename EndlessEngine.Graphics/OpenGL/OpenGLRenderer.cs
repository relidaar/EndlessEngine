// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="OpenGLRenderer.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Math;
using Newtonsoft.Json;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    /// <summary>
    /// Class OpenGLRenderer.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IRenderer" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IRenderer" />
    public class OpenGLRenderer : IRenderer
    {
        /// <summary>
        /// The factory
        /// </summary>
        private readonly IGraphicsFactory _factory;
        
        /// <summary>
        /// The shader settings
        /// </summary>
        private readonly ShaderSettings _shaderSettings;

        /// <summary>
        /// The default texture
        /// </summary>
        private ITexture _defaultTexture;
        
        /// <summary>
        /// The shader
        /// </summary>
        private IShader _shader;
        
        /// <summary>
        /// The vertex array
        /// </summary>
        private IVertexArray _vertexArray;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLRenderer"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="shaderSettings">The shader settings.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public OpenGLRenderer(IGraphicsFactory factory, in ShaderSettings shaderSettings)
        {
            _factory = factory ?? throw new ArgumentNullException();
            _shaderSettings = shaderSettings;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLRenderer"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public OpenGLRenderer(IGraphicsFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException();
            
            using (var r = new StreamReader(Paths.ShaderSettingsPath))
            {
                var json = r.ReadToEnd();
                _shaderSettings = JsonConvert.DeserializeObject<ShaderSettings>(json);
            }
        }

        /// <summary>
        /// Initializes the specified shader.
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <param name="vertexArray">The vertex array.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Init(IShader shader, IVertexArray vertexArray)
        {
            if (shader == null || vertexArray == null)
                throw new ArgumentNullException();

            _shader = shader;
            _shader.Bind();

            _vertexArray = vertexArray;

            _defaultTexture = _factory.CreateTexture(1, 1, 0xffffffff, TextureData.Default);

            Gl.Enable(EnableCap.Blend);
            Gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            Gl.Enable(EnableCap.DepthTest);
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Init()
        {
            var vertexArray = _factory.CreateVertexArray();
            var shaderLibrary = _factory.CreateShaderLibrary();

            var vertices = new[]
            {
                -0.5f, -0.5f, 0.0f, 0.0f,
                0.5f, -0.5f, 1.0f, 0.0f,
                0.5f, 0.5f, 1.0f, 1.0f,
                -0.5f, 0.5f, 0.0f, 1.0f
            };

            var vertexBuffer = _factory.CreateVertexBuffer(vertices);
            vertexBuffer.Layout = _factory.CreateBufferLayout(
                new BufferElement(ShaderDataType.Float2, _shaderSettings.VerticesPosition),
                new BufferElement(ShaderDataType.Float2, _shaderSettings.TextureCoordinates)
            );
            vertexBuffer.Bind();
            vertexArray.Add(vertexBuffer);

            var indices = new[] {0, 1, 2, 2, 3, 0};
            var indexBuffer = _factory.CreateIndexBuffer(indices);
            indexBuffer.Bind();
            vertexArray.Add(indexBuffer);

            var shader = shaderLibrary.Load(
                _shaderSettings.ShaderName,
                Paths.ShadersPath + _shaderSettings.VertexShaderFilename,
                Paths.ShadersPath + _shaderSettings.FragmentShaderFilename
            );
            shader.Bind();
            shader.SetUniform(_shaderSettings.TextureUniform, 0);

            Init(shader, vertexArray);
        }

        /// <summary>
        /// Uses the default shader.
        /// </summary>
        public void UseDefaultShader()
        {
            _shader.Bind();
        }

        /// <summary>
        /// Clears the screen.
        /// </summary>
        public void Clear()
        {
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
        
        /// <summary>
        /// Sets the background color of the window.
        /// </summary>
        /// <param name="color">The color.</param>
        public void SetClearColor(in Color color)
        {
            var (r, g, b, a) = color.ToNormalized();
            Gl.ClearColor(r, g, b, a);
        }
        
        /// <summary>
        /// Sets the background color of the window.
        /// </summary>
        /// <param name="r">The R value.</param>
        /// <param name="g">The G value.</param>
        /// <param name="b">The B value.</param>
        /// <param name="a">The A value.</param>
        public void SetClearColor(int r, int g, int b, int a)
        {
            var (nR, nG, nB, nA) = Color.Normalize(r, g, b, a);
            Gl.ClearColor(nR, nG, nB, nA);
        }
        
        /// <summary>
        /// Sets the background color of the window.
        /// </summary>
        /// <param name="r">The R value.</param>
        /// <param name="g">The G value.</param>
        /// <param name="b">The B value.</param>
        /// <param name="a">The A value.</param>
        public void SetClearColor(float r, float g, float b, float a)
        {
            Gl.ClearColor(r, g, b, a);
        }

        /// <summary>
        /// Sets the scene.
        /// </summary>
        /// <param name="camera">The camera.</param>
        public void SetScene(ICamera camera)
        {
            SetScene(camera, _shader);
        }

        /// <summary>
        /// Sets the scene.
        /// </summary>
        /// <param name="camera">The camera.</param>
        /// <param name="shader">The shader.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetScene(ICamera camera, IShader shader)
        {
            if (camera == null || shader == null)
                throw new ArgumentNullException();
            
            shader.Bind();
            shader.SetUniform(_shaderSettings.ViewProjectionUniform, true, camera.ViewProjectionMatrix);
        }

        /// <summary>
        /// Draws the specified figure.
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <param name="vertexArray">The vertex array.</param>
        /// <param name="transform">The transform.</param>
        public void Draw(IShader shader, IVertexArray vertexArray, in Matrix4 transform)
        {
            if (shader == null || vertexArray == null)
                throw new ArgumentNullException();

            shader.Bind();
            shader.SetUniform(_shaderSettings.TransformUniform, false, transform);

            DrawIndexed(vertexArray);
        }
        
        /// <summary>
        /// Draws the specified colored square.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="size">The size.</param>
        /// <param name="color">The color.</param>
        public void Draw(in Vector2 position, in Vector2 size, in Color color)
        {
            var (r, g, b, a) = color.ToNormalized();
            var transform = Matrix4.Translated(position) * Matrix4.Scaled(size);
            _defaultTexture.Bind();

            _shader.SetUniform(_shaderSettings.TransformUniform, true, transform);
            _shader.SetUniform(_shaderSettings.TilingFactorUniform, 1.0f);
            _shader.SetUniform(_shaderSettings.ColorUniform, r, g, b, a);

            DrawIndexed(_vertexArray);
        }
        
        /// <summary>
        /// Draws the specified texture.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="size">The size.</param>
        /// <param name="texture">The texture.</param>
        /// <param name="tilingFactor">The tiling factor.</param>
        public void Draw(in Vector2 position, in Vector2 size, ITexture texture, float tilingFactor = 1.0f)
        {
            var transform = Matrix4.Translated(position) * Matrix4.Scaled(size);
            texture.Bind();

            _shader.SetUniform(_shaderSettings.TransformUniform, true, transform);
            _shader.SetUniform(_shaderSettings.TilingFactorUniform, tilingFactor);
            _shader.SetUniform(_shaderSettings.ColorUniform, new Vector4(1));

            DrawIndexed(_vertexArray);
        }
        
        /// <summary>
        /// Draws the specified sprite.
        /// </summary>
        /// <param name="sprite">The sprite.</param>
        /// <param name="tilingFactor">The tiling factor.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Draw(Sprite sprite, float tilingFactor = 1.0f)
        {
            if (sprite == null)
                throw new ArgumentNullException();

            var transform = Matrix4.Translated(sprite.Position) * Matrix4.Scaled(sprite.Size);
            sprite.Texture.Bind();

            _shader.SetUniform(_shaderSettings.TransformUniform, true, transform);
            _shader.SetUniform(_shaderSettings.TilingFactorUniform, tilingFactor);
            _shader.SetUniform(_shaderSettings.ColorUniform, new Vector4(1));

            DrawIndexed(_vertexArray);
        }

        /// <summary>
        /// Draws the elements.
        /// </summary>
        /// <param name="vertexArray">The vertex array.</param>
        private static void DrawIndexed(IVertexArray vertexArray)
        {
            vertexArray.Bind();
            Gl.DrawElements(
                PrimitiveType.Triangles,
                vertexArray.IndexBuffer.Count,
                DrawElementsType.UnsignedInt,
                null);
        }
    }
}