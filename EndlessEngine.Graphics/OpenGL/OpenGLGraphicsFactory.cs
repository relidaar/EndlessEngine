using System.Collections.Generic;
using System.Text;
using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLGraphicsFactory : IGraphicsFactory
    {
        public IVertexBuffer CreateVertexBuffer(params float[] vertices) => 
            new OpenGLVertexBuffer(vertices);

        public IIndexBuffer CreateIndexBuffer(params int[] indices) => 
            new OpenGLIndexBuffer(indices);

        public IVertexArray CreateVertexArray() => 
            new OpenGLVertexArray();

        public IBufferLayout CreateBufferLayout(params BufferElement[] elements) => 
            new OpenGLBufferLayout(elements);

        public IWindow CreateWindow(in WindowProperties properties) => 
            new OpenGLWindow(properties);

        public IRenderer CreateRenderer() => 
            new OpenGLRenderer();

        public IShader CreateShader(string[] vertexSource, string[] fragmentSource) => 
            new OpenGLShader(vertexSource, fragmentSource);
    }
}
