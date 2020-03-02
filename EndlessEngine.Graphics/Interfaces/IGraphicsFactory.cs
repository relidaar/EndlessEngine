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
        IShader CreateShader(string[] vertexSource, string[] fragmentSource);
        ITexture CreateTexture(string path);
    }
}