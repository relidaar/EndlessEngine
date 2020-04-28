using System;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Graphics.OpenGL;
using Xunit;

namespace EndlessEngine.Graphics.Test.OpenGLTests
{
    public class OpenGLWindowTests
    {
        [Fact]
        public void CreateWithNegativeValues()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new OpenGLWindow(-1, -1, "Test", new GraphicsSettings()));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateWithIncorrectString(string title)
        {
            Assert.Throws<ArgumentNullException>(() =>
                new OpenGLWindow(0, 0, title, new GraphicsSettings()));
        }
    }
}