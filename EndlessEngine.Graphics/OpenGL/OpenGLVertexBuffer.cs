using System;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLVertexBuffer : IVertexBuffer, IDisposable
    {
        public float[] Vertices { get; }
        public IBufferLayout Layout { get; set; }
        
        private readonly uint _id;

        public OpenGLVertexBuffer(float[] vertices)
        {
            Vertices = vertices;
            var size = (uint)(vertices.Length * sizeof(float));

            _id = Gl.GenBuffer();
            Gl.BindBuffer(BufferTarget.ArrayBuffer, _id);
            Gl.BufferData(BufferTarget.ArrayBuffer, size, vertices, BufferUsage.StaticDraw);
        }

        public void Bind() =>
            Gl.BindBuffer(BufferTarget.ArrayBuffer, _id);

        public void Unbind() =>
            Gl.BindBuffer(BufferTarget.ArrayBuffer, 0);

        public void Dispose() =>
            Gl.DeleteBuffers(_id);
    }
}
