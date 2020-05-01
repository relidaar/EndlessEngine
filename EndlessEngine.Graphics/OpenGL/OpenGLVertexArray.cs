// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="OpenGLVertexArray.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using EndlessEngine.Core;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    /// <summary>
    /// Class OpenGLVertexArray.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IVertexArray" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IVertexArray" />
    public class OpenGLVertexArray : IVertexArray
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly uint _id;
        
        /// <summary>
        /// The vertex buffers
        /// </summary>
        private readonly IList<IVertexBuffer> _vertexBuffers;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLVertexArray"/> class.
        /// </summary>
        public OpenGLVertexArray()
        {
            _vertexBuffers = new List<IVertexBuffer>();
            _id = Gl.CreateVertexArray();
        }

        /// <summary>
        /// Gets the vertex buffers.
        /// </summary>
        /// <value>The vertex buffers.</value>
        public IEnumerable<IVertexBuffer> VertexBuffers => _vertexBuffers;
        
        /// <summary>
        /// Gets the index buffer.
        /// </summary>
        /// <value>The index buffer.</value>
        public IIndexBuffer IndexBuffer { get; private set; }

        /// <summary>
        /// Binds this instance.
        /// </summary>
        public void Bind()
        {
            Gl.BindVertexArray(_id);
        }

        /// <summary>
        /// Unbinds this instance.
        /// </summary>
        public void Unbind()
        {
            Gl.BindVertexArray(0);
        }

        /// <summary>
        /// Adds the specified vertex buffer.
        /// </summary>
        /// <param name="vertexBuffer">The vertex buffer.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(IVertexBuffer vertexBuffer)
        {
            if (vertexBuffer?.Layout == null)
                throw new ArgumentNullException();

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

        /// <summary>
        /// Adds the specified index buffer.
        /// </summary>
        /// <param name="indexBuffer">The index buffer.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(IIndexBuffer indexBuffer)
        {
            if (indexBuffer == null)
                throw new ArgumentNullException();

            Bind();
            indexBuffer.Bind();

            IndexBuffer = indexBuffer;
        }

        /// <summary>
        /// Converts to OpenGL data type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>VertexAttribType.</returns>
        public static VertexAttribType ToOpenGLDataType(ShaderDataType type)
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