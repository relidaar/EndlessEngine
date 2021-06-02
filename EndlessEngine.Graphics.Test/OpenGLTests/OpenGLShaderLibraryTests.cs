using System;
using System.Collections.Generic;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Graphics.OpenGL;
using Xunit;

namespace EndlessEngine.Graphics.Test.OpenGLTests
{
    public class OpenGLShaderLibraryTests
    {
        [Fact]
        public void AddNullReferenceShader()
        {
            IShaderLibrary shaderLibrary = new OpenGLShaderLibrary();
            Assert.Throws<ArgumentNullException>(() => 
                shaderLibrary.Add(null));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GetShaderWithNullReferenceString(string name)
        {
            IShaderLibrary shaderLibrary = new OpenGLShaderLibrary();
            Assert.Throws<ArgumentNullException>(() => 
                shaderLibrary.Get(name));
        }
        
        [Theory]
        [InlineData(null, "test", "test")]
        [InlineData("test", null, "test")]
        [InlineData("test", "test", null)]
        
        [InlineData(null, null, "test")]
        [InlineData(null, "test", null)]
        [InlineData("test", null, null)]
        
        [InlineData(null, null, null)]
        public void LoadShaderWithNullReferenceParameters(string name, string path1, string path2)
        {
            IShaderLibrary shaderLibrary = new OpenGLShaderLibrary();
            Assert.Throws<ArgumentNullException>(() => 
                shaderLibrary.Load(name, path1, path2));
        }

        [Theory]
        [InlineData("", "test", "test")]
        [InlineData("test", "", "test")]
        [InlineData("test", "test", "")]

        [InlineData("", "", "test")]
        [InlineData("", "test", "")]
        [InlineData("test", "", "")]

        [InlineData("", "", "")]
        public void LoadShaderWithEmptyStringParameters(string name, string path1, string path2)
        {
            IShaderLibrary shaderLibrary = new OpenGLShaderLibrary();
            Assert.Throws<ArgumentNullException>(() => 
                shaderLibrary.Load(name, path1, path2));
        }

        [Theory]
        [InlineData(" ", "test", "test")]
        [InlineData("test", " ", "test")]
        [InlineData("test", "test", " ")]

        [InlineData(" ", " ", "test")]
        [InlineData(" ", "test", " ")]
        [InlineData("test", " ", " ")]

        [InlineData(" ", " ", " ")]
        public void LoadShaderWithWhitespaceStringParameters(string name, string path1, string path2)
        {
            IShaderLibrary shaderLibrary = new OpenGLShaderLibrary();
            Assert.Throws<ArgumentNullException>(() => 
                shaderLibrary.Load(name, path1, path2));
        }

        [Fact]
        public void GetNonexistentShader()
        {
            IShaderLibrary shaderLibrary = new OpenGLShaderLibrary();
            Assert.Throws<KeyNotFoundException>(() =>
                shaderLibrary.Get("test"));
        }
    }
}