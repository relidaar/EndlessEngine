using System;
using System.Linq;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Graphics.OpenGL;
using Xunit;

namespace EndlessEngine.Graphics.Test.OpenGLTests
{
    public class OpenGLBufferLayoutTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void CreateBufferLayout(int count)
        {
            const ShaderDataType type = ShaderDataType.Float;
            var typeSize = BufferElement.ShaderDataTypeSize(type);
            
            var bufferElements = new BufferElement[count];
            for (int i = 0; i < count; i++) 
                bufferElements[i] = new BufferElement(ShaderDataType.Float, "Test");
            
            IBufferLayout bufferLayout = new OpenGLBufferLayout(bufferElements);
            
            Assert.NotNull(bufferLayout.Elements);
            Assert.Equal(count, bufferLayout.Elements.Count());
            Assert.Equal(count * typeSize, bufferLayout.Stride);
        }

        [Fact]
        public void CreateBufferLayoutWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new OpenGLBufferLayout(null));
        }
    }
}