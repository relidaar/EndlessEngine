using System;
using System.IO;
using EndlessEngine.Graphics.OpenGL;
using Xunit;

namespace EndlessEngine.Graphics.Test.OpenGLTests
{
    public class OpenGLTextureTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateWithIncorrectPath(string path)
        {
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLTexture(path, TextureData.Default));
        }
    
        [Fact]
        public void CreateWithNonexistentImage()
        {
            Assert.Throws<FileNotFoundException>(() => 
                new OpenGLTexture("test", TextureData.Default));
        }
        
        [Fact]
        public void CreateWithNullReferenceObject()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLTexture(0, 0, null, TextureData.Default));
        }

        [Fact]
        public void CreateWithNegativeValues()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new OpenGLTexture(-1, -1, new float[1], TextureData.Default));
        }
    }
}