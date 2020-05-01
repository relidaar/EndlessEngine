// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="Sprite.cs" company="EndlessEngine.Graphics">
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
    /// Class Sprite.
    /// </summary>
    public class Sprite
    {
        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <value>The texture.</value>
        public ITexture Texture { get; private set; }
        
        /// <summary>
        /// The position
        /// </summary>
        public Vector2 Position;
        /// <summary>
        /// The size
        /// </summary>
        public Vector2 Size;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Sprite(ITexture texture, int x, int y, int width, int height)
            : this(texture, new Vector2(x, y), new Vector2(width, height))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="size">The size.</param>
        public Sprite(ITexture texture, int x, int y, int size)
            : this(texture, new Vector2(x, y), new Vector2(size, size))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <param name="position">The position.</param>
        /// <param name="size">The size.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Sprite(ITexture texture, in Vector2 position, in Vector2 size)
        {
            if (size.X < 0 || size.Y < 0)
                throw new ArgumentOutOfRangeException();
            
            Texture = texture ?? throw new ArgumentNullException();
            Position = position;
            Size = size;
        }
    }
}