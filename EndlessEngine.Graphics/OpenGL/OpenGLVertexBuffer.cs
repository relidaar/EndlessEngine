using System;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLVertexBuffer : IVertexBuffer, IDisposable
    {
        private readonly uint _id;
        private readonly float[] _vertices;

        public OpenGLVertexBuffer(float[] vertices)
        {
            _vertices = vertices ?? throw new ArgumentNullException();
            var size = (uint) (vertices.Length * sizeof(float));

            _id = Gl.GenBuffer();
            Gl.BindBuffer(BufferTarget.ArrayBuffer, _id);
            Gl.BufferData(BufferTarget.ArrayBuffer, size, vertices, BufferUsage.StaticDraw);
        }

        public void Dispose()
        {
            Gl.DeleteBuffers(_id);
        }

        public IBufferLayout Layout { get; set; }

        public void Bind()
        {
            Gl.BindBuffer(BufferTarget.ArrayBuffer, _id);
        }

        public void Unbind()
        {
            Gl.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
    }
}