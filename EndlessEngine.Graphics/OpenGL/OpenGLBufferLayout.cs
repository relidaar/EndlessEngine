using System.Collections.Generic;
using EndlessEngine.Graphics.DataTypes;
using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLBufferLayout : IBufferLayout
    {
        private readonly List<BufferElement> elements;

        public OpenGLBufferLayout(params BufferElement[] elements)
        {
            this.elements = new List<BufferElement>(elements);
            CalculateOffsetAndStride();
        }

        public IEnumerable<BufferElement> Elements => elements;
        public int Stride { get; private set; }

        private void CalculateOffsetAndStride()
        {
            var offset = 0;
            Stride = 0;

            for (var i = 0; i < elements.Count; i++)
            {
                var element = elements[i];
                element.Offset = offset;
                elements[i] = element;

                offset += element.Size;
                Stride += element.Size;
            }
        }
    }
}