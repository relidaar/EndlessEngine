using System;
using System.Collections.Generic;
using System.Text;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics
{
    public class OpenGLIndexBuffer : IIndexBuffer, IDisposable
    {
        public int[] Indices { get; }
        private readonly uint _id;

        public OpenGLIndexBuffer(int[] indices)
        {
            Indices = indices;
            var size = (uint)(indices.Length * sizeof(int));

            _id = Gl.GenBuffer();
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, _id);
            Gl.BufferData(BufferTarget.ElementArrayBuffer, size, indices, BufferUsage.StaticDraw);
        }

        public void Bind() =>
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, _id);

        public void Unbind() =>
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

        public void Dispose() =>
            Gl.DeleteBuffers(_id);
    }
}
