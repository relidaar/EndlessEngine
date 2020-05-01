// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="OpenGLVertexBuffer.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;

namespace EndlessEngine.Graphics.OpenGL
{
    /// <summary>
    /// Class OpenGLVertexBuffer.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IVertexBuffer" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IVertexBuffer" />
    /// <seealso cref="System.IDisposable" />
    public class OpenGLVertexBuffer : IVertexBuffer, IDisposable
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly uint _id;
        
        /// <summary>
        /// The vertices
        /// </summary>
        private readonly float[] _vertices;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLVertexBuffer"/> class.
        /// </summary>
        /// <param name="vertices">The vertices.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public OpenGLVertexBuffer(float[] vertices)
        {
            _vertices = vertices ?? throw new ArgumentNullException();
            var size = (uint) (vertices.Length * sizeof(float));

            _id = Gl.GenBuffer();
            Gl.BindBuffer(BufferTarget.ArrayBuffer, _id);
            Gl.BufferData(BufferTarget.ArrayBuffer, size, vertices, BufferUsage.StaticDraw);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Gl.DeleteBuffers(_id);
        }

        /// <summary>
        /// Gets or sets the layout.
        /// </summary>
        /// <value>The layout.</value>
        public IBufferLayout Layout { get; set; }

        /// <summary>
        /// Binds this instance.
        /// </summary>
        public void Bind()
        {
            Gl.BindBuffer(BufferTarget.ArrayBuffer, _id);
        }

        /// <summary>
        /// Unbinds this instance.
        /// </summary>
        public void Unbind()
        {
            Gl.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
    }
}