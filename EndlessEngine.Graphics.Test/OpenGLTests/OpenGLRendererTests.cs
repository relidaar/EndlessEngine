using System;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Graphics.OpenGL;
using EndlessEngine.Math;
using Xunit;

namespace EndlessEngine.Graphics.Test.OpenGLTests
{
    public class OpenGLRendererTests
    {
        [Fact]
        public void CreateWithNullReferenceFactory()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new OpenGLRenderer(null, new ShaderSettings()));
            
            Assert.Throws<ArgumentNullException>(() =>
                new OpenGLRenderer(null));
        }

        [Fact]
        public void InitializeWithNullReferences()
        {
            IRenderer renderer = new OpenGLRenderer(new OpenGLGraphicsFactory(), new ShaderSettings());

            Assert.Throws<ArgumentNullException>(() =>
                renderer.Init(null, null));
        }

        [Fact]
        public void SetSceneWithNullReferences()
        {
            IRenderer renderer = new OpenGLRenderer(new OpenGLGraphicsFactory(), new ShaderSettings());

            Assert.Throws<ArgumentNullException>(() => 
                renderer.SetScene(new OrthographicCamera(0, 0), null));
            
            Assert.Throws<ArgumentNullException>(() => 
                renderer.SetScene(null, null));
            
            Assert.Throws<ArgumentNullException>(() => 
                renderer.SetScene(null));
        }
        
        [Fact]
        public void DrawWithNullReferences()
        {
            IRenderer renderer = new OpenGLRenderer(new OpenGLGraphicsFactory(), new ShaderSettings());

            Assert.Throws<ArgumentNullException>(() => 
                renderer.Draw(null, null, Matrix4.Identity));
            
            Assert.Throws<ArgumentNullException>(() => 
                renderer.Draw(null, new OpenGLVertexArray(), Matrix4.Identity));
            
            Assert.Throws<ArgumentNullException>(() => 
                renderer.Draw(null));
        }
    }
}