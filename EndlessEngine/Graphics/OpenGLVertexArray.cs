using System;
using System.Collections.Generic;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.System;
using OpenGL;

namespace EndlessEngine.Graphics
{
    public class OpenGLVertexArray : IVertexArray
    {
        private readonly uint _id;
        private readonly IList<IVertexBuffer> _vertexBuffers;
        private IIndexBuffer _indexBuffer;

        public OpenGLVertexArray()
        {
            _vertexBuffers = new List<IVertexBuffer>();
            _id = Gl.CreateVertexArray();
        }

        public void Bind() => 
            Gl.BindVertexArray(_id);

        public void Unbind() =>
            Gl.BindVertexArray(0);

        public void Add(IVertexBuffer vertexBuffer)
        {
            Bind();
            vertexBuffer.Bind();

            uint index = 0;
            foreach (var element in vertexBuffer.Layout.Elements)
            {
                Gl.EnableVertexAttribArray(index);
                Gl.VertexAttribPointer(
                    index, 
                    element.GetCount(), 
                    ToOpenGLDataType(element.Type), 
                    element.Normalized,
                    vertexBuffer.Layout.Stride, 
                    new IntPtr(element.Offset)
                    );
                
                index++;
            }

            _vertexBuffers.Add(vertexBuffer);
        }

        public void Add(IIndexBuffer indexBuffer)
        {
            Bind();
            indexBuffer.Bind();
         
            _indexBuffer = indexBuffer;
        }

        private VertexAttribType ToOpenGLDataType(ShaderDataType type)
        {
            switch (type)
            {
                case ShaderDataType.Float:
                case ShaderDataType.Float2:
                case ShaderDataType.Float3:
                case ShaderDataType.Float4:
                case ShaderDataType.Mat3:
                case ShaderDataType.Mat4:
                    return VertexAttribType.Float;
                case ShaderDataType.Int:
                case ShaderDataType.Int2:
                case ShaderDataType.Int3:
                case ShaderDataType.Int4:
                    return VertexAttribType.Int;
                case ShaderDataType.Bool:
                    return VertexAttribType.Byte;
                default:
                    Log.Instance.Error("Unknown ShaderDataType");
                    return 0;
            }
        }
    }
}