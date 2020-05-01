// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 04-12-2020
//
// Last Modified By : alexs
// Last Modified On : 04-13-2020
// ***********************************************************************
// <copyright file="TextureData.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EndlessEngine.Graphics
{
    /// <summary>
    /// Struct TextureData
    /// </summary>
    public struct TextureData
    {
        /// <summary>
        /// The texture format
        /// </summary>
        public TextureFormat Format;
        
        /// <summary>
        /// The min filter
        /// </summary>
        public TextureMinFilter MinFilter;
        
        /// <summary>
        /// The mag filter
        /// </summary>
        public TextureMagFilter MagFilter;
        
        /// <summary>
        /// The wrap mode
        /// </summary>
        public TextureWrapMode WrapMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextureData"/> struct.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="minFilter">The min filter.</param>
        /// <param name="magFilter">The mag filter.</param>
        /// <param name="wrapMode">The wrap mode.</param>
        public TextureData(
            TextureFormat format,
            TextureMinFilter minFilter, TextureMagFilter magFilter,
            TextureWrapMode wrapMode)
        {
            Format = format;
            MinFilter = minFilter;
            MagFilter = magFilter;
            WrapMode = wrapMode;
        }

        /// <summary>
        /// Gets the default texture data.
        /// </summary>
        /// <value>The default texture data.</value>
        public static TextureData Default =>
            new TextureData
            {
                Format = TextureFormat.Rgba8,
                WrapMode = TextureWrapMode.Repeat,
                MagFilter = TextureMagFilter.Linear,
                MinFilter = TextureMinFilter.LinearMipmapLinear
            };
    }

    /// <summary>
    /// Enum TextureWrapMode
    /// </summary>
    public enum TextureWrapMode
    {
        /// <summary>
        /// The clamp to edge
        /// </summary>
        ClampToEdge,
        /// <summary>
        /// The clamp to border
        /// </summary>
        ClampToBorder,
        /// <summary>
        /// The repeat
        /// </summary>
        Repeat
    }

    /// <summary>
    /// Enum TextureMagFilter
    /// </summary>
    public enum TextureMagFilter
    {
        /// <summary>
        /// The nearest
        /// </summary>
        Nearest,
        /// <summary>
        /// The linear
        /// </summary>
        Linear
    }

    /// <summary>
    /// Enum TextureMinFilter
    /// </summary>
    public enum TextureMinFilter
    {
        /// <summary>
        /// The nearest
        /// </summary>
        Nearest,
        /// <summary>
        /// The linear
        /// </summary>
        Linear,
        /// <summary>
        /// The nearest mipmap nearest
        /// </summary>
        NearestMipmapNearest,
        /// <summary>
        /// The linear mipmap nearest
        /// </summary>
        LinearMipmapNearest,
        /// <summary>
        /// The nearest mipmap linear
        /// </summary>
        NearestMipmapLinear,
        /// <summary>
        /// The linear mipmap linear
        /// </summary>
        LinearMipmapLinear
    }

    /// <summary>
    /// Enum TextureFormat
    /// </summary>
    public enum TextureFormat
    {
        /// <summary>
        /// The rgba
        /// </summary>
        Rgba,
        /// <summary>
        /// The rgba8
        /// </summary>
        Rgba8,
        /// <summary>
        /// The RGB
        /// </summary>
        Rgb,
        /// <summary>
        /// The RGB8
        /// </summary>
        Rgb8
    }
}