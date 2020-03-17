using System;
using System.IO;
using EndlessEngine.Graphics.DataTypes;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;
using StbImageSharp;
using TextureMagFilter = EndlessEngine.Graphics.DataTypes.TextureMagFilter;
using TextureMinFilter = EndlessEngine.Graphics.DataTypes.TextureMinFilter;
using TextureWrapMode = EndlessEngine.Graphics.DataTypes.TextureWrapMode;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLTexture : ITexture
    {
        private readonly uint _id;
        private string _path;

        public OpenGLTexture(string path, TextureData textureData)
        {
            _path = path ?? throw new ArgumentNullException();

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

        public OpenGLTexture(uint width, uint height, object data, TextureData textureData)
        {
            Width = (int) width;
            Height = (int) height;

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

        public int Width { get; }
        public int Height { get; }

        public void Bind()
        {
            Gl.BindTexture(TextureTarget.Texture2d, _id);
        }

        public void Unbind()
        {
            Gl.BindTexture(TextureTarget.Texture2d, 0);
        }

        #region Converters

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