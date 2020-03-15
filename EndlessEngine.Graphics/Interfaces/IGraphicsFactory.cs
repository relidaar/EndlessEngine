using EndlessEngine.Graphics.DataTypes;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IGraphicsFactory
    {
        IVertexBuffer CreateVertexBuffer(params float[] vertices);
        IIndexBuffer CreateIndexBuffer(params int[] indices);
        IVertexArray CreateVertexArray();
        IBufferLayout CreateBufferLayout(params BufferElement[] elements);
        IWindow CreateWindow(in WindowProperties properties);
        IRenderer CreateRenderer();
        IShader CreateShader(string name, string vertexShaderPath, string fragmentShaderPath);
        IShaderLibrary CreateShaderLibrary();
        ITexture CreateTexture(string path);
        ITexture CreateTexture(uint width, uint height, object data, TextureFormat format);
    }
}