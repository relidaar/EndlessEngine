namespace EndlessEngine.Graphics.Interfaces
{
    public interface IIndexBuffer
    {
        int Count { get; }
        void Bind();
        void Unbind();
    }
}