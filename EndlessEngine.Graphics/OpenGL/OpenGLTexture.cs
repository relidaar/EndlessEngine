using EndlessEngine.Graphics.Interfaces;
using OpenGL;
using System.Drawing;
using System.IO;
using SixLabors.ImageSharp;

namespace EndlessEngine.Graphics.OpenGL
{
    public class OpenGLTexture : ITexture
    {
        public int Width { get; }
        public int Height { get; }

        private readonly uint id;
        private string path;

        public OpenGLTexture(string path)
        {
            this.path = path;
            var image = Image.Load(path);
            Width = image.Width;
            Height = image.Height;

            id = Gl.CreateTexture(TextureTarget.Texture2d);
            Gl.TextureStorage2D(id, 1, InternalFormat.Rgb8, Width, Height);
            
            Gl.TextureParameter(id, TextureParameterName.TextureMinFilter, Gl.LINEAR);
            Gl.TextureParameter(id, TextureParameterName.TextureMagFilter, Gl.LINEAR);

            Gl.TextureSubImage2D(id, 0, 0, 0, 
                Width, Height, PixelFormat.Rgb, PixelType.UnsignedByte, image);
        }

        public void Bind(uint slot = 0)
        {
            Gl.BindTextureUnit(slot, id);
        }
    }
}