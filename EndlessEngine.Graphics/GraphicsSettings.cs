namespace EndlessEngine.Graphics
{
    public static class Paths
    {
        public const string ResourcesPath = "resources/";
        public static readonly string ShadersPath = $"{ResourcesPath}shaders/";
        public static readonly string GraphicsSettingsPath = $"{ResourcesPath}graphics.settings.json";
        public static readonly string ShaderSettingsPath = $"{ResourcesPath}shader.settings.json";
    }
    
    public struct GraphicsSettings
    {
        public int ApiVersionMajor;
        public int ApiVersionMinor;

        public bool Maximized;
        public bool Resizable;
        public bool DoubleBuffer;
        public bool Decorated;
    }
    
    public struct ShaderSettings
    {
        public string ShaderName;
        public string VertexShaderFilename;
        public string FragmentShaderFilename;

        public string VerticesPosition;
        public string TextureCoordinates;

        public string ViewProjectionUniform;
        public string TransformUniform;
        public string TextureUniform;
        public string ColorUniform;
        public string TilingFactorUniform;
    }
}