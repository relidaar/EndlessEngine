using System;
using System.Collections.Generic;
using EndlessEngine.Core;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLVertexArray : IVertexArray
    {
        private readonly uint id;
        private readonly IList<IVertexBuffer> vertexBuffers;

        public OpenGLVertexArray()
        {
            vertexBuffers = new List<IVertexBuffer>();
            id = Gl.CreateVertexArray();
        }

        public IIndexBuffer IndexBuffer { get; private set; }

        public void Bind()
        {
            Gl.BindVertexArray(id);
        }

        public void Unbind()
        {
            Gl.BindVertexArray(0);
        }

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
                    ShaderData.GetCount(element.Type),
                    ToOpenGLDataType(element.Type),
                    element.Normalized,
                    vertexBuffer.Layout.Stride,
                    new IntPtr(element.Offset)
                );

                index++;
            }

            vertexBuffers.Add(vertexBuffer);
        }

        public void Add(IIndexBuffer indexBuffer)
        {
            Bind();
            indexBuffer.Bind();

            IndexBuffer = indexBuffer;
        }

        private static VertexAttribType ToOpenGLDataType(ShaderDataType type)
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