using System.Collections.Generic;
using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLBufferLayout : IBufferLayout
    {
        private readonly BufferElement[] _elements;

        public OpenGLBufferLayout(params BufferElement[] elements)
        {
            _elements = elements;
            CalculateOffsetAndStride();
        }

        public IEnumerable<BufferElement> Elements => _elements;
        public int Stride { get; private set; }

        private void CalculateOffsetAndStride()
        {
            var offset = 0;
            Stride = 0;

            for (var i = 0; i < _elements.Length; i++)
            {
                var element = _elements[i];
                element.Offset = offset;
                _elements[i] = element;

                offset += element.Size;
                Stride += element.Size;
            }
        }
    }
}