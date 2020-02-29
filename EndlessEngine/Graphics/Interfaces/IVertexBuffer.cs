namespace EndlessEngine.Graphics.Interfaces
{
    public interface IVertexBuffer : IBuffer
    {
        IBufferLayout Layout { get; set; }
    }
}