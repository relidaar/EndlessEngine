namespace EndlessEngine.Graphics.Interfaces
{
    public interface IGraphicsFactory
    {
        IVertexBuffer CreateVertexBuffer(params float[] vertices);
        IIndexBuffer CreateIndexBuffer(params int[] indices);
        IVertexArray CreateVertexArray();
        IBufferLayout CreateBufferLayout(params BufferElement[] elements);
        
        IWindow CreateWindow(in WindowProperties properties, in GraphicsSettings graphicsSettings);
        IWindow CreateWindow(in WindowProperties properties);
        IWindow CreateWindow(int width, int height, string title, in GraphicsSettings graphicsSettings);
        IWindow CreateWindow(int width, int height, string title);
        
        IRenderer CreateRenderer(in ShaderSettings shaderSettings);
        IRenderer CreateRenderer();
        
        IShader CreateShader(string name, string vertexShaderPath, string fragmentShaderPath);
        IShaderLibrary CreateShaderLibrary();
        
        ITexture CreateTexture(string path, in TextureData textureData);
        ITexture CreateTexture(int width, int height, object data, in TextureData textureData);
    }
}