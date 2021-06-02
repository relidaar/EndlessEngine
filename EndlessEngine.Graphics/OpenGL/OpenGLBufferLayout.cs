// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="OpenGLBufferLayout.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using EndlessEngine.Graphics.Interfaces;

namespace EndlessEngine.Graphics.OpenGL
{
    /// <summary>
    /// Class OpenGLBufferLayout.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.IBufferLayout" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.IBufferLayout" />
    public class OpenGLBufferLayout : IBufferLayout
    {
        /// <summary>
        /// The buffer elements
        /// </summary>
        private readonly BufferElement[] _elements;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLBufferLayout"/> class.
        /// </summary>
        /// <param name="elements">The buffer elements.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public OpenGLBufferLayout(params BufferElement[] elements)
        {
            _elements = elements ?? throw new ArgumentNullException();
            CalculateOffsetAndStride();
        }

        /// <summary>
        /// Gets the buffer elements.
        /// </summary>
        /// <value>The buffer elements.</value>
        public IEnumerable<BufferElement> Elements => _elements;
        
        /// <summary>
        /// Gets the stride.
        /// </summary>
        /// <value>The stride.</value>
        public int Stride { get; private set; }

        /// <summary>
        /// Calculates the offset and stride.
        /// </summary>
        private void CalculateOffsetAndStride()
        {
            var offset = 0;
            Stride = 0;

            for (var i = 0; i < _elements.Length; i++)
            {
                var element = _elements[i];
                element.Offset = offset;
                _elements[i] = element;

                offset += element.Size;
                Stride += element.Size;
            }
        }
    }
}