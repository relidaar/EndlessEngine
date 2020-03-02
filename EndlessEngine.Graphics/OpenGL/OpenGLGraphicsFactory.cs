using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLGraphicsFactory : IGraphicsFactory
    {
        public IVertexBuffer CreateVertexBuffer(params float[] vertices)
        {
            return new OpenGLVertexBuffer(vertices);
        }

        public IIndexBuffer CreateIndexBuffer(params int[] indices)
        {
            return new OpenGLIndexBuffer(indices);
        }

        public IVertexArray CreateVertexArray()
        {
            return new OpenGLVertexArray();
        }

        public IBufferLayout CreateBufferLayout(params BufferElement[] elements)
        {
            return new OpenGLBufferLayout(elements);
        }

        public IWindow CreateWindow(in WindowProperties properties)
        {
            return new OpenGLWindow(properties);
        }

        public IRenderer CreateRenderer()
        {
            return new OpenGLRenderer();
        }

        public IShader CreateShader(string[] vertexSource, string[] fragmentSource)
        {
            return new OpenGLShader(vertexSource, fragmentSource);
        }
    }
}