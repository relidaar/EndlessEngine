using System.Collections.Generic;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IVertexArray
    {
        IEnumerable<IVertexBuffer> VertexBuffers { get; }
        IIndexBuffer IndexBuffer { get; }
        void Add(IVertexBuffer vertexBuffer);
        void Add(IIndexBuffer indexBuffer);
        void Bind();
        void Unbind();
    }
}