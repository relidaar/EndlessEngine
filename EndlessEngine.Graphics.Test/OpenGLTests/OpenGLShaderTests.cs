using System;
using System.IO;
using EndlessEngine.Graphics.OpenGL;
using Xunit;

namespace EndlessEngine.Graphics.Test.OpenGLTests
{
    public class OpenGLShaderTests
    {
        [Fact]
        public void CreateWithNullReferenceParameters()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader(null, "", ""));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader("", null, ""));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader("", "", null));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader(null, null, ""));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader("", null, null));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader(null, "", null));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader(null, null, null));
        }

        [Fact]
        public void CreateWithEmptyStringParameters()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader("", "path1", "path2"));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader("test", "", "path2"));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader("test", "path1", ""));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader("test", "", ""));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader("", "path1", ""));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader("", "", "path2"));
            
            Assert.Throws<ArgumentNullException>(() => 
                new OpenGLShader("", "", ""));
        }

        [Fact]
        public void CreateWithNonexistentFilepath()
        {
            Assert.Throws<FileNotFoundException>(() => 
                new OpenGLShader("test", "path1", "path2"));
        }
    }
}