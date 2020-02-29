namespace EndlessEngine.Graphics.Interfaces
{
    public interface IVertexArray : IBuffer
    {
        void Add(IVertexBuffer vertexBuffer);
        void Add(IIndexBuffer indexBuffer);
    }
}