// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 03-24-2020
// ***********************************************************************
// <copyright file="ITexture.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface ITexture
    /// </summary>
    public interface ITexture
    {
        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        int Width { get; }
        
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        int Height { get; }

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