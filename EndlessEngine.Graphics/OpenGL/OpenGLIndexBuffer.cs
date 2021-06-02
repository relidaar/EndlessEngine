// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="OpenGLIndexBuffer.cs" company="EndlessEngine.Graphics">
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
    /// Class OpenGLIndexBuffer.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IIndexBuffer" />
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IIndexBuffer" />
    /// <seealso cref="System.IDisposable" />
    public class OpenGLIndexBuffer : IIndexBuffer, IDisposable
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly uint _id;
        
        /// <summary>
        /// The indices
        /// </summary>
        private readonly int[] _indices;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLIndexBuffer"/> class.
        /// </summary>
        /// <param name="indices">The indices.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public OpenGLIndexBuffer(int[] indices)
        {
            _indices = indices ?? throw new ArgumentNullException();
            var size = (uint) (indices.Length * sizeof(int));

            _id = Gl.GenBuffer();
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, _id);
            Gl.BufferData(BufferTarget.ElementArrayBuffer, size, indices, BufferUsage.StaticDraw);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Gl.DeleteBuffers(_id);
        }

        /// <summary>
        /// Gets the indices count.
        /// </summary>
        /// <value>The indices count.</value>
        public int Count => _indices.Length;

        /// <summary>
        /// Binds this instance.
        /// </summary>
        public void Bind()
        {
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, _id);
        }

        /// <summary>
        /// Unbinds this instance.
        /// </summary>
        public void Unbind()
        {
            Gl.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }
    }
}