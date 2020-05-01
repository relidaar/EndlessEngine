// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="IVertexArray.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IVertexArray
    /// </summary>
    public interface IVertexArray
    {
        /// <summary>
        /// Gets the vertex buffers.
        /// </summary>
        /// <value>The vertex buffers.</value>
        IEnumerable<IVertexBuffer> VertexBuffers { get; }
        
        /// <summary>
        /// Gets the index buffer.
        /// </summary>
        /// <value>The index buffer.</value>
        IIndexBuffer IndexBuffer { get; }
        
        /// <summary>
        /// Adds the specified vertex buffer.
        /// </summary>
        /// <param name="vertexBuffer">The vertex buffer.</param>
        void Add(IVertexBuffer vertexBuffer);
        
        /// <summary>
        /// Adds the specified index buffer.
        /// </summary>
        /// <param name="indexBuffer">The index buffer.</param>
        void Add(IIndexBuffer indexBuffer);
        
        /// <summary>
        /// Binds this instance.
        /// </summary>
        void Bind();
        
        /// <summary>
        /// Unbinds this instance.
        /// </summary>
        void Unbind();
    }
}