using System;
using EndlessEngine.Graphics.DataTypes;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLRenderer : IRenderer
    {
        private IShader _colorShader;
        private IShader _textureShader;
        private IVertexArray _vertexArray;

        private readonly IGraphicsFactory _factory;

        public OpenGLRenderer(IGraphicsFactory factory)
        {
            _factory = factory;
        }

        public void Init(IShader colorShader, IShader textureShader, IVertexArray vertexArray)
        {
            if (colorShader == null || vertexArray == null)
                throw new ArgumentNullException();

            _colorShader = colorShader;
            _textureShader = textureShader;
            _vertexArray = vertexArray;

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
                 0.5f,  0.5f, 1.0f, 1.0f,
                -0.5f,  0.5f, 0.0f, 1.0f
            };
                                                                                            
            var vertexBuffer = _factory.CreateVertexBuffer(vertices);
            vertexBuffer.Layout = _factory.CreateBufferLayout(
                new BufferElement(ShaderDataType.Float2, "aPosition"),
                new BufferElement(ShaderDataType.Float2, "aTextureCoordinates")
                );
            vertexBuffer.Bind();
            vertexArray.Add(vertexBuffer);

            var indices = new[] {0, 1, 2, 2, 3, 0};
            var indexBuffer = _factory.CreateIndexBuffer(indices);
            indexBuffer.Bind();
            vertexArray.Add(indexBuffer);
            
            var colorShader = shaderLibrary.Load("DefaultColorShader", 
                "assets/shaders/DefaultColorVertex.glsl",
                "assets/shaders/DefaultColorFragment.glsl");
            colorShader.Bind();
            
            var textureShader = shaderLibrary.Load("DefaultTextureShader", 
                "assets/shaders/DefaultTextureVertex.glsl",
                "assets/shaders/DefaultTextureFragment.glsl");
            textureShader.Bind();
            textureShader.SetUniform("uTexture", 0);
            
            Init(colorShader, textureShader, vertexArray);
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

        private static void DrawIndexed(IVertexArray vertexArray)
        {            
            vertexArray.Bind();
            Gl.DrawElements(
                PrimitiveType.Triangles,
                vertexArray.IndexBuffer.Count,
                DrawElementsType.UnsignedInt,
                null);
        }

        public void Draw(IShader shader, IVertexArray vertexArray, Matrix4 transform)
        {
            if (shader == null || vertexArray == null) 
                throw new ArgumentNullException();

            shader.Bind();
            shader.SetUniform("uTransform", false, transform);

            DrawIndexed(vertexArray);
        }

        public void Draw(Vector2 position, Vector2 size, Color color)
        {
            var (r, g, b, a) = color.ToNormalized();
            var transform = Matrix4.Translated(position) * Matrix4.Scaled(size);

            _colorShader.Bind();
            _colorShader.SetUniform("uTransform", true, transform);
            _colorShader.SetUniform("uColor", r, g, b, a);

            DrawIndexed(_vertexArray);
        }

        public void Draw(Vector2 position, Vector2 size, ITexture texture)
        {
            var transform = Matrix4.Translated(position) * Matrix4.Scaled(size);

            _textureShader.Bind();
            _textureShader.SetUniform("uTransform", true, transform);
            texture.Bind();
            
            DrawIndexed(_vertexArray);
        }
    }
}