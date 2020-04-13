﻿using System;
using System.IO;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Math;
using Newtonsoft.Json;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLRenderer : IRenderer
    {
        private readonly IGraphicsFactory _factory;
        private readonly ShaderSettings _shaderSettings;

        private ITexture _defaultTexture;
        private IShader _shader;
        private IVertexArray _vertexArray;

        public OpenGLRenderer(IGraphicsFactory factory, in ShaderSettings shaderSettings)
        {
            _factory = factory;
            _shaderSettings = shaderSettings;
        }

        public OpenGLRenderer(IGraphicsFactory factory)
        {
            _factory = factory;
            
            using (var r = new StreamReader(Paths.ShaderSettingsPath))
            {
                var json = r.ReadToEnd();
                _shaderSettings = JsonConvert.DeserializeObject<ShaderSettings>(json);
            }
        }

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

        public void UseDefaultShader()
        {
            _shader.Bind();
        }

        public void Clear()
        {
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void SetClearColor(in Color color)
        {
            var (r, g, b, a) = color.ToNormalized();
            Gl.ClearColor(r, g, b, a);
        }

        public void SetClearColor(int r, int g, int b, int a)
        {
            var (nR, nG, nB, nA) = Color.Normalize(r, g, b, a);
            Gl.ClearColor(nR, nG, nB, nA);
        }

        public void SetClearColor(float r, float g, float b, float a)
        {
            Gl.ClearColor(r, g, b, a);
        }

        public void SetScene(ICamera camera)
        {
            SetScene(camera, _shader);
        }

        public void SetScene(ICamera camera, IShader shader)
        {
            if (camera == null || shader == null)
                throw new ArgumentNullException();
            
            shader.Bind();
            shader.SetUniform(_shaderSettings.ViewProjectionUniform, true, camera.ViewProjectionMatrix);
        }

        public void Draw(IShader shader, IVertexArray vertexArray, in Matrix4 transform)
        {
            if (shader == null || vertexArray == null)
                throw new ArgumentNullException();

            shader.Bind();
            shader.SetUniform(_shaderSettings.TransformUniform, false, transform);

            DrawIndexed(vertexArray);
        }

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

        public void Draw(in Vector2 position, in Vector2 size, ITexture texture, float tilingFactor = 1.0f)
        {
            var transform = Matrix4.Translated(position) * Matrix4.Scaled(size);
            texture.Bind();

            _shader.SetUniform(_shaderSettings.TransformUniform, true, transform);
            _shader.SetUniform(_shaderSettings.TilingFactorUniform, tilingFactor);
            _shader.SetUniform(_shaderSettings.ColorUniform, new Vector4(1));

            DrawIndexed(_vertexArray);
        }

        public void Draw(Sprite sprite, float tilingFactor = 1.0f)
        {
            var transform = Matrix4.Translated(sprite.Position) * Matrix4.Scaled(sprite.Size);
            sprite.Texture.Bind();

            _shader.SetUniform(_shaderSettings.TransformUniform, true, transform);
            _shader.SetUniform(_shaderSettings.TilingFactorUniform, tilingFactor);
            _shader.SetUniform(_shaderSettings.ColorUniform, new Vector4(1));

            DrawIndexed(_vertexArray);
        }

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