using System.IO;
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
            var vertexSrc = File.ReadAllLines("resources/shaders/vertex.sh");
            var fragmentSrc = File.ReadAllLines("resources/shaders/fragment.sh");
            var shader = Graphics.CreateShader(vertexSrc, fragmentSrc);

            var props = new WindowProperties
            {
                Width = 800,
                Height = 600,
                Title = "EndlessEngine"
            };

            using var window = Graphics.CreateWindow(props);
            var renderer = Graphics.CreateRenderer();

            var vertices = new[]
            {
                -0.5f, -0.5f, 0.0f, 0.0f, 0.0f,
                 0.5f, -0.5f, 0.0f, 1.0f, 0.0f,
                 0.5f, 0.5f, 0.0f, 0.0f, 1.0f,
                -0.5f, 0.5f, 0.0f, 0.0f, 1.0f,
            };
            var indices = new[] {0, 1, 2, 4};
            
            var vertexArray = Graphics.CreateVertexArray();

            var vertexBuffer = Graphics.CreateVertexBuffer(vertices);
            vertexBuffer.Layout = Graphics.CreateBufferLayout(
                new BufferElement(ShaderDataType.Float3, "aPosition"),
                new BufferElement(ShaderDataType.Float2, "aTexture"));

            vertexBuffer.Bind();

            var indexBuffer = Graphics.CreateIndexBuffer(indices);
            indexBuffer.Bind();

            vertexArray.Add(vertexBuffer);
            vertexArray.Add(indexBuffer);

            var texture = Graphics.CreateTexture("resources/images/Solya.jpg");
            shader.SetUniform("uTexture", 0);

            while (window.IsOpen)
            {
                renderer.SetClearColor(0.1f, 0.1f, 0.1f, 1);
                renderer.Clear();

                shader.Bind();
                vertexArray.Bind();
                texture.Bind();

                renderer.DrawIndexed(vertexArray);

                window.Display();
            }
        }
    }
}