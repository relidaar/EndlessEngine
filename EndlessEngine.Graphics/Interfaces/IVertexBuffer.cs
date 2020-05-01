// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 03-24-2020
// ***********************************************************************
// <copyright file="IVertexBuffer.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IVertexBuffer
    /// </summary>
    public interface IVertexBuffer
    {
        /// <summary>
        /// Gets or sets the buffer layout.
        /// </summary>
        /// <value>The buffer layout.</value>
        IBufferLayout Layout { get; set; }
        
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