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

        public IWindow CreateWindow(in WindowProperties properties, in GraphicsSettings graphicsSettings)
        {
            return new OpenGLWindow(properties, graphicsSettings);
        }

        public IWindow CreateWindow(in WindowProperties properties)
        {
            return new OpenGLWindow(properties);
        }

        public IWindow CreateWindow(int width, int height, string title, in GraphicsSettings graphicsSettings)
        {
            return new OpenGLWindow(width, height, title, graphicsSettings);
        }

        public IWindow CreateWindow(int width, int height, string title)
        {
            return new OpenGLWindow(width, height, title);
        }

        public IRenderer CreateRenderer(in ShaderSettings shaderSettings)
        {
            return new OpenGLRenderer(this, shaderSettings);
        }

        public IRenderer CreateRenderer()
        {
            return new OpenGLRenderer(this);
        }

        public IShader CreateShader(string name, string vertexShaderPath, string fragmentShaderPath)
        {
            return new OpenGLShader(name, vertexShaderPath, fragmentShaderPath);
        }

        public IShaderLibrary CreateShaderLibrary()
        {
            return new OpenGLShaderLibrary();
        }

        public ITexture CreateTexture(string path, in TextureData textureData)
        {
            return new OpenGLTexture(path, textureData);
        }

        public ITexture CreateTexture(uint width, uint height, object data, in TextureData textureData)
        {
            return new OpenGLTexture(width, height, data, textureData);
        }
    }
}