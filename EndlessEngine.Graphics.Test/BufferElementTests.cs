using System;
using Xunit;

namespace EndlessEngine.Graphics.Test
{
    public class BufferElementTests
    {
        [Theory]
        [InlineData(ShaderDataType.Float, 4)]        
        [InlineData(ShaderDataType.Float2, 4 * 2)]
        [InlineData(ShaderDataType.Float3, 4 * 3)]
        [InlineData(ShaderDataType.Float4, 4 * 4)]

        [InlineData(ShaderDataType.Int, 4)]
        [InlineData(ShaderDataType.Int2, 4 * 2)]
        [InlineData(ShaderDataType.Int3, 4 * 3)]
        [InlineData(ShaderDataType.Int4, 4 * 4)]
        
        [InlineData(ShaderDataType.Mat3, 4 * 3 * 3)]
        [InlineData(ShaderDataType.Mat4, 4 * 4 * 4)]
        [InlineData(ShaderDataType.Bool, 1)]
        public void CreateBufferElement(ShaderDataType type, int size)
        {
            var bufferElement = new BufferElement(type, "Test");
            
            Assert.Equal(size, bufferElement.Size);
            Assert.Equal("Test", bufferElement.Name);
            Assert.False(bufferElement.Normalized);
        }

        [Fact]
        public void CreateBufferElementWithNullString()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new BufferElement(ShaderDataType.Float, null)
            );
        }

        [Theory]
        [InlineData(ShaderDataType.Float, 4)]
        [InlineData(ShaderDataType.Float2, 4 * 2)]
        [InlineData(ShaderDataType.Float3, 4 * 3)]
        [InlineData(ShaderDataType.Float4, 4 * 4)]

        [InlineData(ShaderDataType.Int, 4)]
        [InlineData(ShaderDataType.Int2, 4 * 2)]
        [InlineData(ShaderDataType.Int3, 4 * 3)]
        [InlineData(ShaderDataType.Int4, 4 * 4)]

        [InlineData(ShaderDataType.Mat3, 4 * 3 * 3)]
        [InlineData(ShaderDataType.Mat4, 4 * 4 * 4)]
        [InlineData(ShaderDataType.Bool, 1)]
        public void GetShaderDataTypeSize(ShaderDataType type, int size)
        {
            var result = BufferElement.ShaderDataTypeSize(type);
            Assert.Equal(size, result);
        }

        [Theory]
        [InlineData(ShaderDataType.Float, 1)]
        [InlineData(ShaderDataType.Float2, 2)]
        [InlineData(ShaderDataType.Float3, 3)]
        [InlineData(ShaderDataType.Float4, 4)]

        [InlineData(ShaderDataType.Int, 1)]
        [InlineData(ShaderDataType.Int2, 2)]
        [InlineData(ShaderDataType.Int3, 3)]
        [InlineData(ShaderDataType.Int4, 4)]
        
        [InlineData(ShaderDataType.Mat3, 3 * 3)]
        [InlineData(ShaderDataType.Mat4, 4 * 4)]
        [InlineData(ShaderDataType.Bool, 1)]
        public void GetBufferDataCount(ShaderDataType type, int count)
        {
            var result = new BufferElement(type, "Test").GetCount();
            Assert.Equal(count, result);
        }
    }
}