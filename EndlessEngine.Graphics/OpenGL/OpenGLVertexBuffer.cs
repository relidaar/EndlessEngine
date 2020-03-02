using System;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLVertexBuffer : IVertexBuffer, IDisposable
    {
        private readonly uint id;

        public OpenGLVertexBuffer(float[] vertices)
        {
            Vertices = vertices;
            var size = (uint) (vertices.Length * sizeof(float));

            id = Gl.GenBuffer();
            Gl.BindBuffer(BufferTarget.ArrayBuffer, id);
            Gl.BufferData(BufferTarget.ArrayBuffer, size, vertices, BufferUsage.StaticDraw);
        }

        public float[] Vertices { get; }

        public void Dispose()
        {
            Gl.DeleteBuffers(id);
        }

        public IBufferLayout Layout { get; set; }

        public void Bind()
        {
            Gl.BindBuffer(BufferTarget.ArrayBuffer, id);
        }

        public void Unbind()
        {
            Gl.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
    }
}