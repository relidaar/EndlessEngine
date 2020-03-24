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

        public IWindow CreateWindow(in WindowProperties properties, GraphicsSettings graphicsSettings)
        {
            return new OpenGLWindow(properties, graphicsSettings);
        }

        public IRenderer CreateRenderer(ShaderSettings shaderSettings)
        {
            return new OpenGLRenderer(this, shaderSettings);
        }

        public IShader CreateShader(string name, string vertexShaderPath, string fragmentShaderPath)
        {
            return new OpenGLShader(name, vertexShaderPath, fragmentShaderPath);
        }

        public IShaderLibrary CreateShaderLibrary()
        {
            return new OpenGLShaderLibrary();
        }

        public ITexture CreateTexture(string path, TextureData textureData)
        {
            return new OpenGLTexture(path, textureData);
        }

        public ITexture CreateTexture(uint width, uint height, object data, TextureData textureData)
        {
            return new OpenGLTexture(width, height, data, textureData);
        }
    }
}