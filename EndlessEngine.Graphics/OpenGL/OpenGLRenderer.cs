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

        private IGraphicsFactory _factory = new OpenGLGraphicsFactory();
        
        public void Init(IShader colorShader, IShader textureShader, IVertexArray vertexArray)
        {
            if (colorShader == null || vertexArray == null)
                throw new ArgumentNullException();

            _colorShader = colorShader;
            _vertexArray = vertexArray;

            Gl.Enable(EnableCap.Blend);
            Gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        public void Init()
        {
            _vertexArray = _factory.CreateVertexArray();
            
            var vertices = new[]
            {
                -0.5f, -0.5f,
                0.5f, -0.5f,
                0.5f, 0.5f,
                -0.5f, 0.5f,
            };
                                                                                            
            var vertexBuffer = _factory.CreateVertexBuffer(vertices);
            vertexBuffer.Layout = _factory.CreateBufferLayout(
                new BufferElement(ShaderDataType.Float2, "aPosition"));
            vertexBuffer.Bind();
            _vertexArray.Add(vertexBuffer);

            var indices = new[] {0, 1, 2, 2, 3, 0};
            var indexBuffer = _factory.CreateIndexBuffer(indices);
            indexBuffer.Bind();
            _vertexArray.Add(indexBuffer);

            var shaderLibrary = _factory.CreateShaderLibrary();
            _colorShader = shaderLibrary.Load("DefaultColorShader", "resources/shaders/ColorVertex.glsl",
                "resources/shaders/ColorFragment.glsl");
            _textureShader = shaderLibrary.Load("DefaultTextureShader", "resources/shaders/TextureVertex.glsl",
                "resources/shaders/TextureFragment.glsl");
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