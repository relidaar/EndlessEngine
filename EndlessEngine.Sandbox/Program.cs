using EndlessEngine.Graphics;
using EndlessEngine.Graphics.DataTypes;
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

            using (var window = Graphics.CreateWindow(props))
            {
                var vertices = new[]
                {
                    -0.5f, -0.5f,
                     0.5f, -0.5f,
                     0.5f, 0.5f,
                    -0.5f, 0.5f,
                };
                var indices = new[] {0, 1, 2, 2, 3, 0};

                var vertexArray = Graphics.CreateVertexArray();

                var vertexBuffer = Graphics.CreateVertexBuffer(vertices);
                vertexBuffer.Layout = Graphics.CreateBufferLayout(
                    new BufferElement(ShaderDataType.Float2, "aPosition"));

                vertexBuffer.Bind();

                var indexBuffer = Graphics.CreateIndexBuffer(indices);
                indexBuffer.Bind();

                vertexArray.Add(vertexBuffer);
                vertexArray.Add(indexBuffer);

                var shaderLibrary = Graphics.CreateShaderLibrary();
                var shader = shaderLibrary.Load("Test", "resources/shaders/vertex.glsl",
                    "resources/shaders/fragment.glsl");

                var renderer = Graphics.CreateRenderer();
                renderer.Init(shader, vertexArray);
                while (window.IsOpen)
                {
                    renderer.SetClearColor(0.1f, 0.1f, 0.1f, 1);
                    renderer.Clear();

                    renderer.Draw(new Vector2(-1.0f, 0), new Vector2(0.8f, 0.8f), new Color(200, 50, 75));
                    renderer.Draw(new Vector2(0.5f, -0.5f), new Vector2(0.5f, 0.75f), new Color(50, 75, 200));

                    window.Display();
                }
            }
        }
    }
}