using System;
using System.IO;
using EndlessEngine.Graphics.Interfaces;
using OpenGL;
using StbImageSharp;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLTexture : ITexture
    {
        private readonly uint id;
        private string path;

        public OpenGLTexture(string path)
        {
            this.path = path ?? throw new ArgumentNullException();

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

                Width = image.Width;
                Height = image.Height;

                id = Gl.GenTexture();
                Gl.BindTexture(TextureTarget.Texture2d, id);

                Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureMinFilter,
                    Gl.LINEAR_MIPMAP_LINEAR);
                Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureMagFilter, Gl.LINEAR);
                Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapS, Gl.CLAMP_TO_EDGE);
                Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapT, Gl.CLAMP_TO_EDGE);

                Gl.TexImage2D(TextureTarget.Texture2d, 0, internalFormat, Width, Height, 0, dataFormat,
                    PixelType.UnsignedByte, image.Data);
                Gl.GenerateMipmap(TextureTarget.Texture2d);

                Gl.BindTexture(TextureTarget.Texture2d, 0);
            }
        }

        public int Width { get; }
        public int Height { get; }

        public void Bind()
        {
            Gl.BindTexture(TextureTarget.Texture2d, id);
        }

        public void Unbind()
        {
            Gl.BindTexture(TextureTarget.Texture2d, 0);
        }
    }
}