using System.IO;
using System.Linq;
using EndlessEngine.Graphics;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Graphics.OpenGL;

namespace EndlessEngine.Sandbox
{
    internal class Program
    {
        private static readonly IGraphicsFactory Graphics = new OpenGLGraphicsFactory();

        private static void Main(string[] args)
        {
            var props = new WindowProperties
            {
                Width = 800,
                Height = 600,
                Title = "EndlessEngine"
            };

            using var window = Graphics.CreateWindow(props);
            var renderer = Graphics.CreateRenderer();
            renderer.Init();

            var vertices = new[]
            {
                -0.5f, -0.5f, 0.0f, 0.0f, 0.0f,
                0.5f, -0.5f, 0.0f, 1.0f, 0.0f,
                0.5f, 0.5f, 0.0f, 1.0f, 1.0f,
                -0.5f, 0.5f, 0.0f, 0.0f, 1.0f
            };
            var indices = new[] {0, 1, 2, 2, 3, 0};

            var vertexArray = Graphics.CreateVertexArray();

            var vertexBuffer = Graphics.CreateVertexBuffer(vertices);
            vertexBuffer.Layout = Graphics.CreateBufferLayout(
                new BufferElement(ShaderDataType.Float3, "aPosition"),
                new BufferElement(ShaderDataType.Float2, "TextureCoordinates"));

            vertexBuffer.Bind();

            var indexBuffer = Graphics.CreateIndexBuffer(indices);
            indexBuffer.Bind();

            vertexArray.Add(vertexBuffer);
            vertexArray.Add(indexBuffer);

            var shader = Graphics.CreateShader("resources/shaders/vertex.glsl", "resources/shaders/fragment.glsl");
            var texture = Graphics.CreateTexture("resources/images/test.jpg");

            while (window.IsOpen)
            {
                renderer.SetClearColor(0.1f, 0.1f, 0.1f, 1);
                renderer.Clear();

                shader.Bind();
                vertexArray.Bind();
                texture.Bind();
                shader.SetUniform("uTexture", 0);

                renderer.DrawIndexed(vertexArray);

                window.Display();
            }
        }
    }
}