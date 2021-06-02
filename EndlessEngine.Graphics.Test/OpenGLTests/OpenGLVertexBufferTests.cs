using System;
using EndlessEngine.Graphics.OpenGL;
using Xunit;

namespace EndlessEngine.Graphics.Test.OpenGLTests
{
    public class OpenGLVertexBufferTests
    {
        [Fact]
        public void CreateVertexBufferWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLVertexBuffer(null));
        }
    }
}