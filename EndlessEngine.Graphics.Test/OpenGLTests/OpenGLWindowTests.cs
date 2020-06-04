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
                new OpenGLWindow(-1, -1, "Test", false, new GraphicsSettings()));
            
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new OpenGLWindow(-1, -1, "Test", false));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateWithIncorrectString(string title)
        {
            Assert.Throws<ArgumentNullException>(() =>
                new OpenGLWindow(0, 0, title, false, new GraphicsSettings()));
            
            Assert.Throws<ArgumentNullException>(() =>
                new OpenGLWindow(0, 0, title, false));
        }
    }
}