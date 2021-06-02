// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 04-13-2020
// ***********************************************************************
// <copyright file="IBufferLayout.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IBufferLayout
    /// </summary>
    public interface IBufferLayout
    {
        /// <summary>
        /// Gets the buffer elements.
        /// </summary>
        /// <value>The buffer elements.</value>
        IEnumerable<BufferElement> Elements { get; }
        
        /// <summary>
        /// Gets the stride.
        /// </summary>
        /// <value>The stride.</value>
        int Stride { get; }
    }
}