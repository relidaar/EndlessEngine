using System;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLIndexBuffer : IIndexBuffer, IDisposable
    {
        private readonly uint _id;
        private readonly int[] _indices;

        public OpenGLIndexBuffer(int[] indices)
        {
            _indices = indices;
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

        public int Count => _indices.Length;
    }
}
