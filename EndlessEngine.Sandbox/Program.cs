using System;
using System.Text;
using EndlessEngine.Graphics;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Graphics.OpenGL;
using OpenGL;

namespace EndlessEngine.Sandbox
{
    class Program
    {
        private static readonly IGraphicsFactory _graphics = new OpenGLGraphicsFactory();

        static void Main(string[] args)
        {
            string[] vertexSrc = {
                "#version 330 core\n",
                "layout(location = 0) in vec3 aPosition;\n",
                "layout(location = 1) in vec4 aColor;\n",
                "out vec4 vColor;\n",
                "void main() {\n",
                "	vColor = aColor;\n",
                "	gl_Position = vec4(aPosition, 1.0);\n",
                "}\n"
            };
            string[] fragmentSrc = {
                "#version 330 core\n",
                "layout(location = 0) out vec4 color;\n",
                "in vec4 vColor;\n",
                "void main() {\n",
                "	color = vColor;\n",
                "}\n"
            };

            var props = new WindowProperties
            {
                Width = 800,
                Height = 600,
                Title = "EndlessEngine"
            };

            using var window = _graphics.CreateWindow(props);
            var renderer = _graphics.CreateRenderer();

            var vertices = new[]
            {
                -0.5f, -0.5f, 0.0f, 0.8f, 0.2f, 0.8f, 1.0f,
                0.5f, -0.5f, 0.0f, 0.2f, 0.3f, 0.8f, 1.0f,
                0.0f,  0.5f, 0.0f, 0.8f, 0.8f, 0.2f, 1.0f,
            };

            var shader = _graphics.CreateShader(vertexSrc, fragmentSrc);

            var indices = new[] {0, 1, 2};

            var vertexArray = _graphics.CreateVertexArray();

            var vertexBuffer = _graphics.CreateVertexBuffer(vertices);
            vertexBuffer.Layout = _graphics.CreateBufferLayout(
                new BufferElement(ShaderDataType.Float3, "aPosition"),
                new BufferElement(ShaderDataType.Float4, "aColor"));

            vertexBuffer.Bind();

            var indexBuffer = _graphics.CreateIndexBuffer(indices);
            indexBuffer.Bind();

            vertexArray.Add(vertexBuffer);
            vertexArray.Add(indexBuffer);

            while (window.IsOpen)
            {
                renderer.SetClearColor(0.1f, 0.1f, 0.1f, 1);
                renderer.Clear();

                shader.Bind();
                vertexArray.Bind();

                renderer.DrawIndexed(vertexArray);

                window.Display();
            }
        }
    }
}
