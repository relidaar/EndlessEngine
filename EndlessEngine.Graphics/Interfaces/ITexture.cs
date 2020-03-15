namespace EndlessEngine.Graphics.Interfaces
{
    public interface ITexture
    {
        int Width { get; }
        int Height { get; }

        void Bind();
        void Unbind();
    }

    public enum TextureFormat
    {
        Rgba,
        Rgba8,
        Rgb,
        Rgb8,
    }
}