using System;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics
{
    public class OpenGLVertexBuffer : IBuffer, IDisposable
    {
        public float[] Vertices { get; }
        private readonly uint _id; 
        
        public OpenGLVertexBuffer(float[] vertices)
        {
            Vertices = vertices;
            var size = (uint) (vertices.Length * sizeof(float));
           
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

    public class OpenGLIndexBuffer : IBuffer, IDisposable
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