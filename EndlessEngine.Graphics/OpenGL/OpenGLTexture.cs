// ***********************************************************************
// Assembly         : EndlessEngine.Graphics
// Author           : alexs
// Created          : 03-24-2020
//
// Last Modified By : alexs
// Last Modified On : 05-01-2020
// ***********************************************************************
// <copyright file="OpenGLTexture.cs" company="EndlessEngine.Graphics">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;
using StbImageSharp;

namespace EndlessEngine.Graphics.OpenGL
{
    /// <summary>
    /// Class OpenGLTexture.
    /// Implements the <see cref="EndlessEngine.Graphics.Interfaces.ITexture" />
    /// </summary>
    /// <seealso cref="EndlessEngine.Graphics.Interfaces.ITexture" />
    public class OpenGLTexture : ITexture
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly uint _id;
        
        /// <summary>
        /// The path
        /// </summary>
        private string _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLTexture"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="textureData">The texture data.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="ArgumentOutOfRangeException">Format not supported</exception>
        public OpenGLTexture(string path, in TextureData textureData)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException();

            if (File.Exists(path))
                throw new FileNotFoundException();

            _path = path;
            
            using (var stream = File.OpenRead(path))
            {
                var image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

                InternalFormat internalFormat;
                PixelFormat dataFormat;
                switch (image.Comp)
                {
                    case ColorComponents.RedGreenBlue:
                        internalFormat = InternalFormat.Rgb8;
                        dataFormat = PixelFormat.Rgb;
                        break;
                    case ColorComponents.RedGreenBlueAlpha:
                        internalFormat = InternalFormat.Rgba8;
                        dataFormat = PixelFormat.Rgba;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Format not supported");
                }

                var minFilter = ToOpenGLFormat(textureData.MinFilter);
                var magFilter = ToOpenGLFormat(textureData.MagFilter);
                var wrapMode = ToOpenGLFormat(textureData.WrapMode);

                Width = image.Width;
                Height = image.Height;

                _id = Gl.GenTexture();
                Gl.BindTexture(TextureTarget.Texture2d, _id);

                Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureMinFilter, minFilter);
                Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureMagFilter, magFilter);
                Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapS, wrapMode);
                Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapT, wrapMode);

                Gl.TexImage2D(TextureTarget.Texture2d, 0, internalFormat, Width, Height, 0, dataFormat,
                    PixelType.UnsignedByte, image.Data);
                Gl.GenerateMipmap(TextureTarget.Texture2d);

                Gl.BindTexture(TextureTarget.Texture2d, 0);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLTexture"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="data">The data.</param>
        /// <param name="textureData">The texture data.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public OpenGLTexture(int width, int height, object data, in TextureData textureData)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException();

            if (data == null)
                throw new ArgumentNullException();

            Width = width;
            Height = height;

            var (internalFormat, pixelFormat) = ToOpenGLFormat(textureData.Format);
            var minFilter = ToOpenGLFormat(textureData.MinFilter);
            var magFilter = ToOpenGLFormat(textureData.MagFilter);
            var wrapMode = ToOpenGLFormat(textureData.WrapMode);

            _id = Gl.GenTexture();
            Gl.BindTexture(TextureTarget.Texture2d, _id);

            Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureMinFilter, minFilter);
            Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureMagFilter, magFilter);
            Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapS, wrapMode);
            Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapT, wrapMode);

            Gl.TexImage2D(TextureTarget.Texture2d, 0, internalFormat, Width, Height, 0, pixelFormat,
                PixelType.UnsignedByte, data);
            Gl.GenerateMipmap(TextureTarget.Texture2d);

            Gl.BindTexture(TextureTarget.Texture2d, 0);
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; }
        
        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; }

        /// <summary>
        /// Binds this instance.
        /// </summary>
        public void Bind()
        {
            Gl.BindTexture(TextureTarget.Texture2d, _id);
        }

        /// <summary>
        /// Unbinds this instance.
        /// </summary>
        public void Unbind()
        {
            Gl.BindTexture(TextureTarget.Texture2d, 0);
        }

        #region Converters

        /// <summary>
        /// Converts to OpenGL format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>System.ValueTuple&lt;InternalFormat, PixelFormat&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Format not supported</exception>
        private static (InternalFormat internalFormat, PixelFormat pixelFormat) ToOpenGLFormat(TextureFormat format)
        {
            switch (format)
            {
                case TextureFormat.Rgba:
                    return (InternalFormat.Rgba, PixelFormat.Rgba);
                case TextureFormat.Rgba8:
                    return (InternalFormat.Rgba8, PixelFormat.Rgba);
                case TextureFormat.Rgb:
                    return (InternalFormat.Rgb, PixelFormat.Rgb);
                case TextureFormat.Rgb8:
                    return (InternalFormat.Rgb8, PixelFormat.Rgb);
                default:
                    throw new ArgumentOutOfRangeException("Format not supported");
            }
        }

        /// <summary>
        /// Converts to OpenGL format.
        /// </summary>
        /// <param name="minFilter">The minimum filter.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Format not supported</exception>
        private static int ToOpenGLFormat(TextureMinFilter minFilter)
        {
            switch (minFilter)
            {
                case TextureMinFilter.Nearest:
                    return Gl.NEAREST;
                case TextureMinFilter.Linear:
                    return Gl.LINEAR;
                case TextureMinFilter.NearestMipmapNearest:
                    return Gl.NEAREST_MIPMAP_NEAREST;
                case TextureMinFilter.LinearMipmapNearest:
                    return Gl.LINEAR_MIPMAP_NEAREST;
                case TextureMinFilter.NearestMipmapLinear:
                    return Gl.NEAREST_MIPMAP_LINEAR;
                case TextureMinFilter.LinearMipmapLinear:
                    return Gl.LINEAR_MIPMAP_LINEAR;
                default:
                    throw new ArgumentOutOfRangeException("Format not supported");
            }
        }

        /// <summary>
        /// Converts to OpenGL format.
        /// </summary>
        /// <param name="magFilter">The mag filter.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Format not supported</exception>
        private static int ToOpenGLFormat(TextureMagFilter magFilter)
        {
            switch (magFilter)
            {
                case TextureMagFilter.Nearest:
                    return Gl.NEAREST;
                case TextureMagFilter.Linear:
                    return Gl.LINEAR;
                default:
                    throw new ArgumentOutOfRangeException("Format not supported");
            }
        }

        /// <summary>
        /// Converts to OpenGL format.
        /// </summary>
        /// <param name="wrapMode">The wrap mode.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Format not supported</exception>
        private static int ToOpenGLFormat(TextureWrapMode wrapMode)
        {
            switch (wrapMode)
            {
                case TextureWrapMode.ClampToEdge:
                    return Gl.CLAMP_TO_EDGE;
                case TextureWrapMode.ClampToBorder:
                    return Gl.CLAMP_TO_BORDER;
                case TextureWrapMode.Repeat:
                    return Gl.REPEAT;
                default:
                    throw new ArgumentOutOfRangeException("Format not supported");
            }
        }

        #endregion
    }
}