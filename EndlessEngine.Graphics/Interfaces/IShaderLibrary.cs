// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 03-24-2020
// ***********************************************************************
// <copyright file="IShaderLibrary.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IShaderLibrary
    /// </summary>
    public interface IShaderLibrary
    {
        /// <summary>
        /// Adds the specified shader.
        /// </summary>
        /// <param name="shader">The shader.</param>
        void Add(IShader shader);
        
        /// <summary>
        /// Loads the specified shader.
        /// </summary>
        /// <param name="name">The shader name.</param>
        /// <param name="vertexShaderPath">The vertex shader path.</param>
        /// <param name="fragmentShaderPath">The fragment shader path.</param>
        /// <returns>IShader.</returns>
        IShader Load(string name, string vertexShaderPath, string fragmentShaderPath);

        /// <summary>
        /// Gets the specified shader.
        /// </summary>
        /// <param name="name">The shader name.</param>
        /// <returns>IShader.</returns>
        IShader Get(string name);
    }
}