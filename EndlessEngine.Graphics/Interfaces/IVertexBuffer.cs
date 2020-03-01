namespace EndlessEngine.Graphics.Interfaces
{
    public interface IVertexBuffer
    {
        IBufferLayout Layout { get; set; }
        void Bind();
        void Unbind();
    }
}