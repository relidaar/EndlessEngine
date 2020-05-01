// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 03-24-2020
// ***********************************************************************
// <copyright file="IIndexBuffer.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IIndexBuffer
    /// </summary>
    public interface IIndexBuffer
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        int Count { get; }
        
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