// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 04-13-2020
// ***********************************************************************
// <copyright file="WindowProperties.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EndlessEngine.Graphics
{
    /// <summary>
    /// Struct WindowProperties
    /// </summary>
    public struct WindowProperties
    {
        /// <summary>
        /// The width
        /// </summary>
        public int Width;
        
        /// <summary>
        /// The height
        /// </summary>
        public int Height;
        
        /// <summary>
        /// The title
        /// </summary>
        public string Title;
        
        /// <summary>
        /// The x coordinate
        /// </summary>
        public int X;
        
        /// <summary>
        /// The y coordinate
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowProperties"/> struct.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="title">The title.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public WindowProperties(int width, int height, string title, int x, int y)
        {
            Width = width;
            Height = height;
            Title = title;
            X = x;
            Y = y;
        }
    }
}