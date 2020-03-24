using System.Collections.Generic;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IBufferLayout
    {
        IEnumerable<BufferElement> Elements { get; }
        int Stride { get; }
    }
}