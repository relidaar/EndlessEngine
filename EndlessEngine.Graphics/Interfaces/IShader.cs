// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="IShader.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using EndlessEngine.Math;

namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface IShader
    /// </summary>
    public interface IShader
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }
        
        /// <summary>
        /// Binds this instance.
        /// </summary>
        void Bind();
        
        /// <summary>
        /// Unbinds this instance.
        /// </summary>
        void Unbind();

        #region Uniforms

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        void SetUniform(string name, float value);
        
        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        void SetUniform(string name, float v1, float v2);
        
        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        /// <param name="v3">The third element.</param>
        void SetUniform(string name, float v1, float v2, float v3);
        
        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        /// <param name="v3">The third element.</param>
        /// <param name="v4">The fourth element.</param>
        void SetUniform(string name, float v1, float v2, float v3, float v4);

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        void SetUniform(string name, int value);
        
        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        void SetUniform(string name, int v1, int v2);
        
        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        /// <param name="v3">The third element.</param>
        void SetUniform(string name, int v1, int v2, int v3);
        
        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="v1">The first element.</param>
        /// <param name="v2">The second element.</param>
        /// <param name="v3">The third element.</param>
        /// <param name="v4">The fourth element.</param>
        void SetUniform(string name, int v1, int v2, int v3, int v4);

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="vertex">The vertex.</param>
        void SetUniform(string name, in Vector2 vertex);
        
        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="vertex">The vertex.</param>
        void SetUniform(string name, in Vector3 vertex);
        
        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="vertex">The vertex.</param>
        void SetUniform(string name, in Vector4 vertex);

        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="transpose">if set to <c>true</c> [transpose].</param>
        /// <param name="matrix">The matrix.</param>
        void SetUniform(string name, bool transpose, in Matrix2 matrix);
        
        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="transpose">if set to <c>true</c> [transpose].</param>
        /// <param name="matrix">The matrix.</param>
        void SetUniform(string name, bool transpose, in Matrix3 matrix);
        
        /// <summary>
        /// Sets the uniform.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="transpose">if set to <c>true</c> [transpose].</param>
        /// <param name="matrix">The matrix.</param>
        void SetUniform(string name, bool transpose, in Matrix4 matrix);

        #endregion
    }
}