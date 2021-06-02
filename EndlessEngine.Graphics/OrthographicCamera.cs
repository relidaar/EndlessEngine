// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="OrthographicCamera.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Math;

namespace EndlessEngine.Graphics
{
    /// <summary>
    /// Class OrthographicCamera.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.ICamera" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.ICamera" />
    public class OrthographicCamera : ICamera
    {
        /// <summary>
        /// The position
        /// </summary>
        private Vector3 _position;
        
        /// <summary>
        /// The rotation
        /// </summary>
        private float _rotation;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrthographicCamera"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public OrthographicCamera(int width, int height)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException();
            
            ProjectionMatrix = Matrix4.Orthographic(0, width, 0, height);
            ViewMatrix = Matrix4.Identity;
            ViewProjectionMatrix = ProjectionMatrix * ViewMatrix;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrthographicCamera"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="top">The top.</param>
        public OrthographicCamera(float left, float right, float bottom, float top)
        {
            ProjectionMatrix = Matrix4.Orthographic(left, right, bottom, top);
            ViewMatrix = Matrix4.Identity;
            ViewProjectionMatrix = ProjectionMatrix * ViewMatrix;
        }

        /// <summary>
        /// Gets the projection matrix.
        /// </summary>
        /// <value>The projection matrix.</value>
        public Matrix4 ProjectionMatrix { get; }
        
        /// <summary>
        /// Gets the view matrix.
        /// </summary>
        /// <value>The view matrix.</value>
        public Matrix4 ViewMatrix { get; private set; }
        
        /// <summary>
        /// Gets the view projection matrix.
        /// </summary>
        /// <value>The view projection matrix.</value>
        public Matrix4 ViewProjectionMatrix { get; private set; }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        public float Rotation
        {
            get => _rotation;
            set
            {
                RecalculateViewMatrix();
                _rotation = value;
            }
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Vector3 Position
        {
            get => _position;
            set
            {
                RecalculateViewMatrix();
                _position = value;
            }
        }

        /// <summary>
        /// Recalculates the view matrix.
        /// </summary>
        private void RecalculateViewMatrix()
        {
            var transform = Matrix4.Translated(_position) * 
                            Matrix4.Rotated(_rotation, 0, 0, 1);

            ViewMatrix = transform.Invert();
            ViewProjectionMatrix = ProjectionMatrix * ViewMatrix;
        }
    }
}