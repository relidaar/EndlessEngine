using System;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLIndexBuffer : IIndexBuffer, IDisposable
    {
        private readonly uint id;
        private readonly int[] indices;

        public OpenGLIndexBuffer(int[] indices)
        {
            this.indices = indices;
            var size = (uint) (indices.Length * sizeof(int));

            id = Gl.GenBuffer();
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, id);
            Gl.BufferData(BufferTarget.ElementArrayBuffer, size, indices, BufferUsage.StaticDraw);
        }

        public void Dispose()
        {
            Gl.DeleteBuffers(id);
        }

        public int Count => indices.Length;

        public void Bind()
        {
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, id);
        }

        public void Unbind()
        {
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }
    }
}