using System;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Graphics.OpenGL;
using Xunit;

namespace EndlessEngine.Graphics.Test.OpenGLTests
{
    public class OpenGLIndexBufferTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(1, 2, 3, 4)]
        public void CreateIndexBuffer(params int[] data)
        {
            IIndexBuffer buffer = new OpenGLIndexBuffer(data);
            Assert.Equal(data.Length, buffer.Count);
        }

        [Fact]
        public void CreateIndexBufferWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLIndexBuffer(null));
        }
    }
}