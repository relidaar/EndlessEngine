using System;
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
        private readonly GraphicsData _graphicsData;

        private ITexture _defaultTexture;
        private IShader _shader;
        private IVertexArray _vertexArray;

        public OpenGLRenderer(IGraphicsFactory factory)
        {
            _factory = factory;

            using (var r = new StreamReader("resources/graphics_data.json"))
            {
                var json = r.ReadToEnd();
                _graphicsData = JsonConvert.DeserializeObject<GraphicsData>(json);
            }
        }

        public void Init(IShader shader, IVertexArray vertexArray)
        {
            if (shader == null || vertexArray == null)
                throw new ArgumentNullException();

            _shader = shader;
            _shader.Bind();

            _vertexArray = vertexArray;

            _defaultTexture = new OpenGLTexture(1, 1, 0xffffffff, TextureData.Default);

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
                new BufferElement(ShaderDataType.Float2, _graphicsData.VerticesPosition),
                new BufferElement(ShaderDataType.Float2, _graphicsData.TextureCoordinates)
            );
            vertexBuffer.Bind();
            vertexArray.Add(vertexBuffer);

            var indices = new[] {0, 1, 2, 2, 3, 0};
            var indexBuffer = _factory.CreateIndexBuffer(indices);
            indexBuffer.Bind();
            vertexArray.Add(indexBuffer);

            var shader = shaderLibrary.Load(
                _graphicsData.ShaderName,
                _graphicsData.VertexShaderPath,
                _graphicsData.FragmentShaderPath
            );
            shader.Bind();
            shader.SetUniform(_graphicsData.TextureUniform, 0);

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

        public void SetClearColor(Color color)
        {
            var (r, g, b, a) = color.ToNormalized();
            Gl.ClearColor(r, g, b, a);
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
            shader.SetUniform(_graphicsData.ViewProjectionUniform, true, camera.ViewProjectionMatrix);
        }

        public void Draw(IShader shader, IVertexArray vertexArray, Matrix4 transform)
        {
            if (shader == null || vertexArray == null)
                throw new ArgumentNullException();

            shader.Bind();
            shader.SetUniform(_graphicsData.TransformUniform, false, transform);

            DrawIndexed(vertexArray);
        }

        public void Draw(Vector2 position, Vector2 size, Color color)
        {
            var (r, g, b, a) = color.ToNormalized();
            var transform = Matrix4.Translated(position) * Matrix4.Scaled(size);
            _defaultTexture.Bind();

            _shader.SetUniform(_graphicsData.TransformUniform, true, transform);
            _shader.SetUniform(_graphicsData.TilingFactorUniform, 1.0f);
            _shader.SetUniform(_graphicsData.ColorUniform, r, g, b, a);

            DrawIndexed(_vertexArray);
        }

        public void Draw(Vector2 position, Vector2 size, ITexture texture, float tilingFactor = 1.0f)
        {
            var transform = Matrix4.Translated(position) * Matrix4.Scaled(size);
            texture.Bind();

            _shader.SetUniform(_graphicsData.TransformUniform, true, transform);
            _shader.SetUniform(_graphicsData.TilingFactorUniform, tilingFactor);
            _shader.SetUniform(_graphicsData.ColorUniform, new Vector4(1));

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