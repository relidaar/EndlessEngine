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

        public IShader CreateShader(string name, string vertexShaderPath, string fragmentShaderPath)
        {
            return new OpenGLShader(name, vertexShaderPath, fragmentShaderPath);
        }

        public IShaderLibrary CreateShaderLibrary()
        {
            return new OpenGLShaderLibrary();
        }

        public ITexture CreateTexture(string path)
        {
            return new OpenGLTexture(path);
        }
    }
}