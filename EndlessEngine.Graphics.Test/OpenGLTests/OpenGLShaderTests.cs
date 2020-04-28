using System;
using System.IO;
using EndlessEngine.Graphics.OpenGL;
using Xunit;

namespace EndlessEngine.Graphics.Test.OpenGLTests
{
    public class OpenGLShaderTests
    {
        [Theory]
        [InlineData(null, "test", "test")]
        [InlineData("test", null, "test")]
        [InlineData("test", "test", null)]
        
        [InlineData(null, null, "test")]
        [InlineData(null, "test", null)]
        [InlineData("test", null, null)]
        
        [InlineData(null, null, null)]
        public void CreateWithNullReferenceParameters(string name, string path1, string path2)
        {
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader(name, path1, path2));
        }
        
        [Theory]
        [InlineData("", "test", "test")]
        [InlineData("test", "", "test")]
        [InlineData("test", "test", "")]

        [InlineData("", "", "test")]
        [InlineData("", "test", "")]
        [InlineData("test", "", "")]

        [InlineData("", "", "")]
        public void CreateWithEmptyStringParameters(string name, string path1, string path2)
        {
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader(name, path1, path2));
        }

        [Theory]
        [InlineData(" ", "test", "test")]
        [InlineData("test", " ", "test")]
        [InlineData("test", "test", " ")]

        [InlineData(" ", " ", "test")]
        [InlineData(" ", "test", " ")]
        [InlineData("test", " ", " ")]

        [InlineData(" ", " ", " ")]
        public void CreateWithWhitespaceStringParameters(string name, string path1, string path2)
        {
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader(name, path1, path2));
        }

        [Fact]
        public void CreateWithNonexistentFilepath()
        {
            Assert.Throws<FileNotFoundException>(() => 
                new OpenGLShader("test", "path1", "path2"));
        }
    }
}