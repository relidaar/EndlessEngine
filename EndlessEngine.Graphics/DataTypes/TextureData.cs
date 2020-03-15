namespace EndlessEngine.Graphics.DataTypes
{
    public struct TextureData
    {
        public TextureFormat Format;
        public TextureMinFilter MinFilter;
        public TextureMagFilter MagFilter;
        public TextureWrapMode WrapMode;

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

        public static TextureData Default =>
            new TextureData
            {
                Format = TextureFormat.Rgba8,
                WrapMode = TextureWrapMode.Repeat,
                MagFilter = TextureMagFilter.Linear,
                MinFilter = TextureMinFilter.LinearMipmapLinear
            };
    }

    public enum TextureWrapMode
    {
        ClampToEdge,
        ClampToBorder,
        Repeat
    }

    public enum TextureMagFilter
    {
        Nearest,
        Linear,
    }

    public enum TextureMinFilter
    {
        Nearest,
        Linear,
        NearestMipmapNearest,
        LinearMipmapNearest,
        NearestMipmapLinear,
        LinearMipmapLinear,
    }
    
    public enum TextureFormat
    {
        Rgba,
        Rgba8,
        Rgb,
        Rgb8,
    }
}