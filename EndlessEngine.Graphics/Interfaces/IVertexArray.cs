namespace EndlessEngine.Graphics.Interfaces
{
    public interface IVertexArray
    {
        void Add(IVertexBuffer vertexBuffer);
        void Add(IIndexBuffer indexBuffer);
        void Bind();
        void Unbind();

        IIndexBuffer IndexBuffer { get; }
    }
}