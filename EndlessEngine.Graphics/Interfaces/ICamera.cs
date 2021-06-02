// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="ICamera.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using EndlessEngine.Math;

namespace EndlessEngine.Graphics.Interfaces
{
    /// <summary>
    /// Interface ICamera
    /// </summary>
    public interface ICamera
    {
        /// <summary>
        /// Gets the projection matrix.
        /// </summary>
        /// <value>The projection matrix.</value>
        Matrix4 ProjectionMatrix { get; }
        
        /// <summary>
        /// Gets the view matrix.
        /// </summary>
        /// <value>The view matrix.</value>
        Matrix4 ViewMatrix { get; }
        
        /// <summary>
        /// Gets the view projection matrix.
        /// </summary>
        /// <value>The view projection matrix.</value>
        Matrix4 ViewProjectionMatrix { get; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        float Rotation { get; set; }
        
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        Vector3 Position { get; set; }
    }
}