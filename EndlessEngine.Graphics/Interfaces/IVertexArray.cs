namespace EndlessEngine.Graphics.Interfaces
{
    public interface IVertexArray
    {
        IIndexBuffer IndexBuffer { get; }
        void Add(IVertexBuffer vertexBuffer);
        void Add(IIndexBuffer indexBuffer);
        void Bind();
        void Unbind();
    }
}