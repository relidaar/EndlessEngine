using System;
using System.Linq;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Graphics.OpenGL;
using OpenGL;
using Xunit;

namespace EndlessEngine.Graphics.Test.OpenGLTests
{
    public class OpenGLVertexArrayTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void AddVertexBuffer(int count)
        {
            IVertexArray vertexArray = new OpenGLVertexArray();
            for (int i = 0; i < count; i++)
            {
                IVertexBuffer vertexBuffer = new OpenGLVertexBuffer(new float[] {0, 0})
                {
                    Layout = new OpenGLBufferLayout(
                        new BufferElement(ShaderDataType.Float2, "TestsBuffer")
                        )
                };
                vertexArray.Add(vertexBuffer);
            }
            
            Assert.NotNull(vertexArray.VertexBuffers);
            Assert.Equal(count, vertexArray.VertexBuffers.Count());
        }

        [Fact]
        public void AddVertexBufferWithNullLayout()
        {
            IVertexArray vertexArray = new OpenGLVertexArray();
            IVertexBuffer vertexBuffer = new OpenGLVertexBuffer(new float[0]);

            Assert.Throws<ArgumentNullException>(() => 
                vertexArray.Add(vertexBuffer));
        }
        
        [Fact]
        public void AddNullVertexBuffer()
        {
            IVertexArray vertexArray = new OpenGLVertexArray();
            Assert.Throws<ArgumentNullException>(() => 
                vertexArray.Add((IVertexBuffer) null));
        }
        
        [Fact]
        public void AddIndexBuffer()
        {
            IVertexArray vertexArray = new OpenGLVertexArray();
            IIndexBuffer indexBuffer = new OpenGLIndexBuffer(new int[0]);
            vertexArray.Add(indexBuffer);
            
            Assert.NotNull(vertexArray.IndexBuffer);
        }
        
        [Fact]
        public void AddNullIndexBuffer()
        {
            IVertexArray vertexArray = new OpenGLVertexArray();
            Assert.Throws<ArgumentNullException>(() => 
                vertexArray.Add((IIndexBuffer) null));
        }

        [Theory]
        [InlineData(ShaderDataType.Float, VertexAttribType.Float)]
        [InlineData(ShaderDataType.Float2, VertexAttribType.Float)]
        [InlineData(ShaderDataType.Float3, VertexAttribType.Float)]
        [InlineData(ShaderDataType.Float4, VertexAttribType.Float)]
        [InlineData(ShaderDataType.Mat3, VertexAttribType.Float)]
        [InlineData(ShaderDataType.Mat4, VertexAttribType.Float)]
        
        [InlineData(ShaderDataType.Int, VertexAttribType.Int)]
        [InlineData(ShaderDataType.Int2, VertexAttribType.Int)]
        [InlineData(ShaderDataType.Int3, VertexAttribType.Int)]
        [InlineData(ShaderDataType.Int4, VertexAttribType.Int)]
        [InlineData(ShaderDataType.Bool, VertexAttribType.Byte)]
        public void ConvertShaderDataTypeToOpenGL(ShaderDataType type, VertexAttribType openGlType)
        {
            Assert.Equal(openGlType, 
                OpenGLVertexArray.ToOpenGLDataType(type));
        }
    }
}