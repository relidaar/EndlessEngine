using System.Collections.Generic;
using EndlessEngine.Graphics.DataTypes;

namespace EndlessEngine.Graphics.Interfaces
{
    public interface IBufferLayout
    {
        IEnumerable<BufferElement> Elements { get; }
        int Stride { get; }
    }
}